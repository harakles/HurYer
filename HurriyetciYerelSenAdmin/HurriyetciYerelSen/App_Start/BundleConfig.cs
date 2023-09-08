using System.Web;
using System.Web.Optimization;

namespace HurriyetciYerelSen
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/assets/js/jquery.js",
                        "~/assets/js/aos.js",
                        "~/assets/js/appear.js",
                        "~/assets/js/bootstrap.bundle.min.js",
                        "~/assets/js/bootstrap-select.min.js",
                        "~/assets/js/isotope.js",
                        "~/assets/js/jquery.bootstrap-touchspin.js",
                        "~/assets/js/jquery.countdown.min.js",
                        "~/assets/js/jquery.countTo.js",
                        "~/assets/js/jquery.easing.min.js",
                        "~/assets/js/jquery.enllax.min.js",
                        "~/assets/js/jquery.fancybox.js",
                        "~/assets/js/jquery.mixitup.min.js",
                        "~/assets/js/jquery.paroller.min.js",
                        "~/assets/js/jquery.polyglot.language.switcher.js",
                        "~/assets/js/map-script.js",
                        "~/assets/js/nouislider.js",
                        "~/assets/js/owl.js",
                        "~/assets/js/timePicker.js",
                        "~/assets/js/validation.js",
                        "~/assets/js/wow.js",
                        "~/assets/js/jquery.magnific-popup.min.js",
                        "~/assets/js/slick.js",
                        "~/assets/js/lazyload.js",
                        "~/assets/js/scrollbar.js",
                        "~/assets/js/tilt.jquery.js",
                        "~/assets/js/jquery.bxslider.min.js",
                        "~/assets/js/jquery-ui.js",
                        "~/assets/js/jQuery.style.switcher.min.js",
                        "~/assets/js/custom.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/css/aos.css",
                      "~/assets/css/bootstrap.min.css",
                      "~/assets/css/imp.css",
                      "~/assets/css/owl.css",
                      "~/assets/css/custom-animate.css",
                      "~/assets/css/flaticon.css",
                      "~/assets/css/font-awesome.min.css",
                      "~/assets/css/magnific-popup.css",
                      "~/assets/css/scrollbar.css",
                      "~/assets/css/hiddenbar.css",
                      "~/assets/css/color.css",
                      "~/assets/css/style.css",
                      "~/assets/css/responsive.css"));
        }
    }
}
