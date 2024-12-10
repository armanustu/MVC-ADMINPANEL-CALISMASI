using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Abstract
{
    public interface IRepositoryBase<Tentity> where Tentity : class
    {
        void Insert(Tentity entity);
        void Update(Tentity entity);
         void Delete(Tentity entity);
        List<Tentity> Listele(Expression<Func<Tentity, bool>> filter);
        List<Tentity> Liste();

        Tentity Get(Expression<Func<Tentity, bool>> filter);
        Tentity GetByID(int id);

    }
}
