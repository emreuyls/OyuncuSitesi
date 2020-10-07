using System;
using System.Collections.Generic;
using System.Text;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.DataAccess.Abstract
{
   public interface IAdvertRepository:IBaseRepository<Advert>
    {
        Advert GetAdvertWithGames(int id);
        void UpdateAdvert(AdvertModelView model);
        
    }
}
