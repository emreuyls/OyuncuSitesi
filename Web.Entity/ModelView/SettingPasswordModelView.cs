using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entity.ModelView
{
   public class SettingPasswordModelView
    {
        [Required(ErrorMessage ="{0} Giriniz")]
        [Display(Name ="Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} Giriniz")]
        [Display(Name = "Yeni Şifre")]
        [MinLength(6, ErrorMessage = "Minimum {1} Karakter")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "{0} Giriniz")]
        [Display(Name = "Yeni Şifre(Tekrar)")]
        [MinLength(6, ErrorMessage = "Minimum {1} Karakter")]
        [Compare("NewPassword", ErrorMessage = "{1} ile {0} Aynı Olmak Zorunda")]
        public string ReNewPassword { get; set; }
    }
}
