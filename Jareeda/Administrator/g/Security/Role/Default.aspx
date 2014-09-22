<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Security.Role.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/groupmanager.png" />
        </div>
        <div class="title-text"><asp:Literal ID="AFTitle" runat="server" Text="Group Manager"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="dsRoles"
                    KeyFieldName="RoleId"  Width="100%" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="RoleId" ReadOnly="True" Visible="False" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None">
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="IsActive" VisibleIndex="3" Width="80px">
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn FieldName="RowGuid" Visible="False" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="ModifiedDate" Visible="False" VisibleIndex="5">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataCheckColumn FieldName="NewRecord" Visible="False" VisibleIndex="6">
                        </dx:GridViewDataCheckColumn>
        </Columns>
        <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
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
        <Templates>
                        <DetailRow>
                            <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="1">
                                <TabPages>
                                    <dx:TabPage Name="Persons" Text="Persons">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                <dx:ASPxGridView ID="gvPerson" runat="server" AutoGenerateColumns="False" DataSourceID="dsRolePersons"
                                                    KeyFieldName="PersonRoleId" Width="100%" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect" >
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn FieldName="PersonRoleId" ReadOnly="True" ShowInCustomizationForm="True"
                                                            Visible="False" VisibleIndex="0">
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="RoleId" ShowInCustomizationForm="True" Visible="False"
                                                            VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        

                                                        <dx:GridViewDataComboBoxColumn Caption="Person" FieldName="PersonId" 
                        VisibleIndex="1">
                        <PropertiesComboBox DataSourceID="dsPerson" TextField="DisplayName" ValueField="BusinessEntityId"></PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataDateColumn FieldName="ModifiedDate" ShowInCustomizationForm="True"
                                                            Visible="False" VisibleIndex="3">
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="NewRecord" ShowInCustomizationForm="True"
                                                            Visible="False" VisibleIndex="4">
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
                                                     <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                    <Settings ShowFilterRow="True" />
                    <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                                                </dx:ASPxGridView>
                                                <asp:ObjectDataSource ID="dsRolePersons" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.RoleSecurity.PersonRoleLogic"
                                                    UpdateMethod="Update">
                                                    <DeleteParameters>
                                                        <asp:Parameter Name="Original_PersonRoleId" Type="Int32" />
                                                    </DeleteParameters>
                                                    <InsertParameters>
                                                        <asp:SessionParameter Name="RoleId" SessionField="RoleID" Type="Int32" />
                                                        <asp:Parameter Name="PersonId" Type="Int32" />
                                                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                                                    </InsertParameters>
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="RoleID" SessionField="RoleID" Type="Int32" />
                                                    </SelectParameters>
                                                    <UpdateParameters>
                                                        <asp:SessionParameter Name="RoleId" SessionField="RoleID" Type="Int32" />
                                                        <asp:Parameter Name="PersonId" Type="Int32" />
                                                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                                                        <asp:Parameter Name="Original_PersonRoleId" Type="Int32" />
                                                    </UpdateParameters>
                                                </asp:ObjectDataSource>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Name="Role privilages" Text="Role Privilages">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                                <dx:ASPxGridView ID="gvRolePrivileges" runat="server" AutoGenerateColumns="False" DataSourceID="dsRolePrivileges"
                                                    KeyFieldName="RolePrivilegeId" Width="100%" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect">
                                                    <Columns>
                                                                     <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn FieldName="RolePrivilegeId" ReadOnly="True" ShowInCustomizationForm="True"
                                                            Visible="False" VisibleIndex="0">
                                                            <EditFormSettings Visible="False" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="RoleId" ShowInCustomizationForm="True" Visible="False"
                                                            VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="ContentEntityType" ShowInCustomizationForm="True"
                                                            Visible="False" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        
                                                         <dx:GridViewDataComboBoxColumn Caption="System Page" FieldName="ContentEntityId" 
                        VisibleIndex="4">
                        <PropertiesComboBox DataSourceID="dsSystemPage" TextField="Name" ValueField="SystemPageId"></PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                                                          <dx:GridViewDataComboBoxColumn Caption="System Function" FieldName="SystemFunctionId" 
                        VisibleIndex="4">
                        <PropertiesComboBox DataSourceID="dsSystemFunction" TextField="Name" ValueField="SystemFunctionId"></PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="HasAccess" ShowInCustomizationForm="True"
                                                            Visible="False" VisibleIndex="5">
                                                        </dx:GridViewDataCheckColumn>
                                                        <dx:GridViewDataDateColumn FieldName="ModifiedDate" ShowInCustomizationForm="True"
                                                            Visible="False" VisibleIndex="6">
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataCheckColumn FieldName="NewRecord" ShowInCustomizationForm="True"
                                                            Visible="False" VisibleIndex="7">
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
                                                     <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                    <Settings ShowFilterRow="True" />
                    <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                                                </dx:ASPxGridView>
                                                <asp:ObjectDataSource ID="dsRolePrivileges" runat="server" DeleteMethod="Delete"
                                                    InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                                    TypeName="BusinessLogicLayer.Components.RoleSecurity.RolePrivilegeLogic" UpdateMethod="Update">
                                                    <DeleteParameters>
                                                        <asp:Parameter Name="Original_RolePrivilegeId" Type="Int32" />
                                                    </DeleteParameters>
                                                    <InsertParameters>
                                                        <asp:SessionParameter Name="RoleId" SessionField="RoleID" Type="Int32" />
                                                        <asp:Parameter Name="ContentEntityId" Type="Int32" />
                                                        <asp:Parameter Name="SystemFunctionId" Type="Int32" />
                                                        <asp:Parameter Name="HasAccess" Type="Boolean" />
                                                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                                                    </InsertParameters>
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="RoleID" SessionField="RoleID" Type="Int32" />
                                                    </SelectParameters>
                                                    <UpdateParameters>
                                                        <asp:SessionParameter Name="RoleId" SessionField="RoleID" Type="Int32" />
                                                        <asp:Parameter Name="ContentEntityId" Type="Int32" />
                                                        <asp:Parameter Name="SystemFunctionId" Type="Int32" />
                                                        <asp:Parameter Name="HasAccess" Type="Boolean" />
                                                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                                                        <asp:Parameter Name="Original_RolePrivilegeId" Type="Int32" />
                                                    </UpdateParameters>
                                                </asp:ObjectDataSource>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                </TabPages>
                            </dx:ASPxPageControl>
                        </DetailRow>
                    </Templates>
    </dx:ASPxGridView>
     <asp:ObjectDataSource ID="dsSystemPage" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.ContentManagement.SystemPageLogic">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="False" Name="IsActive" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsSystemFunction" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.RoleSecurity.SystemFunctionLogic">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsPerson" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetAllCredentials" TypeName="BusinessLogicLayer.Components.Persons.PersonLogic">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsRoles" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.RoleSecurity.RoleLogic"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_RoleId" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="IsActive" Type="Boolean" />
                        <asp:Parameter DbType="Guid" Name="RowGuid" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="IsActive" Type="Boolean" />
                        <asp:Parameter DbType="Guid" Name="RowGuid" />
                        <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                        <asp:Parameter Name="Original_RoleId" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
