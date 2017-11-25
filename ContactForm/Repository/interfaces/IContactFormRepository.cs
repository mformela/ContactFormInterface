using ContactForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactForm.Repository.interfaces
{
    public interface IContactFormRepository : IAbstractRepository<ContactFormModel>
    {
    }
}
