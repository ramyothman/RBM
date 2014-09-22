using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Controls.Common
{
    public partial class WaitControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack && !this.Page.IsCallback)
            {
                LoadJavaScript();
            }
        }

        private void LoadJavaScript()
        {
            string script = @"$(window).load(function () {
                                $('#icmsloading').fadeOut(function () {
                                    $(this).remove();
                                    $('body').removeAttr('style');
                                });
                            });";
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "FormWaitControlLoading", script, true);
        }
    }
}