using Administrator.Code;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.ContentManagement.Home.HomePage
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object values = SourcesGrid.GetRowValues(Convert.ToInt32(0), new string[] { "HomePageID" });
                if (values == null)
                    values = "0";
                Session["HPHomePageID"] = values.ToString();
            }
        }

        protected void SourcesGrid_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (!SourcesGrid.IsNewRowEditing && !SourcesGrid.IsEditing) return;
            if (e.Column.FieldName != "SectionID" && e.Column.FieldName != "ContentModuleTypeID" && e.Column.FieldName != "PositionID") return;
            int site = 0;
            if (e.KeyValue != DBNull.Value && e.KeyValue != null)
            {
                object val = SourcesGrid.GetRowValuesByKeyValue(e.KeyValue, "SiteID");
                if (val == DBNull.Value) return;
                site = (int)val;
            }
            
            ASPxComboBox combo = e.Editor as ASPxComboBox;
            if (e.Column.FieldName == "SectionID")
            {                
                FillSectionCombo(combo, site.ToString());
                combo.Callback += new CallbackEventHandlerBase(cmbSection_OnCallback);
            }
            if (e.Column.FieldName == "ContentModuleTypeID")
            {
                FillModuleTypeCombo(combo, site.ToString());
                combo.Callback += new CallbackEventHandlerBase(cmbModuleType_OnCallback);
            }
            if (e.Column.FieldName == "PositionID")
            {
                FillPositionCombo(combo, site.ToString());
                combo.Callback += new CallbackEventHandlerBase(cmbPosition_OnCallback);
            }
            //FillModuleTypeCombo(combo, site);
            //FillPositionCombo(combo, site);

            
        }

        protected void FillSectionCombo(ASPxComboBox cmb, string SiteID)
        {
            if (SiteID == "0") return;
            cmb.DataSourceID = "ObjectDataSourceSection";
            ObjectDataSourceSection.SelectParameters[0].DefaultValue = SiteID;
            cmb.DataBindItems();
            cmb.Items.Insert(0, new ListEditItem("", null)); // Null Item
        }

        protected void FillModuleTypeCombo(ASPxComboBox cmb, string SiteID)
        {
            if (SiteID == "0") return;
            cmb.DataSourceID = "ObjectDataSourceModuleType";
            ObjectDataSourceModuleType.SelectParameters[0].DefaultValue = SiteID;
            cmb.DataBindItems();
            cmb.Items.Insert(0, new ListEditItem("", null)); // Null Item
        }

        protected void FillPositionCombo(ASPxComboBox cmb, string SiteID)
        {
            if (SiteID == "0") return;
            cmb.DataSourceID = "ObjectDataSourcePosition";
            ObjectDataSourcePosition.SelectParameters[0].DefaultValue = SiteID;
            cmb.DataBindItems();
            cmb.Items.Insert(0, new ListEditItem("", null)); // Null Item
        }

        void cmbSection_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillSectionCombo(source as ASPxComboBox, e.Parameter);
        }
        void cmbModuleType_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillModuleTypeCombo(source as ASPxComboBox, e.Parameter);
        }
        void cmbPosition_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillPositionCombo(source as ASPxComboBox, e.Parameter);
        }

        

        protected void gridViewArticles_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            
        }


        protected void gridViewHomePageArticles_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["HPHomePageID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        //protected void gridViewHomePageArticles_BeforePerformDataSelect(object sender, EventArgs e)
        //{
        //    Session["HPHomePageID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        //}

        protected void articleCallbackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            string[] splits = e.Parameter.Split(',');
            //Session["ArSiteID"] = splits[0];
            //Session["ArSectionID"] = splits[1];
            //Session["ArTypeID"] = splits[2];
            ObjectDataSourceArticles.SelectParameters[0].DefaultValue = splits[0];
            ObjectDataSourceArticles.SelectParameters[1].DefaultValue = splits[1];
            ObjectDataSourceArticles.SelectParameters[2].DefaultValue = "";
            gridViewArticles.DataBind();
        }

        protected void gridViewHomePageArticles_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            
            //string str = e.NewValues[1].ToString();
            //string[] split = str.Split('-');
            //if (split.Length <= 1)
            //    e.Cancel = true;
            //e.NewValues[1] = split[0];
        }

        protected void gridViewHomePageArticles_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            //if (e.NewValues[1].ToString() == "Select Article")
            //    e.Cancel = true;
            //string str = e.NewValues[1].ToString();
            //string[] split = str.Split('-');
            
            //e.NewValues[1] = split[0];
        }

        protected void comboSection_Callback(object sender, CallbackEventArgsBase e)
        {
            FillSectionCombo((ASPxComboBox)sender, e.Parameter);
        }
    }
}