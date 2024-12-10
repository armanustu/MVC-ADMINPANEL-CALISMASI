using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Concrete
{
    public class RepositoryBase<Tentity> : IRepositoryBase<Tentity> where Tentity : class
    {
       
        DbSet<Tentity> _object;
        Context _context = new Context();

        public RepositoryBase()
        {
         
            _object = _context.Set<Tentity>();
        }

      

        public void Delete(Tentity entity)
        {
           _context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public Tentity GetByID(int id)
        {
          return  _object.Find(id);
        }

       

        public void Insert(Tentity entity)
        {
            //var addEntity = _context.Entry(entity);
            //addEntity.State = EntityState.Added;
            _object.Add(entity);
            _context.SaveChanges();
            
        }

        public List<Tentity> Liste()
        {

         return   _object.ToList();
        }

        public List<Tentity> Listele(Expression<Func<Tentity, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(Tentity entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
      
    }
}
