using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class KarikateurControl : BaseControl
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
                    LoadJavaScript();
                }
                ModuleTitleText.InnerText = ModuleTitle;
            }
            if (!IsFirst)
                MainBlockContainer.Attributes.Add("class", "aside-block mrg-top " + GetBackground());
            else
                MainBlockContainer.Attributes.Add("class", "aside-block-head " + GetBackground());
            if (IsPostBack && !this.Page.IsCallback)
            {
                LoadJavaScript();
            }
        }

        /*
         $('.bxslider3').bxSlider({
  infiniteLoop: false,
  hideControlOnEnd: true
});
         */
        void LoadJavaScript()
        {



            string js = @" $(function () { 
 $('#" + this.KarikateurNewsItems.ClientID + @"').bxSlider({
            infiniteLoop: false,
            hideControlOnEnd: true
        });   

 });";

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UrgentControlBlock" + this.ID, js, true);
        }

    }


}