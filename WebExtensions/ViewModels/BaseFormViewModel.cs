using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.ViewModels
{
    public class BaseFormViewModel:BaseViewModel
    {
        public string ImageUrl { get; set; }
        public string EmailTo { get; set; }
    }
}
