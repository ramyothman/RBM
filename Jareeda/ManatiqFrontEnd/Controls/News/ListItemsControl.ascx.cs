using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.News
{
    public partial class ListItemsControl : System.Web.UI.UserControl
    {
        #region Declarations
        public List<BusinessLogicLayer.Entities.ContentManagement.Article> Articles = new List<BusinessLogicLayer.Entities.ContentManagement.Article>();
        public BusinessLogicLayer.Entities.ContentManagement.HomePage HomePage = new BusinessLogicLayer.Entities.ContentManagement.HomePage();
        protected int ItemIndex = 0;
        protected int ItemCount = 0;
        #endregion
        public ListItemsControl()
        {

        }

        public ListItemsControl(List<BusinessLogicLayer.Entities.ContentManagement.Article> articles, BusinessLogicLayer.Entities.ContentManagement.HomePage homePage)
        {
            Articles = articles;
            HomePage = homePage;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region HelperMethods
        protected int descLength = 30;
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
            var article = (from x in Articles where x.ArticleId == Convert.ToInt32(id) select x).FirstOrDefault();
            result = result.Replace("@TITLE", article.ArticleName);
            return result;
        }

        public string GetGoogleLink(string id)
        {
            string result = "https://plus.google.com/share?url=@URL";
            result = result.Replace("@URL", BusinessLogicLayer.Common.MainDomain + "ns2-" + id);
            return result;

        }

        public string GetFacebookLink(string id)
        {
            string result = "https://www.facebook.com/sharer/sharer.php?u=@URL";
            result = result.Replace("@URL", BusinessLogicLayer.Common.MainDomain + "ns2-" + id);
            return result;

        }

        
        #endregion
    }
}