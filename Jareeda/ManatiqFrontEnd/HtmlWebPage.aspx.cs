using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal;
namespace ManatiqFrontEnd
{
    public partial class HtmlWebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string x = new ControlsManagement().GetPollResult(55, "~/Controls/Forms/PollResult.ascx");
        }
    }
}