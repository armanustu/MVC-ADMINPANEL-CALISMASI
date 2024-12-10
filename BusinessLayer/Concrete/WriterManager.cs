using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerdal;
        public WriterManager(IWriterDAL writerDAL)
        {
            _writerdal = writerDAL;
        }
        
        public Writer GetByID(int id)
        {
           return _writerdal.GetByID(id);
        }

        public List<Writer> GetList()
        {
            return _writerdal.Liste();
        }

        
        public void WriterAdd(Writer writer)
        {
          _writerdal.Insert(writer);    
        }

        public void WriterDelete(Writer writer)
        {
            _writerdal.Update(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerdal.Update(writer);
        }
        


    }
}
