using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Core.Services;
using Umbraco.Web;
using Web.Mailer;
using WebExtensions.Common;
using WebExtensions.ContentMappers;
using WebExtensions.Domain;
using WebExtensions.Events;
using WebExtensions.Indexers;
using WebExtensions.Infrastructure;
using WebExtensions.Searchers;
using WebExtensions.Services;
using WebExtensions.ViewModels;
using WebExtensions.ViewModelsMapper;


namespace Web.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // web api controllers
            builder.RegisterApiControllers(typeof (UmbracoApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UmbracoContextProvider>().As<IUmbracoContextProvider>().InstancePerHttpRequest();
            builder.RegisterType<AppDomainTypeFinder>().As<ITypeFinder>().InstancePerHttpRequest();
            builder.RegisterGeneric(typeof (ContentMapper<>)).As(typeof (IContentMapper<>)).InstancePerHttpRequest();

            builder.RegisterType<AutofacServiceProvider>()
                .As<WebExtensions.Common.IServiceProvider>()
                .InstancePerHttpRequest();
            builder.RegisterType<MapperProvider>().As<IMapperProvider>().InstancePerHttpRequest();
            builder.RegisterInstance(ApplicationContext.Current.Services.ContentService)
                    .As<IContentService>()
                    .SingleInstance();
            builder.RegisterType<RepositoryFactory>().AsSelf().InstancePerHttpRequest();

            builder.RegisterType<EventPublisher>().As<IEventPublisher>().InstancePerHttpRequest();
            builder.RegisterType<SubscriptionService>().As<ISubscriptionService>().InstancePerHttpRequest();

            builder.RegisterType<BaseCategoriesService<CategoriesGames>>().As<IBaseCategoriesService<CategoriesGames>>().InstancePerHttpRequest();
            builder.RegisterType<BaseCategoriesService<CategoriesMovies>>().As<IBaseCategoriesService<CategoriesMovies>>().InstancePerHttpRequest();
            builder.RegisterType<BaseCategoriesService<SubCategoryMovies>>().As<IBaseCategoriesService<SubCategoryMovies>>().InstancePerHttpRequest();
            builder.RegisterType<BaseCategoriesService<SubCategoryGames>>().As<IBaseCategoriesService<SubCategoryGames>>().InstancePerHttpRequest();
            builder.RegisterType<GalleryService>().As<IGalleryService>().InstancePerHttpRequest();
            builder.RegisterType<NewsService>().As<INewsService>().InstancePerHttpRequest();
            builder.RegisterType<ArticlesSerivce>().As<IArticlesSerivce>().InstancePerHttpRequest();
            builder.RegisterType<Mailer.Mailer>().As<IMailer>().InstancePerHttpRequest();
            builder.RegisterType<ExamineSearcherProvider>().As<IExamineSearcherProvider>().InstancePerHttpRequest();
            builder.RegisterType<ExternalSearchService>().As<IExternalSearchService>().InstancePerHttpRequest();
           
            RegisterMappers(builder);
            RegisterExamineEventConsumers(builder);

           

            RegisterConsumers(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static void RegisterExamineEventConsumers(ContainerBuilder builder)
        {
            var typeFinder = new AppDomainTypeFinder();
            var consumers = typeFinder.FindClassesOfType<IExamineEventsConsumer>(true);
            foreach (var consumer in consumers)
            {
                builder.RegisterType(consumer).As<IExamineEventsConsumer>().SingleInstance();
            }
        }

        private static void RegisterConsumers(ContainerBuilder builder)
        {
            var typeFinder = new AppDomainTypeFinder();
            var types = typeof(IConsumer<>);
            var consumers = typeFinder.FindClassesOfType(types);
            foreach (var consumer in consumers)
            {
                builder.RegisterType(consumer)
                    .As(consumer.FindInterfaces((type, criteria) =>
                         type.IsGenericType && ((Type)criteria).IsAssignableFrom(type.GetGenericTypeDefinition())
                   , typeof(IConsumer<>)))
                    .InstancePerHttpRequest();
            }
        }

        private static void RegisterMappers(ContainerBuilder builder)
        {
            ITypeFinder typeFinder = new AppDomainTypeFinder();
            var simpleMapperType = typeof (SimpleViewModelMapper<,>);
            var mapperType = typeof (IViewModelMapper<,>);

            var allConverterTypes = typeFinder.FindClassesOfType(mapperType).ToArray();
            var allVmTypes = typeFinder.FindClassesOfType<BaseViewModel>().ToArray();
            var allModelTypes = typeFinder.FindClassesOfType<BaseContent>().ToArray();
            foreach (var vmType in allVmTypes)
            {
                var contentTypeName = vmType.Name.Replace("ViewModel", "");
                var contentType =
                    allModelTypes.FirstOrDefault(
                        c => c.Name.Equals(contentTypeName, StringComparison.InvariantCultureIgnoreCase));
                if (contentType == null)
                    continue;

                var specificeMapperType = allConverterTypes.FirstOrDefault(ct =>
                {
                    var t = ct.GetInterfaces().First(i => i.GetGenericTypeDefinition() == mapperType);
                    return t.GenericTypeArguments[0] == contentType && t.GenericTypeArguments[1] == vmType;

                });

                var concreteType = specificeMapperType ?? simpleMapperType.MakeGenericType(contentType, vmType);

                var target = mapperType.MakeGenericType(contentType, vmType);
                builder.RegisterType(concreteType).As(target).InstancePerHttpRequest();


                AutoMapper.Mapper.CreateMap(contentType, vmType);


            }
        }
    }
}