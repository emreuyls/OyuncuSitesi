using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity.ModelView
{
  public class AdvertListModelView
    {
        public int ID { get; set; }
        public string Game { get; set; }
        public string Nick { get; set; } //oyun içi nicki
        public DateTime AdDate { get; set; }
    }
}
