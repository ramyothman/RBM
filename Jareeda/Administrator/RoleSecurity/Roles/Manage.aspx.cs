using Administrator.Code;
using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.RoleSecurity.Roles
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                object values = gvRoles.GetRowValues(Convert.ToInt32(0), new string[] { "RoleId" });
                if (values == null)
                    values = "0";
                Session["RoleID"] = values.ToString();
            }
        }
        protected void ASPxGridView1_BeforePerformDataSelect(object sender, EventArgs e)
        {

            Session["RoleID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}