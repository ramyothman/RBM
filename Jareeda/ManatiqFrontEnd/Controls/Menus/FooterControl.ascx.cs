using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.Menus
{
    public partial class FooterControl : System.Web.UI.UserControl
    {
        List<BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem> menuList = new List<BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem>();
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                menuList = BusinessLogicLayer.Common.MenuEntityItemLogic.GetAllParentItemsForItemId(36);
                
                MainMenuRepeater.DataSource = menuList;
                MainMenuRepeater.DataBind();
                
            }
        }
        
        public string GetLink(int id)
        {
            //return "#";
            var item = (from x in menuList where x.MenuEntityItemId == id select x).FirstOrDefault();
            string result = "";
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.PagePath) && item.PagePath != "#")
                    result = item.PagePath;
            }
            return result;
        }
    }
}