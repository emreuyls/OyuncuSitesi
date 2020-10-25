using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.DataAccess.Abstract
{
    public interface IGameRepository : IBaseRepository<Games>
    {
        IEnumerable<GameAdvertListModelView> GetGameAdvertList(string name);
        Games GetGameWithTags(int id);
        Games GetGameWithTags(string gamename);

       List<GameModelView> GameList();
    }
}
