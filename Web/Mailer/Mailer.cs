using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Mailer;
using Web.Models;
using WebExtensions.Events;

namespace Web.Mailer
{
    public class Mailer : MailerBase, IMailer, IConsumer<Event<ContactFormModel>>
    {
        public Mailer()
        {
            MasterName = "_Layout";
        }
        public virtual MvcMailMessage ContactUs(ContactFormModel model)
        {
            return Populate(model);
        }

        private MvcMailMessage Populate(ContactFormModel model)
        {
            ViewBag.Data = model;
            return Populate(x =>
            {
                x.Subject = model.EmailSubject;
                x.ViewName = model.GetType().Name;
                AddRecepients(x, model.EmailTo);
            });
        }

        private void AddRecepients(MvcMailMessage mvcMailMessage, string emailTo)
        {
            emailTo.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToList().ForEach(x =>
                    mvcMailMessage.To.Add(x)
                );
        }

        public void HandleEvent(Event<ContactFormModel> eventMessage)
        {
            if (eventMessage.Entity != null)
                ContactUs(eventMessage.Entity).SendAsync();
        }
    }
}