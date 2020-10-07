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
   public class EFAdvertRepository:EFBaseRepository<Advert>,IAdvertRepository
    {
        public EFAdvertRepository(DatabaseContext ctx):base(ctx)
        {

        }
        public DatabaseContext DatabaseContext
        {
            get { return context as DatabaseContext; }
        }
        public Advert GetAdvertWithGames(int id)
        {
            var advert = DatabaseContext.Adverts.Where(a => a.ID == id).Include(x => x.Games).Include(x=>x.AdvertRanks).ThenInclude(x=>x.Rank).Include(x=>x.Games).Include(x => x.AdvertRoles).ThenInclude(x=>x.Roles).FirstOrDefault();
            return advert;
        }

        public void UpdateAdvert(AdvertModelView model)
        {
            
        }
    }
}
