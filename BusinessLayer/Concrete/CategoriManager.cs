using BusinessLayer.Abstract;
using BusinessLayer.Validation;
using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoriManager : ICategoryService
    {
        //RepositoryBase<Category> categoriRepository = new RepositoryBase<Category>();
        ICategoriDAL _categoriDAL;
        public CategoriManager(ICategoriDAL categoriDAL)
        {
            _categoriDAL = categoriDAL;
        }
        public void CategoriAddBL(Category category)
        {
            _categoriDAL.Insert(category);

        }

        public List<Category> GetAllBL()
        {
            return _categoriDAL.Liste();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
          return  _categoriDAL.Get(filter);
        }

        public Category GetByID(int id)
        {
            return _categoriDAL.Get(x => x.CategoryID == id);
        }

        public void DeleteCategory(Category category)
        {
            category.CategoryStatus = false;
            _categoriDAL.Update(category);
        }
        
        public void CategoryUpdate(Category category)
        {
            _categoriDAL.Update(category);
        }

        //public List<Category> SearchCategory(string CategoryName)
        //{
        //   return _categoriDAL.Listele(CategoryName);
        //}







        //public void CategoriAddBL(Category category)
        //{

        //    //if (category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryDescription.Length > 51 || category.CategoryDescription == "")
        //    //{

        //    //}
        //    //else
        //    //{
        //        categoriRepository.Insert(category);
        //    //}



        //}
        //public List<Category> GetAllBL()
        //{

        //   return categoriRepository.Liste().ToList();


        //}
    }
}
