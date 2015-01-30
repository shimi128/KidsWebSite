using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.PropertyEditorTypes
{
    public class RelatedLink
    {
        public string Caption { get; set; }
        public string Link { get; set; }
        public bool NewWindow { get; set; }
        public string Internal { get; set; }
        public bool Edit { get; set; }
        public bool IsInternal { get; set; }
        public string InternalName { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
    }
}
