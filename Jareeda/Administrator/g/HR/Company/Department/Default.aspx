<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.HR.Company.Department.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/positions.png" />
        </div>
        <div class="title-text"><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, HRDepartmentsTitle %>"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" KeyFieldName="DepartmentId"
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
            <dx:GridViewDataTextColumn FieldName="DepartmentId" ReadOnly="True" VisibleIndex="1" Caption="Id" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Organization" FieldName="OrganizationId" VisibleIndex="4" Width="80px">
                        <propertiescombobox datasourceid="OrganizationObjectDS" textfield="OrganizationName" valuefield="OrganizationId" valuetype="System.Int32">
<validationsettings causesvalidation="True" ErrorDisplayMode="None">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiescombobox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Department" FieldName="DepartmentName" VisibleIndex="2">
                        <propertiestextedit>
<validationsettings causesvalidation="True" Display="Dynamic" ErrorDisplayMode="None">
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
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="DepartmentLanguagesId"
                Width="100%" DataSourceID="DepartmentLangDS" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect" >
                <Columns>
                     <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px">
            </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="DepartmentLanguagesId" Visible="false" VisibleIndex="1" Caption="Id" ReadOnly="True" Width="50px">
                        <editformsettings visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DepartmentId" VisibleIndex="2" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageId" VisibleIndex="3" Width="80px">
                        <propertiescombobox datasourceid="LanguageObjectDS" textfield="Name" valuefield="LanguageId" valuetype="System.Int32">
<validationsettings causesvalidation="True" ErrorDisplayMode="None">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiescombobox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="Department" FieldName="DepartmentName" VisibleIndex="4">
                        <propertiestextedit>
<validationsettings causesvalidation="True" ErrorDisplayMode="None">
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
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
