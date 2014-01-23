using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using System.Web.UI;

namespace CommonWeb.Common
{
    public class RegistrationInterfaceHelper
    {

        #region Questions View
        public static void AddQuestionAdvanced(BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType Q, Panel QuestionPanel)
        {
            if (string.IsNullOrEmpty(Q.GroupName))
            {
                AddCheckQuestionAdvanced(Q, QuestionPanel);
            }
            else
            {
                AddChoiceQuestionAdvanced(Q, QuestionPanel);
            }
        }

        
        public static void AddCheckQuestionAdvanced(BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType Q, Panel QuestionPanel)
        {
            Table table = new Table();
            table.Style.Add("width", "100%");
            #region Date Row
            TableRow rowDate = new TableRow();
            TableCell cellDate = new TableCell();
            cellDate.ColumnSpan = 2;
            cellDate.Style.Add("font-weight","bold");
            //cellDate.Style.Add("text-align", "center");
            //string hijriDate = "";
            //string miladyDate = "";
            //if(Q.CurrentSchedule != null)
            //{
            //    hijriDate = Code.RbmCommon.ConferenceBasePage.GregToHijri(Q.CurrentSchedule.StartTime);
            //    miladyDate = Q.CurrentSchedule.StartTime.ToShortDateString();
            //}
            //else
            //{
            //    hijriDate = Code.RbmCommon.ConferenceBasePage.GregToHijri(Q.StartDate);
            //    miladyDate = Q.StartDate.ToShortDateString();
            //}
            //cellDate.Text = String.Format("{0} - {1}", miladyDate, hijriDate);
            rowDate.Cells.Add(cellDate);
            table.Rows.Add(rowDate);
            #endregion

            #region Header Row
            TableRow rowHeader = new TableRow();
            rowHeader.Style.Add("background-color", "#18335F");
            rowHeader.Style.Add("color", "#FFFFFF");
            TableCell cellTime = new TableCell();
            //cellTime.Style.Add("text-align", "center");
            cellTime.Style.Add("width", "185px");
            cellTime.Text +=  CommonWeb.Resources.CommonResource.RegistrationForm_Time;
            TableCell cellTitle = new TableCell();
            //cellTitle.Style.Add("text-align", "center");
            cellTitle.Text = Q.DescriptionLanguage;
            rowHeader.Cells.Add(cellTime);
            rowHeader.Cells.Add(cellTitle);
            table.Rows.Add(rowHeader);
            #endregion

            #region Content Row
            TableRow rowContent = new TableRow();
            TableCell cellTimeContent = new TableCell();
            string hijriDate = "";
            string miladyDate = "";
            if (Q.CurrentSchedule != null)
            {
                hijriDate = BasePage.GregToHijri(Q.CurrentSchedule.StartTime);
                miladyDate = Q.CurrentSchedule.StartTime.ToShortDateString();
            }
            else
            {
                hijriDate = BasePage.GregToHijri(Q.StartDate);
                miladyDate = Q.StartDate.ToShortDateString();
            }
            cellTimeContent.Text = String.Format("{0} - {1}<br/>", miladyDate, hijriDate);
            if (Q.CurrentSchedule == null)
                cellTimeContent.Text += "";
            else
            {
                if(Q.LanguageID == 2)
                    cellTimeContent.Text += Q.CurrentSchedule.StartTime.ToShortTimeString().Replace("AM", "ص").Replace("PM", "م") + " - " + Q.CurrentSchedule.EndTime.ToShortTimeString().Replace("AM", "ص").Replace("PM", "م");
                else
                    cellTimeContent.Text += Q.CurrentSchedule.StartTime.ToShortTimeString() + " - " + Q.CurrentSchedule.EndTime.ToShortTimeString();
            }
            TableCell cellTitleContent = new TableCell();
            cellTitleContent.Style.Add("text-align", CommonWeb.Resources.CommonResource.Direction);
            cellTitleContent.Style.Add("font-weight", "bold");
            ASPxCheckBox checkBox = new ASPxCheckBox();
            checkBox.Text = Q.NameLanguage;
            checkBox.ID = "CheckList" + Q.ConferenceRegistrationTypeId;
            if (Q.MustRegister)
            {
                checkBox.ValidationSettings.CausesValidation = true;
                checkBox.ValidationSettings.Display = Display.Dynamic;
                checkBox.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.Text;
                checkBox.ValidationSettings.RequiredField.ErrorText = "*";
                checkBox.ValidationSettings.RequiredField.IsRequired = true;
                checkBox.ValidationSettings.ValidationGroup = "WizardValidation";
            }
            cellTitleContent.Controls.Add(checkBox);
            rowContent.Cells.Add(cellTimeContent);
            rowContent.Cells.Add(cellTitleContent);
            table.Rows.Add(rowContent);
            #endregion
            
            QuestionPanel.Controls.Add(table);
        }

