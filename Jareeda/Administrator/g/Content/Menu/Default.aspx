<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Content.Menu.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_MasterNew/styles/images/ribbon/menu.png" />
        </div>
        <div class="title-text"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MenuManagerTitle %>"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="MenuObjectDS" KeyFieldName="MenuEntityId" Width="100%" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="MenuEntityId" ReadOnly="True" ShowInCustomizationForm="False" Visible="False" VisibleIndex="1">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, MenuManagerName %>" FieldName="MenuName" VisibleIndex="2">
                <PropertiesTextEdit NullText="<%$Resources:ContentManagement, MenuManagerEnterTitle %>">
                    <ValidationSettings CausesValidation="True" Display="Dynamic">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <EditFormSettings ColumnSpan="2" />
                <DataItemTemplate>
                    <a href="<%# "Items?Code=" +  Eval("MenuEntityId") %>"><%# Eval("MenuName") %></a>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ContentEntityId" ShowInCustomizationForm="False" Visible="False" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, MenuManagerType %>" FieldName="DisplayType" VisibleIndex="4" Width="80px">
                <EditFormSettings ColumnSpan="2" />
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
        <Settings ShowFilterRow="True" />
        <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="MenuObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MenuEntityLogic" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_MenuEntityId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="MenuName" Type="String" />
            <asp:Parameter Name="ContentEntityId" Type="Int32" />
            <asp:Parameter Name="DisplayType" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="MenuName" Type="String" />
            <asp:Parameter Name="ContentEntityId" Type="Int32" />
            <asp:Parameter Name="DisplayType" Type="String" />
            <asp:Parameter Name="Original_MenuEntityId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
