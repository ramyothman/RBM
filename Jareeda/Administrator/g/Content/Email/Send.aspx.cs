using CommonWeb.EmailManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.g.Content.Email
{
    public partial class Send : Code.AdminBase
    {
        List<BusinessLogicLayer.Entities.Persons.Person> Persons = null;// new List<BusinessLogicLayer.Entities.Persons.Person>();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (Persons == null)
            {
                Persons = BusinessLogicLayer.Common.PersonLogic.GetAll();
            }
            gridContacts.DataSource = Persons;
            gridContacts.DataBind();

            manager.SendEmailEvent += new EmailManager.SendEmailEventHandler(manager.SendEmail);
        }
        EmailManager manager = new EmailManager();
        protected void btnSendEmails_Click(object sender, EventArgs e)
        {
            int count = 0;
            List<object> list = gridContacts.GetSelectedFieldValues("BusinessEntityId");
            foreach (int item in list)
            {
                var person = (from x in Persons where x.BusinessEntityId == item select x).FirstOrDefault();
                if (person == null) continue;
                if (person.Email.Trim() == "") continue;
                CommonWeb.EmailManagement.EmailSenderEventArgs args = new CommonWeb.EmailManagement.EmailSenderEventArgs();
                args.EmailType = EmailManager.EmailTypes.Custom;
                args.CurrentPerson = person;
                args.EmailTitle = txtSubject.Text;
                args.InputObject = EmailContentHtmlEditor.Html;
                args.CurrentPage = this.Page;
                //TOOD: Conference Default Managemenet
                //args.LanguageId = ConferenceBasePage.GetCurrentPageLanguageId(this.Page);
                //args.CurrentConference = Code.RbmCommon.ConferenceBasePage.GetConferenceFromPage(this.Page);

                args.ToUser = person.EmailAddressPrimaryObject.Email;
                manager.OnSendEmail(args);
                count++;
            }
            string[] emailsSplit = txtEmail.Text.Split(',');
            foreach (string email in emailsSplit)
            {
                if (string.IsNullOrEmpty(email.Trim())) continue;
                string template = EmailManager.GetTemplateClearCustomData(EmailContentHtmlEditor.Html);
                EmailManager.sendMail(template, txtSubject.Text, email);
                count++;
            }

            //TODO: Conference Send Email Success
            //SuccessMessage.Visible = true;
            //string MessageText = "Email Sent Successfully To ##COUNT## Accounts";
            //SuccessMessage.InnerText = MessageText.Replace("##COUNT##", count.ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                List<object> list = gridContacts.GetSelectedFieldValues("BusinessEntityId");
                foreach (int item in list)
                {
                    var person = (from x in Persons where x.BusinessEntityId == item select x).FirstOrDefault();
                    if (person == null) continue;
                    if (person.Email.Trim() == "") continue;
                    CommonWeb.EmailManagement.EmailSenderEventArgs args = new CommonWeb.EmailManagement.EmailSenderEventArgs();
                    args.EmailType = EmailManager.EmailTypes.Custom;
                    args.CurrentPerson = person;
                    args.EmailTitle = txtSubject.Text;
                    args.InputObject = EmailContentHtmlEditor.Html;
                    args.CurrentPage = this.Page;
                    //TOOD: Conference Default Managemenet
                    //args.LanguageId = ConferenceBasePage.GetCurrentPageLanguageId(this.Page);
                    //args.CurrentConference = Code.RbmCommon.ConferenceBasePage.GetConferenceFromPage(this.Page);

                    args.ToUser = person.EmailAddressPrimaryObject.Email;
                    manager.OnSendEmail(args);
                    count++;
                }
                string[] emailsSplit = txtEmail.Text.Split(',');
                foreach (string email in emailsSplit)
                {
                    if (string.IsNullOrEmpty(email.Trim())) continue;
                    string template = EmailManager.GetTemplateClearCustomData(EmailContentHtmlEditor.Html);
                    EmailManager.sendMail(template, txtSubject.Text, email);
                    count++;
                }

                
                Session["Notification"] = "success";
                Response.Redirect("~/g/Content/Email/Send.aspx");
            }
            catch (Exception ex)
            {
                SetNotification("fail", ex.Message, "", this);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}