using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oyuncu_Sitesi.Models
{
    public class ImageUploadModel
    {
        [Required(ErrorMessage ="Bir Resim Seçiniz"),Display(Name ="Dosya")]  
        public IFormFile file { get; set; }
    }
}
