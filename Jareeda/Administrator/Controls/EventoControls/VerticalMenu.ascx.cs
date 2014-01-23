using BusinessLogicLayer.Components.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
using DevExpress.Web.ASPxNavBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Controls.EventoControls
{
    public partial class VerticalMenu : System.Web.UI.UserControl
    {
        #region Declarations
        private List<MenuEntityItem> menuList;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Session["SelectedMenuGroup"] != null)
                    {
                        int groupId = 0;
                        Int32.TryParse(Session["SelectedMenuGroup"].ToString(), out groupId);
                        BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem item = BusinessLogicLayer.Common.MenuEntityItemLogic.GetByID(groupId);
                        if (item != null)
                        {
                            NavBarGroup group = new NavBarGroup(item.Name,item.Name);
                            LoadMenuItemDetails(item, group);
                            NavigationMenu.Groups.Add(group);
                        }
                    }
                }
            }
        }

        private void LoadMenuItemDetails(MenuEntityItem itemParent, NavBarGroup menuItemParent)
        {

            List<MenuEntityItem> details = new MenuEntityItemLogic().GetAllByParent(itemParent.MenuEntityItemId);
            foreach (MenuEntityItem item in details)
            {
                NavBarItem menuItem = new NavBarItem();
                menuItem.Text = item.Name;
                if (!string.IsNullOrEmpty(item.PagePath) && item.PagePath != "#")
                    menuItem.NavigateUrl = item.PagePath;
                menuItemParent.Items.Add(menuItem);
            }
        }

        public int GroupParentId
        {
            set { this.Page.Session["SelectedMenuGroup"] = value; }
            get { return this.Page.Session["SelectedMenuGroup"] == null ? 0 : Convert.ToInt32(this.Page.Session["SelectedMenuGroup"]); }
        }
    }
}