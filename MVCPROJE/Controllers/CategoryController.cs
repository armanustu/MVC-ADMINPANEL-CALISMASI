using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVCPROJE.Controllers
{
   
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string categoryname)
        {

            var categoryvalues = (from c in categoryManager.GetAllBL()
                                  select c).ToList();
            if (!string.IsNullOrEmpty(categoryname))
            {
                 categoryvalues = (from c in categoryManager.GetAllBL()
                                      select c).Where(x => x.CategoryName==categoryname).ToList();

            }

            return View(categoryvalues);
            
           
        }
        CategoriManager categoryManager = new CategoriManager(new CategoriRepository());
        public ActionResult GetKategoriList() {

           
            var item = categoryManager.GetAllBL();
            return  View(item);
        
        }
         
        public ActionResult AddCategory()
        {
            return View();      
        }
            [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoriValidator categoriValidator = new CategoriValidator();
            ValidationResult result = categoriValidator.Validate(category);
            if (result.IsValid)
            {
                categoryManager.CategoriAddBL(category);
                ViewBag.Status = true;
                return View();
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var item = categoryManager.GetByID(id);
            categoryManager.DeleteCategory(item);
            return RedirectToAction("Index");
        }

        public ActionResult CategoryUpdate(int id)
        {
            var item = categoryManager.GetByID(id);
            if (item != null)
            {
                return View(item);

            }
            return View();

        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            

            categoryManager.CategoryUpdate(category);
            ViewBag.Status = true;
            return View(category);

        }



    }
}