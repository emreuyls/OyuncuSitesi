using System;
using System.Collections.Generic;
using System.Text;

namespace Web.DataAccess.Abstract
{
   public interface IUnitOfWork:IDisposable
    {
        IGameRepository Games { get; }
        IRolesRepository Roles { get; }
        IRankRepository Ranks { get; }
        IAdvertRepository Advert { get; }
        int SaveChanges();
    }
}
