﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entity
{
   public class ApplicationUser:IdentityUser
    {
        public string Names { get; set; }
        public Guid GuidId { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool isCheck { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Statement { get; set; }
        public string SteamLink { get; set; }
        public string OriginLink { get; set; }
        public string BattleNetLink { get; set; }
        public string EpicGamesLink { get; set; }
        public string PsnLink { get; set; }
        public string XboxLink { get; set; }
        public string Discord { get; set; }
        public string TeamSpeak { get; set; }
    }
}
