using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.DataAccess.Abstract;
using Web.Entity;

namespace Web.DataAccess.EntityFramework
{
   public class EFTagRepository:EFBaseRepository<Tags>,ITagRepository
    {
        public EFTagRepository(DatabaseContext context) : base(context)
        {

        }

        public DatabaseContext databaseContext
        {
            get { return context as DatabaseContext; }

        }

        public bool DeleteTagByID(List<Tags> taglist)
        {
            try
            {
                databaseContext.Tags.RemoveRange(taglist);
                var result = databaseContext.SaveChanges();
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

        public bool FindTag(Tags tag)
        {
           var tags = databaseContext.Tags.Where(x => x.Tag == tag.Tag).FirstOrDefault();

            if (tags != null)
            {
                if (tags.Tag.ToLower() == tag.Tag.ToLower())
                {
                    return false;
                }
                return true;
            }

            return true;
        }
    }
}
