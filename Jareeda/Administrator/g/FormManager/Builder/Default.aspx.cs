using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using BusinessLogicLayer.Entities.JSON;
using System.Text;
using Administrator.Code;

namespace Administrator.g.FormManager.Builder
{
    public partial class Default : Code.AdminBase
    {
        public BusinessLogicLayer.Entities.FormBuilder.FormDocument CurrentSurvey
        {
            set
            {
                Session["FormDocument"] = value;
            }
            get
            {
                if (Session["FormDocument"] == null)
                    Session["FormDocument"] = new BusinessLogicLayer.Entities.FormBuilder.FormDocument();
                return Session["FormDocument"] as BusinessLogicLayer.Entities.FormBuilder.FormDocument;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["code"]))
                {
                    int surveyId = 0;
                    Int32.TryParse(Request["code"], out surveyId);
                    CurrentSurvey = BusinessLogicLayer.Common.FormDocumentLogic.GetByID(surveyId);


                    if (CurrentSurvey != null)
                    {

                        //MasterPages_MainPortal master = this.Master as MasterPages_MainPortal;
                        //if (master != null)
                        //    master.NotificationTitleString = CurrentSurvey.SurveyTitle;
                        //CurrentSurvey.CurrentLanguage = 1;

                        SurveyJSON jsonSurvey = GetJSONSurvey();
                        string jsonString = JsonConvert.SerializeObject(jsonSurvey);
                        hiddenJSONLoad.Add("JSONSurvey", jsonString);
                    }
                    //ViewState["PageTitleState"] = "Test Value";
                }
            }
        }


        #region Helper
        private SurveyJSON GetJSONSurvey()
        {
            SurveyJSON survey = new SurveyJSON();
            if (CurrentSurvey != null)
            {
                survey.Description = CurrentSurvey.Description;
                survey.LanguageCode = "";
                survey.Title = CurrentSurvey.Title;
                txtSurveySubmitReply.Html = CurrentSurvey.ConfirmationText;
                chkSendEmail.Checked = CurrentSurvey.SendEmail;
            }


            foreach (BusinessLogicLayer.Entities.FormBuilder.FormField question in CurrentSurvey.FormFields)
            {
                QuestionsJSON questionJSON = new QuestionsJSON();
                questionJSON.Help = question.HelpText;
                questionJSON.Title = question.Title;
                questionJSON.HasOther = question.HasOther;
                questionJSON.QuestionOrder = question.FormFieldOrder;
                questionJSON.Id = question.FormFieldId;
                questionJSON.IsRequired = question.IsRequired;
                questionJSON.IsSection = question.IsSection;
                questionJSON.IsContactEmail = question.IsContactEmail;
                questionJSON.IsContactMobile = question.IsContactMobile;
                questionJSON.QuestionType = question.FormFieldTypeId;
                int count = 0;
                foreach (BusinessLogicLayer.Entities.FormBuilder.FormFieldColumn column in question.FormFieldColumns)
                {
                    if (count == 0)
                        questionJSON.Column1 = column.FieldColumnValue;
                    else if (count == 1)
                        questionJSON.Column2 = column.FieldColumnValue;
                    else if (count == 2)
                        questionJSON.Column3 = column.FieldColumnValue;
                    else if (count == 3)
                        questionJSON.Column4 = column.FieldColumnValue;
                    else if (count == 4)
                        questionJSON.Column5 = column.FieldColumnValue;
                    count++;
                }
                questionJSON.ColumnCount = count;
                foreach (BusinessLogicLayer.Entities.FormBuilder.FormFieldValue answer in question.FormFieldValues)
                {
                    AnswerJSON answerJSON = new AnswerJSON();
                    answerJSON.AnswerText = answer.FieldValue;
                    answerJSON.Id = answer.FormFieldValueId;
                    answerJSON.IsOther = answer.IsOther;
                    questionJSON.Answeres.Add(answerJSON);
                }
                survey.Questions.Add(questionJSON);
            }
            return survey;
        }
        #endregion

        protected void saveCallBack_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();

            StringReader reader = new StringReader(e.Parameter);
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                SurveyJSON p = (SurveyJSON)serializer.Deserialize(jsonReader, typeof(SurveyJSON));
                if (p != null)
                {
                    #region SavingSurvey

                    //int languageId = BusinessLogicLayer.Common.LanguagesLogic.GetByLanguageCode("en-us").LanguageId;
                    CurrentSurvey.ConfirmationText = txtSurveySubmitReply.Html;
                    CurrentSurvey.SendEmail = chkSendEmail.Checked;
                    CurrentSurvey.Description = p.Description;


                    CurrentSurvey.Title = p.Title;
                    if (CurrentSurvey.NewRecord)
                    {
                        CurrentSurvey.FormDocumentStatusID = 1;
                        CurrentSurvey.StartDate = DateTime.Now;
                        BusinessLogicLayer.Common.FormDocumentLogic.Insert(CurrentSurvey);
                    }
                    else
                        BusinessLogicLayer.Common.FormDocumentLogic.Update(CurrentSurvey, CurrentSurvey.FormDocumentID);
                    int orderId = 1;
                    StringBuilder questionsIds = new StringBuilder();

                    foreach (QuestionsJSON q in p.Questions)
                    {
                        if (q.Id == -1)
                        {
                            #region Adding Question
                            BusinessLogicLayer.Entities.FormBuilder.FormField question = new BusinessLogicLayer.Entities.FormBuilder.FormField();
                            question.HasOther = q.HasOther;
                            question.IsRequired = Convert.ToBoolean(q.IsRequired);
                            question.IsSection = q.IsSection;
                            question.IsContactEmail = q.IsContactEmail;
                            question.IsContactMobile = q.IsContactMobile;
                            question.FormFieldOrder = q.QuestionOrder;
                            question.FormFieldTypeId = q.QuestionType;
                            question.FormDocumentId = CurrentSurvey.FormDocumentID;
                            question.HelpText = q.Help;
                            question.Title = q.Title;
                            BusinessLogicLayer.Common.FormFieldLogic.Insert(question);
                            BusinessLogicLayer.Common.FormFieldColumnLogic.DeleteByFormFieldId(question.FormFieldId);
                            for (int i = 0; i < q.ColumnCount; i++)
                            {
                                if (i == 0)
                                    BusinessLogicLayer.Common.FormFieldColumnLogic.Insert(question.FormFieldId, q.Column1, "", 10);
                                else if (i == 1)
                                    BusinessLogicLayer.Common.FormFieldColumnLogic.Insert(question.FormFieldId, q.Column2, "", 10);
                                else if (i == 2)
                                    BusinessLogicLayer.Common.FormFieldColumnLogic.Insert(question.FormFieldId, q.Column3, "", 10);
                                else if (i == 3)
                                    BusinessLogicLayer.Common.FormFieldColumnLogic.Insert(question.FormFieldId, q.Column4, "", 10);
                                else if (i == 4)
                                    BusinessLogicLayer.Common.FormFieldColumnLogic.Insert(question.FormFieldId, q.Column5, "", 10);
                            }
                            foreach (AnswerJSON a in q.Answeres)
                            {
                                if (a.Id == 0)
                                    continue;
                                BusinessLogicLayer.Entities.FormBuilder.FormFieldValue questionAnswer = new BusinessLogicLayer.Entities.FormBuilder.FormFieldValue();
                                questionAnswer.FieldGrade = 10;
                                questionAnswer.IsOther = a.IsOther;
                                questionAnswer.FormFieldId = question.FormFieldId;
                                questionAnswer.FieldValue = a.AnswerText;
                                BusinessLogicLayer.Common.FormFieldValueLogic.Insert(questionAnswer);
                            }
                            if (question.FormFieldTypeId == 3 || question.FormFieldTypeId == 4)
                            {
                                BusinessLogicLayer.Entities.FormBuilder.FormFieldValue questionAnswer = new BusinessLogicLayer.Entities.FormBuilder.FormFieldValue();
                                questionAnswer.FieldGrade = 10;
                                questionAnswer.IsOther = true;
                                questionAnswer.FormFieldId = question.FormFieldId;
                                questionAnswer.FieldValue = "";
                                BusinessLogicLayer.Common.FormFieldValueLogic.Insert(questionAnswer);
                            }
                            #endregion
                            questionsIds.Append(question.FormFieldId + ",");
                        }
                        else
                        {
                            #region Update Question
                            BusinessLogicLayer.Entities.FormBuilder.FormField question = BusinessLogicLayer.Common.FormFieldLogic.GetByID(q.Id);
                            question.CurrentDocument = CurrentSurvey;
                            question.HasOther = q.HasOther;
                            question.IsRequired = Convert.ToBoolean(q.IsRequired);
                            question.IsSection = q.IsSection;
                            question.IsContactEmail = q.IsContactEmail;
                            question.IsContactMobile = q.IsContactMobile;
                            question.FormFieldOrder = q.QuestionOrder;
                            question.FormFieldTypeId = q.QuestionType;
                            question.FormDocumentId = CurrentSurvey.FormDocumentID;
                            question.HelpText = q.Help;
                            question.Title = q.Title;
                            BusinessLogicLayer.Common.FormFieldLogic.Update(question, question.FormFieldId);

                            StringBuilder currentAnswersId = new StringBuilder();
                            foreach (AnswerJSON a in q.Answeres)
                            {
                                if (a.Id == -1)
                                {
                                    #region Adding Answer
                                    BusinessLogicLayer.Entities.FormBuilder.FormFieldValue questionAnswer = new BusinessLogicLayer.Entities.FormBuilder.FormFieldValue();
                                    questionAnswer.FieldGrade = 10;
                                    questionAnswer.FormFieldId = question.FormFieldId;
                                    questionAnswer.IsOther = a.IsOther;
                                    questionAnswer.FieldValue = a.AnswerText;
                                    BusinessLogicLayer.Common.FormFieldValueLogic.Insert(questionAnswer);

                                    #endregion
                                    currentAnswersId.Append(questionAnswer.FormFieldValueId + ",");
                                }
                                else if (a.Id != 0)
                                {
                                    #region Updating Answer
                                    BusinessLogicLayer.Entities.FormBuilder.FormFieldValue questionAnswer = BusinessLogicLayer.Common.FormFieldValueLogic.GetByID(a.Id);
                                    if (questionAnswer == null)
                                        continue;
                                    questionAnswer.CurrentFormField = question;
                                    questionAnswer.FieldGrade = 10;
                                    questionAnswer.IsOther = a.IsOther;
                                    questionAnswer.FieldValue = a.AnswerText;
                                    BusinessLogicLayer.Common.FormFieldValueLogic.Update(questionAnswer, questionAnswer.FormFieldValueId);
                                    #endregion
                                    currentAnswersId.Append(questionAnswer.FormFieldValueId + ",");
                                }

                            }
                            if (question.FormFieldTypeId == 3 || question.FormFieldTypeId == 4)
                            {
                                if (question.FormFieldValues == null || question.FormFieldValues.Count == 0)
                                {
                                    BusinessLogicLayer.Entities.FormBuilder.FormFieldValue questionAnswer = new BusinessLogicLayer.Entities.FormBuilder.FormFieldValue();
                                    questionAnswer.FieldGrade = 10;
                                    questionAnswer.IsOther = true;
                                    questionAnswer.FormFieldId = question.FormFieldId;
                                    questionAnswer.FieldValue = "";
                                    BusinessLogicLayer.Common.FormFieldValueLogic.Insert(questionAnswer);

                                    currentAnswersId.Append(questionAnswer.FormFieldValueId + ",");
                                }
                                else
                                {
                                    BusinessLogicLayer.Entities.FormBuilder.FormFieldValue questionAnswer = question.FormFieldValues[0];
                                    currentAnswersId.Append(questionAnswer.FormFieldValueId + ",");
                                }
                            }
                            if (currentAnswersId.Length > 0)
                            {
                                string lastAnswersIds = currentAnswersId.ToString().Substring(0, currentAnswersId.Length - 1);
                                BusinessLogicLayer.Common.FormFieldValueLogic.Delete(lastAnswersIds, question.FormFieldId.ToString());
                            }
                            #endregion
                            questionsIds.Append(question.FormFieldId + ",");

                        }

                        orderId++;
                    }
                    if (questionsIds.Length > 0)
                    {
                        string lastquestionsIds = questionsIds.ToString().Substring(0, questionsIds.Length - 1);
                        BusinessLogicLayer.Common.FormFieldLogic.Delete(lastquestionsIds, CurrentSurvey.FormDocumentID.ToString());
                    }

                    #endregion
                }
            }


        }

        protected void callbackPanelSettings_Callback(object source, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {

        }
    }
}