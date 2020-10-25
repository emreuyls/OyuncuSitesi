using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Business;
using Web.DataAccess.Abstract;
using Web.Entity;

namespace Oyuncu_Sitesi.Component
{
    public class GameInfoComponent : ViewComponent
    {
        private IUnitOfWork repo;
        private readonly UserManager<ApplicationUser> userManager;
        private AdvertManager manager;
        public GameInfoComponent(IUnitOfWork _repo, UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
            manager = new AdvertManager(repo, _userManager);
        }

        public  IViewComponentResult Invoke(int? id, string? gamename)
        {
            if (id != null)
            {
                var model = manager.GetGameByID((int)id);
                return View(model);
            }
            else
            {
                var model = manager.GetGameByID(gamename);
                return View(model);

            }
           
        }

    }
}
