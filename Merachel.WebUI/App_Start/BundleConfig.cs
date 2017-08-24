using System.Web;
using System.Web.Optimization;

namespace Merachel.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                //Inspinia - Base
                "~/Scripts/Assets/Inspinia/plugins/metisMenu/metisMenu.min.js",
                "~/Scripts/Assets/Inspinia/plugins/pace/pace.min.js",
                "~/Scripts/Assets/Inspinia/app/inspinia.js",

                //Inspinia - Jquery UI
                "~/Scripts/Assets/Inspinia/plugins/jquery-ui/jquery-ui.min.js",

                //Inspinia - Daterange Picker
                "~/Scripts/Assets/Inspinia/plugins/datapicker/bootstrap-datepicker.js",
                
                //Inspinia - DataTable
                "~/Scripts/Assets/Inspinia/plugins/dataTables/datatables.min.js",

                //Inspinia - Select2
                "~/Scripts/Assets/Inspinia/plugins/select2/select2.full.min.js",
                
                //Inspinia - Summernote
                "~/Scripts/Assets/Inspinia/plugins/summernote/summernote.min.js",

                //Inspinia - Slimscroll
                "~/Scripts/Assets/Inspinia/plugins/slimscroll/jquery.slimscroll.min.js",

                //Inspinia - Ladda
                "~/Scripts/Assets/Inspinia/plugins/ladda/ladda.jquery.min.js",
                "~/Scripts/Assets/Inspinia/plugins/ladda/ladda.min.js",
                "~/Scripts/Assets/Inspinia/plugins/ladda/spin.min.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      //"~/Scripts/cbpScroller.js",
                      //"~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css",
                      "~/Content/OwlCarousel/owl.carousel.css",
                      "~/Content/OwlCarousel/owl.theme.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                      "~/Scripts/ckeditor/ckeditor.js",
                      "~/Scripts/ckeditor/config.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlcarousel").Include(
                      "~/Scripts/owl.carousel.js",
                      "~/Scripts/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Scripts/DataTables/jquery.datatable.min.js"));

            bundles.Add(new StyleBundle("~/Content/old").Include(
                      "~/Content/admin.css"));

            bundles.Add(new StyleBundle("~/Content/asset").Include(
                //Inspinia - Base
                "~/Content/Assets/Inspinia/animate.css",
                "~/Content/Assets/Inspinia/style.css",
                "~/Scripts/plugins/jquery-ui/jquery-ui.min.css"
                ));
        }
    }
}
