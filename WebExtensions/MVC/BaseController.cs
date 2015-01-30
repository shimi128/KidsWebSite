using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using WebExtensions.Common;
using WebExtensions.Domain;
using WebExtensions.ViewModels;

namespace WebExtensions.MVC
{
    public class BaseController<TContent, TModel> : RenderMvcController where TContent : BaseContent, new()
        where TModel : BaseViewModel, new()
    {
        protected readonly IMapperProvider _mapperProvider;

        public BaseController(IMapperProvider mapperProvider)
        {
            _mapperProvider = mapperProvider;
        }

        public override ActionResult Index(RenderModel model)
        {
            var viewModel = Create(model);

            if (viewModel == null)
                return View(model);

            return View(viewModel);
        }

        protected virtual TModel Create(RenderModel model)
        {
            var content = _mapperProvider.GetContentMapper<TContent>().Map(model.Content);
            var viewModel = _mapperProvider.GetViewModelMapper<TContent, TModel>().Map(content);
            return viewModel;
        }
    }
}
