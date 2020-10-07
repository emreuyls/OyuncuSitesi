using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.DataAccess.EntityFramework
{
   public class EFRankRepository:EFBaseRepository<Rank>,IRankRepository
    {
        public EFRankRepository(DatabaseContext ctx):base(ctx)
        {
                
        }

        public DatabaseContext DatabaseContext
        {
            get { return context as DatabaseContext; }
        }

        public List<RankAdvert> GetRankWithGamesID(int id)
        {

            var Rank = DatabaseContext.Rank.Where(a => a.GameRanks.Where(x => x.GamesID == id).Any()).Select(a => new RankAdvert() { Ranks = a.Ranks, ID = a.ID }).ToList();
            return Rank;
        }
        public List<Rank> GetGameRankListByID(int id)
        {
            return DatabaseContext.Rank.Where(x => x.GameRanks.Where(x => x.GamesID == id).Any()).Select(a => new Rank() { ID =a.ID, Ranks =a.Ranks  }).ToList();
        }
    }
}
