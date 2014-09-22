using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.Web.UI;
using System.Text;

namespace CommonWeb.Common
{
    public enum BasePageType
    {
        Manage,
        View,
        Save
    }
    /// <summary>
    /// Summary description for BasePage
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        public BasePageType PageType = BasePageType.Manage;
        public BasePage()
        {

            //
            // TODO: Add constructor logic here
            //
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name.Contains("ar"))
            {
                this.Theme = "MetropolisBlueAr";
            }
            else
            {
                this.Theme = "MetropolisBlue";
            }
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

        #region Helpers
        public int intItemID
        {
            get { return (ViewState["intItemID"] != null) ? int.Parse(ViewState["intItemID"].ToString()) : 0; }
            set { ViewState["intItemID"] = value.ToString(); }
        }

        // the currently selected item id, where actions like view details, update, delete, etc take place.
        public string ItemID
        {
            get { return (ViewState["ItemID"] != null) ? ViewState["ItemID"] as string : string.Empty; }
            set { ViewState["ItemID"] = value; }
        }

        // redirect to home page
        protected void PageHome()
        {
            string homePage = "~/";
            if (ConfigurationManager.AppSettings["HomePage"] != null)
                homePage = ConfigurationManager.AppSettings["HomePage"];
            // transfer execution to it        
            Response.Redirect(ResolveUrl(homePage));
        }

        // redirect to login
        protected void PageLogin()
        {
            string LoginPage = "~/Login/Default.aspx";
            //if (ConfigurationManager.AppSettings["LoginPage"] != null)
            //    LoginPage = ConfigurationManager.AppSettings["LoginPage"];
            // transfer execution to it        
            Response.Redirect(ResolveUrl(LoginPage));
        }



        // onError, redirect the browser to the error page
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

        public static void Message(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "alert", "alert('" + message + "');", true);
        }

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
            return string.Format("{0} {3}/{2}/{1}  هـ ",dtTime.ToString("dddd", info),CurrDayOfMonth.ToString(),CurrMonth.ToString() ,Curryear.ToString());

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

            return  dtTime.ToString("yyyy/MM/dd") + "  م  "; 

        }

        public static string GetGreggCompleteByDateEng(DateTime dtTime)
        {

            return dtTime.ToString("yyyy/MM/dd") + "    ";

        }
        #endregion

        #region Main Conference Methods
        public static int GetCurrentPageLanguageId(System.Web.UI.Page page)
        {
            if (page.Session["LanguageId"] == null)
                page.Session["LanguageId"] = BusinessLogicLayer.Common.DefaultLanguageId;
            return Convert.ToInt32(page.Session["LanguageId"]);
        }
        public static BusinessLogicLayer.Entities.Conference.Conferences GetConferenceFromPage(System.Web.UI.Page page)
        {
            BusinessLogicLayer.Entities.Conference.Conferences conference = null;
            if (page.Session["CurrentApplicationConference"] == null)
            {
                //TODO: Load Conference Dynamically
                page.Session["CurrentApplicationConference"] = BusinessLogicLayer.Common.ConferencesLogic.GetByID(1);
                if (page.Session["CurrentApplicationConference"] != null)
                    page.Session["CurrentApplicationConferenceId"] = ((BusinessLogicLayer.Entities.Conference.Conferences)page.Session["CurrentApplicationConference"]).ConferenceId;
            }
            if (!page.IsPostBack)
            {
                page.Session["CurrentApplicationConferenceId"] = page.Session["CurrentApplicationConferenceId"].ToString();
            }
            conference = page.Session["CurrentApplicationConference"] as BusinessLogicLayer.Entities.Conference.Conferences;
            return conference;
        }
        #endregion


    }
}