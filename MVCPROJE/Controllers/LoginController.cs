using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCPROJE.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }

            [HttpPost]
            public ActionResult Index(Admin admin)
        {
            var user=context.Admins.FirstOrDefault(x=>x.AdminName==admin.AdminName && admin.AdminPassword==admin.AdminPassword);
            
            if (user != null && user.AdminRole=="Admin")
            {
                FormsAuthentication.SetAuthCookie(user.AdminName,false);
                Session["AdminName"] = user.AdminName;
                return RedirectToAction("Index", "Admin");
            }
            if (user != null && user.AdminRole == "Writer")
            {
                FormsAuthentication.SetAuthCookie(user.AdminName, false);
                Session["AdminName"] = user.AdminName;
                return RedirectToAction("Index", "WriterPanel");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}