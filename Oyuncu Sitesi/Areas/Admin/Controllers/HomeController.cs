using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Entity;

namespace Oyuncu_Sitesi.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin")]
        [Area("admin")]
        [Route("panel")]
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
