using Administrator.Code;
using CommonWeb.Common;
using CommonWeb.Security;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.ASPxUploadControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.g.Content.Article
{
    public partial class Save : Code.AdminBase
    {
        #region Properties
        public string SiteLink
        {
            set
            {

            }
        }
        protected void GridView_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)DropDownEdit.FindControl("GridView");
            object[] employeeNames = new object[grid.VisibleRowCount];
            object[] keyValues = new object[grid.VisibleRowCount];
            for (int i = 0; i < grid.VisibleRowCount; i++)
            {
                employeeNames[i] = grid.GetRowValues(i, "Name") + " : " + grid.GetRowValues(i, "SiteSectionParentId");
                keyValues[i] = grid.GetRowValues(i, "SiteSectionId");
            }
            e.Properties["cpEmployeeNames"] = employeeNames;
            e.Properties["cpKeyValues"] = keyValues;
        }
        protected void GridView_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            SynchronizeFocusedRow();
        }
        protected void SynchronizeFocusedRow()
        {
            ASPxGridView grid = (ASPxGridView)DropDownEdit.FindControl("GridView");
            object lookupKeyValue = DropDownEdit.KeyValue;
            grid.FocusedRowIndex = grid.FindVisibleIndexByKeyValue(lookupKeyValue);
        }
        public BusinessLogicLayer.Entities.ContentManagement.Article SitePage
        {
            get
            {
                if (Session["AMCurrentSiteArticle"] == null)
                {
                    Session["AMCurrentSiteArticle"] = new BusinessLogicLayer.Entities.ContentManagement.Article();
                }
                return Session["AMCurrentSiteArticle"] as BusinessLogicLayer.Entities.ContentManagement.Article;
            }
            set
            {
                Session["AMCurrentSiteArticle"] = value;
            }
        }

        public int OldLanguageId
        {
            get
            {
                if (Session["AMSiteArticleOldLanguageId"] == null)
                    return 0;
                else
                    return Convert.ToInt32(Session["AMSiteArticleOldLanguageId"]);
            }

            set { Session["AMSiteArticleOldLanguageId"] = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                uploadHidden.Add("HaveWaterMark", false);
                SitePage = null;
                Session["UploadedFile"] = null;
                DevExpress.Web.ASPxEditors.ASPxListBox checkbox = categoriesDropDownEdit.FindControl("listBox") as DevExpress.Web.ASPxEditors.ASPxListBox;
                if (checkbox != null)
                {
                    checkbox.DataBind();
                    checkbox.Items.Insert(0, new DevExpress.Web.ASPxEditors.ListEditItem("(Select All)", "0"));
                }
                pageSite.DataBind();
                pageState.DataBind();
                pageArticleType.DataBind();
                pageAuthor.DataBind();
                //pageAuthor.SelectedIndex = pageAuthor.Items.IndexOfValue(SecurityManager.getUser(this).BusinessEntityId);
                //pageSecurityAccess.DataBind();
                pageLanguages.DataBind();
                pageLanguages.SelectedIndex = pageLanguages.Items.IndexOfValue(BusinessLogicLayer.Common.DefaultLanguage.LanguageId);
                if (!string.IsNullOrEmpty(Request["Code"]))
                {
                    int pageId = 0;
                    Int32.TryParse(Request["Code"], out pageId);
                    SitePage = BusinessLogicLayer.Common.ArticleLogic.GetByID(pageId);

                    if (!SitePage.NewRecord)
                    {
                        SiteLink = pageId.ToString();
                        pageSite.SelectedIndex = pageSite.Items.IndexOfValue(SitePage.SiteId);
                        pageArticleType.SelectedIndex = pageArticleType.Items.IndexOfValue(SitePage.ArticleTypeID);
                        pageState.SelectedIndex = pageState.Items.IndexOfValue(SitePage.ArticleStatusId);
                        //pageSecurityAccess.SelectedIndex = pageSecurityAccess.Items.IndexOfValue(SitePage.SecurityAccessTypeId);

                        //pageAlias.Text = SitePage.UniquePageName;
                        //chkIsMainPage.Checked = SitePage.IsMainPage;
                        pageSection.DataBind();

                        ((DevExpress.Web.ASPxTreeList.ASPxTreeList)DropDownEdit.FindControl("SectionTreeView")).DataBind();
                        TreeListNode node = ((DevExpress.Web.ASPxTreeList.ASPxTreeList)DropDownEdit.FindControl("SectionTreeView")).FindNodeByKeyValue(SitePage.SiteSectionId.ToString());
                        node.Focus();
                        DropDownEdit.KeyValue = SitePage.SiteSectionId;
                        DropDownEdit.Text = GetEntryText(node);
                        pageSection.SelectedIndex = pageSection.Items.IndexOfValue(SitePage.SiteSectionId);
                        List<BusinessLogicLayer.Entities.ContentManagement.ArticleCategory> cats = BusinessLogicLayer.Common.ArticleCategoryLogic.GetAllByArticleId(SitePage.ArticleId);
                        foreach (BusinessLogicLayer.Entities.ContentManagement.ArticleCategory cat in cats)
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
                                    BusinessLogicLayer.Common.ArticleCategoryLogic.Insert(Convert.ToInt32(item.Value), SitePage.ArticleId, DateTime.Now);
                                }
                            }
                        }
                        cmbCommentType.DataBind();
                        cmbCommentType.SelectedIndex = cmbCommentType.Items.IndexOfValue(SitePage.CommentsTypeId);
                        pageLanguages.SelectedIndex = pageLanguages.Items.IndexOfValue(BusinessLogicLayer.Common.DefaultLanguage.LanguageId);
                        BusinessLogicLayer.Entities.ContentManagement.ArticleLanguage splang = SitePage.GetArticlePageLanguageByLanguageId(Convert.ToInt32(pageLanguages.SelectedItem.Value));
                        pageTitle.Text = splang.ArticleName;
                        pageSubTitle.Text = splang.ArticleSubTitle;
                        pageShortTitle.Text = splang.ArticleShortTitle;
                        pageContent.Html = splang.ArticleContent;
                        txtAlias.Text = splang.ArticleAlias;
                        txtAuthor.Text = splang.AuthorAlias;
                        txtSummaryText.Text = splang.ArticleSummary;
                        pageAuthor.SelectedIndex = pageAuthor.Items.IndexOfValue(SitePage.AuthorId);
                        if (chkListSources.Items.Count == 0)
                            chkListSources.DataBind();
                        foreach (BusinessLogicLayer.Entities.ContentManagement.ArticleSources source in SitePage.ArticleSources)
                        {
                            chkListSources.Items.FindByValue(source.SourceID).Selected = true;
                        }

                        List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle> Articles = new BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic().GetAllByHomePageIDOrdered(48);
                        foreach (BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle article in Articles)
                        {
                            if (article.ArticleID == SitePage.ArticleId)
                            {
                                InSliderOrder.Value = article.ArticleOrder;
                                InSlider.Checked = true;
                                
                            }
                        }
                        //pageAlias.Text = splang.ArticleAlias;
                    }
                }
                OldLanguageId = (int)pageLanguages.SelectedItem.Value;
            }
        }

        #region Events
        private void SaveMethod()
        {
            #region Getting Language Last Updates
            BusinessLogicLayer.Entities.ContentManagement.ArticleLanguage oldLanguage = SitePage.GetArticlePageLanguageByLanguageId(OldLanguageId);
            oldLanguage.ArticleName = pageTitle.Text;
            oldLanguage.ArticleSubTitle = pageSubTitle.Text;
            oldLanguage.ArticleShortTitle = pageShortTitle.Text;
            oldLanguage.ArticleContent = pageContent.Html;
            oldLanguage.ModifiedDate = DateTime.Now;
            oldLanguage.ArticleSummary = txtSummaryText.Text;
            oldLanguage.AuthorAlias = txtAuthor.Text;
            oldLanguage.ArticleAlias = txtAlias.Text;
            oldLanguage.LanguageId = OldLanguageId;
            if (Session["UploadedFile"] != null)
                oldLanguage.ArticleAttachment = Session["UploadedFile"].ToString();
            //oldLanguage.ArticleAlias = pageAlias.Text;
            if (oldLanguage.NewRecord)
            {
                oldLanguage.NewRecord = false;
                SitePage.CurrentArticleLanguage.Add(oldLanguage);
            }
            #endregion

            if (SitePage.NewRecord)
            {
                #region Insert
                SitePage.CreatorId = SecurityManager.getUser(this).BusinessEntityId;
                SitePage.AuthorId = Convert.ToInt32(pageAuthor.Value);
                //SitePage.IsMainPage = false;
                SitePage.ModifiedDate = DateTime.Now;
                SitePage.ArticleStatusId = Convert.ToInt32(pageState.Value);
                SitePage.ArticleTypeID = Convert.ToInt32(pageArticleType.Value);
                SitePage.PostDate = DateTime.Now;
                //SitePage.SecurityAccessTypeId = Convert.ToInt32(pageSecurityAccess.Value);
                //SitePage.UniquePageName = pageAlias.Text;
                if (cmbCommentType.Value != null)
                    SitePage.CommentsTypeId = Convert.ToInt32(cmbCommentType.Value);
                else
                    SitePage.CommentsTypeId = 1;
                //SitePage.SiteSectionId = Convert.ToInt32(pageSection.Value);
                SitePage.SiteSectionId = Convert.ToInt32(DropDownEdit.KeyValue.ToString());
                //SitePage.is = chkIsMainPage.Checked;

                BusinessLogicLayer.Common.ArticleLogic.Insert(SitePage);
                //SitePage.NewRecord = false;
                List<BusinessLogicLayer.Entities.ContentManagement.ArticleCategory> cats = new List<BusinessLogicLayer.Entities.ContentManagement.ArticleCategory>();
                DevExpress.Web.ASPxEditors.ASPxListBox checkbox = categoriesDropDownEdit.FindControl("listBox") as DevExpress.Web.ASPxEditors.ASPxListBox;
                if (checkbox != null)
                {

                    foreach (DevExpress.Web.ASPxEditors.ListEditItem item in checkbox.Items)
                    {
                        if (item.Value.ToString() != "0" && item.Selected)
                        {
                            BusinessLogicLayer.Common.ArticleCategoryLogic.Insert(Convert.ToInt32(item.Value), SitePage.ArticleId, DateTime.Now);
                        }
                    }
                }
                foreach (BusinessLogicLayer.Entities.ContentManagement.ArticleLanguage lang in SitePage.CurrentArticleLanguage)
                {
                    lang.ArticleId = SitePage.ArticleId;
                    BusinessLogicLayer.Common.ArticleLanguageLogic.Insert(lang);
                }

                #endregion
            }
            else
            {
                #region Update
                SitePage.CreatorId = SecurityManager.getUser(this).BusinessEntityId;
                SitePage.AuthorId = Convert.ToInt32(pageAuthor.Value);
                //SitePage.IsMainPage = false;
                SitePage.ModifiedDate = DateTime.Now;
                SitePage.ArticleStatusId = Convert.ToInt32(pageState.Value);
                SitePage.ArticleTypeID = Convert.ToInt32(pageArticleType.Value);

                //SitePage.SecurityAccessTypeId = Convert.ToInt32(pageSecurityAccess.Value);
                //SitePage. = pageAlias.Text;
                //SitePage.SiteSectionId = Convert.ToInt32(pageSection.Value);
                SitePage.SiteSectionId = Convert.ToInt32(DropDownEdit.KeyValue.ToString());
                //SitePage.IsMainPage = chkIsMainPage.Checked;
                if (cmbCommentType.Value != null)
                    SitePage.CommentsTypeId = Convert.ToInt32(cmbCommentType.Value);
                else
                    SitePage.CommentsTypeId = 1;
                BusinessLogicLayer.Common.ArticleLogic.Update(SitePage, SitePage.ArticleId);
                DevExpress.Web.ASPxEditors.ASPxListBox checkbox = categoriesDropDownEdit.FindControl("listBox") as DevExpress.Web.ASPxEditors.ASPxListBox;
                BusinessLogicLayer.Common.ArticleCategoryLogic.DeleteByArticleId(SitePage.ArticleId);
                if (checkbox != null)
                {
                    foreach (DevExpress.Web.ASPxEditors.ListEditItem item in checkbox.Items)
                    {
                        if (item.Value.ToString() != "0" && item.Selected)
                        {
                            BusinessLogicLayer.Common.ArticleCategoryLogic.Insert(Convert.ToInt32(item.Value), SitePage.ArticleId, DateTime.Now);
                        }
                    }
                }
                BusinessLogicLayer.Common.ArticleLanguageLogic.DeleteByArticleId(SitePage.ArticleId);
                foreach (BusinessLogicLayer.Entities.ContentManagement.ArticleLanguage lang in SitePage.CurrentArticleLanguage)
                {
                    lang.ArticleId = SitePage.ArticleId;
                    BusinessLogicLayer.Common.ArticleLanguageLogic.Insert(lang);
                }


                #endregion
            }

            if(InSlider.Checked)
            {
                List<BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle> Articles = new BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic().GetAllByHomePageIDOrdered(48);
                var ar = (from x in Articles where x.ArticleOrder == Convert.ToInt32(InSliderOrder.Value) select x).FirstOrDefault();
                if(ar != null)
                {
                    ar.ArticleID = SitePage.ArticleId;
                    new BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic().Update(ar, ar.ContentModuleArticleID);
                }
                else
                {
                    int index = 1;
                    foreach (BusinessLogicLayer.Entities.ContentManagement.ContentModuleArticle article in Articles)
                    {
                        if (article.ArticleOrder == 0 && index != Convert.ToInt32(InSliderOrder.Value))
                        {
                            article.ArticleOrder = index;
                            new BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic().Update(article, article.ContentModuleArticleID);
                        }
                        else
                        {
                            article.ArticleID = SitePage.ArticleId;
                            article.ArticleOrder = Convert.ToInt32(InSliderOrder.Value);
                            new BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic().Update(article, article.ContentModuleArticleID);
                        }
                        index++;
                    }
                }
                
            }

            new BusinessLogicLayer.Components.ContentManagement.ArticleSourcesLogic().DeleteByArticleID(SitePage.ArticleId);
            foreach (int x in chkListSources.SelectedValues)
            {
                new BusinessLogicLayer.Components.ContentManagement.ArticleSourcesLogic().Insert(x, SitePage.ArticleId);
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
                SiteLink = SitePage.ArticleId.ToString();
            }
            catch (Exception ex)
            {
                //NoticeMessageDiv.Visible = true;
                //NoticeMessageDiv.Attributes.Remove("class");
                //NoticeMessageDiv.Attributes.Add("class", GetErrorMessageClasses());
                //NoticeMessage.InnerHtml = "<span>Error Saving: </span>" + ex.Message;
                return;
            }
            Response.Redirect("ManageSiteArticles.aspx");
        }

        protected void pageSection_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            SectionObjectDS.SelectParameters[0].DefaultValue = e.Parameter;
            pageSection.DataBind();
        }

        protected void pageContentLanguageCallbackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            BusinessLogicLayer.Entities.ContentManagement.ArticleLanguage oldLanguage = SitePage.GetArticlePageLanguageByLanguageId(OldLanguageId);
            BusinessLogicLayer.Entities.ContentManagement.ArticleLanguage newlanguage = SitePage.GetArticlePageLanguageByLanguageId(Convert.ToInt32(e.Parameter));

            oldLanguage.ArticleName = pageTitle.Text;
            oldLanguage.ArticleSubTitle = pageSubTitle.Text;
            oldLanguage.ArticleShortTitle = pageShortTitle.Text;

            oldLanguage.ArticleContent = pageContent.Html;
            oldLanguage.ArticleSummary = txtSummaryText.Text;
            oldLanguage.ArticleAlias = txtAlias.Text;
            oldLanguage.AuthorAlias = txtAuthor.Text;
            oldLanguage.ModifiedDate = DateTime.Now;
            if (!string.IsNullOrEmpty(txtPublishStart.Text))
                oldLanguage.PublishStartDate = txtPublishStart.Date;
            if (!string.IsNullOrEmpty(txtPublishEnd.Text))
                oldLanguage.PublishEndDate = txtPublishEnd.Date;
            oldLanguage.LanguageId = OldLanguageId;
            if (Session["UploadedFile"] != null)
                oldLanguage.ArticleAttachment = Session["UploadedFile"].ToString();
            //oldLanguage.ArticleAlias = pageAlias.Text;
            if (oldLanguage.NewRecord)
            {
                oldLanguage.NewRecord = false;
                SitePage.CurrentArticleLanguage.Add(oldLanguage);
            }

            //pageAlias.Text = newlanguage.ArticleAlias;
            pageContent.Html = newlanguage.ArticleContent;
            pageTitle.Text = newlanguage.ArticleName;
            pageSubTitle.Text = newlanguage.ArticleSubTitle;
            pageShortTitle.Text = newlanguage.ArticleShortTitle;

            txtSummaryText.Text = newlanguage.ArticleSummary;
            txtAlias.Text = newlanguage.ArticleAlias;
            txtAuthor.Text = newlanguage.AuthorAlias;
            if (newlanguage.PublishStartDate == DateTime.MinValue)
                txtPublishStart.Text = "";
            else
                txtPublishStart.Date = newlanguage.PublishStartDate;
            if (newlanguage.PublishEndDate == DateTime.MinValue)
                txtPublishEnd.Text = "";
            else
                txtPublishEnd.Date = newlanguage.PublishEndDate;
            OldLanguageId = Convert.ToInt32(e.Parameter);

        }

        protected void pageState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string SavePostedFile(UploadedFile uploadedFile, bool HaveWaterMark)
        {
            BusinessLogicLayer.Entities.ContentManagement.ArticleLanguage oldLanguage = SitePage.GetArticlePageLanguageByLanguageId(OldLanguageId);
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
                    if (oldLanguage != null)
                    {
                        oldLanguage.ArticleAttachment = fileName;
                    }
                    //uploadedFile.SaveAs(Server.MapPath("~/ContentData/MenuImages/") + fileName, true);
                    //byte[] thumb = Tools.CreateThumb(uploadedFile.FileBytes, 32, true);
                    //MemoryStream stream = new MemoryStream(thumb);
                    string fileName_withoutWaterMark = "now" + fileName;
                    if (HaveWaterMark)
                    {
                        FileStream stream = new FileStream(Server.MapPath(BusinessLogicLayer.Common.ConferenceContentPath) + fileName_withoutWaterMark, FileMode.Create);
                        stream.Write(uploadedFile.FileBytes, 0, uploadedFile.FileBytes.Length);
                        stream.Flush();
                        stream.Close();
                        WaterMarkImage.SaveImageWithWaterMark(Server.MapPath(BusinessLogicLayer.Common.ConferenceContentPath), "www.almnatiq.net", fileName_withoutWaterMark, "watermark.png", fileName);
                    }
                    else
                    {
                        FileStream stream = new FileStream(Server.MapPath(BusinessLogicLayer.Common.ConferenceContentPath) + fileName, FileMode.Create);
                        stream.Write(uploadedFile.FileBytes, 0, uploadedFile.FileBytes.Length);
                        stream.Flush();
                        stream.Close();

                    }
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
            bool HaveWaterMark = false;

            Boolean.TryParse(uploadHidden.Get("HaveWaterMark") == null ? "False" : uploadHidden.Get("HaveWaterMark").ToString(), out HaveWaterMark);
            e.CallbackData = SavePostedFile(e.UploadedFile, HaveWaterMark);
        }




        List<string> sectionNames = new List<string>();
        List<int> sectionKeys = new List<int>();
        void ProcessNodes(TreeListNode startNode, ASPxTreeList list)
        {
            if (startNode == null) return;
            TreeListNodeIterator iterator = new TreeListNodeIterator(startNode);
            while (iterator.Current != null)
            {
                GetParentNodeKey(iterator.Current, list);
                iterator.GetNext();
            }
        }

        private void GetParentNodeKey(TreeListNode node, DevExpress.Web.ASPxTreeList.ASPxTreeList treeList)
        {
            if (node != treeList.RootNode && node.HasChildren)
            {
                sectionKeys.Add(Convert.ToInt32(node.Key));
                sectionNames.Add(node.GetValue("Name") + " : " + node.GetValue("SiteSectionParentId"));
            }
        }
        protected void TreeView_CustomJSProperties(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomJSPropertiesEventArgs e)
        {
            //DevExpress.Web.ASPxTreeList.ASPxTreeList grid = (DevExpress.Web.ASPxTreeList.ASPxTreeList)DropDownEdit.FindControl("SectionTreeView");
            //sectionNames = new List<string>();
            //sectionKeys = new List<int>();


            //for (int i = 0; i < grid.Nodes.Count; i++)
            //{
            //    ProcessNodes(grid.Nodes[i], grid);
            //}
            //e.Properties["cpSectionNames"] = sectionNames;
            //e.Properties["cpSectionKeyValues"] = sectionKeys;
        }

        protected void treeList_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
        {
            DevExpress.Web.ASPxTreeList.ASPxTreeList treeList = (DevExpress.Web.ASPxTreeList.ASPxTreeList)DropDownEdit.FindControl("SectionTreeView");
            string key = e.Argument.ToString();
            TreeListNode node = treeList.FindNodeByKeyValue(key);
            e.Result = GetEntryText(node);
        }

        protected string GetEntryText(TreeListNode node)
        {
            if (node != null)
            {
                string text = "";
                if (node.ParentNode == null)
                    text = node["Name"].ToString();
                else
                    text = GetFullNodeName(node.ParentNode, node["Name"].ToString());
                return text;
            }
            return string.Empty;
        }

        string GetFullNodeName(TreeListNode node, string name)
        {
            if (node == null || node["Name"] == null) return name;
            if (node.ParentNode == null)
                return name += " <- " + node["Name"].ToString();
            else
                return GetFullNodeName(node.ParentNode, name += " <- " + node["Name"].ToString());
        }


        protected void btnSaveandClose_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMethod();
                Session["Notification"] = "success";
                Response.Redirect("~/g/Content/Article");

            }
            catch (Exception ex)
            {
                SetNotification("fail", ex.Message, "", this);
            }
        }

        protected void SaveandNew_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMethod();
                Session["Notification"] = "success";
                Response.Redirect("Save.aspx?Code=0");
            }
            catch (Exception ex)
            {
                SetNotification("fail", ex.Message, "", this);
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMethod();
                Session["Notification"] = "success";
                Response.Redirect("Save.aspx?Code=" + SitePage.ArticleId);
            }
            catch (Exception ex)
            {
                SetNotification("fail", ex.Message, "", this);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/g/Content/Article");
        }
        #endregion

        protected void fileManagerImageChooser_SelectedFileOpened(object source, DevExpress.Web.ASPxFileManager.FileManagerFileOpenedEventArgs e)
        {

            string fileName_withWaterMark = "w_" + e.File.Name;
            if (chkApplyWaterMark.Checked)
            {
                WaterMarkImage.SaveImageWithWaterMark(Server.MapPath(BusinessLogicLayer.Common.ConferenceContentPath), "www.almnatiq.net", e.File.Name, "watermark.png", "w_" + fileName_withWaterMark);
                Session["UploadedFile"] = fileName_withWaterMark;
                lblIconPath.Text = fileName_withWaterMark;
            }
            else
            {
                Session["UploadedFile"] = e.File.Name;
                lblIconPath.Text = e.File.Name;
            }
            
        }

    }
}