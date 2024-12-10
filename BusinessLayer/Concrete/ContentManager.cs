using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDAL _contentDal;
        public ContentManager(IContentDAL contentDAL)
        {
            _contentDal = contentDAL;
        }
        public void CategoriAddBL(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public void DeleteContent(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content Get(Expression<Func<Content, bool>> filter)
        {
            return _contentDal.Get(filter);
        }

        public List<Content> GetAllBL()
        {
            return _contentDal.Liste();
        }

        public Content GetByID(int id)
        {
           return _contentDal.GetByID(id);
        }

        public List<Content> GetListByID(int id)
        {
            return _contentDal.Listele(x=>x.HeadingID==id);
        }
    }
}
