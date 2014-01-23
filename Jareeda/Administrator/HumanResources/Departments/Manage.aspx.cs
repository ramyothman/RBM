using Administrator.Code;
using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.HumanResources.Departments
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object values = DepartmentGrid.GetRowValues(Convert.ToInt32(0), new string[] { "DepartmentId" });
                if (values == null)
                    values = "0";
                Session["DepartmentId"] = values.ToString();
            }
        }

        protected void ASPxGridView1_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["DepartmentId"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
    }
}