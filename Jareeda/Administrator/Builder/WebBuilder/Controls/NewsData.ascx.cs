using DevExpress.Web.ASPxClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Builder.WebBuilder.Controls
{
    public partial class NewsData : BaseBuilderControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

        protected void callbackPanelSettings_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            int x = 0;
            Int32.TryParse(e.Parameter, out x);
            if (x <= 0)
                pageControlMain.Visible = false;
            Session["HPHomePageID"] = e.Parameter;
            gridViewHomePageArticles.DataBind();
            moduleSectionGrid.DataBind();
            
        }

        protected void comboSection_Callback(object sender, CallbackEventArgsBase e)
        {
            //FillSectionCombo((ASPxComboBox)sender, e.Parameter);
        }

        protected void gridViewArticles_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {

        }
    }
}