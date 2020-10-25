using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Oyuncu_Sitesi.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Business;
using Web.Core.Message;
using Web.Entity;
using Web.Entity.ModelView.Panel;

namespace Oyuncu_Sitesi.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Yönetici")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private AdminRoleManager manager;
        public RoleController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            manager = new AdminRoleManager(roleManager, userManager);
        }

        [Route("Panel/Rol")]

        public IActionResult Index()
        {
            var model = manager.GetAllRole();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateOrUpdateRole()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdateRole(AddRoleModelView model)
        {
            if (ModelState.IsValid)
            {
                var control = await manager.CreateRole(model);
                if (control)
                {
                    return Json(new { success = true });
                }
                else
                {
                    ErrorMessage message = new ErrorMessage();
                    message.AddErrors(ErrorMessageCode.ProfileImageError, "Bir Sorun Oluştu");
                    message.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
                    return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "CreateOrUpdateRole", model) });
                }
            }
            return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "CreateOrUpdateRole", model) });
        }
        [HttpGet, Route("Panel/Rol/{id}")]
        public async Task<IActionResult> UserRole(string id)
        {
            if (id != null)
            {
                var model = await manager.GetRolePage(id);
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> GetRoleUser(string searchname)
        {
            if (ModelState.IsValid)
            {

                var model = await manager.GetRoleUser(searchname);
                if (model != null)
                {
                    return Json(new { success = true, data = model });
                }
                return Json(new { success = false });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRole(string roleuserid, string rolename)
        {
            if (roleuserid != null && rolename != null)
            {
                var control = await manager.AssingToRole(roleuserid, rolename);
                if (control.Errors.Find(a => a.Code == ErrorMessageCode.AddRoleSuccess) != null)
                {
                    return Json(new { success = true });
                }

                var jsonerror = JsonConvert.SerializeObject(control.Errors);
                return Json(new { success = false, errors = jsonerror });
            }
            return Json(new { success = false });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUserRole(RoleEditModel model)
        {
            if (model.IdtoRemove != null)
            {
                var result = await manager.DeleteToRole(model);
                if (result)
                {
                    TempData["message"] = "Kullanıcı Başarıyla Silindi";
                    return new RedirectResult(url: "/Panel/Rol/" + model.RoleID);
                }
            }
            TempData["message"] = "Kullanıcı Silinirken Bir Sorun Oluştu";
            return new RedirectResult(url: "/Panel/Rol/" + model.RoleID);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole()
        {
            try
            {
                var role = roleManager.Roles;
                ViewBag.RolesBag = new SelectList(role, "Id", "Name");
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string RoleID)
        {

            if (!String.IsNullOrEmpty(RoleID))
            {
                var control = await manager.DeleteRole(RoleID);
                if (control)
                {
                    TempData["message"] = "Rol Başarı İle Silindi";
                    return Json(new { success = true});
                }
            }
            var role = roleManager.Roles;
            ViewBag.RolesBag = new SelectList(role, "Id", "Name");
            ErrorMessage message = new ErrorMessage();
            message.AddErrors(ErrorMessageCode.AddRoleSuccess, "Bir Sorun Oluştu");
            message.Errors.ForEach(a => ModelState.AddModelError("", a.Message));
            return Json(new { success = false, html = Helper.RenderRazorViewToString(this, "DeleteRole", role) });
        }
    }
}
