using BusinessLogicLayer.Components.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
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

namespace Administrator.g.Content.Menu.Items
{
    public partial class Save : Code.AdminBase
    {
        private MenuEntityItem _Menu;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                int id = 0;
                Int32.TryParse(Request["Code"], out id);
                BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem menu = BusinessLogicLayer.Common.MenuEntityItemLogic.GetByID(id);
                if (menu != null)
                {
                    MenuManagerTitle.InnerText = Resources.ContentManagement.MenuManagerTitle + " : " + menu.Name + " [edit]";
                }
                else 
                {
                    MenuManagerTitle.InnerText = Resources.ContentManagement.MenuManagerTitle;
                }

                FillControls();
                if (Request.QueryString["ParentID"] == null)
                {
                    divForParent.Visible = true;
                }
            }
        }

        private void FillControls()
        {
            if (Request.QueryString["Code"] != null)
            {
                _Menu = new MenuEntityItemLogic().GetByID(Convert.ToInt32(Request.QueryString["Code"]));
                txtMenuName.Text = _Menu.Name;
                cbMenuType.DataBind();
                if (cbMenuType.Items.FindByValue(_Menu.MenuEntityTypeId) != null)
                    cbMenuType.SelectedIndex = cbMenuType.Items.FindByValue(_Menu.MenuEntityTypeId).Index;
                txtDisplayOrder.Text = _Menu.DisplayOrder.ToString();
                if (_Menu.MenuEntityTypeId == (int)MenuEntityTypeEnum.ExternalLink)
                {
                    divExternalLink.Visible = true;
                    txtExternalPageURL.Text = _Menu.PagePath;
                    cbSiteName.DataBind();
                    if (cbSiteName.Items.FindByValue(_Menu.ContentEntityId) != null)
                        cbSiteName.SelectedIndex = cbSiteName.Items.FindByValue(_Menu.ContentEntityId).Index;
                }
                else if (_Menu.MenuEntityTypeId == (int)MenuEntityTypeEnum.SiteContent)
                {
                    divSite.Visible = true;
                    BusinessLogicLayer.Entities.ContentManagement.SitePage page = new SitePageLogic().GetByID(_Menu.ContentEntityId);
                    SiteSection section = new SiteSectionLogic().GetByID(page.SectionId);
                    cbSiteName.DataBind();
                    if (cbSiteName.Items.FindByValue(section.SiteId) != null)
                        cbSiteName.SelectedIndex = cbSiteName.Items.FindByValue(section.SiteId).Index;
                    //cbSiteName.DataBind();
                    cbSectionName.DataBind();
                    if (cbSectionName.Items.FindByValue(section.SiteSectionId) != null)
                        cbSectionName.SelectedIndex = cbSectionName.Items.FindByValue(section.SiteSectionId).Index;
                    cbPageName.DataBind();
                    if (cbPageName.Items.FindByValue(page.SitePageId) != null)
                        cbPageName.SelectedIndex = cbPageName.Items.FindByValue(page.SitePageId).Index;
                }
                else if (_Menu.MenuEntityTypeId == (int)MenuEntityTypeEnum.ArticleSection)
                {
                    divSiteSection.Visible = true;

                    SiteSection section = new SiteSectionLogic().GetByID(_Menu.ContentEntityId);
                    cbSiteName.DataBind();
                    if (cbSiteName.Items.FindByValue(section.SiteId) != null)
                        cbSiteName.SelectedIndex = cbSiteName.Items.FindByValue(section.SiteId).Index;
                    //cbSiteName.DataBind();
                    cbSectionNameArticle.DataBind();
                    if (cbSectionNameArticle.Items.FindByValue(section.SiteSectionId) != null)
                        cbSectionNameArticle.SelectedIndex = cbSectionNameArticle.Items.FindByValue(section.SiteSectionId).Index;

                }
                if (Request.QueryString["ParentID"] == null)
                {
                    cbLang.DataBind();
                    if (cbLang.Items.FindByValue(_Menu.LanguageID) != null)
                        cbLang.SelectedIndex = cbLang.Items.FindByValue(_Menu.LanguageID).Index;
                    cbMenuPosition.DataBind();
                    if (cbMenuPosition.Items.FindByValue(_Menu.MenuEntityPositionID) != null)
                        cbMenuPosition.SelectedIndex = cbMenuPosition.Items.FindByValue(_Menu.MenuEntityPositionID).Index;
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?Code=" + Request.QueryString["menu"]);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool IsSaved;
            GetFormValues();
            if (Request.QueryString["Code"] != null)
            {
                IsSaved = new MenuEntityItemLogic().Update(_Menu, Convert.ToInt32(Request.QueryString["Code"]));
            }
            else
            {
                IsSaved = new MenuEntityItemLogic().Insert(_Menu);
            }
            if (IsSaved)
            {
                Session["Notification"] = "success";
                Response.Redirect("Default.aspx?Code=" + Request.QueryString["menu"]);
            }
                
        }
        private void GetFormValues()
        {
            if (Request.QueryString["Code"] != null)
            {
                _Menu = new MenuEntityItemLogic().GetByID(Convert.ToInt32(Request.QueryString["Code"]));
            }
            else
            {
                _Menu = new MenuEntityItem();
                if (Request.QueryString["menu"] != null)
                    _Menu.MenuEntityId = Convert.ToInt32(Request.QueryString["menu"]);
                if (Request.QueryString["ParentID"] != null)
                    _Menu.MenuEntityParentId = Convert.ToInt32(Request.QueryString["ParentID"]);
            }
            if (txtDisplayOrder.Text != "")
                _Menu.DisplayOrder = Convert.ToInt32(txtDisplayOrder.Text);
            _Menu.Name = txtMenuName.Text;
            _Menu.MenuEntityTypeId = Convert.ToInt32(cbMenuType.Value);
            if (divExternalLink.Visible)
            {
                _Menu.PagePath = txtExternalPageURL.Text;
                _Menu.ContentEntityId = Convert.ToInt32(cbSiteName.Value);
            }
            else if (divSite.Visible)
            {

                _Menu.ContentEntityId = Convert.ToInt32(cbPageName.Value);
                _Menu.PagePath = BusinessLogicLayer.Common.PagePath + _Menu.ContentEntityId;
            }
            else if (divSystemPages.Visible)
            {
                _Menu.ContentEntityId = Convert.ToInt32(cbSystemPages.Value);
                _Menu.PagePath = new SystemPageLogic().GetByID(_Menu.ContentEntityId).Path;
            }
            else if (divSiteSection.Visible)
            {
                _Menu.ContentEntityId = Convert.ToInt32(cbSectionNameArticle.Value);
                _Menu.PagePath = "~/ArticlesView.aspx?code=" + _Menu.ContentEntityId;
            }
            if (divForParent.Visible)
            {
                _Menu.LanguageID = Convert.ToInt32(cbLang.Value);
                _Menu.MenuEntityPositionID = Convert.ToInt32(cbMenuPosition.Value);
            }
            if (menuIconUpload.HasFile) 
            {
                if (!RemoveIcon.Checked)
                    _Menu.IconPath = SavePostedFile(menuIconUpload.UploadedFiles[0], false);
            }
            if(RemoveIcon.Checked)
            {
                _Menu.IconPath = "";
            }

        }

        protected void cbMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbMenuType.Value) == (int)MenuEntityTypeEnum.ExternalLink)
            {
                divExternalLink.Visible = true;
                divSite.Visible = false;
                divSystemPages.Visible = false;
                divSiteSection.Visible = false;
            }
            else if (Convert.ToInt32(cbMenuType.Value) == (int)MenuEntityTypeEnum.SiteContent)
            {
                divExternalLink.Visible = false;
                divSystemPages.Visible = false;
                divSite.Visible = true;
                divSiteSection.Visible = false;
            }
            else if (Convert.ToInt32(cbMenuType.Value) == (int)MenuEntityTypeEnum.ArticleSection)
            {
                divExternalLink.Visible = false;
                divSystemPages.Visible = false;
                divSite.Visible = false;
                divSiteSection.Visible = true;

            }
            else if (Convert.ToInt32(cbMenuType.Value) == (int)MenuEntityTypeEnum.SystemPage)
            {
                divSystemPages.Visible = true;
                divExternalLink.Visible = false;
                divSite.Visible = false;
                divSiteSection.Visible = false;
            }
        }

        private string SavePostedFile(UploadedFile uploadedFile, bool HaveWaterMark)
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
                    string fileName_withoutWaterMark = "now" + fileName;
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

        protected void menuIconUpload_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {

        }
    }
}