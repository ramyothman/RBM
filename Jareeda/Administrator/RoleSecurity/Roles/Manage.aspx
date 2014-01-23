<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.RoleSecurity.Roles.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
     <div class="g12 widgets">
        <div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
            <h3 class="handle">                
                Manage Roles</h3>
            <div class="inner-content">
                <dx:ASPxGridView ID="gvRoles" runat="server" AutoGenerateColumns="False" DataSourceID="dsRoles"
                    KeyFieldName="RoleId" Width="70%">
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
                        <dx:GridViewDataTextColumn FieldName="RoleId" ReadOnly="True" Visible="False" VisibleIndex="0">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="IsActive" VisibleIndex="2">
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn FieldName="RowGuid" Visible="False" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="ModifiedDate" Visible="False" VisibleIndex="4">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataCheckColumn FieldName="NewRecord" Visible="False" VisibleIndex="5">
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                    <Settings ShowFilterRow="True" />
                    <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
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
            </div>
        </div>
    </div>
</asp:Content>
