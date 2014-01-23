using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.Ads
{
    public partial class Advertisement1 : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                if (Articles.Count > 0)
                {
                    ImportantNewsRepeater.DataSource = Articles;
                    ImportantNewsRepeater.DataBind();
                    
                }
                
            }
        }
    }
}