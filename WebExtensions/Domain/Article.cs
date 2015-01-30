using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Domain
{
    public class Article:BaseContent
    {
        public string ShortText { get; set; }
        public string ArticleImageUrl { get; set; }
        public string ArticleImageUrlWide { get; set; }
    }
}
