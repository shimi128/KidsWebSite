using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.Infrastructure;
using WebExtensions.ViewModels;
using WebExtensions.ViewModelsMapper;

namespace WebExtensions.Common
{
    public class MapperProvider: IMapperProvider
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITypeFinder _typeFinder;

        public MapperProvider(IServiceProvider serviceProvider, ITypeFinder typeFinder)
        {
            _serviceProvider = serviceProvider;
            _typeFinder = typeFinder;
        }

        public IContentMapper<TContent> GetContentMapper<TContent>() where TContent : BaseContent, new()
        {
            return _serviceProvider.GetService<IContentMapper<TContent>>();
        }




        public IViewModelMapper<TContent, TViewModel> GetViewModelMapper<TContent, TViewModel>()
            where TContent : BaseContent
            where TViewModel : BaseViewModel
        {
            return _serviceProvider.GetService<IViewModelMapper<TContent, TViewModel>>();
        }
    }
}
