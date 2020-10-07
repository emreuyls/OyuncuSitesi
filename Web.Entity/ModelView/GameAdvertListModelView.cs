using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity.ModelView
{
   public class GameAdvertListModelView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        public List<Advert> Advert { get; set; }
    }
}
