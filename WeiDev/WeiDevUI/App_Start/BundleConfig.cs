using System.Web;
using System.Web.Optimization;

namespace WeiDevUI
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                       "~/Scripts/jquery.validate.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/external").Include(
                     "~/Scripts/jquery.dcjqaccordion.2.7.js",
                     "~/Scripts/jquery.scrollTo.min.js",
                     "~/Scripts/jquery.nicescroll.js",
                     "~/Scripts/jquery.sparkline.js",
                     "~/Scripts/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js",
                     "~/Scripts/owl.carousel.js",
                     "~/Scripts/jquery.customSelect.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/right_slidebar").Include(
                       "~/Scripts/slidebars.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Scripts/common-scripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                "~/Scripts/DataTables-1.10.2/jquery.dataTables.js",
                "~/Scripts/DataTables-1.10.2/dataTables.bootstrap.js"));


            //==============================================
            //CSS

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-reset.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/style.css",
                      "~/Content/style-responsive.css"));

            bundles.Add(new StyleBundle("~/DT/css").Include(
                  "~/Scripts/assets/data-tables/DT_bootstrap.css"
                ));

            bundles.Add(new StyleBundle("~/external/css").Include(
                "~/Scripts/assets/font-awesome/css/font-awesome.css",
                "~/Scripts/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.css"
                ));

            bundles.Add(new StyleBundle("~/right_slidebar/css").Include(
               "~/Content/slidebars.css"
               ));

        }
    }
}
