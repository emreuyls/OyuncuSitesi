using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Web.DataAccess.Abstract;
using Web.Entity;
using Web.Entity.ModelView;

namespace Web.DataAccess.EntityFramework
{
    public class EFGameRepository : EFBaseRepository<Games>, IGameRepository
    {
        public EFGameRepository(DatabaseContext context) : base(context)
        {

        }

        public DatabaseContext databaseContext
        {
            get { return context as DatabaseContext; }

        }

        public IEnumerable<GameAdvertListModelView> GetGameAdvertList(string name)
        {

            var model = databaseContext.Games.Where(x => x.Name == name).Include(a => a.Adverts).Select(a => new GameAdvertListModelView()
            {
                Advert = a.Adverts.ToList(),
                Description = a.Description,
                ID = a.ID,
                Img = a.Img,
                Name = a.Name
            }).ToList();
            //TODO: Rütbe sayı olarak Geliyor Onu Yazısal Bir Biçime Çevirmek Lazım
            return model;
        }
    }
}
