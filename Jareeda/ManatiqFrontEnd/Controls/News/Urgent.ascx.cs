using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class Urgent : BaseControl
    {
        public Urgent()
        {
            ModeCode = 2;
            ModName = "Urgent";
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                if (Articles.Count > 0)
                {

                    UrgentNewsRepeater.DataSource = Articles;
                    UrgentNewsRepeater.DataBind();
                    ModuleTitleText.InnerText = ModuleTitle;
                    LoadJavaScript();
                    
                }
                
            }
            if (IsPostBack && !this.Page.IsCallback)
            {
                LoadJavaScript();
            }
        }

        
        
        void LoadJavaScript()
        {

            
            
            string js = @" $(function () { 
 $('#" + this.UrgentNewsItems.ClientID + @"').cycle({
            fx: 'fade',
            speed: 'slow',
            timeout: 5000
        });   

 });";

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UrgentControlBlock" + this.ID, js, true);
        }
    }
}