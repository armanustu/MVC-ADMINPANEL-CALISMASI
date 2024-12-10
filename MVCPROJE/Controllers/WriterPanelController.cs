using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace MVCPROJE.Controllers
{
   
    public class WriterPanelController : Controller
    {
        // GET: WriterProfile
        HeadingManager headingManager = new HeadingManager(new HeadingRepository());

        public ActionResult WriterProfile(int id)
        {  
            var heading = headingManager.GetListWriter(id);
            ViewBag.ID = id;

            return View(heading);
            
        }
        CategoriManager categoriManager=new CategoriManager(new CategoriRepository());

        [HttpGet]
        public ActionResult WriterHeadinAdding()
        {            
            return View();
        
        }
        public ActionResult WriterHeadingDelete(int id)
        {
            var heading = headingManager.GetByID(id);
            heading.HeadingStatus = false;
            headingManager.HeadingDelete(heading);
            return RedirectToAction("Index","WriterPanel");
        }


        WriterManager writerManager = new WriterManager(new WriterRepository());
            [HttpPost]
        public ActionResult WriterHeadinAdding(Heading heading)
        {
            
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            heading.WriterID = id;
            List<SelectListItem> category = (from c in categoriManager.GetAllBL()
                                             select new SelectListItem
                                             {
                                                 Text = c.CategoryName,
                                                 Value = c.CategoryID.ToString()
                                             }
                                            ).ToList();

            ViewBag.Writer = category;
            headingManager.HeadingAdd(heading);

            return RedirectToAction("Index", "WriterPanel");
        }


        [Authorize(Roles = "Writer")]
        public ActionResult Index()
        {
            var heading = headingManager.GetList(); 
            return View(heading);  
        }
       public ActionResult WriterHeadingEditing(int id)
        {
            var heading = headingManager.GetByID(id);
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            List<SelectListItem> category = (from c in categoriManager.GetAllBL()
                                             select new SelectListItem
                                             {
                                                 Text = c.CategoryName,
                                                 Value = c.CategoryID.ToString()
                                             }).ToList();
            ViewBag.Category = category;

            List<SelectListItem> writer = (from c in writerManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = c.WriterName,
                                               Value = c.WriterID.ToString()
                                           }).ToList();

            ViewBag.Writer = writer;


            return View(heading);
        }
        [HttpPost]
        public ActionResult WriterHeadingEditing(Heading heading)
        {
            heading.HeadingStatus = true;
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index","WriterPanel");
        }
        public ActionResult AllHeading(int p=1)
        {
            var headings = headingManager.GetList().ToPagedList(p, 5); 
            return View(headings);
        }
        public ActionResult Yazarlar()
        {
            var item = writerManager.GetList();
            return View(item);
        }
        public ActionResult Kategoriler()
        {
            var item = categoriManager.GetAllBL();

            return View(item);
        }
        ContentManager contentManager = new ContentManager(new ContentRepository());
        public ActionResult ContentByHeading(int id)
        {
            var model = contentManager.GetListByID(id);

            return View(model);

        }
        public ActionResult WriterUpdate(int id)
        {
            var item = writerManager.GetByID(id);
            if (item != null)
            {
                return View(item);

            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult WriterUpdate(Writer writer)
        {
            writerManager.WriterUpdate(writer);

            return RedirectToAction("Yazarlar","WriterPanel");

        }

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
            heading.HeadingStatus = true;
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

    }
}