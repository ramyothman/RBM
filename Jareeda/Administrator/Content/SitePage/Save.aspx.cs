using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxFileManager;
using CommonWeb.Security;
namespace Administrator.Content.SitePage
{
    public partial class Save : Administrator.Code.AdminBasePage
    {
        #region Documents Selector



        protected void DemoHtmlEditor_DocumentSelectorFileUploading(object source, FileManagerFileUploadEventArgs e)
        {
            ValidateSiteEdit(e);
        }
        protected void DemoHtmlEditor_DocumentSelectorItemRenaming(object source, FileManagerItemRenameEventArgs e)
        {
            ValidateSiteEdit(e);
        }
        protected void DemoHtmlEditor_DocumentSelectorItemMoving(object source, FileManagerItemMoveEventArgs e)
        {
            ValidateSiteEdit(e);
        }
        protected void DemoHtmlEditor_DocumentSelectorItemDeleting(object source, FileManagerItemDeleteEventArgs e)
        {
            ValidateSiteEdit(e);
        }
        protected void DemoHtmlEditor_DocumentSelectorFolderCreating(object source, FileManagerFolderCreateEventArgs e)
        {
            ValidateSiteEdit(e);
        }
        protected void ValidateSiteEdit(FileManagerActionEventArgsBase e)
        {
            //e.Cancel = DevExpress.Web.Demos.Utils.IsSiteMode;
            //e.ErrorText = DevExpress.Web.Demos.Utils.GetReadOnlyMessageText();
        }
        #endregion

        #region Properties
        public string SiteLink
        {
            set
            {

            }
        }
        public BusinessLogicLayer.Entities.ContentManagement.SitePage SitePage
        {
            get
            {
                if (Session["AMCurrentSitePage"] == null)
                {
                    Session["AMCurrentSitePage"] = new BusinessLogicLayer.Entities.ContentManagement.SitePage();
                }
                return Session["AMCurrentSitePage"] as BusinessLogicLayer.Entities.ContentManagement.SitePage;
            }
            set
            {
                Session["AMCurrentSitePage"] = value;
            }
        }

        public int OldLanguageId
        {
            get
            {
                if (Session["AMSitePageOldLanguageId"] == null)
                    return 0;
                else
                    return Convert.ToInt32(Session["AMSitePageOldLanguageId"]);
            }

            set { Session["AMSitePageOldLanguageId"] = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                SitePage = null;
                DevExpress.Web.ASPxEditors.ASPxListBox checkbox = categoriesDropDownEdit.FindControl("listBox") as DevExpress.Web.ASPxEditors.ASPxListBox;
                if (checkbox != null)
                {
                    checkbox.DataBind();
                    checkbox.Items.Insert(0, new DevExpress.Web.ASPxEditors.ListEditItem("(Select All)", "0"));
                }
                pageSite.DataBind();
                pageState.DataBind();
                pageSecurityAccess.DataBind();
                pageLanguages.DataBind();
                pageLanguages.SelectedIndex = pageLanguages.Items.IndexOfValue(BusinessLogicLayer.Common.DefaultLanguage.LanguageId);
                if (!string.IsNullOrEmpty(Request["PageCode"]))
                {
                    int pageId = 0;
                    Int32.TryParse(Request["PageCode"], out pageId);
                    SitePage = BusinessLogicLayer.Common.SitePageLogic.GetByID(pageId);

                    if (!SitePage.NewRecord)
                    {
                        SiteLink = pageId.ToString();
                        pageSite.SelectedIndex = pageSite.Items.IndexOfValue(SitePage.SiteId);
                        pageState.SelectedIndex = pageState.Items.IndexOfValue(SitePage.PageStatusId);
                        pageSecurityAccess.SelectedIndex = pageSecurityAccess.Items.IndexOfValue(SitePage.SecurityAccessTypeId);
                        pageAlias.Text = SitePage.UniquePageName;
                        chkIsMainPage.Checked = SitePage.IsMainPage;
                        pageSection.DataBind();
                        pageSection.SelectedIndex = pageSection.Items.IndexOfValue(SitePage.SectionId);
                        List<BusinessLogicLayer.Entities.ContentManagement.SitePageCategory> cats = BusinessLogicLayer.Common.SitePageCategoryLogic.GetAllBySitePageId(SitePage.SitePageId);
                        foreach (BusinessLogicLayer.Entities.ContentManagement.SitePageCategory cat in cats)
                        {

                            foreach (DevExpress.Web.ASPxEditors.ListEditItem item in checkbox.Items)
                            {
                                if (item.Value.ToString() == cat.SiteCategoryId.ToString())
                                {
                                    categoriesDropDownEdit.Text += item.Text + ";";
                                    item.Selected = true;
                                }
                            }
                        }
                        if (categoriesDropDownEdit.Text.Length > 0)
                            categoriesDropDownEdit.Text = categoriesDropDownEdit.Text.Remove(categoriesDropDownEdit.Text.Length - 1, 1);
                        if (checkbox != null)
                        {

                            foreach (DevExpress.Web.ASPxEditors.ListEditItem item in checkbox.Items)
                            {
                                if (item.Value.ToString() != "0")
                                {
                                    BusinessLogicLayer.Common.SitePageCategoryLogic.Insert(Convert.ToInt32(item.Value), SitePage.SitePageId, DateTime.Now);
                                }
                            }
                        }
                        pageLanguages.SelectedIndex = pageLanguages.Items.IndexOfValue(BusinessLogicLayer.Common.DefaultLanguage.LanguageId);
                        BusinessLogicLayer.Entities.ContentManagement.SitePageLanguage splang = SitePage.GetSitePageLanguageByLanguageId(Convert.ToInt32(pageLanguages.SelectedItem.Value));
                        pageTitle.Text = splang.PageName;
                        pageContent.Html = splang.PageContent;
                        pageAlias.Text = splang.PageAlias;
                    }
                }
                OldLanguageId = (int)pageLanguages.SelectedItem.Value;
            }
        }

