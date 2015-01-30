using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public class SimpleViewModelMapper<TModel, TViewModel> : ViewModelMapper<TModel, TViewModel>
        where TModel : BaseContent
        where TViewModel : BaseViewModel
    {
        public SimpleViewModelMapper(IUmbracoContextProvider umbracoConextProvider)
            : base(umbracoConextProvider)
        {

        }
    }
}
