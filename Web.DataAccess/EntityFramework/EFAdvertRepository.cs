using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.DataAccess.EntityFramework
{
    public class EFAdvertRepository : EFBaseRepository<Advert>, IAdvertRepository
    {
        public EFAdvertRepository(DatabaseContext ctx) : base(ctx)
        {

        }
        public DatabaseContext DatabaseContext
        {
            get { return context as DatabaseContext; }
        }

        public ContentAdvert GetAdvertContent(int id)
        {
            try
            {
                var model = DatabaseContext.Adverts.Where(x => x.ID == id).Include(a => a.AdvertRanks).ThenInclude(a => a.Rank).Include(a => a.AdvertRoles).ThenInclude(a => a.Roles).Select(a => new ContentAdvert()
                {
                    AdDate = a.AdDate,
                    MinAge = a.MinAge,
                    Content = a.Content,
                    Nick = a.Nick,
                    Rank = a.Rank,
                    Role = a.Role,
                    SeekRank = a.AdvertRanks,
                    SeekRole = a.AdvertRoles,
                    UserID = a.UserID
                }).FirstOrDefault();
                string role = DatabaseContext.Roles.Where(a => a.ID == Convert.ToInt32(model.Role)).Select(a => a.Role).FirstOrDefault();
                string rank = DatabaseContext.Rank.Where(a => a.ID == Convert.ToInt32(model.Rank)).Select(a => a.Ranks).FirstOrDefault();
                model.Rank = rank;
                model.Role = role;
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Advert GetAdvertWithGames(int id)
        {
            var advert = DatabaseContext.Adverts.Where(a => a.ID == id).Include(x => x.Games).Include(x => x.AdvertRanks).ThenInclude(x => x.Rank).Include(x => x.Games).Include(x => x.AdvertRoles).ThenInclude(x => x.Roles).FirstOrDefault();
            return advert;
        }

        public List<ProfileAdvert> GetPRofileAdvert(string id)
        {
            var model = DatabaseContext.Adverts.Where(x => x.UserID == id).Include(x => x.Games).Select(x => new ProfileAdvert()
            {
                Date = x.AdDate,
                GameName = x.Games.Name,
                AdType=x.AdType,
                ID=x.ID
            }).ToList();
            return model;
        }

        public void UpdateAdvert(AdvertModelView model)
        {

        }
    }
}
