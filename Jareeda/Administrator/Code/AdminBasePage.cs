using CommonWeb.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Administrator.Code
{
    public enum AdminBasePageType
    {
        Manage,
        View,
        Save
    }
    public class AdminBasePage : CommonWeb.Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!SecurityManager.isLogged(this))
                {
                    Response.Redirect("~/Login/Default.aspx");
                }
                else
                {
                    
                    if (Request["Logout"] != null && Request["Logout"].ToLower() == "true")
                    {
                        SecurityManager.doLogout(this);
                    }
                }
            }
        }
        string JareedaStyleRef
        {
            set
            {
                _Masters.RootAdmin master = this.Master as _Masters.RootAdmin;
                if (master == null)
                {
                    master = this.Master.Master as _Masters.RootAdmin;
                }
                if (master != null)
                {
                    master.JareedaStyleRef = value;
                    AddHeader(value);
                }
            }
        }

        void AddHeader(string href)
        {
            //_Masters.RootAdmin master = this.Master as _Masters.RootAdmin;
           //Header.Controls.Remove(master.JareedaStyleControl);
           Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl(href) + "\" />"));
            
        }

        

        public AdminBasePageType PageType = AdminBasePageType.Manage;
        #region Client Messages
        public enum NotifyMessageType
        {
            Success,
            Info,
            Error
        }
        public void NotifyMessage(NotifyMessageType type, string message)
        {
            
            switch (type)
            {
                case NotifyMessageType.Error:
                    ClientScript.RegisterStartupScript(GetType(), "error", "jError('" + message + "');", true);
                    break;
                case NotifyMessageType.Info:
                    ClientScript.RegisterStartupScript(GetType(), "notify", "jNotify('" + message + "');", true);
                    break;
                case NotifyMessageType.Success:
                    ClientScript.RegisterStartupScript(GetType(), "success", "jSuccess('" + message + "');", true);
                    break;
            }
        }

        public void NotifyMessageRedirect(NotifyMessageType type, string message,string url)
        {

            switch (type)
            {
                case NotifyMessageType.Error:
                    ClientScript.RegisterStartupScript(GetType(), "error", "jError('" + message + "'); setTimeout(function() {window.location.href ='" + url + "'}" + ",1500);", true);
                    break;
                case NotifyMessageType.Info:
                    ClientScript.RegisterStartupScript(GetType(), "notify", "jNotify('" + message + "'); setTimeout(function() {window.location.href ='" + url + "'}" + ",1500);", true);
                    break;
                case NotifyMessageType.Success:
                    ClientScript.RegisterStartupScript(GetType(), "success", "jSuccess('" + message + "'); setTimeout(function() {window.location.href ='" + url + "'}" + ",1500);", true);
                    break;
            }
        }
        #endregion
    }
}