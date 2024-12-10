using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetAllBL();
        void AboutAddBL(About about);
        About Get(Expression<Func<About, bool>> filter);
        About GetByID(int id);
        void DeleteAbout(About about);
        void AboutUpdate(About about);
    }
}
