using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Components.Conference;
using BusinessLogicLayer.Entities.Conference;

namespace Administrator.g.Content.Email.Template
{
    public partial class Save : Code.AdminBase
    {
        EmailTemplate template;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                FillFOrmControls();
            }
        }

        private void FillFOrmControls()
        {
            if (Request.QueryString["ID"] != null)
            {
                cbConference.DataBind();
                cbEmailType.DataBind();
                cbLang.DataBind();
                template = new EmailTemplateLogic().GetByID(Convert.ToInt32(Request.QueryString["ID"]));
                txtContent.Html = template.EmailContent;
                txtDesc.Text = template.Description;
                txtName.Text = template.Name;
                cbConference.SelectedIndex = cbConference.Items.FindByValue(template.ConferenceID).Index;
                cbEmailType.SelectedIndex = cbEmailType.Items.FindByValue(template.SystemEmailTypeID).Index;
                cbLang.SelectedIndex = cbLang.Items.FindByValue(template.LanguageID).Index;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            template = new EmailTemplate();
            template.EmailContent = txtContent.Html;
            template.Description = txtDesc.Text;
            template.Name = txtName.Text;
            template.ConferenceID = Convert.ToInt32(cbConference.Value);
            template.SystemEmailTypeID = Convert.ToInt32(cbEmailType.Value);
            template.LanguageID = Convert.ToInt32(cbLang.Value);
            if (Request.QueryString["ID"] != null)
                new EmailTemplateLogic().Update(template, Convert.ToInt32(Request.QueryString["ID"]));
            else
                new EmailTemplateLogic().Insert(template);
            Session["Notification"] = "success";
            Response.Redirect("Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}