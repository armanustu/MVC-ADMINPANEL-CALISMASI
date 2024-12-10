using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAllBL();
        void AdminAddBL(Admin admin);
        Admin Get(Expression<Func<Admin, bool>> filter);
        Admin GetByID(int id);
        void DeleteAdmin(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
