<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Content.Menu.Items.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-5">
        <div class="title-icon">
            <img runat="server" src="~/_MasterNew/styles/images/ribbon/menu.png" />
        </div>
        <div runat="server" id="MenuManagerTitle" class="title-text"></div>
    </div>
    <div class="col-md-4 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="window.location.href='Save?menu=' + $.QueryString['Code'];"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxTreeList ClientInstanceName="tree" ID="tree" runat="server" AutoGenerateColumns="False" DataSourceID="MenuEntityItemObjectDS" KeyFieldName="MenuEntityItemId" ParentFieldName="MenuEntityParentId" Width="100%" OnNodeDeleted="tree_NodeDeleted">
        <Columns>
            <dx:TreeListTextColumn FieldName="MenuEntityParentId" ShowInCustomizationForm="False" Visible="False" VisibleIndex="0">
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="Name" Caption="<%$Resources:ContentManagement, MenuItemManagerName %>" VisibleIndex="1" Width="160px">
                <DataCellTemplate>
                    <a href="<%# "Save?Code=" + Eval("MenuEntityItemId") + "&menu=" + Request["Code"] %>"><%# Eval("Name") %></a>
                </DataCellTemplate>
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="PagePath" Caption="<%$Resources:ContentManagement, MenuItemManagerPath %>" VisibleIndex="2">
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="ContentEntityId" Visible="False" VisibleIndex="9">
            </dx:TreeListTextColumn>
            <dx:TreeListCheckColumn FieldName="DisplayAlways" ShowInCustomizationForm="False" Visible="False" VisibleIndex="3">
            </dx:TreeListCheckColumn>
            <dx:TreeListCheckColumn FieldName="IsActive" Visible="False" VisibleIndex="4" Width="80px">
            </dx:TreeListCheckColumn>
            <dx:TreeListTextColumn Caption="<%$Resources:ContentManagement, MenuItemManagerOrder %>" FieldName="DisplayOrder" VisibleIndex="5" Width="60px">
            </dx:TreeListTextColumn>
            <dx:TreeListDateTimeColumn Caption="<%$Resources:ContentManagement, MenuItemManagerModified %>" FieldName="ModifiedDate" VisibleIndex="8" Width="80px">
            </dx:TreeListDateTimeColumn>
            <dx:TreeListTextColumn FieldName="MenuEntityTypeId" ShowInCustomizationForm="False" Visible="False" VisibleIndex="10">
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="MenuEntityId" ShowInCustomizationForm="False" Visible="False" VisibleIndex="11">
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="PageName" ShowInCustomizationForm="False" Visible="False" VisibleIndex="12">
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="SiteName" ShowInCustomizationForm="False" Visible="False" VisibleIndex="13">
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="LanguageID" ShowInCustomizationForm="False" Visible="False" VisibleIndex="14">
            </dx:TreeListTextColumn>
            <dx:TreeListTextColumn FieldName="MenuEntityPositionID" ShowInCustomizationForm="False" Visible="False" VisibleIndex="15">
            </dx:TreeListTextColumn>
            <dx:TreeListCommandColumn ButtonType="Image" VisibleIndex="16" Width="86px">
                <DeleteButton Visible="True">
                    <Image Url="~/images/geni/toolbox/remove2.png">
                    </Image>
                </DeleteButton>
                <CustomButtons>
                    <dx:TreeListCommandColumnCustomButton Text="Edit" ID="edit">
                        <Image Url="~/images/geni/toolbox/edit.png">
                        </Image>
                    </dx:TreeListCommandColumnCustomButton>
                    <dx:TreeListCommandColumnCustomButton Text="New" ID="new" Visibility="BrowsableNode">
                        <Image Url="~/images/geni/toolbox/add.png">
                        </Image>
                    </dx:TreeListCommandColumnCustomButton>
                    <dx:TreeListCommandColumnCustomButton Text="Languages" ID="lang" Visibility="BrowsableNode">
                        <Image Url="~/images/geni/toolbox/lang.png">
                        </Image>
                    </dx:TreeListCommandColumnCustomButton>
                </CustomButtons>
            </dx:TreeListCommandColumn>
            <dx:TreeListImageColumn Caption="<%$Resources:ContentManagement, MenuItemManagerIcon %>" FieldName="IconPath" VisibleIndex="7" Width="40px">
                <PropertiesImage ImageUrlFormatString="~/ContentData/Sites/Conferences/{0}" NullDisplayText="No Image">
                </PropertiesImage>
            </dx:TreeListImageColumn>
        </Columns>
        <SettingsBehavior AllowFocusedNode="True" />
        
        <SettingsEditing AllowNodeDragDrop="True" />
        <SettingsText ConfirmDelete="Are you sure you want to delete this record?" RecursiveDeleteError="This menu item has sub items" />
        <Styles>
            <AlternatingNode BackColor="#F3F9FD">
            </AlternatingNode>
        </Styles>
        <ClientSideEvents CustomButtonClick="function(s, e) {
	if(e.buttonID == 'edit'){
		window.location.href='Save?Code=' + e.nodeKey + '&menu=' + $.QueryString['Code'];
	}
    else if(e.buttonID == 'new'){
		window.location.href='Save?ParentID=' + e.nodeKey + '&menu=' + $.QueryString['Code'];
	}
    else if(e.buttonID == 'lang'){
            $('#myModal').modal({show: true});
            grid.PerformCallback(e.nodeKey);
    }
}" EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
    </dx:ASPxTreeList>
    <asp:ObjectDataSource ID="MenuEntityItemObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MenuEntityItemLogic" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_MenuEntityItemId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="MenuEntityParentId" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="PagePath" Type="String" />
            <asp:Parameter Name="ContentEntityId" Type="Int32" />
            <asp:Parameter Name="DisplayAlways" Type="Boolean" />
            <asp:Parameter Name="IsActive" Type="Boolean" />
            <asp:Parameter Name="IconPath" Type="String" />
            <asp:Parameter Name="DisplayOrder" Type="Int32" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="MenuEntityTypeId" Type="Int32" />
            <asp:Parameter Name="MenuEntityId" Type="Int32" />
            <asp:Parameter Name="LanguageID" Type="Int32" />
            <asp:Parameter Name="MenuEntityPositionID" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="MenuEntityId" QueryStringField="Code" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="MenuEntityParentId" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="PagePath" Type="String" />
            <asp:Parameter Name="ContentEntityId" Type="Int32" />
            <asp:Parameter Name="DisplayAlways" Type="Boolean" />
            <asp:Parameter Name="IsActive" Type="Boolean" />
            <asp:Parameter Name="IconPath" Type="String" />
            <asp:Parameter Name="DisplayOrder" Type="Int32" />
            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
            <asp:Parameter Name="MenuEntityTypeId" Type="Int32" />
            <asp:Parameter Name="MenuEntityId" Type="Int32" />
            <asp:Parameter Name="LanguageID" Type="Int32" />
            <asp:Parameter Name="MenuEntityPositionID" Type="Int32" />
            <asp:Parameter Name="Original_MenuEntityItemId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <!-- Button trigger modal -->


