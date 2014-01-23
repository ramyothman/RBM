<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMainFull.master" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="Administrator.HumanResources.Employees.Save" %>
<%@ Register Src="~/Controls/EventoControls/ImageUpload.ascx" TagName="ImageUploadControl" TagPrefix="evento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../_Scripts/jquery.Jcrop.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
     <div style="width:18%;float:left;"><h1><asp:Literal runat="server" Text="<%$Resources:ContentManagement, HREmployeeTitle %>"></asp:Literal> </h1></div>
    <div style="float:left;margin-top:12px;width:40%;" class="TopInformation"><dx:ASPxTextBox runat="server" ID="miPersonName" Width="100%" Font-Size="18px" NullText="<%$Resources:ContentManagement, HREmployeeFullName %>"></dx:ASPxTextBox></div>
    
    <div class="toolbar">
        <ul>
            
            <li>
                <asp:Button runat="server" ID="btnSave" CssClass="button-link icon-32-apply" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);"  Text="<%$Resources:ContentManagement, Save %>" OnClick="btnSave_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="btnSaveandClose" CssClass="button-link icon-32-save" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);" Text="<%$Resources:ContentManagement, SaveandClose %>" OnClick="btnSaveandClose_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="SaveandNew" CssClass="button-link icon-32-save-new" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);" Text="<%$Resources:ContentManagement, SaveandNew %>" OnClick="SaveandNew_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="btnCancel" CssClass="button-link icon-32-cancel" Text="<%$Resources:ContentManagement, Cancel %>" OnClick="btnCancel_Click"/>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
    <div class="admin-form">
        
         <div id="ImageRow" class="row">
            
            <div class="editor">
                <evento:ImageUploadControl runat="server" ID="miPersonImage" />
                <%--<dx:ASPxImage runat="server" ID="miPersonPhoto" Width="100%" EmptyImage-Url="~/images/no-frame-person.png"></dx:ASPxImage>--%>
                </div>
            </div>

        
        <%--<div id="nationalTypeRow" class="row">
            <span class="label"><asp:Literal ID="Literal4" runat="server" Text="<%$Resources:ContentManagement, HREmployeeNationalTypeID %>"></asp:Literal></span>
            <div class="editor">
                <dx:ASPxComboBox ID="employeeNationalIDType" runat="server" 
                        DataSourceID="employeeNationalIDTypeObjectDS" TextField="OrganizationName" ValueField="OrganizationId" Width="100%" Font-Size="14px"  
                        ValueType="System.Int32">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	employeeDepartment.PerformCallback(s.GetValue());
}" />
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="employeeNationalIDTypeObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.HumanResources.OrganizationsLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>--%>
         </div>
    <div id="MenuRow" class="row" style="margin-left:10px;">
        <div class="editor">
            <dx:ASPxNavBar Visible="false" ID="ProfileNavigation" runat="server" Width="95%">
                <Groups>
                    <dx:NavBarGroup Name="ProfileMenu" Text="Information">
                        <Items>
                            <dx:NavBarItem Name="General" Text="General Information" ToolTip="General Information">
                            </dx:NavBarItem>
                            <dx:NavBarItem Text="Credentials">
                            </dx:NavBarItem>
                        </Items>
                    </dx:NavBarGroup>
                </Groups>
            </dx:ASPxNavBar>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div class="admin-form">
        <div id="organizationRow" class="row">
            <span class="label"><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, HREmployeeOrganization %>"></asp:Literal></span>
            <div class="editor">
                <dx:ASPxComboBox ID="employeeOrganization" runat="server" 
                        DataSourceID="PageContentObjectDS" TextField="OrganizationName" ValueField="OrganizationId" Width="30%" Font-Size="14px"  
                        ValueType="System.Int32">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	employeeDepartment.PerformCallback(s.GetValue());
}" />
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="PageContentObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.HumanResources.OrganizationsLogic">
                    </asp:ObjectDataSource>
            </div>
        </div>
        <div id="departmentRow" class="row">
            <span class="label"><asp:Literal ID="Literal3" runat="server" Text="<%$Resources:ContentManagement, HREmployeeDepartment %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxComboBox ID="employeeDepartment" runat="server" Font-Size="14px" Width="30%"  
                        ClientInstanceName="employeeDepartment" DataSourceID="SectionObjectDS" 
                        oncallback="employeeDepartment_Callback" TextField="DepartmentName" ValueField="DepartmentId" 
                        ValueType="System.Int32">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="None" ErrorTextPosition="Bottom">
                            <RequiredField ErrorText="* Please Select Department" IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxComboBox>
                    <asp:ObjectDataSource ID="SectionObjectDS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByOrganizationId" 
                        TypeName="BusinessLogicLayer.Components.HumanResources.DepartmentsLogic">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="OrganizationId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
            </div>
        </div>
        <div id="employeeNumberRow" class="row">
            <span class="label"><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:ContentManagement, HREmployeeNumber %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxTextBox ID="employeeNumber" runat="server" Font-Size="14px" Width="30%"  
                        ClientInstanceName="employeeNumber" ></dx:ASPxTextBox>
                        
            </div>
        </div>
        <div id="employeePositionRow" class="row">
            <span class="label"><asp:Literal ID="Literal6" runat="server" Text="<%$Resources:ContentManagement, HREmployeePosition %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxTextBox ID="employeePosition" runat="server" Font-Size="14px" Width="30%"  
                        ClientInstanceName="employeeNumber" ></dx:ASPxTextBox>
                        
            </div>
        </div>
        <div id="employeeBirthDateRow" class="row">
            <span class="label"><asp:Literal ID="Literal4" runat="server" Text="<%$Resources:ContentManagement, HREmployeeBirthDate %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxDateEdit ID="employeeBirthDate" runat="server" Font-Size="14px" Width="30%"  ></dx:ASPxDateEdit>
                        
            </div>
        </div>
        <div id="employeeHireDateRow" class="row">
            <span class="label"><asp:Literal ID="Literal5" runat="server" Text="<%$Resources:ContentManagement, HREmployeeHireDate %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxDateEdit ID="employeeHireDate" runat="server" Font-Size="14px" Width="30%"  ></dx:ASPxDateEdit>
                        
            </div>
        </div>
        <div id="employeeemail" class="row">
            <span class="label"><asp:Literal ID="Literal7" runat="server" Text="<%$Resources:ContentManagement, HREmployeeEmail %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxTextBox ID="employeeEmail" runat="server" Font-Size="14px" Width="40%"  ></dx:ASPxTextBox>
                        
            </div>
        </div>
        <div id="employeeusername" class="row">
            <span class="label"><asp:Literal ID="Literal8" runat="server" Text="<%$Resources:ContentManagement, HREmployeeUserName %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxTextBox ID="employeeUserName" runat="server" Font-Size="14px" Width="40%"  ></dx:ASPxTextBox>
                        
            </div>
        </div>
        <div id="employeepassword" class="row">
            <span class="label"><asp:Literal ID="Literal9" runat="server" Text="<%$Resources:ContentManagement, HREmployeePassword %>"></asp:Literal></span>
            <div class="editor">
                             <dx:ASPxTextBox ID="employeePassword" runat="server" Font-Size="14px" Width="40%" Password="True"  ></dx:ASPxTextBox>
                        
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
