using Umbraco.Core.Models;
using WebExtensions.Domain;
using WebExtensions.ViewModels;

namespace WebExtensions.Common
{
    public static class MapperProviderExtensions
    {
        public static TViewModel MapContent<TContent, TViewModel>(this IPublishedContent content,
            IMapperProvider mapperProvider)
            where TContent : BaseContent, new()
            where TViewModel : BaseViewModel, new()
        {
            var contentMapper = mapperProvider.GetContentMapper<TContent>();
            var vmMapper = mapperProvider.GetViewModelMapper<TContent, TViewModel>();

            return vmMapper.Map(contentMapper.Map(content));
        }
    }
}
