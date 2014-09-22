<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.HumanResources.Departments.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, HRDepartmentsTitle %>"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
       

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
     <dx:ASPxGridView ID="DepartmentGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="DepartmentId"
                Width="100%" DataSourceID="DSAirLine" >
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
                    <dx:GridViewDataTextColumn FieldName="DepartmentId" ReadOnly="True" VisibleIndex="1" Caption="Id" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Organization" FieldName="OrganizationId" VisibleIndex="4" Width="80px">
                        <propertiescombobox datasourceid="OrganizationObjectDS" textfield="OrganizationName" valuefield="OrganizationId" valuetype="System.Int32">
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiescombobox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Department" FieldName="DepartmentName" VisibleIndex="2">
                        <propertiestextedit>
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiestextedit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DepartmentDescription" VisibleIndex="3" Caption="Description">
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="Phone1" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone2" Visible="False" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Fax1" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Fax2" Visible="False" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine1" Visible="False" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine2" Visible="False" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="<%$Resources:ContentManagement, FormDeleteMsg %>" PopupEditFormCaption="<%$Resources:ContentManagement, FormEditForm %>" CommandUpdate="<%$Resources:ContentManagement, FormUpdate %>"  CommandCancel="<%$Resources:ContentManagement, FormCancel %>"  />
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="DepartmentLanguagesId"
                Width="100%" DataSourceID="DepartmentLangDS" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect" >
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
                    <dx:GridViewDataTextColumn FieldName="DepartmentLanguagesId" VisibleIndex="1" Caption="Id" ReadOnly="True" Width="50px">
                        <editformsettings visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DepartmentId" VisibleIndex="2" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageId" VisibleIndex="3" Width="80px">
                        <propertiescombobox datasourceid="LanguageObjectDS" textfield="Name" valuefield="LanguageId" valuetype="System.Int32">
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiescombobox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Department" FieldName="DepartmentName" VisibleIndex="4">
                        <propertiestextedit>
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiestextedit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DepartmentDescription" VisibleIndex="5" Caption="Description">
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="AddressLine1" VisibleIndex="6" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine2" Visible="False" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="<%$Resources:ContentManagement, FormDeleteMsg %>" PopupEditFormCaption="<%$Resources:ContentManagement, FormEditForm %>" CommandUpdate="<%$Resources:ContentManagement, FormUpdate %>"  CommandCancel="<%$Resources:ContentManagement, FormCancel %>"  />
                
            </dx:ASPxGridView>
                        <asp:ObjectDataSource ID="DepartmentLangDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByDepartmentId" TypeName="BusinessLogicLayer.Components.HumanResources.DepartmentLanguagesLogic" UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_DepartmentLanguagesId" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:SessionParameter DefaultValue="0" Name="DepartmentId" SessionField="DepartmentId" Type="Int32" />
                                <asp:Parameter Name="LanguageId" Type="Int32" />
                                <asp:Parameter Name="DepartmentName" Type="String" />
                                <asp:Parameter Name="DepartmentDescription" Type="String" />
                                <asp:Parameter Name="AddressLine1" Type="String" />
                                <asp:Parameter Name="AddressLine2" Type="String" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="DepartmentId" SessionField="DepartmentId" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:SessionParameter DefaultValue="0" Name="DepartmentId" SessionField="DepartmentId" Type="Int32" />
                                <asp:Parameter Name="LanguageId" Type="Int32" />
                                <asp:Parameter Name="DepartmentName" Type="String" />
                                <asp:Parameter Name="DepartmentDescription" Type="String" />
                                <asp:Parameter Name="AddressLine1" Type="String" />
                                <asp:Parameter Name="AddressLine2" Type="String" />
                                <asp:Parameter Name="Original_DepartmentLanguagesId" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </DetailRow>
                </Templates>

            </dx:ASPxGridView>

    
                    <asp:ObjectDataSource ID="LanguageObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_LanguageId" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="LanguageCode" Type="String" />
                            <asp:Parameter Name="Name" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="LanguageCode" Type="String" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Original_LanguageId" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="OrganizationObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.HumanResources.OrganizationsLogic"></asp:ObjectDataSource>
     <asp:ObjectDataSource ID="DSAirLine" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.HumanResources.DepartmentsLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_DepartmentId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="OrganizationId" Type="Int32" />
                    <asp:Parameter Name="DepartmentName" Type="String" />
                    <asp:Parameter Name="DepartmentDescription" Type="String" />
                    <asp:Parameter Name="Phone1" Type="String" />
                    <asp:Parameter Name="Phone2" Type="String" />
                    <asp:Parameter Name="Fax1" Type="String" />
                    <asp:Parameter Name="Fax2" Type="String" />
                    <asp:Parameter Name="AddressLine1" Type="String" />
                    <asp:Parameter Name="AddressLine2" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="OrganizationId" Type="Int32" />
                    <asp:Parameter Name="DepartmentName" Type="String" />
                    <asp:Parameter Name="DepartmentDescription" Type="String" />
                    <asp:Parameter Name="Phone1" Type="String" />
                    <asp:Parameter Name="Phone2" Type="String" />
                    <asp:Parameter Name="Fax1" Type="String" />
                    <asp:Parameter Name="Fax2" Type="String" />
                    <asp:Parameter Name="AddressLine1" Type="String" />
                    <asp:Parameter Name="AddressLine2" Type="String" />
                    <asp:Parameter Name="Original_DepartmentId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>

    
</asp:Content>