        #region Control Events
        protected void pageSection_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            SectionObjectDS.SelectParameters[0].DefaultValue = e.Parameter;
            pageSection.DataBind();
        }

        protected void pageState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMethod();
                //NoticeMessageDiv.Visible = true;
                //NoticeMessageDiv.Attributes.Remove("class");
                //NoticeMessageDiv.Attributes.Add("class", GetSuccessMessageClasses());
                //NoticeMessage.InnerHtml = "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                //NoticeMessageDiv.Visible = true;
                //NoticeMessageDiv.Attributes.Remove("class");
                //NoticeMessageDiv.Attributes.Add("class", GetErrorMessageClasses());
                //NoticeMessage.InnerHtml = "<span>Error Saving: </span>" + ex.Message;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMethod();
                //NoticeMessageDiv.Visible = true;
                //NoticeMessageDiv.Attributes.Remove("class");
                //NoticeMessageDiv.Attributes.Add("class", GetSuccessMessageClasses());
                //NoticeMessage.InnerHtml = "Data Saved Successfully";
                SiteLink = SitePage.SitePageId.ToString();
            }
            catch (Exception ex)
            {
                //NoticeMessageDiv.Visible = true;
                //NoticeMessageDiv.Attributes.Remove("class");
                //NoticeMessageDiv.Attributes.Add("class", GetErrorMessageClasses());
                //NoticeMessage.InnerHtml = "<span>Error Saving: </span>" + ex.Message;
                return;
            }
            Response.Redirect("ManageSitePages.aspx");
        }

        protected void pageContentLanguageCallbackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            BusinessLogicLayer.Entities.ContentManagement.SitePageLanguage oldLanguage = SitePage.GetSitePageLanguageByLanguageId(OldLanguageId);
            BusinessLogicLayer.Entities.ContentManagement.SitePageLanguage newlanguage = SitePage.GetSitePageLanguageByLanguageId(Convert.ToInt32(e.Parameter));

            oldLanguage.PageName = pageTitle.Text;
            oldLanguage.PageContent = pageContent.Html;
            oldLanguage.ModifiedDate = DateTime.Now;
            oldLanguage.LanguageId = OldLanguageId;
            oldLanguage.PageAlias = pageAlias.Text;
            if (oldLanguage.NewRecord)
            {
                oldLanguage.NewRecord = false;
                SitePage.CurrentSitePageLanguages.Add(oldLanguage);
            }

            pageAlias.Text = newlanguage.PageAlias;
            pageContent.Html = newlanguage.PageContent;
            pageTitle.Text = newlanguage.PageName;

            OldLanguageId = Convert.ToInt32(e.Parameter);

        }
        #endregion

        #region Helping Methods
        private void SaveMethod()
        {
            #region Getting Language Last Updates
            BusinessLogicLayer.Entities.ContentManagement.SitePageLanguage oldLanguage = SitePage.GetSitePageLanguageByLanguageId(OldLanguageId);
            oldLanguage.PageName = pageTitle.Text;
            oldLanguage.PageContent = pageContent.Html;
            oldLanguage.ModifiedDate = DateTime.Now;
            oldLanguage.LanguageId = OldLanguageId;
            oldLanguage.PageAlias = pageAlias.Text;
            if (oldLanguage.NewRecord)
            {
                oldLanguage.NewRecord = false;
                SitePage.CurrentSitePageLanguages.Add(oldLanguage);
            }
            #endregion

            if (SitePage.NewRecord)
            {
                #region Insert
                SitePage.CreatorId = SecurityManager.getUser(this).BusinessEntityId;
                SitePage.IsMainPage = false;
                SitePage.ModifiedDate = DateTime.Now;
                SitePage.PageStatusId = Convert.ToInt32(pageState.Value);
                SitePage.RevisionDate = DateTime.Now;
                SitePage.SecurityAccessTypeId = Convert.ToInt32(pageSecurityAccess.Value);
                SitePage.UniquePageName = pageAlias.Text;
                SitePage.SectionId = Convert.ToInt32(pageSection.Value);
                SitePage.IsMainPage = chkIsMainPage.Checked;
                BusinessLogicLayer.Common.SitePageLogic.Insert(SitePage);
                //SitePage.NewRecord = false;
                List<BusinessLogicLayer.Entities.ContentManagement.SitePageCategory> cats = new List<BusinessLogicLayer.Entities.ContentManagement.SitePageCategory>();
                DevExpress.Web.ASPxEditors.ASPxListBox checkbox = categoriesDropDownEdit.FindControl("listBox") as DevExpress.Web.ASPxEditors.ASPxListBox;
                if (checkbox != null)
                {

                    foreach (DevExpress.Web.ASPxEditors.ListEditItem item in checkbox.Items)
                    {
                        if (item.Value.ToString() != "0" && item.Selected)
                        {
                            BusinessLogicLayer.Common.SitePageCategoryLogic.Insert(Convert.ToInt32(item.Value), SitePage.SitePageId, DateTime.Now);
                        }
                    }
                }
                foreach (BusinessLogicLayer.Entities.ContentManagement.SitePageLanguage lang in SitePage.CurrentSitePageLanguages)
                {
                    lang.SitePageId = SitePage.SitePageId;
                    BusinessLogicLayer.Common.SitePageLanguageLogic.Insert(lang);
                }
                #endregion
            }
            else
            {
                #region Update
                SitePage.CreatorId = SecurityManager.getUser(this).BusinessEntityId;
                SitePage.IsMainPage = false;
                SitePage.ModifiedDate = DateTime.Now;
                SitePage.PageStatusId = Convert.ToInt32(pageState.Value);
                SitePage.RevisionDate = DateTime.Now;
                SitePage.SecurityAccessTypeId = Convert.ToInt32(pageSecurityAccess.Value);
                SitePage.UniquePageName = pageAlias.Text;
                SitePage.SectionId = Convert.ToInt32(pageSection.Value);
                SitePage.IsMainPage = chkIsMainPage.Checked;
                BusinessLogicLayer.Common.SitePageLogic.Update(SitePage, SitePage.SitePageId);
                DevExpress.Web.ASPxEditors.ASPxListBox checkbox = categoriesDropDownEdit.FindControl("listBox") as DevExpress.Web.ASPxEditors.ASPxListBox;
                BusinessLogicLayer.Common.SitePageCategoryLogic.DeleteBySitePageId(SitePage.SitePageId);
                if (checkbox != null)
                {
                    foreach (DevExpress.Web.ASPxEditors.ListEditItem item in checkbox.Items)
                    {
                        if (item.Value.ToString() != "0" && item.Selected)
                        {
                            BusinessLogicLayer.Common.SitePageCategoryLogic.Insert(Convert.ToInt32(item.Value), SitePage.SitePageId, DateTime.Now);
                        }
                    }
                }
                BusinessLogicLayer.Common.SitePageLanguageLogic.DeleteBySitePageId(SitePage.SitePageId);
                foreach (BusinessLogicLayer.Entities.ContentManagement.SitePageLanguage lang in SitePage.CurrentSitePageLanguages)
                {
                    lang.SitePageId = SitePage.SitePageId;
                    BusinessLogicLayer.Common.SitePageLanguageLogic.Insert(lang);
                }


                #endregion
            }
        }
        private string GetErrorMessageClasses()
        {
            return "message error no-margin";
        }
        private string GetSuccessMessageClasses()
        {
            return "message success no-margin";
        }
        #endregion

        protected void btnSaveandClose_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMethod();
                NotifyMessageRedirect(NotifyMessageType.Success, "Data Saved Successfully", "Manage.aspx");

            }
            catch (Exception ex)
            {
                NotifyMessage(NotifyMessageType.Error, ex.Message);
            }
        }

        protected void SaveandNew_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMethod();
                NotifyMessageRedirect(NotifyMessageType.Success, "Data Saved Successfully", "Save.aspx?PageCode=0");
            }
            catch (Exception ex)
            {
                NotifyMessage(NotifyMessageType.Error, ex.Message);
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMethod();
                if (SitePage.NewRecord)
                    NotifyMessageRedirect(NotifyMessageType.Success, "Data Saved Successfully", "Save.aspx?PageCode=" + SitePage.SitePageId);
                else
                    NotifyMessage(NotifyMessageType.Success, "Data Saved Successfully");
            }
            catch (Exception ex)
            {
                NotifyMessage(NotifyMessageType.Error, ex.Message);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manage.aspx");
        }
    }
}