using Mvc.Mailer;
using Web.Models;

namespace Web.Mailer
{
    public interface IMailer
    {
        MvcMailMessage ContactUs(ContactFormModel model);
    }
}