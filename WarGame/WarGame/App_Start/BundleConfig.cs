﻿using System.Web;
using System.Web.Optimization;

namespace WarGame
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            var cssUrlRewriter = new CssRewriteUrlTransform();

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                     "~/Scripts/jquery-{version}.js",
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/westeros-map").Include(
                    "~/Scripts/game-play.js",
                    "~/Scripts/westeros-map-view.js"
                ));

            bundles.Add(new StyleBundle("~/Content/Styles/css")
                      .Include("~/Content/Styles/bootstrap.css", cssUrlRewriter)
                      .Include("~/Content/Styles/site.css", cssUrlRewriter)
                      .Include("~/Content/Styles/bootstrap.min.css", cssUrlRewriter));

        }
    }
}
