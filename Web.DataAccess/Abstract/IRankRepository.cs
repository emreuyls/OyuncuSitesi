using System;
using System.Collections.Generic;
using System.Text;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.DataAccess.Abstract
{
   public interface IRankRepository:IBaseRepository<Rank>
    {
        List<RankAdvert> GetRankWithGamesID(int id);
        List<Rank> GetGameRankListByID(int id);
    }
}
