using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAllBL();
        void CategoriAddBL(Content content);
        Content Get(Expression<Func<Content, bool>> filter);
        Content GetByID(int id);
        void DeleteContent(Content content);
        void ContentUpdate(Content content);
        List<Content> GetListByID(int id);
    }
}
