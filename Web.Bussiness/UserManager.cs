using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.Business
{
   public class UserManager
    {
        private IUnitOfWork repository;
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> singInManager;
        public UserManager(IUnitOfWork repo ,UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _singInManager)
        {
            repository = repo;
            userManager = _userManager;
            singInManager = _singInManager;
        }
        public async Task<SignInResult> LoginManager(LoginModelView model)
        {
            var user = await userManager.FindByEmailAsync(model.EPosta);
            if(user!=null)
            {
                await singInManager.SignOutAsync();
                
               var result = await singInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);                                
                
                return result;
            }
            return null;
        }

        public async Task<IdentityResult> RegisterManager(RegisterModelView model)
        {
            ApplicationUser user = new ApplicationUser {
                Email = model.Email,
                UserName = model.Username,
                RegisterDate = DateTime.Now,
                Birthdate = model.Birthdate,
                Gender = model.Gender,
                GuidId = Guid.NewGuid()            
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {

                return result;
            }
            
            return result;
          
        
        }


        public async Task<bool> LogoutManeger()
        {
             await singInManager.SignOutAsync();
            return true;
        }

    }
}
