<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Content.MainImages.Default" %>
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
    <div class="col-md-4">
        <h1>
            <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, MITitle %>"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
      

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
     <dx:ASPxGridView ID="ConferenceProgramGrid" runat="server" 
                AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                KeyFieldName="ConferenceMainImageId" onrowinserting="ConferenceGrid_RowInserting" 
                        onrowupdating="ConferenceGrid_RowUpdating" 
                        onstartrowediting="ConferenceGrid_StartRowEditing" Width="100%">


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
                    <dx:GridViewDataTextColumn FieldName="ConferenceMainImageId" ReadOnly="True" 
                        Visible="False" VisibleIndex="1" Caption="<%$Resources:ContentManagement, MIID %>">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn FieldName="PhotoPath" Caption="<%$Resources:ContentManagement, MIPhotoPath %>" VisibleIndex="2" 
                        Width="250px">
                        <PropertiesImage ImageHeight="80px" 
                            ImageUrlFormatString="~/ContentData/Sites/Conferences/{0}">
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
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MISite %>" FieldName="ConferenceId" 
                        VisibleIndex="3">
                        <PropertiesComboBox DataSourceID="ConferenceObjectDS" 
                            TextField="ConferenceName" ValueField="ConferenceId" ValueType="System.Int32">
                            
<ValidationSettings CausesValidation="True" Display="Dynamic" 
                                ErrorDisplayMode="Text">
                                
<RequiredField IsRequired="True" />
                            
</ValidationSettings>
                        
</PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MILanguage %>" FieldName="LanguageId" 
                        VisibleIndex="4">
                        <PropertiesComboBox DataSourceID="dsLanguages" TextField="Name" 
                            ValueField="LanguageId" ValueType="System.Int32">
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, MIName %>" FieldName="PhotoTitle" 
                        Visible="False" VisibleIndex="5">
                        <EditFormSettings ColumnSpan="2" Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, MILink %>" FieldName="PhotoLink" Visible="False" 
                        VisibleIndex="6">
                        <EditFormSettings ColumnSpan="2" Visible="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataMemoColumn Caption="<%$Resources:ContentManagement, MIDescription %>" FieldName="PhotoDescription" 
                        Visible="False" VisibleIndex="7">
                        <EditFormSettings ColumnSpan="2" Visible="True" />
                    </dx:GridViewDataMemoColumn>
                </Columns>
                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />

                
            </dx:ASPxGridView>
    <asp:ObjectDataSource ID="dsLanguages" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
            </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.Conference.ConferenceMainImagesLogic" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ConferenceMainImageId" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="PhotoPath" Type="String" />
                        <asp:Parameter Name="ConferenceId" Type="Int32" />
                        <asp:Parameter Name="LanguageId" Type="Int32" />
                        <asp:Parameter Name="PhotoLink" Type="String" />
                        <asp:Parameter Name="PhotoTitle" Type="String" />
                        <asp:Parameter Name="PhotoDescription" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="PhotoPath" Type="String" />
                        <asp:Parameter Name="ConferenceId" Type="Int32" />
                        <asp:Parameter Name="LanguageId" Type="Int32" />
                        <asp:Parameter Name="PhotoLink" Type="String" />
                        <asp:Parameter Name="PhotoTitle" Type="String" />
                        <asp:Parameter Name="PhotoDescription" Type="String" />
                        <asp:Parameter Name="Original_ConferenceMainImageId" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConflictDetection="CompareAllValues" 
                    ConnectionString="<%$ ConnectionStrings:MainDB %>" 
                    DeleteCommand="DELETE FROM [Conference].[ConferenceMainImages] WHERE [ConferenceMainImageId] = @original_ConferenceMainImageId AND (([PhotoPath] = @original_PhotoPath) OR ([PhotoPath] IS NULL AND @original_PhotoPath IS NULL)) AND (([ConferenceId] = @original_ConferenceId) OR ([ConferenceId] IS NULL AND @original_ConferenceId IS NULL)) AND (([LanguageId] = @original_LanguageId) OR ([LanguageId] IS NULL AND @original_LanguageId IS NULL))" 
                    InsertCommand="INSERT INTO [Conference].[ConferenceMainImages] ([PhotoPath], [ConferenceId], [LanguageId]) VALUES (@PhotoPath, @ConferenceId, @LanguageId)" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectCommand="SELECT * FROM [Conference].[ConferenceMainImages]" 
                    UpdateCommand="UPDATE [Conference].[ConferenceMainImages] SET [PhotoPath] = @PhotoPath, [ConferenceId] = @ConferenceId, [LanguageId] = @LanguageId WHERE [ConferenceMainImageId] = @original_ConferenceMainImageId AND (([PhotoPath] = @original_PhotoPath) OR ([PhotoPath] IS NULL AND @original_PhotoPath IS NULL)) AND (([ConferenceId] = @original_ConferenceId) OR ([ConferenceId] IS NULL AND @original_ConferenceId IS NULL)) AND (([LanguageId] = @original_LanguageId) OR ([LanguageId] IS NULL AND @original_LanguageId IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_ConferenceMainImageId" Type="Int32" />
                        <asp:Parameter Name="original_PhotoPath" Type="String" />
                        <asp:Parameter Name="original_ConferenceId" Type="Int32" />
                        <asp:Parameter Name="original_LanguageId" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="PhotoPath" Type="String" />
                        <asp:Parameter Name="ConferenceId" Type="Int32" />
                        <asp:Parameter Name="LanguageId" Type="Int32" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="PhotoPath" Type="String" />
                        <asp:Parameter Name="ConferenceId" Type="Int32" />
                        <asp:Parameter Name="LanguageId" Type="Int32" />
                        <asp:Parameter Name="original_ConferenceMainImageId" Type="Int32" />
                        <asp:Parameter Name="original_PhotoPath" Type="String" />
                        <asp:Parameter Name="original_ConferenceId" Type="Int32" />
                        <asp:Parameter Name="original_LanguageId" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            <asp:ObjectDataSource ID="ConferenceObjectDS" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic">
            </asp:ObjectDataSource>
</asp:Content>
