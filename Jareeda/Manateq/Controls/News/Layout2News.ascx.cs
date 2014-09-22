using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class Layout2News : BaseControl
    {
        public Layout2News()
        {
            ItemIndex = 0;
            ModeCode = 5;
            ModName = "MultipleCategories";
            descLength = 16;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                ModuleSections = ModuleSectionLogic.GetAllByHomePageID(HomePageID);
                Layout2NewsRepeater.DataSource = ModuleSections;
                Layout2NewsRepeater.DataBind();
                Layout2NewsDetailsRepeater.DataSource = ModuleSections;
                Layout2NewsDetailsRepeater.DataBind();
            }
        }

        
    }
}