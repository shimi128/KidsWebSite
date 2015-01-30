using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Domain
{
    public class GalleryCategory:BaseContent
    {
        public IList<Gallery> Galleries { get; set; }

        public GalleryCategory()
        {
            Galleries = new List<Gallery>();
        }
    }
}
