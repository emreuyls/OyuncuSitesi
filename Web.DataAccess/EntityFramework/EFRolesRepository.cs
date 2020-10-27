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

        public bool DeleteRolesByID(List<Roles> rolelist)
        {
            try
            {
                DatabaseContext.Roles.RemoveRange(rolelist);
                 var result= DatabaseContext.SaveChanges();
                if (result > 0)
                    return true;
                else
                    return false;
                
            }
            catch (Exception)
            {

                return false;
            }
            
           
        }

        public bool FindRoles(Roles role)
        {
            var roles = DatabaseContext.Roles.Where(x => x.Role == role.Role).FirstOrDefault();
            if(roles!=null)
            {
                if (roles.Role.ToLower() == role.Role.ToLower())
                {
                    return false;
                }
                return true;
            }

            return true;
            
        }

        public List<RolesAdvert> GetRolesWithGamesID(int id)
        {
            var test = DatabaseContext.Roles.Where(a => a.GameRoles.Where(x => x.GamesID == id).Any()).Select(a=>new RolesAdvert() { ID=a.ID,Role=a.Role}).ToList();
            return test;
        }
    
    }
}
