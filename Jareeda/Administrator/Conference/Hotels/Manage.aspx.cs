using Administrator.Code;
using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Conference.Hotels
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object values = HotelsGrid.GetRowValues(Convert.ToInt32(0), new string[] { "ID" });
                if (values == null)
                    values = "0";
                Session["ParentID"] = values.ToString();
            }
        }
        protected void ASPxGridView1_BeforePerformDataSelect(object sender, EventArgs e)
        {

            Session["ParentID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}