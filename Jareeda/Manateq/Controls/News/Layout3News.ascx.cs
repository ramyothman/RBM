using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class Layout3News : BaseControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BlockHead.Attributes.Add("class", "block-head " + GetBackground());
                descLength = 30;
                LoadData();
                LayoutNewsRepeater.DataSource = Articles;
                LayoutNewsRepeater.DataBind();
                ModuleTitleText.InnerText = ModuleTitle;
                MoreLink.HRef = GetMoreLink();
                if(!IsFirst)
                    MainBlockContainer.Attributes.Add("class", "block-news international mrg-top");
            }
        }

        
    }
}