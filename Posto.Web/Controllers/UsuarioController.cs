using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using Posto.Infrastructure.Context;
using Posto.Web.Helpers;

namespace Posto.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly IEmpresaService _empresaService;
        private readonly IEnderecoService _enderecoService;
        public UsuarioController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IUsuarioService usuarioService, IMapper mapper, IEmpresaUsuarioService empresaUsuarioService,
            IEmpresaService empresaService, IEnderecoService enderecoService)
        {
            _signManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _empresaUsuarioService = empresaUsuarioService;
            _empresaService = empresaService;
            _enderecoService = enderecoService;
        }

        public IActionResult Index()
        {
            ViewBag.UsersIdentity = _userManager.Users;
            var UsuariosVM = _mapper.Map<IEnumerable<UsuarioVM>>(_usuarioService.Get(u => u.Ativo == true));
            ViewBag.Users = UsuariosVM;
            return View();
        }

        public IActionResult NovoUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoUsuario(UsuarioIdentityVM usuario)
        {
            try
            {
              
                if(ModelState.IsValid)
                {
                    string empresa_Global = Request.Cookies["empresa_global"];

                    IdentityUser userIdentity = CarregarUsuarioIdentity(new IdentityUser(), usuario);

                    var resultIdentity = await _userManager.CreateAsync(userIdentity, usuario.Password);

                    if (resultIdentity.Succeeded)
                    {
                        var usuarioEntity = _mapper.Map<Usuario>(usuario);
                        var userGetId = await _userManager.FindByNameAsync(usuario.UserName);
                        usuarioEntity.IdentityUser = userGetId.Id;
                        _usuarioService.Add(usuarioEntity);

                        var resultPerfil = await _userManager.AddToRoleAsync(userIdentity, EnumHelper.GetName(usuario.Perfil));
                        if (resultPerfil.Succeeded)
                        {
                            var empresa = _empresaService.GetById(Convert.ToInt32(empresa_Global));
                            EmpresaUsuario eUsuario = new EmpresaUsuario(usuarioEntity.Id_Usuario, empresa.IdEmpresa);
                            _empresaUsuarioService.Add(eUsuario);
                            Endereco endereco = new Endereco(usuario.Endereco_Complemento, usuario.LinkGoogleMaps);
                            var end = _enderecoService.Add(endereco);
                            usuarioEntity.Id_Endereco = end.Id_Endereco;
                            _usuarioService.Update(usuarioEntity);

                            var resultRole = await _userManager.AddClaimsAsync(userGetId, new Claim[] {
                                new Claim(EnumTypeClaims.Perfil.ToString(), usuario.Perfil.ToString()),
                                new Claim(EnumTypeClaims.Nome.ToString(), usuarioEntity.Nome),
                                new Claim(EnumTypeClaims.Id_Usuario.ToString(), usuarioEntity.Id_Usuario.ToString())
                            });
                            if (resultRole.Succeeded)
                            {
                                return Redirect("Index");
                            }


                            return View(usuario);
                        }
                    }

                    //StringBuilder errors = new StringBuilder();

                    //foreach (var error in resultIdentity.Errors)
                    //{
                    //    errors.AppendLine(error.Description);
                    //}

                    return View(usuario);
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw;
            }
        }

        private IdentityUser CarregarUsuarioIdentity(IdentityUser identityUser, UsuarioIdentityVM usuario)
        {
            identityUser.Email = usuario.Email;
            identityUser.PhoneNumber = usuario.PhoneNumber;
            identityUser.UserName = usuario.UserName;
            return identityUser;
        }

        public async Task<IActionResult> EditarUsuario(int id)
        {
            var usuarioEntidade = _usuarioService.GetById(id);
            var usuario = _mapper.Map<UsuarioIdentityVM>(usuarioEntidade);

            var identityUser = await _userManager.FindByIdAsync(usuario.IdentityUser);
            var usuarioIdentity = CarregarUsuarioIdentityVM(identityUser, usuario);
            var endereco = usuario.Id_Endereco == null ? null : _enderecoService.GetById(usuario.Id_Endereco.Value);
            if (endereco != null)
            {
                usuarioIdentity.LinkGoogleMaps = endereco.LinkGoogleMaps;
                usuarioIdentity.Endereco_Complemento = endereco.Endereco_Complemento;
            }

            return View(usuarioIdentity);
        }

        [HttpPost]
        public async Task<JsonResult> EditarUsuario(UsuarioIdentityVM usuario)
        {
            try
            {
                var userOld = _usuarioService.GetById(usuario.Id_Usuario);
                var userIdentityOld = await _userManager.FindByIdAsync(usuario.IdentityUser);
                IdentityUser userIdentity = CarregarUsuarioIdentity(userIdentityOld, usuario);
                var resultIdentity = await _userManager.UpdateAsync(userIdentity);
                if (resultIdentity.Succeeded)
                {
                    if (userOld.Perfil != usuario.Perfil)
                    {
                        var resultPerfil = await _userManager.RemoveFromRoleAsync(userIdentity, userOld.Perfil.ToString());
                        if (resultPerfil.Succeeded)
                        {
                            var resultAddPerfil = await _userManager.AddToRoleAsync(userIdentity, usuario.Perfil.ToString());
                            if (resultAddPerfil.Succeeded)
                            {
                                var usuarioEntidade = AtualizarUsuarioEntidade(userOld,usuario);//_mapper.Map<Usuario>(usuario);
                                _usuarioService.Update(usuarioEntidade);

                                var endereco = usuario.Id_Endereco == null ? null : _enderecoService.GetById(usuario.Id_Endereco.Value);
                                if (endereco != null)
                                {
                                    endereco.LinkGoogleMaps = usuario.LinkGoogleMaps;
                                    endereco.Endereco_Complemento = usuario.Endereco_Complemento;
                                }
                                _enderecoService.Update(endereco);

                                return Json("OK OK OK");
                            }
                                
                        }
                    }
                    return Json("");
                }

                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw;
            }
            
        }

        public Usuario AtualizarUsuarioEntidade(Usuario userOld, UsuarioIdentityVM newUser)
        {
            userOld.Ativo = newUser.Ativo;
            userOld.Cpf = newUser.Cpf;
            userOld.IdentityUser = newUser.IdentityUser;
            userOld.Id_Usuario = newUser.Id_Usuario;
            userOld.Nome = newUser.Nome;
            userOld.Perfil = newUser.Perfil;
            userOld.Id_Endereco = newUser.Id_Endereco;

            return userOld;
        }

        [HttpPost]
        public JsonResult RemoverUsuario(int id)
        {
            var usuario = _usuarioService.GetById(id);
            usuario.Inativar();
            _usuarioService.Update(usuario);

            //var usuario = _usuarioService.GetById(id);
            //_usuarioService.Remove(usuario);


            //IdentityUser userIdentity = await _userManager.FindByIdAsync(usuario.IdentityUser);
            //var result = await _userManager.RemoveFromRoleAsync(userIdentity, EnumHelper.GetName(usuario.Perfil));
            //if (result.Succeeded)
            //{
            //    _userManager.remo
            //}
            return Json("Removeu!!!");
        }

        private UsuarioIdentityVM CarregarUsuarioIdentityVM(IdentityUser identityUser, UsuarioIdentityVM usuario)
        {
            usuario.Email = identityUser.Email;
            usuario.PhoneNumber = identityUser.PhoneNumber;
            usuario.IdentityUser = identityUser.Id;
            usuario.UserName = identityUser.UserName;

            return usuario;
        }
    }
}