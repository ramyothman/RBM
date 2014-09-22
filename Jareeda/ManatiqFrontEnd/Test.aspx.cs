using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WWB.DisqusSharp;
using WWB.DisqusSharp.Infrastructure.HammockWrappers;
using WWB.DisqusSharp.Model.DisqusService;

namespace ManatiqFrontEnd
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //IDisqusService disqus2 = new HammockDisqusForumService();
            //IDisqusService disqus = new HammockDisqusService("9kwDCTCWpWEAL1kmQfq0IUV4PSefjcrAcy9IwxnZK23v5ZkyHvjS3eKytuAzTUP0");
            //var f = disqus.GetForumList();
            //IEnumerable < WWB.DisqusSharp.Model.DisqusDTO.Forum> forums = (IEnumerable < WWB.DisqusSharp.Model.DisqusDTO.Forum>)disqus.GetForumList();
            ////IEnumerable<string> names = disqus.GetThreadList("Almnatiq", new StartLimitArgs { Start = 0, Limit = 5 }).Payload.Select(disqusThread => disqusThread.Title);
            
            //foreach (WWB.DisqusSharp.Model.DisqusDTO.Forum forum in forums)
            //{
            //    Console.WriteLine(forum.ShortName);
            //}

            Code.Disqus.DisqusComments comments = new Code.Disqus.DisqusComments();
            List<Code.Disqus.PopularArticle> c = comments.GetMostPopular(5);
        }

        protected void gridViewArticles_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
           
        }

        protected void articleCallbackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {

        }

        protected void callBackList_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            e.Result = "done";
        }

        protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            
        }

        protected void cb2_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            e.Result = DateTime.Now.ToString();
        }
    }
}