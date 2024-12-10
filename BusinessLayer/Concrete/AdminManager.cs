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
    public class AdminManager : IAdminService
    {
        IAdminDAL _admindal;
        public AdminManager(IAdminDAL admindal)
        {
            _admindal = admindal;
        }
        public void AdminAddBL(Admin admin)
        {
            _admindal.Insert(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _admindal.Update(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            _admindal.Delete(admin);
        }

        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
           return _admindal.Get(filter);
        }

        public List<Admin> GetAllBL()
        {
          return  _admindal.Liste();
        }

        public Admin GetByID(int id)
        {
           return _admindal.Get(x => x.AdminID == id);
        }
    }
}
