<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.PageManager.ModuleTypes.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/moduletypes.png" />
        </div>
        <div class="title-text"><asp:Literal ID="Literal1" runat="server" Text="Manage Module Type"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ContentModuleTypeID"
                Width="100%" DataSourceID="SourcesObjectDS" OnCellEditorInitialize="SourcesGrid_CellEditorInitialize" onrowupdating="ConferenceGrid_RowUpdating" 
                        onstartrowediting="ConferenceGrid_StartRowEditing"  OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ContentModuleTypeID" ReadOnly="True" VisibleIndex="1" Width="50px" Visible="false" Caption="ID">
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
        <SettingsCommandButton>

            <EditButton ButtonType="Image">
                <Image Url="~/images/geni/toolbox/edit.png">
                </Image>
            </EditButton>
            <DeleteButton ButtonType="Image">
                <Image Url="~/images/geni/toolbox/remove2.png">
                </Image>
            </DeleteButton>
            <UpdateButton Text="<%$Resources:ContentManagement, GridSave %>">
            </UpdateButton>
            <CancelButton Text="<%$Resources:ContentManagement, GridCancel %>">
            </CancelButton>

        </SettingsCommandButton>
        <SettingsBehavior ConfirmDelete="True" />
        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
        <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
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
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
