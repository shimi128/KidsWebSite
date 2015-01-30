using System;
using System.Collections.Generic;
using Umbraco.Web;
using Umbraco.Web.Routing;
using WebExtensions.Extensions;

namespace Web.Routing
{
    public class NullUrlProvider:IUrlProvider
    {
        public IEnumerable<string> GetOtherUrls(UmbracoContext umbracoContext, int id, Uri current)
        {
            return null;
        }

        public string GetUrl(UmbracoContext umbracoContext, int id, Uri current, UrlProviderMode mode)
        {
            var content = umbracoContext.ContentCache.GetById(id);
            if (content == null)
                return null;
            if (content.IsContainer())
            {
                return "#";
            }

            return null;
        }
    }
}