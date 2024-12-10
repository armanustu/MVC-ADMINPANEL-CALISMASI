using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var item=aboutManager.GetAllBL();
            return View(item);
        }
        AboutManager aboutManager = new AboutManager(new AboutRepository());
        public PartialViewResult AboutPartial()
        {
            //aboutManager.AboutAddBL(about);
            //return RedirectToAction("Index");
            return PartialView();
        }
        public ActionResult AddAbout()
        {
            return View();
        }
            [HttpPost]
        public ActionResult AddAbout(About about)
        {

            aboutManager.AboutAddBL(about);
            return RedirectToAction("Index");
        }



    }
}