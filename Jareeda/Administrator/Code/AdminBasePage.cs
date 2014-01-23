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

        //protected override void InitializeCulture()
        //{
        //    try
        //    {
        //        base.InitializeCulture();
        //        string culture = "en";
        //        string uiculture = "en";
        //        if (!string.IsNullOrEmpty(Request["Culture"]))
        //        {
        //            culture = Request["Culture"];
        //            uiculture = culture;
        //            Session["CurrentCulture"] = culture;
        //            Session["CurrentCultureUI"] = uiculture;
        //        }
        //        else if (Session["CurrentCulture"] != null)
        //            culture = Session["CurrentCulture"].ToString();
        //        if (Session["CurrentCultureUI"] != null)
        //            uiculture = Session["CurrentCultureUI"].ToString();
        //        BusinessLogicLayer.Entities.ContentManagement.Language language = BusinessLogicLayer.Common.LanguageLogic.GetByCode(culture);
        //        if (language != null)
        //            Session["LanguageId"] = language.LanguageId;
        //        //retrieve culture information from user
        //        //set culture to current thread
        //        Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo(uiculture);

        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //}

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