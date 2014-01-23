using Administrator.Code;
using CommonWeb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator
{
    public partial class Default : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = 0;
            if(!SecurityManager.isLogged(this))
                Response.Redirect("Login\\Default.aspx");
            //Response.Redirect("Login/Default.aspx");
            /*
             string url = "http://fooblog.com/feed";
        XmlReader reader = XmlReader.Create(url);
        SyndicationFeed feed = SyndicationFeed.Load(reader);
        reader.Close();
        foreach (SyndicationItem item in feed.Items)
        {
            String subject = item.Title.Text;    
            String summary = item.Summary.Text;
            ...                
        }
             */
        }
    }
}