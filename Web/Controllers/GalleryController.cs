using System;
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
    public class GalleryController : BaseController<Gallery,GalleryViewModel>
    {
       

        public GalleryController(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }
        

    }
}
