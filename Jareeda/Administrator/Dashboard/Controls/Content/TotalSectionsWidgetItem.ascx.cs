using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Dashboard.Controls
{
    public partial class TotalSectionsWidgetItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void callBackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            metricTotalArticles.InnerText = BusinessLogicLayer.Common.SiteSectionLogic.GetAll().Count.ToString("n0");
        }
    }
}