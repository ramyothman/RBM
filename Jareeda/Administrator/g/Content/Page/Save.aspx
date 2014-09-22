<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="Administrator.g.Content.Page.Save" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var MaxLength = 2200;
        var ConfirmMessage = "Are you sure you want to perform the action? Unsaved html content will be lost.";
        var CustomErrorText = "Custom validation fails because the HTML content&prime;s length exceeds " + MaxLength.toString() + " characters. The current length of characters: ";
        var CurrentDocumentIndex = -1;
        ASPxClientUtils.AttachEventToElement(window, "beforeunload", function (e) {
            if (!IsHtmlChanged() || CurrentDocumentIndex == -1)
                return;
            e.returnValue = ConfirmMessage;
            return ConfirmMessage;
        });
        function IsHtmlChanged() {
            return Ribbon.GetItemByName('SaveChanges').GetEnabled();
        }
        function UpdateRibbonItems() {
            Ribbon.GetItemByName("PreviousDocument").SetEnabled(ListBox.GetSelectedIndex() > 0);
            Ribbon.GetItemByName("NextDocument").SetEnabled(ListBox.GetSelectedIndex() != (ListBox.GetItemCount() - 1));
        }
        function SetEditingCommandEnabled(enabled) {
            Ribbon.GetItemByName('SaveChanges').SetEnabled(enabled);
            Ribbon.GetItemByName('CancelChanges').SetEnabled(enabled);
        }
        function LoadHtmlContent(htmlEditor, result) {
            if (result != null)
                htmlEditor.SetHtml(result);
            SetEditingCommandEnabled(false);
        }
        function CommandExecutedHandler(s, e) {
            var isHtmlChanged = IsHtmlChanged();
            switch (e.item.name) {
                case "PreviousDocument":
                    if (isHtmlChanged && !confirm(ConfirmMessage))
                        return;
                    ListBox.SelectIndex(ListBox.GetSelectedIndex() - 1);
                    break;
                case "NextDocument":
                    if (isHtmlChanged && !confirm(ConfirmMessage))
                        return;
                    ListBox.SelectIndex(ListBox.GetSelectedIndex() + 1);
                    break;
                case "SaveChanges":
                    HtmlEditor.Validate();
                    if (!HtmlEditor.GetIsValid())
                        return;
                    SetEditingCommandEnabled(false);
                    HtmlEditor.PerformDataCallback(e.item.name);
                    break;
                case "CancelChanges":
                    HtmlEditor.PerformDataCallback(e.item.name, LoadHtmlContent);
                    break;
            }
            if (!HtmlEditor.GetIsValid())
                HtmlEditor.SetIsValid(true)
            UpdateRibbonItems();
        }
        function ValidationHandler(s, e) {
            if (e.html.length > MaxLength) {
                e.isValid = false;
                e.errorText = CustomErrorText + e.html.length;
            }
        }
        function HtmlEditorInitHandler(s, e) {
            s.Focus();
            UpdateRibbonItems();
            SetEditingCommandEnabled(false);
            CurrentDocumentIndex = ListBox.GetSelectedIndex();
        }
        function HtmlChangedHandler(s, e) {
            if (!s.InCallback())
                SetEditingCommandEnabled(true);
        }
        function SelectedIndexChangedHandler(s, e) {
            if (IsHtmlChanged() && CurrentDocumentIndex != e.index && !confirm(ConfirmMessage))
                s.SetSelectedIndex(CurrentDocumentIndex);
            else {
                CurrentDocumentIndex = e.index;
                HtmlEditor.PerformDataCallback('CancelChanges', LoadHtmlContent);
                UpdateRibbonItems();
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
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-5">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/pagestest.png" />
        </div>
        <div class="title-text" runat="server" id="MenuManagerTitle"></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <ul>
            <li>
                <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:ContentManagement, Save %>" Font-Size="8pt" ImageSpacing="5px" OnClick="btnSave_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-apply.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnSaveandClose" runat="server" Text="<%$Resources:ContentManagement, SaveandClose %>" Font-Size="8pt" ImageSpacing="5px" OnClick="btnSaveandClose_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-save.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnSaveandNew" runat="server" Text="<%$Resources:ContentManagement, SaveandNew %>" Font-Size="8pt" ImageSpacing="5px" OnClick="SaveandNew_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-save-new.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnCancel" runat="server" Text="<%$Resources:ContentManagement, Cancel %>" Font-Size="8pt" ImageSpacing="5px" ValidationGroup="Cancel" OnClick="btnCancel_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-cancel.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="col-md-3 left-content">
        <div class="form">
            <div id="LanguageRow" class="row geni-left-item">
                <span class="geni-label"><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, PMSLanguage %>"></asp:Literal></span>
                <div class="geni-edit">
                    <dx:ASPxComboBox ID="pageLanguages" runat="server"
                        DataSourceID="PageContentObjectDS" TextField="Name" ValueField="LanguageId" Width="100%" Font-Size="14px"
                        ValueType="System.Int32">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	pageContentLanguageCallbackPanel.PerformCallback(s.GetValue());
}" />
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="PageContentObjectDS" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
                </div>
            </div>
            <div id="AliasRow" class="row geni-left-item">
                <span class="geni-label"><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:ContentManagement, PMSAlias %>"></asp:Literal></span>
                <div class="geni-edit">
                    <dx:ASPxTextBox ID="pageAlias" runat="server" Width="100%" Font-Size="16px">
                    </dx:ASPxTextBox>
                </div>
            </div>
            <div id="SiteRow" class="row geni-left-item">
                <span class="geni-label required"><asp:Literal ID="Literal3" runat="server" Text="<%$Resources:ContentManagement, PMSSite %>"></asp:Literal></span>
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
                        TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
                </div>
            </div>
            <div id="SectionRow" class="row geni-left-item">
                <span class="geni-label required"><asp:Literal ID="Literal4" runat="server" Text="<%$Resources:ContentManagement, PMSSection %>"></asp:Literal></span>
                <div class="geni-edit">
                    <dx:ASPxComboBox ID="pageSection" runat="server" Font-Size="14px" Width="100%"
                        ClientInstanceName="pageSection" DataSourceID="SectionObjectDS"
                        OnCallback="pageSection_Callback" TextField="Name" ValueField="SiteSectionId"
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

            <div id="CategoryRow" class="row geni-left-item">
                <span class="geni-label"><asp:Literal ID="Literal5" runat="server" Text="<%$Resources:ContentManagement, PMSCategory %>"></asp:Literal></span>
                <div class="geni-edit">
                    <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="categoriesDropDownEdit" Width="100%" Font-Size="14px" runat="server" EnableAnimation="False">
                        <DropDownWindowTemplate>
                            <dx:ASPxListBox Width="100%" Font-Size="14px" ID="listBox" ClientInstanceName="checkListBox"
                                SelectionMode="CheckColumn" runat="server"
                                DataSourceID="CategoriesObjectDS" TextField="Name" ValueField="SiteCategoryId"
                                ValueType="System.Int32">
                                <ClientSideEvents SelectedIndexChanged="OnListBoxSelectionChanged" />
                            </dx:ASPxListBox>

                            <table style="width: 100%">
                                <tr>
                                    <td align="right">
                                        <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Close">
                                            <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </DropDownWindowTemplate>
                        <ClientSideEvents TextChanged="SynchronizeListBoxValues" DropDown="SynchronizeListBoxValues" />

                        <ClientSideEvents DropDown="SynchronizeListBoxValues" TextChanged="SynchronizeListBoxValues"></ClientSideEvents>
                    </dx:ASPxDropDownEdit>
                    <asp:ObjectDataSource ID="CategoriesObjectDS" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="BusinessLogicLayer.Components.ContentManagement.SiteCategoryLogic"></asp:ObjectDataSource>
                </div>
            </div>

            <div id="StateRow" class="row geni-left-item">
                <span class="geni-label required"><asp:Literal ID="Literal6" runat="server" Text="<%$Resources:ContentManagement, PMSState %>"></asp:Literal></span>
                <div class="geni-edit">
                    <dx:ASPxComboBox ID="pageState" runat="server" DataSourceID="StateObjectDS" Width="100%" Font-Size="14px"
                        TextField="Name" ValueField="PageStatusId" ValueType="System.Int32"
                        OnSelectedIndexChanged="pageState_SelectedIndexChanged">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Status" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="StateObjectDS" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="BusinessLogicLayer.Components.ContentManagement.PageStatusLogic"></asp:ObjectDataSource>
                </div>
            </div>

            <div id="AccessRow" class="row geni-left-item">
                <span class="geni-label required"><asp:Literal ID="Literal7" runat="server" Text="<%$Resources:ContentManagement, PMSSecurityAccess %>"></asp:Literal></span>
                <div class="geni-edit">
                    <dx:ASPxComboBox ID="pageSecurityAccess" runat="server" Width="100%" Font-Size="14px"
                        DataSourceID="SecurityAccessObjectDS" TextField="Name"
                        ValueField="SecurityAccessTypeId" ValueType="System.Int32">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="*" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="SecurityAccessObjectDS" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="BusinessLogicLayer.Components.RoleSecurity.SecurityAccessTypeLogic"></asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-9">
        <div class="right-content">
            <dx:ASPxCallbackPanel ID="pageContentLanguageCallbackPanel"
                ClientInstanceName="pageContentLanguageCallbackPanel" runat="server" Width="100%" OnCallback="pageContentLanguageCallbackPanel_Callback">
                <PanelCollection>
                    <dx:PanelContent>

                        <div class="form">
                            <div id="PageTitleRow" class="row geni-right-item">
                                <div class="geni-edit">
                                    <dx:ASPxTextBox ID="pageTitle" runat="server" Width="100%" Font-Size="22px" NullText="<%$Resources:ContentManagement, PMSAddTitle %>" Font-Names="Segoe UI,Segoe UI Web Regular,Segoe UI Symbol,Helvetica Neue,BBAlpha Sans,S60 Sans,Arial,sans-serif">
                                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                                            <RequiredField IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                            <div id="PageContentRow" class="row geni-right-item">
                                <div class="geni-edit height-80">
                                  
                                    <dx:ASPxHtmlEditor ID="pageContent" runat="server" Width="100%" Height="450px" ToolbarMode="Ribbon" ClientInstanceName="HtmlEditor"
            >
                                        <SettingsHtmlEditing AllowFormElements="True" AllowIFrames="True"
                                            AllowScripts="True" />
                                        <SettingsDocumentSelector Enabled="True">
                                            <CommonSettings RootFolder="~/ContentData/Documents" AllowedFileExtensions=".doc, .docx, .xls, .xlsx, .pdf, .ppt, .pptx, .rtf" />

                                            <EditingSettings AllowCreate="True" AllowDelete="True" AllowRename="True" />
                                            <CommonSettings RootFolder="~/ContentData/Documents"
                                                AllowedFileExtensions=".doc, .docx, .xls, .xlsx, .pdf, .ppt, .pptx, .rtf"
                                                InitialFolder="Documents" ThumbnailFolder="~/ContentData/Documents"></CommonSettings>

                                            <EditingSettings AllowCreate="True" AllowRename="True" AllowDelete="True"></EditingSettings>

                                            <UploadSettings Enabled="True" UseAdvancedUploadMode="True">
                                            </UploadSettings>
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

                                            <EditingSettings AllowCreate="True" />

                                            <EditingSettings AllowCreate="True"></EditingSettings>

                                            <UploadSettings Enabled="True" UseAdvancedUploadMode="True">
                                            </UploadSettings>
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

                                        <SettingsImageUpload UseAdvancedUploadMode="True">
                                            <ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png">
                                            </ValidationSettings>
                                        </SettingsImageUpload>
                                        <SettingsImageSelector>
                                            <CommonSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png" />
                                        </SettingsImageSelector>
                                      
                                    </dx:ASPxHtmlEditor>

                                </div>
                            </div>
                            <div id="PageIsMainRow" class="row geni-right-item">
                                <div style="float: left">
                                    <dx:ASPxCheckBox Text="<%$Resources:ContentManagement, PMSIsMain %>" Font-Size="13px" runat="server" ID="chkIsMainPage"></dx:ASPxCheckBox>
                                </div>


                            </div>

                        </div>
                    </dx:PanelContent>

                </PanelCollection>
            </dx:ASPxCallbackPanel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
