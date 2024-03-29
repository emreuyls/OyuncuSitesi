﻿using System;
using System.Collections.Generic;
using System.Text;
using Web.Entity;

namespace Web.Entity.ModelView
{
  public class ProfileModelView
    {
        public string Username { get; set; }
        public string Names { get; set; }
        public DateTime RegisterDate { get; set; }
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
        public List<ProfileAdvert> Adverts { get; set; }
    }
}
public class ProfileAdvert
{
    public int ID { get; set; }
    public string GameName { get; set; }
    public bool AdType { get; set; }
    public DateTime Date { get; set; }
}