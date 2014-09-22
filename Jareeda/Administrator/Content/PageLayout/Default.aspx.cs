using Administrator.Code;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Content.PageLayout
{
    public partial class Default : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void SitePageGrid_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (!SitePageGrid.IsEditing || e.Column.FieldName != "SectionId") return;
            if (e.KeyValue == DBNull.Value || e.KeyValue == null) return;
            object val = SitePageGrid.GetRowValuesByKeyValue(e.KeyValue, "SiteId");
            if (val == DBNull.Value) return;
            string country = (string)val;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            FillSectionCombo(combo, country);

            combo.Callback += new CallbackEventHandlerBase(cmbSection_OnCallback);

        }

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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Save.aspx?PageCode=0");
        }
    }
}