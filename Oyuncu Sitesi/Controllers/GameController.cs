using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Business;
using Web.DataAccess.Abstract;

namespace Oyuncu_Sitesi.Controllers
{
    public class GameController : Controller
    {
        IUnitOfWork repo;
        GameManager manager;
        public GameController(IUnitOfWork _repo)
        {
            repo = _repo;
            manager = new GameManager(repo);
        }
        [Route("Oyunlar")]
        public IActionResult Index()
        {
            var model=manager.GetAll();
            return View(model);
        }

        [Route("Oyunlar/{name}")]
        public IActionResult GameProfile(string name)
        {

            var model = manager.GetGameListByID(name);

            var Ranklist = manager.GetRoles(model.Select(x=>x.ID).FirstOrDefault());
            ViewBag.RankList = Ranklist;
            if (model != null&&model.Any())
                return View(model);

            //TODO: gelen rütbelerin string olarak id kayıtlı onları string cevir string olan rankı rank ile ilişki yapılabilinirmi ?
            return NotFound();
        }
    }
}
