using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Entities.ContentManagement;
using System.Linq;
using BusinessLogicLayer.Components.ContentManagement;
namespace Administrator._MasterPages
{
    public partial class RootAdmin : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Page.Theme = "EventoAdmin";
        }

        public int SelectedMenuItemId
        {
            get
            {
                return MainMenuControl1.SelectedGroupId;
            }
        }
        
    }
}