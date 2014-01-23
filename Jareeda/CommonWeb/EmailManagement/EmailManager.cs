using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;

using System.Net.Mime;
using System.Net;

using System.IO;

using System.Threading;

namespace CommonWeb.EmailManagement
{

    /// <summary>
    /// Summary description for SManager
    /// </summary>
    public class EmailManager
    {
        public EmailManager()
        {

        }
        public enum EmailTypes
        {
            Signup = 1,
            Register = 2,
            ForgotPassword = 3,
            AbstractSubmitted = 4,
            AbstractEdited = 5,
            AbstractWaitingReview = 6,
            AbstractReviewed = 7,
            AbstractPosterAccepted = 8,
            AbstractOralAccepted = 9,
            AbstractRejected = 10,
            AbstractCancelled = 11,
            AbstractRequireRevise = 12,
            UserEmailGeneralTemplate = 13,
            AdminEmailGeneralTemplate = 14,
            Custom = 15
        }
        #region Old Code
        public static bool SendSignupEmailFromDBTemplate(Page currentPage, int ConferenceId, int LanguageId, string Name, string City, string Country, string PhoneNumber, string UserName, string Password, string VerificationCode, string Email)
        {
            bool result = false;
            string tmplName = "SignupEmail.html", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }
            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", City);
            tmpl = tmpl.Replace("##COUNTRY##", Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", PhoneNumber);
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", Name);
            tmpl = tmpl.Replace("##NAMEFULL##", Name);
            tmpl = tmpl.Replace("##USERNAME##", UserName);
            tmpl = tmpl.Replace("##PASSWORD##", Password);
            tmpl = tmpl.Replace("##VERIFY##", VerificationCode);
            // send email 
            if (sendMail(tmpl, "Sign up for Qiyas", Email, currentPage, "", null))
                return true;

            return false;

        }
        #region Abstracts
        public static bool SendNotAcceptedAbstractEmail(Page currentPage, BusinessLogicLayer.Entities.Conference.Abstracts abstracts)
        {
            string tmplName = "NotAcceptedAbstract.htm", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }
            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", abstracts.MainAuthor.City);
            tmpl = tmpl.Replace("##COUNTRY##", abstracts.MainAuthor.Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", abstracts.MainAuthor.PhoneNumberAreaCode, abstracts.MainAuthor.PhoneNumber));
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", abstracts.AuthorContactName);
            tmpl = tmpl.Replace("##NAMEFULL##", abstracts.AuthorContactNameFull);
            tmpl = tmpl.Replace("##TITLE##", abstracts.AbstractTitle);
            // send email 

            if (sendMail(tmpl, "Abstract Rejected by Qiyas ", abstracts.MainAuthor.Email, currentPage, "", null))
                return true;

            return false;
        }

