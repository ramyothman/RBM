<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Content.ApprovalFlow.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/approval.png" />
        </div>
        <div class="title-text">
            <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, AFTitleMain %>"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal> </div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="ApprovalFlowID"
        Width="100%" DataSourceID="SourcesObjectDS" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ApprovalFlowID" Visible="false" ReadOnly="True" VisibleIndex="1" Caption="Id">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, AFSection %>" FieldName="SectionID" VisibleIndex="2">
                <PropertiesComboBox DataSourceID="SectionDS" TextField="Name" ValueField="SiteSectionId" ValueType="System.Int32">
                    <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>

            <dx:GridViewDataTextColumn FieldName="Title" Caption="<%$Resources:ContentManagement, AFTitle %>" VisibleIndex="3" Width="120px">
                <PropertiesTextEdit>
                    <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DateStart" Caption="<%$Resources:ContentManagement, AFDateStart %>" VisibleIndex="4">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="DateEnd" Caption="<%$Resources:ContentManagement, AFDateEnd %>" VisibleIndex="5">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="ApprovedBy" Caption="<%$Resources:ContentManagement, AFApprovedBy %>" VisibleIndex="6" Visible="False">
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
        <settingsdetail allowonlyonemasterrowexpanded="True" showdetailrow="True" />
        <Templates>
            <DetailRow>
                <dx:ASPxGridView ID="OfferFlowDetailGrid" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" KeyFieldName="ApprovalFlowDetailID" Width="100%" OnBeforePerformDataSelect="OfferFlowDetailGrid_BeforePerformDataSelect">
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="true"  VisibleIndex="0" Width="76px">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="ID" Visible="false" FieldName="ApprovalFlowDetailID" ReadOnly="True" VisibleIndex="1" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ApprovalFlowID" Visible="False" VisibleIndex="2" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="OrderNumber" Caption="<%$Resources:ContentManagement, AFOrderNumber %>" VisibleIndex="3" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, AFStatus %>" FieldName="ArticleStatusID" VisibleIndex="4" ShowInCustomizationForm="True">
                            <PropertiesComboBox DataSourceID="statusObjectDS" TextField="Name" ValueField="ArticleStatusId" ValueType="System.Int32"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, AFUser %>" FieldName="UserID" VisibleIndex="5" ShowInCustomizationForm="True">
                            <PropertiesComboBox DataSourceID="usersObjectDS" TextField="DisplayName" ValueField="BusinessEntityId" ValueType="System.Int32"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="StatusDurationInHours" VisibleIndex="6" Caption="<%$Resources:ContentManagement, AFStatusDurationInHours %>" ShowInCustomizationForm="True">
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
                    <SettingsEditing Mode="PopupEditForm" />
                    <SettingsBehavior ConfirmDelete="True" />
                    <Settings ShowFilterRow="True" />
                    <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
                </dx:ASPxGridView>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByApprovalFlowID" TypeName="BusinessLogicLayer.Components.ContentManagement.ApprovalFlowDetailLogic" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ApprovalFlowDetailID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ApprovalFlowDetailID" Type="Int32" />
                        <asp:SessionParameter DefaultValue="0" Name="ApprovalFlowID" SessionField="ApprovalFlowID" Type="Int32" />
                        <asp:Parameter Name="OrderNumber" Type="Int32" />
                        <asp:Parameter Name="ArticleStatusID" Type="Int32" />
                        <asp:Parameter Name="UserID" Type="Int32" />
                        <asp:Parameter Name="StatusDurationInHours" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="ApprovalFlowID" SessionField="ApprovalFlowID" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ApprovalFlowDetailID" Type="Int32" />
                        <asp:SessionParameter DefaultValue="0" Name="ApprovalFlowID" SessionField="ApprovalFlowID" Type="Int32" />
                        <asp:Parameter Name="OrderNumber" Type="Int32" />
                        <asp:Parameter Name="ArticleStatusID" Type="Int32" />
                        <asp:Parameter Name="UserID" Type="Int32" />
                        <asp:Parameter Name="StatusDurationInHours" Type="Int32" />
                        <asp:Parameter Name="Original_ApprovalFlowDetailID" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </DetailRow>
        </Templates>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="statusObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleStatusLogic"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="usersObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Persons.PersonLogic"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SourcesObjectDS"  runat="server" DeleteMethod="Delete" InsertMethod="Insert"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ApprovalFlowLogic"
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_ApprovalFlowID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="SectionID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="DateStart" Type="DateTime" />
            <asp:Parameter Name="DateEnd" Type="DateTime" />
            <asp:Parameter Name="ApprovedBy" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="SectionID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="DateStart" Type="DateTime" />
            <asp:Parameter Name="DateEnd" Type="DateTime" />
            <asp:Parameter Name="ApprovedBy" Type="Int32" />
            <asp:Parameter Name="Original_ApprovalFlowID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SectionDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic"></asp:ObjectDataSource>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
