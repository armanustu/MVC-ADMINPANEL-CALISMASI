using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutdal;
        public AboutManager(IAboutDAL aboutDAL)
        {
                _aboutdal = aboutDAL;   
        }
        public void AboutUpdate(About about)
        {
            _aboutdal.Update(about);
        }

        public void AboutAddBL(About about)
        {
            _aboutdal.Insert(about);
        }

        public void DeleteAbout(About about)
        {
          _aboutdal.Delete(about);  
        }

        public About Get(Expression<Func<About, bool>> filter)
        {
         return  _aboutdal.Get(filter);   
        }

        public List<About> GetAllBL()
        {
            return _aboutdal.Liste();
        }

        public About GetByID(int id)
        {
           return _aboutdal.Get(x => x.AboutID == id);
        }
    }
}
