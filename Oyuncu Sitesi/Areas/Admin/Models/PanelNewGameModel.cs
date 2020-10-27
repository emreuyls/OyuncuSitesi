using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.Entity;

namespace Oyuncu_Sitesi.Areas.Admin.Models
{
    public class PanelNewGameModel
    {
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [MinLength(2, ErrorMessage = "Minimum {1} Karakterli")]
        [Display(Name = "Oyun İsmi")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [MinLength(10, ErrorMessage = "Minimum {1} Karakterli")]
        [Display(Name = "Oyun Açıklama")]
        public string Content { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [Display(Name = "Oyun Resmi")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [Display(Name = "Oyun Rolü")]
        public int[] Roles { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [Display(Name = "Oyun Rütbesi")]
        public int[] Ranks { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [Display(Name = "Oyun Etiketi")]
        public int[] Tags { get; set; }

    }
    public class PanelUpdateGameModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [MinLength(2, ErrorMessage = "Minimum {1} Karakterli")]
        [Display(Name = "Oyun İsmi")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [MinLength(10, ErrorMessage = "Minimum {1} Karakterli")]
        [Display(Name = "Oyun Açıklama")]
        public string Content { get; set; }        
        [Display(Name = "Oyun Resmi")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [Display(Name = "Oyun Rolü")]
        public int[] Roles { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [Display(Name = "Oyun Rütbesi")]
        public int[] Ranks { get; set; }
        [Required(ErrorMessage = "{0} Kısmı Boş Bırakılamaz")]
        [Display(Name = "Oyun Etiketi")]
        public int[] Tags { get; set; }
        public string FirstImg { get; set; }

    }

}
