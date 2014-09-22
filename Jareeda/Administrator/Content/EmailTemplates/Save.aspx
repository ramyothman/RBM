<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="Administrator.Content.EmailTemplates.Save" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, SaveEmailTemplate %>"></asp:Literal>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
                <tr>
                <td>
                Name
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtName" runat="server" Width="170px">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
                </tr>
                 <tr>
                <td>
                Template Type
                </td>
                <td>
                    <dx:ASPxComboBox ID="cbEmailType" runat="server" DataSourceID="dsEmailType" 
                        TextField="Name" ValueField="SystemEmailTypeID" ValueType="System.Int32">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="dsEmailType" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.Conference.SystemEmailTypeLogic">
                    </asp:ObjectDataSource>
                </td>
                </tr>
                 <tr>
                <td>
                Conference Name
                </td>
                <td>
                    <dx:ASPxComboBox ID="cbConference" runat="server" DataSourceID="dsConference" 
                        TextField="ConferenceName" ValueField="ConferenceId" ValueType="System.Int32">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="dsConference" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic">
                    </asp:ObjectDataSource>
                </td>
                </tr>
                 <tr>
                <td>
                Language
                </td>
                <td>
                    <dx:ASPxComboBox ID="cbLang" runat="server" DataSourceID="dsLanguage" 
                        TextField="Name" ValueField="LanguageId" ValueType="System.Int32">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="dsLanguage" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
                    </asp:ObjectDataSource>
                </td>
                </tr>
                  <tr>
                <td>
                Content
                </td>
                <td>
                    <dx:ASPxHtmlEditor ID="txtContent" runat="server" Width="100%">
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
                </td>
                </tr>
                  <tr>
                <td>
                Description
                </td>
                <td>
                    <dx:ASPxMemo ID="txtDesc" runat="server" Height="71px" Width="586px">
                    </dx:ASPxMemo>
                </td>
                </tr>
              
                </table>
</asp:Content>
