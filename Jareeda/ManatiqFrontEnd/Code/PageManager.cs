using BusinessLogicLayer.Entities.ContentManagement;
using ManatiqFrontEnd.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
namespace ManatiqFrontEnd.Code
{
    public class PageManager
    {
        #region Enumerators
        public enum ControlType
        {
            Urgent = 2,
            MainNews = 3,
            ImportantNews = 4,
            ImageNews = 5,
            MultipleCategories = 6,
            News = 7,
            MostRead = 8,
            MostComments = 9,
            TitlePicture = 10,
            Columns = 12,
            Ads1 = 13,
            Ads2 = 14
        }

        public enum ControlPosition
        {
            
            Middle = 1,
            Left = 2,
            Right = 3,
            None = 4
        }
        #endregion

        #region Declarations
        System.Web.UI.HtmlControls.HtmlGenericControl CurrentContainer = null;
        ControlPosition CurrentPosition = ControlPosition.None;

        private System.Web.UI.WebControls.ContentPlaceHolder _Holders;
        public System.Web.UI.WebControls.ContentPlaceHolder Holders
        {
            set
            {
                _Holders = value;
            }
            get
            {
                return _Holders;
            }
        }

        private List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleType> _ContentModuleTypes = null;
        public List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleType> ContentModuleTypes
        {
            get
            {
                if (_ContentModuleTypes == null)
                {
                    _ContentModuleTypes = new BusinessLogicLayer.Components.ContentManagement.ContentModuleTypeLogic().GetAllBySiteID(BusinessLogicLayer.Common.ManatiqID);
                    if (_ContentModuleTypes == null)
                        _ContentModuleTypes = new List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleType>();
                }
                return _ContentModuleTypes;
            }
        }

        private List<BusinessLogicLayer.Entities.ContentManagement.Position> _Positions = null;
        public List<Position> Positions
        {
            get
            {
                if (_Positions == null)
                {
                    _Positions = new BusinessLogicLayer.Components.ContentManagement.PositionLogic().GetAllBySiteID(BusinessLogicLayer.Common.ManatiqID);
                    if (_Positions == null)
                        _Positions = new List<BusinessLogicLayer.Entities.ContentManagement.Position>();
                }
                return _Positions;
            }
        }

        private List<BusinessLogicLayer.Entities.ContentManagement.SitePageLayout> _PageLayouts = null;
        public List<SitePageLayout> PageLayouts
        {
            get
            {
                if (_PageLayouts == null)
                {
                    _PageLayouts = new BusinessLogicLayer.Components.ContentManagement.SitePageLayoutLogic().GetAllBySiteId(BusinessLogicLayer.Common.ManatiqID);
                    if (_PageLayouts == null)
                        _PageLayouts = new List<BusinessLogicLayer.Entities.ContentManagement.SitePageLayout>();
                }
                return _PageLayouts;
            }
        }

        #endregion

        #region Helper Methods
        private List<BusinessLogicLayer.Entities.ContentManagement.HomePage> GetHomePages(System.Web.UI.Page page, int SiteID)
        {
            List<BusinessLogicLayer.Entities.ContentManagement.HomePage> result = null;
            //BusinessLogicLayer.Entities.ContentManagement.Site site = BusinessLogicLayer.Common.SiteLogic.GetByID(SiteID);
            if (page.Session["HomePageModules"] == null)
            {
                result = new BusinessLogicLayer.Components.ContentManagement.HomePageLogic().GetAllBySiteID(SiteID);
            }
            else
            {
                result = page.Session["HomePageModules"] as List<BusinessLogicLayer.Entities.ContentManagement.HomePage>;
            }
            return result;
        }
        private BaseControl GetControlByID(System.Web.UI.Page page, int id)
        {
            BaseControl control = null;
            var con = (from x in ContentModuleTypes where x.ContentModuleTypeID == id select x).FirstOrDefault();
            if (con != null)
            {
                if (!string.IsNullOrEmpty(con.ControlPath))
                {
                    control = page.LoadControl(con.ControlPath) as BaseControl;
                }
            }
            
            return control;
        }
        private BaseControl GetControl(System.Web.UI.Page page, ControlType c)
        {
            BaseControl control = null;
            switch (c)
            {
                case ControlType.ImageNews:

                    control = page.LoadControl("~/Controls/News/Layout1News.ascx") as Controls.News.Layout1News;
                    break;
                case ControlType.ImportantNews:
                    control = page.LoadControl("~/Controls/News/ImportantNews.ascx") as Controls.News.ImportantNews;
                    break;
                case ControlType.MainNews:
                    //control = new Controls.News.MainNews();
                    control = page.LoadControl("~/Controls/News/MainNews.ascx") as Controls.News.MainNews;
                    break;
                case ControlType.MostComments:
                    break;
                case ControlType.MostRead:
                    break;
                case ControlType.MultipleCategories:
                    control = page.LoadControl("~/Controls/News/Layout2News.ascx") as Controls.News.Layout2News;
                    //control = new Controls.News.Layout2News();
                    break;
                case ControlType.News:
                    control = page.LoadControl("~/Controls/News/Layout3News.ascx") as Controls.News.Layout3News;
                    //control = new Controls.News.Layout3News();
                    break;
                case ControlType.TitlePicture:
                    break;
                case ControlType.Urgent:
                    control = page.LoadControl("~/Controls/News/Urgent.ascx") as Controls.News.Urgent;
                    //control = new Controls.News.Urgent();
                    break;
                case ControlType.Columns:
                    control = page.LoadControl("~/Controls/Columns/ColumnsControl.ascx") as Controls.Columns.ColumnsControl;
                    //control = new Controls.Columns.ColumnsControl();
                    break;
                case ControlType.Ads1:
                    control = page.LoadControl("~/Controls/Ads/Advertisement1.ascx") as Controls.Ads.Advertisement1;

                    break;
                case ControlType.Ads2:
                    control = page.LoadControl("~/Controls/Ads/Advertisement2.ascx") as Controls.Ads.Advertisement2;
                    break;
            }
            return control;
        }

