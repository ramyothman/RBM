<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.HR.Company.Employee.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/employees.png" />
        </div>
        <div class="title-text"><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, HRMTitle %>"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="window.location.href='Save?Code=0';"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="DSAirLine" KeyFieldName="EmployeeId"  Width="100%"  OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
        <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" CustomButtonClick="function(s, e) {
	window.location.href ='Save.aspx?Code=' + s.GetRowKey(s.GetFocusedRowIndex());
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
            <dx:GridViewDataTextColumn FieldName="EmployeeId" ReadOnly="True" VisibleIndex="0" Caption="<%$Resources:ContentManagement, HRMEmployeeID %>" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DisplayName" VisibleIndex="2" Caption="<%$Resources:ContentManagement, HRMDisplayName %>" ReadOnly="True" Width="250px">
                        <DataItemTemplate>
                            <a href="<%# String.Format("Save?Code={0}", Eval("EmployeeId")) %>"><%# Eval("DisplayName") %></a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HRMuser %>" FieldName="UserName" ReadOnly="True" VisibleIndex="3" Width="150px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HRMDepartment %>" FieldName="DepartmentName" ReadOnly="True" VisibleIndex="5" Width="150px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HRMOrganization %>" FieldName="OrganizationName" ReadOnly="True" VisibleIndex="4" Width="150px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HRMDivision %>" FieldName="DivisionName" ReadOnly="True" VisibleIndex="6" Width="150px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn Caption="<%$ Resources:ContentManagement, HRMImage %>" FieldName="EmployeeImage" ReadOnly="True" VisibleIndex="17">
                        <PropertiesImage ImageUrlFormatString="~/ContentData/Sites/Conferences/{0}" ImageHeight="50px">
                        </PropertiesImage>
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HRMCode %>" FieldName="EmployeeNumber" VisibleIndex="1">
                        <DataItemTemplate>
                            <a href="<%# String.Format("Save?Code={0}", Eval("EmployeeId")) %>"><%# Eval("EmployeeNumber") %></a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="FormalSiteUrl" Visible="False" VisibleIndex="18">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BirthDate" Visible="False" VisibleIndex="10">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="MaritalStatus" Visible="false" VisibleIndex="14">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Gender" Visible="false" VisibleIndex="15">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="HireDate" Visible="false" VisibleIndex="16">
                    </dx:GridViewDataDateColumn>
                    
                    <dx:GridViewDataCheckColumn FieldName="SalariedFlag" VisibleIndex="19" Visible="False">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataTextColumn FieldName="VacationHours" Visible="False" VisibleIndex="20">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SickLeaveHours" Visible="False" VisibleIndex="23">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="ModifiedDate" Visible="False" VisibleIndex="24">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="Position" Caption="<%$Resources:ContentManagement, HRMPosition %>" VisibleIndex="7" Width="150px">
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
    <asp:ObjectDataSource ID="DSAirLine" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllView" TypeName="BusinessLogicLayer.Components.HumanResources.EmployeesLogic" DeleteMethod="Delete">
                <DeleteParameters>
                    <asp:Parameter Name="Original_EmployeeId" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="2" Name="LanguageID" SessionField="EmpLanguageID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
