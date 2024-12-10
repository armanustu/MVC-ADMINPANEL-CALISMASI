using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        GaleriManager galeriManager = new GaleriManager(new GaleriRepository());
        public ActionResult Index()
        {
          var list=  galeriManager.GetAllBL();
            return View(list);
        }
    }
}