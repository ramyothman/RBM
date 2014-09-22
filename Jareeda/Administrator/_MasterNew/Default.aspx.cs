using CommonWeb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator._MasterNew
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = 0;
        }

        public  string GetUserImage()
        {
            if (SecurityManager.getUser(this) == null) return "";
            return BusinessLogicLayer.Common.NewsImages + SecurityManager.getUser(this).PersonImage;
        }
    }
}