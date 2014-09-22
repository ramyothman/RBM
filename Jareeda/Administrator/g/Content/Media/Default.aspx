<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Content.Media.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function Uploader_OnUploadComplete(args) {
             if (args.isValid) {
                 lblIconPath.SetText(args.callbackData);
             }
         }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-5">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/multimedia.png" />
        </div>
        <div class="title-text">Media Manager</div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="SourcesObjectDS" KeyFieldName="MultimediaID" Width="100%" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted" OnRowInserting="ConferenceGrid_RowInserting"
        OnRowUpdating="ConferenceGrid_RowUpdating"
        OnStartRowEditing="ConferenceGrid_StartRowEditing">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="MultimediaID" ReadOnly="True" VisibleIndex="1" Caption="Id" Visible="False">
                <EditFormSettings Visible="False"></EditFormSettings>
            </dx:GridViewDataTextColumn>
            
            <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MUType %>" FieldName="MultimediaTypeID" VisibleIndex="4" Width="120px">
                        <propertiescombobox datasourceid="MultimediaTypeObjectDS" textfield="Name" valuefield="MultimediaTypeID" valuetype="System.Int32">
<validationsettings causesvalidation="True" ErrorDisplayMode="None" Display="Dynamic">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataImageColumn FieldName="Url"  VisibleIndex="5" 
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
            <dx:GridViewDataTextColumn FieldName="ThumbnainUrl" Caption="<%$Resources:ContentManagement, MUVideoUrl %>" VisibleIndex="6" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Title" Caption="<%$Resources:ContentManagement, MUName %>" VisibleIndex="2">
                        <propertiestextedit>
<validationsettings causesvalidation="True" Display="Dynamic" ErrorDisplayMode="None">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiestextedit>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn FieldName="Description" Width="120px" Caption="<%$Resources:ContentManagement, MUDescription %>" VisibleIndex="3">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="PublishDate" Width="60px" Caption="<%$Resources:ContentManagement, MUPublishDate %>" VisibleIndex="7">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="CreatedDate" Width="60px" Caption="<%$Resources:ContentManagement, MUCreatedDate %>" VisibleIndex="8" Visible="False">
                    </dx:GridViewDataDateColumn>
            <dx:GridViewDataCheckColumn FieldName="NewRecord" VisibleIndex="9" Visible="false"></dx:GridViewDataCheckColumn>
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
        <Settings ShowFilterRow="True" />
        <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
    </dx:ASPxGridView>
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
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
