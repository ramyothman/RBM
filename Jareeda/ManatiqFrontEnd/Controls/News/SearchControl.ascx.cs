using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class SearchControl : BaseControl
    {
        List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles = null;
                int id = 0;
                string code = Request["key"];
                if (string.IsNullOrEmpty(code))
                {
                    code = Page.RouteData.Values["key"].ToString();
                }
                Articles = BusinessLogicLayer.Common.ArticleLogic.FindArticles(BusinessLogicLayer.Common.DefaultLanguageId.ToString(), BusinessLogicLayer.Common.ManatiqID.ToString(), code);
                ImportantNewsRepeater.DataSource = Articles;
                ImportantNewsRepeater.DataBind();
            }
        }
    }
}