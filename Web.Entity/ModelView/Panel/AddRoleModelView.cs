using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entity.ModelView.Panel
{
  public class AddRoleModelView
    {
        [Required(ErrorMessage ="Bir Rol Giriniz"),MinLength(2,ErrorMessage ="En Az {1} Karakterli Olmak Zorunda"),Display(Name ="Role")]
        public string RoleName { get; set; }
    }
    public class AdminRoleUserModelView
    {
        public IdentityRole Role { get; set; }
        public List<ApplicationUser> User { get; set; }       
    }
    public class RoleEditModel
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string[] IdtoRemove { get; set; }
    }
    public class getRoleUser
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Nick { get; set; }
    }
    public class MainRoleModelView
    {

        public string RoleID { get; set; }
        public string RoleName { get; set; }

    }
}
