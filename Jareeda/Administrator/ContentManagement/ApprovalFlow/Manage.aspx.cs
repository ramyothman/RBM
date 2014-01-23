using Administrator.Code;
using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.ContentManagement.ApprovalFlow
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //AFTitle.Text = Resources.ContentManagement.AFTitle;
            if (!IsPostBack)
            {
                object values = SourcesGrid.GetRowValues(Convert.ToInt32(0), new string[] { "ApprovalFlowID" });
                if (values == null)
                    values = "0";
                Session["ApprovalFlowID"] = values.ToString();
            }
        }

        protected void OfferFlowDetailGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["ApprovalFlowID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}