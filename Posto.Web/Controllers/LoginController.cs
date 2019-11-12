using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;

namespace Posto.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly IEmpresaService _empresaService;
        public LoginController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IEmpresaService empresaService)
        {
            _signManager = signInManager;
            _userManager = userManager;
            _empresaService = empresaService;
        }

        public ActionResult Index()
        {
            //var user = new IdentityUser { UserName = "raulluiz_araujo_12@hotmail.com" };
            //var result = await userManager.CreateAsync(user, "Qu@lquer1");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(user.login, user.password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Chamado");
                }

                ModelState.AddModelError(string.Empty, "Login Inválido!");

                
            }
            ModelState.AddModelError(string.Empty, "Login Inválido!");
            ViewBag.error = "Login ou senha inválida!";
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}