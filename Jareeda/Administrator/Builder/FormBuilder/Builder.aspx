<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Builder.aspx.cs" Inherits="Administrator.Builder.FormBuilder.Builder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    
    <link href="Styles/Main.css" rel="stylesheet" type="text/css" />
     <script src="http://code.jquery.com/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/Rbm/Tools.js" type="text/javascript" ></script>
    <script src="Scripts/JQuery/JSON.js" type="text/javascript"></script>
    <script src="Scripts/JQuery/SurveyQuestion.js" type="text/javascript"></script>
    <script src="Scripts/JQuery/GeneralBuilderScript.js" type="text/javascript"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
    <div class="content">
                <div class="commandpanelleft">
                    <a href="javascript:AddElement()">Add Question</a>
                    <select id="QuestionAddOption" style="font-size: 16px;" name="QuestionAddOption">
                        <option value="Text">Text</option>
                        <option value="Paragraph">Paragraph</option>
                        <option value="MultipleChoice">Option</option>
                        <option value="CheckBoxes">Checkbox</option>
                        <option value="DropDown">DropDown</option>
                        <option value="Grid">Grid</option>
                    </select>
                </div>
                <div class="commandpanelright">
                   <a href="javascript:SaveData();"><img src="images/filesaveas.png" class="ImageLink" alt="Save" /></a><a href="javascript:popupSurveySettings.Show();"><img src="images/page_accept.png" class="ImageLink" alt="Edit Confirmation" /></a>
                </div>
            </div>
            <div class="fix">
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page">
            <div class="contentpage">
                
            <dx:ASPxHiddenField ID="hiddenJSONLoad" runat="server" ClientInstanceName="hiddenJSONLoad">
    </dx:ASPxHiddenField>
                
    <dx:ASPxLoadingPanel ID="SavingLoadingPanel" 
        ClientInstanceName="SavingLoadingPanel" Modal="True" runat="server" 
      Text="">
    </dx:ASPxLoadingPanel>
                <div id="FormContainer">
    <div id="MainParts" style="padding-left:20px;padding-right:20px;">
    <input id="TitleText" type="text" value="Untitled Form" style="width:100%;color:#666666;font-size:1.1em;font-family: Trebuchet MS;" onfocus="TextChanged(this,'Untitled Form')" onblur="TextLeave(this,'Untitled Form')" /><br /><br />
    <textarea rows="3" cols="1" id="SubTitleText" style="width:100%;height:50px;color:#666666;font-size:0.9em;font-family: Trebuchet MS;" onfocus="TextChanged(this,'You can include any text or message that will help people fill this out')" onblur="TextLeave(this,'You can include any text or message that will help people fill this out')" >
You can include any text or message that will help people fill this out</textarea><br /><br />
    
    </div>
    
    <div id="ContainerDiv" >
          
    </div>
    <div id="OtherContent">
    
        <dx:ASPxCallback ID="saveCallBack" runat="server" 
            ClientInstanceName="saveCallBack" oncallback="saveCallBack_Callback">
            <ClientSideEvents BeginCallback="function(s, e) {
	SavingLoadingPanel.Show();
}" CallbackComplete="function(s, e) {
		SavingLoadingPanel.Hide();
}" />
        </dx:ASPxCallback>
        <dx:ASPxPopupControl ID="popupSurveySettings" 
            ClientInstanceName="popupSurveySettings" runat="server" 
            
            HeaderText="Edit Confirmation" 
            AllowDragging="True" Modal="True" PopupHorizontalAlign="WindowCenter" 
            PopupVerticalAlign="WindowCenter">
            <ContentStyle VerticalAlign="Top">
            </ContentStyle>
            <SizeGripImage Height="12px" Width="12px" />
            <ContentCollection>
<dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">

<div id="MainSurveyInformation">
    <dx:ASPxCallbackPanel runat="server" id="callbackPanelSettings" 
        ClientInstanceName="callbackPanelSettings" width="550"
        OnCallback="callbackPanelSettings_Callback"  ><PanelCollection>
<dx:PanelContent ID="PanelContent1" runat="server">
    <dx:ASPxCheckbox runat="server" id="chkSendEmail" Text="Send Confirmation Email"></dx:ASPxCheckbox><br />
     <dx:ASPxHtmlEditor ID="txtSurveySubmitReply" runat="server" Width="100%">
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
   <%-- <dx:ASPxMemo ID="txtSurveySubmitReply" runat="server" Height="250" 
        Width="100%" Text="Thanks!

Your response are submitted successfully.">
    </dx:ASPxMemo>--%>
</dx:PanelContent>
</PanelCollection>
    </dx:ASPxCallbackPanel>

        
    </div>

</dx:PopupControlContentControl>
</ContentCollection>
            <CloseButtonImage Height="16px" Width="17px" />
        </dx:ASPxPopupControl>
    </div>
    
    </div>
            </div>
            
            <div class="fix">
            </div>
        </div>
</asp:Content>
