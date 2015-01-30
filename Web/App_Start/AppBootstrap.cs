using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using Umbraco.Core;
using Umbraco.Web.Routing;
using Web.Routing;

namespace Web.App_Start
{
    public class AppBootstrap : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            UrlProviderResolver.Current.InsertTypeBefore<DefaultUrlProvider, NullUrlProvider>();
           }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            DependencyConfig.RegisterDependencies();
            BundlesConfig.RegisterBundles(BundleTable.Bundles);
            ExamineEventsHandler.Init();
        }
    }
}