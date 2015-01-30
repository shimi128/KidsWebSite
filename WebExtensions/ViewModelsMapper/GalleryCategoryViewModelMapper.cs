using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.Web;
using WebExtensions.Common;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.Services;
using WebExtensions.ViewModels;

namespace WebExtensions.ViewModelsMapper
{
    public class GalleryCategoryViewModelMapper:ViewModelMapper<GalleryCategory,GalleryCategoryViewModel>
    {
        private readonly IGalleryService _galleryService;
        private readonly IMapperProvider _mapperProvieder;
        private readonly IContentMapper<Gallery> _contentMapper;

        public GalleryCategoryViewModelMapper(IUmbracoContextProvider umbracoConextProvider, IGalleryService gelleryService,
            IMapperProvider mapperProvieder,IContentMapper<Gallery> contentMapper )
            : base(umbracoConextProvider)
        {
            _galleryService = gelleryService;
            _mapperProvieder = mapperProvieder;
            _contentMapper = contentMapper;
        }

        protected override void Then(GalleryCategory model, GalleryCategoryViewModel viewModel)
        {
            base.Then(model, viewModel);
            var galleris = _galleryService.GetAllGalleries().ToList();

            galleris.ForEach(x =>
            {
                var gallery = _mapperProvieder.GetViewModelMapper<Gallery, GalleryViewModel>()
                    .Map(_contentMapper.Map(x));
                gallery.ImageUrl = x.GetPropertyValue<string>("image");
                viewModel.Galleries.Add(gallery);

            });

        }
    }
}
