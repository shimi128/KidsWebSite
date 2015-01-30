using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web;
using WebExtensions.Services;

namespace WebExtensions.Converters
{
    public abstract class BaseConverter : IPropertyValueConverter
    {
        protected UmbracoHelper Umbraco;

        public BaseConverter()
        {
            var umbracoConextProvider = DependencyResolver.Current.GetService<IUmbracoContextProvider>();


            this.Umbraco = new UmbracoHelper(umbracoConextProvider.GetUmbracoContext());
        }

        public abstract bool IsConverter(PublishedPropertyType propertyType);


        public abstract object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview);


        public abstract object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview);

        public abstract object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview);
    }
}
