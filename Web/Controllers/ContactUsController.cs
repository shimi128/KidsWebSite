﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.MVC;
using WebExtensions.ViewModels;

namespace Web.Controllers
{
    public class ContactUsController : BaseController<ContactUs, ContactUsViewModel>
    {
        public ContactUsController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
    }
}
