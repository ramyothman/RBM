<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="Administrator.ContentManagement.Article.Save" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    
    <script type="text/javascript">
    function Uploader_OnUploadComplete(args) {
        if (args.isValid) {
            //            txtImageUploadPath.SetText(args.callbackData);
            lblIconPath.SetText(args.callbackData);
        }
    }
    var textSeparator = ";";
    function OnListBoxSelectionChanged(listBox, args) {
        if (args.index == 0)
            args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
        UpdateSelectAllItemState();
        UpdateText();
    }
    function UpdateSelectAllItemState() {
        IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
    }
    function IsAllSelected() {
        for (var i = 1; i < checkListBox.GetItemCount() ; i++)
            if (!checkListBox.GetItem(i).selected)
                return false;
        return true;
    }
    function UpdateText() {
        var selectedItems = checkListBox.GetSelectedItems();
        checkComboBox.SetText(GetSelectedItemsText(selectedItems));
    }
    function SynchronizeListBoxValues(dropDown, args) {
        checkListBox.UnselectAll();
        var texts = dropDown.GetText().split(textSeparator);
        var values = GetValuesByTexts(texts);
        checkListBox.SelectValues(values);
        UpdateSelectAllItemState();
        UpdateText();  // for remove non-existing texts
    }
    function GetSelectedItemsText(items) {
        var texts = [];
        for (var i = 0; i < items.length; i++)
            if (items[i].index != 0)
                texts.push(items[i].text);
        return texts.join(textSeparator);
    }
    function GetValuesByTexts(texts) {
        var actualValues = [];
        var item;
        for (var i = 0; i < texts.length; i++) {
            item = checkListBox.FindItemByText(texts[i]);
            if (item != null)
                actualValues.push(item.value);
        }
        return actualValues;
    }
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <h1><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, SATitle %>"></asp:Literal></h1>
    <div class="toolbar">
        <ul>
            
            <li>
                <asp:Button runat="server" ID="btnSave" CssClass="button-link icon-32-apply" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);"  Text="<%$Resources:ContentManagement, Save %>" OnClick="btnSave_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="btnSaveandClose" CssClass="button-link icon-32-save" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);" Text="<%$Resources:ContentManagement, SaveandClose %>" OnClick="btnSaveandClose_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="SaveandNew" CssClass="button-link icon-32-save-new" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);" Text="<%$Resources:ContentManagement, SaveandNew %>" OnClick="SaveandNew_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="btnCancel" CssClass="button-link icon-32-cancel" Text="<%$Resources:ContentManagement, Cancel %>" OnClick="btnCancel_Click"/>
            </li>
        </ul>
    </div>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
     <div class="admin-form">
        <div id="LanguageRow" class="row">
            <span class="label"><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, SALanguage %>"></asp:Literal></span>
            <div class="editor">
                <dx:ASPxComboBox ID="pageLanguages" runat="server" 
                        DataSourceID="PageContentObjectDS" TextField="Name" ValueField="LanguageId" Width="100%" Font-Size="14px"  
                        ValueType="System.Int32">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	pageContentLanguageCallbackPanel.PerformCallback(s.GetValue());
}" />
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="PageContentObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>
       <div id="TypeRow" class="row">
            <span class="label"><asp:Literal ID="Literal12" runat="server" Text="<%$Resources:ContentManagement, SAArticleType %>"></asp:Literal></span>
            <div class="editor">
                  <dx:ASPxComboBox ID="pageArticleType" runat="server" DataSourceID="ArticleTypeObjectDS" Width="100%" Font-Size="14px"  
                        TextField="Name" ValueField="ArticleTypeID" ValueType="System.Int32">
                        
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Article Type" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="ArticleTypeObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleTypeLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>
        <div id="SiteRow" class="row">
            <span class="label"><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:ContentManagement, SASite %>"></asp:Literal></span>
            <div class="editor">
                  <dx:ASPxComboBox ID="pageSite" runat="server" DataSourceID="SiteObjectDS" Width="100%" Font-Size="14px"  
                        TextField="Name" ValueField="SiteId" ValueType="System.Int32">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	pageSection.PerformCallback(s.GetValue());
}" />
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Site" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="SiteObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>
        <div id="SectionRow" class="row">
            <span class="label"><asp:Literal ID="Literal3" runat="server" Text="<%$Resources:ContentManagement, SASection %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxComboBox ID="pageSection" runat="server" Font-Size="14px" Width="100%"  
                        ClientInstanceName="pageSection" DataSourceID="SectionObjectDS" 
                        oncallback="pageSection_Callback" TextField="Name" ValueField="SiteSectionId" 
                        ValueType="System.Int32">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Section" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="SectionObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteId" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic">
                        <SelectParameters>
                            <asp:Parameter Name="SiteId" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
            </div>
        </div>
        <div id="AuthorRow" class="row">
            <span class="label"><asp:Literal ID="Literal13" runat="server" Text="<%$Resources:ContentManagement, SAAuthor %>"></asp:Literal></span>
            <div class="editor">
                  <dx:ASPxComboBox ID="pageAuthor" runat="server" DataSourceID="AuthorObjectDS" Width="100%" Font-Size="14px"  
                        TextField="DisplayName" ValueField="BusinessEntityId" ValueType="System.Int32">
                        
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Author" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="AuthorObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.Persons.PersonLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>
        <div id="CategoryRow" class="row">
            <span class="label"><asp:Literal ID="Literal4" runat="server" Text="<%$Resources:ContentManagement, SACategories %>"></asp:Literal></span>
            <div class="editor">
                <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="categoriesDropDownEdit" Width="100%" Font-Size="14px" runat="server" EnableAnimation="False">
                     <DropDownWindowTemplate>
                         <dx:ASPxListBox Width="100%" Font-Size="14px" ID="listBox" ClientInstanceName="checkListBox" 
                             SelectionMode="CheckColumn" runat="server" 
                             DataSourceID="CategoriesObjectDS" TextField="Name" ValueField="SiteCategoryId" 
                             ValueType="System.Int32">
                             <ClientSideEvents SelectedIndexChanged="OnListBoxSelectionChanged" />
                         </dx:ASPxListBox>
                         
                         <table style="width:100%"><tr><td align="right">
                             <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close">
                                 <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                             </dx:ASPxButton>
                         </td></tr></table>
                     </DropDownWindowTemplate>
                     <ClientSideEvents TextChanged="SynchronizeListBoxValues" DropDown="SynchronizeListBoxValues" />

