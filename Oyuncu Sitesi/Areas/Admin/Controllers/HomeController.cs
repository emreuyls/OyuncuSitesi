using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Business;
using Web.DataAccess.Abstract;
using Web.Entity;

namespace Oyuncu_Sitesi.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    [Route("panel")]
    public class HomeController : Controller
    {
        PanelManager manager;
        IUnitOfWork repo;
        UserManager<ApplicationUser> userManager;
        public HomeController(UserManager<ApplicationUser> _userManager,IUnitOfWork _repo)
        {
            userManager = _userManager;
            repo = _repo;
            manager = new PanelManager(userManager,repo);
        }
        public IActionResult Index()
        {
            var model = manager.GetIndex();
            return View(model);
        }
    }
}
