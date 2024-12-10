using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllBL();
        void MessageAddBL(Message message);
        Message Get(Expression<Func<Message, bool>> filter);
        Message GetByID(int id);
        void DeleteCategory(Message message);
        void MessageUpdate(Message message);
        List<Message> GetListBox();
        List<Message> SendListBox();
        void MessageAdd(Message message);
    }
}
