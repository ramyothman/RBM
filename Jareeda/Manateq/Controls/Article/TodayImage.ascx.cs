using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.Article
{
    public partial class TodayImage : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    TitleDiv.Attributes.Add("class", "aside-block-head mrg-top " + GetBackground());
                else
                    TitleDiv.Attributes.Add("class", "aside-block-head " + GetBackground());

            }
        }
        public string GetDisplay(int id)
        {
            string display = "display:block;";
            var article = (from x in Articles where x.ArticleID == id select x).FirstOrDefault();
            if (article != null)
            {
                if (string.IsNullOrEmpty(article.Description.Trim()))
                    display = "display:none;";
            }
            return display;
        }
    }
}