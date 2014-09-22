<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.HR.Company.Division.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/divisions.png" />
        </div>
        <div class="title-text"><asp:Literal ID="AFTitle" runat="server" Text="Manage Divisions"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="DivisionId"
                Width="100%" DataSourceID="DSAirLine"  OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="DivisionId" ReadOnly="True" VisibleIndex="1" Caption="Id" Width="50px" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                     <dx:GridViewDataComboBoxColumn Caption="Department" FieldName="DepartmentId" VisibleIndex="2" Width="120px">
                         <propertiescombobox datasourceid="DepartmentOBjectDS" textfield="DepartmentName" valuefield="DepartmentId" valuetype="System.Int32">
<validationsettings causesvalidation="True" Display="Dynamic" ErrorDisplayMode="None">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiescombobox>
                     </dx:GridViewDataComboBoxColumn>
                    
                    <dx:GridViewDataTextColumn Caption="Division" FieldName="DivisionName" VisibleIndex="3">
                        <propertiestextedit>
<validationsettings Display="Dynamic" ErrorDisplayMode="None">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiestextedit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Description" FieldName="DivisionDescription" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone1" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone2" Visible="False" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Fax1" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Fax2" Visible="False" VisibleIndex="8">
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
    <asp:ObjectDataSource ID="DSAirLine" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.HumanResources.DivisionsLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_DivisionId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="DepartmentId" Type="Int32" />
                    <asp:Parameter Name="DivisionName" Type="String" />
                    <asp:Parameter Name="DivisionDescription" Type="String" />
                    <asp:Parameter Name="Phone1" Type="String" />
                    <asp:Parameter Name="Phone2" Type="String" />
                    <asp:Parameter Name="Fax1" Type="String" />
                    <asp:Parameter Name="Fax2" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="DepartmentId" Type="Int32" />
                    <asp:Parameter Name="DivisionName" Type="String" />
                    <asp:Parameter Name="DivisionDescription" Type="String" />
                    <asp:Parameter Name="Phone1" Type="String" />
                    <asp:Parameter Name="Phone2" Type="String" />
                    <asp:Parameter Name="Fax1" Type="String" />
                    <asp:Parameter Name="Fax2" Type="String" />
                    <asp:Parameter Name="Original_DivisionId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="DepartmentOBjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.HumanResources.DepartmentsLogic"></asp:ObjectDataSource>
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
