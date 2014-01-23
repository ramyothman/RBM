using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Entities.Persons;
using CommonWeb.Common;
namespace CommonWeb.Security
{
    /// <summary>
    /// Summary description for SecurityManager
    /// </summary>
    public class SecurityManager
    {
        public SecurityManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static bool doLogin(Page currentPage, string uid, string pwd)
        {
            if (uid == string.Empty || pwd == string.Empty)
                return false;
            // loging
            BusinessLogicLayer.Entities.Persons.Person user = null;
            BusinessLogicLayer.Components.UserMonitorLogic monitorLogic = new BusinessLogicLayer.Components.UserMonitorLogic();
            string ipMain = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string IpForwardedFor = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string ip= String.Format("{0}-{1}", ipMain, IpForwardedFor);
            int countNumbers = monitorLogic.GetUserMonitorCountInPeriod(uid, ip);
            
            try
            {
                // autehticate        

                user = BusinessLogicLayer.Common.PersonLogic.GetByUserName(uid);
                if (countNumbers >= 10)
                {
                    throw new smLoginInactiveException();
                }
                // invalid login
                if (user == null)
                {
                    throw new smInvalidLoginException();
                }

                if (user.Credentials == null)
                {
                    monitorLogic.Insert(0, false, ip, uid, DateTime.Now);
                    throw new smLoginInactiveException();
                }
                if (string.IsNullOrEmpty(user.Credentials.PasswordHash))
                {
                    monitorLogic.Insert(user.BusinessEntityId, false, ip, uid, DateTime.Now);
                    throw new smLoginInactiveException();
                }
                // password
                string passHash = Tools.MD5(pwd + user.Credentials.PasswordSalt);

                if (user.Credentials.PasswordHash != passHash)
                {

                    monitorLogic.Insert(user.BusinessEntityId, false, ip, uid, DateTime.Now);
                    throw new smInvalidPasswordException();
                }


                // copy by value to another object before saving it into session.

                // blank the user password before saving into the session            
                //u.Password = string.Empty;

                // save user object into session
                monitorLogic.Insert(user.BusinessEntityId, true, ip, uid, DateTime.Now);
                currentPage.Session.Add("USER", user);
                //currentPage.Session.Add("UserAccessType", user.AccessTypeId);
                currentPage.Session.Add("USERID", user.BusinessEntityId);
                currentPage.Session["MenuSession"] = null;
                // log the current login            
                // get user IP and browser type, etc, and put it in ExtraParam            
                //SManager.logAction(log);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public static bool doLogout(Page currentPage)
        {
            // loging

            Person u = currentPage.Session["USER"] as Person;
            if (u != null)
            {
                currentPage.Session.Remove("USER");
                currentPage.Session.Remove("USERID");
                currentPage.Session["MenuSession"] = null;
                currentPage.Session.Clear();
                currentPage.Session.Abandon();

                return true;
            }
            return false;
        }

        public static Person getUser(Page currentPage)
        {
            return currentPage.Session["USER"] as Person;
        }

        //public static Employees getEmployee(Page currentPage)
        //{
        //    Users user = getUser(currentPage);
        //    return user.CurrentEmployee;
        //}
        public static void UpdateUser(Page currentPage,Person person)
        {
            currentPage.Session["USER"] = person;
        }
        public static bool isLogged(Page currentPage)
        {
            return (currentPage.Session["USER"] != null ? true : false);
        }

    }

}