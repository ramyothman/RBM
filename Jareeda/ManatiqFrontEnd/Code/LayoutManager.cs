using ManatiqFrontEnd.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Linq.Expressions;
namespace ManatiqFrontEnd.Code
{
    public class LayoutManager
    {
        
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
            None = 0,
            Middle = 1,
            Left = 2,
            Right = 3,
            Top = 4
        }

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
        private BaseControl GetControl(System.Web.UI.Page page,ControlType c)
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
        System.Web.UI.HtmlControls.HtmlGenericControl CurrentContainer = null;
        ControlPosition CurrentPosition = ControlPosition.None;
        private System.Web.UI.HtmlControls.HtmlGenericControl GetContainer(ControlPosition position,bool isFullWidth)
        {
            
            System.Web.UI.HtmlControls.HtmlGenericControl control = null;
            if (position == ControlPosition.None)
            {
                CurrentPosition = position;
                control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                control.Attributes.Add("class", "block-2");
                CurrentContainer = control;
            }
            if (CurrentContainer != null && CurrentPosition == position)
            {
                control = CurrentContainer;
            }
            else if (CurrentContainer == null && !isFullWidth)
            {
                switch (position)
                {
                    case ControlPosition.Left:
                        control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        control.Attributes.Add("class", "aside");
                        break;
                    case ControlPosition.Right:
                        control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        control.Attributes.Add("class", "wrapper");
                        break;
                    case ControlPosition.Top:
                        break;
                    case ControlPosition.Middle:
                        //control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        //control.Attributes.Add("class", "block-1");
                        break;
                }
                CurrentContainer = control;
            }
            else if (isFullWidth)
                CurrentContainer = null;
            else if (CurrentContainer != null)
                control = CurrentContainer;

            CurrentPosition = position;
            return control;
        }
        public void AddControl(System.Web.UI.HtmlControls.HtmlGenericControl container, BusinessLogicLayer.Entities.ContentManagement.HomePage module,bool isFirst)
        {
            BaseControl control = GetControl(Holders.Page,(ControlType)module.ContentModuleTypeID);

            if (control != null)
            {
                control.ModuleTitle = module.Title;
                control.HomePageID = module.HomePageID;
                control.SectionID = module.SectionID;
                control.IsFirst = isFirst;
                //CurrentContainer = GetContainer((ControlPosition)module.PositionID, module.IsFullWidth);
                container.Controls.Add(control);
            }
        }
        public void AddClass(string className, ControlType c)
        {

        }

