using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.Columns
{
    public partial class ColumnsControl : BaseControl
    {
        public ColumnsControl()
        {
            ModeCode = 6;
            ModName = "News";
            ItemIndex = 0;
            ItemCount = 0;
            descLength = 20;
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                LayoutRepeater.DataSource = Articles;
                LayoutRepeater.DataBind();

                ModuleTitleText.InnerText = ModuleTitle;
            }
            if (!IsFirst)
                MainBlockContainer.Attributes.Add("class", "aside-block mrg-top");
        }
        public string GetDate(DateTime d)
        {
            return CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriCompleteWithDay(d)) + "  -  "  + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriTime(d));
        }
       

    }
}