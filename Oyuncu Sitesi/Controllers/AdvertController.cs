////using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json;
using Oyuncu_Sitesi.Infrastructure;
using Web.Business;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView;

namespace Oyuncu_Sitesi.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        private IUnitOfWork repo;
        private readonly UserManager<ApplicationUser> userManager;
        private AdvertManager manager;
        public AdvertController(IUnitOfWork _repo, UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
            manager = new AdvertManager(repo,_userManager);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("ilan")]
        public IActionResult Advert()
        {
            var userID = userManager.GetUserId(User);
            List<AdvertListModelView> model= manager.GetUserAdvert(userID);
            return View(model);
        }
        [Route("ilan/{gamename}/{id}")]
        [HttpGet]
        public IActionResult AdvertContent(string gamename, int id)
        {
            var model=manager.GetAdvertContent(id);
            ViewBag.GameName =gamename;
            if(model !=null)
                return View(model);
            return NotFound();
                
        }   

        [Route("ilan/Yeni")]
        public IActionResult NewAdvert()
        {
            List<Games> model = manager.GetGame();
            return View(model);
        }
        [Route("İlan/Yeni/Bilgiler/{id}")]
        [HttpGet]
        public IActionResult NewAdvertİnfo(int id)
        {
       
            var role = manager.GetRoles(id);
            var rank = manager.GetRank(id);            
            ViewBag.RolesBag = new SelectList(role, "ID", "Role");
            ViewBag.RankBag = new SelectList(rank, "ID", "Ranks");
            var game = manager.GetGameByID(id);
            ViewBag.GameBag = game;
            ViewBag.GameID = id;
            return View();
        }
        [HttpPost]
        [Route("İlan/Yeni/Bilgiler/")]
        [ValidateAntiForgeryToken]
        public JsonResult NewAdvertİnfo(AdvertModelView model, int id)
        {
            CustomValidationError error = new CustomValidationError();
            if (ModelState.IsValid)
            {
              
                var UserID = userManager.GetUserId(HttpContext.User);
                manager.CreateAdvert(model, UserID, id);
                return Json(new { success = true, message = "Kayıt Başarılı." });
            }
            var errorlist = JsonConvert.SerializeObject(error.GetModelStateErrors(ModelState));
            return Json(new { success = false, message = "Kayıt sırasında Bir Sorun Oluştu Tekrar Deneyiniz.", data = model, test = errorlist });
            
        }
        [Route("ilan/düzenle/{id}")]
        [HttpGet]
        public IActionResult AdvertEdit(int id)
        {
            var userıd = userManager.GetUserId(User);
            var model= manager.GetAdvert(id);
            bool CheckUser = manager.CheckUserID(userıd, id);
            if(CheckUser)
            {
                var role = manager.GetRoles(model.GameModels.ID);
                var rank = manager.GetRank(model.GameModels.ID);
                ViewBag.RolesBag = new SelectList(role, "ID","Role");
                ViewBag.RankBag = new SelectList(rank,"ID","Ranks");
                ViewBag.ID = id;
                return View(model);
            }
            return NotFound();

        }
        [Route("ilan/düzenle")]
        [HttpPost]
        public JsonResult AdvertEdit(AdvertModelView model,int id)
        {
            if(ModelState.IsValid)
            {
           var control=manager.AdvertUpdate(model,id);
                if(control)
                    return Json(new { success = true,message="Kayıt Başarılı" });

            }
            CustomValidationError error = new CustomValidationError();
            var errorlist = JsonConvert.SerializeObject(error.GetModelStateErrors(ModelState));
            return Json(new { success = false, data = model, message = "Kayıt sırasında Bir Sorun Oluştu Tekrar Deneyiniz.", Errors = errorlist });
            //TODO: Validation Sorunu var
        }

        [Route("ilan/sil/{id}")]
        public IActionResult DeleteAdvert(int id)
        {
            manager.AdvertDeleteAll(id);
            return RedirectToAction("Advert");
        }
    }
}
