using System.Web;
using System.Web.Optimization;

namespace HurriyetciYerelSenAdmin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/vendor/fonts/fontawesome.css",
                      "~/assets/vendor/fonts/tabler-icons.css",
                      "~/assets/vendor/fonts/flag-icons.css",
                      "~/assets/vendor/css/rtl/core.css",
                      "~/assets/vendor/css/rtl/theme-default.css",
                      "~/assets/css/demo.css",
                      "~/assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.css",
                      "~/assets/vendor/libs/node-waves/node-waves.css",
                      "~/assets/vendor/libs/typeahead-js/typeahead.css",
                      "~/assets/vendor/libs/dropzone/dropzone.css",
                      "~/assets/vendor/libs/apex-charts/apex-charts.css",
                      "~/assets/vendor/libs/swiper/swiper.css",
                      "~/assets/vendor/libs/datatables-bs5/datatables.bootstrap5.css",
                      "~/assets/vendor/libs/datatables-responsive-bs5/responsive.bootstrap5.css",
                      "~/assets/vendor/libs/datatables-checkboxes-jquery/datatables.checkboxes.css",
                      "~/assets/vendor/libs/flatpickr/flatpickr.css",
                      "~/assets/vendor/libs/select2/select2.css",
                      "~/assets/SweetAlert/sweetalert2.css",
                      "~/assets/vendor/libs/quill/katex.css",
                      "~/assets/vendor/libs/quill/editor.css",
                      "~/assets/vendor/libs/flatpickr/flatpickr.css",
                      "~/assets/vendor/libs/bootstrap-datepicker/bootstrap-datepicker.css",
                      "~/assets/vendor/libs/bootstrap-daterangepicker/bootstrap-daterangepicker.css",
                      "~/assets/vendor/libs/pickr/pickr-themes.css",    
                      "~/assets/vendor/libs/formvalidation/dist/css/formValidation.min.css",
                      "~/assets/vendor/css/pages/page-auth.css",
                      "~/assets/vendor/css/pages/cards-advance.css"
                      ));

            bundles.Add(new ScriptBundle("~/Bundle/js").Include(
                        "~/Scripts/jquery-3.7.0.js",
                        "~/assets/vendor/libs/popper/popper.js",
                        "~/assets/vendor/js/bootstrap.js",
                        "~/assets/Datatable/datatables.min.js",
                        "~/assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.js",
                        "~/assets/vendor/libs/node-waves/node-waves.js",
                        "~/assets/vendor/libs/hammer/hammer.js",
                        "~/assets/vendor/libs/i18n/i18n.js",
                        "~/assets/vendor/libs/typeahead-js/typeahead.js",
                        "~/assets/vendor/js/menu.js",
                        "~/assets/vendor/libs/apex-charts/apexcharts.js",
                        "~/assets/vendor/libs/swiper/swiper.js",
                        "~/assets/Clave/cleave.min.js",
                        "~/assets/Clave/cleave-phone.i18n.js",
                        "~/assets/vendor/libs/moment/moment.js",
                        "~/assets/vendor/libs/flatpickr/flatpickr.js",
                        "~/assets/vendor/libs/select2/select2.js",
                        "~/assets/vendor/libs/dropzone/dropzone.js",
                        "~/assets/SweetAlert/sweetalert2.all.min.js",
                        "~/assets/vendor/libs/formvalidation/dist/js/FormValidation.full.min.js",
                        "~/assets/vendor/libs/formvalidation/dist/js/plugins/Bootstrap5.min.js",
                        "~/assets/vendor/libs/formvalidation/dist/js/plugins/AutoFocus.min.js",
                        "~/assets/vendor/libs/quill/katex.js",
                        "~/assets/vendor/libs/quill/quill.js",
                        "~/assets/vendor/libs/moment/moment.js",
                        "~/assets/vendor/libs/flatpickr/flatpickr.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/assets/vendor/libs/bootstrap-datepicker/bootstrap-datepicker.js",
                        "~/assets/vendor/libs/bootstrap-daterangepicker/bootstrap-daterangepicker.js",
                        "~/assets/vendor/libs/pickr/pickr.js",
                        "~/assets/js/main.js"
                ));
        }
    }
}
