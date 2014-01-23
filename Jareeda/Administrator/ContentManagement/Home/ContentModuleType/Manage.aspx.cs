using Administrator.Code;
using CommonWeb.Common;
using CommonWeb.Security;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxUploadControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.ContentManagement.Home.ContentModuleType
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object values = SourcesGrid.GetRowValues(Convert.ToInt32(0), new string[] { "SiteID" });
                if (values == null)
                    values = "0";
                Session["MSiteID"] = values.ToString();
            }
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
                e.NewValues["ImagePreview"] = Session["UploadedFile"];
                Session["UploadedFile"] = null;

            }
        }

        protected void ConferenceGrid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Session["UploadedFile"] != null)
            {
                e.NewValues["ImagePreview"] = Session["UploadedFile"];
                Session["UploadedFile"] = null;

            }
        }

        protected void SourcesGrid_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (!SourcesGrid.IsNewRowEditing && !SourcesGrid.IsEditing) return;
            if (e.Column.FieldName != "PositionID") return;
            int site = 0;
            if (e.KeyValue != DBNull.Value && e.KeyValue != null)
            {
                object val = SourcesGrid.GetRowValuesByKeyValue(e.KeyValue, "SiteID");
                if (val == DBNull.Value) return;
                site = (int)val;
            }
            ASPxComboBox combo = e.Editor as ASPxComboBox;
            if (e.Column.FieldName == "PositionID")
            {
                FillSectionCombo(combo, site.ToString());
                combo.Callback += new CallbackEventHandlerBase(cmbSection_OnCallback);
            }

        }

        protected void FillSectionCombo(ASPxComboBox cmb, string SiteID)
        {
            if (SiteID == "0") return;
            cmb.DataSourceID = "PositionObjectDS";
            Session["MSiteID"] =SiteID;
            PositionObjectDS.SelectParameters[0].DefaultValue = SiteID;
            cmb.DataBindItems();
            cmb.Items.Insert(0, new ListEditItem("", null)); // Null Item
        }

        void cmbSection_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillSectionCombo(source as ASPxComboBox, e.Parameter);
        }
    }
}