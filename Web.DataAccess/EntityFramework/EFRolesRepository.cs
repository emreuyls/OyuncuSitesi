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
    public class EFRolesRepository:EFBaseRepository<Roles>,IRolesRepository
    {
        public EFRolesRepository(DatabaseContext ctx):base(ctx)
        {

        }
        public DatabaseContext DatabaseContext
        {
            get { return context as DatabaseContext; }
        }
        public List<RolesAdvert> GetRolesWithGamesID(int id)
        {
            var test = DatabaseContext.Roles.Where(a => a.GameRoles.Where(x => x.GamesID == id).Any()).Select(a=>new RolesAdvert() { ID=a.ID,Role=a.Role}).ToList();
            return test;
        }
    
    }
}
