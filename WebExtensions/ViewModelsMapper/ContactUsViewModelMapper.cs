using Umbraco.Web;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public class ContactUsViewModelMapper:ViewModelMapper<ContactUs,ContactUsViewModel>
    {
        public ContactUsViewModelMapper(IUmbracoContextProvider umbracoConextProvider) : base(umbracoConextProvider)
        {
        }

        protected override void Then(ContactUs model, ContactUsViewModel viewModel)
        {
            base.Then(model, viewModel);

            viewModel.ImageUrl = model.PublishedContent.GetCropUrl("image", "contactus");
        }
    }
}
