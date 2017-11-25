using ContactForm.Models;
using ContactForm.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactForm.Repository
{

    public class ContactFormRepository : AbstractRepository<ContactFormModel>, IContactFormRepository
    {
    }
}