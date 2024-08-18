﻿using System.Web.Optimization;

namespace AlWarraq
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/assets").Include(
                      "~/assets/css/normalize.css",
                      "~/assets/icomoon/icomoon.css",
                      "~/assets/css/vendor.css",
                      "~/assets/style.css")
                      );

            bundles.Add(new ScriptBundle("~/assets/js").Include(
            "~/assets/js/plugins.js",
            "~/assets/js/script.js",
            "~/assets/js/jquery-1.11.0.min.js"
            ));
        }
    }
}
