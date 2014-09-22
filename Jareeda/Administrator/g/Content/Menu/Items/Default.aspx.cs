using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.g.Content.Menu.Items
{
    public partial class Default : Code.AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            AddTreeExporter(tree);
            if(!IsPostBack)
            {
                int id = 0;
                Int32.TryParse(Request["Code"], out id);
                BusinessLogicLayer.Entities.ContentManagement.MenuEntity menu = BusinessLogicLayer.Common.MenuEntityLogic.GetByID(id);
                if (menu != null)
                {
                    MenuManagerTitle.InnerText = String.Format("{0} : {1}", Resources.ContentManagement.MenuManagerTitle, menu.MenuName);
                }
                else
                {
                    MenuManagerTitle.InnerText = Resources.ContentManagement.MenuManagerTitle;
                }
            }
        }

        #region Export
        protected void Exportexcel_Click(object sender, EventArgs e)
        {
            ExportTreeToExcel("menu items");
        }

        protected void ExportWord_Click(object sender, EventArgs e)
        {
            ExportTreeToWord("menu items");
        }

        protected void ExportPDF_Click(object sender, EventArgs e)
        {
            ExportTreeToPDF("menu items");
        }
        #endregion

        protected void tree_NodeDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                ((DevExpress.Web.ASPxTreeList.ASPxTreeList)sender).JSProperties["cp_Arg"] = "Deleted";
            }
        }

        protected void grid_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            Session["MenuLanguageParentID"] = e.Parameters;
            grid.DataBind();
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
        #endregion
    }
}