<ClientSideEvents DropDown="SynchronizeListBoxValues" TextChanged="SynchronizeListBoxValues"></ClientSideEvents>
                 </dx:ASPxDropDownEdit>
                    <asp:ObjectDataSource ID="CategoriesObjectDS" runat="server" 
                             OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                             TypeName="BusinessLogicLayer.Components.ContentManagement.SiteCategoryLogic">
                     </asp:ObjectDataSource>
            </div>
        </div>
        
        <div id="StateRow" class="row">
            <span class="label"><asp:Literal ID="Literal5" runat="server" Text="<%$Resources:ContentManagement, SAState %>"></asp:Literal></span>
            <div class="editor">
                 <dx:ASPxComboBox ID="pageState" runat="server" DataSourceID="StateObjectDS" Width="100%" Font-Size="14px" 
                        TextField="Name" ValueField="ArticleStatusId" ValueType="System.Int32" 
                        OnSelectedIndexChanged="pageState_SelectedIndexChanged">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Status" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="StateObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleStatusLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>
        
        <div id="AccessRow" class="row">
            <span class="label"><asp:Literal ID="Literal6" runat="server" Text="<%$Resources:ContentManagement, SACommentType %>"></asp:Literal></span>
            <div class="editor">
                <dx:ASPxComboBox ID="cmbCommentType" runat="server" Font-Size="14px" Width="100%"  
                        ClientInstanceName="pageSection" DataSourceID="ObjectDataSource1" 
                        TextField="CommentTypeName" ValueField="CommentTypeID" 
                        ValueType="System.Int32">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Section" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                                    TypeName="BusinessLogicLayer.Components.ContentManagement.CommentTypeLogic">
                                </asp:ObjectDataSource>
            </div>
        </div>               
                       
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <dx:ASPxCallbackPanel ID="pageContentLanguageCallbackPanel"
        ClientInstanceName="pageContentLanguageCallbackPanel" runat="server" Width="100%" oncallback="pageContentLanguageCallbackPanel_Callback">
        <PanelCollection>
           <dx:PanelContent>
               
                <div class="admin-form-main">
                <div id="PageTitleRow" class="row">
                    <div class="editor">
                        <span><asp:Literal ID="Literal14" runat="server" Text="<%$Resources:ContentManagement, SAArticleTitle %>"></asp:Literal></span>
                        <dx:ASPxTextBox ID="pageTitle" runat="server" Width="100%" Font-Size="22px" NullText="<%$Resources:ContentManagement, SAAddTitle %>" Font-Names="Segoe UI,Segoe UI Web Regular,Segoe UI Symbol,Helvetica Neue,BBAlpha Sans,S60 Sans,Arial,sans-serif">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Enter Title" IsRequired="True" />
