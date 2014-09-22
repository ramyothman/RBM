using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ManatiqFrontEnd.Code.Disqus
{
    public class DisqusComments
    {
        // Set API variables. You can pull these from any source appropriate for your app
        string PublicKey = "poM0TgOoHyO0I4ZJCg0iBPEg7sam6xti4NguTuilsiiAm1gFEE6B2QQgVtto6ZMI";     // Application public key - register for one here: http://disqus.com/api/applications/
        string SecretKey = "9kwDCTCWpWEAL1kmQfq0IUV4PSefjcrAcy9IwxnZK23v5ZkyHvjS3eKytuAzTUP0";     // Application secret key
        string Thread = "2961756694";                  // Disqus thread ID. You can also use your custom identifier or URL using "ident:your_custom_identifier" or "link:http://example.com/your-post/", respectively
        string Forum = "natteq";                     // Change "example" to your own shortname
        string Limit = "5";                          // Get 15 comments from this thread at a time, I found this is the optimal number for speed of downloading. Max is 100
        string Include = "approved";
        string AccessToken = "326d7bf3df514a6ba2893e4fdc34a9c1";    // Enter your administrator access token or get one from the user: http://disqus.com/api/docs/auth/
        string EndPoint = "threads%2FlistPopular";
        // Create web client to get the comments for a thread
        public void DownloadComments(string cursor, string order)
        {
            // Call the posts/list endpoint documented here: http://disqus.com/api/docs/posts/list/
            Uri postsListUri = new Uri(("https://disqus.com/api/3.0/posts/list.json?api_key=" + PublicKey
                                        + "&api_secret=" + SecretKey
                                            //+ "&thread=" + Thread
                                            + "&forum=" + Forum
                                            + "&limit=" + Limit
                                            + "&include=" + Include
                                           
                                            //+ "&order=" + order
                                            //+ "&cursor=" + cursor
                                            + "&access_token=" + AccessToken));

            WebClient postsListData = new WebClient();
            postsListData.Headers[HttpRequestHeader.Referer] = "http://disqus.com/"; // API call will fail if you don't change the referrer: http://stackoverflow.com/questions/7216738/your-api-key-is-not-valid-on-this-domain-when-calling-disqus-from-wp7

            postsListData.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadComments_Completed);   // Download completed event handler
            string result = postsListData.DownloadString(postsListUri);
            JObject resultObject = JObject.Parse(result);
            // Get comment data from XML file
            var commentsdata = from comment in resultObject["response"].Children()
                               select new Comment
                               {
                                   CommenterAvatar = (string)comment["author"]["avatar"]["small"]["permalink"],
                                   CommenterName = (string)comment["author"]["name"],
                                   CommentTimestamp = (DateTime)comment["createdAt"],
                                   SingleComment = (string)comment["raw_message"],
                                   Link = (string)comment["link"]
                               };
            CurrentComments = commentsdata.ToList();
        }

        public List<PopularArticle> GetMostPopular(int limit)
        {
            // Call the posts/list endpoint documented here: http://disqus.com/api/docs/posts/list/
            Uri postsListUri = new Uri(("https://disqus.com/api/3.0/threads/listPopular.json?api_key=" + PublicKey
                                        + "&api_secret=" + SecretKey
                                            + "&forum=" + Forum
                                            + "&limit=" + limit.ToString()
                                            + "&include=" + Include
                                            //+ "&order=" + order
                                            + "&access_token=" + AccessToken));

            WebClient postsListData = new WebClient();
            postsListData.Headers[HttpRequestHeader.Referer] = "http://disqus.com/"; // API call will fail if you don't change the referrer: http://stackoverflow.com/questions/7216738/your-api-key-is-not-valid-on-this-domain-when-calling-disqus-from-wp7

            postsListData.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadComments_Completed);   // Download completed event handler
            string result = postsListData.DownloadString(postsListUri);
            JObject resultObject = JObject.Parse(result);
            // Get comment data from XML file
            var commentsdata = from comment in resultObject["response"].Children()
                               select new PopularArticle
                               {
                                   Title = (string)comment["title"],
                                   Posts = (int)comment["posts"],
                                   Likes = (int)comment["likes"],
                                   Link = (string)comment["link"]
                               };
            if (commentsdata != null)
                return commentsdata.ToList();
            else
                return new List<PopularArticle>();
        }



        // Comment download is finished, now we parse it
        private List<Comment> _comments;
        public List<Comment> CurrentComments
        {
            set { _comments = value; }
            get { return _comments; }
        }
        private void DownloadComments_Completed(object sender, DownloadStringCompletedEventArgs e)
        {
            // Parse the JSON Response
            JObject resultObject = JObject.Parse(e.Result);

            // Get comment data from XML file
            var commentsdata = from comment in resultObject["response"].Children()
                               select new Comment
                               {
                                   CommenterAvatar = (string)comment["author"]["avatar"]["small"]["permalink"],
                                   CommenterName = (string)comment["author"]["name"],
                                   CommentTimestamp = (DateTime)comment["createdAt"],
                                   SingleComment = (string)comment["raw_message"],
                               };
            CurrentComments = commentsdata.ToList();
            // Bind data to our listbox
            
        }
    }
}