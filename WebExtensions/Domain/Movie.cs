using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.Domain
{
    public class Movie:BaseContent
    {
        public string YouTubeUrl { get; set; }
        public string LargeImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
    }
}
