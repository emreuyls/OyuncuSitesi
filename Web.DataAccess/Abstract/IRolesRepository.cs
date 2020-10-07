using System;
using System.Collections.Generic;
using System.Text;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.DataAccess.Abstract
{
   public interface IRolesRepository:IBaseRepository<Roles>
    {
        List<RolesAdvert> GetRolesWithGamesID(int id);
    }
}
