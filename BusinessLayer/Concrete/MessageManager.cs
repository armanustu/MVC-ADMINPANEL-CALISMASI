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
    public class MessageManager : IMessageService
    {
        IMessageDAL _messagedal;
        public MessageManager(IMessageDAL messageDAL)
        {
                _messagedal = messageDAL;
        }
        public void DeleteCategory(Message message)
        {
            _messagedal.Delete(message);
        }

        public Message Get(Expression<Func<Message, bool>> filter)
        {
            return _messagedal.Get(filter);
        }

        public List<Message> GetAllBL()
        {
            return _messagedal.Listele(x => x.ReceiverMail == "admin@gmail.com");//alıcı admin olan tüm bilgileri gönder
        }

        public Message GetByID(int id)
        {
            return _messagedal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListBox()
        {

            return _messagedal.Listele(x => x.ReceiverMail == "admin@gmail.com");//alıcı admin olan tüm bilgileri gönder


        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageAddBL(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageUpdate(Message message)
        {
            _messagedal.Update(message);
        }

        public List<Message> SendListBox()
        {
            return _messagedal.Listele(x => x.SenderMail == "admin@gmail.com"|| x.SenderMail=="");
        }
    }
}
