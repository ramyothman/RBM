using BusinessLogicLayer.Components.Conference;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxUploadControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Conference.ConferenceSchedules
{
    public partial class Manage : Administrator.Code.AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object values = ConferenceProgramGrid.GetRowValues(Convert.ToInt32(0), new string[] { "ScheduleId" });
                if (values == null)
                    values = "0";
                Session["ParentID"] = values.ToString();
                if (Request.QueryString["ProgramID"] != null)
                {
                    litProgramName.Text = new ConferenceProgramsLogic().GetByID(Convert.ToInt32(Request.QueryString["ProgramID"])).ProgramName;
                }
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
                Session["UploadedFile"] = fileName;
                FileStream stream = new FileStream(Server.MapPath(BusinessLogicLayer.Common.ConferenceScheduleDocPath) + fileName, FileMode.Create);
                stream.Write(uploadedFile.FileBytes, 0, uploadedFile.FileBytes.Length);
                stream.Flush();
                stream.Close();


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
                e.NewValues["DocPath"] = Session["UploadedFile"];
                Session["UploadedFile"] = null;

            }
        }

        protected void ConferenceGrid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Session["UploadedFile"] != null)
            {
                e.NewValues["DocPath"] = Session["UploadedFile"];
                Session["UploadedFile"] = null;

            }
        }
    }
}