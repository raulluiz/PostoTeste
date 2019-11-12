using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Posto.ApplicationCore.ViewModels;

namespace Posto.Web.Controllers
{
    public class PerfilController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PerfilController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = _roleManager.Roles;
            return View();
        }

        public IActionResult NovoPerfil()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoPerfil(PerfilVM perfil)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole(perfil.Nome);
                IdentityResult result =  await _roleManager.CreateAsync(role);

                if(result.Succeeded)
                    return RedirectToAction("Index", "Home");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(perfil);
        }

        public async Task<IActionResult> EditarPerfil(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            PerfilVM perfil = new PerfilVM();
            perfil.Id = role.Id;
            perfil.Nome = role.Name;
            return View(perfil);
        }

        [HttpPost]
        public async Task<IActionResult> EditarPerfil(PerfilVM perfil)
        {
            if (ModelState.IsValid) {
                var role = await _roleManager.FindByIdAsync(perfil.Id);
                IdentityResult result = await _roleManager.SetRoleNameAsync(role, perfil.Nome);

                if (result.Succeeded)
                {
                    var resultUpdate = await _roleManager.UpdateAsync(role);
                    if(resultUpdate.Succeeded)
                        return RedirectToAction("Index", "Perfil");
                    foreach (var error in resultUpdate.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
                    

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> RemoverPerfil(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
                return Json("Perfil removido com sucesso!");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return Json("Erro ao remover o perfil, favor entrar em contato com o administrador.");
        }
    }
}