using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.ViewModels;
using WebExtensions.ViewModelsMapper;

namespace WebExtensions.Common
{
    public interface IMapperProvider
    {
        IContentMapper<TContent> GetContentMapper<TContent>() where TContent : BaseContent, new();
        IViewModelMapper<TContent, TViewModel>  GetViewModelMapper<TContent, TViewModel>()where TContent : BaseContent where TViewModel : BaseViewModel;
    }
}
