using System;
using System.Data;
using System.Configuration;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Web;

namespace CommonWeb.Reports
{
    public class Helper
    {
        public static string GetReportPath(DevExpress.XtraReports.UI.XtraReport fReport, string ext)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string repName = fReport.Name;
            if (repName.Length == 0) repName = fReport.GetType().Name;
            string dirName = Path.GetDirectoryName(asm.Location);
            return Path.Combine(dirName, repName + "." + ext);
        }
        public static void SetConnectionString(System.Data.OleDb.OleDbConnection oleDbConnection, string path)
        {
            oleDbConnection.ConnectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", path);
        }
        public static string GetRelativePath(string name)
        {
            return System.Web.HttpContext.Current.Request.MapPath("~/App_Data/" + name);
        }
        public static string GetRelativeStyleSheetPath(string styleSheetPath)
        {
            int index = styleSheetPath.LastIndexOf(@"\");
            index = index + 1;
            return GetRelativePath(styleSheetPath.Substring(index));
        }
        static bool IsIE55_6
        {
            get
            {
                return string.Compare(HttpContext.Current.Request.Browser.Browser, "ie", true, System.Globalization.CultureInfo.InvariantCulture) == 0 &&
                    (string.Compare(HttpContext.Current.Request.Browser.Version, "5.5", true, System.Globalization.CultureInfo.InvariantCulture) == 0 ||
                    string.Compare(HttpContext.Current.Request.Browser.Version, "6.0", true, System.Globalization.CultureInfo.InvariantCulture) == 0);
            }
        }
        public static string GetPageBorderCSSLink()
        {
            return @"<link rel=""stylesheet"" type=""text/css"" href=""" + HttpContext.Current.Request.ApplicationPath + "/CSS/PageBorder" + (IsIE55_6 ? "IE6.css" : ".css") + "\"/>";
        }
    }
    public class ReportNames
    {
        public const string
            MailMerge = "Mail Merge",
            OddEvenStyles = "Products by Categories",
            NorthwindTraders_Products = "Products List",
            NorthwindTraders_Catalog = "Fall Catalog",
            NorthwindTraders_Invoice = "Invoice",
            MasterDetailReport = "Suppliers",
            MultiColumnReport = "Customers",
            IListDatasource = "Fishes",
            CustomDraw = "Population",
            ShrinkGrow = "Employees",
            BarCodes_ProductLabels = "Product Labels",
            BarCodes_BarcodeTypes = "Barcode Types",
            RichText = "Cars",
            Subreports = "Customers List",
            TableReport = "Customer Order",
            TreeView = "Countries",
            Charts = "Prices",
            SideBySideReports = "Employee Comparison",
            AnchorVertical = "Vertical Anchoring",
            XRPivotGrid = "Orders Report",
            CalculatedFieldsReport = "Calculated Fields",
            FormattingRulesReport = "Condition Formatting";
    }
}