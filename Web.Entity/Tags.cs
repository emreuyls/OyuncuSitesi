using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class Tags
    {
        
        public int ID { get; set; }
        public string Tag { get; set; }
        public List<GameTags> GameTags { get; set; }
    }
}
