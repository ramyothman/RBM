<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.Conference.Sponsors.Manage" %>
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
				<h3 class="handle">Manage Sponsors </h3>
				<div class="inner-content">
            <dx:ASPxGridView ID="SponsorsGrid" ClientInstanceName="SponsorsGrid" onrowinserting="SponsorGrid_RowInserting" 
                onrowupdating="SponsorGrid_RowUpdating" 
                onstartrowediting="SponsorGrid_StartRowEditing"
                runat="server" AutoGenerateColumns="False" DataSourceID="SponsorsObjectDS" 
                KeyFieldName="SponsorId" Width="100%">
                <Columns>
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

                    <dx:GridViewDataTextColumn FieldName="SponsorId" ReadOnly="True" VisibleIndex="1" Visible="False" Caption="Id" Width="50px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SponsorName" VisibleIndex="2" Caption="Name">
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Conference" FieldName="ConferenceId" VisibleIndex="3" Width="200px">
                        <PropertiesComboBox DataSourceID="ConferenceObjectDS" 
                            TextField="ConferenceName" ValueField="ConferenceId" ValueType="System.Int32">
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="SponsorType" VisibleIndex="4" Caption="Type" Width="120px">
                        <PropertiesComboBox ValueType="System.String">
                            <Items>
                                <dx:ListEditItem Text="Platinum" Value="Platinum" />
                                <dx:ListEditItem Text="Gold" Value="Gold" />
                                <dx:ListEditItem Text="Silver" Value="Silver" />
                            </Items>
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataImageColumn FieldName="SponsorImage" VisibleIndex="5" Caption="Logo" Width="100px">
                        <PropertiesImage ImageHeight="64px" 
                            ImageUrlFormatString="~/ContentData/Sites/Conferences/{0}" ImageWidth="64px">
                            <EmptyImage Height="64px" Url="~/images/emptyimage.png" Width="64px">
                            </EmptyImage>
                        </PropertiesImage>
                        <EditFormSettings ColumnSpan="2" />
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
                    </dx:GridViewDataImageColumn>
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
                            DataSourceID="dsSponsorLang" KeyFieldName="SponsorId"  onrowinserting="SponsorGrid_RowInserting" 
                onrowupdating="SponsorGrid_RowUpdating" 
                onstartrowediting="SponsorGrid_StartRowEditing" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect">
                             <Columns>
                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px">
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

                    <dx:GridViewDataTextColumn FieldName="SponsorId" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SponsorName" VisibleIndex="2">
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Conference" FieldName="ConferenceId" VisibleIndex="3" Visible="false">
                        <PropertiesComboBox DataSourceID="ConferenceObjectDS" 
                            TextField="ConferenceName" ValueField="ConferenceId" ValueType="System.Int32">
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="SponsorType" VisibleIndex="4" Visible="false">
                        <PropertiesComboBox ValueType="System.String">
                            <Items>
                                <dx:ListEditItem Text="Platinum" Value="Platinum" />
                                <dx:ListEditItem Text="Gold" Value="Gold" />
                                <dx:ListEditItem Text="Silver" Value="Silver" />
                            </Items>
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataImageColumn FieldName="SponsorImage" VisibleIndex="5" Visible="false">
                        <PropertiesImage ImageHeight="64px" 
                            ImageUrlFormatString="~/ContentData/Sites/Conferences/{0}" ImageWidth="64px">
                            <EmptyImage Height="64px" Url="~/images/emptyimage.png" Width="64px">
                            </EmptyImage>
                        </PropertiesImage>
                        <EditFormSettings ColumnSpan="2" />
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
                    </dx:GridViewDataImageColumn>
                      <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageID" 
                        VisibleIndex="22">
                        <PropertiesComboBox DataSourceID="dsLanguages" TextField="Name" ValueField="LanguageId"></PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="SponsorParentID" VisibleIndex="6" Visible="false">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="NewRecord" VisibleIndex="7" Visible="false">
                                </dx:GridViewDataCheckColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                    EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                               
                         </dx:ASPxGridView>
                          <asp:ObjectDataSource ID="dsLanguages" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
            </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="dsSponsorLang" runat="server" DeleteMethod="Delete" 
                            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="GetAll" 
                            TypeName="BusinessLogicLayer.Components.Conference.SponsorslanguageLogic" 
                            UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_SponsorId" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="SponsorName" Type="String" />
                                <asp:Parameter Name="ConferenceId" Type="Int32" />
                                <asp:Parameter Name="SponsorType" Type="String" />
                                <asp:Parameter Name="SponsorImage" Type="String" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                               <asp:SessionParameter Name="SponsorParentID" SessionField="ParentID" 
                                    Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="SponsorParentID" SessionField="ParentID" 
                                    Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="SponsorName" Type="String" />
                                <asp:Parameter Name="ConferenceId" Type="Int32" />
                                <asp:Parameter Name="SponsorType" Type="String" />
                                <asp:Parameter Name="SponsorImage" Type="String" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                                <asp:SessionParameter Name="SponsorParentID" SessionField="ParentID" 
                                    Type="Int32" />
                                <asp:Parameter Name="Original_SponsorId" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            </div>
            <asp:ObjectDataSource ID="SponsorsObjectDS" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                TypeName="BusinessLogicLayer.Components.Conference.SponsorsLogic" 
                DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_SponsorId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="SponsorName" Type="String" />
                    <asp:Parameter Name="ConferenceId" Type="Int32" />
                    <asp:Parameter Name="SponsorType" Type="String" />
                    <asp:Parameter Name="SponsorImage" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SponsorName" Type="String" />
                    <asp:Parameter Name="ConferenceId" Type="Int32" />
                    <asp:Parameter Name="SponsorType" Type="String" />
                    <asp:Parameter Name="SponsorImage" Type="String" />
                    <asp:Parameter Name="Original_SponsorId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ConferenceObjectDS" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic">
            </asp:ObjectDataSource>
            <br />

        </div>
        </div>
</asp:Content>
