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
    public class GaleriManager : IGaleriService
    {
        IGaleriDAL _galeriDAL;
        public GaleriManager(IGaleriDAL galeriDAL) { 
        
        _galeriDAL=galeriDAL;
        
        }  
        public List<ImageFile> GetAllBL()
        {
           return _galeriDAL.Liste();
        }
    }
}
