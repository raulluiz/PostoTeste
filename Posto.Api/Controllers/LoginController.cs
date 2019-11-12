using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;

namespace Posto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly IEmpresaService _empresaService;
        private readonly IUsuarioService _usuarioService;
        public LoginController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IEmpresaService empresaService, IUsuarioService usuarioService)
        {
            _signManager = signInManager;
            _userManager = userManager;
            _empresaService = empresaService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Token([FromBody] LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(loginVM.login, loginVM.password, false, false);

                if (result.Succeeded)
                {
                    var direitos = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, loginVM.login),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("posto-webApp-authentication-valid"));
                    var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "Posto.Web",
                        audience: "Postman",
                        claims: direitos,
                        signingCredentials: credenciais,
                        expires: DateTime.Now.AddHours(12.0)
                    );

                    UsuarioAppVM usuarioRetorno = new UsuarioAppVM();
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    var usuarioIdentity = _userManager.Users.FirstOrDefault(u => u.UserName == loginVM.login);
                    var usuario = _usuarioService.Get(u => u.IdentityUser == usuarioIdentity.Id).FirstOrDefault();
                    var claims = await _userManager.GetClaimsAsync(usuarioIdentity);
                    var claimPerfil = claims.FirstOrDefault(c => c.Type == EnumTypeClaims.Perfil.ToString());

                    usuarioRetorno.Id_Usuario = usuario.Id_Usuario;
                    usuarioRetorno.Nome = usuario.Nome;
                    usuarioRetorno.Token = tokenString;
                    usuarioRetorno.Perfil = claimPerfil == null ? "" : claimPerfil.Value; 

                    return Ok(usuarioRetorno);

                }

                return Unauthorized(); //401
            }

            return BadRequest(); //400
        }
    }
}