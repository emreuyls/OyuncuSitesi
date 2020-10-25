using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entity.ModelView
{
   public class AdvertModelView
    {
        [Required(ErrorMessage ="{0} Boş Bırakılamaz")]
        [Display(Name ="Nick")]
        [MinLength(2,ErrorMessage ="Minimum {1} Karakter Olmalı")]
        public string Nick { get; set; } //oyun içi nicki
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        public string Rank { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        public int[] SeekRank { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        public string MinAge { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        [Display(Name ="Bilgiler")]
        [MinLength(5,ErrorMessage ="Minimum {1} Karakter Giriniz")]
        public string Content { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        public int[] SeekRole { get; set; }
   
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        public string Role { get; set; }
        public DateTime AdDate { get; set; }
        [Required(ErrorMessage ="{0} Seçiniz"),Display(Name ="İlan Türü")]
        public bool AdType { get; set; }
        public Games GameModels { get; set; }


    }

    public class RolesAdvert
    {
        public int ID { get; set; }
        public string Role { get; set; }
    }
    public class RankAdvert
    {
        public int ID { get; set; }
        public string Ranks { get; set; }
    }
}
