using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oyuncu_Sitesi.Infrastructure;
using Web.Business;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Core.Message;
using Web.Entity.ModelView;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Oyuncu_Sitesi.Controllers
{
    public class ProfileController : Controller
    {
        private IUnitOfWork repo;
        private UserManager<ApplicationUser> usermanager;
        ProfileManager manager;
        public ProfileController(IUnitOfWork _repo, UserManager<ApplicationUser> _usermanager)
        {
            repo = _repo;
            usermanager = _usermanager;
            manager = new ProfileManager(repo, usermanager);
        }

        [Route("Profil/{nick}")]
        public IActionResult Profil(string nick)
        {
            
            var model = manager.FindUser(nick);
            return View(model);
        }
        [Authorize]
        [HttpGet]
        [Route("Ayarlar")]
        public IActionResult Setting()
        {
          var model=manager.GetProfileSetting(usermanager.GetUserId(User));
            City Citylist = new City();
            ViewBag.CityList =new SelectList(Citylist.GetCityList(), "City","City");
            return View(model);
        }
        [Route("Ayarlar"),ValidateAntiForgeryToken,HttpPost,Authorize]
        public async Task<JsonResult> Setting(ProfileSettingsModelView model)
        {

            if (ModelState.IsValid)
            {
              await manager.UpdateProfile(model,usermanager.GetUserId(User));
                
                if(model.Error!=null&&model.Error.Count()>0)
                {
                    model.Error.ForEach(x => ModelState.AddModelError("", x.Message));
                    var jsonerror = JsonConvert.SerializeObject(model.Error.ToArray());
                    return Json(new { success = false, data = model,errors=jsonerror});
                }
               
                return Json(new { success = true, data = model});
            }
            CustomValidationError error = new CustomValidationError();
            var errorlist = JsonConvert.SerializeObject(error.GetModelStateErrors(ModelState));
            return Json(new { success = false, data = model,error=errorlist });
        }
        [Route("ayarlar/sifre"),Authorize,HttpGet]
        public IActionResult ProfilePassword()
        {
            return View();
        }
        [Route("ayarlar/sifre"),Authorize,ValidateAntiForgeryToken,HttpPost]
        public async Task<IActionResult> ProfilePassword(SettingPasswordModelView model)
        {
            if(ModelState.IsValid)
            {
              var result= await manager.UpdatePassword(model, usermanager.GetUserId(User));
                if(result.Errors!=null&&result.Errors.Count()>0)
                {
                    if(result.Errors.Find(x=>x.Code==ErrorMessageCode.PasswordUpdatedSuccess)!=null)
                    {
                        result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                        return View(model);
                    }
                    result.Errors.ForEach(x => ModelState.AddModelError("", x.Message));                  
                }
            }
            return View(model);
        }
        
        [Route("ayarlar/platform"),Authorize,HttpGet]
        public async Task<IActionResult> PlatformSetting()
        {
           var model=await manager.GetPlatform(usermanager.GetUserId(User));
            return View(model);
        }
        [Route("ayarlar/platform"),Authorize,HttpPost,ValidateAntiForgeryToken]
        public async Task<JsonResult> PlatformSetting(PlatformSettingModelView model)
        {
            if(ModelState.IsValid)
            {
                var control=await manager.UpdatePlatform(model, usermanager.GetUserId(User));
               if(control.Errors.Find(x=>x.Code==ErrorMessageCode.PlatformUpdateSuccess)!=null)
                {

                    return Json(new { success = true,data=model});
                }
            }
            CustomValidationError error = new CustomValidationError();
            var errorlist = JsonConvert.SerializeObject(error.GetModelStateErrors(ModelState));
            return Json(new { success = false, data = model, error = errorlist });
        }
    }
}
