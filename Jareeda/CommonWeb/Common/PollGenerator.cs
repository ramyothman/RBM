using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLogicLayer.Entities;
using System.Collections;
using BusinessLogicLayer.Components;
using DevExpress.Web.ASPxEditors;
using BusinessLogicLayer.Entities.FormBuilder;
using System;
using System.Collections.Generic;


namespace CommonWeb.Common
{
   public static class PollGenerator
    {
        //public static QuestionsTemplates _QuestionTemplates = new QuestionsTemplates();
        private static void AddTextToDiv(HtmlGenericControl ResultsArea, string TextToBeAdded)
        {
            Label lbl = new Label();
            lbl.Text = TextToBeAdded;
            ResultsArea.Controls.Add(lbl);
        }

        private static void ControlsAdder(HtmlGenericControl ResultsArea, string Original, Control[] ControlsToBeAdded, string[] ReplacementStrings)
        {
            int x = 0;
            int y = 0;
            string temp = "";
            int counter = 0;
            foreach (string s in ReplacementStrings)
            {
                x = Original.IndexOf(s);
                y = x + s.Length;
                temp = Original.Substring(0, x);
                Original = Original.Substring(y);
                AddTextToPanel(ResultsArea, temp);
                if (ControlsToBeAdded.Length > counter)
                {
                    ResultsArea.Controls.Add(ControlsToBeAdded[counter]);
                    counter++;
                }


            }
            AddTextToPanel(ResultsArea, Original);

        }

        private static void AddTextToPanel(HtmlGenericControl ResultsArea, string TextToBeAdded)
        {
            HtmlGenericControl lbl = new HtmlGenericControl("h2");
            lbl.InnerText = TextToBeAdded;
            ResultsArea.Controls.Add(lbl);
        }

        private struct QuestionsTemplates
        {
            
            public static string Check = @"<div class=""vote"">	
							<h2>@QuestionTitle</h2>
							<div class=""vote"">
								@AnswerTextBox
							</div>
							<a href=""#"" class=""vote_btn"">صوت</a>
							<a href=""#"" class=""result_btn"">النتيجة</a>
						</div>";
            public static string Choice = @"<div class=""vote"">	
							<h2>@QuestionTitle</h2>
							<div class=""vote"">
								@AnswerTextBox
							</div>
							
						</div>";
        }

        private static void AddQuestion(BusinessLogicLayer.Entities.FormBuilder.FormField Q, HtmlGenericControl QuestionPanel)
        {
            if (Q.FormFieldType.Name == "Check")
            {
                QuestionPanel.Attributes.Add("rel",Q.FormFieldType.Name);
                AddTextToPanel(QuestionPanel, Q.Title);
                //Label QuestionTitle = new Label();
                //QuestionTitle.Text = Q.Title;
                ////-----
                //Label IsReqired = new Label();
                //IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
                ////-----
                //Label HelpText = new Label();
                //HelpText.Text = Q.HelpText;
                //-----
                HtmlGenericControl AnswerArea = new HtmlGenericControl("div");
                AnswerArea.Attributes.Add("class", "vote");
                //Panel AnswerArea = new Panel();

                foreach (BusinessLogicLayer.Entities.FormBuilder.FormFieldValue qa in Q.FormFieldValues)
                {
                    HtmlGenericControl contDiv = new HtmlGenericControl("div");
                    contDiv.Attributes.Add("class", "row");

                    CheckBox chckbx = new CheckBox();
                    chckbx.ID = "CheckAnswer" + qa.FormFieldValueId.ToString();
                    chckbx.Text = qa.FieldValue;
                    chckbx.Width = new Unit(100, UnitType.Percentage);
                    contDiv.Controls.Add(chckbx);
                    AnswerArea.Controls.Add(contDiv);
                    //AddTextToPanel(AnswerArea, "<br/>");
                }
                QuestionPanel.Controls.Add(AnswerArea);
                //-----
                //ControlsAdder(QuestionPanel, QuestionsTemplates.Check, new Control[2] { QuestionTitle, AnswerArea }, new String[2] { "@QuestionTitle", "@AnswerTextBox" });
            }

            else if (Q.FormFieldType.Name == "Choice")
            {
                QuestionPanel.Attributes.Add("rel", Q.FormFieldType.Name);
                AddTextToPanel(QuestionPanel, Q.Title);
                //-----
                //Label IsReqired = new Label();
                //IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
                ////-----
                //Label HelpText = new Label();
                //HelpText.Text = Q.HelpText;
                ////-----
                HtmlGenericControl AnswerArea = new HtmlGenericControl("div");
                AnswerArea.Attributes.Add("class", "vote");

                foreach (BusinessLogicLayer.Entities.FormBuilder.FormFieldValue qa in Q.FormFieldValues)
                {
                    HtmlGenericControl contDiv = new HtmlGenericControl("div");
                    contDiv.Attributes.Add("class", "row");
                    RadioButton chckbx = new RadioButton();
                    chckbx.GroupName = "ChoiceAnswer" + Q.FormFieldId;
                    chckbx.ID = "ChoiceAnswer" + qa.FormFieldValueId.ToString();
                    chckbx.Text = qa.FieldValue;
                    
                    chckbx.Width = new Unit(100, UnitType.Percentage);
                    contDiv.Controls.Add(chckbx);
                    AnswerArea.Controls.Add(contDiv);
                    //AddTextToPanel(AnswerArea, "<br/>");
                }

                //RadioButtonList rbl = new RadioButtonList();
                //rbl.ID = "AnswerList" + Q.FormFieldId.ToString();
                //foreach (FormFieldValue qa in Q.FormFieldValues)
                //{
                //    rbl.Items.Add(new ListItem(qa.FieldValue, qa.FormFieldValueId.ToString()));
                    
                //}

                //-----
                QuestionPanel.Controls.Add(AnswerArea);
                //ControlsAdder(QuestionPanel, QuestionsTemplates.Choice, new Control[2] { QuestionTitle, AnswerArea }, new String[2] { "@QuestionTitle", "@AnswerTextBox" });
            }
        }

