using Analytics;
using Analytics.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Dashboard.Controls.GoogleAnalytics
{
    public partial class TopArticleTodayWidgetItem : System.Web.UI.UserControl
    {

        AnalyticsManager Manager
        {
            set { Session["MainAnalyticsManager"] = value; }
            get
            {
                if (Session["MainAnalyticsManager"] == null)
                {
                    try
                    {
                        AnalyticsManager manager = new AnalyticsManager(Server.MapPath("~/Libraries/privatekey.p12"), BusinessLogicLayer.Common.ClientEmailAddress);
                        manager.LoadAnalyticsProfiles();
                        manager.SetDefaultAnalyticProfile(BusinessLogicLayer.Common.DefaultAnalaticsProfile);
                        Session["MainAnalyticsManager"] = manager;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return Session["MainAnalyticsManager"] as AnalyticsManager;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
        protected void callBackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {

            List<DataItem> metrics = new List<DataItem>();
            metrics.Add(Analytics.Data.Session.Metrics.visits);
            List<DataItem> dimensions = new List<DataItem>();
            dimensions.Add(Analytics.Data.PageTracking.Dimensions.pagePath);
            System.Data.DataTable table = Manager.GetGaDataTable(DateTime.Today, DateTime.Today, metrics, dimensions, null, 1, null, null, null,  metrics, false, null, null);
            string visitItem = table.Rows[0][0].ToString();
            string[] idSplit = visitItem.Split('-');
            int id = 0;
            Int32.TryParse(idSplit[1],out id);
            if (id != 0)
            {
                BusinessLogicLayer.Entities.ContentManagement.Article article = BusinessLogicLayer.Common.ArticleLogic.GetByID(id);
                if (article != null)
                {
                    WriterImage.Src = GetWriterImagePath(article.Author.PersonImage);
                    Writer.InnerText = article.AuthorName;
                    ArticleShortName.InnerText = article.ShortTitle;
                }
            }
            AFTitle.Text = Convert.ToInt32(table.Rows[0][1]).ToString("n0");
        }
    }
}