<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.Conference.ConferenceSchedules.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">
        function Uploader_OnUploadComplete(args) {
            if (args.isValid) {
                //            txtImageUploadPath.SetText(args.callbackData);
                lblIconPath.SetText(args.callbackData);
            }
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="g12 widgets">
			<div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
				<h3 class="handle">Manage Conference Schedules-<asp:Literal ID="litProgramName" runat="server"></asp:Literal></h3>
				<div class="inner-content">
            <dx:ASPxGridView ID="ConferenceProgramGrid" runat="server" AutoGenerateColumns="False"
                DataSourceID="ConferenceProgramsObjectDS" KeyFieldName="ScheduleId" onrowinserting="ConferenceGrid_RowInserting" 
                onrowupdating="ConferenceGrid_RowUpdating" 
                onstartrowediting="ConferenceGrid_StartRowEditing" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image" Caption=" " Width="60px">
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
                    <dx:GridViewDataTextColumn FieldName="ScheduleId" ReadOnly="True" 
                        VisibleIndex="1" Visible="false"
                        Caption="Id" Width="50px">
                        <EditFormSettings Visible="False" />
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Program" Visible="false"
                        FieldName="ConferenceProgramId" VisibleIndex="2" Width="120px">
                        <PropertiesComboBox DataSourceID="ProgramObjectDS" TextField="ProgramName" ValueField="ConferenceProgramId"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Speaker Name" FieldName="SpeakerName" 
                        VisibleIndex="7" Width="120px">
                        <PropertiesComboBox DataSourceID="DSSpeaker" TextField="CurrentPerson.DisplayName"
                            ValueField="ConferenceSpeakerId" ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Session Type" FieldName="ScheduleSessionTypeId"
                        VisibleIndex="4" Width="80px">
                        <PropertiesComboBox DataSourceID="SessionTypeObjectDS" TextField="Name" ValueField="ScheduleSessionTypeId"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataDateColumn FieldName="StartTime" VisibleIndex="5" Width="80px">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm tt" EditFormat="DateTime">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EndTime" VisibleIndex="6" Width="80px">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm tt" EditFormat="DateTime">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Hall" FieldName="ConferenceHallId" 
                        VisibleIndex="7" Width="80px">
                        <PropertiesComboBox DataSourceID="HallObjectDS" TextField="Name" ValueField="ConferenceHallsId"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Description"
                        VisibleIndex="8" Width="200px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn FieldName="AllDescription"
                        Visible="False" VisibleIndex="9">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataMemoColumn>
                    
                     <dx:GridViewDataTextColumn FieldName="DocPath" Visible="true" 
                        VisibleIndex="9" Width="80px">
                        <EditFormSettings Visible="True" ColumnSpan="2" />
                        <EditItemTemplate>
                            <dx:ASPxUploadControl ID="conferenceLogoUpload" 
                                ClientInstanceName="conferenceLogoUpload" runat="server" 
                                ShowProgressPanel="True" ShowUploadButton="True" 
                                onfileuploadcomplete="conferenceLogoUpload_FileUploadComplete">
                                 <ClientSideEvents FileUploadComplete="function(s, e) {
	Uploader_OnUploadComplete(e);
}" />
                            </dx:ASPxUploadControl>
                            <dx:ASPxLabel ID="lblIconPath" runat="server" 
                        ClientInstanceName="lblIconPath">
                    </dx:ASPxLabel>
                        </EditItemTemplate>
                        <DataItemTemplate>
                        <a href='<%#BusinessLogicLayer.Common.ConferenceScheduleDocPath+Eval("DocPath") %>' target="_blank" runat="server" id="a" visible='<%#Eval("DocPath").ToString()!="" %>'>view</a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                    EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="dsConferenceSchedule" KeyFieldName="ScheduleId" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect">
                            <Columns>
                    <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0" 
                                    ButtonType="Image" Width="70px">
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
                    <dx:GridViewDataTextColumn FieldName="ScheduleId" ReadOnly="True" VisibleIndex="1" Visible="false"
                        Caption="Id" ShowInCustomizationForm="True">
                        <EditFormSettings Visible="False" />
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Program" FieldName="ConferenceProgramId" Visible="false"
                        ShowInCustomizationForm="True" VisibleIndex="2">
                        <PropertiesComboBox DataSourceID="ProgramObjectDS" TextField="ProgramName" ValueField="ConferenceProgramId"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="3" 
                                    ShowInCustomizationForm="True" Width="200px">
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Speaker Name" FieldName="SpeakerID" VisibleIndex="8" Visible="false">
                        <PropertiesComboBox DataSourceID="DSSpeaker" TextField="CurrentPerson.DisplayName"
                            ValueField="ConferenceSpeakerId" ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Session Type" FieldName="ScheduleSessionTypeId" Visible="false"
                        VisibleIndex="4">
                        <PropertiesComboBox DataSourceID="SessionTypeObjectDS" TextField="Name" ValueField="ScheduleSessionTypeId"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataDateColumn FieldName="StartTime" ShowInCustomizationForm="True" VisibleIndex="5" Visible="false">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm tt" EditFormat="DateTime">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EndTime" ShowInCustomizationForm="True" VisibleIndex="6" Visible="false">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm tt" EditFormat="DateTime" >
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Hall" FieldName="ConferenceHallId" VisibleIndex="8" Visible="false">
                        <PropertiesComboBox DataSourceID="HallObjectDS" TextField="Name" ValueField="ConferenceHallsId"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Description" ShowInCustomizationForm="True" Visible="false"
                        VisibleIndex="9">
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn FieldName="AllDescription" ShowInCustomizationForm="True" Visible="false"
                        VisibleIndex="10">
                        <EditFormSettings Visible="True" />
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn FieldName="DocPath" ShowInCustomizationForm="True" Visible="False"
                        VisibleIndex="10">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataMemoColumn>
                     <dx:GridViewDataTextColumn FieldName="ScheduleparentID" VisibleIndex="12" Visible="false">
                                </dx:GridViewDataTextColumn>
                               <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageID" 
                        VisibleIndex="22">
                        <PropertiesComboBox DataSourceID="dsLanguages" TextField="Name" ValueField="LanguageId"></PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>
                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                    EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="600px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                               
                            
                        </dx:ASPxGridView>
                         <asp:ObjectDataSource ID="dsLanguages" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
            </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="dsConferenceSchedule" runat="server" 
                            DeleteMethod="Delete" InsertMethod="Insert" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                            TypeName="BusinessLogicLayer.Components.Conference.ConferenceScheduleLanguageLogic" 
                            UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_ScheduleId" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="ConferenceProgramId" Type="Int32" />
                                <asp:Parameter Name="Title" Type="String" />
                                <asp:Parameter Name="ScheduleSessionTypeId" Type="Int32" />
                                <asp:Parameter Name="StartTime" Type="DateTime" />
                                <asp:Parameter Name="EndTime" Type="DateTime" />
                                <asp:Parameter Name="SpeakerName" Type="String" />
                                <asp:Parameter Name="ConferenceHallId" Type="Int32" />
                                <asp:Parameter Name="Description" Type="String" />
                                <asp:Parameter Name="AllDescription" Type="String" />
                                <asp:Parameter Name="SpeakerID" Type="Int32" />
                                <asp:Parameter Name="DocPath" Type="String" />                                
                                <asp:SessionParameter Name="ScheduleparentID" SessionField="ParentID" 
                                    Type="Int32" DefaultValue="0" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ConferenceProgramId" Type="Int32" />
                                <asp:Parameter Name="Title" Type="String" />
                                <asp:Parameter Name="ScheduleSessionTypeId" Type="Int32" />
                                <asp:Parameter Name="StartTime" Type="DateTime" />
                                <asp:Parameter Name="EndTime" Type="DateTime" />
                                <asp:Parameter Name="SpeakerName" Type="String" />
                                <asp:Parameter Name="ConferenceHallId" Type="Int32" />
                                <asp:Parameter Name="Description" Type="String" />
                                <asp:Parameter Name="AllDescription" Type="String" />
                                <asp:Parameter Name="SpeakerID" Type="Int32" />
                                <asp:Parameter Name="DocPath" Type="String" />
                                <asp:SessionParameter Name="ScheduleparentID" SessionField="ParentID" 
                                    Type="Int32" DefaultValue="0" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                                <asp:Parameter Name="Original_ScheduleId" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            </div>
            <asp:ObjectDataSource ID="HallObjectDS" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Conference.ConferenceHallsLogic">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="DSSpeaker" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Conference.ConferenceSpeakersLogic">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="SessionTypeObjectDS" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Conference.ScheduleSessionTypeLogic">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ConferenceProgramsObjectDS" runat="server" DeleteMethod="Delete"
                InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.Conference.ConferenceScheduleLogic" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_ScheduleId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:QueryStringParameter QueryStringField="ProgramID" Name="ConferenceProgramId" Type="Int32" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="ScheduleSessionTypeId" Type="Int32" />
                    <asp:Parameter Name="StartTime" Type="DateTime" />
                    <asp:Parameter Name="EndTime" Type="DateTime" />
                    <asp:Parameter Name="SpeakerName" Type="String" />
                    <asp:Parameter Name="ConferenceHallId" Type="Int32" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="AllDescription" Type="String" />
                    <asp:Parameter Name="SpeakerID" Type="Int32" />
                    <asp:Parameter Name="DocPath" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:QueryStringParameter Name="ProgramID" QueryStringField="ProgramID" 
                        Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                     <asp:QueryStringParameter QueryStringField="ProgramID" Name="ConferenceProgramId" Type="Int32" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="ScheduleSessionTypeId" Type="Int32" />
                    <asp:Parameter Name="StartTime" Type="DateTime" />
                    <asp:Parameter Name="EndTime" Type="DateTime" />
                    <asp:Parameter Name="SpeakerName" Type="String" />
                    <asp:Parameter Name="ConferenceHallId" Type="Int32" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="AllDescription" Type="String" />
                    <asp:Parameter Name="SpeakerID" Type="Int32" />
                    <asp:Parameter Name="DocPath" Type="String" />
                    <asp:Parameter Name="Original_ScheduleId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ConferenceObjectDS" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ProgramObjectDS" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Conference.ConferenceProgramsLogic">
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
