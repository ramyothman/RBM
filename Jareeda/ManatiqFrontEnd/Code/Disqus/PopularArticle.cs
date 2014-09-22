using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManatiqFrontEnd.Code.Disqus
{
    public class PopularArticle
    {
        public string Title;
        public int Posts;
        public string Link;
        public int Likes;
        public int ArticleId
        {
            get
            {
                if (string.IsNullOrEmpty(Link))
                    return 0;
                int index = Link.LastIndexOf("-");
                if (index <= 0)
                    return 0;
                string idString = Link.Substring(index + 1, Link.Length - 1 - index);
                int id = 0;
                Int32.TryParse(idString, out id);
                return id;
            }
        }

        public static string GetArticleListString(List<PopularArticle> articles)
        {
            string result = "";
            foreach(PopularArticle a in articles)
            {
                result += a.ArticleId + ",";
            }
            if(!string.IsNullOrEmpty(result))
                result = result.Remove(result.Length - 1, 1);
            return result;
        }
    }
}