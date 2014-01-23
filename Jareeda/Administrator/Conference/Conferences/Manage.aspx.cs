using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxUploadControl;
using System.IO;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxTabControl;
using DevExpress.Web.ASPxEditors;
using Administrator.Code;
using CommonWeb.Common;
using CommonWeb.Security;

namespace Administrator.Conference.Conferences
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object values = ConferenceGrid.GetRowValues(Convert.ToInt32(0), new string[] { "ConferenceId" });
                if (values == null)
                    values = "0";
                Session["ParentID"] = values.ToString();
            }

        }
        protected void ASPxGridView1_BeforePerformDataSelect(object sender, EventArgs e)
        {

            Session["ParentID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        private string SavePostedFile(UploadedFile uploadedFile)
        {

            Session["UploadedFile"] = null;
            string fileName = "";
            if (uploadedFile.IsValid)
            {
                Random random = new Random();
                //string _MenuGroupId = Session["MenuGroupId"].ToString();
                string dateString = String.Format("{0}{1}{2}", System.DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                string timeString = String.Format("{0}{1}{2}", System.DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                fileName = String.Format("{0}-{1}-{2}-{3}", dateString, timeString, random.Next(), uploadedFile.FileName);
                if (Tools.IsImage(uploadedFile.FileBytes))
                {
                    Session["UploadedFile"] = fileName;
                    //uploadedFile.SaveAs(Server.MapPath("~/ContentData/MenuImages/") + fileName, true);
                    //byte[] thumb = Tools.CreateThumb(uploadedFile.FileBytes, 32, true);
                    //MemoryStream stream = new MemoryStream(thumb);
                    FileStream stream = new FileStream(Server.MapPath(BusinessLogicLayer.Common.ConferenceContentPath) + fileName, FileMode.Create);
                    stream.Write(uploadedFile.FileBytes, 0, uploadedFile.FileBytes.Length);
                    stream.Flush();
                    stream.Close();
                }
                else
                {
                    BusinessLogicLayer.Components.UserMonitorLogic monitorLogic = new BusinessLogicLayer.Components.UserMonitorLogic();
                    string ipMain = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    string IpForwardedFor = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    string ip = String.Format("{0}-{1}", ipMain, IpForwardedFor);
                    int userid = 0;
                    if (SecurityManager.isLogged(this.Page))
                        userid = SecurityManager.getUser(this.Page).BusinessEntityId;
                    monitorLogic.Insert(userid, false, ip, fileName, DateTime.Now);
                    fileName = "";
                }

            }
            return fileName;
        }
        protected void conferenceLogoUpload_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SavePostedFile(e.UploadedFile);
        }

        protected void ConferenceGrid_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session["UploadedFile"] = null;
        }

        protected void ConferenceGrid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            if (Session["UploadedFile"] != null)
            {
                e.NewValues["ConferenceLogo"] = Session["UploadedFile"];
                Session["UploadedFile"] = null;


            }
            object v = null;
            #region Conference Data
            e.NewValues["ConferenceName"] = GetValueFromControl("txtConferenceName").ToString();
            e.NewValues["ConferenceCode"] = GetValueFromControl("txtConferenceCode").ToString();
            e.NewValues["ConferenceAlias"] = GetValueFromControl("txtConferenceAlias").ToString();
            e.NewValues["StartDate"] = GetValueFromControl("txtStartDate");
            e.NewValues["EndDate"] = GetValueFromControl("txtEndDate");
            e.NewValues["IsActive"] = GetValueFromControl("chkIsActive");
            e.NewValues["IsDefault"] = GetValueFromControl("chkIsDefault");
            e.NewValues["ConferenceDomain"] = GetValueFromControl("txtConferenceDomain");
            #endregion

            #region Location Data
            e.NewValues["LocationName"] = GetValueFromControl("txtLocationName");
            e.NewValues["Location"] = GetValueFromControl("txtLocation");
            e.NewValues["LocationLongitude"] = GetValueFromControl("txtLocationLongitude");
            e.NewValues["LocationLatitude"] = GetValueFromControl("txtLocationLatitude");
            #endregion

            #region Abstract Settings
            e.NewValues["AbstractSubmissionStartDate"] = GetValueFromControl("txtAbstractStart");
            e.NewValues["AbstractSubmissionEndDate"] = GetValueFromControl("txtAbstractEnd");
            e.NewValues["AbstractSubmissionEndMessagePageID"] = GetValueFromControl("txtAbstractPageEnd");
            e.NewValues["AbstractSubmissionNotStartedPageID"] = GetValueFromControl("txtAbstractNotStarted");
            #endregion
        }



        protected void ConferenceGrid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Session["UploadedFile"] != null)
            {
                e.NewValues["ConferenceLogo"] = Session["UploadedFile"];
                Session["UploadedFile"] = null;

            }
            object v = null;
            #region Conference Data
            e.NewValues["ConferenceName"] = GetValueFromControl("txtConferenceName").ToString();
            e.NewValues["ConferenceCode"] = GetValueFromControl("txtConferenceCode").ToString();
            e.NewValues["ConferenceAlias"] = GetValueFromControl("txtConferenceAlias").ToString();
            e.NewValues["StartDate"] = GetValueFromControl("txtStartDate");
            e.NewValues["EndDate"] = GetValueFromControl("txtEndDate");
            e.NewValues["IsActive"] = GetValueFromControl("chkIsActive");
            e.NewValues["IsDefault"] = GetValueFromControl("chkIsDefault");
            e.NewValues["ConferenceDomain"] = GetValueFromControl("txtConferenceDomain");
            #endregion

            #region Location Data
            e.NewValues["LocationName"] = GetValueFromControl("txtLocationName");
            e.NewValues["Location"] = GetValueFromControl("txtLocation");
            e.NewValues["LocationLongitude"] = GetValueFromControl("txtLocationLongitude");
            e.NewValues["LocationLatitude"] = GetValueFromControl("txtLocationLatitude");
            #endregion

            #region Abstract Settings
            e.NewValues["AbstractSubmissionStartDate"] = GetValueFromControl("txtAbstractStart");
            e.NewValues["AbstractSubmissionEndDate"] = GetValueFromControl("txtAbstractEnd");
            e.NewValues["AbstractSubmissionEndMessagePageID"] = GetValueFromControl("txtAbstractPageEnd");
            e.NewValues["AbstractSubmissionNotStartedPageID"] = GetValueFromControl("txtAbstractNotStarted");
            #endregion
        }

        protected void SettingLanguagesGrid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            e.NewValues["RegistrationShorInstructions"] = GetValueFromControlSettings((ASPxGridView)sender, "txtRegistrationShorInstructions").ToString();
            e.NewValues["RegistrationInstructionsInFormPre"] = GetValueFromControlSettings((ASPxGridView)sender, "htmlRegistrationPre").ToString();
            e.NewValues["RegistrationInstructionsInFormPost"] = GetValueFromControlSettings((ASPxGridView)sender, "htmlRegistrationPost").ToString();
            e.NewValues["PostRegistrationInstructions"] = GetValueFromControlSettings((ASPxGridView)sender, "htmlSubmissionComplete").ToString();
            e.NewValues["LanguageID"] = GetValueFromControlSettings((ASPxGridView)sender, "txtLanguageId").ToString();
            e.NewValues["ConferenceRegistrationSettingID"] = Session["SettingParentID"];
        }



        protected void SettingLanguagesGrid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            e.NewValues["RegistrationShorInstructions"] = GetValueFromControlSettings((ASPxGridView)sender, "txtRegistrationShorInstructions").ToString();
            e.NewValues["RegistrationInstructionsInFormPre"] = GetValueFromControlSettings((ASPxGridView)sender, "htmlRegistrationPre").ToString();
            e.NewValues["RegistrationInstructionsInFormPost"] = GetValueFromControlSettings((ASPxGridView)sender, "htmlRegistrationPost").ToString();
            e.NewValues["PostRegistrationInstructions"] = GetValueFromControlSettings((ASPxGridView)sender, "htmlSubmissionComplete").ToString();
            e.NewValues["LanguageID"] = GetValueFromControlSettings((ASPxGridView)sender, "txtLanguageId").ToString();
            e.NewValues["ConferenceRegistrationSettingID"] = Session["SettingParentID"];
        }


        protected object GetValueFromControl(string idName)
        {
            return GetValueFromControlGeneric(idName, ConferenceGrid, "conferencePageControl");
        }

        protected object GetValueFromControlSettings(ASPxGridView grid, string idName)
        {

            return GetValueFromControlGeneric(idName, grid, "settingsPageControl");
        }

        protected object GetValueFromControlGeneric(string idName, ASPxGridView grid, string pageControlID)
        {

            ASPxPageControl pageControl = grid.FindEditFormTemplateControl(pageControlID) as ASPxPageControl;
            if (pageControl == null) return null;
            object control = pageControl.FindControl(idName);
            if (control is ASPxTextBox)
            {
                ASPxTextBox t = control as ASPxTextBox;
                return t.Text;
            }
            else if (control is ASPxSpinEdit)
            {
                ASPxSpinEdit t = control as ASPxSpinEdit;
                return t.Value;
            }
            else if (control is ASPxDateEdit)
            {
                ASPxDateEdit t = control as ASPxDateEdit;
                return t.Date;
            }
            else if (control is ASPxComboBox)
            {
                ASPxComboBox t = control as ASPxComboBox;
                return t.Value;
            }
            else if (control is ASPxMemo)
            {
                ASPxMemo t = control as ASPxMemo;
                return t.Text;
            }
            else if (control is ASPxCheckBox)
            {
                ASPxCheckBox t = control as ASPxCheckBox;
                return t.Checked;
            }
            else if (control is DevExpress.Web.ASPxHtmlEditor.ASPxHtmlEditor)
            {
                DevExpress.Web.ASPxHtmlEditor.ASPxHtmlEditor t = control as DevExpress.Web.ASPxHtmlEditor.ASPxHtmlEditor;
                return t.Html;
            }


            return "";
        }

        protected void ASPxGridView3_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["SettingParentID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gridRegistrationTypeLanguages_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["ConferenceRegistrationTypeParentId"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        
    }
}