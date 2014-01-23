using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManatiqFrontEnd.Controls
{
    public class BaseControl : System.Web.UI.UserControl
    {
        #region Declarations
        public List<BusinessLogicLayer.Entities.ContentManagement.ModuleSection> ModuleSections = new List<BusinessLogicLayer.Entities.ContentManagement.ModuleSection>();
        public List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle> Articles = new List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle>();
        public BusinessLogicLayer.Entities.ContentManagement.HomePage HomePage = new BusinessLogicLayer.Entities.ContentManagement.HomePage();
        public BusinessLogicLayer.Components.ContentManagement.ModuleSectionLogic ModuleSectionLogic = new BusinessLogicLayer.Components.ContentManagement.ModuleSectionLogic();
        public BusinessLogicLayer.Components.ContentManagement.HomePageLogic HomePageLogic = new BusinessLogicLayer.Components.ContentManagement.HomePageLogic();
        protected int ModeCode = 0;
        protected string ModName = "";
        protected int ItemIndex = 0;
        protected int ItemCount = 0;
        public bool IsInternalBlock = false;

        public int SectionID
        {
            set
            {
                ViewState["SectionID"] = value;
            }
            get
            {
                if (ViewState["SectionID"] != null)
                {
                    return Convert.ToInt32(ViewState["SectionID"].ToString());
                }
                return 0;
            }
        }

        public string ModuleTitle
        {
            set
            {
                 ViewState["ModuleTitle"] = value;
            }
            get
            {
                if (ViewState["ModuleTitle"] != null)
                {
                    return ViewState["ModuleTitle"].ToString();
                }
                return "";
            }
        }

        public bool IsFirst
        {
            set
            {
                ViewState["IsFirst"] = value;
            }
            get
            {
                if (ViewState["IsFirst"] != null)
                {
                    return Convert.ToBoolean(ViewState["IsFirst"].ToString());
                }
                return true;
            }
        }

        public int HomePageID
        {
            set
            {
                ViewState["HomePageID"] = value;
            }
            get
            {
                if (ViewState["HomePageID"] != null)
                {
                    return Convert.ToInt32(ViewState["HomePageID"].ToString());
                }
                return 0;
            }
        }

        public string GetDate(DateTime d)
        {
            return CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriCompleteWithDay(d)) + "  -  " + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GetGreggCompleteByDate(d)) + "  -  " + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriTime(d));
        }
        #endregion

        #region Loadings
        public void LoadData()
        {
            if (!IsPostBack)
            {
                if (HomePageID == 0) return;
                HomePage = HomePageLogic.GetByID(HomePageID);

                Articles = new BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic().GetAllByHomePageIDOrdered(HomePageID);
                int i = Articles.Count;
                if (i < HomePage.ItemsNumber)
                {
                    ModuleSections = ModuleSectionLogic.GetAllByHomePageID(HomePageID);
                    foreach (BusinessLogicLayer.Entities.ContentManagement.ModuleSection moduleSection in ModuleSections)
                    {
                        if (i >= HomePage.ItemsNumber) break;
                        foreach (BusinessLogicLayer.Entities.ContentManagement.Article article in moduleSection.Articles)
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
                ItemCount = HomePage.ItemsNumber;
            }
        }
        #endregion


        #region HelperMethods
        protected int descLength = 10;
        public string GetDescriptionText(string text)
        {
            string result = "";
            string[] split = text.Split(' ');
            int count = 1;
            foreach (string str in split)
            {
                if (count <= descLength)
                {
                    result += str + " ";
                }
                count++;
            }
            if (result.Length > 0)
            {
                result += " ...";
            }
            return result;
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
        public string GetWriterImagePath(string url)
        {
            string urlFinal = BusinessLogicLayer.Common.NewsImages + url;
            if (string.IsNullOrEmpty(url))
            {
                urlFinal = "~/App_Themes/Manatiq/images/writters2.png";
            }
            return urlFinal;
        }

        public string GetTwitterLink(string id)
        {
            string result = "http://twitter.com/share?url=@URL&amp;text=@TITLE";
            result = result.Replace("@URL", BusinessLogicLayer.Common.MainDomain + "ns2-" + id);
            var article = (from x in Articles where x.ArticleID == Convert.ToInt32(id) select x).FirstOrDefault();
            result = result.Replace("@TITLE", article.ArticleName);
            return result;
        }

        public string GetTwitterLinkColumn(string id)
        {
            string result = "http://twitter.com/share?url=@URL&amp;text=@TITLE";
            result = result.Replace("@URL", BusinessLogicLayer.Common.MainDomain + "cl3-" + id);
            var article = (from x in Articles where x.ArticleID == Convert.ToInt32(id) select x).FirstOrDefault();
            result = result.Replace("@TITLE", article.ArticleName);
            return result;
        }

        public string GetGoogleLink(string id)
        {
            string result = "https://plus.google.com/share?url=@URL";
            result = result.Replace("@URL", BusinessLogicLayer.Common.MainDomain + "ns2-" + id);
            return result;

        }
        public string GetGoogleLinkColumn(string id)
        {
            string result = "https://plus.google.com/share?url=@URL";
            result = result.Replace("@URL", BusinessLogicLayer.Common.MainDomain + "cl3-" + id);
            return result;

        }

        public string GetFacebookLink(string id)
        {
            string result = "https://www.facebook.com/sharer/sharer.php?u=@URL";
            result = result.Replace("@URL", BusinessLogicLayer.Common.MainDomain + "ns2-" + id);
            return result;

        }

        public string GetFacebookLinkColumn(string id)
        {
            string result = "https://www.facebook.com/sharer/sharer.php?u=@URL";
            result = result.Replace("@URL", BusinessLogicLayer.Common.MainDomain + "cl3-" + id);
            return result;

        }

        public string GetMoreLink()
        {
            string result = "";
            if (ModuleSections != null)
            {
                foreach (BusinessLogicLayer.Entities.ContentManagement.ModuleSection section in ModuleSections)
                {
                    result += section.SectionID + ",";
                }
                if (!string.IsNullOrEmpty(result))
                    result = result.Remove(result.Length - 1, 1);
            }
            else
            {
                if (Articles != null)
                {
                    if (Articles.Count > 0)
                    {
                        result = Articles[0].CurrentArticle.SiteSectionId.ToString();
                    }
                }
            }
            if (string.IsNullOrEmpty(result))
            {
                result = "#";
            }
            else
            {
                result = "~/list/5-" + result;
            }
            return result;
        }
        #endregion
    }
}