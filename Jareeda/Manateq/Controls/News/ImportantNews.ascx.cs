using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class ImportantNews : BaseControl
    {
        
        public List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle> ArticlesMain = new List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle>();
        public List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle> ArticlesLeft = new List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle>();
        public List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle> ArticlesRight = new List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle>();

        public ImportantNews()
        {
            ModeCode = 4;
            ModName = "ImportantNews";
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BlockHead.Attributes.Add("class", "block-head " + GetBackground());
                descLength = 32;
                LoadData();
                //Articles = new BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic().GetAllByHomePageID(HomePageID);
                if (Articles.Count > 0)
                {
                    int i = 1;
                    int leftNews = HomePage.ItemsPerPage + ((Articles.Count - HomePage.ItemsPerPage) / 2);
                    foreach (BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle article in Articles)
                    {

                        if (i <= HomePage.ItemsPerPage)
                        {
                            ArticlesMain.Add(article);
                        }
                        else if (i <= leftNews)
                        {
                            ArticlesRight.Add(article);
                        }
                        else
                        {
                            ArticlesLeft.Add(article);
                        }
                        i++;
                    }
                    MoreLink.HRef = GetMoreLink();
                    ImportantNewsRepeater.DataSource = ArticlesMain;
                    ImportantNewsRepeater.DataBind();
                    FirstItemsRepeater.DataSource = ArticlesRight;
                    FirstItemsRepeater.DataBind();
                    SecondItemsRepeater.DataSource = ArticlesLeft;
                    SecondItemsRepeater.DataBind();
                    ModuleTitleText.InnerText = ModuleTitle;
                    
                }
            }
        }

        
    }
}