using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Web.ASPxDataView;
using System.Data;
using System.Web.UI.HtmlControls;
namespace ManatiqFrontEnd.Controls.News
{
    public class SectionItem
    {
        private string _GuidID;
        private string _SectionName;

        public string GuidID
        {
            get
            {
                if (string.IsNullOrEmpty(_GuidID))
                {
                    _GuidID = Guid.NewGuid().ToString();
                }
                return _GuidID;
            }
        }
        public string SectionName
        {
            set { _SectionName = value; }
            get { return _SectionName; }
        }
        public List<BusinessLogicLayer.Entities.ContentManagement.Article> _Articles = null;
        public List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles
        {
            set { _Articles = value; }
            get { return _Articles; }
        }
    }
    public partial class List : BaseControl
    {
        
        List<SectionItem> SectionItems = new List<SectionItem>();
        public List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles
        {
            get
            {

                string code = Request["sections"];
                if (string.IsNullOrEmpty(code))
                {
                    code = Page.RouteData.Values["sections"].ToString();
                }
                if (Session["Articles" + code] == null)
                {   
                    List<BusinessLogicLayer.Entities.ContentManagement.Article> articles = BusinessLogicLayer.Common.ArticleLogic.FindArticlesBySection(BusinessLogicLayer.Common.DefaultLanguageId.ToString(), BusinessLogicLayer.Common.ManatiqID.ToString(), code);
                    Session["Articles" + code] = articles;
                }
                return Session["Articles" + code] as List<BusinessLogicLayer.Entities.ContentManagement.Article>;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                LoadDataControls();
                //ImportantNewsRepeater.ItemTemplate = new ListItemTemplate(Articles);
                //ImportantNewsRepeater.DataSource = Articles;
                //ImportantNewsRepeater.DataBind();
            }
            if (this.Page.IsCallback)
            {
                //ImportantNewsRepeater.DataSource = Articles;
                //ImportantNewsRepeater.DataBind();
            }
        }

        private void LoadDataControls()
        {
            descLength = 30;
            string code = Request["sections"];
            if (string.IsNullOrEmpty(code))
            {
                code = Page.RouteData.Values["sections"].ToString();
            }
            var sections = (from x in Articles select x.SectionName).Distinct();
            int itemid = 1;
            foreach (string section in sections)
            {
                SectionItem item = new SectionItem();
                item.SectionName = section;
                item.Articles = (from x in Articles where x.SectionName == section select x).ToList();
                SectionItems.Add(item);
                MainContainer.Controls.Add(GetDivContainer(item,itemid));
                MainContainer.DataBind();
                itemid++;
            }
            itemid = 1;
            foreach (SectionItem section in SectionItems)
            {
                ASPxDataView dv = GetDataView(section, itemid);
                containers[itemid - 1].Controls.Add(dv);
                dv.ItemTemplate = new ListItemTemplate(Articles);
                dv.DataSource = (from x in Articles where x.SectionName == section.SectionName select x).ToList();
                dv.DataBind();
                itemid++;
            }
            //SectionsRepeater.DataSource = SectionItems;
            //SectionsRepeater.DataBind();
        }
        List<HtmlGenericControl> containers = new List<HtmlGenericControl>();
        private HtmlGenericControl LoadContainers(SectionItem item)
        {
            HtmlGenericControl blockNews = new HtmlGenericControl("div");
            blockNews.ID = "blockNews" + item.GuidID;
            blockNews.Attributes.Add("class", "block-news mrg-top");
            HtmlGenericControl headControl = new HtmlGenericControl("div");
            headControl.ID = "headControl" + item.GuidID;
            headControl.Attributes.Add("class", "block-head");
            HtmlGenericControl h1Control = new HtmlGenericControl("h1");
            h1Control.ID = "h1Control" + item.GuidID;
            h1Control.InnerText = item.SectionName;
            headControl.Controls.Add(h1Control);
            blockNews.Controls.Add(headControl);

            HtmlGenericControl txtWrapper = new HtmlGenericControl("div");
            txtWrapper.ID = "txtWrapper" + item.GuidID;
            txtWrapper.Attributes.Add("class", "txt-wrapper clear");
            containers.Add(txtWrapper);
            blockNews.Controls.Add(txtWrapper);
            return blockNews;
        }
        private HtmlGenericControl GetDivContainer(SectionItem section,int itemId)
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
            txtWrapper.Attributes.Add("class","txt-wrapper clear");
            containers.Add(txtWrapper);
            blockNews.Controls.Add(txtWrapper);
            this.Controls.Add(blockNews);
            //this.Controls.Add(blockNews);
            return blockNews;
        }

        private ASPxDataView GetDataView(SectionItem item,int itemId)
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
            public ListItemTemplate() :base()
            {

            }
            List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles = null;
            public ListItemTemplate(List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles) : base()
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

        protected void ImportantNewsRepeater_CustomCallback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {

        }

        protected void SectionsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            if ( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl p = e.Item.FindControl("myPanel") as System.Web.UI.HtmlControls.HtmlGenericControl;
                if (p != null)
                {
                    ASPxDataView dv = new ASPxDataView();
                    var y = e.Item.DataItem as DataRowView;
                    dv.ID = "DV_" + SectionItems[e.Item.ItemIndex].SectionName.Replace(" ", "_").Replace("-", "_").Replace("!","").Replace("?","");
                    p.Controls.Add(dv);
                    dv.Height = new Unit("100%");
                    dv.Width = new Unit("100%");
                    dv.PagerSettings.EndlessPagingMode = DataViewEndlessPagingMode.OnScroll;
                    dv.EnableCallbackAnimation = true;
                    dv.ItemSpacing = new Unit("0px");
                    dv.ItemTemplate = new ListItemTemplate(Articles);
                    dv.SettingsTableLayout.ColumnCount = 1;
                    dv.SettingsTableLayout.RowsPerPage = 10;
                    p.DataBind();
                    dv.DataSource = (from x in Articles where x.SectionName == SectionItems[e.Item.ItemIndex].SectionName select x).ToList();
                    dv.DataBind();
                }
            }
            
            
        }

        
    }




}