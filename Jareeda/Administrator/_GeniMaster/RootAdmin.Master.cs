using CommonWeb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator._GeniMaster
{
    public partial class RootAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(Request["logout"] == "true")
            //{
            //    SecurityManager.doLogout(this.Page);
                
            //}
            if (!IsPostBack) 
            {
                BuildMenu();
            }
        }

        public void BuildMenu()
        {
            BusinessLogicLayer.Entities.ContentManagement.MenuEntity menu = null;
            if (Session["menu"] != null)
                menu = (BusinessLogicLayer.Entities.ContentManagement.MenuEntity)Session["menu"];
            else
            {
                menu = BusinessLogicLayer.Common.MenuEntityLogic.GetAdminMenu();
                Session["menu"] = menu;
            }

            if(menu != null)
            {
                
                foreach(BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem item in menu.Items)
                {
                    DevExpress.Web.ASPxRibbon.RibbonTab tab = new DevExpress.Web.ASPxRibbon.RibbonTab(item.GetNameByLanguageId(Code.AdminBase.GetLanguageID(this.Page)));
                    
                    foreach (BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem itemGroup in item.ChildItems)
                    {
                        DevExpress.Web.ASPxRibbon.RibbonGroup group = new DevExpress.Web.ASPxRibbon.RibbonGroup(itemGroup.GetNameByLanguageId(Code.AdminBase.GetLanguageID(this.Page)));
                        foreach (BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem itemChild in itemGroup.ChildItems)
                        {
                            DevExpress.Web.ASPxRibbon.RibbonButtonItem button = new DevExpress.Web.ASPxRibbon.RibbonButtonItem();
                            button.Text = itemChild.GetNameByLanguageId(Code.AdminBase.GetLanguageID(this.Page));
                            button.LargeImage.Url = BusinessLogicLayer.Common.ConferenceContentPath + itemChild.IconPath;
                            if(itemChild.PagePath == "#ar")
                                button.NavigateUrl = Resources.ContentManagement.CultureLink;
                            else
                                button.NavigateUrl = itemChild.PagePath;
                            button.Size = DevExpress.Web.ASPxRibbon.RibbonItemSize.Large;
                            group.Items.Add(button);
                        }
                        tab.Groups.Add(group);
                    }
                    ribbon.Tabs.Add(tab);
                }
            }
            
        }
        public string GetName()
        {
            if (!SecurityManager.isLogged(this.Page))
                return "";
            return SecurityManager.getUser(this.Page).DisplayName;
        }
        public string GetUserImage()
        {
            if (SecurityManager.getUser(this.Page) == null) return "";
            return BusinessLogicLayer.Common.NewsImages + SecurityManager.getUser(this.Page).PersonImage;
        }
    }
}