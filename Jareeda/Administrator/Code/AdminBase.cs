using CommonWeb.Security;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace Administrator.Code
{
    public class AdminBase : System.Web.UI.Page
    {
        #region Initialization

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Request["Logout"] != null && Request["Logout"].ToLower() == "true") || (Request["logout"] != null && Request["logout"].ToLower() == "true"))
                {
                    SecurityManager.doLogout(this);
                    LoginPageHome();
                }
                if (!SecurityManager.isLogged(this))
                {
                    LoginPage();
                }
                CheckNotification();    
            }
        }

        private void CheckNotification()
        {
            if (Session["Notification"] == null) return;
            if (Session["Notification"].ToString() == "success")
            {
                Session["Notification"] = "";
                SetNotification("success", "Data Saved Successfully", "", this);
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name.Contains("ar"))
            {
                this.Theme = "GeniAdminAr";
            }
            else
            {
                this.Theme = "GeniAdminEn";
            }
        }

        public static int GetLanguageID(Page p)
        {
            if(p.Session["LanguageId"] == null)
            {
                return Convert.ToInt32(BusinessLogicLayer.Common.DefaultLanguageId);
            }
            int id = 0;
            Int32.TryParse(p.Session["LanguageId"].ToString(), out id);
            if(id == 0)
                return Convert.ToInt32(BusinessLogicLayer.Common.DefaultLanguageId);

            return id;

        }
        protected override void InitializeCulture()
        {
            try
            {
                base.InitializeCulture();
                string culture = "en";
                string uiculture = "en";
                if (!string.IsNullOrEmpty(Request["Culture"]))
                {
                    culture = Request["Culture"];
                    uiculture = culture;
                    Session["CurrentCulture"] = culture;
                    Session["CurrentCultureUI"] = uiculture;
                }
                else if (Session["CurrentCulture"] != null)
                    culture = Session["CurrentCulture"].ToString();
                if (Session["CurrentCultureUI"] != null)
                    uiculture = Session["CurrentCultureUI"].ToString();
                BusinessLogicLayer.Entities.ContentManagement.Language language = BusinessLogicLayer.Common.LanguageLogic.GetByCode(culture);
                if (language != null)
                    Session["LanguageId"] = language.LanguageId;
                //retrieve culture information from user
                //set culture to current thread
                //Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(uiculture);

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        #endregion

        #region Helpers
        protected void HomePage()
        {
            string homePage = "~/";
            if (ConfigurationManager.AppSettings["HomePage"] != null)
                homePage = ConfigurationManager.AppSettings["HomePage"];
            // transfer execution to it        
            Response.Redirect(ResolveUrl(homePage));
        }

        protected void LoginPage()
        {
            string LoginPage = "~/Login?ReturnUrl=" + Server.UrlEncode(HttpContext.Current.Request.RawUrl);
            Response.Redirect(ResolveUrl(LoginPage));
        }

        protected void LoginPageHome()
        {
            string LoginPage = "~/Login";
            Response.Redirect(ResolveUrl(LoginPage));
        }

        protected void PageError(string msg)
        {
            // store msg into session
            Session.Add("ErrorMsg", msg);
            // get error page
            string errorPage = "~/Error.aspx";
            if (ConfigurationManager.AppSettings["ErrorPage"] != null)
                errorPage = ConfigurationManager.AppSettings["ErrorPage"];
            // transfer execution to it        
            Response.Redirect(ResolveUrl(errorPage));
        }
        #endregion

        #region Client Side
        public static void Message(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "alert", "alert('" + message + "');", true);
        }

        public static void SetNotification(string messageType, string message,string iconMessage, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "notification", String.Format("SetNotification('{0}', '{1}', '{2}');", messageType, message, iconMessage), true);
        }
        #endregion

        #region Language and Date
        public static string TranslateNumerals(string sIn)
        {
            return TranslateNumerals(sIn, false);
        }
        //this method will convert all english numbers in string into arabic format
        public static string TranslateNumerals(string sIn, bool IsDate)
        {
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decoder;
            utf8Decoder = enc.GetDecoder();
            StringBuilder sTranslated = new StringBuilder();
            char[] cTransChar = new char[1];
            byte[] bytes = new byte[] { 217, 160 };
            char[] aChars = sIn.ToCharArray();
            foreach (char c in aChars)
            {
                if (char.IsDigit(c))
                {
                    bytes[1] = Convert.ToByte(160 + Convert.ToInt32((char.GetNumericValue(c))));
                    utf8Decoder.GetChars(bytes, 0, 2, cTransChar, 0);
                    sTranslated.Append(cTransChar[0]);
                }
                else
                {
                    sTranslated.Append(c);
                }
            }
            if (IsDate)
            {
                string finalResult = "";
                string[] strSplit = sTranslated.ToString().Split(new char[] { '/' });
                for (int i = strSplit.Length - 1; i >= 0; i--)
                {
                    finalResult += strSplit[i] + "/";
                }
                return finalResult.Substring(0, finalResult.Length - 1);
            }
            else
                return sTranslated.ToString();


        }

        private static string[] allFormats ={"yyyy/MM/dd","yyyy/M/d",
        "dd/MM/yyyy","d/M/yyyy",
        "dd/M/yyyy","d/MM/yyyy","yyyy-MM-dd",
        "yyyy-M-d","dd-MM-yyyy","d-M-yyyy",
        "dd-M-yyyy","d-MM-yyyy","yyyy MM dd",
       "yyyy M d","dd MM yyyy","d M yyyy",
        "dd M yyyy","d MM yyyy"};

        public static DateTime HijriToGreg(string hijri)
        {
            CultureInfo enCul = new CultureInfo("en-US");
            CultureInfo arCul = new CultureInfo("ar-SA");
            DateTime tempDate = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate;

        }


        public static string HijriToGregs(string hijri)
        {
            CultureInfo enCul = new CultureInfo("en-US");
            CultureInfo arCul = new CultureInfo("ar-SA");
            DateTime tempDate = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString("yyyy/MM/dd", enCul.DateTimeFormat);

        }

        public static string GregToHijri(DateTime dtTime)
        {
            if (dtTime == DateTime.MinValue)
                return "";
            UmAlQuraCalendar calHijri = new UmAlQuraCalendar();
            string weekday = Convert.ToString(calHijri.GetDayOfWeek(dtTime));
            int CurrDayOfMonth = calHijri.GetDayOfMonth(dtTime);
            int CurrMonth = calHijri.GetMonth(dtTime);
            int Curryear = calHijri.GetYear(dtTime);
            return CurrDayOfMonth.ToString() + "/" + CurrMonth.ToString() + "/" + Curryear.ToString();

        }

        public static string GregToHijriCompleteWithDay(DateTime dtTime)
        {
            if (dtTime == DateTime.MinValue)
                return "";
            UmAlQuraCalendar calHijri = new UmAlQuraCalendar();
            CultureInfo info = new CultureInfo("ar-sa");
            info.DateTimeFormat.Calendar = calHijri;
            string weekday = Convert.ToString(calHijri.GetDayOfWeek(dtTime));
            int CurrDayOfMonth = calHijri.GetDayOfMonth(dtTime);
            int CurrMonth = calHijri.GetMonth(dtTime);
            int Curryear = calHijri.GetYear(dtTime);
            return string.Format("{0} {3}/{2}/{1}  هـ ", dtTime.ToString("dddd", info), CurrDayOfMonth.ToString(), CurrMonth.ToString(), Curryear.ToString());

        }

        public static string GregToHijriCompleteWithDayEng(DateTime dtTime)
        {
            if (dtTime == DateTime.MinValue)
                return "";
            UmAlQuraCalendar calHijri = new UmAlQuraCalendar();
            GregorianCalendar calEng = new GregorianCalendar();
            CultureInfo info = new CultureInfo("ar-sa");
            info.DateTimeFormat.Calendar = calHijri;
            string weekday = Convert.ToString(calEng.GetDayOfWeek(dtTime));
            int CurrDayOfMonth = calHijri.GetDayOfMonth(dtTime);
            int CurrMonth = calHijri.GetMonth(dtTime);
            int Curryear = calHijri.GetYear(dtTime);
            return string.Format("{3}/{2}/{1}  h ", weekday, CurrDayOfMonth.ToString(), CurrMonth.ToString(), Curryear.ToString());

        }

        public static string GregToHijriTime(DateTime dtTime)
        {
            if (dtTime == DateTime.MinValue)
                return "";
            UmAlQuraCalendar calHijri = new UmAlQuraCalendar();
            CultureInfo info = new CultureInfo("ar-sa");
            info.DateTimeFormat.Calendar = calHijri;
            string weekday = Convert.ToString(calHijri.GetDayOfWeek(dtTime));
            int CurrDayOfMonth = calHijri.GetDayOfMonth(dtTime);
            int CurrMonth = calHijri.GetMonth(dtTime);
            int Curryear = calHijri.GetYear(dtTime);
            return dtTime.ToString("hh:mm tt", info);

        }

        public static string GetGreggCompleteByDate(DateTime dtTime)
        {

            return dtTime.ToString("yyyy/MM/dd") + "  م  ";

        }

        public static string GetGreggCompleteByDateEng(DateTime dtTime)
        {

            return dtTime.ToString("yyyy/MM/dd") + "    ";

        }
        #endregion

        #region Content Methods
        public static int GetCurrentPageLanguageId(System.Web.UI.Page page)
        {
            if (page.Session["LanguageId"] == null)
                page.Session["LanguageId"] = BusinessLogicLayer.Common.DefaultLanguageId;
            return Convert.ToInt32(page.Session["LanguageId"]);
        }
        #endregion

        #region Export
        DevExpress.Web.ASPxGridView.Export.ASPxGridViewExporter gridExporter = new DevExpress.Web.ASPxGridView.Export.ASPxGridViewExporter();
        DevExpress.Web.ASPxTreeList.Export.ASPxTreeListExporter treeExporter = new DevExpress.Web.ASPxTreeList.Export.ASPxTreeListExporter();
        public  void AddGridExporter(ASPxGridView grid)
        {
            gridExporter.ID = "gridExporter";
            gridExporter.GridViewID = grid.ID;
            gridExporter.DataBind();
            this.Controls.Add(gridExporter);
        }

        public void ExportGridToExcel(string title)
        {
            gridExporter.WriteXlsxToResponse(title);
        }

        public void ExportGridToWord(string title)
        {
            gridExporter.WriteRtfToResponse(title);
        }

        public void ExportGridToPDF(string title)
        {
            gridExporter.WritePdfToResponse(title);
        }


        public void AddTreeExporter(ASPxTreeList tree)
        {
            treeExporter.ID = "treeExporter";
            treeExporter.TreeListID = tree.ID;
            treeExporter.DataBind();
            this.Controls.Add(treeExporter);
        }

        public void ExportTreeToExcel(string title)
        {
            treeExporter.WriteXlsxToResponse(title);
        }

        public void ExportTreeToWord(string title)
        {
            treeExporter.WriteRtfToResponse(title);
        }

        public void ExportTreeToPDF(string title)
        {
            treeExporter.WritePdfToResponse(title);
        }
        #endregion

    }
}