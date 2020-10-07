using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entity.ModelView
{
   public class AdvertContentModelView
    {
       
        public ContentAdvert ContentAdvert { get; set; }
        public ContentGame ContentGame { get; set; }
        public ContentUser ContentUser { get; set; }
    }  
    public class ContentAdvert
    {
        public string Nick { get; set; } //oyun içi nicki
        public string Rank { get; set; } //oyundaki rütbesi veya leveli
        public string MinAge { get; set; }
        public string Role { get; set; } //ya aradığı yada oynadığı rol olabilir
        public string Content { get; set; }
        public DateTime AdDate { get; set; }
        public int[] SeekRole { get; set; }
        public int[] SeekRank { get; set; }

    }
    public class ContentUser
    {
        public string Username { get; set; }
        public bool Gender { get; set; }

        public string Img { get; set; }
    }

    public class ContentGame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public string Img { get; set; }
    }
}
