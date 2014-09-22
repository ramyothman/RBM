<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Content.Email.Template.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/emailtemplate.png" />
        </div>
        <div class="title-text">
            <asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, ManageEmailTemplates %>"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="window.location.href='Save';"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="dsEmailTemplates" 
                        KeyFieldName="EmailTemplateID" Width="100%" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}"
            CustomButtonClick="function(s, e) {
	window.location.href ='Save.aspx?ID=' + s.GetRowKey(s.GetFocusedRowIndex());
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
            <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="EmailTemplateID" ReadOnly="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Name" Caption="Name" VisibleIndex="3">
                <DataItemTemplate>
                            <a href="<%# String.Format("Save?ID={0}", Eval("EmailTemplateID")) %>"><%# Eval("Name") %></a>
                        </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="SystemEmailTypeID" Caption="Template Type" VisibleIndex="4" Width="80px">
                <PropertiesComboBox DataSourceID="dsTemplateType" TextField="Name" ValueField="SystemEmailTypeID"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="ConferenceID" Caption="conference Name" VisibleIndex="5" Width="80px">
                <PropertiesComboBox DataSourceID="dsconference" TextField="ConferenceName" ValueField="ConferenceId"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="LanguageID" Caption="Language" VisibleIndex="6" Width="80px">
                <PropertiesComboBox DataSourceID="dsLang" TextField="Name" ValueField="LanguageId"></PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>

            <dx:GridViewDataTextColumn FieldName="Description"
                Visible="False" VisibleIndex="7">
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn FieldName="EmailContent" VisibleIndex="8" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="NewRecord" Visible="False"
                VisibleIndex="9">
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
    <asp:ObjectDataSource ID="dsTemplateType" runat="server"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
        TypeName="BusinessLogicLayer.Components.Conference.SystemEmailTypeLogic"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="dsEmailTemplates" runat="server"
        DeleteMethod="Delete" InsertMethod="Insert"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
        TypeName="BusinessLogicLayer.Components.Conference.EmailTemplateLogic"
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_EmailTemplateID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="SystemEmailTypeID" Type="Int32" />
            <asp:Parameter Name="ConferenceID" Type="Int32" />
            <asp:Parameter Name="LanguageID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="EmailContent" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="SystemEmailTypeID" Type="Int32" />
            <asp:Parameter Name="ConferenceID" Type="Int32" />
            <asp:Parameter Name="LanguageID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="EmailContent" Type="String" />
            <asp:Parameter Name="Original_EmailTemplateID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsconference" runat="server"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
        TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsLang" runat="server"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
        TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
