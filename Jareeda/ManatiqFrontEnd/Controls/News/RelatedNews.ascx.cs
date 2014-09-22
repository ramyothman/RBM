using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class RelatedNews : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                descLength = 30;
                BusinessLogicLayer.Entities.ContentManagement.Article articleItem = new BusinessLogicLayer.Entities.ContentManagement.Article();
                LoadData();
                int id = 0;
                string code = Request["Code"];
                if (string.IsNullOrEmpty(code))
                {
                    code = Page.RouteData.Values["Id"].ToString();
                }
                Int32.TryParse(code, out id);
                int i = Articles.Count;
                if (id != 0)
                {
                    articleItem = BusinessLogicLayer.Common.ArticleLogic.GetByID(id);
                    if (articleItem != null)
                    {
                        List<BusinessLogicLayer.Entities.ContentManagement.Article> articles = BusinessLogicLayer.Common.ArticleLogic.GetAllBySectionIdandCountExcludingCurrent(articleItem.ArticleId, articleItem.SiteSectionId.ToString(), HomePage.ItemsNumber);
                        foreach (BusinessLogicLayer.Entities.ContentManagement.Article article in articles)
                        {
                            if (i >= HomePage.ItemsNumber) break;
                            BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle cmArticles = new BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle();
                            cmArticles.ArticleID = article.ArticleId;
                            cmArticles.CurrentArticle = article;
                            cmArticles.ArticleOrder = i;
                            cmArticles.HomePageID = HomePageID;
                            Articles.Add(cmArticles);
                            i++;
                        }
                    }
                }
                LayoutNewsRepeater.DataSource = Articles;
                LayoutNewsRepeater.DataBind();
                ModuleTitleText.InnerText = ModuleTitle;
                MoreLink.HRef = GetMoreLink();
                if (!IsFirst)
                    MainBlockContainer.Attributes.Add("class", "block-news international mrg-top");
            }
        }
    }
}