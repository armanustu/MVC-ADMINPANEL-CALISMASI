using MVCPROJE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE.Controllers
{
    public class ChartTestController : Controller
    {
        // GET: ChartTest


        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CategoryChart()
        {

            return Json(BlogList().ToList(), JsonRequestBehavior.AllowGet);
        }


        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> lst = new List<CategoryClass>();
            lst.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8

            });
            lst.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8

            });
            lst.Add(new CategoryClass()
            {
                CategoryName = "VeriTabanı",
                CategoryCount = 4

            });
            lst.Add(new CategoryClass()
            {
                CategoryName = "Web",
                CategoryCount = 5

            });
            lst.Add(new CategoryClass()
            {
                CategoryName = "İngilizce",
                CategoryCount = 5

            });

            return lst;

        }

    }
}