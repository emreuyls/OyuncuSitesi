using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oyuncu_Sitesi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Entity;

namespace Oyuncu_Sitesi.Areas.Admin.Component
{
    public class PanelSidebarComponent:ViewComponent
    {
        private UserManager<ApplicationUser> userManager;

        public PanelSidebarComponent(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
                {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var role = await userManager.GetRolesAsync(user);
                PanelSidebarModel model = new PanelSidebarModel()
                {
                    Role=role[0],
                    Img = user.Image
                };
                return View(model);
            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}
