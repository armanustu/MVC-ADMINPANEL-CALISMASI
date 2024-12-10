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
  
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new AdminRepository());
        public ActionResult Index()
        {
           var list= adminManager.GetAllBL();
            return View(list);
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
           // admin.Adminstatus = true;
            adminManager.AdminAddBL(admin);
            ViewBag.Status = true;
            return View();
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        public ActionResult AdminDelete(int id)
        { 
            var adminvalue = adminManager.GetByID(id);
            adminvalue.Adminstatus = false;
            adminManager.AdminUpdate(adminvalue);
            return RedirectToAction("Index","Authorization");

        }
        public ActionResult UpdateAdmin(int id) 
        {
            var adminvalue = adminManager.GetByID(id);
            adminManager.AdminUpdate(adminvalue);
            return View(adminvalue);

        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index","Authorization");
        }
    }
}