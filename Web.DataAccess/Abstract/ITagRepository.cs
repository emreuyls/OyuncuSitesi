using System;
using System.Collections.Generic;
using System.Text;
using Web.DataAccess.Abstract;
using Web.Entity;

namespace Web.DataAccess.Abstract
{
   public interface ITagRepository:IBaseRepository<Tags>
    {
        bool FindTag(Tags tag);
        bool DeleteTagByID(List<Tags> taglist);
    }
}
