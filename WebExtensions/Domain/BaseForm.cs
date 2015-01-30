using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Domain
{
    public class BaseForm:BaseContent
    {
        public string ImageUrl { get; set; }
        public string EmailTo { get; set; }
    }
}
