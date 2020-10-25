using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Message;
using Web.Entity;
using Web.Entity.ModelView.Panel;

namespace Web.Business
{
    public class AdminRoleManager
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<ApplicationUser> userManager;
        public AdminRoleManager(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }

        public List<MainRoleModelView> GetAllRole()
        {
            var roles = roleManager.Roles.ToList();
            List<MainRoleModelView> model = new List<MainRoleModelView>();          
            foreach (var role in roles)
            {           
                model.Add(new MainRoleModelView() { RoleID = role.Id, RoleName = role.Name});
            }
            return model;
        }
        public async Task<bool> CreateRole(AddRoleModelView model)
        {
            if (model != null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(model.RoleName));
                if (result.Succeeded)
                    return true;
            }
            return false;
        }

        public async Task<AdminRoleUserModelView> GetRolePage(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            
            var member = await userManager.GetUsersInRoleAsync(role.Name);
           
            var model = new AdminRoleUserModelView()
            {
                Role = role,
                User = member.ToList()
            };
            return model;
        }
        public async Task<getRoleUser> GetRoleUser(string name)
        {
            var user = await userManager.FindByNameAsync(name);
            getRoleUser model = new getRoleUser()
            {
                ID = user.Id,
                Name = user.UserName,
                Nick = user.Names,

            };
            return model;
        }

        public async Task<ErrorMessage> AssingToRole(string userid, string rolename)
        {
            ErrorMessage message = new ErrorMessage();
            try
            {
                var user = await userManager.FindByIdAsync(userid);
                if(await userManager.IsInRoleAsync(user,rolename))
                {
                    message.AddErrors(ErrorMessageCode.AddRoleError, "Kullanıcı Zaten Role Atanmış");
                    return message;

                }
                var result = await userManager.AddToRoleAsync(user, rolename);
                if (result.Succeeded)
                {
                    message.AddErrors(ErrorMessageCode.AddRoleSuccess, "Kayıt Başarılı");
                    return message;
                }
            }
            catch (Exception)
            {

                throw;
            }
            message.AddErrors(ErrorMessageCode.AddRoleError, "Kayıt Sırasında Sorun Oluştu");
            return message;
        }

        public async Task<bool> DeleteToRole(RoleEditModel model)
        {
            foreach (var userid in model.IdtoRemove)
            {
                var user = await userManager.FindByIdAsync(userid);
                if(user!=null)
                {
                    var result = await userManager.RemoveFromRoleAsync(user,model.RoleName);               
                    if(!result.Succeeded)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role!=null)
            {
                var result = await roleManager.DeleteAsync(role);
                return result.Succeeded;
            }
            return false;
        }
        
    }
}
