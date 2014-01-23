using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.ASPxGridView;

namespace Administrator.Conference.Travels
{
    public partial class Manage : Administrator.Code.AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object values = TravelsGrid.GetRowValues(Convert.ToInt32(0), new string[] { "ID" });
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