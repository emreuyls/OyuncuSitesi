using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oyuncu_Sitesi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Business;
using Web.Entity;

namespace Oyuncu_Sitesi.Areas.Admin.Component
{
    public class PanelNavbarComponent:ViewComponent
    {
       private UserManager<ApplicationUser> userManager;
        public PanelNavbarComponent(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var user =await userManager.FindByNameAsync(User.Identity.Name);
                PanelHeaderModel model = new PanelHeaderModel() { 
                Email=user.Email,
                Img=user.Image
                };
            return View(model);
            }
            catch(System.Exception)
            {
                throw;
            }

        }

    }
}
