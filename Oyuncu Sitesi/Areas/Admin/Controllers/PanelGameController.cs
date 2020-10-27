using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oyuncu_Sitesi.Areas.Admin.Models;
using Oyuncu_Sitesi.Infrastructure;
using Web.Business;
using Web.Core.Message;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView.Panel;

namespace Oyuncu_Sitesi.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class PanelGameController : Controller
    {

        AdminGameManager manager;
        IUnitOfWork repo;
        UserManager<ApplicationUser> userManager;
        public PanelGameController(UserManager<ApplicationUser> _userManager, IUnitOfWork _repo)
        {
            userManager = _userManager;
            repo = _repo;
            manager = new AdminGameManager(userManager, repo);
        }
        [Route("Panel/Oyunlar")]

        public IActionResult Index()
        {

            return View(manager.GetGameMainPage());
        }
        [HttpGet, Route("/Panel/Oyunlar/Yeni")]
        public IActionResult AddGame()
        {
            try
            {
                var role = repo.Roles.GetAll();
                var rank = repo.Ranks.GetAll();
                var tag = repo.Tag.GetAll();
                ViewBag.RoleList = new SelectList(role, "ID", "Role");
                ViewBag.RankList = new SelectList(rank, "ID", "Ranks");
                ViewBag.TagList = new SelectList(tag, "ID", "Tag");
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }


        }
        [HttpPost, ValidateAntiForgeryToken, Route("/Panel/Oyunlar/Yeni")]
        public async Task<IActionResult> AddGame(PanelNewGameModel model)
        {

            if (ModelState.IsValid)
            {
                PanelGameModel game = new PanelGameModel()
                {
                    Content = model.Content,
                    Name = model.Name,
                    Ranks = model.Ranks,
                    Roles = model.Roles,
                    Tags = model.Tags,

                };
                if (model.Image != null && model.Image.ContentType.Contains("image"))
                {
                    string imageExtension = Path.GetExtension(model.Image.FileName);
                    string imageName = model.Name + imageExtension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/game/{imageName}");
                    using var stream = new FileStream(path, FileMode.OpenOrCreate);
                    await model.Image.CopyToAsync(stream);
                    game.Image = imageName;
                    var control = manager.CreateOrUpdate(game, false, null);
                    if (control.Errors.Find(x => x.Code == ErrorMessageCode.AddGameSuccess) != null)
                    {
                        return Json(new { success = true });
                    }
                    control.Errors.ForEach(a => ModelState.AddModelError("", a.Message));

                }
            }

            return View(model);
        }
        [HttpGet, Route("Panel/Oyunlar/{gamename}")]
        public IActionResult UpdateGame(string gamename)
        {
            try
            {
                var game = manager.GetGameByName(gamename);

                PanelUpdateGameModel model = new PanelUpdateGameModel()
                {
                    Content = game.Content,
                    Name = game.Name,
                    FirstImg = game.Image,
                    ID = game.ID,
                    Ranks = game.Ranks,
                    Roles = game.Roles,
                    Tags = game.Tags
                };
                var content = manager.GetContentList();
                ViewBag.RoleList = new SelectList(content.Roles, "ID", "Role");
                ViewBag.RankList = new SelectList(content.Ranks, "ID", "Ranks");
                ViewBag.TagList = new SelectList(content.Tags, "ID", "Tag");
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost, ValidateAntiForgeryToken, Route("Panel/Oyunlar/{gamename}")]
        public async Task<IActionResult> UpdateGame(PanelUpdateGameModel model, int? ID)
        {

            if (ModelState.IsValid)
            {
                PanelGameModel game = new PanelGameModel()
                {
                    Content = model.Content,
                    ID = model.ID,
                    Name = model.Name,
                    Ranks = model.Ranks,
                    Roles = model.Roles,
                    Tags = model.Tags
                };
                if (model.Image != null && model.Image.ContentType.Contains("image"))
                {
                    string imageExtension = Path.GetExtension(model.Image.FileName);
                    string imageName = model.Name + imageExtension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/game/{imageName}");
                    using var stream = new FileStream(path, FileMode.OpenOrCreate);
                    await model.Image.CopyToAsync(stream);
                    game.Image = imageName;
                    if (ID > 0)
                    {
                        var control = manager.CreateOrUpdate(game, true, model.ID);
                        if (control.Errors.Find(x => x.Code == ErrorMessageCode.AddGameSuccess) != null)
                        {
                            TempData["Message"] = "Kayıt Başarılı";
                            return Json(new { success = true });
                        }
                        control.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                    }
                    else
                    {
                        var control = manager.CreateOrUpdate(game, false, null);
                        if (control.Errors.Find(x => x.Code == ErrorMessageCode.AddGameSuccess) != null)
                        {
                            TempData["Message"] = "Kayıt Başarılı";
                            return Json(new { success = true });
                        }
                        control.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                    }
                }
                else
                {
                    game.Image = model.FirstImg;
                    var control = manager.CreateOrUpdate(game, true, model.ID);
                    if (control.Errors.Find(x => x.Code == ErrorMessageCode.AddGameSuccess) != null)
                    {
                        TempData["Message"] = "Kayıt Başarılı";
                        return Json(new { success = true });
                    }
                    control.Errors.ForEach(a => ModelState.AddModelError("", a.Message));

                }
            }

            return View(model);
        }

        [Authorize(Roles = "Yönetici")]
        public IActionResult DeleteGame(int ID)
        {
            var result = manager.DeleteGame(ID);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var game = repo.Games.Find(x => x.ID == ID).Select(a => a.Name);
                return new RedirectResult(url: "/Panel/Oyunlar/" + game);
            }
        }

        [Route("Panel/Oyunlar/Rol")]
        [HttpGet]
        public IActionResult PanelGameRoles()
        {
            var model = manager.GetRolesPage();

            return View(model);


        }
        [Route("Panel/Oyunlar/Rütbe")]
        [HttpGet]
        public IActionResult PanelGameRanks()
        {
            var model = manager.GetRankPage();
            return View(model);
        }
        [Route("Panel/Oyunlar/Etiket")]
        [HttpGet]
        public IActionResult PanelGameTags()
        {
            var model = manager.GetTagPage();
            return View(model);
        }
        /** ---Role---**/
        [HttpGet]
        public IActionResult AddRole()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddRole(string rolename)
        {
            ErrorMessage message = new ErrorMessage();
            if (rolename != null)
            {
                var control = manager.AddRoles(rolename);
                if (control.Errors.Find(x => x.Code == ErrorMessageCode.AddRoleSuccess) != null)
                {
                    return Json(new { success = true });
                }
                control.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "AddRole", rolename) });
            }
            else
            {

                message.AddErrors(ErrorMessageCode.AddRoleError, "Boş Bırakılmaz.");
                message.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "AddRole", rolename) });
            }

        }
        [HttpGet]
        public IActionResult UpdateRole(int ID)
        {
            var role = repo.Roles.Find(x => x.ID == ID).FirstOrDefault();
            PanelGameExtraModel model = new PanelGameExtraModel()
            {
                ID = role.ID,
                Name = role.Role,
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateRole(PanelGameExtraModel model)
        {
            if (ModelState.IsValid)
            {
                var control = manager.UpdateRoles(model);
                if (control)
                    return Json(new { success = true });
                ModelState.AddModelError("", "Bir Sorun Oluştu");
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "UpdateTag") });
            }
            ModelState.AddModelError("", "Boş Bırakmayınız");
            return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "UpdateTag") });
        }
        [HttpPost]
        public IActionResult DeleteRol(int[] RoleID)
        {
            if (RoleID.Length > 0)
            {
                var control = manager.DeleteRoles(RoleID);
                if (control)
                {
                    TempData["message"] = "Kayıt Silme Başarılı";
                    return new RedirectResult(url: "/Panel/Oyunlar/Rol");
                }
            }
            TempData["message"] = "Bir Değer Seçiniz.";
            return new RedirectResult(url: "/Panel/Oyunlar/Rol");
        }
        /** ---Rank---**/
        [HttpGet]
        public IActionResult AddRank()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddRank(string rankname)
        {
            ErrorMessage message = new ErrorMessage();
            if (rankname != null)
            {
                var control = manager.AddRank(rankname);
                if (control.Errors.Find(x => x.Code == ErrorMessageCode.AddRoleSuccess) != null)
                {
                    return Json(new { success = true });
                }
                control.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "AddRank") });
            }
            else
            {

                message.AddErrors(ErrorMessageCode.AddRoleError, "Boş Bırakılmaz.");
                message.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "AddRank") });
            }

        }
        [HttpGet]
        public IActionResult UpdateRank(int ID)
        {
            var rank = repo.Ranks.Find(x => x.ID == ID).FirstOrDefault();
            PanelGameExtraModel model = new PanelGameExtraModel()
            {
                ID = rank.ID,
                Name = rank.Ranks
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateRank(PanelGameExtraModel model)
        {
            if (ModelState.IsValid)
            {
                var control = manager.UpdateRank(model);
                if (control)
                    return Json(new { success = true });
                ModelState.AddModelError("", "Bir Sorun Oluştu");
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "UpdateRank"),model });
            }          
            return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "UpdateRank"), model });
        }
        [HttpPost]
        public IActionResult DeleteRank(int[] RankID)
        {
            if (RankID.Length > 0)
            {
                var control = manager.DeleteRanks(RankID);
                if (control)
                {
                    TempData["message"] = "Kayıt Silme Başarılı";
                    return new RedirectResult(url: "/Panel/Oyunlar/Rütbe");
                }
            }
            TempData["message"] = "Bir Değer Seçiniz.";
            return new RedirectResult(url: "/Panel/Oyunlar/Rütbe");
        }
        /** ---Tags---**/

        [HttpGet]
        public IActionResult AddTag()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddTag(string tagname)
        {
            ErrorMessage message = new ErrorMessage();
            if (tagname != null)
            {
                var control = manager.AddTag(tagname);
                if (control.Errors.Find(x => x.Code == ErrorMessageCode.AddRoleSuccess) != null)
                {
                    return Json(new { success = true });
                }
                control.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "AddTag") });
            }
            else
            {

                message.AddErrors(ErrorMessageCode.AddRoleError, "Boş Bırakılmaz.");
                message.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "AddTag") });
            }

        }
        [HttpGet]
        public IActionResult UpdateTag(int ID)
        {
            var tag = repo.Tag.Find(x => x.ID == ID).FirstOrDefault();
            PanelGameExtraModel model = new PanelGameExtraModel()
            { 
                ID=tag.ID,
                Name=tag.Tag,
            };
            
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateTag(PanelGameExtraModel model)
        {
            if (ModelState.IsValid)
            {
                var control = manager.UpdateTag(model);
                if (control)
                    return Json(new { success = true });
                ModelState.AddModelError("", "Bir Sorun Oluştu");
                return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "UpdateTag") });
            }
            ModelState.AddModelError("", "Boş Bırakmayınız");
            return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "UpdateTag") });
        }
        [HttpPost]
        public IActionResult DeleteTag(int[] TagID)
        {
            if (TagID.Length > 0)
            {
                var control = manager.DeleteTags(TagID);
                if (control)
                {
                    TempData["message"] = "Kayıt Silme Başarılı";
                    return new RedirectResult(url: "/Panel/Oyunlar/Etiket");
                }
            }
            TempData["message"] = "Bir Değer Seçiniz.";
            return new RedirectResult(url: "/Panel/Oyunlar/Etiket");
        }
    }
}
