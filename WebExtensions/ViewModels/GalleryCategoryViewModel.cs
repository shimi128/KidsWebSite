using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExtensions.ViewModels
{
    public class GalleryCategoryViewModel:BaseViewModel
    {
        public IList<GalleryViewModel> Galleries { get; set; }

        public GalleryCategoryViewModel()
        {
            Galleries = new List<GalleryViewModel>();
        }
    }
}
