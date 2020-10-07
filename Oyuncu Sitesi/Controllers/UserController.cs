using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Business;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView;

namespace Oyuncu_Sitesi.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUnitOfWork repository;
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        public UserController(IUnitOfWork repo, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            repository = repo;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnURL = returnUrl;
            return View();
        }
        [Route("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModelView model)
        {
            if(ModelState.IsValid)
            { 
            UserManager login = new UserManager(repository, userManager, signInManager);
           var result= await login.LoginManager(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Hata", "Kullanıcı Adı Veya Şifre Hatalı");
                }
                
            }
            return View(model);
        }
        [AllowAnonymous]
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModelView model)
        {
            if(ModelState.IsValid)
            {
                UserManager register = new  UserManager(repository,userManager,signInManager);
                IdentityResult control=  await register.RegisterManager(model);
                if(control.Errors.Count() == 0)
                {
                    return RedirectToAction("Index","Home");
                }else
                {
                    foreach (var error in control.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }            
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            
            UserManager logout= new UserManager(repository, userManager, signInManager);
          await logout.LogoutManeger();
            return RedirectToAction("Index","Home");

        }
    }


    
}
