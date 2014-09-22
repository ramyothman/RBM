<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.FormManager.Forms.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/fieldtype.png" />
        </div>
        <div class="title-text"><asp:Literal ID="AFTitle" runat="server" Text="Manage Forms"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" Width="100%" DataSourceID="FormsObjectDS" KeyFieldName="FormDocumentID"  OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
             <dx:GridViewDataTextColumn Caption="Id" FieldName="FormDocumentID"  Visible="false"
                ReadOnly="True" VisibleIndex="1" Width="50px">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="View" FieldName="FormDocumentID" 
                ReadOnly="True" VisibleIndex="2" Width="50px">
                <EditFormSettings Visible="False" />
                <DataItemTemplate>
                    <a id="A1" target="_blank" runat="server" href='<%# "../View.aspx?code=" + Eval("FormDocumentID") %>'><img id="Img1" src="~/Builder/FormBuilder/images/download.png" alt="Download Excel" runat="server" /> </a>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Status" 
                FieldName="FormDocumentStatusID" VisibleIndex="3" Width="50px">
                <PropertiesComboBox DataSourceID="StatusObjectDS" TextField="StatusName" 
                    ValueField="FormDocumentStatusID" ValueType="System.Int32">
                    <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="4" Width="200px">
                <PropertiesTextEdit>
                    <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
                <EditFormSettings ColumnSpan="2" />
                <DataItemTemplate>
                    <a href='../Builder?code=<%# Eval("FormDocumentID") %>'><%# Eval("Title") %></a>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Description" Visible="False" 
                VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="StartDate" VisibleIndex="6">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="EndDate" VisibleIndex="7">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="ConfirmationText" Visible="False" 
                VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CreatorID" VisibleIndex="9" 
                Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="CreationDate" VisibleIndex="10" 
                Visible="False">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataCheckColumn FieldName="SendEmail" Visible="False" 
                VisibleIndex="11">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="SendSMS" Visible="False" 
                VisibleIndex="12">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AllowModify" VisibleIndex="13" 
                Visible="False">
            </dx:GridViewDataCheckColumn>
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
    <asp:ObjectDataSource ID="FormsObjectDS" runat="server" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAll" 
        TypeName="BusinessLogicLayer.Components.FormBuilder.FormDocumentLogic" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_FormDocumentID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FormDocumentStatusID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="ConfirmationText" Type="String" />
            <asp:SessionParameter Name="CreatorID" SessionField="MFCreatorID" 
                Type="Int32" />
            <asp:SessionParameter Name="CreationDate" SessionField="MFCreationDate" 
                Type="DateTime" />
            <asp:Parameter Name="SendEmail" Type="Boolean" />
            <asp:Parameter Name="SendSMS" Type="Boolean" />
            <asp:Parameter Name="AllowModify" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FormDocumentStatusID" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="StartDate" Type="DateTime" />
            <asp:Parameter Name="EndDate" Type="DateTime" />
            <asp:Parameter Name="ConfirmationText" Type="String" />
            <asp:Parameter Name="CreatorID" Type="Int32" />
            <asp:Parameter Name="CreationDate" Type="DateTime" />
            <asp:Parameter Name="SendEmail" Type="Boolean" />
            <asp:Parameter Name="SendSMS" Type="Boolean" />
            <asp:Parameter Name="AllowModify" Type="Boolean" />
            <asp:Parameter Name="Original_FormDocumentID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="StatusObjectDS" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
        TypeName="BusinessLogicLayer.Components.FormBuilder.FormDocumentStatusLogic">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="QualityGroupObjectDS" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="ViewQualityGroup" 
        TypeName="BusinessLogicLayer.Components.QualityGroupLogic">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="FormGroupsObjectDS" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAllByFormDocumentId" 
        TypeName="BusinessLogicLayer.Components.FormQualityGroupLogic" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_FormQualityGroupId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter DefaultValue="0" Name="FormDocumentId" 
                SessionField="FormBuilderDocumentId" Type="Int32" />
            <asp:Parameter Name="QualityGroupId" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="FormDocumentId" 
                SessionField="FormBuilderDocumentId" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter DefaultValue="0" Name="FormDocumentId" 
                SessionField="FormBuilderDocumentId" Type="Int32" />
            <asp:Parameter Name="QualityGroupId" Type="Int32" />
            <asp:Parameter Name="Original_FormQualityGroupId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
           
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
