using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.General
{
    public partial class Twitter : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsFirst)
                MainBlockContainer.Attributes.Add("class", "aside-block mrg-top");
        }
    }
}