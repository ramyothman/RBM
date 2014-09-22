using ManatiqFrontEnd.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.News
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageManager manager = new PageManager();
                _Masters.Master master = this.Master as _Masters.Master;
                if (master != null)
                {
                    manager.Holders = master.ContentPlaceHolderMain;
                    int SectionID = 0;
                    Int32.TryParse(Request["Section"], out SectionID);
                    manager.LoadControls(this, SectionID,2);
                }
            }
        }
        
    }
}