﻿Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryui").Include(
                  "~/Scripts/jquery-ui-{version}.js"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New ScriptBundle("~/bundles/custom").Include(
                  "~/Scripts/DataTables/jquery.dataTables.min.js",
                  "~/Scripts/custom.js",
                  "~/Scripts/modernizr.custom.js",
                  "~/Scripts/tinymce/tinymce.min.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css",
                  "~/Content/font-awesome.css",
                  "~/Content/superfish.css",
                  "~/Content/megafish.css",
                  "~/Content/jquery.navgoco.css",
                  "~/Content/owl.carousel.css",
                  "~/Content/owl.theme.css",
                  "~/Content/jquery.mCustomScrollbar.css",
                  "~/Content/bootstrap-slider.css",
                  "~/Content/style.css",
                  "~/Content/DataTables/css/jquery.dataTables.min.css",
                  "~/Content/fontawesome/font-awesome.css"))



    End Sub
End Module

