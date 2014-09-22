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
    public partial class TotalVisitsWidgetITem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
                    catch(Exception ex)
                    {

                    }
                }
                return Session["MainAnalyticsManager"] as AnalyticsManager;

            }
        }
        protected void callBackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {


            List<DataItem> metrics = new List<DataItem>();
            metrics.Add(Analytics.Data.Session.Metrics.visits);
            System.Data.DataTable table = Manager.GetGaDataTable(DateTime.Today, DateTime.Today, metrics);
            metricTotalArticles.InnerText = Convert.ToInt32(table.Rows[0][0]).ToString("n0");
        }
    }
}