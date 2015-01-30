using WebExtensions.Domain;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public interface IViewModelMapper<in TModel,out TViewModel> where TModel:BaseContent
        where TViewModel:BaseViewModel
    {
        TViewModel Map(TModel model);
    }
}
