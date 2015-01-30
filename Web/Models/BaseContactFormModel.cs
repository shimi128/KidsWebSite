using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class BaseContactFormModel
    {
        public string EmailTo { get; set; }
        public virtual string EmailSubject { get; set; }
    }
}