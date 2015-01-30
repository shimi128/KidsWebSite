using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ContactFormModel:BaseContactFormModel
    {
        [DisplayName("שם מלא")]
        [Required(ErrorMessage = "שדה חובה")]
        [MaxLength(50, ErrorMessage = "אנא הזן לכל היותר 50 תוים")]
        public string FullName { get; set; }

        [DisplayName("כתובת מייל")]
        [Required(ErrorMessage = "שדה חובה")]
        [EmailAddress(ErrorMessage = "כתובת מייל לא תקינה")]
        public string EmailAddres { get; set; }

        [DisplayName("טלפון")]
        [RegularExpression("^\\d{2,3}-?\\d{7}$", ErrorMessage = "אנא הזן מספר טלפון תקין בן 9-10 ספרות. לדוגמה 055-1234567")]
        public string Phone { get; set; }

        [DisplayName("פרטים")]
        [MaxLength(200, ErrorMessage = "אנא הזן לכל היותר 200 תוים")]
        public string Message { get; set; }
    }
}