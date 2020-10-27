using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.DataAccess.Abstract;
using Web.DataAccess.EntityFramework;
using Web.Entity;
using Web.Entity.ModelView.Panel;

namespace Web.Business
{
    public class PanelManager
    {
        IUnitOfWork repo;
        UserManager<ApplicationUser> userManager;
        public PanelManager(UserManager<ApplicationUser> _userManager, IUnitOfWork _repo)
        {
            userManager = _userManager;
            repo = _repo;
        }
        public PanelModelView GetIndex()
        {

            try
            {
                var Totaluser = userManager.Users.Count();
                var RegisteredToday = userManager.Users.Where(x => x.RegisterDate.Date == DateTime.Today).Count();
                var TotalGame = repo.Games.GetAll().Count();
                var totaladvert = repo.Advert.GetAll().Count();
                PanelModelView model = new PanelModelView()
                {
                    TotalUser = Totaluser.ToString(),
                    RegisteredToday = RegisteredToday.ToString(),
                    TotalGame = TotalGame.ToString(),
                    TotalAdvert=totaladvert.ToString(),

                };
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
