using BusinessLogicLayer.Components.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Controls.EventoControls
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        #region Declarations
        private List<MenuEntityItem> menuList;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Contains("ar"))
                {
                    menuList = new MenuEntityItemLogic().GetAllParentItemsForItemId(88);
                }
                else
                {
                    menuList = new MenuEntityItemLogic().GetAllParentItemsForItemId(Convert.ToInt32(BusinessLogicLayer.Common.AdminMenu));
                }
                foreach (MenuEntityItem item in menuList)
                {
                    DevExpress.Web.ASPxMenu.MenuItem menuItem = new DevExpress.Web.ASPxMenu.MenuItem();
                    
                    menuItem.Text = item.Name;
                    menuItem.Name = item.MenuEntityItemId.ToString();
                    if (!string.IsNullOrEmpty(item.PagePath) && item.PagePath != "#")
                        menuItem.NavigateUrl = item.PagePath;
                    LoadMenuItemDetails(item, menuItem);
                    dxMainMenu.Items.Add(menuItem);
                }
            }
        }

        private void LoadMenuItemDetails(MenuEntityItem itemParent, DevExpress.Web.ASPxMenu.MenuItem menuItemParent)
        {

            List<MenuEntityItem> details = new MenuEntityItemLogic().GetAllByParent(itemParent.MenuEntityItemId);
            foreach (MenuEntityItem item in details)
            {
                DevExpress.Web.ASPxMenu.MenuItem menuItem = new DevExpress.Web.ASPxMenu.MenuItem();
                menuItem.Text = item.Name;
                menuItem.Name = item.MenuEntityItemId.ToString();
                if (!string.IsNullOrEmpty(item.PagePath) && item.PagePath != "#")
                    menuItem.NavigateUrl = item.PagePath;
                menuItemParent.Items.Add(menuItem);
            }
        }

        protected void dxMainMenu_ItemClick(object source, DevExpress.Web.ASPxMenu.MenuItemEventArgs e)
        {
            if (e.Item.Parent == null)
                Session["SelectedMenuGroup"] = e.Item.Name;
            else
                Session["SelectedMenuGroup"] =  e.Item.Parent.Name;
           
        }

        public int SelectedGroupId
        {
            get
            {
                int selectedId = 0;
                if (dxMainMenu.SelectedItem == null) return selectedId;
                if (dxMainMenu.SelectedItem.Parent != null)
                    if (dxMainMenu.SelectedItem.Parent.Parent != null)
                    {
                        Int32.TryParse(dxMainMenu.SelectedItem.Parent.Parent.Name, out selectedId);
                    }
                    else
                        Int32.TryParse(dxMainMenu.SelectedItem.Parent.Name, out selectedId);
                else
                    Int32.TryParse(dxMainMenu.SelectedItem.Name, out selectedId);
                return selectedId;
            }
        }


    }
}