        public static bool SendOralAcceptedAbstractEmail(Page currentPage, BusinessLogicLayer.Entities.Conference.Abstracts abstracts)
        {
            string tmplName = "OralPresentationAcceptance.htm", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", abstracts.MainAuthor.City);
            tmpl = tmpl.Replace("##COUNTRY##", abstracts.MainAuthor.Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", abstracts.MainAuthor.PhoneNumberAreaCode, abstracts.MainAuthor.PhoneNumber));
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", abstracts.AuthorContactName);
            tmpl = tmpl.Replace("##NAMEFULL##", abstracts.AuthorContactNameFull);
            tmpl = tmpl.Replace("##TITLE##", abstracts.AbstractTitle);
            // send email 

            if (sendMail(tmpl, "Abstract acceptance as Oral presentation by Qiyas ", abstracts.MainAuthor.Email, currentPage, "", null))
                return true;

            return false;
        }

        public static bool SendPosterAcceptedAbstractEmail(Page currentPage, BusinessLogicLayer.Entities.Conference.Abstracts abstracts)
        {
            string tmplName = "PosterAbstractAcceptance.htm", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", abstracts.MainAuthor.City);
            tmpl = tmpl.Replace("##COUNTRY##", abstracts.MainAuthor.Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", abstracts.MainAuthor.PhoneNumberAreaCode, abstracts.MainAuthor.PhoneNumber));
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", abstracts.AuthorContactName);
            tmpl = tmpl.Replace("##NAMEFULL##", abstracts.AuthorContactNameFull);
            tmpl = tmpl.Replace("##TITLE##", abstracts.AbstractTitle);
            // send email 

            if (sendMail(tmpl, "Abstract acceptance as Poster Presentation by Qiyas ", abstracts.MainAuthor.Email, currentPage, "", null))
                return true;

            return false;
        }
        public static bool SendCancelAbstractEmail(Page currentPage, BusinessLogicLayer.Entities.Conference.Abstracts abstracts)
        {
            string tmplName = "CancelAbstract.htm", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", abstracts.MainAuthor.City);
            tmpl = tmpl.Replace("##COUNTRY##", abstracts.MainAuthor.Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", abstracts.MainAuthor.PhoneNumberAreaCode, abstracts.MainAuthor.PhoneNumber));
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", abstracts.AuthorContactName);
            tmpl = tmpl.Replace("##NAMEFULL##", abstracts.AuthorContactNameFull);
            tmpl = tmpl.Replace("##TITLE##", abstracts.AbstractTitle);
            // send email 

            if (sendMail(tmpl, "Abstract Rejected by Qiyas ", abstracts.MainAuthor.Email, currentPage, "", null))
                return true;

            return false;
        }

        public static bool SendSubmitAbstractEmail(Page currentPage, string abstractNumber, string Category, string title, string name, string authors, string email, string namefull)
        {
            string tmplName = "FinalSubmitAbstractTemplate.html", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", name);
            tmpl = tmpl.Replace("##NAMEFULL##", namefull);
            tmpl = tmpl.Replace("##ABSTRACTNUMBER##", abstractNumber);
            tmpl = tmpl.Replace("##CATEGORY##", Category);
            tmpl = tmpl.Replace("##TITLE##", title);
            tmpl = tmpl.Replace("##AUTHORS##", authors);
            // send email 
            if (sendMail(tmpl, "Confirmation of abstract receipt By Qiyas #" + abstractNumber, email))
                return true;

            return false;
        }


        public static bool SendSubmitAbstractEmail(Page currentPage, BusinessLogicLayer.Entities.Conference.Abstracts abstracts, MemoryStream stream)
        {
            string tmplName = "FinalSubmitAbstractTemplate.html", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }
            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", abstracts.MainAuthor.City);
            tmpl = tmpl.Replace("##COUNTRY##", abstracts.MainAuthor.Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", abstracts.MainAuthor.PhoneNumberAreaCode, abstracts.MainAuthor.PhoneNumber));
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", abstracts.AuthorContactName);
            tmpl = tmpl.Replace("##NAMEFULL##", abstracts.AuthorContactNameFull);
            tmpl = tmpl.Replace("##ABSTRACTNUMBER##", abstracts.ABCode);
            tmpl = tmpl.Replace("##CATEGORY##", abstracts.CurrentConferenceCategory.CategoryName);
            tmpl = tmpl.Replace("##TITLE##", abstracts.AbstractTitle);
            tmpl = tmpl.Replace("##AUTHORS##", abstracts.AbstractAuthors);
            // send email 
            if (sendMail(tmpl, "Confirmation of abstract receipt By Qiyas #" + abstracts.ABCode, abstracts.MainAuthor.Email, currentPage, "", stream))
                return true;

            return false;
        }

        #endregion
        public static bool SendUserSendEmail(Page currentPage, BusinessLogicLayer.Entities.Conference.Abstracts abstracts, string Title, string Subject, string Email)
        {
            string tmplName = "UserSendEmail.htm", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", abstracts.MainAuthor.City);
            tmpl = tmpl.Replace("##COUNTRY##", abstracts.MainAuthor.Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", abstracts.MainAuthor.PhoneNumberAreaCode, abstracts.MainAuthor.PhoneNumber));
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", abstracts.AuthorContactName);
            tmpl = tmpl.Replace("##NAMEFULL##", abstracts.AuthorContactNameFull);
            tmpl = tmpl.Replace("##TITLE##", abstracts.AbstractTitle);
            tmpl = tmpl.Replace("##CODE##", abstracts.AbstractTitle);
            tmpl = tmpl.Replace("##CONTENT##", Subject);
            // send email 

            if (sendMail(tmpl, Title, Email, currentPage, "", null))
                return true;

            return false;
        }

        public static bool SendUserSendEmailWithContent(Page currentPage, BusinessLogicLayer.Entities.Conference.Abstracts abstracts, string Title, string Subject, string Email, MemoryStream contents)
        {
            string tmplName = "UserSendEmail.htm", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", abstracts.MainAuthor.City);
            tmpl = tmpl.Replace("##COUNTRY##", abstracts.MainAuthor.Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", abstracts.MainAuthor.PhoneNumberAreaCode, abstracts.MainAuthor.PhoneNumber));
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", abstracts.AuthorContactName);
            tmpl = tmpl.Replace("##NAMEFULL##", abstracts.AuthorContactNameFull);
            tmpl = tmpl.Replace("##TITLE##", abstracts.AbstractTitle);
            tmpl = tmpl.Replace("##CODE##", abstracts.AbstractTitle);
            tmpl = tmpl.Replace("##CONTENT##", Subject);
            // send email 

            if (sendMail(tmpl, Title, Email, currentPage, "", contents))
                return true;

            return false;
        }

        public static bool SendReviewerSubmissionEmail(Page currentPage, BusinessLogicLayer.Entities.Conference.Abstracts abstracts, string authorName, string authorEmail, MemoryStream stream)
        {
            string tmplName = "ReviewerSubmission.html", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }
            //tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            //tmpl = tmpl.Replace("##CITY##", abstracts.MainAuthor.City);
            //tmpl = tmpl.Replace("##COUNTRY##", abstracts.MainAuthor.Country);
            //tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", abstracts.MainAuthor.PhoneNumberAreaCode, abstracts.MainAuthor.PhoneNumber));
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", authorName);
            //tmpl = tmpl.Replace("##NAMEFULL##", abstracts.AuthorContactNameFull);
            tmpl = tmpl.Replace("##ABSTRACTNUMBER##", abstracts.ABCode);
            tmpl = tmpl.Replace("##CATEGORY##", abstracts.CurrentConferenceCategory.CategoryName);
            tmpl = tmpl.Replace("##TITLE##", abstracts.AbstractTitle);
            tmpl = tmpl.Replace("##AUTHORS##", abstracts.AbstractAuthors);
            // send email 
            if (sendMail(tmpl, "Abstract Review Assignment #" + abstracts.ABCode, authorEmail, currentPage, "", stream))
                return true;

            return false;
        }

        public static bool SendSignupEmail(Page currentPage, string Name, string City, string Country, string PhoneNumber, string UserName, string Password, string VerificationCode, string Email)
        {
            string tmplName = "SignupEmail.html", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }
            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", City);
            tmpl = tmpl.Replace("##COUNTRY##", Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", PhoneNumber);
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", Name);
            tmpl = tmpl.Replace("##NAMEFULL##", Name);
            tmpl = tmpl.Replace("##USERNAME##", UserName);
            tmpl = tmpl.Replace("##PASSWORD##", Password);
            tmpl = tmpl.Replace("##VERIFY##", VerificationCode);
            // send email 
            if (sendMail(tmpl, "Sign up for Qiyas", Email, currentPage, "", null))
                return true;

            return false;
        }

        public static bool SendForgetPasswordEmail(Page currentPage, string Name, string City, string Country, string PhoneNumber, string UserName, string Password, string VerificationCode, string Email)
        {
            string tmplName = "ForgetPassword.html", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }
            tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
            tmpl = tmpl.Replace("##CITY##", City);
            tmpl = tmpl.Replace("##COUNTRY##", Country);
            tmpl = tmpl.Replace("##PHONENUMBER##", PhoneNumber);
            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##NAME##", Name);
            tmpl = tmpl.Replace("##NAMEFULL##", Name);
            tmpl = tmpl.Replace("##USERNAME##", UserName);
            tmpl = tmpl.Replace("##PASSWORD##", Password);
            tmpl = tmpl.Replace("##VERIFY##", VerificationCode);
            // send email 
            if (sendMail(tmpl, "Sign up for Qiyas", Email, currentPage, "", null))
                return true;

            return false;
        }

        public static bool SendSubmitAbstractAdministrationEmail(Page currentPage, string abstractNumber, string topic, string title, string name, string email)
        {
            string tmplName = "AbstractSubmissionAdministration.htm", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##ABSTRACTNUMBER##", abstractNumber);
            tmpl = tmpl.Replace("##TOPIC##", topic);
            tmpl = tmpl.Replace("##TITLE##", title);
            // send email 
            if (sendMail(tmpl, "Successfull Abstract Submission #" + abstractNumber, email))
                return true;

            return false;
        }
        public static bool SendForgetPasswordEmail(Page currentPage, string title, string body, string email)
        {
            string tmplName = "ForgetPassword.html", tmpl = string.Empty;

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##EMAILTITLE##", title);
            tmpl = tmpl.Replace("##EMAILCONTENT##", body);

            // send email 
            if (sendMail(tmpl, title, email))
                return true;

            return false;
        }

        public static bool SendActivationEmail(Page currentPage, string activationCode, string email)
        {
            string tmplName = "ForgetPassword.html", tmpl = string.Empty;
            string title, body;
            title = "Quality Management Site - Email Activation";
            body = "Thank you for registering in the quality management site kindly <a href=\"" + System.Configuration.ConfigurationManager.AppSettings["URLHome"] + "/AccountActivation.aspx?ActivationCode=" + activationCode + "\">click here</a> to activate your account";

            try
            {
                tmpl = getEmailTemplate(currentPage, tmplName);
            }
            catch
            {
                // error loading template file
                throw new Exception(string.Format("Can't open template file ({0}), make sure that the file exists in the 'EmailTemplates' path defined in web.config ", tmplName));
            }

            // replace ##xxx## with appropriate values
            tmpl = tmpl.Replace("##EMAILTITLE##", title);
            tmpl = tmpl.Replace("##EMAILCONTENT##", body);

            // send email 
            if (sendMail(tmpl, title, email))
                return true;

            return false;
        }
        private static string getEmailTemplate(Page currentPage, string TemplateName)
        {
            string tmpl = string.Empty;
            // load template file
            StreamReader streamReader = new StreamReader(currentPage.Server.MapPath(BusinessLogicLayer.Common.EmailTemplates + TemplateName));
            tmpl = streamReader.ReadToEnd();
            streamReader.Close();
            return tmpl;
        }


        public static bool sendMail(string body, string subject, string toUser)
        {
            // mail parameters
            string fromEmail = "termauser@gmail.com";
            if (BusinessLogicLayer.Common.FromEmail != null)
                fromEmail = BusinessLogicLayer.Common.FromEmail;

            string MailServer = "smtp.gmail.com";

            MailServer = BusinessLogicLayer.Common.MailServer;

            SmtpClient client = new SmtpClient(MailServer);
            NetworkCredential cred = new NetworkCredential(BusinessLogicLayer.Common.MailUser, ConfigurationManager.AppSettings["MailPassowrd"].ToString());
            client.EnableSsl = BusinessLogicLayer.Common.EnableSSL.ToString().ToLowerInvariant() == "true" ? true : false;
            // Add credentials if the SMTP server requires them.        
            if (!BusinessLogicLayer.Common.MailPort.ToString().Equals(""))
                client.Port = Convert.ToInt32(BusinessLogicLayer.Common.MailPort.ToString());


            client.UseDefaultCredentials = false;
            client.Credentials = cred;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            //if (MyValidation.isEmail(toUser))
            message.To.Add(toUser);
            //message.Bcc.Add(toUser);
            // Create a message and set up the recipients.            


            try
            {
                // Thread t = new Thread();
                client.Send(message);
            }
            catch (Exception ex)
            {
                // error loading template file
                //throw new ErrorException(ex.Message);
                return false;
            }

            // also send internal msg
            //UserMsg msg = new UserMsg();
            //msg.FromUserID = SManager.getUserID(currentPage);
            //msg.MsgTopic = MyMsgTopic.TermEval;
            //msg.Msg = body;
            //try
            //{
            //    MsgManager.sendBroadCastMsg(usrList, msg);
            //}
            //catch (Exception ex)
            //{
            //    // error loading template file
            //    //throw new ErrorException(string.Format("Can't send message to ({0})", msg.ToUserID));
            //}
            return true;
        }

        public static bool sendMail(string body, string subject, string toUser, Page page, string fileAttachment, MemoryStream stream)
        {
            // mail parameters
            string fromEmail = "termauser@gmail.com";
            if (BusinessLogicLayer.Common.FromEmail != null)
                fromEmail = BusinessLogicLayer.Common.FromEmail.ToString();

            string MailServer = "smtp.gmail.com";
            MailServer = BusinessLogicLayer.Common.MailServer;

            SmtpClient client = new SmtpClient(MailServer);
            NetworkCredential cred = new NetworkCredential(BusinessLogicLayer.Common.FromEmail, BusinessLogicLayer.Common.MailPassowrd);
            client.EnableSsl = BusinessLogicLayer.Common.EnableSSL.ToString().ToLowerInvariant() == "true" ? true : false;
            // Add credentials if the SMTP server requires them.        
            if (!BusinessLogicLayer.Common.MailPort.ToString().Equals(""))
                client.Port = Convert.ToInt32(BusinessLogicLayer.Common.MailPort.ToString());


            client.UseDefaultCredentials = false;
            client.Credentials = cred;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.Subject = subject;
            //message.Body = body;
            message.IsBodyHtml = true;

            //if (MyValidation.isEmail(toUser))
            message.To.Add(toUser);
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            //LinkedResource logo = new LinkedResource(page.MapPath("~/images/bg-top_email.jpg"));
            LinkedResource logo = new LinkedResource(page.MapPath("~/images/bg-top_email.jpg"));
            logo.ContentId = "conferencelogo";
            htmlView.LinkedResources.Add(logo);
            message.AlternateViews.Add(htmlView);
            //if(stream != null)
            //{

            //    Attachment a = new Attachment(stream, "application/pdf");
            //    a.ContentId = "Abstract Submission";
            //    message.Attachments.Add(a);
            //}
            //message.Bcc.Add(toUser);
            // Create a message and set up the recipients.            


            try
            {
                // Thread t = new Thread();
                client.Send(message);
            }
            catch (Exception ex)
            {
                // error loading template file
                //throw new ErrorException(ex.Message);
                return false;
            }

            // also send internal msg
            //UserMsg msg = new UserMsg();
            //msg.FromUserID = SManager.getUserID(currentPage);
            //msg.MsgTopic = MyMsgTopic.TermEval;
            //msg.Msg = body;
            //try
            //{
            //    MsgManager.sendBroadCastMsg(usrList, msg);
            //}
            //catch (Exception ex)
            //{
            //    // error loading template file
            //    //throw new ErrorException(string.Format("Can't send message to ({0})", msg.ToUserID));
            //}
            return true;
        }



        public static bool sendMailWithError(string body, string subject, string toUser, out string errorMessage)
        {
            // mail parameters
            string fromEmail = "termauser@gmail.com";
            fromEmail = BusinessLogicLayer.Common.FromEmail;

            string MailServer = "smtp.gmail.com";

            MailServer = BusinessLogicLayer.Common.MailServer;

            SmtpClient client = new SmtpClient(MailServer);
            NetworkCredential cred = new NetworkCredential(BusinessLogicLayer.Common.MailUser, BusinessLogicLayer.Common.MailPassowrd);
            client.EnableSsl = BusinessLogicLayer.Common.EnableSSL.ToLowerInvariant() == "true" ? true : false;
            // Add credentials if the SMTP server requires them.        
            if (!BusinessLogicLayer.Common.MailPort.ToString().Equals(""))
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["MailPort"].ToString());


            client.UseDefaultCredentials = false;
            client.Credentials = cred;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            //if (MyValidation.isEmail(toUser))
            message.To.Add(toUser);
            //message.Bcc.Add(toUser);
            // Create a message and set up the recipients.            


            try
            {
                // Thread t = new Thread();
                client.Send(message);
                errorMessage = "";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + "<br />" + ex.InnerException;
                // error loading template file
                //throw new ErrorException(ex.Message);
                return false;
            }

            // also send internal msg
            //UserMsg msg = new UserMsg();
            //msg.FromUserID = SManager.getUserID(currentPage);
            //msg.MsgTopic = MyMsgTopic.TermEval;
            //msg.Msg = body;
            //try
            //{
            //    MsgManager.sendBroadCastMsg(usrList, msg);
            //}
            //catch (Exception ex)
            //{
            //    // error loading template file
            //    //throw new ErrorException(string.Format("Can't send message to ({0})", msg.ToUserID));
            //}
            return true;
        }
        #endregion

        #region Send Email Event
        // A delegate type for hooking up Send Email notifications.
        public delegate bool SendEmailEventHandler(object sender, EmailSenderEventArgs e);
        public event SendEmailEventHandler SendEmailEvent;
        public void OnSendEmail(EmailSenderEventArgs e)
        {
            if (SendEmailEvent != null)
                SendEmailEvent(this, e);
        }

        public bool SendEmail(object sender, EmailSenderEventArgs e)
        {

            bool result = false;
            string template = string.Empty;
            string title = string.Empty;
            if (e.CurrentConference == null) return result;
            if (e.EmailType != EmailTypes.Custom)
            {
                BusinessLogicLayer.Entities.Conference.EmailTemplate emailTemplate = new BusinessLogicLayer.Components.Conference.EmailTemplateLogic().GetTemplate((int)e.EmailType, e.CurrentConference.ConferenceId, e.LanguageId);

                if (emailTemplate == null) return result;

                template = emailTemplate.EmailContent;
                title = emailTemplate.Name;
                switch (e.EmailType)
                {
                    case EmailTypes.Signup:
                        template = GetTemplateUserData(template, e);
                        break;
                    case EmailTypes.Register:
                        template = GetTemplateUserData(template, e);
                        break;
                    case EmailTypes.AdminEmailGeneralTemplate:
                        template = template.Replace("##CUSTOMBODY##", e.InputObject == null ? string.Empty : e.InputObject.ToString());
                        break;
                    case EmailTypes.UserEmailGeneralTemplate:
                        template = template.Replace("##CUSTOMBODY##", e.InputObject == null ? string.Empty : e.InputObject.ToString());
                        break;
                    case EmailTypes.ForgotPassword:
                        template = GetTemplateUserData(template, e);
                        break;
                    case EmailTypes.AbstractCancelled:
                    case EmailTypes.AbstractEdited:
                    case EmailTypes.AbstractOralAccepted:
                    case EmailTypes.AbstractPosterAccepted:
                    case EmailTypes.AbstractRejected:
                    case EmailTypes.AbstractRequireRevise:
                    case EmailTypes.AbstractReviewed:
                    case EmailTypes.AbstractSubmitted:
                    case EmailTypes.AbstractWaitingReview:
                        template = GetTemplateAbstractData(template, e);
                        break;
                    default:
                        return result;
                }
            }
            else
            {
                template = GetTemplateCustomData(e.InputObject.ToString(), e);
                title = e.EmailTitle;
            }
            result = sendMailNew(template, title, e.ToUser, e.CurrentPage, e.FileAttachment, e.FileMemoryStream);
            return result;
        }

        public static bool sendMailNew(string body, string subject, string toUser, Page page, string fileAttachment, MemoryStream stream)
        {
            // mail parameters
            string fromEmail = "termauser@gmail.com";
            if (BusinessLogicLayer.Common.FromEmail != null)
                fromEmail = BusinessLogicLayer.Common.FromEmail.ToString();

            string MailServer = "smtp.gmail.com";
            MailServer = BusinessLogicLayer.Common.MailServer;

            SmtpClient client = new SmtpClient(MailServer);
            NetworkCredential cred = new NetworkCredential(BusinessLogicLayer.Common.FromEmail, BusinessLogicLayer.Common.MailPassowrd);
            client.EnableSsl = BusinessLogicLayer.Common.EnableSSL.ToString().ToLowerInvariant() == "true" ? true : false;
            // Add credentials if the SMTP server requires them.        
            if (!BusinessLogicLayer.Common.MailPort.ToString().Equals(""))
                client.Port = Convert.ToInt32(BusinessLogicLayer.Common.MailPort.ToString());


            client.UseDefaultCredentials = false;
            client.Credentials = cred;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage();

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            //if (MyValidation.isEmail(toUser))

            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            //LinkedResource logo = new LinkedResource(page.MapPath("~/images/bg-top_email.jpg"));

            //LinkedResource logo = new LinkedResource(page.MapPath("~/images/bg-top_email.jpg"));
            //logo.ContentId = "conferencelogo";
            //htmlView.LinkedResources.Add(logo);
            //message.AlternateViews.Add(htmlView);
            if (stream != null)
            {

                Attachment a = new Attachment(stream, "application/pdf");
                a.ContentId = "attachment";
                a.Name = "attachment.pdf";
                message.Attachments.Add(a);
            }
            //message.Bcc.Add(toUser);
            // Create a message and set up the recipients.            


            try
            {
                message.From = new MailAddress(fromEmail);
                message.To.Add(toUser);
                // Thread t = new Thread();
                client.Send(message);
            }
            catch (Exception ex)
            {
                // error loading template file
                //throw new ErrorException(ex.Message);
                return false;
            }

            // also send internal msg
            //UserMsg msg = new UserMsg();
            //msg.FromUserID = SManager.getUserID(currentPage);
            //msg.MsgTopic = MyMsgTopic.TermEval;
            //msg.Msg = body;
            //try
            //{
            //    MsgManager.sendBroadCastMsg(usrList, msg);
            //}
            //catch (Exception ex)
            //{
            //    // error loading template file
            //    //throw new ErrorException(string.Format("Can't send message to ({0})", msg.ToUserID));
            //}
            return true;
        }

        private string GetTemplateUserData(string template, EmailSenderEventArgs e)
        {
            if (e.CurrentPerson != null)
            {
                #region Template User
                template = template.Replace("##DATE##", DateTime.Now.ToLongDateString());
                template = template.Replace("##CITY##", e.CurrentPerson.MainPersonAddress.City);
                template = template.Replace("##COUNTRY##", e.CurrentPerson.MainPersonAddress.CountryName);
                template = template.Replace("##PHONENUMBER##", e.CurrentPerson.PersonHomePhoneMain);
                template = template.Replace("##MOBILE##", e.CurrentPerson.PersonMobileMain);
                // replace ##xxx## with appropriate values
                template = template.Replace("##NAME##", e.CurrentPerson.DisplayName);
                template = template.Replace("##NAMEFULL##", e.CurrentPerson.FullName);
                template = template.Replace("##USERNAME##", e.CurrentPerson.UserName);
                //input object in signup email is password
                template = template.Replace("##PASSWORD##", e.InputObject == null ? string.Empty : e.InputObject.ToString());
                template = template.Replace("##VERIFY##", e.CurrentPerson.Credentials.ActivationCode);
                #endregion
            }
            return template;
        }


        private string GetTemplateCustomData(string template, EmailSenderEventArgs e)
        {
            if (e.CurrentPerson != null)
            {
                #region Template User
                template = template.Replace("##DATE##", DateTime.Now.ToLongDateString());
                template = template.Replace("##CITY##", e.CurrentPerson.MainPersonAddress.City);
                template = template.Replace("##COUNTRY##", e.CurrentPerson.MainPersonAddress.CountryName);
                template = template.Replace("##PHONENUMBER##", e.CurrentPerson.PersonHomePhoneMain);
                template = template.Replace("##MOBILE##", e.CurrentPerson.PersonMobileMain);
                // replace ##xxx## with appropriate values
                template = template.Replace("##NAME##", e.CurrentPerson.DisplayName);
                template = template.Replace("##NAMEFULL##", e.CurrentPerson.FullName);
                template = template.Replace("##USERNAME##", e.CurrentPerson.UserName);
                #endregion
            }
            return template;
        }

        public static string GetTemplateClearCustomData(string template)
        {
            // if (e.CurrentPerson != null)
            {
                #region Template User
                template = template.Replace("##DATE##", DateTime.Now.ToLongDateString());
                template = template.Replace("##CITY##", "");
                template = template.Replace("##COUNTRY##", "");
                template = template.Replace("##PHONENUMBER##", "");
                template = template.Replace("##MOBILE##", "");
                // replace ##xxx## with appropriate values
                template = template.Replace("##NAME##", "");
                template = template.Replace("##NAMEFULL##", "");
                template = template.Replace("##USERNAME##", "");
                #endregion
            }
            return template;
        }


        private string GetTemplateAbstractData(string tmpl, EmailSenderEventArgs e)
        {
            if (e.CurrentAbstract != null)
            {
                tmpl = tmpl.Replace("##DATE##", DateTime.Now.ToLongDateString());
                tmpl = tmpl.Replace("##CITY##", e.CurrentAbstract.MainAuthor.City);
                tmpl = tmpl.Replace("##COUNTRY##", e.CurrentAbstract.MainAuthor.Country);
                tmpl = tmpl.Replace("##PHONENUMBER##", String.Format("{0} - {1}", e.CurrentAbstract.MainAuthor.PhoneNumberAreaCode, e.CurrentAbstract.MainAuthor.PhoneNumber));
                // replace ##xxx## with appropriate values
                tmpl = tmpl.Replace("##NAME##", e.CurrentAbstract.AuthorContactName);
                tmpl = tmpl.Replace("##NAMEFULL##", e.CurrentAbstract.AuthorContactNameFull);
                tmpl = tmpl.Replace("##TITLE##", e.CurrentAbstract.AbstractTitle);
                tmpl = tmpl.Replace("##ABSTRACTNUMBER##", e.CurrentAbstract.ABCode);
                tmpl = tmpl.Replace("##CATEGORY##", e.CurrentAbstract.CurrentConferenceCategory.CategoryName);
                tmpl = tmpl.Replace("##AUTHORS##", e.CurrentAbstract.AbstractAuthors);
            }
            return tmpl;
        }


        #endregion

    }
}