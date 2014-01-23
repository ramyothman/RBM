<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.ContentManagement.Multimedia.Manage" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="g12 widgets">
			<div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
				<h3 class="handle"><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, MUTitle %>"></asp:Literal></h3>
				<div class="inner-content">
                    

            <dx:ASPxGridView ID="SourcesGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="MultimediaID"
                Width="100%" DataSourceID="SourcesObjectDS" onrowinserting="ConferenceGrid_RowInserting" 
                        onrowupdating="ConferenceGrid_RowUpdating" 
                        onstartrowediting="ConferenceGrid_StartRowEditing">
                <Columns>
                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="1" Width="60px" Caption=" ">
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
                    <dx:GridViewDataTextColumn FieldName="MultimediaID" ReadOnly="True" VisibleIndex="0" Caption="Id" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MUType %>" FieldName="MultimediaTypeID" VisibleIndex="3" Width="120px">
                        <propertiescombobox datasourceid="MultimediaTypeObjectDS" textfield="Name" valuefield="MultimediaTypeID" valuetype="System.Int32">
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    
                    <dx:GridViewDataImageColumn FieldName="Url"  VisibleIndex="8" 
                        Width="250px" Caption="<%$Resources:ContentManagement, MUImage %>">
                        <PropertiesImage ImageHeight="80px" 
                            ImageUrlFormatString="~/ContentData/{0}">
                        </PropertiesImage>
                        <EditFormSettings ColumnSpan="2" />
                        <EditItemTemplate>
                            <dx:ASPxUploadControl ID="conferenceLogoUpload" runat="server" 
                                ClientInstanceName="conferenceLogoUpload" 
                                onfileuploadcomplete="conferenceLogoUpload_FileUploadComplete" 
                                ShowProgressPanel="True" ShowUploadButton="True">
                                <ClientSideEvents FileUploadComplete="function(s, e) {
	Uploader_OnUploadComplete(e);
}" />
<ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe,.gif,.png">
                                            </ValidationSettings>
                            </dx:ASPxUploadControl>
                            <dx:ASPxLabel ID="lblIconPath" runat="server" ClientInstanceName="lblIconPath">
                            </dx:ASPxLabel>
                        </EditItemTemplate>
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn FieldName="ThumbnainUrl" VisibleIndex="3" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Title" Caption="<%$Resources:ContentManagement, MUName %>" VisibleIndex="2">
                        <propertiestextedit>
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiestextedit>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="Description" Caption="<%$Resources:ContentManagement, MUDescription %>" VisibleIndex="5">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="PublishDate" Caption="<%$Resources:ContentManagement, MUPublishDate %>" VisibleIndex="6">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="CreatedDate" Caption="<%$Resources:ContentManagement, MUCreatedDate %>" VisibleIndex="7" Visible="False">
                    </dx:GridViewDataDateColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>
            </div>

            <asp:ObjectDataSource ID="SourcesObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MultimediaLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_MultimediaID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="MultimediaTypeID" Type="Int32" />
                    <asp:Parameter Name="Url" Type="String" />
                    <asp:Parameter Name="ThumbnainUrl" Type="String" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="PublishDate" Type="DateTime" />
                    <asp:Parameter Name="CreatedDate" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="MultimediaTypeID" Type="Int32" />
                    <asp:Parameter Name="Url" Type="String" />
                    <asp:Parameter Name="ThumbnainUrl" Type="String" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="PublishDate" Type="DateTime" />
                    <asp:Parameter Name="CreatedDate" Type="DateTime" />
                    <asp:Parameter Name="Original_MultimediaID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="MultimediaTypeObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MultimediaTypeLogic"></asp:ObjectDataSource>
            <br />
                </div>
         </div>
    
</asp:Content>
