using System;
using System.Collections.Generic;
using System.Text;
using Web.DataAccess.Abstract;

namespace Web.DataAccess.EntityFramework
{
    public class EFUnitOfWork : IUnitOfWork
    {
        DatabaseContext dbContext;
        public EFUnitOfWork(DatabaseContext _dbcontext)
        {
            dbContext = _dbcontext ?? throw new Exception("DB Context NULL");
                    }

        private IGameRepository _games;
        private IRolesRepository _role;
        private IRankRepository _rank;
        private IAdvertRepository _advert;
        private ITagRepository _tag;
        public IGameRepository Games
        {
            get { return _games ?? (_games = new EFGameRepository(dbContext)); }
        }

        public IAdvertRepository Advert
        {
            get { return _advert ?? (_advert = new EFAdvertRepository(dbContext)); }
        }
        public IRolesRepository Roles
        {
            get { return _role ?? (_role = new EFRolesRepository(dbContext)); }
        }
        public IRankRepository Ranks
        {
            get { return _rank ?? (_rank = new EFRankRepository(dbContext)); }
        }
        public ITagRepository Tag
        {
            get { return _tag ?? (_tag = new EFTagRepository(dbContext)); }
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
