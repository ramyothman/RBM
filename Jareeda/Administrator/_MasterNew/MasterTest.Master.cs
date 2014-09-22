using CommonWeb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator._MasterNew
{
    public partial class MasterTest : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetUserImage()
        {
            if (SecurityManager.getUser(this.Page) == null) return "";
            return BusinessLogicLayer.Common.NewsImages + SecurityManager.getUser(this.Page).PersonImage;
        }
    }
}