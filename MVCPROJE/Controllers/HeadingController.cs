using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList.Mvc;
using BusinessLayer.Validation;
using FluentValidation.Results;
using FluentValidation;

namespace MVCPROJE.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new HeadingRepository());
        CategoriManager categoriManager = new CategoriManager(new CategoriRepository());
        WriterManager writerManager = new WriterManager(new WriterRepository());
        ContentManager contentManager = new ContentManager(new ContentRepository());
        public ActionResult Index2()
        {
            var item = headingManager.GetList();
            
            return View(item);
        }
        public ActionResult Index(int p=1)
        {
            var item = headingManager.GetList().ToPagedList(p, 6);

            return View(item);

        }
        public ActionResult AddHeading()
        {

           
                List<SelectListItem> valuecategory = (from m in categoriManager.GetAllBL()
                                                      select new SelectListItem
                                                      {
                                                          Text = m.CategoryName,
                                                          Value = m.CategoryID.ToString()
                                                      }).ToList();
                List<SelectListItem> valuewriter = (from m in writerManager.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = m.WriterName,
                                                        Value = m.WriterID.ToString()
                                                    }).ToList();
                ViewBag.Data = valuecategory;
                ViewBag.Writer = valuewriter;
            
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading) {
              
                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToString());
                headingManager.HeadingAdd(heading);
                ViewBag.Status = true;
                return View();

        }
        public ActionResult ContentByHeading(int id)
        {
         var model=  contentManager.GetListByID(id);
            
            return View(model);
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valuecategory = (from m in categoriManager.GetAllBL()
                       select new SelectListItem
                       {
                           Text = m.CategoryName,
                           Value = m.CategoryID.ToString()
                       }).ToList();
            List<SelectListItem> Writers = (from m in writerManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = m.WriterName,
                                                      Value = m.WriterID.ToString()
                                                  }).ToList();
            ViewBag.Category = valuecategory;
            ViewBag.Writer = Writers;
            var model = headingManager.GetByID(id);
            return View(model);

        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            //heading.HeadingStatus = true;
            headingManager.HeadingUpdate(heading);
          
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult DeleteHeadingByStatus(int id)
        {

                var item = headingManager.GetByID(id);
                item.HeadingStatus = false;
                headingManager.HeadingDelete(item);
                return RedirectToAction("Index");
            
           
        }
        public ActionResult HeadingReport()
        {
            var list = headingManager.GetList();
            return View(list);
        }

    }
}