        public static void AddChoiceQuestionAdvanced(BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType Q, Panel QuestionPanel)
        {
            Table table = new Table();
            table.Style.Add("width", "100%");
            #region Date Row
            TableRow rowDate = new TableRow();
            TableCell cellDate = new TableCell();
            cellDate.ColumnSpan = 2;
            cellDate.Style.Add("font-weight", "bold");
            //cellDate.Style.Add("text-align", "center");
            //string hijriDate = "";
            //string miladyDate = "";
            //if (Q.CurrentSchedule != null)
            //{
            //    hijriDate = Code.RbmCommon.ConferenceBasePage.GregToHijri(Q.CurrentSchedule.StartTime);
            //    miladyDate = Q.CurrentSchedule.StartTime.ToShortDateString();
            //}
            //else
            //{
            //    hijriDate = Code.RbmCommon.ConferenceBasePage.GregToHijri(Q.StartDate);
            //    miladyDate = Q.StartDate.ToShortDateString();
            //}
            //cellDate.Text = String.Format("{0} - {1}", miladyDate, hijriDate);
            rowDate.Cells.Add(cellDate);
            table.Rows.Add(rowDate);
            #endregion

            #region Header Row
            TableRow rowHeader = new TableRow();
            rowHeader.Style.Add("background-color", "#18335F");
            rowHeader.Style.Add("color", "#FFFFFF");
            TableCell cellTime = new TableCell();
            cellTime.Style.Add("width", "185px");
            //cellTime.Style.Add("text-align", "center");
            cellTime.Text = CommonWeb.Resources.CommonResource.RegistrationForm_Time;
            TableCell cellTitle = new TableCell();
            //cellTitle.Style.Add("text-align", "center");
            cellTitle.Text = Q.DescriptionLanguage;
            rowHeader.Cells.Add(cellTime);
            rowHeader.Cells.Add(cellTitle);
            table.Rows.Add(rowHeader);
            #endregion

            #region Content Row
            TableRow rowContent = new TableRow();
            TableCell cellTimeContent = new TableCell();
            string hijriDate = "";
            string miladyDate = "";
            if (Q.CurrentSchedule != null)
            {
                hijriDate = BasePage.GregToHijri(Q.CurrentSchedule.StartTime);
                miladyDate = Q.CurrentSchedule.StartTime.ToShortDateString();
            }
            else
            {
                hijriDate = BasePage.GregToHijri(Q.StartDate);
                miladyDate = Q.StartDate.ToShortDateString();
            }
            cellTimeContent.Text = String.Format("{0} - {1}<br/>", miladyDate, hijriDate);
            if (Q.CurrentSchedule == null)
                cellTimeContent.Text += "";
            else
            {
                if (Q.LanguageID == 2)
                    cellTimeContent.Text += Q.CurrentSchedule.StartTime.ToShortTimeString().Replace("AM", "ص").Replace("PM", "م") + " - " + Q.CurrentSchedule.EndTime.ToShortTimeString().Replace("AM", "ص").Replace("PM", "م");
                else
                    cellTimeContent.Text += Q.CurrentSchedule.StartTime.ToShortTimeString() + " - " + Q.CurrentSchedule.EndTime.ToShortTimeString();
            }

            TableCell cellTitleContent = new TableCell();
            cellTitleContent.Style.Add("font-weight", "bold");
            cellTitleContent.Style.Add("text-align",CommonWeb.Resources.CommonResource.Direction);
            ASPxRadioButton checkBox = new ASPxRadioButton();
            checkBox.GroupName = Q.GroupName;
            checkBox.Text = Q.NameLanguage;
            checkBox.ID = "ChoiceList" + Q.ConferenceRegistrationTypeId;
            cellTitleContent.Controls.Add(checkBox);
            rowContent.Cells.Add(cellTimeContent);
            rowContent.Cells.Add(cellTitleContent);
            table.Rows.Add(rowContent);
            #endregion

            QuestionPanel.Controls.Add(table);
        }

        
        #endregion

