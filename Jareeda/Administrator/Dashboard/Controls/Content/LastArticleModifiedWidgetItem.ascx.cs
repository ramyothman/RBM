using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Dashboard.Controls
{
    public partial class LastArticleModifiedWidgetItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void callBackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            BusinessLogicLayer.Entities.ContentManagement.Article article = BusinessLogicLayer.Common.ArticleLogic.FindLastArticle(BusinessLogicLayer.Common.DefaultLanguage.LanguageId.ToString(), "0");
            Writer.InnerText = article.AuthorName;
            WriterImage.Src = GetWriterImagePath(article.Author.PersonImage);
            ArticleShortName.InnerText = article.ShortTitle;
            //~/images/writters-s.jpg
            AFTitle.Text = GetDate(DateTime.Today);
        }

        public string GetWriterImagePath(string url)
        {
            string urlFinal = BusinessLogicLayer.Common.NewsImages + url;
            if (string.IsNullOrEmpty(url))
            {
                urlFinal = "~/images/writters-s.jpg";
            }
            return urlFinal;
        }

        public string GetDate(DateTime d)
        {
            DateTime dt = BusinessLogicLayer.Common.ArticleLogic.GetLast(0);
            TimeSpan ts = DateTime.Now.Subtract(dt);
            string x = "";
            if (Thread.CurrentThread.CurrentCulture.Name.Contains("ar"))
            {
                if (ts.Hours == 0)
                {
                    x = CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriCompleteWithDay(d)) + " - " + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GetGreggCompleteByDate(d));
                    x += " آخر تحديث منذ " + ts.Minutes + " دقيقة ";
                }
                else
                {
                    x = CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriCompleteWithDay(d)) + " - " + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GetGreggCompleteByDate(d));
                    x += " آخر تحديث منذ " + ts.Hours + " ساعة و " + ts.Minutes + " دقيقة ";
                }
            }
            else
            {
                if (ts.Hours == 0)
                {
                    x = CommonWeb.Common.BasePage.GregToHijriCompleteWithDayEng(d) + " - " + CommonWeb.Common.BasePage.GetGreggCompleteByDateEng(d);
                    x += " last post from " + ts.Minutes + " minutes ";
                }
                else
                {
                    x = CommonWeb.Common.BasePage.GregToHijriCompleteWithDayEng(d) + " - " + CommonWeb.Common.BasePage.GetGreggCompleteByDateEng(d);
                    x += " last post from " + ts.Hours + " hours " + ts.Minutes + " minutes ";
                }
            }
            return x;
        }
    }
}