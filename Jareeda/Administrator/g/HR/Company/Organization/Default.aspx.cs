using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.g.HR.Company.Organization
{
    public partial class Default : Code.AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            AddGridExporter(grid);
            if (!IsPostBack)
            {
                object values = grid.GetRowValues(Convert.ToInt32(0), new string[] { "OrganizationId" });
                if (values == null)
                    values = "0";
                Session["OrganizationId"] = values.ToString();
            }
        }

        #region GridEvents
        protected void grid_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            if (e.Exception == null)
            {
                ((DevExpress.Web.ASPxGridView.ASPxGridView)sender).JSProperties["cp_Arg"] = "Inserted";
            }

        }

        protected void grid_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            if (e.Exception == null)
            {
                ((DevExpress.Web.ASPxGridView.ASPxGridView)sender).JSProperties["cp_Arg"] = "Updated";
            }

        }

        protected void grid_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                ((DevExpress.Web.ASPxGridView.ASPxGridView)sender).JSProperties["cp_Arg"] = "Deleted";
            }
        }
        protected void OrganizationLanguagesGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["OrganizationId"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        #endregion

        #region Export
        protected void Exportexcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel("organization");
        }

        protected void ExportWord_Click(object sender, EventArgs e)
        {
            ExportGridToWord("organization");
        }

        protected void ExportPDF_Click(object sender, EventArgs e)
        {
            ExportGridToPDF("organization");
        }
        #endregion
    }
}