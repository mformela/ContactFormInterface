using ContactForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ContactForm.Interfaces
{
   public interface IEmailService
    {
        MailMessage CreateMailMessage(ContactFormModel model);
        void SendEmail(MailMessage message);
    }
}
