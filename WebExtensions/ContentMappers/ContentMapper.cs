using System.Reflection;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using WebExtensions.Domain;

namespace WebExtensions.ContentMappers
{
    public class ContentMapper<TContent> :IContentMapper<TContent> where TContent:BaseContent,new()
    {
        public TContent Map(IPublishedContent content)
        {
            var model = new TContent();
            FillValues(content, model);
            model.PublishedContent = content;
            model.IsVisible = !content.GetPropertyValue<bool>("umbracoNaviHide");
            return model;
        }

        protected void FillValues(IPublishedContent content, TContent model)
        {
            var type = typeof(TContent);
            var properties =
                type.GetProperties(BindingFlags.Public | BindingFlags.Instance);


            foreach (PropertyInfo propertyInfo in properties)
            {
                var contentType = content.GetType();
                if (content.GetType().GetProperty(propertyInfo.Name) != null)
                {
                    // It is a default propery - get the value with refelection
                    var propertyValue = contentType.GetProperty(propertyInfo.Name).GetValue(content, null);
                    type.GetProperty(propertyInfo.Name).SetValue(model, propertyValue, null);
                }
                else
                {
                    // it is a doctype property - ask Umbraco for the value
                    var propertyValue = content.GetPropertyValue(propertyInfo.Name);
                    if (propertyValue != null &&
                        type.GetProperty(propertyInfo.Name).PropertyType.IsInstanceOfType(propertyValue))
                        type.GetProperty(propertyInfo.Name).SetValue(model, propertyValue, null);
                    else
                    {
                        var attempt = propertyValue.TryConvertTo(type.GetProperty(propertyInfo.Name).PropertyType);
                        if (attempt.Success && attempt.Result != null)
                            type.GetProperty(propertyInfo.Name).SetValue(model, attempt.Result, null);
                    }
                }
            }
        }
    }
}
