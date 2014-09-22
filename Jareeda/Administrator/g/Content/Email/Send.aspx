﻿<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Send.aspx.cs" Inherits="Administrator.g.Content.Email.Send" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnCustomDialogOpened() {
            RestoreInsertTemplateFormDialogState();
        }



        function OnCustomDialogClosing(s, e) {
            if (e.name == "InsertTemplate" && e.status == "ok") {
                RetrieveTemplateHtml(e.status);
                e.handled = true;
            }
        }

        function OnGridRowDblClick(s, e) {
            RetrieveTemplateHtml("dbl");
        }

        function RetrieveTemplateHtml(status) {
            loadingPanel.ShowInElement(templatesGrid.GetMainElement().parentNode);

            templatesGrid.GetRowValues(
            templatesGrid.GetFocusedRowIndex(),
            "EmailContent",
            function (html) {
                loadingPanel.Hide();


                ASPxClientHtmlEditor.CustomDialogComplete(
                    status,
                    {
                        "html": html,
                        "overwrite": true
                    }
                );
                //EmailContentHtmlEditor.SetHtml(html);
            }
        );
        }

        function OnCustomDialogClosed(s, e) {
            if (e.name == "InsertTemplate" && (e.status == "ok" || e.status == "dbl")) {
                if (e.data) {
                    if (e.data.overwrite)
                        EmailContentHtmlEditor.SetHtml(e.data.html, false)
                    else
                        EmailContentHtmlEditor.ExecuteCommand(ASPxClientCommandConsts.PASTEHTML_COMMAND, e.data.html);
                }

                SaveInsertTemplateFormDialogState();
            }
        }


        var insertTemplateFormDialogState = {};

        function SaveInsertTemplateFormDialogState() {
            insertTemplateFormDialogState.focusedRow = templatesGrid.GetFocusedRowIndex();
            insertTemplateFormDialogState.overwrite = overwriteCheckBox.GetChecked();
        }

        function RestoreInsertTemplateFormDialogState() {
            if (insertTemplateFormDialogState.focusedRow)
                templatesGrid.SetFocusedRowIndex(insertTemplateFormDialogState.focusedRow);

            if (insertTemplateFormDialogState.overwrite != undefined)
                overwriteCheckBox.SetChecked(insertTemplateFormDialogState.overwrite);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-5">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/sendemail.png" />
        </div>
        <div class="title-text">
            <asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, SendEmail %>"></asp:Literal>
        </div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <ul>
            <li>
                <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:ContentManagement, SendEmail %>" Font-Size="8pt" ImageSpacing="5px" OnClick="btnSave_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-apply.png" Height="24px" Width="24px">
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
            <div id="ContactRow" class="row geni-left-item">
            <span class="geni-label">Contact Emails</span>
            <div class="geni-edit">
                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="100%">
            </dx:ASPxTextBox>
            </div>
        </div>
        <div id="Div1" class="row geni-left-item">
            <span class="geni-label">Contact List</span>
            <div class="geni-edit">
               <dx:ASPxGridView ID="gridContacts" runat="server" AutoGenerateColumns="False" 
                ClientInstanceName="gridUsers" KeyFieldName="BusinessEntityId" 
                Width="250px" PreviewFieldName="Email">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" 
                        Width="20px">
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                        <HeaderCaptionTemplate>
                        <center>
                            <dx:ASPxCheckBox ID="chkUserSelect" runat="server" CheckState="Unchecked" 
                                Text=" ">
                                <ClientSideEvents CheckedChanged="function(s, e) {
	if(s.GetChecked())
		gridUsers.SelectRows();
	else
		gridUsers.UnselectRows(); 

        
}" />
                            </dx:ASPxCheckBox>
                            </center>
                        </HeaderCaptionTemplate>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="BusinessEntityId" ReadOnly="True" 
                        Visible="False" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="3" Visible="False">
                        <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DisplayName" VisibleIndex="2" Width="150px">
                        <Settings AutoFilterCondition="Contains" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                   <SettingsPager>
                       <Summary Visible="False" />
                   </SettingsPager>
                <Settings ShowFilterRow="True" ShowPreview="True" />
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="ManageUsersObjectDS" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
    TypeName="BusinessLogicLayer.Components.Persons.PersonLogic" 
        DeleteMethod="Delete">
    <DeleteParameters>
        <asp:Parameter Name="Original_BusinessEntityId" Type="Int32" />
    </DeleteParameters>
</asp:ObjectDataSource>
            </div>
        </div>
        </div>
    </div>
    <div class="col-md-9">
        <div class="right-content">
            <div class="form">
             <div id="PageTitleRow" class="row geni-right-item">
                    <div class="geni-edit">
                        <dx:ASPxTextBox ID="txtSubject" runat="server" Width="100%" Font-Size="22px" NullText="Add a Subject" Font-Names="Segoe UI,Segoe UI Web Regular,Segoe UI Symbol,Helvetica Neue,BBAlpha Sans,S60 Sans,Arial,sans-serif">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Enter Subject" IsRequired="True" />
<RequiredField IsRequired="True" ErrorText="* Please Enter Subject"></RequiredField>
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    </div>
                </div>
                <div id="PageContentRow" class="row geni-right-item">
                    <div class="geni-edit height-80">
                         <dx:ASPxHtmlEditor ID="EmailContentHtmlEditor" ClientInstanceName="EmailContentHtmlEditor" runat="server" Width="100%" Height="550px">
                              <Toolbars>
            <dx:HtmlEditorToolbar Caption="DemoToolbar" Name="DemoToolbar">
                <Items>
                    <dx:ToolbarUndoButton>
                    </dx:ToolbarUndoButton>
                    <dx:ToolbarRedoButton>
                    </dx:ToolbarRedoButton>
                    <dx:ToolbarJustifyLeftButton BeginGroup="True">
                    </dx:ToolbarJustifyLeftButton>
                    <dx:ToolbarJustifyCenterButton>
                    </dx:ToolbarJustifyCenterButton>
                    <dx:ToolbarJustifyRightButton>
                    </dx:ToolbarJustifyRightButton>
                    <dx:ToolbarJustifyFullButton>
                    </dx:ToolbarJustifyFullButton>
                    <dx:ToolbarInsertLinkDialogButton></dx:ToolbarInsertLinkDialogButton>
                    <dx:ToolbarPasteButton></dx:ToolbarPasteButton>
                    <dx:ToolbarPasteFromWordButton></dx:ToolbarPasteFromWordButton>
                    <dx:ToolbarRemoveFormatButton></dx:ToolbarRemoveFormatButton>
                    <dx:ToolbarCustomDialogButton Name="InsertTemplate" BeginGroup="True" ToolTip="Insert Template">
                        <Image Url="../../../images/template.png">
                        </Image>
                    </dx:ToolbarCustomDialogButton>
                </Items>
            </dx:HtmlEditorToolbar>
        </Toolbars>
           <CustomDialogs>
            <dx:HtmlEditorCustomDialog Caption="Insert Template" Name="InsertTemplate" FormPath="../../../Controls/EventoControls/InsertTemplate.ascx"
                OkButtonText="Insert">
            </dx:HtmlEditorCustomDialog>
        </CustomDialogs>
        <ClientSideEvents CustomDialogOpened="OnCustomDialogOpened" CustomDialogClosed="OnCustomDialogClosed"
            CustomDialogClosing="OnCustomDialogClosing" />
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
               </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
