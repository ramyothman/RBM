using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class MostReadCommented : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                int index = 1;
                string cacheKey1 = "mostReadItems";
                string cacheKey2 = "mostCommentedItems";
                var cacheItem = this.Page.Cache[cacheKey1] as List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle>;
                if ((cacheItem == null))
                {
                    List<BusinessLogicLayer.Entities.ContentManagement.Article> articles = BusinessLogicLayer.Common.ArticleLogic.GetTopReadArticles(5);
                    Articles = new List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle>();
                    foreach (BusinessLogicLayer.Entities.ContentManagement.Article article in articles)
                    {
                        BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle cmArticle = new BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle();
                        cmArticle.ArticleID = article.ArticleId;
                        cmArticle.ArticleName = article.ArticleName;
                        cmArticle.ArticleOrder = index;
                        cmArticle.CurrentArticle = article;
                        Articles.Add(cmArticle);
                    }
                    Cache.Insert(cacheKey1, Articles, null,
                    DateTime.Now.AddHours(2),
                    TimeSpan.Zero);
                }
                else
                    Articles = cacheItem;

                var cacheItem2 = this.Page.Cache[cacheKey2] as List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle>;
                if ((cacheItem2 == null))
                {
                    Code.Disqus.DisqusComments comments = new Code.Disqus.DisqusComments();
                    List<Code.Disqus.PopularArticle> c = comments.GetMostPopular(5);
                    Articles2 = new List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle>();
                    List<BusinessLogicLayer.Entities.ContentManagement.Article> articles2 = BusinessLogicLayer.Common.ArticleLogic.GetArticlesByID(Code.Disqus.PopularArticle.GetArticleListString(c), 5);
                    foreach (BusinessLogicLayer.Entities.ContentManagement.Article article in articles2)
                    {
                        BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle cmArticle = new BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle();
                        cmArticle.ArticleID = article.ArticleId;
                        cmArticle.ArticleName = article.ArticleName;
                        cmArticle.ArticleOrder = index;
                        cmArticle.CurrentArticle = article;
                        Articles2.Add(cmArticle);
                    }
                    Cache.Insert(cacheKey2, Articles2, null,
                    DateTime.Now.AddHours(2),
                    TimeSpan.Zero);
                }
                else
                    Articles2 = cacheItem;
                
                
                LayoutNewsRepeater.DataSource = Articles;
                LayoutNewsRepeater.DataBind();
                RepeaterMostCommented.DataSource = Articles2;
                RepeaterMostCommented.DataBind();
                LoadJavaScript();
            }

            if (IsPostBack && !this.Page.IsCallback)
            {
                LoadJavaScript();
            }

            if (!IsFirst)
                MainBlockContainer.Attributes.Add("class", "aside-block mrg-top ");
            else
                MainBlockContainer.Attributes.Add("class", "aside-block ");
        }

        void LoadJavaScript()
        {

            string js = @" $(function () { 
                $('#" + this.MostReadCommentedTab.ClientID + @"').tabs();   
             

 });";

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "WeatherBlock" + this.ID, js, true);
        }
    }
}