        public static void GeneratePoll(HtmlGenericControl QuestionContainer,BusinessLogicLayer.Entities.FormBuilder.FormDocument document)
        {
            foreach (BusinessLogicLayer.Entities.FormBuilder.FormField field in document.FormFields)
            {
                HtmlGenericControl question = new HtmlGenericControl("div");
                question.Attributes.Add("class", "vote");
                question.ID = "Panel" + field.FormFieldId;
                AddQuestion(field, question);
                QuestionContainer.Controls.Add(question);
            }
        }

        private static void CollectSurveyUserAnswers(List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers, int SurveyId, int UserId)
        {
            FormSubmission sub = new FormSubmission();
            sub.FormDocumentID = SurveyId;
            sub.UserId = UserId;
            sub.SubmissionDate = DateTime.Now;
            sub.IsValid = true;
            BusinessLogicLayer.Common.FormSubmissionLogic.Insert(sub);
            foreach (BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua in SurveyUserAnswers)
            {
                ua.FormSubmissionId = sub.FormSubmissionId;
                BusinessLogicLayer.Common.FormSubmissionAnswerLogic.Insert(ua);
            }



        }
        static List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers;

        

        

        #region Collect Submission Answers
        private static List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> RetrieveUserAnswers(HtmlGenericControl ResultsArea)
        {
            List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers = new List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer>();
            string result = "";
            List<HtmlGenericControl> Panels = new List<HtmlGenericControl>();
            foreach (Control c in ResultsArea.Controls)
            {
                try
                {
                    HtmlGenericControl p = c as HtmlGenericControl;

                    if (p != null)
                    {
                        foreach (Control g in p.Controls)
                        {
                            HtmlGenericControl d = g as HtmlGenericControl;
                            if (d != null)
                            {
                                Panels.Add(p);
                            }
                        }
                    }
                }
                catch
                {

                }
            }

            foreach (HtmlGenericControl p in Panels)
            {
                BusinessLogicLayer.Entities.FormBuilder.FormField q = BusinessLogicLayer.Common.FormFieldLogic.GetByID(int.Parse(p.ID.Replace("Panel", "")));
                if (q.FormFieldType.Name == "Check")
                {
                    CollectCheckAnswer(ref SurveyUserAnswers, p, q);
                }
                else if (q.FormFieldType.Name == "Choice")
                {
                    CollectChoiceAnswer(ref SurveyUserAnswers, p, q);
                }
                
            }
            return SurveyUserAnswers;

        }


        private static void CollectCheckAnswer(ref List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers, HtmlGenericControl p, BusinessLogicLayer.Entities.FormBuilder.FormField q)
        {
            HtmlGenericControl answersArea = p.Controls[5] as HtmlGenericControl;
            //HtmlGenericControl AnswerArea = new HtmlGenericControl("div");
            if (answersArea == null) return;
            
            foreach (HtmlGenericControl li in answersArea.Controls)
            {
                CheckBox answer = li.Controls[0] as CheckBox;
                if (answer != null && answer.Checked)
                {
                    
                    BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                    ua.FormFieldId = q.FormFieldId;
                    ua.FormFieldValueId = Int32.Parse(answer.ID.ToString().Replace("CheckAnswer",""));
                    ua.Answer = answer.Text;
                    SurveyUserAnswers.Add(ua);
                    //break;
                }
            }

        }

        private static void CollectChoiceAnswer(ref List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers, HtmlGenericControl p, BusinessLogicLayer.Entities.FormBuilder.FormField q)
        {
            HtmlGenericControl answersArea = p.Controls[5] as HtmlGenericControl;
            //HtmlGenericControl AnswerArea = new HtmlGenericControl("div");
            if (answersArea == null) return;

            foreach (HtmlGenericControl li in answersArea.Controls)
            {
                RadioButton answer = li.Controls[0] as RadioButton;
                if (answer != null && answer.Checked)
                {

                    BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                    ua.FormFieldId = q.FormFieldId;
                    ua.FormFieldValueId = Int32.Parse(answer.ID.ToString().Replace("CheckAnswer", ""));
                    ua.Answer = answer.Text;
                    SurveyUserAnswers.Add(ua);
                    //break;
                }
            }
        }

        #endregion
    }
}
