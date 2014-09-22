using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManatiqFrontEnd.Code.Disqus
{
    public class Comment
    {
        string commenteravatar;
        string commentername;
        DateTime commenttimestamp;
        string singlecomment;
        string link;

        public string CommenterAvatar
        {
            get { return commenteravatar; }
            set { commenteravatar = value; }
        }

        public string CommenterName
        {
            get { return commentername; }
            set { commentername = value; }
        }

        public DateTime CommentTimestamp
        {
            get { return commenttimestamp; }
            set { commenttimestamp = value; }
        }

        public string Link
        {
            set { link = value; }
            get { return link; }
        }
        public string SingleComment
        {
            get { return singlecomment; }
            set
            {
                // Truncates the characters in comment to 250 (user can click comment for more)
                var maxLength = 250;
                singlecomment = value;
                if (singlecomment.Length > maxLength)
                {
                    singlecomment = value.Substring(0, maxLength);
                    singlecomment += "... (more)";
                }
            }
        }

    }
}