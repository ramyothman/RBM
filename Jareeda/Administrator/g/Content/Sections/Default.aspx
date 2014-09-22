<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Sections.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_MasterNew/styles/images/ribbon/sections.png" />
        </div>
        <div class="title-text"><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, SSTitle %>"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
     <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="SiteSectionObjectDS" KeyFieldName="SiteSectionId" Width="100%" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="SiteSectionId"  Visible="false" ShowInCustomizationForm="false"
                        ReadOnly="True" VisibleIndex="1" Caption="<%$Resources:ContentManagement, SSId %>" Width="50px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" Caption="<%$Resources:ContentManagement, SSName %>" VisibleIndex="2" Width="200px">
                        <PropertiesTextEdit>
                            <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesTextEdit>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Alias" Caption="<%$Resources:ContentManagement, SSAlias %>" VisibleIndex="3" Width="200px">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, SSSectionParent %>" 
                        FieldName="SiteSectionParentId" VisibleIndex="4">
                        <PropertiesComboBox DataSourceID="SiteSectionObjectDS" TextField="Name" 
                            ValueField="SiteSectionId" ValueType="System.Int32">
                            <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, SSSectionStatus %>" 
                        FieldName="SectionStatusId" VisibleIndex="5">
                        <PropertiesComboBox DataSourceID="SectionStatusObjectDS" TextField="Name" 
                            ValueField="SiteSectionStatusId" ValueType="System.Int32">
                            <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, SSSite %>" FieldName="SiteId" 
                        VisibleIndex="6">
                        <PropertiesComboBox DataSourceID="SiteObjectDS" TextField="Name" 
                            ValueField="SiteId" ValueType="System.Int32">
                            <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, SSPerson %>" FieldName="PersonId" 
                        VisibleIndex="7">
                        <PropertiesComboBox DataSourceID="PersonObjectDS" TextField="FullName" 
                            ValueField="BusinessEntityId" ValueType="System.Int32">
                        </PropertiesComboBox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, SSSecurityAccess %>" 
                        FieldName="SecurityAccessTypeId" VisibleIndex="8">
                        <PropertiesComboBox DataSourceID="SecurityAccessObjectDS" TextField="Name" 
                            ValueField="SecurityAccessTypeId" ValueType="System.Int32">
                            <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </PropertiesComboBox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="RowGuid" VisibleIndex="9" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="ModifiedDate" VisibleIndex="10" Caption="<%$Resources:ContentManagement, SSModifiedDate %>">
                        <EditFormSettings Visible="False" />
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
            <UpdateButton Text="<%$Resources:ContentManagement, GridSave %>">
            </UpdateButton>
            <CancelButton Text="<%$Resources:ContentManagement, GridCancel %>">
            </CancelButton>

        </SettingsCommandButton>
        <SettingsBehavior ConfirmDelete="True" />
        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
        <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
    </dx:ASPxGridView>
        <asp:ObjectDataSource ID="SiteSectionObjectDS" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteId" 
                    TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_SiteSectionId" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="SiteSectionId" Type="Int32" />
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="SiteSectionParentId" Type="Int32" />
                        <asp:Parameter Name="SectionStatusId" Type="Int32" />
                        <asp:Parameter Name="SiteId" Type="Int32" />
                        <asp:Parameter Name="PersonId" Type="Int32" />
                        <asp:Parameter Name="SecurityAccessTypeId" Type="Int32" />
                        <asp:Parameter DbType="Guid" Name="RowGuid" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                        <asp:Parameter Name="Alias" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="SiteId" 
                            SessionField="CurrentWorkingSite" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SiteSectionId" Type="Int32" />
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="SiteSectionParentId" Type="Int32" />
                        <asp:Parameter Name="SectionStatusId" Type="Int32" />
                        <asp:Parameter Name="SiteId" Type="Int32" />
                        <asp:Parameter Name="PersonId" Type="Int32" />
                        <asp:Parameter Name="SecurityAccessTypeId" Type="Int32" />
                        <asp:Parameter DbType="Guid" Name="RowGuid" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                        <asp:Parameter Name="Alias" Type="String" />
                        <asp:Parameter Name="Original_SiteSectionId" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="SecurityAccessObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.RoleSecurity.SecurityAccessTypeLogic">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="SiteObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="SectionStatusObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionStatusLogic">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="PersonObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.Persons.PersonLogic">
                    </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
