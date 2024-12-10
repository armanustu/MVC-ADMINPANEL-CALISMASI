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
    public class ContactManager : IContactService
    {
        IContactDAL contactDAL;
        public ContactManager(IContactDAL _contactDAL)
        {
            contactDAL = _contactDAL;
        }

        public void ContactAddBL(Contact contact)
        {
            contactDAL.Insert(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            contactDAL.Delete(contact);
        }

        public void DeleteContact(Contact contact)
        {
            contactDAL.Delete(contact);
        }

        public Contact Get(Expression<Func<Contact, bool>> filter)
        {
            return contactDAL.Get(filter);
        }

        public List<Contact> GetAllBL()
        {
            return contactDAL.Liste();
        }

        public Contact GetByID(int id)
        {
            return contactDAL.Get(x=>x.ContactID==id);
        }
    }
}
