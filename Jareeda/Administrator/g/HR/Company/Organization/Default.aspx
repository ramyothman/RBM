<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.HR.Company.Organization.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/positions.png" />
        </div>
        <div class="title-text"><asp:Literal ID="AFTitle" runat="server" Text="Manage Organizations"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="OrganizationId"
                Width="100%" DataSourceID="ObjectDS"   OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="OrganizationId" ReadOnly="True" VisibleIndex="1" Caption="Id" Width="50px" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="OrganizationName" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="OrganizationDescription" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone1" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone2" VisibleIndex="5" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone3" VisibleIndex="6" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Fax1" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    
                    
                    <dx:GridViewDataTextColumn FieldName="Fax2" VisibleIndex="8" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine1" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine2" VisibleIndex="10">
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
        <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
        <SettingsBehavior ConfirmDelete="True" />
        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
        <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
        <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="OrganizationLanguagesGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="OrganizationLanguagesId"
                Width="100%" DataSourceID="DSAirLine" OnBeforePerformDataSelect="OrganizationLanguagesGrid_BeforePerformDataSelect" >
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
                    <dx:GridViewDataTextColumn FieldName="OrganizationLanguagesId" ReadOnly="True" VisibleIndex="0" Caption="Id">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="OrganizationId" VisibleIndex="1" Visible="False">
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageId" VisibleIndex="2">
                        <propertiescombobox datasourceid="LanguagesObjectDS" textfield="Name" valuefield="LanguageId" valuetype="System.Int32"></propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="OrganizationName" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="OrganizationDescription" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine1" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine2" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.HumanResources.OrganizationsLogic" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_OrganizationId" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="OrganizationName" Type="String" />
                            <asp:Parameter Name="OrganizationDescription" Type="String" />
                            <asp:Parameter Name="Phone1" Type="String" />
                            <asp:Parameter Name="Phone2" Type="String" />
                            <asp:Parameter Name="Phone3" Type="String" />
                            <asp:Parameter Name="Fax1" Type="String" />
                            <asp:Parameter Name="Fax2" Type="String" />
                            <asp:Parameter Name="AddressLine1" Type="String" />
                            <asp:Parameter Name="AddressLine2" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="OrganizationName" Type="String" />
                            <asp:Parameter Name="OrganizationDescription" Type="String" />
                            <asp:Parameter Name="Phone1" Type="String" />
                            <asp:Parameter Name="Phone2" Type="String" />
                            <asp:Parameter Name="Phone3" Type="String" />
                            <asp:Parameter Name="Fax1" Type="String" />
                            <asp:Parameter Name="Fax2" Type="String" />
                            <asp:Parameter Name="AddressLine1" Type="String" />
                            <asp:Parameter Name="AddressLine2" Type="String" />
                            <asp:Parameter Name="Original_OrganizationId" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>

      <asp:ObjectDataSource ID="DSAirLine" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByOrganizationId" TypeName="BusinessLogicLayer.Components.HumanResources.OrganizationLanguagesLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_OrganizationLanguagesId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:SessionParameter DefaultValue="0" Name="OrganizationId" SessionField="OrganizationId" Type="Int32" />
                    <asp:Parameter Name="LanguageId" Type="Int32" />
                    <asp:Parameter Name="OrganizationName" Type="String" />
                    <asp:Parameter Name="OrganizationDescription" Type="String" />
                    <asp:Parameter Name="AddressLine1" Type="String" />
                    <asp:Parameter Name="AddressLine2" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="OrganizationId" SessionField="OrganizationId" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:SessionParameter DefaultValue="0" Name="OrganizationId" SessionField="OrganizationId" Type="Int32" />
                    <asp:Parameter Name="LanguageId" Type="Int32" />
                    <asp:Parameter Name="OrganizationName" Type="String" />
                    <asp:Parameter Name="OrganizationDescription" Type="String" />
                    <asp:Parameter Name="AddressLine1" Type="String" />
                    <asp:Parameter Name="AddressLine2" Type="String" />
                    <asp:Parameter Name="Original_OrganizationLanguagesId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>

    
            
    <asp:ObjectDataSource ID="LanguagesObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
