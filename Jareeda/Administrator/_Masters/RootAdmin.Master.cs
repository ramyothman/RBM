using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator._Masters
{
    public partial class RootAdmin : System.Web.UI.MasterPage
    {

        public string JareedaStyleRef
        {
            set { JareedaStyleReference.Href = value; }
        }

        public System.Web.UI.HtmlControls.HtmlLink JareedaStyleControl
        {
            get { return JareedaStyleReference; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}