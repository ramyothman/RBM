using Administrator.Code;
using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.HumanResources.Organizations
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object values = OrganizationGrid.GetRowValues(Convert.ToInt32(0), new string[] { "OrganizationId" });
                if (values == null)
                    values = "0";
                Session["OrganizationId"] = values.ToString();
            }
        }

        protected void OrganizationLanguagesGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["OrganizationId"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}