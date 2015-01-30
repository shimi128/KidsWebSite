using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Mvc;
using WebExtensions.ViewModels;

namespace WebExtensions.MVC
{
    public class WebLayout<T>:UmbracoViewPage<T> where T:IBaseViewModel
    {
        public override void Execute()
        {
           
        }
    }
}
