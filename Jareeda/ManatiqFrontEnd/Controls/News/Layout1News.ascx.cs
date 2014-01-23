using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
namespace ManatiqFrontEnd.Controls.News
{
    public partial class Layout1News : BaseControl
    {

        public Layout1News()
        {
            ModeCode = 5;
            ModName = "ImageNews";
            descLength = 11;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                if (Articles.Count > 0)
                {
                    LayoutNewsRepeater.DataSource = Articles;
                    LayoutNewsRepeater.DataBind();
                    
                }
                ModuleTitleText.InnerText = ModuleTitle;
            }
        }

       
        
        
    }
}