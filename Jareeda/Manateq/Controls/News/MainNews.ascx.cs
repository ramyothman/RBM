using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class MainNews : BaseControl
    {
        public MainNews()
        {
            ModeCode = 3;
            ModName = "MainNews";
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            descLength = 20;
            if (!IsPostBack)
            {
                LoadData();
                if (Articles.Count > 0)
                {
                    MainSliderRepeater.DataSource = Articles;
                    SmallSliderRepeater.DataSource = Articles;

                    MainSliderRepeater.DataBind();
                    SmallSliderRepeater.DataBind();
                    LoadJavaScript();
                }
                else
                {
                    BusinessLogicLayer.Entities.ContentManagement.Article articleItem = new BusinessLogicLayer.Entities.ContentManagement.Article();
                    int id = 0;
                    string code = Request["sections"];
                    if (string.IsNullOrEmpty(code))
                    {
                        code = Page.RouteData.Values["sections"].ToString();
                    }
                    Int32.TryParse(code, out id);
                    int i = Articles.Count;
                    if (id != 0)
                    {
                        List<BusinessLogicLayer.Entities.ContentManagement.Article> articles = BusinessLogicLayer.Common.ArticleLogic.GetAllBySectionIdandCount(code, 5);
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

                        if (Articles.Count > 0)
                        {
                            MainSliderRepeater.DataSource = Articles;
                            SmallSliderRepeater.DataSource = Articles;

                            MainSliderRepeater.DataBind();
                            SmallSliderRepeater.DataBind();
                            LoadJavaScript();
                        }
                    }
                }
            }
            if (IsPostBack && !this.Page.IsCallback)
            {
                LoadJavaScript();
            }
        }
        
        /*
        
         */
        public int Index = 0;

        void LoadJavaScript()
        {

            string js = @" $(function () { 
 $('#" + this.MainNewsSlider.ClientID + @"').bxSlider({
            pagerCustom: '#bx-pager',
            auto: true
        });   

 });";

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MainNewsControlBlock" + this.ID, js, true);
        }
        
    }
}