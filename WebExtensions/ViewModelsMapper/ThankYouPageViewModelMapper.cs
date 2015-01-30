using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public class ThankYouPageViewModelMapper : ViewModelMapper<ThankYouPage, ThankYouPageViewModel>
    {
        public ThankYouPageViewModelMapper(IUmbracoContextProvider umbracoConextProvider) : base(umbracoConextProvider)
        {
        }
    }
}
