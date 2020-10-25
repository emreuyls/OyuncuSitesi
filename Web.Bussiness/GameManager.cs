using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.Business
{
    public class GameManager
    {
        IUnitOfWork repo;
        public GameManager(IUnitOfWork _repo)
        {
            repo = _repo;
        }
        public List<GameModelView> GameList()
        {

            try
            {
                return repo.Games.GameList();
            }
            catch (Exception)
            {

                return null;
            }

        }
        public List<Rank> GetRoles(int id)
        {
            try
            {
                var rolelist = repo.Ranks.GetGameRankListByID(id);
                return rolelist;

            }
            catch (Exception)
            {

                throw;//TODO
            }

        }
        public IEnumerable<GameAdvertListModelView> GetGameListByID(string name)
        {
            var model = repo.Games.GetGameAdvertList(name);
            return model;
        }
    }
}