        #region Collect Submission Answers
        public static List<BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems> RetrieveUserAnswers(Panel ResultsArea)
        {
            List<BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems> SurveyUserAnswers = new List<BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems>();
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
                BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType q = new BusinessLogicLayer.Components.Conference.ConferenceRegistrationTypeLogic().GetByID(int.Parse(p.ID.Replace("Panel", "")));
                if (string.IsNullOrEmpty(q.GroupName))
                {
                    CollectCheckAnswer(ref SurveyUserAnswers, p, q);
                }
                else 
                {
                    CollectChoiceAnswer(ref SurveyUserAnswers, p, q);
                }
               

            }
            return SurveyUserAnswers;

        }



        public static void CollectCheckAnswer(ref List<BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems> SurveyUserAnswers, Panel p, BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType q)
        {
            Table table = ((Table)p.Controls[0]);
            TableRow row = table.Rows[2];
            TableCell cell = row.Cells[1];

            ASPxCheckBox answersArea = ((ASPxCheckBox)cell.Controls[0]);
            if (answersArea.Checked)
            {
                BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems item = new BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems();
                item.ConferenceRegistrationTypeID = q.ConferenceRegistrationTypeId;
                item.CreatedDate = DateTime.Now;
                SurveyUserAnswers.Add(item);
            }
        }

        public static void CollectChoiceAnswer(ref List<BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems> SurveyUserAnswers, Panel p, BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType q)
        {
            Table table = ((Table)p.Controls[0]);
            TableRow row = table.Rows[2];
            TableCell cell = row.Cells[1];

            ASPxRadioButton answersArea = ((ASPxRadioButton)cell.Controls[0]);
            if (answersArea.Checked)
            {
                BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems item = new BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems();
                item.ConferenceRegistrationTypeID = q.ConferenceRegistrationTypeId;
                item.CreatedDate = DateTime.Now;
                SurveyUserAnswers.Add(item);
            }
        }

        #endregion


        #region Collect Submission Answers
        public static void LoadControlValues(Panel ResultsArea, List<BusinessLogicLayer.Entities.Conference.ConferenceRegistrationItems> items)
        {
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
                BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType q = new BusinessLogicLayer.Components.Conference.ConferenceRegistrationTypeLogic().GetByID(int.Parse(p.ID.Replace("Panel", "")));
                var item = (from x in items where x.ConferenceRegistrationTypeID == q.ConferenceRegistrationTypeId select x).FirstOrDefault();
                if (item != null)
                {
                    if (string.IsNullOrEmpty(q.GroupName))
                    {
                        SetCheckAnswerValue(p, q);
                    }
                    else
                    {
                        SetChoiceAnswerValue(p, q);
                    }
                }
            }
            

        }



        public static void SetCheckAnswerValue(Panel p, BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType q)
        {
            Table table = ((Table)p.Controls[0]);
            TableRow row = table.Rows[2];
            TableCell cell = row.Cells[1];

            ASPxCheckBox answersArea = ((ASPxCheckBox)cell.Controls[0]);
            answersArea.Checked = true;
        }

        public static void SetChoiceAnswerValue(Panel p, BusinessLogicLayer.Entities.Conference.ConferenceRegistrationType q)
        {
            Table table = ((Table)p.Controls[0]);
            TableRow row = table.Rows[2];
            TableCell cell = row.Cells[1];

            ASPxRadioButton answersArea = ((ASPxRadioButton)cell.Controls[0]);
            answersArea.Checked = true;
        }

        #endregion
    }
}