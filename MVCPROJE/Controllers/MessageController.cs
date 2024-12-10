using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAcessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPROJE.Controllers
{
   
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new MessageRepository());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox() {//Göndericini bilgilerini gönderir yani gelen kutusu olarak

            var item = messageManager.GetListBox();
            return View(item);
        
        }
        public ActionResult SendBox()
        {
            var message = messageManager.SendListBox();
            return View(message);
        }
        [HttpGet]
        public ActionResult AddNews() {
            return View();
        }
        [HttpPost]
        public ActionResult AddNews(Message message) {
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
             MessageValidator validations = new MessageValidator();
             ValidationResult result=validations.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return View("SendBox");
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
        public ActionResult MessageGetInListBox(int id)
        {
            var item = messageManager.GetByID(id);
            return View(item);
        }
        public ActionResult MessageGetListSendBox(int id)
        {
            var item=messageManager.GetByID(id);
            return View(item);
        }
            
    }
}