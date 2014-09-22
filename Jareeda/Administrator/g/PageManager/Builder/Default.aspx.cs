using Administrator.Code;
using BusinessLogicLayer.Entities.ContentManagement.WebBuilder.JSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using BusinessLogicLayer.Entities.ContentManagement.WebBuilder;

namespace Administrator.g.PageManager.Builder
{
    public partial class Default : Code.AdminBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                hiddenJSONLoad.Add("JSONLayout", "");
                cmbPageType.DataBind();
                cmbPageType.SelectedIndex = 0;
            }
        }

        public string GetImagePath(string url)
        {
            string urlFinal = BusinessLogicLayer.Common.NewsImages + url;
            if (string.IsNullOrEmpty(url))
            {
                urlFinal = "/images/img-replacement.png";
            }
            return urlFinal;

        }

        protected void cmbSection_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            Session["HPDSiteId"] = e.Parameter;
            cmbSection.DataBind();
            cmbSection.Items.Insert(0, new DevExpress.Web.ASPxEditors.ListEditItem("", -1));
        }

        protected void cmbPosition_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            Session["HPDSiteId"] = e.Parameter;
            cmbPosition.DataBind();

        }

        protected void saveCallBack_CustomCallback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {

        }

        protected void saveCallBack_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();

            StringReader reader = new StringReader(e.Parameter);
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                List<GroupJSON> p = (List<GroupJSON>)serializer.Deserialize(jsonReader, typeof(List<GroupJSON>));
                if (p != null)
                {
                    bool isManagerSet = false;
                    BusinessLogicLayer.Entities.ContentManagement.SitePageManager manager = null;
                    foreach (GroupJSON group in p)
                    {
                        if (group.IsDeleted)
                            BusinessLogicLayer.Common.HomePageGroupLogic.Delete(group.ID);
                        else
                        {
                            if (!isManagerSet)
                            {
                                manager = new BusinessLogicLayer.Components.ContentManagement.SitePageManagerLogic().GetBySectionandType(group.SectionID, Convert.ToInt32(cmbPageType.Value));

                                if (manager == null)
                                {
                                    manager = new BusinessLogicLayer.Entities.ContentManagement.SitePageManager();
                                    manager.SectionID = group.SectionID;
                                    manager.SitePageTypeID = group.PageType;
                                }
                                manager.IsMain = group.IsMain;
                                if (manager.NewRecord)
                                    new BusinessLogicLayer.Components.ContentManagement.SitePageManagerLogic().Insert(manager);
                                else
                                    new BusinessLogicLayer.Components.ContentManagement.SitePageManagerLogic().Update(manager, manager.SitePageManagerID);
                                isManagerSet = true;
                            }
                            BusinessLogicLayer.Entities.ContentManagement.HomePageGroup hgroup = new BusinessLogicLayer.Entities.ContentManagement.HomePageGroup();
                            hgroup.GroupClass = group.GroupClass;
                            hgroup.GroupName = group.Name;
                            hgroup.SitePageManagerID = manager.SitePageManagerID;
                            hgroup.HomePageGroupID = group.ID;
                            hgroup.NewRecord = !group.OldGroup;
                            hgroup.SectionID = group.SectionID;
                            hgroup.SitePageLayoutID = group.LayoutID;
                            hgroup.OrderNumber = group.OrderNumber;
                            if (hgroup.NewRecord)
                            {
                                BusinessLogicLayer.Common.HomePageGroupLogic.Insert(hgroup);
                            }
                            else
                            {
                                BusinessLogicLayer.Common.HomePageGroupLogic.Update(hgroup, hgroup.HomePageGroupID);
                            }
                            string ids = "";
                            foreach (WidgetJSON widget in group.Widgets)
                            {

                                if (widget.IsDeleted)
                                    BusinessLogicLayer.Common.HomePageLogic.Delete(widget.ID);
                                else
                                {
                                    BusinessLogicLayer.Entities.ContentManagement.HomePage homePage = new BusinessLogicLayer.Entities.ContentManagement.HomePage();
                                    homePage.ContentModuleTypeID = widget.ContentModuleTypeID;
                                    homePage.HomePageGroupID = hgroup.HomePageGroupID;
                                    homePage.HomePageID = widget.ID;
                                    homePage.IsActive = widget.IsActive;
                                    homePage.IsFullWidth = widget.IsFullWidth;
                                    homePage.ItemsNumber = widget.ItemsNumber;

                                    homePage.ItemsPerPage = widget.ItemsPerPage;
                                    homePage.LanguageID = widget.LanguageID;
                                    homePage.OrderNumber = widget.OrderNumber;
                                    homePage.PositionID = widget.PositionID;
                                    homePage.SectionID = Convert.ToInt32(cmbSection.Value);
                                    homePage.SiteID = Convert.ToInt32(cmbSite.Value);
                                    homePage.NewRecord = !widget.OldGroup;
                                    homePage.Title = widget.Name;
                                    if (homePage.NewRecord)
                                        BusinessLogicLayer.Common.HomePageLogic.Insert(homePage);
                                    else
                                        BusinessLogicLayer.Common.HomePageLogic.Update(homePage, homePage.HomePageID);
                                    ids += homePage.HomePageID + ",";
                                }
                            }
                            if (ids.Length > 0)
                            {
                                ids = ids.Remove(ids.Length - 1, 1);
                                BusinessLogicLayer.Common.HomePageLogic.Delete(ids, hgroup.HomePageGroupID);
                            }
                        }

                    }
                }
            }
        }

        protected void loadCallBack_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            string result = "";
            string[] paramsList = e.Parameter.Split(',');
            string section = paramsList[0];
            string pageType = paramsList[1];
            BusinessLogicLayer.Entities.ContentManagement.SitePageManager manager = BusinessLogicLayer.Common.SitePageManagerLogic.GetBySectionandType(Convert.ToInt32(section), Convert.ToInt32(pageType));
            if (manager == null)
            {
                e.Result = result;
                return;
            }
            List<BusinessLogicLayer.Entities.ContentManagement.HomePageGroup> groups = BusinessLogicLayer.Common.HomePageGroupLogic.GetAllBySitePageManagerID(manager.SitePageManagerID);
            List<GroupJSON> groupJason = new List<GroupJSON>();
            var groupsOrdered = from x in groups orderby x.OrderNumber select x;
            bool isManagerSet = false;
            foreach (BusinessLogicLayer.Entities.ContentManagement.HomePageGroup group in groupsOrdered)
            {
                GroupJSON g = new GroupJSON();
                if (!isManagerSet)
                {
                    if (manager != null)
                    {
                        g.IsMain = manager.IsMain;
                        g.PageType = manager.SitePageTypeID;
                    }
                }

                g.GroupClass = group.GroupClass;
                g.ID = group.HomePageGroupID;
                g.IsDeleted = false;
                g.OldGroup = true;
                g.OrderNumber = group.OrderNumber;
                g.SectionID = group.SectionID;
                g.LayoutID = group.SitePageLayoutID;
                g.Name = group.GroupName;
                g.Widgets = new List<BusinessLogicLayer.Entities.ContentManagement.WebBuilder.WidgetJSON>();
                foreach (BusinessLogicLayer.Entities.ContentManagement.HomePage widget in group.Widgets)
                {
                    BusinessLogicLayer.Entities.ContentManagement.WebBuilder.WidgetJSON widgetJson = new WidgetJSON();
                    widgetJson.ContentModuleTypeID = widget.ContentModuleTypeID;

                    widgetJson.ID = widget.HomePageID;
                    widgetJson.IsActive = widget.IsActive;
                    widgetJson.IsFullWidth = widget.IsFullWidth;
                    widgetJson.ItemsNumber = widget.ItemsNumber;
                    widgetJson.ItemsPerPage = widget.ItemsPerPage;
                    widgetJson.LanguageID = widget.LanguageID;
                    widgetJson.OrderNumber = widget.OrderNumber;
                    widgetJson.PositionID = widget.PositionID;

                    BusinessLogicLayer.Entities.ContentManagement.ContentModuleType typeGroup = new BusinessLogicLayer.Components.ContentManagement.ContentModuleTypeLogic().GetByID(widgetJson.ContentModuleTypeID);
                    if (typeGroup != null)
                        widgetJson.ImagePath = GetImagePath(typeGroup.ImagePreview);
                    widgetJson.Name = widget.Title;
                    g.Widgets.Add(widgetJson);
                }

                groupJason.Add(g);
            }
            if (groupJason.Count() > 0)
            {
                result = JsonConvert.SerializeObject(groupJason);
            }
            e.Result = result;
        }

        protected void callbackPanelSettings_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {

        }
    }
}