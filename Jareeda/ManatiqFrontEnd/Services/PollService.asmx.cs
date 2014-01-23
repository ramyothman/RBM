using BusinessLogicLayer.Entities.FormBuilder;
using ManatiqFrontEnd.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Portal
{
    /// <summary>
    /// Summary description for PollService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    [System.Web.Script.Services.GenerateScriptType(typeof(PollData))]
    public class PollService : System.Web.Services.WebService
    {

        
        [WebMethod]

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool Vote(int FormFieldValueId, int FormFieldId)
        {
            BusinessLogicLayer.Entities.FormBuilder.FormField field = BusinessLogicLayer.Common.FormFieldLogic.GetByID(FormFieldId);
            BusinessLogicLayer.Entities.FormBuilder.FormFieldValue value = BusinessLogicLayer.Common.FormFieldValueLogic.GetByID(FormFieldValueId);
            if (field == null)
                return false;
            FormSubmission sub = new FormSubmission();
            sub.FormDocumentID = field.FormDocumentId;
            sub.UserId = 0;
            sub.SubmissionDate = DateTime.Now;
            sub.IsValid = true;
            BusinessLogicLayer.Common.FormSubmissionLogic.Insert(sub);

            BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
            ua.FormSubmissionId = sub.FormSubmissionId;
            ua.Answer = value.FieldValue;
            ua.FormFieldId = FormFieldId;
            ua.FormFieldValueId = FormFieldValueId;
            BusinessLogicLayer.Common.FormSubmissionAnswerLogic.Insert(ua);
            return true;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetPollResult(int FormFieldId)
        {
            return new ControlsManagement().GetPollResult(FormFieldId, "~/Controls/Forms/PollResult.ascx");
        }
    }
}
