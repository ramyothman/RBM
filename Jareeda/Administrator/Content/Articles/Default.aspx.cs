using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using Administrator.Code;
namespace Administrator.Content.Articles
{
    public partial class Default : AdminBasePage
    {

        Analytics.AnalyticsManager manager = new Analytics.AnalyticsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                SitePageGrid.DataBind();
                
                //List<BusinessLogicLayer.Entities.ContentManagement.Article> articles = SitePageGrid.DataSource as List<BusinessLogicLayer.Entities.ContentManagement.Article>;
                
                //metricTotalArticles.InnerText = SitePageGrid.VisibleRowCount.ToString();
                //var todayArticles = (from x in articles where x.PostDate.ToString("yyyy-MM-dd") == DateTime.Today.ToString("yyyy-MM-dd") select x);
                //metricTotalArticlesToday.InnerText = todayArticles.Count().ToString();
                //metricMinutes.InnerHtml = GetDate(DateTime.Now);
                try
                {
                    
                    
                }
                catch (Exception ex)
                {

                }
                
                //metricTodayVisits.InnerText = analytics.GetVisitsByPeriod(DateTime.Today, DateTime.Today).ToString();
                //metricArticleVisitsToday.InnerText = analytics.GetPageViewsByPeriod(DateTime.Today, DateTime.Today).ToString();
            }
        }

        
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Save.aspx?PageCode=0");
        }

        protected void SitePageGrid_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (!SitePageGrid.IsEditing || e.Column.FieldName != "SiteSectionId") return;
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
    }
}