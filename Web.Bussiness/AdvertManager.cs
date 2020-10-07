using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.Business
{
    public class AdvertManager
    {
        private IUnitOfWork repo;
        private readonly UserManager<ApplicationUser> userManager;

        public AdvertManager(IUnitOfWork _repo, UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
             userManager = _userManager;
        }

        public List<Games> GetGame()
        {
            return repo.Games.GetAll().ToList();

        }
        public List<RolesAdvert> GetRoles(int id)
        {
            //var test=repo.Roles.GetRolesWithGamesID(id);
            //return test;
            return repo.Roles.GetRolesWithGamesID(id); 
        }
        public List<RankAdvert> GetRank(int id)
        {
            return repo.Ranks.GetRankWithGamesID(id);
        }

        public void CreateAdvert(AdvertModelView model,string userID,int id)
        {
            var games=repo.Games.Get(id);
            var advert = new Advert() {
                AdDate = DateTime.Now,
                Content = model.Content,
                MinAge = model.MinAge,
                Nick = model.Nick,
                Rank = model.Rank,
                UserID = userID,
                Games = games,
                Role=model.Role
                
                
            };
            List<AdvertRank> advertrank = new List<AdvertRank>();
            
            for (int i = 0; i < model.SeekRank.Count(); i++)
            {
                advertrank.Add(new AdvertRank { Advert = advert, RankID = model.SeekRank[i] });
            }
            List<AdvertRole> advertrole = new List<AdvertRole>();
                for (int i = 0; i < model.SeekRole.Count(); i++)
            {
             advertrole.Add( new AdvertRole { Advert = advert, RolesID = model.SeekRole[i] });
            }
            advert.AdvertRoles=advertrole;
            advert.AdvertRanks = advertrank;
            repo.Advert.Create(advert);
        }
        
        public List<AdvertListModelView> GetUserAdvert(string Userid)
        {

            var AdvertList = repo.Advert.Find(x => x.UserID == Userid).Select(a=>new AdvertListModelView() { 
            AdDate=a.AdDate,
            Game=a.Games.Name,
            Nick=a.Nick,
            ID=a.ID
            }).ToList();


            return AdvertList;
        }
        public bool CheckUserID(string userid,int id)
        {
            try
            {
                var check = repo.Advert.Get(id).UserID;

                if (check == userid)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }               
            
            return false;
        }

        public AdvertModelView GetAdvert(int id)
        {
            var advert = repo.Advert.GetAdvertWithGames(id);
            if (advert != null)
            {
                AdvertModelView model = new AdvertModelView()
                {
                    AdDate = advert.AdDate,
                    MinAge = advert.MinAge,
                    Content = advert.Content,
                    Nick = advert.Nick,
                    Rank = advert.Rank,
                    Role = advert.Role,
                    GameModels = advert.Games
                };

                List<int> seekrank = new List<int>();
                foreach (var item in advert.AdvertRanks)
                {
                    seekrank.Add(item.RankID);
                }
                model.SeekRank = seekrank.ToArray();
                List<int> seekrole = new List<int>();
                foreach (var test in advert.AdvertRoles)
                {
                    seekrole.Add(test.RolesID);
                }
                model.SeekRole = seekrole.ToArray();
                return model;
            }
            else
                return null;
        }

        public bool AdvertUpdate(AdvertModelView model,int id)
        {
            try
            {
                var getadvert = repo.Advert.GetAdvertWithGames(id);
                getadvert.MinAge = model.MinAge;
                getadvert.Content = model.Content;
                getadvert.Nick = model.Nick;
                getadvert.Rank = model.Rank;
                getadvert.Role = model.Role;
                List<AdvertRole> advertRole = new List<AdvertRole>();
                for (int i = 0; i < model.SeekRole.Count(); i++)
                {
                    advertRole.Add(new AdvertRole
                    {
                        Advert = getadvert,
                        AdvertID = id,
                        RolesID = model.SeekRole[i]
                    });
                }
                List<AdvertRank> advertRanks = new List<AdvertRank>();
                for (int i = 0; i < model.SeekRank.Count(); i++)
                {
                    advertRanks.Add(new AdvertRank { Advert = getadvert, AdvertID = id, RankID = model.SeekRank[i] });
                }

                getadvert.AdvertRanks = advertRanks;
                getadvert.AdvertRoles = advertRole;
                repo.Advert.Update(getadvert);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool AdvertDeleteAll(int id)
        {
            try
            {
            var advert=repo.Advert.GetAdvertWithGames(id);
            int Control=repo.Advert.Delete(advert);
                if (Control >= 1)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {

                return false;
            }          
        }

        public  AdvertContentModelView GetAdvertContent(int id)
        {

            var advert=repo.Advert.GetAdvertWithGames(id);
            var user = userManager.FindByIdAsync(advert.UserID);
            AdvertContentModelView model = new AdvertContentModelView()
            {
                ContentAdvert=new ContentAdvert{AdDate=advert.AdDate,MinAge=advert.MinAge,Content=advert.Content,Nick=advert.Nick,Rank=advert.Rank,Role=advert.Role},
                ContentGame=new ContentGame { Description=advert.Games.Description,Img=advert.Games.Img,Name=advert.Games.Name,ID=advert.Games.ID},
                ContentUser=new ContentUser {Username=user.Result.UserName,Gender=user.Result.Gender,Img=user.Result.Image}
                
            };
            List<int> seekRole = new List<int>();
            foreach (var role in advert.AdvertRoles)
            {
                seekRole.Add(role.RolesID);
            }
            model.ContentAdvert.SeekRole = seekRole.ToArray();
            List<int> seekRank = new List<int>();
            foreach (var rank in advert.AdvertRanks)
            {
                seekRank.Add(rank.RankID);
            }
            model.ContentAdvert.SeekRank = seekRank.ToArray();
            return model;
        }
    }
}