        private System.Web.UI.HtmlControls.HtmlGenericControl GetContainerByPosition(int PositionID, string className, bool overrideClass)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            string classNameFinal = className;
            if (!overrideClass)
            {
                if (PositionID != 0)
                {
                    var con = (from x in Positions where x.PositionID == PositionID select x).FirstOrDefault();

                    if (con != null)
                    {
                        classNameFinal = con.Code;
                    }
                    if (!string.IsNullOrEmpty(classNameFinal))
                        control.Attributes.Add("class", classNameFinal);
                }
                else
                {
                    if (!string.IsNullOrEmpty(classNameFinal))
                        control.Attributes.Add("class", classNameFinal);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(classNameFinal))
                    control.Attributes.Add("class", classNameFinal);
            }
            return control;
        }

        public void AddControl(System.Web.UI.HtmlControls.HtmlGenericControl container, BusinessLogicLayer.Entities.ContentManagement.HomePage module, bool isFirst,bool isInternalBlock)
        {
            BaseControl control = GetControlByID(Holders.Page, module.ContentModuleTypeID);

            if (control != null)
            {
                control.IsInternalBlock = isInternalBlock;
                control.ModuleTitle = module.Title;
                control.HomePageID = module.HomePageID;
                control.SectionID = module.SectionID;
                control.IsFirst = isFirst;
                control.Attributes.Add("rel", module.HomePageID.ToString());
                //CurrentContainer = GetContainer((ControlPosition)module.PositionID, module.IsFullWidth);
                container.Controls.Add(control);
            }
        }
        #endregion

        #region Creating Page
        public void LoadControls(System.Web.UI.Page page, int SectionID,int PageType)
        {

            //List<BusinessLogicLayer.Entities.ContentManagement.HomePageGroup> HomePageGroup
            BusinessLogicLayer.Entities.ContentManagement.SitePageManager manager = BusinessLogicLayer.Common.SitePageManagerLogic.GetBySectionandTypeOrDefault(BusinessLogicLayer.Common.ManatiqID,SectionID, PageType);
            if (manager != null)
            {
                List<HomePageGroup> groups = BusinessLogicLayer.Common.HomePageGroupLogic.GetAllBySitePageManagerID(manager.SitePageManagerID);
                foreach (HomePageGroup hpgroup in groups)
                {

                    System.Web.UI.HtmlControls.HtmlGenericControl mainControl = GetContainerByPosition(0, hpgroup.GroupClass,false);
                    var layout = (from x in PageLayouts where x.SitePageLayoutID == hpgroup.SitePageLayoutID select x).FirstOrDefault();
                    string[] positionOrders = layout.PreviewCode.Split(';');
                    foreach(string pos in positionOrders)
                    {
                        string []posItems = pos.Split(',');
                        if (posItems.Length == 0) continue;
                        if(string.IsNullOrEmpty(posItems[0])) continue;
                        var items = from x in hpgroup.Widgets where x.PositionID == Convert.ToInt32(posItems[0]) orderby x.OrderNumber select x;
                        string className = "";
                        bool overrideClass = false;
                        if (posItems.Length > 1)
                        {
                            className = posItems[1];
                            overrideClass = true;
                        }
                        bool isInternalBlock = layout.PreviewClass != "block-1";
                        System.Web.UI.HtmlControls.HtmlGenericControl subContainer = GetContainerByPosition(Convert.ToInt32(posItems[0]), className,overrideClass);
                        bool isFirst = true;
                        foreach (HomePage widget in items)
                        {
                            AddControl(subContainer, widget,isFirst,isInternalBlock);
                            isFirst = false;
                        }

                        mainControl.Controls.Add(subContainer);
                    }
                    Holders.Controls.Add(mainControl);
                    mainControl.DataBind();
                    Holders.DataBind();
                }
            }
            //List<BusinessLogicLayer.Entities.ContentManagement.HomePage> result = GetHomePages(page, SiteID);
            
        }
        #endregion
    }
}