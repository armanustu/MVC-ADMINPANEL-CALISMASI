using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
         List<Category> GetAllBL();
         void CategoriAddBL(Category category);
         Category Get(Expression<Func<Category,bool>>filter);
         Category GetByID(int id);
        void DeleteCategory(Category category);
        void CategoryUpdate(Category category);
        //List<Category> SearchCategory(string CategoryName);
       
    }
}
