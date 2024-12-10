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
    public class HeadingManager : IHeadingService
    {
        IHeadingDAL _headingDal;
        public HeadingManager(IHeadingDAL headingDAL)
        {
            _headingDal = headingDAL;
        }

        public Heading GetByID(int id)
        {
           return _headingDal.GetByID(id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.Liste();
        }

        public List<Heading> GetListWriter(int id)
        {
            return _headingDal.Listele(x=>x.WriterID==id); 
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
          
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
