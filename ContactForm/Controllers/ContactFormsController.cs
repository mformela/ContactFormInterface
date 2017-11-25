using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactForm.Models;
using ContactForm.Repository;
using ContactForm.Service;
using ContactForm.Interfaces;
using ContactForm.Repository.interfaces;

namespace ContactForm.Controllers 
{
    //podmiana użycia dbcontext na generyczne repo
    public class ContactFormsController : Controller
    {
        //zmieniamy jako interface - i zmieniamy w konstruktorze nie new -> ma pobierać z parametru a nie tworzyć nową instancję
        private IEmailService _emailService;
        private IContactFormRepository _contactRepository;
        public ContactFormsController(IEmailService emailService, IContactFormRepository contactRepository)
        {
            _emailService =emailService;
            _contactRepository = contactRepository;
        }
       

        // GET: ContactForms
        public ActionResult Index()
        {
            return View(_contactRepository.GetWhere(x => x.Id>0));//przykład zastosowania metody generycznej GetWhere
        }

        // GET: ContactForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactFormModel contactForm = _contactRepository.GetWhere(x =>x.Id==id.Value).FirstOrDefault();
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // GET: ContactForms/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactFormModel contactForm)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Create(contactForm);
                //var message = _emailService.CreateMailMessage(contactForm);
                //_emailService.SendEmail(message);
                return RedirectToAction("Index");
            }

            return View(contactForm);
        }




        // GET: ContactForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactFormModel contactForm = _contactRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactFormModel contactForm = _contactRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _contactRepository.Delete(contactForm);

            return RedirectToAction("Index");
        }
    }
}
