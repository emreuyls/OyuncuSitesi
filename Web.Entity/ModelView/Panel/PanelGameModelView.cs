using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Entity.ModelView.Panel
{ 
    public class PanelGameMainModel
    {
        public List<PanelTableGameModel> Games { get; set; }
    }
    public class PanelTableGameModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
    public class PanelGameModel
    {
        public int ID { get; set; }
        public string Name { get; set; }     
        public string Content { get; set; } 
       public string Image { get; set; }
        public int[] Roles { get; set; }    
        public int[] Ranks { get; set; }  
        public int[] Tags { get; set; }
    }
    public class PanelGameRoleModelView
    {
        public List<Roles> Roles { get; set; }
    }
    public class PanelGameRankModelView
    {
        public List<Rank> Ranks { get; set; }
    }
    public class PanelGameTagModelView
    {
        public List<Tags> Tags { get; set; }
    }

    public class GetContentListModel
    {
        public List<Tags> Tags { get; set; }
        public List<Rank> Ranks { get; set; }
        public List<Roles> Roles { get; set; }
    }
    public class PanelGameExtraModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Boş Bırakmayınız")]
        [Display(Name ="Adı"),MinLength(2,ErrorMessage ="Minimum {1} Karakterli Olmak Zorunda")]
        public string Name { get; set; }
    }
}
