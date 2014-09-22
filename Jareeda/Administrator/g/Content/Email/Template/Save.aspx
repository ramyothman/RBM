<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="Administrator.g.Content.Email.Template.Save" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-5">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/emailtemplate.png" />
        </div>
        <div class="title-text">
            <asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, SaveEmailTemplate %>"></asp:Literal>
        </div>
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
            <div class="row geni-left-item">
                <span class="geni-label">Name</span>
                <div class="geni-edit">
                    <dx:ASPxTextBox ID="txtName" runat="server" Width="170px">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </div>
            </div>
            <div class="row geni-left-item">
                <span class="geni-label">Template Type</span>
                <div class="geni-edit">
                    <dx:ASPxComboBox ID="cbEmailType" runat="server" DataSourceID="dsEmailType"
                        TextField="Name" ValueField="SystemEmailTypeID" ValueType="System.Int32">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="dsEmailType" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="BusinessLogicLayer.Components.Conference.SystemEmailTypeLogic"></asp:ObjectDataSource>
                </div>
            </div>
            <div class="row geni-left-item">
                <span class="geni-label">Site Name</span>
                <div class="geni-edit">
                    <dx:ASPxComboBox ID="cbConference" runat="server" DataSourceID="dsConference"
                        TextField="ConferenceName" ValueField="ConferenceId" ValueType="System.Int32">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="dsConference" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic"></asp:ObjectDataSource>
                </div>
            </div>
            <div class="row geni-left-item">
                <span class="geni-label"></span>
                <div class="geni-edit">
                </div>
            </div>
            <div class="row geni-left-item">
                <span class="geni-label">Language</span>
                <div class="geni-edit">
                    <dx:ASPxComboBox ID="cbLang" runat="server" DataSourceID="dsLanguage"
                        TextField="Name" ValueField="LanguageId" ValueType="System.Int32">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="dsLanguage" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
                </div>
            </div>
            <div class="row geni-left-item">
                <span class="geni-label">Description</span>
                <div class="geni-edit">
                    <dx:ASPxMemo ID="txtDesc" runat="server" Height="71px" Width="100%">
                    </dx:ASPxMemo>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-9">
        <div class="right-content">
            <div class="form">
                <div id="PageTitleRow" class="row geni-right-item">
                    <div class="geni-edit">
                        <dx:ASPxHtmlEditor ID="txtContent" runat="server" Width="100%" ToolbarMode="Ribbon">
                            <SettingsImageUpload UploadImageFolder="~/ContentData/" UseAdvancedUploadMode="True">
                                <ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png"></ValidationSettings>
                            </SettingsImageUpload>

                            <SettingsValidation>
                                <RequiredField IsRequired="True" />
                            </SettingsValidation>

                            <SettingsImageSelector>
                                <CommonSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png"></CommonSettings>
                            </SettingsImageSelector>

                            <SettingsDocumentSelector>
                                <CommonSettings AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp"></CommonSettings>
                            </SettingsDocumentSelector>
                        </dx:ASPxHtmlEditor>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
