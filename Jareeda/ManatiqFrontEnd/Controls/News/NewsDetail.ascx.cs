using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class NewsDetail : BaseControl
    {
        public string ArticleTitleText = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BusinessLogicLayer.Entities.ContentManagement.Article article = new BusinessLogicLayer.Entities.ContentManagement.Article();
                int id = 0;
                string code = Request["Code"];
                if (string.IsNullOrEmpty(code))
                {
                    code = Page.RouteData.Values["Id"].ToString();
                }
                Int32.TryParse(code, out id);
                if (id != 0)
                {
                    article = BusinessLogicLayer.Common.ArticleLogic.GetByID(id);
                    if (article != null)
                    {
                        ArticleTitle.InnerText = article.ArticleName;
                        ArticleTitleText = article.ArticleName;
                        this.Page.Title = article.ArticleName;
                        ArticleSubTitle.InnerText = article.SubTitle;
                        MainImage.Src = GetImagePath(article.ArticleAttachment);
                        if (!string.IsNullOrEmpty(article.ArticleArabic.AuthorAlias))
                        {
                            AuthorAlilas.InnerText += article.ArticleArabic.AuthorAlias;
                            WriterImage.Visible = false;
                        }
                        else
                            AuthorAlilas.InnerText = article.AuthorName;
                        Content.InnerHtml = article.ArticleContent;
                        DateSpan.InnerText = GetDate(article.PostDate);
                        ManatiqFrontEnd.News.Default defaultPage = this.Page as ManatiqFrontEnd.News.Default;
                        if (defaultPage != null)
                        {
                            defaultPage.ogImage.Attributes.Add("content", GetImagePath(article.ArticleAttachment));
                            defaultPage.ogDescription.Attributes.Add("content", article.ArticleDescription);
                            defaultPage.ogTitle.Attributes.Add("content", article.ArticleName);
                        }
                        WriterImage.Src = GetWriterImagePath(article.Author.PersonImage);
                        ArticleViews.InnerText = CommonWeb.Common.BasePage.TranslateNumerals(article.ViewsCount.ToString("n0"));
                        string sources = "";
                        foreach (BusinessLogicLayer.Entities.ContentManagement.ArticleSources source in article.ArticleSources)
                        {
                            sources += " " + source.CurrentSource.Name + " -";
                        }
                        if (!string.IsNullOrEmpty(sources))
                        {
                            sources = sources.Remove(sources.Length - 1, 1);
                        }

                        
                        if(!string.IsNullOrEmpty(sources))
                            AuthorAlilas.InnerText += " - " + sources;
                        new BusinessLogicLayer.Components.ContentManagement.ArticleViewsLogic().Insert(article.ArticleId, CommonWeb.Common.Tools.GetIPAddress(), DateTime.Now);
                    }

                }
            }
        }
        public string GetDate(DateTime d)
        {
            return CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriCompleteWithDay(d)) + "  -  " + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GetGreggCompleteByDate(d)) + "  -  " + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriTime(d));
        }

        public string GetImagePath(string url)
        {
            string urlFinal = BusinessLogicLayer.Common.NewsImages + url;
            if (string.IsNullOrEmpty(url))
            {
                urlFinal = "~/App_Themes/Manatiq/images/main-slider/main-slide2.png";
            }
            return urlFinal;

        }
    }
}