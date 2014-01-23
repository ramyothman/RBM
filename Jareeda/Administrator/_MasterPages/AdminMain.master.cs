using Administrator.Code;
using CommonWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator._MasterPages
{
    public partial class AdminMain : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (AdminBasePage page = this.Page as AdminBasePage)
                {
                    if (page == null) return;
                    if (page.PageType == AdminBasePageType.Manage)
                    {
                        Administrator.Controls.EventoControls.VerticalMenu menu = new Controls.EventoControls.VerticalMenu();
                        LeftSectionServerDiv.Controls.Add(menu);
                        menu.GroupParentId = (this.Master as RootAdmin).SelectedMenuItemId;
                        
                    }
                }
            }
        }
    }
}