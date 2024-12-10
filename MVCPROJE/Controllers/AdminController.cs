using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin

        CategoriManager categoriManager = new CategoriManager(new CategoriRepository());
        HeadingManager headingManager= new HeadingManager(new HeadingRepository()); 



        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            var item=categoriManager.GetAllBL();
            ViewBag.AdminName = Session["AdminName"];
            return View(item);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category  category)
        {

            CategoriValidator validations = new CategoriValidator();
            ValidationResult result=validations.Validate(category);
            if (result.IsValid)
            {
                CategoriManager categoriManager = new CategoriManager(new CategoriRepository());
                categoriManager.CategoriAddBL(category);
                return RedirectToAction("Index");
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
      
        //[HttpPost]
       public ActionResult DeleteCategory(int id)
        {
          var item=  categoriManager.GetByID(id);
            categoriManager.DeleteCategory(item);
            return RedirectToAction("Index");
        }
           
        public ActionResult CategoryUpdate(int id)
        {
            var item=categoriManager.GetByID(id);
            if (item != null)
            {
                return View(item);
              
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
             categoriManager.CategoryUpdate(category);
          
            return RedirectToAction("Index");

        }
        public ActionResult WriterHeading(int id)
        {
            var heading = headingManager.GetListWriter(id);
            return View(heading);
        }

    }
}