using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entity.ModelView
{
   public class RegisterModelView
    {
        [Required]
        [Display(Name ="Kullanıcı Adı")]
        [MinLength(3,ErrorMessage ="{0} Minimum 3 Karakter Olmak Zorunda")]
        public string Username { get; set; }
        [Display(Name = "E-Posta")]
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage ="{0} Kısmı Boş Bırakılamaz.")]
        [Compare("Password",ErrorMessage ="{1} ile {0} Aynı Olmak Zorunda")]
        public string RePassword { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public bool isCheck { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
