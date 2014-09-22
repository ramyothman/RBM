<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Content.Page.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         var textSeparator = ";";
         function OnListBoxSelectionChanged(listBox, args) {
             if (args.index == 0)
                 args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
             UpdateSelectAllItemState();
             UpdateText();
         }
         function UpdateSelectAllItemState() {
             IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
         }
         function IsAllSelected() {
             for (var i = 1; i < checkListBox.GetItemCount() ; i++)
                 if (!checkListBox.GetItem(i).selected)
                     return false;
             return true;
         }
         function UpdateText() {
             var selectedItems = checkListBox.GetSelectedItems();
             checkComboBox.SetText(GetSelectedItemsText(selectedItems));
         }
         function SynchronizeListBoxValues(dropDown, args) {
             checkListBox.UnselectAll();
             var texts = dropDown.GetText().split(textSeparator);
             var values = GetValuesByTexts(texts);
             checkListBox.SelectValues(values);
             UpdateSelectAllItemState();
             UpdateText();  // for remove non-existing texts
         }
         function GetSelectedItemsText(items) {
             var texts = [];
             for (var i = 0; i < items.length; i++)
                 if (items[i].index != 0)
                     texts.push(items[i].text);
             return texts.join(textSeparator);
         }
         function GetValuesByTexts(texts) {
             var actualValues = [];
             var item;
             for (var i = 0; i < texts.length; i++) {
                 item = checkListBox.FindItemByText(texts[i]);
                 if (item != null)
                     actualValues.push(item.value);
             }
             return actualValues;
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/pagestest.png" />
        </div>
        <div class="title-text"><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, MSPTitle %>"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="window.location.href='Save?PageCode=0';"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="SitePagesObjectDS" KeyFieldName="SitePageId"  Width="100%" oncelleditorinitialize="SitePageGrid_CellEditorInitialize" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" CustomButtonClick="function(s, e) {
	window.location.href ='Save.aspx?PageCode=' + s.GetRowKey(s.GetFocusedRowIndex());
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" VisibleIndex="0" Width="76px" ButtonType="Image">
                
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton Text="Edit">
                        <Image Url="~/images/geni/toolbox/edit.png">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
                
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="SitePageId" 
                        ReadOnly="True" VisibleIndex="1" Caption="<%$Resources:ContentManagement, MSPId %>" Width="50px" ShowInCustomizationForm="False" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, MSPName %>" FieldName="PageName" VisibleIndex="2">
                        <DataItemTemplate>
                            <a href="<%# String.Format("Save?PageCode={0}", Eval("SitePageId")) %>"><%# Eval("PageName") %></a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MSPSite %>" FieldName="SiteId" VisibleIndex="3" Width="120px">
                        <PropertiesComboBox DataSourceID="SiteObjectDS" TextField="Name" 
                            ValueField="SiteId" ValueType="System.Int32">
                             <ClientSideEvents SelectedIndexChanged="function(s, e) { OnSiteChanged(s); }"></ClientSideEvents>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MSPSection %>" FieldName="SectionId" 
                        VisibleIndex="4" Width="120px">
                        <PropertiesComboBox DataSourceID="SectionObjectDS" 
                            IncrementalFilteringMode="Contains" TextField="Name" ValueField="SiteSectionId" 
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MSPStatus %>" FieldName="PageStatusId" 
                        VisibleIndex="5" Width="80px">
                        <PropertiesComboBox DataSourceID="StatusObjectDS" TextField="Name" 
                            ValueField="PageStatusId" ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MSPSecurityAccess %>" 
                        FieldName="SecurityAccessTypeId" VisibleIndex="6" Width="80px">
                        <PropertiesComboBox DataSourceID="SecurityAccessObjectDS" TextField="Name" 
                            ValueField="SecurityAccessTypeId" ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, MSPCreator %>" FieldName="CreatorId" 
                        VisibleIndex="7" Width="80px">
                        <PropertiesComboBox DataSourceID="PersonObjectDS" TextField="UserName" 
                            ValueField="BusinessEntityId" ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="UniquePageName" VisibleIndex="8" 
                        Caption="Uni. Page Name" Visible="False" Width="80px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="IsMainPage" Caption="<%$Resources:ContentManagement, MSPMainPage %>" VisibleIndex="9" 
                        Width="60px">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataTextColumn FieldName="RowGuid" VisibleIndex="10" Visible="False" ShowInCustomizationForm="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="RevisionDate" VisibleIndex="11" 
                        Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ModifiedDate" Caption="<%$Resources:ContentManagement, MSPModifiedDate %>" VisibleIndex="12" Width="80px">
                    </dx:GridViewDataDateColumn>
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
            <UpdateButton Text="Save" ButtonType="Link">
            </UpdateButton>
            <CancelButton Text="Cancel" ButtonType="Link">
            </CancelButton>
            <ApplyFilterButton ButtonType="Link">

            </ApplyFilterButton>
            <ClearFilterButton ButtonType="Link"></ClearFilterButton>
            
        </SettingsCommandButton>
        <SettingsBehavior ConfirmDelete="True" />
        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
        <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="SitePagesObjectDS" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteId" 
                    TypeName="BusinessLogicLayer.Components.ContentManagement.SitePageLogic" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_SitePageId" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="SitePageId" Type="Int32" />
                        <asp:Parameter Name="SectionId" Type="Int32" />
                        <asp:Parameter Name="PageStatusId" Type="Int32" />
                        <asp:Parameter Name="SecurityAccessTypeId" Type="Int32" />
                        <asp:Parameter Name="CreatorId" Type="Int32" />
                        <asp:Parameter Name="UniquePageName" Type="String" />
                        <asp:Parameter Name="IsMainPage" Type="Boolean" />
                        <asp:Parameter DbType="Guid" Name="RowGuid" />
                        <asp:Parameter Name="RevisionDate" Type="DateTime" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                        <asp:Parameter Name="SiteId" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="SiteId" 
                            SessionField="CurrentWorkingSite" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SitePageId" Type="Int32" />
                        <asp:Parameter Name="SectionId" Type="Int32" />
                        <asp:Parameter Name="PageStatusId" Type="Int32" />
                        <asp:Parameter Name="SecurityAccessTypeId" Type="Int32" />
                        <asp:Parameter Name="CreatorId" Type="Int32" />
                        <asp:Parameter Name="UniquePageName" Type="String" />
                        <asp:Parameter Name="IsMainPage" Type="Boolean" />
                        <asp:Parameter DbType="Guid" Name="RowGuid" />
                        <asp:Parameter Name="RevisionDate" Type="DateTime" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                        <asp:Parameter Name="SiteId" Type="Int32" />
                        <asp:Parameter Name="Original_SitePageId" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                
                <asp:ObjectDataSource ID="SiteObjectDS" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="SectionObjectDS" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteId" 
                    TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic">
                    <SelectParameters>
                        <asp:Parameter Name="SiteId" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                
                <asp:ObjectDataSource ID="StatusObjectDS" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.ContentManagement.PageStatusLogic">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="SecurityAccessObjectDS" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.RoleSecurity.SecurityAccessTypeLogic">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="PersonObjectDS" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.Persons.PersonLogic">
                </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
