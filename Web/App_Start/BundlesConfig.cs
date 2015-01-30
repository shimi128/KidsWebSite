using System.Web.Optimization;

namespace Web.App_Start
{
    public class BundlesConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/main").Include("~/scripts/jquery-1.10.2.js", "~/scripts/bootstrap.js", "~/scripts/utility.js", "~/scripts/jquery.validate.js", "~/scripts/jquery.validate.unobtrusive.js", "~/scripts/jquery.fancybox.js", "~/scripts/toastr.js", "~/scripts/siteScripts.js"));
            bundles.Add(new StyleBundle("~/css/main").Include("~/Content/bootstrap.css", "~/Content/css/bootstrap-rtl.css", "~/Content/bootstrap-theme.css", "~/Content/jquery.fancybox.css", "~/css/Styles.css", "~/Content/toastr.css","~/css/editorstyle.css"));
            
            bundles.Add(new ScriptBundle("~/scripts/grid-gallery").Include("~/scripts/grid-gallery/imagesloaded.pkgd.min.js", "~/scripts/grid-gallery/masonry.pkgd.min.js", "~/scripts/grid-gallery/classie.js", "~/scripts/grid-gallery/cbpGridGallery.js"));
            bundles.Add(new ScriptBundle("~/css/grid-gallery").Include("~/css/grid-gallery/component.css", "~/css/grid-gallery/demo.css"));
            //bundles.Add(new StyleBundle("~/css/main").Include("~/css/reset.css", "~/css/styles.css", "~/css/jquery.fancybox.css", "~/css/toastr.css"));

            //bundles.Add(new StyleBundle("~/css/main").Include("~/css/reset.css", "~/css/styles.css", "~/css/jquery.fancybox.css", "~/css/toastr.css"));
   
        }
    }
}