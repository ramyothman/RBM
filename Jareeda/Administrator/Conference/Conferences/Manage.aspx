<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.Conference.Conferences.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <script type="text/javascript">
         function Uploader_OnUploadComplete(args) {
             if (args.isValid) {
                 lblIconPath.SetText(args.callbackData);
                 //            lblIconImage.SetImageUrl("/ContentData/Sites/Conferences/" + args.callbackData);
                 //            lblIconImage.SetVisible(false);
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="g12 widgets">
        <div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
            <h3 class="handle">Manage Conferences</h3>
            <div class="inner-content">
                <dx:aspxgridview id="ConferenceGrid" clientinstancename="ConferenceGrid"
                    runat="server" autogeneratecolumns="False" datasourceid="ConferenceObjectDS"
                    keyfieldname="ConferenceId" onrowinserting="ConferenceGrid_RowInserting"
                    onrowupdating="ConferenceGrid_RowUpdating"
                    onstartrowediting="ConferenceGrid_StartRowEditing" Width="100%">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Code" FieldName="ConferenceCode" 
                        VisibleIndex="4" Width="100px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        <EditButton Visible="True">
                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                            </Image>
                        </EditButton>
                        <NewButton Visible="True">
                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                            </Image>
                        </NewButton>
                        <CancelButton>
                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                            </Image>
                        </CancelButton>
                        <UpdateButton>
                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                            </Image>
                        </UpdateButton>
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Id" FieldName="ConferenceId" 
                        ReadOnly="True" VisibleIndex="1" Visible="False" Width="50px">
                        <EditFormSettings Visible="False" />
<EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Site" FieldName="SiteId"  Visible="False"
                        VisibleIndex="2" Width="120px">
                        <PropertiesComboBox DataSourceID="SiteObjectDS" TextField="Name" 
                            ValueField="SiteId" ValueType="System.Int32">
                            <ValidationSettings CausesValidation="True" Display="Dynamic" 
                                ErrorDisplayMode="Text">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" Visible="False" />

<EditFormSettings ColumnSpan="2" Visible="False"></EditFormSettings>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="ConferenceName" VisibleIndex="3">
                        <PropertiesTextEdit>
                            <ValidationSettings CausesValidation="True" ErrorDisplayMode="Text">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                        <EditFormSettings ColumnSpan="2" />

<EditFormSettings ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn Caption="Logo" FieldName="ConferenceLogo" 
                        VisibleIndex="21" Width="100px">
                        <PropertiesImage ImageUrlFormatString="~/ContentData/Sites/Conferences/{0}" 
                            ImageWidth="100px">
                        </PropertiesImage>
                        <EditFormSettings ColumnSpan="2" Visible="True" />
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataDateColumn FieldName="StartDate" VisibleIndex="4" Width="80px">
                    <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                        <PropertiesDateEdit>
                            <ValidationSettings CausesValidation="True" Display="Dynamic" 
                                ErrorDisplayMode="Text">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesDateEdit>

                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EndDate" VisibleIndex="5" Width="80px">
                    <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                        <PropertiesDateEdit>
                            <ValidationSettings CausesValidation="True" Display="Dynamic" 
                                ErrorDisplayMode="Text">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesDateEdit>

                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataCheckColumn FieldName="IsActive" VisibleIndex="6" Width="50px">
<EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataTextColumn FieldName="Location" Visible="False" 
                        VisibleIndex="7">
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>

                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="LocationName" Visible="False" 
                        VisibleIndex="8">
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>

                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="LocationLogo" Visible="False" 
                        VisibleIndex="9">
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>

                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="LocationLongitude" Visible="False" 
                        VisibleIndex="10">
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="LocationLatitude" Visible="False" 
                        VisibleIndex="11">
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ConferenceDomain" Visible="False" 
                        VisibleIndex="12">
<EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataHyperLinkColumn Caption="Abstracts" FieldName="ConferenceId" 
                        VisibleIndex="13" Width="80px">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="~/Administrator/Conference/Abstracts/ManageAbstracts.aspx?code={0}" 
                            Text="Abstracts">
                        </PropertiesHyperLinkEdit>
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataHyperLinkColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Venue" FieldName="ConferenceVenueID" 
                        Visible="False" VisibleIndex="14">
                        <PropertiesComboBox DataSourceID="VenueObjectDS" TextField="Name" 
                            ValueField="ID" ValueType="System.Int32">
                        </PropertiesComboBox>
<EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Alias" FieldName="ConferenceAlias" 
                        VisibleIndex="15" Visible="False">
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn Caption="Is Default" FieldName="IsDefault" 
                        VisibleIndex="16" Width="50px">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataDateColumn Caption="Abstract Start" 
                        FieldName="AbstractSubmissionStartDate" Visible="False" VisibleIndex="17">
                        <PropertiesDateEdit DisplayFormatString="">
                        </PropertiesDateEdit>
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="Abstract End" 
                        FieldName="AbstractSubmissionEndDate" Visible="False" VisibleIndex="18">
                        <PropertiesDateEdit DisplayFormatString="">
                        </PropertiesDateEdit>
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Abstract End Page" 
                        FieldName="AbstractSubmissionEndMessagePageID" Visible="False" 
                        VisibleIndex="19">
                        <PropertiesComboBox DataSourceID="ConferencePageObjectDS" TextField="PageName" 
                            ValueField="SitePageId" ValueType="System.Int32">
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Abstract Not Started Page" 
                        FieldName="AbstractSubmissionNotStartedPageID" Visible="False" 
                        VisibleIndex="20">
                        <PropertiesComboBox DataSourceID="ConferencePageObjectDS" 
                            IncrementalFilteringMode="Contains" TextField="PageName" 
                            ValueField="SitePageId" ValueType="System.Int32">
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="0" Visible="True"></EditFormSettings>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
                <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                    EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="600px" 
                    EditFormColumnCount="2" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />

<SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True"></SettingsBehavior>

<SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="700px"></SettingsEditing>

<Settings ShowFilterRow="True"></Settings>

<SettingsText ConfirmDelete="Are you sure you want to delete this record?"></SettingsText>

<SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True"></SettingsDetail>

                <Templates>
                    <DetailRow>
                        <dx:ASPxPageControl ID="ConferenceDetailPageControl" runat="server" 
                            ActiveTabIndex="0" Width="100%">
                            <TabPages>
                                <dx:TabPage Text="Conference Language">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl1" runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
                                                DataSourceID="dsConferenceLang" KeyFieldName="ConferenceId" 
                                                OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect" 
                                               
                                                OnStartRowEditing="ConferenceGrid_StartRowEditing">
                                                <Columns>
                                                    <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" 
                                                        VisibleIndex="0" Width="80px">
                                                        <EditButton Visible="True">
                                                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                                                            </Image>
                                                        </EditButton>
                                                        <NewButton Visible="True">
                                                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                                                            </Image>
                                                        </NewButton>
                                                        <DeleteButton Visible="True">
                                                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                                                            </Image>
                                                        </DeleteButton>
                                                        <CancelButton>
                                                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                                                            </Image>
                                                        </CancelButton>
                                                        <UpdateButton>
                                                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                                                            </Image>
                                                        </UpdateButton>
                                                        <ClearFilterButton Visible="True">
                                                        </ClearFilterButton>
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn Caption="Id" FieldName="ConferenceId" 
                                                        ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                                        <EditFormSettings Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Site" FieldName="SiteId" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                        <PropertiesComboBox DataSourceID="SiteObjectDS" TextField="Name" 
                                                            ValueField="SiteId" ValueType="System.Int32">
                                                        </PropertiesComboBox>
                                                        <EditFormSettings ColumnSpan="2" />
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ConferenceName" 
                                                        ShowInCustomizationForm="True" VisibleIndex="3" Width="300px">
                                                        <EditFormSettings ColumnSpan="2" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ConferenceLogo" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="3">
                                                        <EditFormSettings ColumnSpan="2" Visible="True" />
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataDateColumn FieldName="StartDate" ShowInCustomizationForm="True" 
                                                        Visible="False" VisibleIndex="4">
                                                        <EditFormSettings ColumnSpan="2" />
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataDateColumn FieldName="EndDate" ShowInCustomizationForm="True" 
                                                        Visible="False" VisibleIndex="5">
                                                        <EditFormSettings ColumnSpan="2" />
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataCheckColumn FieldName="IsActive" ShowInCustomizationForm="True" 
                                                        Visible="False" VisibleIndex="6">
                                                        <EditFormSettings ColumnSpan="2" />
                                                    </dx:GridViewDataCheckColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Location" ShowInCustomizationForm="True" 
                                                        VisibleIndex="6" Width="120px">
                                                        <EditFormSettings ColumnSpan="2" Visible="True" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="LocationName" 
                                                        ShowInCustomizationForm="True" VisibleIndex="6" Width="120px">
                                                        <EditFormSettings ColumnSpan="2" Visible="True" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="LocationLogo" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                        <EditFormSettings ColumnSpan="2" Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="LocationLongitude" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                        <EditFormSettings ColumnSpan="2" Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="LocationLatitude" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                        <EditFormSettings ColumnSpan="2" Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ConferenceDomain" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="6">
                                                        <EditFormSettings ColumnSpan="2" Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ConferenceParentId" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageID" 
                                                        ShowInCustomizationForm="True" VisibleIndex="22" Width="120px">
                                                        <PropertiesComboBox DataSourceID="dsLanguages" TextField="Name" 
                                                            ValueField="LanguageId">
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                </Columns>
                                                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                                                    EnableRowHotTrack="True" />
                                                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="400px" />
                                                <Settings ShowFilterRow="True" />
                                                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                                            </dx:ASPxGridView>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Registration Settings">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl2" runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" 
                                                DataSourceID="RegistrationSettingsObjectDS" 
                                                KeyFieldName="ConferenceRegistrationSettingID" 
                                                OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect">
                                                <Columns>
                                                    <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" 
                                                        VisibleIndex="0" Width="80px">
                                                        <EditButton Visible="True">
                                                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                                                            </Image>
                                                        </EditButton>
                                                        <NewButton Visible="True">
                                                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                                                            </Image>
                                                        </NewButton>
                                                        <DeleteButton Visible="True">
                                                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                                                            </Image>
                                                        </DeleteButton>
                                                        <CancelButton>
                                                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                                                            </Image>
                                                        </CancelButton>
                                                        <UpdateButton>
                                                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                                                            </Image>
                                                        </UpdateButton>
                                                        <ClearFilterButton Visible="True">
                                                        </ClearFilterButton>
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn Caption="Id" 
                                                        FieldName="ConferenceRegistrationSettingID" ReadOnly="True" 
                                                        ShowInCustomizationForm="True" VisibleIndex="1">
                                                        <EditFormSettings Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ConferenceID" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataDateColumn Caption="End Date" FieldName="RegistrationEndDate" 
                                                        ShowInCustomizationForm="True" VisibleIndex="4">
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataDateColumn Caption="Start Date" 
                                                        FieldName="RegistrationStartDate" ShowInCustomizationForm="True" 
                                                        VisibleIndex="3">
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataCheckColumn FieldName="IsActive" ShowInCustomizationForm="True" 
                                                        VisibleIndex="5">
                                                    </dx:GridViewDataCheckColumn>
                                                </Columns>
                                                <SettingsDetail ShowDetailRow="True" />
                                                <Templates>
                                                    <DetailRow>
                                                        <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" 
                                                            DataSourceID="RegistrationSettingsLanguagesObjectDS" OnBeforePerformDataSelect="ASPxGridView3_BeforePerformDataSelect"
                                                            KeyFieldName="ConferenceRegistrationSettingLanguageID" onrowinserting="SettingLanguagesGrid_RowInserting" 
                onrowupdating="SettingLanguagesGrid_RowUpdating" 
>
                                                            <Columns>
                                                                <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" 
                                                        VisibleIndex="0" Width="80px">
                                                        <EditButton Visible="True">
                                                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                                                            </Image>
                                                        </EditButton>
                                                        <NewButton Visible="True">
                                                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                                                            </Image>
                                                        </NewButton>
                                                        <DeleteButton Visible="True">
                                                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                                                            </Image>
                                                        </DeleteButton>
                                                        <CancelButton>
                                                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                                                            </Image>
                                                        </CancelButton>
                                                        <UpdateButton>
                                                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                                                            </Image>
                                                        </UpdateButton>
                                                        <ClearFilterButton Visible="True">
                                                        </ClearFilterButton>
                                                    </dx:GridViewCommandColumn>
                                                                <dx:GridViewDataTextColumn Caption="Id" 
                                                                    FieldName="ConferenceRegistrationSettingLanguageID" ReadOnly="True" 
                                                                    VisibleIndex="1">
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ConferenceRegistrationSettingID" 
                                                                    Visible="False" VisibleIndex="2">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Short Instruction" 
                                                                    FieldName="RegistrationShorInstructions" VisibleIndex="3">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Registration Pre" Visible="false" 
                                                                    FieldName="RegistrationInstructionsInFormPre" VisibleIndex="4">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Registration Post" Visible="false" 
                                                                    FieldName="RegistrationInstructionsInFormPost" VisibleIndex="5">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="After Submission Message" 
                                                                    FieldName="PostRegistrationInstructions" Visible="False" VisibleIndex="6">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageID" 
                                                                    VisibleIndex="7">
                                                                    <PropertiesComboBox DataSourceID="dsLanguages" TextField="Name" 
                                                                        ValueField="LanguageID" ValueType="System.Int32">
                                                                    </PropertiesComboBox>
                                                                </dx:GridViewDataComboBoxColumn>
                                                            </Columns>
                                                            <Templates>
                                                                <EditForm>
                                                                <div style="padding: 4px 4px 3px 4px;width:100%">
                        <dx:ASPxPageControl ID="settingsPageControl" runat="server"  Width="100%"
                            ActiveTabIndex="0">
                            <TabPages>
                                <dx:TabPage Text="Language Settings">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl2" runat="server" SupportsDisabledAttribute="True">
                                            <div class="form">
                                                <fieldset class="fieldset">
                                                    <%--<label class="label">Save Conference</label>--%>
                                                    <section><label class="label" for="text_field">Short Description:</label>
							                            <div>
                                                            <dx:ASPxMemo width="100%" Height="100px" ID="txtRegistrationShorInstructions" Text='<%# Bind("RegistrationShorInstructions") %>' runat="server">
                                                                    <ValidationSettings  causesvalidation="True" 
                                                                        display="Dynamic" errordisplaymode="Text">
                                                                        <RequiredField IsRequired="True" />
                                                                        <requiredfield isrequired="True" />
                                                                        <requiredfield isrequired="True" />
                                                                    </ValidationSettings>
                                                            </dx:ASPxMemo>
                                
                                                        </div>
						                            </section>
                                                    <section><label class="label" for="text_field">Language:</label>
							                            <div>
                                                            <dx:ASPxComboBox width="50%" ID="txtLanguageId" Value='<%# Bind("LanguageID") %>' TextField="Name" ValueField="LanguageId" DataSourceID="dsLanguages" ValueType="System.Int32" runat="server">
                                                                   
                                                            </dx:ASPxComboBox>
                                
                                                        </div>
						                            </section>
                                                   
                                                </fieldset>
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Registration Page Pre" >
                                    <ContentCollection>
                                        
                                        <dx:ContentControl ID="ContentControl3" runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxHtmlEditor ID="htmlRegistrationPre" Html='<%# Bind("RegistrationInstructionsInFormPre") %>' runat="server">
                                                <SettingsImageUpload>
                                                    <ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png">
                                                    </ValidationSettings>
                                                </SettingsImageUpload>
                                                <SettingsImageSelector>
                                                    <CommonSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png" />
                                                </SettingsImageSelector>
                                                <SettingsDocumentSelector>
                                                    <CommonSettings AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp" />
                                                </SettingsDocumentSelector>
                                            </dx:ASPxHtmlEditor>
                                        </dx:ContentControl>
                                        
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Registration Page Post" >
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl4" runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxHtmlEditor ID="htmlRegistrationPost" Html='<%# Bind("RegistrationInstructionsInFormPost") %>' runat="server">
                                                <SettingsImageUpload>
                                                    <ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png">
                                                    </ValidationSettings>
                                                </SettingsImageUpload>
                                                <SettingsImageSelector>
                                                    <CommonSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png" />
                                                </SettingsImageSelector>
                                                <SettingsDocumentSelector>
                                                    <CommonSettings AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp" />
                                                </SettingsDocumentSelector>
                                            </dx:ASPxHtmlEditor>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Submission Complete" >
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl5" runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxHtmlEditor ID="htmlSubmissionComplete" Html='<%# Bind("PostRegistrationInstructions") %>' runat="server">
                                                <SettingsImageUpload>
                                                    <ValidationSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png">
                                                    </ValidationSettings>
                                                </SettingsImageUpload>
                                                <SettingsImageSelector>
                                                    <CommonSettings AllowedFileExtensions=".jpe, .jpeg, .jpg, .gif, .png" />
                                                </SettingsImageSelector>
                                                <SettingsDocumentSelector>
                                                    <CommonSettings AllowedFileExtensions=".rtf, .pdf, .doc, .docx, .odt, .txt, .xls, .xlsx, .ods, .ppt, .pptx, .odp" />
                                                </SettingsDocumentSelector>
                                            </dx:ASPxHtmlEditor>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                
                            </TabPages>
                        </dx:ASPxPageControl>
                    </div>
                    <div style="text-align: right; padding: 2px 2px 2px 2px">
                    <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton"
                        runat="server">
                    </dx:ASPxGridViewTemplateReplacement>
                    <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                        runat="server">
                    </dx:ASPxGridViewTemplateReplacement>
                </div>
                                                                </EditForm>
                                                            </Templates>
                                                        </dx:ASPxGridView>
                                                    </DetailRow>
                                                </Templates>
                                            </dx:ASPxGridView>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Registration Details">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl6" runat="server" SupportsDisabledAttribute="True">
                                            <dx:ASPxGridView ID="gridRegistrationDetails" runat="server" 
                                                AutoGenerateColumns="False" DataSourceID="RegistrationTypesObjectDS" 
                                                KeyFieldName="ConferenceRegistrationTypeId">
                                                <Columns>
                                                    <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" 
                                                        VisibleIndex="0" Width="80px">
                                                        <EditButton Visible="True">
                                                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                                                            </Image>
                                                        </EditButton>
                                                        <NewButton Visible="True">
                                                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                                                            </Image>
                                                        </NewButton>
                                                        <DeleteButton Visible="True">
                                                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                                                            </Image>
                                                        </DeleteButton>
                                                        <CancelButton>
                                                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                                                            </Image>
                                                        </CancelButton>
                                                        <UpdateButton>
                                                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                                                            </Image>
                                                        </UpdateButton>
                                                        <ClearFilterButton Visible="True">
                                                        </ClearFilterButton>
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn Caption="Id" 
                                                        FieldName="ConferenceRegistrationTypeId" ReadOnly="True" 
                                                        ShowInCustomizationForm="True" VisibleIndex="1">
                                                        <EditFormSettings Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="ConferenceId" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Name" ShowInCustomizationForm="True" 
                                                        VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Fee" ShowInCustomizationForm="True" 
                                                        VisibleIndex="8">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="GroupName" ShowInCustomizationForm="True" 
                                                        VisibleIndex="4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataDateColumn FieldName="StartDate" ShowInCustomizationForm="True" 
                                                        VisibleIndex="5">
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataDateColumn FieldName="EndDate" ShowInCustomizationForm="True" 
                                                        VisibleIndex="6">
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataDateColumn Caption="Early Registration End" 
                                                        FieldName="EarlyRegistrationEndDate" ShowInCustomizationForm="True" 
                                                        VisibleIndex="7">
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataTextColumn FieldName="LateFee" ShowInCustomizationForm="True" 
                                                        VisibleIndex="9">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataComboBoxColumn Caption="Conference Schedule" 
                                                        FieldName="ConferenceScheduleID" ShowInCustomizationForm="True" Visible="False" 
                                                        VisibleIndex="10">
                                                        <PropertiesComboBox DataSourceID="conferenceScheduleObjectDS" 
                                                            IncrementalFilteringMode="Contains" TextField="Title" ValueField="ScheduleId" 
                                                            ValueType="System.Int32">
                                                        </PropertiesComboBox>
                                                        <EditFormSettings Visible="True" />
                                                    </dx:GridViewDataComboBoxColumn>
                                                    <dx:GridViewDataDateColumn FieldName="OfferStartDate" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                        <EditFormSettings Visible="True" />
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataDateColumn FieldName="OfferEndDate" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="12">
                                                        <EditFormSettings Visible="True" />
                                                    </dx:GridViewDataDateColumn>
                                                    <dx:GridViewDataTextColumn FieldName="OfferFee" ShowInCustomizationForm="True" 
                                                        Visible="False" VisibleIndex="13">
                                                        <EditFormSettings Visible="True" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataCheckColumn FieldName="HaveOffer" 
                                                        ShowInCustomizationForm="True" VisibleIndex="14">
                                                    </dx:GridViewDataCheckColumn>
                                                    <dx:GridViewDataCheckColumn FieldName="MustRegister" 
                                                        ShowInCustomizationForm="True" Visible="False" VisibleIndex="15">
                                                        <EditFormSettings Visible="True" />
                                                    </dx:GridViewDataCheckColumn>
                                                </Columns>
                                                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="600px" />
                                                <SettingsDetail ShowDetailRow="True" />
                                                <Templates>
                                                    <DetailRow>
                                                        <dx:ASPxGridView ID="gridRegistrationTypeLanguages" runat="server" 
                                                            AutoGenerateColumns="False" DataSourceID="RegistrationTypeLanguagesObjectDS" 
                                                            KeyFieldName="ConferenceRegistrationTypeId" 
                                                            onbeforeperformdataselect="gridRegistrationTypeLanguages_BeforePerformDataSelect">
                                                            <Columns>
                                                                <dx:GridViewCommandColumn ButtonType="Image" ShowInCustomizationForm="True" 
                                                        VisibleIndex="0" Width="80px">
                                                        <EditButton Visible="True">
                                                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                                                            </Image>
                                                        </EditButton>
                                                        <NewButton Visible="True">
                                                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                                                            </Image>
                                                        </NewButton>
                                                        <DeleteButton Visible="True">
                                                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                                                            </Image>
                                                        </DeleteButton>
                                                        <CancelButton>
                                                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                                                            </Image>
                                                        </CancelButton>
                                                        <UpdateButton>
                                                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                                                            </Image>
                                                        </UpdateButton>
                                                        <ClearFilterButton Visible="True">
                                                        </ClearFilterButton>
                                                    </dx:GridViewCommandColumn>
                                                                <dx:GridViewDataTextColumn Caption="Id" 
                                                                    FieldName="ConferenceRegistrationTypeId" ReadOnly="True" VisibleIndex="1">
                                                                    <EditFormSettings Visible="False" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ConferenceId" Visible="False" 
                                                                    VisibleIndex="7">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                                                                    <EditFormSettings ColumnSpan="2" />
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Fee" Visible="False" VisibleIndex="6">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="ConferenceRegistrationTypeParentId" 
                                                                    Visible="False" VisibleIndex="8">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageID" 
                                                        ShowInCustomizationForm="True" VisibleIndex="22" Width="120px">
                                                        <PropertiesComboBox DataSourceID="dsLanguages" TextField="Name" 
                                                            ValueField="LanguageId">
                                                        </PropertiesComboBox>
                                                    </dx:GridViewDataComboBoxColumn>
                                                                <dx:GridViewDataMemoColumn FieldName="Description" VisibleIndex="3">
                                                                    <EditFormSettings ColumnSpan="2" />
                                                                </dx:GridViewDataMemoColumn>
                                                                <dx:GridViewDataTextColumn FieldName="OfferMessage" VisibleIndex="4">
                                                                    <EditFormSettings ColumnSpan="2" />
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                        </dx:ASPxGridView>
                                                    </DetailRow>
                                                </Templates>
                                            </dx:ASPxGridView>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                            </TabPages>
                        </dx:ASPxPageControl>
                        <asp:ObjectDataSource ID="dsConferenceLang" runat="server" 
                            DeleteMethod="Delete" InsertMethod="Insert" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                            TypeName="BusinessLogicLayer.Components.Conference.ConferencesLanguageLogic" 
                            UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_ConferenceId" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="SiteId" Type="Int32" />
                                <asp:Parameter Name="ConferenceName" Type="String" />
                                <asp:Parameter Name="ConferenceLogo" Type="String" />
                                <asp:Parameter Name="StartDate" Type="DateTime" />
                                <asp:Parameter Name="EndDate" Type="DateTime" />
                                <asp:Parameter Name="IsActive" Type="Boolean" />
                                <asp:Parameter Name="Location" Type="String" />
                                <asp:Parameter Name="LocationName" Type="String" />
                                <asp:Parameter Name="LocationLogo" Type="String" />
                                <asp:Parameter Name="LocationLongitude" Type="Decimal" />
                                <asp:Parameter Name="LocationLatitude" Type="Decimal" />
                                <asp:Parameter Name="ConferenceDomain" Type="String"/>                                
                                <asp:SessionParameter Name="ConferenceParentId" SessionField="ParentID" Type="Int32" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" 
                                    DefaultValue="0" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="SiteId" Type="Int32" />
                                <asp:Parameter Name="ConferenceName" Type="String" />
                                <asp:Parameter Name="ConferenceLogo" Type="String" />
                                <asp:Parameter Name="StartDate" Type="DateTime" />
                                <asp:Parameter Name="EndDate" Type="DateTime" />
                                <asp:Parameter Name="IsActive" Type="Boolean" />
                                <asp:Parameter Name="Location" Type="String" />
                                <asp:Parameter Name="LocationName" Type="String" />
                                <asp:Parameter Name="LocationLogo" Type="String" />
                                <asp:Parameter Name="LocationLongitude" Type="Decimal" />
                                <asp:Parameter Name="LocationLatitude" Type="Decimal" />
                                <asp:Parameter Name="ConferenceDomain" Type="String" />
                                <asp:SessionParameter Name="ConferenceParentId" SessionField="ParentID" Type="Int32" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                                <asp:Parameter Name="Original_ConferenceId" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="RegistrationTypeLanguagesObjectDS" runat="server" 
                            DeleteMethod="Delete" InsertMethod="Insert" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                            TypeName="BusinessLogicLayer.Components.Conference.ConferenceRegistrationTypeLanguageLogic" 
                            UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_ConferenceRegistrationTypeId" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="ConferenceId" Type="Int32" />
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="Fee" Type="Decimal" />
                                <asp:SessionParameter DefaultValue="0" 
                                    Name="ConferenceRegistrationTypeParentId" 
                                    SessionField="ConferenceRegistrationTypeParentId" Type="Int32" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                                <asp:Parameter Name="Description" Type="String" />
                                <asp:Parameter Name="OfferMessage" Type="String" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ParentID" 
                                    SessionField="ConferenceRegistrationTypeParentId" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ConferenceId" Type="Int32" />
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="Fee" Type="Decimal" />
                                <asp:SessionParameter DefaultValue="0" 
                                    Name="ConferenceRegistrationTypeParentId" 
                                    SessionField="ConferenceRegistrationTypeParentId" Type="Int32" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                                <asp:Parameter Name="Description" Type="String" />
                                <asp:Parameter Name="OfferMessage" Type="String" />
                                <asp:Parameter Name="Original_ConferenceRegistrationTypeId" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="RegistrationTypesObjectDS" runat="server" 
                            DeleteMethod="Delete" InsertMethod="Insert" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="GetAllByConferenceId" 
                            TypeName="BusinessLogicLayer.Components.Conference.ConferenceRegistrationTypeLogic" 
                            UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_ConferenceRegistrationTypeId" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceId" 
                                    SessionField="ParentID" Type="Int32" />
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="Fee" Type="Decimal" />
                                <asp:Parameter Name="GroupName" Type="String" />
                                <asp:Parameter Name="StartDate" Type="DateTime" />
                                <asp:Parameter Name="EndDate" Type="DateTime" />
                                <asp:Parameter Name="EarlyRegistrationEndDate" Type="DateTime" />
                                <asp:Parameter Name="LateFee" Type="Decimal" />
                                <asp:Parameter Name="ConferenceScheduleID" Type="Int32" />
                                <asp:Parameter Name="OfferStartDate" Type="DateTime" />
                                <asp:Parameter Name="OfferEndDate" Type="DateTime" />
                                <asp:Parameter Name="OfferFee" Type="Decimal" />
                                <asp:Parameter Name="HaveOffer" Type="Boolean" />
                                <asp:Parameter Name="MustRegister" Type="Boolean" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceId" 
                                    SessionField="ParentID" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceId" 
                                    SessionField="ParentID" Type="Int32" />
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="Fee" Type="Decimal" />
                                <asp:Parameter Name="GroupName" Type="String" />
                                <asp:Parameter Name="StartDate" Type="DateTime" />
                                <asp:Parameter Name="EndDate" Type="DateTime" />
                                <asp:Parameter Name="EarlyRegistrationEndDate" Type="DateTime" />
                                <asp:Parameter Name="LateFee" Type="Decimal" />
                                <asp:Parameter Name="ConferenceScheduleID" Type="Int32" />
                                <asp:Parameter Name="OfferStartDate" Type="DateTime" />
                                <asp:Parameter Name="OfferEndDate" Type="DateTime" />
                                <asp:Parameter Name="OfferFee" Type="Decimal" />
                                <asp:Parameter Name="HaveOffer" Type="Boolean" />
                                <asp:Parameter Name="MustRegister" Type="Boolean" />
                                <asp:Parameter Name="Original_ConferenceRegistrationTypeId" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="RegistrationSettingsObjectDS" runat="server" 
                            DeleteMethod="Delete" InsertMethod="Insert" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByConferenceID" 
                            TypeName="BusinessLogicLayer.Components.Conference.ConferenceRegistrationSettingsLogic" 
                            UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_ConferenceRegistrationSettingID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceID" 
                                    SessionField="ParentID" Type="Int32" />
                                <asp:Parameter Name="RegistrationEndDate" Type="DateTime" />
                                <asp:Parameter Name="RegistrationStartDate" Type="DateTime" />
                                <asp:Parameter Name="IsActive" Type="Boolean" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceID" 
                                    SessionField="ParentID" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceID" 
                                    SessionField="ParentID" Type="Int32" />
                                <asp:Parameter Name="RegistrationEndDate" Type="DateTime" />
                                <asp:Parameter Name="RegistrationStartDate" Type="DateTime" />
                                <asp:Parameter Name="IsActive" Type="Boolean" />
                                <asp:Parameter Name="Original_ConferenceRegistrationSettingID" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="RegistrationSettingsLanguagesObjectDS" runat="server" 
                            DeleteMethod="Delete" InsertMethod="Insert" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="GetAllByConferenceRegistrationSettingID" 
                            TypeName="BusinessLogicLayer.Components.Conference.ConferenceRegistrationSettingLanguagesLogic" 
                            UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_ConferenceRegistrationSettingLanguageID" 
                                    Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceRegistrationSettingID" 
                                    SessionField="SettingParentID" Type="Int32" />
                                <asp:Parameter Name="RegistrationShorInstructions" Type="String" />
                                <asp:Parameter Name="RegistrationInstructionsInFormPre" Type="String" />
                                <asp:Parameter Name="RegistrationInstructionsInFormPost" Type="String" />
                                <asp:Parameter Name="PostRegistrationInstructions" Type="String" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceRegistrationSettingID" 
                                    SessionField="SettingParentID" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ConferenceRegistrationSettingID" 
                                    SessionField="SettingParentID" Type="Int32" />
                                <asp:Parameter Name="RegistrationShorInstructions" Type="String" />
                                <asp:Parameter Name="RegistrationInstructionsInFormPre" Type="String" />
                                <asp:Parameter Name="RegistrationInstructionsInFormPost" Type="String" />
                                <asp:Parameter Name="PostRegistrationInstructions" Type="String" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                                <asp:Parameter Name="Original_ConferenceRegistrationSettingLanguageID" 
                                    Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </DetailRow>
                    <EditForm>
                    <div style="padding: 4px 4px 3px 4px;width:100%">
                        <dx:ASPxPageControl ID="conferencePageControl" runat="server"  Width="100%"
                            ActiveTabIndex="0">
                            <TabPages>
                                <dx:TabPage Text="Conference">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl7" runat="server" SupportsDisabledAttribute="True">
                                            <div class="form">
                                                <fieldset class="fieldset">
                                                    <%--<label class="label">Save Conference</label>--%>
                                                    <section><label class="label" for="text_field">Name:</label>
							                            <div>
                                                            <dx:ASPxTextBox width="100%" ID="txtConferenceName" Text='<%# Bind("ConferenceName") %>' runat="server">
                                                                    <ValidationSettings  causesvalidation="True" 
                                                                        display="Dynamic" errordisplaymode="Text">
                                                                        <RequiredField IsRequired="True" />
                                                                        <requiredfield isrequired="True" />
                                                                    </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label" for="text_field">Code:</label>
							                            <div class="half-div">
                                                            <dx:ASPxTextBox width="100%" ID="txtConferenceCode" Text='<%# Bind("ConferenceCode") %>' runat="server">
                                                                    <ValidationSettings  causesvalidation="True" 
                                                                        display="Dynamic" errordisplaymode="Text">
                                                                        <RequiredField IsRequired="True" />
                                                                        <requiredfield isrequired="True" />
                                                                    </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label half-label" for="text_field">Alias:</label>
							                            <div class="half-div">
                                                            <dx:ASPxTextBox width="100%" ID="txtConferenceAlias" Text='<%# Bind("ConferenceAlias") %>' runat="server">
                                                                    <ValidationSettings  causesvalidation="True" 
                                                                        display="Dynamic" errordisplaymode="Text">
                                                                        <RequiredField IsRequired="True" />
                                                                        <requiredfield isrequired="True" />
                                                                    </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label" for="text_field">Start:</label>
							                            <div class="half-div">
                                                            <dx:ASPxDateEdit width="100%" ID="txtStartDate" Value='<%# Bind("StartDate") %>' runat="server">
                                                                    <ValidationSettings  causesvalidation="True" 
                                                                        display="Dynamic" errordisplaymode="Text">
                                                                        <RequiredField IsRequired="True" />
                                                                        <requiredfield isrequired="True" />
                                                                    </ValidationSettings>
                                                            </dx:ASPxDateEdit>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label half-label" for="text_field">End:</label>
							                            <div class="half-div">
                                                            <dx:ASPxDateEdit width="100%" ID="txtEndDate" Value='<%# Bind("EndDate") %>' runat="server">
                                                                    <ValidationSettings  causesvalidation="True" 
                                                                        display="Dynamic" errordisplaymode="Text">
                                                                        <RequiredField IsRequired="True" />
                                                                        <requiredfield isrequired="True" />
                                                                    </ValidationSettings>
                                                            </dx:ASPxDateEdit>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label" for="text_field"></label>
							                            <div class="half-div">
                                                            <dx:ASPxCheckBox width="100%" ID="chkIsActive" Value='<%# Bind("IsActive") %>' Text="Is Active" runat="server">
                                                                    
                                                            </dx:ASPxCheckBox>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label half-label" for="text_field"></label>
							                            <div class="half-div">
                                                            <dx:ASPxCheckBox width="100%" ID="chkIsDefault" Value='<%# Bind("IsDefault") %>' Text="Is Default" runat="server">
                                                                    
                                                            </dx:ASPxCheckBox>
                                
                                                        </div>
						                            </section>
                                                    <section><label class="label" for="text_field">Domain:</label>
							                            <div>
                                                            <dx:ASPxTextBox width="100%" ID="txtConferenceDomain" Text='<%# Bind("ConferenceDomain") %>' runat="server">
                                                                   
                                                            </dx:ASPxTextBox>
                                
                                                        </div>
						                            </section>
                                                    <section><label class="label" for="text_field">Logo:</label>
							                            <div>
                                                            <dx:ASPxUploadControl ID="conferenceLogoUpload" 
                                ClientInstanceName="conferenceLogoUpload" runat="server" 
                                ShowProgressPanel="True" ShowUploadButton="True" 
                                onfileuploadcomplete="conferenceLogoUpload_FileUploadComplete">
                                 <ClientSideEvents FileUploadComplete="function(s, e) {
	Uploader_OnUploadComplete(e);
}" />
<ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe,.gif,.png">
                                            </ValidationSettings>
                                                                <clientsideevents fileuploadcomplete="function(s, e) {
	Uploader_OnUploadComplete(e);
}" />
                            </dx:ASPxUploadControl>
                            <%--<dx:ASPxImage ImageUrl='<%# "~/ContentData/Sites/Conferences/" + Eval("ConferenceLogo") %>' runat="server" ID="lblIconImage" ClientInstanceName="lblIconImage">
                                
                            </dx:ASPxImage>--%>
                            <dx:ASPxLabel ID="lblIconPath" runat="server" 
                        ClientInstanceName="lblIconPath">
                    </dx:ASPxLabel>
                                
                                                        </div>
						                            </section>
                                                </fieldset>
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Location">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl8" runat="server" SupportsDisabledAttribute="True">
                                            <div class="form">
                                                <fieldset class="fieldset">
                                                    <%--<label class="label">Save Conference</label>--%>
                                                    <section><label class="label" for="text_field">Location Name:</label>
							                            <div>
                                                            <dx:ASPxTextBox width="100%" ID="txtLocationName" Text='<%# Bind("LocationName") %>' runat="server">
                                                                   
                                                            </dx:ASPxTextBox>
                                
                                                        </div>
						                            </section>
                                                    <section><label class="label" for="text_field">Location:</label>
							                            <div>
                                                            <dx:ASPxTextBox width="100%" ID="txtLocation" Text='<%# Bind("Location") %>' runat="server">
                                                                   
                                                            </dx:ASPxTextBox>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label" for="text_field">Longitude:</label>
							                            <div class="half-div">
                                                            <dx:ASPxSpinEdit width="100%" ID="txtLocationLongitude" Text='<%# Bind("LocationLongitude") %>' runat="server">
                                                                    
                                                            </dx:ASPxSpinEdit>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label half-label" for="text_field">Latitude:</label>
							                            <div class="half-div">
                                                            <dx:ASPxSpinEdit width="100%" ID="txtLocationLatitude" Text='<%# Bind("LocationLatitude") %>' runat="server">
                                                                    
                                                            </dx:ASPxSpinEdit>
                                
                                                        </div>
						                            </section>

                                                </fieldset>
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="Abstract Settings">
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl1" runat="server" SupportsDisabledAttribute="True">
                                            <div class="form">
                                                <fieldset class="fieldset">
                                                    <%--<label class="label">Save Conference</label>--%>
                                                    <section class="half-section"><label class="label" for="text_field">Start:</label>
							                            <div class="half-div">
                                                            <dx:ASPxDateEdit width="100%" ID="txtAbstractStart" Value='<%# Bind("AbstractSubmissionStartDate") %>' runat="server">
                                                                    
                                                            </dx:ASPxDateEdit>
                                
                                                        </div>
						                            </section>
                                                    <section class="half-section"><label class="label half-label" for="text_field">End:</label>
							                            <div class="half-div">
                                                            <dx:ASPxDateEdit width="100%" ID="txtAbstractEnd" Value='<%# Bind("AbstractSubmissionEndDate") %>' runat="server">
                                                                    
                                                            </dx:ASPxDateEdit>
                                
                                                        </div>
						                            </section>
                                                    <section><label class="label" for="text_field">Submission Ended:</label>
							                            <div>
                                                            <dx:ASPxComboBox width="100%" ID="txtAbstractPageEnd" 
                                                                Value='<%# Bind("AbstractSubmissionEndMessagePageID") %>' runat="server" 
                                                                DataSourceID="ConferencePageObjectDS" IncrementalFilteringMode="Contains" 
                                                                TextField="PageName" ValueField="SitePageId" ValueType="System.Int32">
                                                                   
                                                            </dx:ASPxComboBox>
                                
                                                        </div>
						                            </section>
                                                    <section><label class="label" for="text_field">Submission Not-Started :</label>
							                            <div>
                                                            <dx:ASPxComboBox width="100%" ID="txtAbstractNotStarted" 
                                                                Value='<%# Bind("AbstractSubmissionNotStartedPageID") %>' runat="server" 
                                                                DataSourceID="ConferencePageObjectDS" IncrementalFilteringMode="Contains" 
                                                                TextField="PageName" ValueField="SitePageId" ValueType="System.Int32">
                                                                   
                                                            </dx:ASPxComboBox>
                                
                                                        </div>
						                            </section>
                                                </fieldset>
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                            </TabPages>
                        </dx:ASPxPageControl>
                    </div>
                    <div style="text-align: right; padding: 2px 2px 2px 2px">
                    <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton"
                        runat="server">
                    </dx:ASPxGridViewTemplateReplacement>
                    <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                        runat="server">
                    </dx:ASPxGridViewTemplateReplacement>
                </div>
                    </EditForm>
                </Templates>
            </dx:aspxgridview>
            </div>
            <asp:ObjectDataSource ID="dsLanguages" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ConferencePageObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.ContentManagement.SitePageLogic"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ConferenceObjectDS" runat="server"
                DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_ConferenceId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="SiteId" Type="Int32" />
                    <asp:Parameter Name="ConferenceName" Type="String" />
                    <asp:Parameter Name="ConferenceLogo" Type="String" />
                    <asp:Parameter Name="StartDate" Type="DateTime" />
                    <asp:Parameter Name="EndDate" Type="DateTime" />
                    <asp:Parameter Name="IsActive" Type="Boolean" />
                    <asp:Parameter Name="Location" Type="String" />
                    <asp:Parameter Name="LocationName" Type="String" />
                    <asp:Parameter Name="LocationLogo" Type="String" />
                    <asp:Parameter Name="LocationLongitude" Type="Decimal" />
                    <asp:Parameter Name="LocationLatitude" Type="Decimal" />
                    <asp:Parameter Name="ConferenceDomain" Type="String" />
                    <asp:Parameter Name="ConferenceCode" Type="String" />
                    <asp:Parameter Name="ConferenceAlias" Type="String" />
                    <asp:Parameter Name="ConferenceVenueID" Type="Int32" />
                    <asp:Parameter Name="IsDefault" Type="Boolean" />
                    <asp:Parameter Name="AbstractSubmissionStartDate" Type="DateTime" />
                    <asp:Parameter Name="AbstractSubmissionEndDate" Type="DateTime" />
                    <asp:Parameter Name="AbstractSubmissionEndMessagePageID" Type="Int32" />
                    <asp:Parameter Name="AbstractSubmissionNotStartedPageID" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SiteId" Type="Int32" />
                    <asp:Parameter Name="ConferenceName" Type="String" />
                    <asp:Parameter Name="ConferenceLogo" Type="String" />
                    <asp:Parameter Name="StartDate" Type="DateTime" />
                    <asp:Parameter Name="EndDate" Type="DateTime" />
                    <asp:Parameter Name="IsActive" Type="Boolean" />
                    <asp:Parameter Name="Location" Type="String" />
                    <asp:Parameter Name="LocationName" Type="String" />
                    <asp:Parameter Name="LocationLogo" Type="String" />
                    <asp:Parameter Name="LocationLongitude" Type="Decimal" />
                    <asp:Parameter Name="LocationLatitude" Type="Decimal" />
                    <asp:Parameter Name="ConferenceDomain" Type="String" />
                    <asp:Parameter Name="ConferenceCode" Type="String" />
                    <asp:Parameter Name="ConferenceAlias" Type="String" />
                    <asp:Parameter Name="ConferenceVenueID" Type="Int32" />
                    <asp:Parameter Name="IsDefault" Type="Boolean" />
                    <asp:Parameter Name="AbstractSubmissionStartDate" Type="DateTime" />
                    <asp:Parameter Name="AbstractSubmissionEndDate" Type="DateTime" />
                    <asp:Parameter Name="AbstractSubmissionEndMessagePageID" Type="Int32" />
                    <asp:Parameter Name="AbstractSubmissionNotStartedPageID" Type="Int32" />
                    <asp:Parameter Name="Original_ConferenceId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="VenueObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.Conference.VenuesLogic"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="SiteObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="conferenceScheduleObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAllByConferenceId"
                TypeName="BusinessLogicLayer.Components.Conference.ConferenceScheduleLogic">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="ConferenceID"
                        SessionField="ParentID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
        </div>
    </div>
</asp:Content>