<RequiredField IsRequired="True" ErrorText="* Please Enter Title"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    </div>
                </div>
                    <div id="PageSubTitleRow" class="row">
                    <div class="editor">
                        <span><asp:Literal ID="Literal15" runat="server" Text="<%$Resources:ContentManagement, SAArticleSubTitle %>"></asp:Literal></span>
                        <dx:ASPxTextBox ID="pageSubTitle" runat="server" Width="100%" Font-Size="22px" NullText="<%$Resources:ContentManagement, SASubTitle %>" Font-Names="Segoe UI,Segoe UI Web Regular,Segoe UI Symbol,Helvetica Neue,BBAlpha Sans,S60 Sans,Arial,sans-serif">
                        
                    </dx:ASPxTextBox>
                    </div>
                </div>
                    <div id="PageShortTitleRow" class="row">
                    <div class="editor">
                        <span><asp:Literal ID="Literal16" runat="server" Text="<%$Resources:ContentManagement, SAArticleShortTitle %>"></asp:Literal></span>
                        <dx:ASPxTextBox ID="pageShortTitle" runat="server" Width="100%" Font-Size="22px" NullText="<%$Resources:ContentManagement, SAShortTitle %>" Font-Names="Segoe UI,Segoe UI Web Regular,Segoe UI Symbol,Helvetica Neue,BBAlpha Sans,S60 Sans,Arial,sans-serif">
                        
                    </dx:ASPxTextBox>
                    </div>
                </div>
                    
                <div id="PageContentRow" class="row">
                    <div class="editor">
                         <dx:ASPxPageControl ID="ArticlePageControl" runat="server" ActiveTabIndex="2" Width="100%">
                        <TabPages>
                            <dx:TabPage Text="<%$Resources:ContentManagement, SAArticleContent %>">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl1" runat="server">
                                        <dx:ASPxHtmlEditor ID="pageContent" runat="server" Width="100%">
                                            <SettingsHtmlEditing AllowIFrames="True" EnterMode="BR" />
                                            <SettingsImageUpload UploadImageFolder="~/ContentData/Images/">
                                            </SettingsImageUpload>
                                            <SettingsImageSelector Enabled="True">
                                                <CommonSettings RootFolder="~/ContentData/Images/" />
                                                <EditingSettings AllowCreate="True" AllowDelete="True" AllowMove="True" AllowRename="True" />
                                                <UploadSettings Enabled="True">
                                                </UploadSettings>
                                            </SettingsImageSelector>
                                            <SettingsDocumentSelector Enabled="True">
                                                <CommonSettings AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp, .jpe, .jpeg, .jpg, .gif, .png" RootFolder="~/ContentData/Documents/" />
                                                <EditingSettings AllowCreate="True" AllowDelete="True" AllowMove="True" AllowRename="True" />
                                                <UploadSettings Enabled="True">
                                                </UploadSettings>
                                            </SettingsDocumentSelector>
                                        </dx:ASPxHtmlEditor>

                                          
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="<%$Resources:ContentManagement, SADescription %>">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl2" runat="server">
                                        <dx:ASPxMemo runat="server" ID="txtSummaryText" Width="100%" Height="550px"></dx:ASPxMemo>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="<%$Resources:ContentManagement, SAMoreInfo %>">
                                <ContentCollection>
                                    <dx:ContentControl ID="ContentControl3" runat="server">
                                              <div class="form">
                    <fieldset class="fieldset">
                        <table>
                            <tr>
                                <td style="vertical-align:top;">
                                    <section runat="server" >
							<div>
                                <dx:ASPxCheckBox ID="chkApplyWaterMark" ClientInstanceName="chkApplyWaterMark" runat="server" Text="<%$Resources:ContentManagement, SMApplyWaterMark %>">
                    </dx:ASPxCheckBox>
                            </div>
						</section>
                                    <section><label class="label" for="text_field"><asp:Literal ID="Literal7" runat="server" Text="<%$Resources:ContentManagement, SAMInfoImage %>"></asp:Literal></label>
							<div>
                                <dx:ASPxHiddenField ID="uploadHidden" ClientInstanceName="uploadHidden" runat="server"></dx:ASPxHiddenField>
                               <dx:ASPxUploadControl ID="conferenceLogoUpload" runat="server" 
                                ClientInstanceName="conferenceLogoUpload"  Width="250px"
                                onfileuploadcomplete="conferenceLogoUpload_FileUploadComplete"  
                                ShowProgressPanel="True" ShowUploadButton="True">
                                <ClientSideEvents FileUploadStart="function(s,e){uploadHidden.Set('HaveWaterMark',chkApplyWaterMark.GetValue());}" FileUploadComplete="function(s, e) {
                                    
	Uploader_OnUploadComplete(e);
                                    
}" />
<ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe,.gif,.png">
                                            </ValidationSettings>
                            </dx:ASPxUploadControl>
                            <dx:ASPxLabel ID="lblIconPath" runat="server" ClientInstanceName="lblIconPath">
                            </dx:ASPxLabel>
                            </div>
						</section>
                     <section runat="server" visible="false"><label class="label" for="text_field"><asp:Literal ID="Literal8" runat="server" Text="<%$Resources:ContentManagement, SAMInfoAlias %>"></asp:Literal></label>
							<div>
                                <dx:ASPxTextBox ID="txtAlias" runat="server" Width="250px" Font-Size="16px">
                    </dx:ASPxTextBox>
                            </div>
						</section>
                        <section runat="server" ><label class="label" for="text_field"><asp:Literal ID="Literal9" runat="server" Text="<%$Resources:ContentManagement, SAMInfoAuthor %>"></asp:Literal></label>
							<div>
                                <dx:ASPxTextBox ID="txtAuthor" runat="server" Width="250px" Font-Size="16px">
                    </dx:ASPxTextBox>
                            </div>
						</section>
                         <section><label class="label" for="text_field"><asp:Literal ID="Literal10" runat="server" Text="<%$Resources:ContentManagement, SAMInfoPublishStart %>"></asp:Literal></label>
							<div>
                                <dx:ASPxDateEdit ID="txtPublishStart" runat="server" Width="250px" Font-Size="16px" DisplayFormatString="dd/MM/yyyy hh:mm tt" EditFormat="DateTime">
                    </dx:ASPxDateEdit>
                            </div>
						</section>
                        <section><label class="label" for="text_field"><asp:Literal ID="Literal11" runat="server" Text="<%$Resources:ContentManagement, SAMInfoPublishEnd %>"></asp:Literal></label>
							<div>
                                <dx:ASPxDateEdit ID="txtPublishEnd" runat="server" Width="250px" Font-Size="16px" DisplayFormatString="dd/MM/yyyy hh:mm tt" EditFormat="DateTime">
                    </dx:ASPxDateEdit>
                            </div>
						</section>
                                </td>
                                <td style="vertical-align:top;padding:10px;">
                                     <section><label class="label" for="text_field"><asp:Literal ID="Literal17" runat="server" Text="<%$Resources:ContentManagement, SAMSources %>"></asp:Literal></label>
							<div>
                                <dx:ASPxCheckBoxList ID="chkListSources" runat="server" ValueType="System.Int32" DataSourceID="SourcesObjectDS" TextField="Name" ValueField="MediaSourceID" Width="100%"></dx:ASPxCheckBoxList>
                                <asp:ObjectDataSource ID="SourcesObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MediaSourceLogic"></asp:ObjectDataSource>
                            </div>
						</section>
                                    
                                </td>
                            </tr>
                        </table>
                        
                    <%--<label class="label">More Info</label>--%>
                    
                        </fieldset>
                        </div>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>
                        </dx:ASPxPageControl>
                    </div>
                </div>
              
                
            </div>
           </dx:PanelContent>
           
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    
</asp:Content>
