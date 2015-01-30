using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Web.Models;
using WebExtensions.Events;

namespace Web.Controllers
{
    public class FormSurfaceController : SurfaceController
    {
        private readonly IEventPublisher _eventPublisher;
      

        public FormSurfaceController(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }


        public ActionResult ContactForm()
        {
            //if (TempData["Success"] != null && (bool)TempData["Success"])
            //{
            //    return SuccessMessage();
            //}
            var model = (ContactFormModel)TempData["FaultyModel"] ?? new ContactFormModel();
            return PartialView("_ContactForm", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitContactForm(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                model.EmailTo = CurrentPage.GetPropertyValue<string>("emailTo", true);
                model.EmailSubject = "פניה חדשה מטופס צור קשר";
                _eventPublisher.Publish(new Event<ContactFormModel> { Entity = model });
                return Success(model);
            }

            return Error(model);
        }

        public ActionResult Error(BaseContactFormModel model)
        {
            TempData["FaultyModel"] = model;
            return CurrentUmbracoPage();
        }

        private ActionResult Success(BaseContactFormModel model)
        {
            TempData["Success"] = true;
            var thanksPage = CurrentPage.Children(x => x.DocumentTypeAlias == "ThankYouPage").FirstOrDefault();
            return RedirectToUmbracoPage(thanksPage);
        }

        //private ActionResult SuccessMessage()
        //{
        //    TempData.Remove("Success");
        //    return PartialView("_SuccessMessage", CurrentPage.GetPropertyValue<string>("successMessage"));
        //}
    }
}
