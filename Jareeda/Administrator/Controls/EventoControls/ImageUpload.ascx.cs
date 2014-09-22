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

namespace Administrator.Controls.EventoControls
{
    public partial class ImageUpload : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string SavePostedFile(UploadedFile uploadedFile)
        {

            Session["ImageUploadedFile"] = "";
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
                    Session["ImageUploadedFile"] = fileName;
                    //uploadedFile.SaveAs(Server.MapPath("~/ContentData/MenuImages/") + fileName, true);
                    //byte[] thumb = Tools.CreateThumb(uploadedFile.FileBytes, 32, true);
                    //MemoryStream stream = new MemoryStream(thumb);
                    int width = 300;
                    using (MemoryStream ms = new MemoryStream(uploadedFile.FileBytes, 0, uploadedFile.FileBytes.Length))
                    {
                        ms.Write(uploadedFile.FileBytes, 0, uploadedFile.FileBytes.Length);
                        using (System.Drawing.Image CroppedImage = System.Drawing.Image.FromStream(ms, true))
                        {
                            if (width > CroppedImage.Width)
                                width = CroppedImage.Width;
                        }
                    }
                   byte []thumb = Tools.CreateThumb(uploadedFile.FileBytes, width, false);
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
            e.CallbackData = ResolveUrl(BusinessLogicLayer.Common.ConferenceContentPath) + SavePostedFile(e.UploadedFile);
        }

        public string ImagePath
        {
            set { miPersonPhoto.ImageUrl = BusinessLogicLayer.Common.ConferenceContentPath + value; Session["CroppedImageUploadedFile"] = value; }
            get 
            {
                if(Session["CroppedImageUploadedFile"] == null)
                    Session["CroppedImageUploadedFile"] = "";
                return Session["CroppedImageUploadedFile"].ToString();
            }
        }

        protected void callBackEditImage_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            string ImageName = Session["ImageUploadedFile"].ToString();
            int w = Convert.ToInt32(EditImageHidden.Get("W"));
            int h = Convert.ToInt32(EditImageHidden.Get("H"));
            int x = Convert.ToInt32(EditImageHidden.Get("X"));
            int y = Convert.ToInt32(EditImageHidden.Get("Y"));

            byte[] CropImage = Tools.Crop(Server.MapPath(BusinessLogicLayer.Common.ConferenceContentPath) + ImageName, w, h, x, y);
            using (MemoryStream ms = new MemoryStream(CropImage, 0, CropImage.Length))
            {
                ms.Write(CropImage, 0, CropImage.Length);
                using (System.Drawing.Image CroppedImage = System.Drawing.Image.FromStream(ms, true))
                {
                    string SaveTo = Server.MapPath(BusinessLogicLayer.Common.ConferenceContentPath) + "crop" + ImageName;
                    string SaveToThumb = Server.MapPath(BusinessLogicLayer.Common.ConferenceContentPath) + "thumb" + ImageName;
                    byte[] thumb = Tools.CreateThumb(CropImage, 250, false);
                    CroppedImage.Save(SaveTo, CroppedImage.RawFormat);
                    FileStream stream = new FileStream(SaveToThumb, FileMode.Create);
                    stream.Write(thumb, 0, thumb.Length);
                    stream.Flush();
                    stream.Close();
                    Session["CroppedImageUploadedFile"] = "thumb" + ImageName;
                    miPersonPhoto.ImageUrl = BusinessLogicLayer.Common.ConferenceContentPath + "thumb" + ImageName;
                }
            }
        }

        
    }
}