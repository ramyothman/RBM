using Administrator.Code;
using BusinessLogicLayer.Components.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.ContentManagement.Menu
{
    public partial class Save : AdminBasePage
    {
        private MenuEntityItem _Menu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillControls();
                if (Request.QueryString["ParentID"] == null)
                {
                    divForParent.Visible = true;
                }
            }
        }
        private void FillControls()
        {
            if (Request.QueryString["ID"] != null)
            {
                _Menu = new MenuEntityItemLogic().GetByID(Convert.ToInt32(Request.QueryString["ID"]));
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
            Response.Redirect("Manage.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool IsSaved;
            GetFormValues();
            if (Request.QueryString["ID"] != null)
            {
                IsSaved = new MenuEntityItemLogic().Update(_Menu, Convert.ToInt32(Request.QueryString["ID"]));
            }
            else
            {
                IsSaved = new MenuEntityItemLogic().Insert(_Menu);
            }
            if (IsSaved)
                Response.Redirect("Manage.aspx");
        }
        private void GetFormValues()
        {
            if (Request.QueryString["ID"] != null)
            {
                _Menu = new MenuEntityItemLogic().GetByID(Convert.ToInt32(Request.QueryString["ID"]));
            }
            else
            {
                _Menu = new MenuEntityItem();
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
    }
}