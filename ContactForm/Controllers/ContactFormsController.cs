﻿using System;
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

namespace ContactForm.Controllers 
{
    //podmiana użycia dbcontext na generyczne repo
    public class ContactFormsController : Controller
    {
        private IEmailService _emailService;
        private ContactFormRepository _contactRepository;
        public ContactFormsController(IEmailService emailService)
        {
            _emailService =emailService;
            _contactRepository = new ContactFormRepository();
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
