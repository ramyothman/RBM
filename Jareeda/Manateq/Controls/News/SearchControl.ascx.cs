using DevExpress.Web.ASPxDataView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class SearchControl : BaseControl
    {
        public new List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles
        {
            get
            {

                int id = 0;
                string code = Request["key"];
                if (string.IsNullOrEmpty(code))
                {
                    code = Page.RouteData.Values["key"].ToString();
                }
                if (Session["SearchArticles" + code] == null)
                {
                    List<BusinessLogicLayer.Entities.ContentManagement.Article> articles = BusinessLogicLayer.Common.ArticleLogic.FindArticles(BusinessLogicLayer.Common.DefaultLanguageId.ToString(), BusinessLogicLayer.Common.ManatiqID.ToString(), code);
                    Session["SearchArticles" + code] = articles;
                }
                return Session["SearchArticles" + code] as List<BusinessLogicLayer.Entities.ContentManagement.Article>;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDataControls();
        }

        
        List<HtmlGenericControl> containers = new List<HtmlGenericControl>();
        List<SectionItem> SectionItems = new List<SectionItem>();
        private void LoadDataControls()
        {
            descLength = 30;
            string code = Request["key"];
            if (string.IsNullOrEmpty(code))
            {
                code = Page.RouteData.Values["key"].ToString();
            }
            var sections = (from x in Articles select x.SectionName).Distinct();
            int itemid = 1;
            SectionItems.Clear();
            SectionItem item = new SectionItem();
            item.SectionName = " بحث:" + code;
            item.Articles = Articles;
            SectionItems.Add(item);
            MainBlockContainer.Controls.Add(GetDivContainer(item, itemid));
            MainBlockContainer.DataBind();
            itemid = 1;
            foreach (SectionItem section in SectionItems)
            {
                ASPxDataView dv = GetDataView(section, itemid);
                containers[itemid - 1].Controls.Add(dv);
                dv.ItemTemplate = new ListItemTemplate(Articles);
                dv.DataSource = Articles;
                dv.DataBind();
                itemid++;
            }
            //SectionsRepeater.DataSource = SectionItems;
            //SectionsRepeater.DataBind();
        }
        private HtmlGenericControl GetDivContainer(SectionItem section, int itemId)
        {
            HtmlGenericControl blockNews = new HtmlGenericControl("div");
            blockNews.ID = "blockNews" + section.GuidID;
            blockNews.Attributes.Add("class", "block-news mrg-top");
            HtmlGenericControl headControl = new HtmlGenericControl("div");
            headControl.ID = "headControl" + section.GuidID;
            headControl.Attributes.Add("class", "block-head");
            HtmlGenericControl h1Control = new HtmlGenericControl("h1");
            h1Control.ID = "h1Control" + section.GuidID;
            h1Control.InnerText = section.SectionName;
            headControl.Controls.Add(h1Control);
            blockNews.Controls.Add(headControl);

            HtmlGenericControl txtWrapper = new HtmlGenericControl("div");
            txtWrapper.ID = "txtWrapper" + section.GuidID;
            txtWrapper.Attributes.Add("class", "txt-wrapper clear");
            containers.Add(txtWrapper);
            blockNews.Controls.Add(txtWrapper);
            this.Controls.Add(blockNews);
            //this.Controls.Add(blockNews);
            return blockNews;
        }
        private ASPxDataView GetDataView(SectionItem item, int itemId)
        {
            ASPxDataView dv = new ASPxDataView();

            dv.ID = "DV_" + itemId;
            dv.Height = new Unit("100%");
            dv.Width = new Unit("100%");
            dv.ItemSpacing = new Unit("0px");
            dv.PagerSettings.EndlessPagingMode = DataViewEndlessPagingMode.OnClick;
            //dv.EnableCallbackAnimation = true;
            dv.ItemSpacing = new Unit("0px");
            //dv.EnableTheming = false;
            //dv.EnableDefaultAppearance = false;
            dv.Paddings.Padding = new Unit("0px");
            dv.ContentStyle.Paddings.Padding = new Unit("0px");
            dv.ItemStyle.Paddings.Padding = new Unit("0px");
            dv.ItemStyle.Height = new Unit("0px");
            dv.Theme = "Moderno";
            dv.PagerSettings.ShowMoreItemsText = "تحميل أكثر";
            dv.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
            dv.SettingsTableLayout.ColumnCount = 1;
            dv.SettingsTableLayout.RowsPerPage = 10;
            return dv;
        }

        class ListItemTemplate : ITemplate
        {
            public ListItemTemplate()
                : base()
            {

            }
            List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles = null;
            public ListItemTemplate(List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles)
                : base()
            {
                this.Articles = Articles;
            }
            public void InstantiateIn(Control container)
            {
                ListItemsControl control = container.TemplateControl.LoadControl("~/Controls/News/ListItemsControl.ascx") as ListItemsControl;
                control.Articles = Articles;
                container.Controls.Add(control);
            }
        }
    }
}