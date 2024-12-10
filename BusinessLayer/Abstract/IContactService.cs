using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAllBL();
        void ContactAddBL(Contact contact);
        Contact Get(Expression<Func<Contact, bool>> filter);
        Contact GetByID(int id);
        void DeleteContact(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