<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="myModalLabel"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MenuItemManagerLanguages %>"></asp:Literal></h4>
      </div>
      <div class="modal-body">
        <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="MenuEntityItemId" DataSourceID="SourcesObjectDS"  OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted" OnCustomCallback="grid_CustomCallback">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowNewButtonInHeader="True" ShowEditButton="true" ShowDeleteButton="true" VisibleIndex="0" Width="72px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="MenuEntityItemId" Visible="False" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" Caption="<%$Resources:ContentManagement, MenuItemManagerName %>" VisibleIndex="2" Width="200px">
                        <PropertiesTextEdit>
                            <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="ParentId" VisibleIndex="4" Visible="False">
                    </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MenuItemManagerLanguage %>" FieldName="LanguageID" VisibleIndex="3" Width="80px">
                <PropertiesComboBox DataSourceID="LanguageObjectDS" TextField="Name" ValueField="LanguageId">
                    <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
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
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MenuEntityItemLanguageLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_MenuEntityItemId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="LanguageID" Type="Int32" />
                    <asp:SessionParameter DefaultValue="0" Name="ParentId" SessionField="MenuLanguageParentID" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="ParentID" SessionField="MenuLanguageParentID" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="LanguageID" Type="Int32" />
                    <asp:SessionParameter DefaultValue="0" Name="ParentId" SessionField="MenuLanguageParentID" Type="Int32" />
                    <asp:Parameter Name="Original_MenuEntityItemId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
          <asp:ObjectDataSource ID="LanguageObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
            </asp:ObjectDataSource>
      </div>
      
    </div>
  </div>
</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
    <!-- Modal -->

</asp:Content>
