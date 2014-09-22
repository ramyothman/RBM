using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.Article
{
    public partial class HorizontalArticle : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TitleDiv.Attributes.Add("class", "block-head " + GetBackground());
                LoadData();
                if (Articles.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ModuleTitle))
                    {
                        TitleDiv.InnerHtml = "<h1>" + ModuleTitle + "</h1>";
                        TitleDiv.Visible = true;
                    }
                    ImportantNewsRepeater.DataSource = Articles;
                    ImportantNewsRepeater.DataBind();

                }
                if (!IsFirst)
                    MainBlockContainer.Attributes.Add("class", "block-news international mrg-top");

            }
        }
    }
}