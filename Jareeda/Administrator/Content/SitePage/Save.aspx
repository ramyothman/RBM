<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="Administrator.Content.SitePage.Save" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">
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
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="Save Page"></asp:Literal>
        </h1>

    </div>
    <div class="col-md-7 control-box">
        <ul>
            <li>
               <dx:ASPxButton ID="btnCancel" runat="server" Text="<%$Resources:ContentManagement, Cancel %>" Font-Size="8pt" ImagePosition="Top" ImageSpacing="0px" OnClick="btnCancel_Click" ValidationGroup="Cancel">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-cancel.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnSaveandNew" runat="server" Text="<%$Resources:ContentManagement, SaveandNew %>" Font-Size="8pt" ImagePosition="Top" ImageSpacing="0px" OnClick="SaveandNew_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-save-new.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnSaveandClose" runat="server" Text="<%$Resources:ContentManagement, SaveandClose %>" Font-Size="8pt" ImagePosition="Top" ImageSpacing="0px" OnClick="btnSaveandClose_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-save.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:ContentManagement, Save %>" Font-Size="8pt" ImagePosition="Top" ImageSpacing="0px" OnClick="btnSave_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-apply.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            
        </ul>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
     <div class="admin-form">
        <div id="LanguageRow" class="row">
            <span class="label">Language</span>
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
        <div id="AliasRow" class="row">
            <span class="label">Alias</span>
            <div class="editor">
                <dx:ASPxTextBox ID="pageAlias" runat="server" Width="100%" Font-Size="16px">
                    </dx:ASPxTextBox>
            </div>
        </div>
        <div id="SiteRow" class="row">
            <span class="label">Site</span>
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
            <span class="label">Section</span>
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
        
        <div id="CategoryRow" class="row">
            <span class="label">Categories</span>
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
            <span class="label">State</span>
            <div class="editor">
                 <dx:ASPxComboBox ID="pageState" runat="server" DataSourceID="StateObjectDS" Width="100%" Font-Size="14px" 
                        TextField="Name" ValueField="PageStatusId" ValueType="System.Int32" 
                        OnSelectedIndexChanged="pageState_SelectedIndexChanged">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Status" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="StateObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.PageStatusLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>
        
        <div id="AccessRow" class="row">
            <span class="label">Security Access</span>
            <div class="editor">
               <dx:ASPxComboBox ID="pageSecurityAccess" runat="server" Width="100%" Font-Size="14px" 
                        DataSourceID="SecurityAccessObjectDS" TextField="Name" 
                        ValueField="SecurityAccessTypeId" ValueType="System.Int32">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="Text" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Access" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="SecurityAccessObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.RoleSecurity.SecurityAccessTypeLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>               
                       
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
      <dx:ASPxCallbackPanel ID="pageContentLanguageCallbackPanel"
        ClientInstanceName="pageContentLanguageCallbackPanel" runat="server" Width="100%" oncallback="pageContentLanguageCallbackPanel_Callback">
        <PanelCollection>
           <dx:PanelContent>
               
                <div class="admin-form-main">
                <div id="PageTitleRow" class="row">
                    <div class="editor">
                        <dx:ASPxTextBox ID="pageTitle" runat="server" Width="100%" Font-Size="22px" NullText="Add a Title" Font-Names="Segoe UI,Segoe UI Web Regular,Segoe UI Symbol,Helvetica Neue,BBAlpha Sans,S60 Sans,Arial,sans-serif">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Enter Title" IsRequired="True" />
<RequiredField IsRequired="True" ErrorText="* Please Enter Title"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    </div>
                </div>
                <div id="PageContentRow" class="row">
                    <div class="editor height-80">
                         <dx:ASPxHtmlEditor ID="pageContent" runat="server" Width="100%" Height="550px">
                <SettingsHtmlEditing AllowFormElements="True" AllowIFrames="True" 
                    AllowScripts="True" />
                    <SettingsDocumentSelector Enabled="True">
            <CommonSettings RootFolder="~/ContentData/Documents" AllowedFileExtensions=".doc, .docx, .xls, .xlsx, .pdf, .ppt, .pptx, .rtf" />

                        <editingsettings allowcreate="True" allowdelete="True" allowrename="True" />
<CommonSettings RootFolder="~/ContentData/Documents" 
                            AllowedFileExtensions=".doc, .docx, .xls, .xlsx, .pdf, .ppt, .pptx, .rtf" 
                            initialfolder="Documents" thumbnailfolder="~/ContentData/Documents"></CommonSettings>

<EditingSettings AllowCreate="True" AllowRename="True" AllowDelete="True"></EditingSettings>

                        <uploadsettings enabled="True" useadvanceduploadmode="True">
                        </uploadsettings>
            <PermissionSettings>
                <AccessRules>
                    <dx:FileManagerFolderAccessRule Role="" Upload="Allow" />
                    <dx:FileManagerFolderAccessRule Role="" Path="Documents" Upload="Allow" />
                </AccessRules>
            </PermissionSettings>
        </SettingsDocumentSelector>
        <SettingsImageSelector Enabled="True">
            <CommonSettings RootFolder="~/ContentData/Documents" ThumbnailFolder="~/ContentData/Documents"
                InitialFolder="Documents" />
<CommonSettings ThumbnailFolder="~/ContentData/Documents" RootFolder="~/ContentData/Documents" InitialFolder="Documents" AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png"></CommonSettings>

            <editingsettings allowcreate="True" />

<EditingSettings AllowCreate="True"></EditingSettings>

            <uploadsettings enabled="True" useadvanceduploadmode="True">
            </uploadsettings>
            <PermissionSettings>
                <AccessRules>
                    <dx:FileManagerFolderAccessRule Role="" Upload="Allow" Browse="Allow" 
                        Edit="Allow" EditContents="Allow" />
                    <dx:FileManagerFolderAccessRule Role="" Path="Documents" Upload="Allow" 
                        Browse="Allow" Edit="Allow" EditContents="Allow" />
                </AccessRules>
            </PermissionSettings>
        </SettingsImageSelector>

<SettingsHtmlEditing AllowScripts="True" AllowIFrames="True" AllowFormElements="True"></SettingsHtmlEditing>

                <SettingsImageUpload useadvanceduploadmode="True">
                    <ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png">
                    </ValidationSettings>
                </SettingsImageUpload>
                <SettingsImageSelector>
                    <CommonSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png" />
                </SettingsImageSelector>
            </dx:ASPxHtmlEditor>

                    </div>
                </div>
                <div id="PageIsMainRow" class="row">
                    <div style="float:left">
                    <dx:ASPxCheckBox Text="Is Main Page" Font-Size="13px" runat="server" ID="chkIsMainPage"></dx:ASPxCheckBox>
                        </div>
                    
                    
                </div>
                
            </div>
           </dx:PanelContent>
           
        </PanelCollection>
    </dx:ASPxCallbackPanel>
   
</asp:Content>
