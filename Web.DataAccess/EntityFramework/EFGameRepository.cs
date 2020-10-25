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

        public List<GameModelView> GameList()
        {
            var model=databaseContext.Games.Include(a => a.GameTags).ThenInclude(a => a.Tags).Select(a => new GameModelView() {
            Description=a.Description,
            GameTags=a.GameTags,
            Img=a.Img,
            Name=a.Name,
            ID=a.ID
            }).ToList();
            return model;
        }

        public IEnumerable<GameAdvertListModelView> GetGameAdvertList(string name)
        {

            var model = databaseContext.Games.Where(x => x.Name == name).Include(a => a.Adverts).Select(a => new GameAdvertListModelView()
            {
                Advert=a.Adverts,
                Description = a.Description,
                ID = a.ID,
                Img = a.Img,
                Name = a.Name
            }).ToList();
            //TODO: Rütbe sayı olarak Geliyor Onu Yazısal Bir Biçime Çevirmek Lazım
            return model;
        }

        public Games GetGameWithTags(int id)
        {
            var model = databaseContext.Games.Where(x => x.ID == id).Include(a => a.GameTags).ThenInclude(a => a.Tags).Select(a => new Games()
            {
                Description = a.Description,
                GameTags = a.GameTags,
                Img = a.Img,
                Name = a.Name,
                ID = a.ID,
            }).FirstOrDefault();
            
            return model;
        }

        public Games GetGameWithTags(string gamename)
        {
            var model = databaseContext.Games.Where(x => x.Name == gamename).Include(a => a.GameTags).ThenInclude(a => a.Tags).Select(a => new Games()
            {
                Description = a.Description,
                GameTags = a.GameTags,
                Img = a.Img,
                Name = a.Name,
                ID = a.ID,
            }).FirstOrDefault();

            return model;
        }

    }
}
