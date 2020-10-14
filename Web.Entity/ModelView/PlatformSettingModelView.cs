using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Web.Entity.ModelView
{
   public class PlatformSettingModelView
    {
        [Display(Name ="Discord")]
        public string Discord { get; set; }

        [Display(Name = "Team Speak")]
        public string TeamSpeak { get; set; }

        [Display(Name = "Steam")]
        public string Steam { get; set; }

        [Display(Name ="Epic Games")]
        public string EpicGames { get; set; }

        [Display(Name ="Origin")]
        public string Origin { get; set; }

        [Display(Name ="BattleNet")]
        public string BattleNet { get; set; }

        [Display(Name ="Xbox")]
        public string Xbox { get; set; }

        [Display(Name ="Playstation Network")]
        public string Psn { get; set; }
    }
}
