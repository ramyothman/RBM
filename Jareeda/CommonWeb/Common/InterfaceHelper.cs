using System;
using System.Collections.Generic;
using System.Linq;
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



namespace CommonWeb.Common
{
    public static class InterfaceHelper
    {
        //public static QuestionsTemplates _QuestionTemplates = new QuestionsTemplates();
        public static void AddTextToDiv(HtmlGenericControl ResultsArea, string TextToBeAdded)
        {
            Label lbl = new Label();
            lbl.Text = TextToBeAdded;
            ResultsArea.Controls.Add(lbl);
        }

        public static void ControlsAdder(Panel ResultsArea, string Original, Control[] ControlsToBeAdded, string[] ReplacementStrings)
        {
            int x = 0;
            int y = 0;
            string temp="";
            int counter =0;
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

        private static void AddTextToPanel(Panel ResultsArea, string TextToBeAdded)
        {
            Label lbl = new Label();
            lbl.Text = TextToBeAdded;
            ResultsArea.Controls.Add(lbl);
        }

         public struct QuestionsTemplates
        {
             public static string Text = @"<table cellpadding='0' cellspacing='2' style='width: 100%;border-width: 0'><tr><td >@QuestionTitle</td><td width='100px'>@IsRequired</td></tr><tr><td colspan='2' class=""HelpSection"">@HelpText</td></tr><tr><td colspan='2'>@AnswerTextBox</td></tr></table><hr/>";
             public static string Paragraph = @"<table cellpadding='0' cellspacing='2' style='width: 100%;border-width: 0'><tr><td >@QuestionTitle</td><td width='100px'>@IsRequired</td></tr><tr><td colspan='2' class=""HelpSection"">@HelpText</td></tr><tr><td colspan='2'>@AnswerTextBox</td></tr></table><hr/>";
             public static string Check = @"<table cellpadding='0' cellspacing='2' style='width: 100%;border-width: 0'><tr><td >@QuestionTitle</td><td width='100px'>@IsRequired</td></tr><tr><td colspan='2' class=""HelpSection"">@HelpText</td></tr><tr><td colspan='2'>@AnswerTextBox</td></tr></table><hr/>";
             public static string Choice = @"<table cellpadding='0' cellspacing='2' style='width: 100%;border-width: 0'><tr><td >@QuestionTitle</td><td width='100px'>@IsRequired</td></tr><tr><td colspan='2' class=""HelpSection"">@HelpText</td></tr><tr><td colspan='2'>@AnswerTextBox</td></tr></table><hr/>";
        }

         public static void AddQuestion(BusinessLogicLayer.Entities.FormBuilder.FormField Q , Panel QuestionPanel)
         {
             if (Q.FormFieldType.Name == "Text")
             {
                 QuestionPanel.ToolTip = Q.FormFieldType.Name;
                 Label QuestionTitle = new Label();
                 QuestionTitle.Text = @"<span style='font-size:large;font-weight:bold'>"+ Q.Title +"</span>"; 
                 
                 //-----
                 Label IsReqired = new Label();
                 IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
                 //-----
                 Label HelpText = new Label();
                 HelpText.Text = Q.HelpText != null ? Q.HelpText : "";
                 //-----
                 TextBox txtAnswer = new TextBox();
                 txtAnswer.ID = String.Format("Answer{0}", Q.FormFieldValues[0].FormFieldValueId);
                 //-----
                 ControlsAdder(QuestionPanel, QuestionsTemplates.Text, new Control[4] {QuestionTitle, IsReqired, HelpText, txtAnswer }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
             }

             else if (Q.FormFieldType.Name == "Paragraph")
             {
                 QuestionPanel.ToolTip = Q.FormFieldType.Name;
                 Label QuestionTitle = new Label();
                 QuestionTitle.Text = @"<span style='font-size:large;font-weight:bold'>" + Q.Title + "</span>"; 
                 //-----
                 Label IsReqired = new Label();
                 IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
                 //-----
                 Label HelpText = new Label();
                 HelpText.Text = Q.HelpText;
                 //-----
                 TextBox txtAnswer = new TextBox();
                 txtAnswer.ID  = String.Format("Answer{0}", Q.FormFieldValues[0].FormFieldValueId);
                 txtAnswer.TextMode = TextBoxMode.MultiLine;
                 txtAnswer.Width = new Unit(400);
                 txtAnswer.Height = new Unit(100);
                 //-----
                 ControlsAdder(QuestionPanel, QuestionsTemplates.Paragraph, new Control[4] { QuestionTitle, IsReqired, HelpText, txtAnswer }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
             }

             else if (Q.FormFieldType.Name  == "Check")
             {
                 QuestionPanel.ToolTip = Q.FormFieldType.Name;
                 Label QuestionTitle = new Label();
                 QuestionTitle.Text = @"<span style='font-size:large;font-weight:bold'>" + Q.Title + "</span>"; 
                 //-----
                 Label IsReqired = new Label();
                 IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
                 //-----
                 Label HelpText = new Label();
                 HelpText.Text = Q.HelpText;
                 //-----
                 Panel AnswerArea = new Panel();

                 foreach (BusinessLogicLayer.Entities.FormBuilder.FormFieldValue qa in Q.FormFieldValues)
                 {
                     CheckBox chckbx = new CheckBox();
                     chckbx.ID = "CheckAnswer"+qa.FormFieldValueId.ToString();
                     chckbx.Text = qa.FieldValue;
                     chckbx.Width = new Unit(100, UnitType.Percentage);
                     AnswerArea.Controls.Add(chckbx);
                     AddTextToPanel(AnswerArea, "<br/>");
                 }
                 //-----
                 ControlsAdder(QuestionPanel, QuestionsTemplates.Paragraph, new Control[4] { QuestionTitle, IsReqired, HelpText, AnswerArea }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
             }

             else if (Q.FormFieldType.Name == "Choice")
             {
                 QuestionPanel.ToolTip = Q.FormFieldType.Name;
                 Label QuestionTitle = new Label();
                 QuestionTitle.Text = @"<span style='font-size:large;font-weight:bold'>" + Q.Title + "</span>"; 
                 //-----
                 Label IsReqired = new Label();
                 IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
                 //-----
                 Label HelpText = new Label();
                 HelpText.Text = Q.HelpText;
                 //-----
                 
                 RadioButtonList rbl = new RadioButtonList();
                 rbl.ID = "AnswerList"+Q.FormFieldId.ToString();
                 foreach (FormFieldValue qa in Q.FormFieldValues)
                 {
                     rbl.Items.Add(new ListItem(qa.FieldValue, qa.FormFieldValueId.ToString()));
                 }
                 
                 //-----
                 ControlsAdder(QuestionPanel, QuestionsTemplates.Paragraph, new Control[4] { QuestionTitle, IsReqired, HelpText, rbl }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
             }
         }

         public static void CollectSurveyUserAnswers(List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers,int SurveyId,int UserId)
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

         public static string ValidateUserAnswers(HtmlGenericControl ResultsArea)
         {
             SurveyUserAnswers = new List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer>();
             string result="";
             List<Panel> Panels = new List<Panel>();
             foreach (Control c in ResultsArea.Controls)
             {
                 try 
                 { 
                     Panel p = (Panel)c;
                     Panels.Add(p);
                 }
                 catch 
                 {

                 }
             }

             foreach (Panel p in Panels)
             {
                 BusinessLogicLayer.Entities.FormBuilder.FormField q = BusinessLogicLayer.Common.FormFieldLogic.GetByID(int.Parse(p.ID.Replace("Panel", "")));
                 if (q.FormFieldType.Name == "Text")
                 {
                     if (((TextBox)p.Controls[7]).Text.Length == 0 && q.IsRequired)
                     {
                         result += String.Format("Required question: {0}<br/>", q.Title);
                         break;
                     }
                     else 
                     {
                         
                         BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                         ua.FormFieldValueId = int.Parse(((TextBox)p.Controls[7]).ID.Replace("Answer", ""));
                         ua.Answer = ((TextBox)p.Controls[7]).Text;
                         SurveyUserAnswers.Add(ua);
                     }
                 }
                 else if (q.FormFieldType.Name == "Paragraph")
                 {

                     if (((TextBox)p.Controls[7]).Text.Length == 0 && q.IsRequired)
                     {
                         result += "Required question: " + q.Title + "<br/>";
                         break;
                     }
                     else
                     {

                         BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                         ua.FormFieldValueId = int.Parse(((TextBox)p.Controls[7]).ID.Replace("Answer", ""));
                         ua.Answer = ((TextBox)p.Controls[7]).Text;
                         SurveyUserAnswers.Add(ua);
                     }
                 }
                 else if (q.FormFieldType.Name == "Check")
                 {
                     Panel answersArea = ((Panel)p.Controls[7]);
                     List<CheckBox> checkboxes = new List<CheckBox>();
                     foreach (Control ctrl in answersArea.Controls)
                     {
                         try
                         {
                             CheckBox cb = (CheckBox)ctrl;
                             checkboxes.Add(cb);
                         }
                         catch { }
                     }
                     bool Ischecked = false;
                     foreach (CheckBox cb in checkboxes)
                     {
                         if (cb.Checked)
                         {
                             Ischecked = true;
                             break;
                         }
                     }
                     if (!Ischecked && q.IsRequired)
                     {
                         result += "Required question: " + q.Title + "<br/>";
                         break;
                     }
                     else if (Ischecked) 
                     {
                         foreach(CheckBox cb in checkboxes )
                         {
                             if (cb.Checked)
                             {
                                BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                                ua.FormFieldValueId = int.Parse(cb.ID.Replace("CheckAnswer","")) ;
                                ua.Answer = cb.Text;
                                SurveyUserAnswers.Add(ua);
                             }
                         }
                     }
                     
                 }
                 else if (q.FormFieldType.Name == "Choice")
                 {
                     RadioButtonList answersArea = ((RadioButtonList)p.Controls[7]);
                     
                     
                     ListItem answer=null ;
                     foreach (ListItem li in answersArea.Items)
                     {
                         
                         if (li.Selected)
                         {
                             
                             answer= li;
                             break;
                         }
                     }
                     if (answer==null && q.IsRequired)
                     {
                         result += "Required question: " + q.Title + "<br/>";
                         break;
                     }
                     else if (answer!=null)
                     {
                         BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                         ua.FormFieldValueId = int.Parse(answer.Value);
                         ua.Answer = answer.Text;
                         SurveyUserAnswers.Add(ua);
                         
                     }

                 }
                
             }
             return result;
             
         }

         #region Questions View
         public static void AddQuestionAdvanced(BusinessLogicLayer.Entities.FormBuilder.FormField Q, Panel QuestionPanel)
         {
             if (Q.FormFieldType.Name == "Text")
             {
                 AddTextQuestionAdvanced(Q, QuestionPanel);
             }
             else if (Q.FormFieldType.Name == "Paragraph")
             {
                 AddParagraphQuestionAdvanced(Q, QuestionPanel);
             }
             else if (Q.FormFieldType.Name == "Check")
             {
                 AddCheckQuestionAdvanced(Q, QuestionPanel);
             }
             else if (Q.FormFieldType.Name == "Choice")
             {
                 AddChoiceQuestionAdvanced(Q, QuestionPanel);
             }
             else if (Q.FormFieldType.Name == "DropDown")
             {
                 AddDropDownQuestionAdvanced(Q, QuestionPanel);
             }
             else if (Q.FormFieldType.Name == "Grid")
             {
                 AddGridQuestionAdvanced(Q, QuestionPanel);
             }
         }

         public static void AddTextQuestionAdvanced(BusinessLogicLayer.Entities.FormBuilder.FormField Q, Panel QuestionPanel)
         {
             QuestionPanel.ToolTip = Q.FormFieldType.Name;
             Label QuestionTitle = new Label();
             QuestionTitle.Text = String.Format(@"<span class='fb-Title'>{0}</span>", Q.Title);

             //-----
             Label IsReqired = new Label();
             IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
             //-----
             Label HelpText = new Label();
             HelpText.Text = Q.HelpText;
             //-----
             ASPxTextBox txtAnswer = new ASPxTextBox();
             txtAnswer.ID = String.Format("Answer{0}", Q.FormFieldValues[0].FormFieldValueId);
             txtAnswer.Width = new Unit(250);
             if (Q.IsRequired)
             {
                 txtAnswer.ValidationSettings.CausesValidation = true;
                 txtAnswer.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.Text;
                 txtAnswer.ValidationSettings.RequiredField.IsRequired = true;
             }
             //-----
             ControlsAdder(QuestionPanel, QuestionsTemplates.Text, new Control[4] { QuestionTitle, IsReqired, HelpText, txtAnswer }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
         }

         public static void AddParagraphQuestionAdvanced(BusinessLogicLayer.Entities.FormBuilder.FormField Q, Panel QuestionPanel)
         {
             QuestionPanel.ToolTip = Q.FormFieldType.Name;
             Label QuestionTitle = new Label();
             QuestionTitle.Text = String.Format(@"<span class='fb-Title'>{0}</span>", Q.Title);
             //-----
             Label IsReqired = new Label();
             IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
             //-----
             Label HelpText = new Label();
             HelpText.Text = Q.HelpText;
             //-----
             ASPxMemo txtAnswer = new ASPxMemo();
             txtAnswer.ID = String.Format("Answer{0}", Q.FormFieldValues[0].FormFieldValueId);
             txtAnswer.Width = new Unit(400);
             txtAnswer.Height = new Unit(100);
             if (Q.IsRequired)
             {
                 txtAnswer.ValidationSettings.CausesValidation = true;
                 txtAnswer.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.Text;
                 txtAnswer.ValidationSettings.RequiredField.IsRequired = true;
             }
             //-----
             ControlsAdder(QuestionPanel, QuestionsTemplates.Paragraph, new Control[4] { QuestionTitle, IsReqired, HelpText, txtAnswer }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
         }

         public static void AddCheckQuestionAdvanced(BusinessLogicLayer.Entities.FormBuilder.FormField Q, Panel QuestionPanel)
         {
             QuestionPanel.ToolTip = Q.FormFieldType.Name;
             Label QuestionTitle = new Label();
             QuestionTitle.Text = String.Format(@"<span class='fb-Title'>{0}</span>", Q.Title);
             //-----
             Label IsReqired = new Label();
             IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
             //-----
             Label HelpText = new Label();
             HelpText.Text = Q.HelpText;
             //-----
             //Panel AnswerArea = new Panel();
             ASPxListBox chckbx = new ASPxListBox();
             chckbx.SelectionMode = ListEditSelectionMode.CheckColumn;
             chckbx.Width = new Unit(400);
             chckbx.ID = chckbx.ID = "CheckList" + Q.FormFieldId.ToString();
             foreach (BusinessLogicLayer.Entities.FormBuilder.FormFieldValue qa in Q.FormFieldValues)
             {

                 ListEditItem item = new ListEditItem();
                 item.Text = qa.FieldValue;
                 item.Value = qa.FormFieldValueId;
                 chckbx.Items.Add(item);
             }
             if (Q.IsRequired)
             {
                 chckbx.ValidationSettings.CausesValidation = true;
                 chckbx.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.Text;
                 chckbx.ValidationSettings.RequiredField.IsRequired = true;
             }
             //-----
             ControlsAdder(QuestionPanel, QuestionsTemplates.Paragraph, new Control[4] { QuestionTitle, IsReqired, HelpText, chckbx }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
         }

         public static void AddChoiceQuestionAdvanced(BusinessLogicLayer.Entities.FormBuilder.FormField Q, Panel QuestionPanel)
         {
             QuestionPanel.ToolTip = Q.FormFieldType.Name;
             Label QuestionTitle = new Label();
             QuestionTitle.Text = String.Format(@"<span class='fb-Title'>{0}</span>", Q.Title);
             //-----
             Label IsReqired = new Label();
             IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
             //-----
             Label HelpText = new Label();
             HelpText.Text = Q.HelpText;
             //-----

             ASPxRadioButtonList rbl = new ASPxRadioButtonList();
             rbl.ID = "AnswerList" + Q.FormFieldId.ToString();
             rbl.Border.BorderStyle = BorderStyle.None;
             foreach (FormFieldValue qa in Q.FormFieldValues)
             {
                 rbl.Items.Add(new ListEditItem(qa.FieldValue, qa.FormFieldValueId));
             }
             if (Q.IsRequired)
             {
                 rbl.ValidationSettings.CausesValidation = true;
                 rbl.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.Text;
                 rbl.ValidationSettings.RequiredField.IsRequired = true;
             }
             //-----
             ControlsAdder(QuestionPanel, QuestionsTemplates.Paragraph, new Control[4] { QuestionTitle, IsReqired, HelpText, rbl }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
         }

         public static void AddDropDownQuestionAdvanced(BusinessLogicLayer.Entities.FormBuilder.FormField Q, Panel QuestionPanel)
         {
             QuestionPanel.ToolTip = Q.FormFieldType.Name;
             Label QuestionTitle = new Label();
             QuestionTitle.Text = String.Format(@"<span class='fb-Title'>{0}</span>", Q.Title);
             //-----
             Label IsReqired = new Label();
             IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
             //-----
             Label HelpText = new Label();
             HelpText.Text = Q.HelpText;
             //-----

             ASPxComboBox rbl = new ASPxComboBox();
             rbl.ID = "DropDownList" + Q.FormFieldId.ToString();
             rbl.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith;
             rbl.Width = new Unit(250);
             foreach (FormFieldValue qa in Q.FormFieldValues)
             {
                 rbl.Items.Add(new ListEditItem(qa.FieldValue, qa.FormFieldValueId));
             }
             if (Q.IsRequired)
             {
                 rbl.ValidationSettings.CausesValidation = true;
                 rbl.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.Text;
                 rbl.ValidationSettings.RequiredField.IsRequired = true;
                 
             }
             //-----
             ControlsAdder(QuestionPanel, QuestionsTemplates.Paragraph, new Control[4] { QuestionTitle, IsReqired, HelpText, rbl }, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
         }

         public static void AddGridQuestionAdvanced(BusinessLogicLayer.Entities.FormBuilder.FormField Q, Panel QuestionPanel)
         {
             QuestionPanel.ToolTip = Q.FormFieldType.Name;
             Label QuestionTitle = new Label();
             QuestionTitle.Text = String.Format(@"<span class='fb-Title'>{0}</span>", Q.Title);
             //-----
             Label IsReqired = new Label();
             IsReqired.Text = (Q.IsRequired) ? "*Required" : "";
             //-----
             Label HelpText = new Label();
             HelpText.Text = Q.HelpText;
             HtmlTable table = new HtmlTable();
             int counter = 1;
             #region Header Row
             HtmlTableRow row = new HtmlTableRow();
             row.ID = "RowHeader" + Q.FormFieldId;
             HtmlTableCell cellInit1 = new HtmlTableCell();
             HtmlTableCell cellInit2 = new HtmlTableCell();
             HtmlTableCell cellInit3 = new HtmlTableCell();
             cellInit1.Attributes.Add("class", "ss-gridnumbers");
             cellInit2.Attributes.Add("class", "ss-gridnumbers ss-spacer");
             cellInit2.Attributes.Add("style", "width: 6.25%;");
             row.Cells.Add(cellInit1);
             //row.Cells.Add(cellInit2);
             foreach (BusinessLogicLayer.Entities.FormBuilder.FormFieldColumn column in Q.FormFieldColumns)
             {
                 HtmlTableCell cell = new HtmlTableCell();
                 cell.Attributes.Add("class", "ss-gridnumbers");
                 cell.Attributes.Add("style", "width: 12.5%;");
                 Label label = new Label();
                 label.CssClass = "ss-gridnumber";
                 label.Text = column.FieldColumnValue;
                 cell.Controls.Add(label);
                 row.Cells.Add(cell);
             }
             
             table.Rows.Add(row);
             #endregion

             #region Content Rows
             foreach (FormFieldValue qa in Q.FormFieldValues)
             {
                 HtmlTableRow bodyRow = new HtmlTableRow();
                 bodyRow.ID = "Row" + qa.FormFieldValueId.ToString();
                 if(counter % 2 == 0)
                     bodyRow.Attributes.Add("class", "ss-gridrow ss-grid-row-odd");
                 else
                     bodyRow.Attributes.Add("class", "ss-gridrow ss-grid-row-even");
                 HtmlTableCell cellMain = new HtmlTableCell();
                 cellMain.Attributes.Add("class", "ss-gridrow ss-leftlabel");
                 cellMain.InnerText = qa.FieldValue;
                 bodyRow.Cells.Add(cellMain);
                 //HtmlTableCell cellSpacer = new HtmlTableCell();
                 //cellSpacer.Attributes.Add("class", "ss-gridrow ss-spacer");
                 //cellSpacer.Attributes.Add("style", "width: 6.25%;");
                 //bodyRow.Cells.Add(cellSpacer);
                 HtmlTableCell cellContent = new HtmlTableCell();
                 cellContent.ColSpan = Q.FormFieldColumns.Count;
                 ASPxRadioButtonList rbl = new ASPxRadioButtonList();
                 rbl.ID = String.Format("GridColumnList_{0}_{1}", counter, Q.FormFieldId);
                 rbl.RepeatColumns = Q.FormFieldColumns.Count;
                 rbl.Width = new Unit("100%");
                 rbl.Border.BorderStyle = BorderStyle.None;
                 if (Q.IsRequired)
                 {
                     rbl.ValidationSettings.CausesValidation = true;
                     rbl.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.Text;
                     rbl.ValidationSettings.RequiredField.IsRequired = true;
                 }
                 foreach (BusinessLogicLayer.Entities.FormBuilder.FormFieldColumn column in Q.FormFieldColumns)
                 {
                     
                     rbl.Items.Add(new ListEditItem("", String.Format("{0}_{1}", column.FormFieldColumnId, qa.FormFieldValueId)));
                 }
                 cellContent.Controls.Add(rbl);
                 bodyRow.Cells.Add(cellContent);
                 table.Rows.Add(bodyRow);
                 counter++;
             }
             #endregion

             //-----
             ControlsAdder(QuestionPanel, QuestionsTemplates.Paragraph, new Control[4] { QuestionTitle, IsReqired, HelpText, table}, new String[4] { "@QuestionTitle", "@IsRequired", "@HelpText", "@AnswerTextBox" });
         }
        #endregion

        #region Collect Submission Answers
         public static List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> RetrieveUserAnswers(Panel ResultsArea)
         {
             List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers = new List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer>();
             string result = "";
             List<Panel> Panels = new List<Panel>();
             foreach (Control c in ResultsArea.Controls)
             {
                 try
                 {
                     Panel p = (Panel)c;
                     Panels.Add(p);
                 }
                 catch
                 {

                 }
             }

             foreach (Panel p in Panels)
             {
                 BusinessLogicLayer.Entities.FormBuilder.FormField q = BusinessLogicLayer.Common.FormFieldLogic.GetByID(int.Parse(p.ID.Replace("Panel", "")));
                 if (q.FormFieldType.Name == "Text")
                 {
                     CollectTextAnswer(ref SurveyUserAnswers,p, q);
                 }
                 else if (q.FormFieldType.Name == "Paragraph")
                 {
                     CollectParagraphAnswer(ref SurveyUserAnswers, p, q);
                 }
                 else if (q.FormFieldType.Name == "Check")
                 {
                     CollectCheckAnswer(ref SurveyUserAnswers, p, q);
                 }
                 else if (q.FormFieldType.Name == "Choice")
                 {
                     CollectChoiceAnswer(ref SurveyUserAnswers, p, q);
                 }
                 else if (q.FormFieldType.Name == "DropDown")
                 {
                     CollectDropDownAnswer(ref SurveyUserAnswers, p, q);
                 }
                 else if (q.FormFieldType.Name == "Grid")
                 {
                     CollectGridAnswer(ref SurveyUserAnswers, p, q);
                 }

             }
             return SurveyUserAnswers;

         }

         public static void CollectTextAnswer(ref List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers, Panel p, BusinessLogicLayer.Entities.FormBuilder.FormField q)
         {
              BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
              ua.FormFieldId = q.FormFieldId;
              ua.FormFieldValueId = int.Parse(((ASPxTextBox)p.Controls[7]).ID.Replace("Answer", ""));
              ua.Answer = ((ASPxTextBox)p.Controls[7]).Text.Trim();
              SurveyUserAnswers.Add(ua);
         }

         public static void CollectParagraphAnswer(ref List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers,Panel p, BusinessLogicLayer.Entities.FormBuilder.FormField q)
         {
             BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
             ua.FormFieldId = q.FormFieldId;
             ua.FormFieldValueId = int.Parse(((ASPxMemo)p.Controls[7]).ID.Replace("Answer", ""));
             ua.Answer = ((ASPxMemo)p.Controls[7]).Text;
             SurveyUserAnswers.Add(ua);
         }

         public static void CollectCheckAnswer(ref List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers, Panel p, BusinessLogicLayer.Entities.FormBuilder.FormField q)
         {
             ASPxListBox answersArea = ((ASPxListBox)p.Controls[7]);


             ListEditItem answer = null;
             foreach (ListEditItem li in answersArea.Items)
             {
                 if (li.Selected)
                 {
                     answer = li;
                     BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                     ua.FormFieldId = q.FormFieldId;
                     if (answer != null)
                     {
                         ua.FormFieldValueId = Int32.Parse(answer.Value.ToString());
                         ua.Answer = answer.Text;
                     }
                     SurveyUserAnswers.Add(ua);
                     //break;
                 }
             }
             
         }

         public static void CollectChoiceAnswer(ref List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers, Panel p, BusinessLogicLayer.Entities.FormBuilder.FormField q)
         {
             ASPxRadioButtonList answersArea = ((ASPxRadioButtonList)p.Controls[7]);


             ListEditItem answer = null;
             foreach (ListEditItem li in answersArea.Items)
             {
                 if (li.Selected)
                 {
                     answer = li;
                     break;
                 }
             }
             BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
             ua.FormFieldId = q.FormFieldId;
             if (answer != null)
             {
                 ua.FormFieldValueId = Int32.Parse(answer.Value.ToString());
                 ua.Answer = answer.Text;
             }
             SurveyUserAnswers.Add(ua);
         }

         public static void CollectDropDownAnswer(ref List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers, Panel p, BusinessLogicLayer.Entities.FormBuilder.FormField q)
         {
             ASPxComboBox answersArea = ((ASPxComboBox)p.Controls[7]);
             if (answersArea.SelectedIndex >= 0)
             {
                 BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                 ua.FormFieldId = q.FormFieldId;
                 if (answersArea.SelectedItem != null)
                 {
                     ua.FormFieldValueId = Int32.Parse(answersArea.SelectedItem.Value.ToString());
                     ua.Answer = answersArea.Text;
                 }
                 SurveyUserAnswers.Add(ua);
             }

             
             
         }

         public static void CollectGridAnswer(ref List<BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer> SurveyUserAnswers, Panel p, BusinessLogicLayer.Entities.FormBuilder.FormField q)
         {

             HtmlTable table = ((HtmlTable)p.Controls[7]);
             for (int i = 1; i < table.Rows.Count; i++)
             {

                 ASPxRadioButtonList answersArea = table.Rows[i].Cells[1].Controls[0] as ASPxRadioButtonList;
                 if (answersArea != null)
                 {
                     ListEditItem answer = null;
                     foreach (ListEditItem li in answersArea.Items)
                     {
                         if (li.Selected)
                         {
                             answer = li;
                             break;
                         }
                     }
                     BusinessLogicLayer.Entities.FormBuilder.FormSubmissionAnswer ua = new FormSubmissionAnswer();
                     ua.FormFieldId = q.FormFieldId;
                     if (answer != null)
                     {
                         string[] sps = answer.Value.ToString().Split('_');
                         ua.FormFieldValueId = Int32.Parse(sps[1]);
                         BusinessLogicLayer.Entities.FormBuilder.FormFieldColumn column = BusinessLogicLayer.Common.FormFieldColumnLogic.GetByID(Convert.ToInt32(sps[0]));
                         if(column != null)
                            ua.Answer = column.FieldColumnValue;
                     }
                     SurveyUserAnswers.Add(ua);
                 }
             }

             
         }
        #endregion

    }
}
