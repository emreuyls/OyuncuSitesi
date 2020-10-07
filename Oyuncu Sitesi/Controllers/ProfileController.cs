using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Oyuncu_Sitesi.Controllers
{
    public class ProfileController : Controller
    {
        [Route("Profil")]
        public IActionResult Profil()
        {
            return View();
        }
    }
}
