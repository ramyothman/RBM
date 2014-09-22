using Administrator.Code;
using CommonWeb.Common;
using CommonWeb.Security;
using DevExpress.Web.ASPxUploadControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Content.MainImages
{
    public partial class Default : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
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
                e.NewValues["PhotoPath"] = Session["UploadedFile"];
                Session["UploadedFile"] = null;

            }
        }

        protected void ConferenceGrid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Session["UploadedFile"] != null)
            {
                e.NewValues["PhotoPath"] = Session["UploadedFile"];
                Session["UploadedFile"] = null;

            }
        }
    }
}