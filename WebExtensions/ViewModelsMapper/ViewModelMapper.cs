using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using WebExtensions.Domain;
using WebExtensions.Extensions;
using WebExtensions.PropertyEditorTypes;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public abstract class ViewModelMapper<TModel, TViewModel> : IViewModelMapper<TModel, TViewModel>
        where TModel : BaseContent
        where TViewModel : BaseViewModel
    {

        protected UmbracoHelper Umbraco;

        private HeaderModel header;
        private FooterModel footer;
        public ViewModelMapper(IUmbracoContextProvider umbracoConextProvider)
        {
            Umbraco = new UmbracoHelper(umbracoConextProvider.GetUmbracoContext());
        }
        public TViewModel Map(TModel model)
        {
            var vm = Mapper.DynamicMap<TViewModel>(model);
            Then(model, vm);

            return vm;
        }

        protected virtual void Then(TModel model, TViewModel viewModel)
        {
            if (header == null)
            {
                header = viewModel.Header;
                header.Menu = model.PublishedContent.GetTopMenuItems().ToList();
                header.Name = viewModel.Name;
                header.HeaderLinks = model.PublishedContent.GetPropertyValue<List<RelatedLink>>("headerLinks", true);
                header.FacebookLink = model.PublishedContent.GetPropertyValue<string>("facebookLink", true);
                SetBreadCrumbs(header.BreadCrumbs, model.PublishedContent);
                header.HomePage = getHomePage(model.PublishedContent);
            }
            else
            {
                viewModel.Header = header;
            }

            if (footer == null)
            {
                footer = viewModel.Footer;
                footer.FooterLink = model.PublishedContent.GetPropertyValue<List<RelatedLink>>("footerLinks", true);
                footer.FacebookLink = header.FacebookLink;
                footer.FooterText = model.PublishedContent.GetPropertyValue<string>("footerText",true);
            }
            else
            {
                viewModel.Footer = footer;
            }   
            
        }

        private HomePageModel getHomePage(IPublishedContent publishedContent)
        {
            var home = publishedContent.AncestorOrSelf(1);
            return new HomePageModel
            {
                Icon=home.GetCropUrl("icon","icon"),
                Id=home.Id,
                Name=home.Name,
                Url=home.Url(),
                LogoUrl=home.GetPropertyValue<string>("logoimage")
            };
        }

        private void SetBreadCrumbs(IList<KeyValuePair<string, string>> breadCrumbs, IPublishedContent publishedContent)
        {
            if (publishedContent.Level == 1)
            {
                breadCrumbs.Add(new KeyValuePair<string, string>(publishedContent.Name, publishedContent.Url));
                return;
            }


            publishedContent.Ancestors()
                .Where(x => x.IsVisible())
                .OrderBy(x => x.Level).ForEach(x => breadCrumbs.Add(new KeyValuePair<string, string>(x.Name, x.Url)));


        }
    }
}
