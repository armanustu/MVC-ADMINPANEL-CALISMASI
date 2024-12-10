using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager=new ContactManager(new ContactRepository());
        
        public ActionResult Index()
        {
            var item = contactManager.GetAllBL();
            return View(item);
        }
        public ActionResult GetDetail(int id)
        {
            var item =contactManager.GetByID(id);   
            return View(item);

        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}