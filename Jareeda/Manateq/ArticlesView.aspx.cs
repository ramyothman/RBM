using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd
{
    public partial class ArticlesView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int secId = 0;
            Int32.TryParse(Request["code"], out secId);
            if (secId != 0)
            {
                BusinessLogicLayer.Entities.ContentManagement.SiteSection section = BusinessLogicLayer.Common.SiteSectionLogic.GetByID(secId);
                if (section != null)
                {
                    if (!string.IsNullOrEmpty(section.Alias))
                        Response.Redirect("~/" + section.Alias);
                }
            }
            Response.Redirect("~/Default.aspx?Section=" + Request["code"]);
        }
    }
}