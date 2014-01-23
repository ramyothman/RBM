using Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.Forms
{
    public partial class Polls : BaseControl
    {
        public BusinessLogicLayer.Entities.FormBuilder.FormField DataSource { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //return;
            if (!IsPostBack)
            {
                ModuleTitleText.InnerText = ModuleTitle;
            }
            BusinessLogicLayer.Entities.FormBuilder.FormDocument document = BusinessLogicLayer.Common.FormDocumentLogic.GetByID(9);
            if(document.FormFields.Count > 0)
                DataSource = document.FormFields[0];
            if (Request.Cookies["MnatiqPoll"] == null || string.IsNullOrEmpty(Request.Cookies["MnatiqPoll"].Values[DataSource.FormFieldId.ToString()]))
            {
                CommonWeb.Common.PollGenerator.GeneratePoll(PollQuestionContainer, document);
                //Answers.Visible = false;
            }
            else
            {
                //Questions.Visible = false;
                Answers.InnerHtml = new ControlsManagement().GetPollResult(DataSource.FormFieldId,"~/Controls/Forms/PollResult.ascx");
                Answers.Style["display"] = "block";
            }
            
        }


        protected void VoteBtn_Click(object sender, EventArgs e)
        {

        }

        protected void ResultBtn_Click(object sender, EventArgs e)
        {

        }
    }
}