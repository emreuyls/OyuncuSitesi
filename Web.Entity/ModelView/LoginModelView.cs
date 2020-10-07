using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entity.ModelView
{
   public class LoginModelView
    {
        [Required(ErrorMessage ="{0} Kısmı Boş Bırakılamaz")]
        [Display(Name ="E-posta")]
        public string EPosta { get; set; }
        [Required(ErrorMessage ="{0} Kısmı Boş Bırakılamaz")]
        [Display(Name ="Şifre")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
