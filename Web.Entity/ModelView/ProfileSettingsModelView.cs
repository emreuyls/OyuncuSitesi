using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Text;
using Web.Core.Message;

namespace Web.Entity.ModelView
{
   public class ProfileSettingsModelView
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="{0} Boş Bırakılamaz.")]
        public string Names { get; set; }
        [Display(Name ="E-Posta")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz.")]
        public string Email { get; set; }
        [Display(Name ="Şehir")]
        public string City { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz.")]
        [Display(Name ="Doğum Tarihi")]
        public DateTime Birthdate { get; set; }
        [Display(Name ="Cinsiyet")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz.")]
        public bool Gender { get; set; }
        public string PictureData { get; set; }
        [Display(Name ="İçerik")]
        public string Content { get; set; }

        public List<ErrorMessageObj> Error { get; set; }
    }
}
