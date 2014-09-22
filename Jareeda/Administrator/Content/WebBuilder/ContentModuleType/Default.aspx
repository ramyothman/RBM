<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Content.WebBuilder.ContentModuleType.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <script type="text/javascript">
         function Uploader_OnUploadComplete(args) {
             if (args.isValid) {
                 //            txtImageUploadPath.SetText(args.callbackData);
                 lblIconPath.SetText(args.callbackData);
             }
         }
         var lastSite = null;
         function OnSiteChanged(cmbSite) {

             if (grid.GetEditor("PositionID").InCallback())
                 lastSite = cmbSite.GetValue().toString();
             else
                 grid.GetEditor("PositionID").PerformCallback(cmbSite.GetValue().toString());


         }
         function OnEndCallbackSection(s, e) {
             if (lastSite) {
                 grid.GetEditor("PositionID").PerformCallback(lastSite);
                 lastSite = null;
             }
         }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
       <div class="col-md-4">
        <h1>
            <asp:Literal ID="Literal1" runat="server" Text="Manage Module Type"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
      

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
     <dx:ASPxGridView ID="SourcesGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="ContentModuleTypeID"
                Width="100%" onrowinserting="ConferenceGrid_RowInserting" ClientInstanceName="grid" 
                        onrowupdating="ConferenceGrid_RowUpdating" 
                        onstartrowediting="ConferenceGrid_StartRowEditing" DataSourceID="SourcesObjectDS" OnCellEditorInitialize="SourcesGrid_CellEditorInitialize" >
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
                    <dx:GridViewDataTextColumn FieldName="ContentModuleTypeID" ReadOnly="True" VisibleIndex="1" Width="50px" Caption="ID">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Site" FieldName="SiteID" VisibleIndex="2" Width="120px">
                        <propertiescombobox datasourceid="ObjectDataSourceSites" textfield="Name" valuefield="SiteId" valuetype="System.Int32">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { OnSiteChanged(s); }"></ClientSideEvents>
                        </propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="3">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn Caption="Code" FieldName="Code" VisibleIndex="4">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn FieldName="ImagePreview" Caption="<%$Resources:ContentManagement, MIPhotoPath %>" VisibleIndex="2" 
                        Width="250px">
                        <PropertiesImage ImageWidth="140px" 
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
                    
                    <dx:GridViewDataComboBoxColumn Caption="Position" FieldName="PositionID" VisibleIndex="5">
                        <propertiescombobox datasourceid="PositionObjectDS" textfield="Name" valuefield="PositionID" valuetype="System.Int32">
                            <ClientSideEvents EndCallback="OnEndCallbackSection"></ClientSideEvents>
                        </propertiescombobox>
                        <editformsettings columnspan="2" />
                            
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="ControlPath" VisibleIndex="6">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>
     <asp:ObjectDataSource ID="SourcesObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ContentModuleTypeLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_ContentModuleTypeID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="SiteID" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Code" Type="String" />
                    <asp:Parameter Name="ImagePreview" Type="String" />
                    <asp:Parameter Name="PositionID" Type="Int32" />
                    <asp:Parameter Name="ControlPath" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SiteID" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Code" Type="String" />
                    <asp:Parameter Name="ImagePreview" Type="String" />
                    <asp:Parameter Name="PositionID" Type="Int32" />
                    <asp:Parameter Name="ControlPath" Type="String" />
                    <asp:Parameter Name="Original_ContentModuleTypeID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSourceSites" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSourceSites0" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="PositionObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteID" TypeName="BusinessLogicLayer.Components.ContentManagement.PositionLogic">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="SiteID" SessionField="MSiteID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="PositionAllObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.PositionLogic"></asp:ObjectDataSource>
</asp:Content>