        private System.Web.UI.HtmlControls.HtmlGenericControl GetContainer(ControlPosition position)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl control = null;
            switch (position)
            {
                case ControlPosition.None:
                        control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        control.Attributes.Add("class", "block-2");
                        break;
                case ControlPosition.Left:
                        control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        control.Attributes.Add("class", "aside");
                        break;
                case ControlPosition.Right:
                        control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        control.Attributes.Add("class", "wrapper");
                    break;
                case ControlPosition.Top:
                    break;
                case ControlPosition.Middle:
                    //control = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    //control.Attributes.Add("class", "block-1");
                    break;
            }
            return control;
        }

        public void LoadControls(System.Web.UI.Page page, int SiteID)
        {
            
            List<BusinessLogicLayer.Entities.ContentManagement.HomePage> result = GetHomePages(page, SiteID);
            var centerResults = from x in result where x.IsActive && x.IsFullWidth orderby x.OrderNumber select x;
            bool isAdded = false;
            bool isBlock1 = false;
            bool isFirst = true;
            if (centerResults != null && centerResults.Count() > 0)
            {
                
                int lastModuleOrder = 0;
                
                
                foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage module in centerResults)
                {
                    var rightSide = from x in result where x.OrderNumber < module.OrderNumber && x.OrderNumber > lastModuleOrder && x.PositionID == (int)ControlPosition.Right && x.IsActive orderby x.OrderNumber select x;
                    var leftSide = from x in result where x.OrderNumber < module.OrderNumber && x.OrderNumber > lastModuleOrder && x.PositionID == (int)ControlPosition.Left && x.IsActive orderby x.OrderNumber select x;
                    
                    if (rightSide.Count() > 0 || leftSide.Count() > 0)
                    {
                        
                        System.Web.UI.HtmlControls.HtmlGenericControl mainControl = GetContainer(ControlPosition.None, false);
                        CurrentContainer = mainControl;
                        isFirst = true;
                        foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage moduleRight in rightSide)
                        {
                            CurrentContainer = GetContainer((ControlPosition)moduleRight.PositionID, moduleRight.IsFullWidth);
                            if(!isBlock1)
                                isBlock1 = ((ControlType)moduleRight.ContentModuleTypeID) == ControlType.MainNews;
                            if (CurrentContainer != mainControl && !isAdded)
                            {
                                mainControl.Controls.Add(CurrentContainer);
                                isAdded = true;
                            }
                            AddControl(CurrentContainer, moduleRight,isFirst);
                            isFirst = false;
                        }
                        isAdded = false;
                        isFirst = true;
                        System.Web.UI.HtmlControls.HtmlGenericControl leftContainer = GetContainer(ControlPosition.Left, false);
                        bool isLeftAdded = false;
                        foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage moduleLeft in leftSide)
                        {
                            leftContainer = GetContainer((ControlPosition)moduleLeft.PositionID, moduleLeft.IsFullWidth);
                            if (!isBlock1)
                                isBlock1 = ((ControlType)moduleLeft.ContentModuleTypeID) == ControlType.MainNews;
                            if (!isLeftAdded)
                            {
                                mainControl.Controls.Add(leftContainer);
                                isLeftAdded = true;
                            }
                            AddControl(leftContainer, moduleLeft, isFirst);
                            isFirst = false;
                        }
                        isAdded = false;
                        isFirst = true;
                        if (isBlock1)
                        {
                            mainControl.Attributes.Remove("class");
                            mainControl.Attributes.Add("class", "block-1");
                            isBlock1 = false;
                        }
                        Holders.Controls.Add(mainControl);
                    }
                    BaseControl control = GetControl(page,(ControlType)module.ContentModuleTypeID);

                    if (control != null)
                    {
                        control.ModuleTitle = module.Title;
                        control.HomePageID = module.HomePageID;
                        control.SectionID = module.SectionID;
                        CurrentContainer = GetContainer((ControlPosition)module.PositionID, module.IsFullWidth);
                        Holders.Controls.Add(control);
                    }
                    lastModuleOrder = module.OrderNumber;
                }
                var rightSideLast = from x in result where x.OrderNumber > lastModuleOrder && x.PositionID == (int)ControlPosition.Right && x.IsActive orderby x.OrderNumber select x;
                var leftSideLast = from x in result where x.OrderNumber > lastModuleOrder && x.PositionID == (int)ControlPosition.Left && x.IsActive orderby x.OrderNumber select x;
                System.Web.UI.HtmlControls.HtmlGenericControl mainControlLast  = GetContainer(ControlPosition.None, false);
                CurrentContainer = mainControlLast;
                isFirst = true;
                foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage moduleRight in rightSideLast)
                {
                    CurrentContainer = GetContainer((ControlPosition)moduleRight.PositionID, moduleRight.IsFullWidth);
                    if (!isBlock1)
                        isBlock1 = ((ControlType)moduleRight.ContentModuleTypeID) == ControlType.MainNews;
                    if (CurrentContainer != mainControlLast && !isAdded)
                    {
                        mainControlLast.Controls.Add(CurrentContainer);
                        isAdded = true;
                    }
                    AddControl(CurrentContainer, moduleRight,isFirst);
                    isFirst = false;
                }
                isAdded = false;
                isFirst = true;
                System.Web.UI.HtmlControls.HtmlGenericControl lastLeftContainer = GetContainer(ControlPosition.Left, false);
                bool isLastLeftAdded = false;
                foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage moduleLeft in leftSideLast)
                {
                    lastLeftContainer = GetContainer((ControlPosition)moduleLeft.PositionID, moduleLeft.IsFullWidth);
                    if (!isBlock1)
                        isBlock1 = ((ControlType)moduleLeft.ContentModuleTypeID) == ControlType.MainNews;
                    if (!isLastLeftAdded)
                    {
                        mainControlLast.Controls.Add(lastLeftContainer);
                        isLastLeftAdded = true;
                    }
                    AddControl(lastLeftContainer, moduleLeft, isFirst);
                    isFirst = false;
                }
                if (isBlock1)
                {
                    mainControlLast.Attributes.Remove("class");
                    mainControlLast.Attributes.Add("class", "block-1");
                    isBlock1 = false;
                }
                Holders.Controls.Add(mainControlLast);

            }
            else
            {
                var rightSide = from x in result where x.PositionID == (int)ControlPosition.Right && x.IsActive orderby x.OrderNumber select x;
                var leftSide = from x in result where x.PositionID == (int)ControlPosition.Left && x.IsActive orderby x.OrderNumber select x;
                System.Web.UI.HtmlControls.HtmlGenericControl mainControl = GetContainer(ControlPosition.None, false);
                CurrentContainer = mainControl;
                isAdded = false;
                isFirst = true;
                foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage module in rightSide)
                {
                    CurrentContainer = GetContainer((ControlPosition)module.PositionID, module.IsFullWidth);
                    if (!isBlock1)
                        isBlock1 = ((ControlType)module.ContentModuleTypeID) == ControlType.MainNews;
                    if (CurrentContainer != mainControl && !isAdded)
                    {
                        mainControl.Controls.Add(CurrentContainer);
                        isAdded = true;
                    }
                    AddControl(CurrentContainer, module,isFirst);
                    isFirst = false;
                }
                isAdded = false;
                isFirst = true;
                System.Web.UI.HtmlControls.HtmlGenericControl leftContainer = GetContainer(ControlPosition.Left, false);
                bool isLeftAdded = false;
                foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage module in leftSide)
                {
                    leftContainer = GetContainer((ControlPosition)module.PositionID, module.IsFullWidth);
                    if (!isBlock1)
                        isBlock1 = ((ControlType)module.ContentModuleTypeID) == ControlType.MainNews;
                    if (!isLeftAdded)
                    {
                        mainControl.Controls.Add(leftContainer);
                        isLeftAdded = true;
                    }
                    AddControl(leftContainer, module, isFirst);
                    isFirst = false;
                }
                isAdded = false;
                if (isBlock1)
                {
                    mainControl.Attributes.Remove("class");
                    mainControl.Attributes.Add("class", "block-1");
                    isBlock1 = false;
                }
                Holders.Controls.Add(mainControl);
            }
            foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage module in result)
            {
                BaseControl control = GetControl(page,(ControlType)module.ContentModuleTypeID);
                if (control != null)
                {
                    control.ModuleTitle = module.Title;
                    control.HomePageID = module.HomePageID;
                    control.SectionID = module.SectionID;
                }
            }
        }

        public void LoadAllControls(System.Web.UI.Page page, int SiteID)
        {

        }

        #region Session Management

        public List<BusinessLogicLayer.Entities.ContentManagement.HomePage> GetHomePages(System.Web.UI.Page page,int SiteID)
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

        #endregion
    }
}