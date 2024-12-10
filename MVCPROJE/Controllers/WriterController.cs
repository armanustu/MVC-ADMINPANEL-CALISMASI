using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager writerManager = new WriterManager(new WriterRepository());
        public ActionResult Index(int p=1)
        {
            var item = writerManager.GetList().ToPagedList(p, 6); ;
            return View(item);
        }
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer) {
            WriterValidator validations = new WriterValidator();
            ValidationResult result = validations.Validate(writer);


            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
               
                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string TamYolYeri = "~/Content/images/" + DosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                    writer.WriterImage = DosyaAdi + uzanti;
                    writerManager.WriterAdd(writer);
                    ViewBag.Status = true;
                    return View(); ;
                }
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


        public ActionResult WriterUpdate(int id)
        {
            var item = writerManager.GetByID(id);
            if (item != null)
            {
                return View(item);

            }
            return View();


        }
        [HttpPost]
        public ActionResult WriterUpdate(Writer writer)
        {
            if (Request.Files.Count > 0)//veritabanına ve klasöre kendi adıyla kaydetme
            {
                string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                string TamYolYeri = "~/Content/images/" + DosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                writer.WriterImage = DosyaAdi + uzanti;
                writerManager.WriterUpdate(writer);
                ViewBag.Status = true;
                return View(writer);
            }
            return View();

        }




    }
}