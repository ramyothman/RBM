using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
namespace ManatiqFrontEnd.Controls.Article
{
    public partial class VerticalArticle : BaseControl
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
                    MainBlockContainer.Attributes.Add("class", "aside-block mrg-top");

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