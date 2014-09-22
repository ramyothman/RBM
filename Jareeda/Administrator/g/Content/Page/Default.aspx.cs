using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.g.Content.Page
{
    public partial class Default : Code.AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            AddGridExporter(grid);
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

        protected void SitePageGrid_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (!grid.IsEditing || e.Column.FieldName != "SectionId") return;
            if (e.KeyValue == DBNull.Value || e.KeyValue == null) return;
            object val = grid.GetRowValuesByKeyValue(e.KeyValue, "SiteId");
            if (val == DBNull.Value) return;
            string country = (string)val;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            FillSectionCombo(combo, country);

            combo.Callback += new CallbackEventHandlerBase(cmbSection_OnCallback);

        }
        #endregion

        #region Export
        protected void Exportexcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel("pages");
        }

        protected void ExportWord_Click(object sender, EventArgs e)
        {
            ExportGridToWord("pages");
        }

        protected void ExportPDF_Click(object sender, EventArgs e)
        {
            ExportGridToPDF("pages");
        }
        #endregion


        #region Methods
        protected void FillSectionCombo(ASPxComboBox cmb, string country)
        {
            if (string.IsNullOrEmpty(country)) return;
            SectionObjectDS.SelectParameters[0].DefaultValue = country;
            cmb.DataBind();

        }
        private void cmbSection_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillSectionCombo(source as ASPxComboBox, e.Parameter);
        }
        #endregion
    }
}