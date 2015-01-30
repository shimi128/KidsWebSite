using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace WebExtensions.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly UmbracoHelper _umbraco;
        public GalleryService(IUmbracoContextProvider umbacoContextProvider)
        {
            _umbraco =new UmbracoHelper(umbacoContextProvider.GetUmbracoContext());
        }
        public IEnumerable<IPublishedContent> GetAllGalleries()
        {
            var galleries = _umbraco.TypedContentAtXPath("//GalleryCategory/Gallery['umbracoNaviHide'!='1']");

            return galleries;
        }
    }
}
