<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="Administrator.g.HR.Company.Employee.Save" %>
<%@ Register Src="~/Controls/EventoControls/ImageUpload.ascx" TagName="ImageUploadControl" TagPrefix="evento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Assets/css/jquery.Jcrop.min.css" rel="stylesheet" /> 
    <script src="/Assets/JS/jquery.Jcrop.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-5">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/pagestest.png" />
        </div>
        <div class="title-text">
            <asp:Literal runat="server" Text="<%$Resources:ContentManagement, HREmployeeTitle %>"></asp:Literal></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <ul>
            <li>
                <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:ContentManagement, Save %>" Font-Size="8pt" ImageSpacing="5px" OnClick="btnSave_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-apply.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnSaveandClose" runat="server" Text="<%$Resources:ContentManagement, SaveandClose %>" Font-Size="8pt" ImageSpacing="5px" OnClick="btnSaveandClose_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-save.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnSaveandNew" runat="server" Text="<%$Resources:ContentManagement, SaveandNew %>" Font-Size="8pt" ImageSpacing="5px" OnClick="SaveandNew_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-save-new.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnCancel" runat="server" Text="<%$Resources:ContentManagement, Cancel %>" Font-Size="8pt" ImageSpacing="5px" ValidationGroup="Cancel" OnClick="btnCancel_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-cancel.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="col-md-3 left-content">
        <div class="form">
            <div class="row geni-left-item">
                <div class="geni-label">
                    <asp:Literal runat="server" Text="<%$Resources:ContentManagement, HREmployeeName %>"></asp:Literal>
                </div>
                <div class="geni-edit">
                    <dx:ASPxTextBox runat="server" ID="miPersonName" Width="100%" Font-Size="18px" NullText="<%$Resources:ContentManagement, HREmployeeFullName %>"></dx:ASPxTextBox>
                </div>
            </div>
            <div class="row geni-left-item">
                <div class="geni-label">

                </div>
                <div class="geni-edit">
                    <evento:ImageUploadControl runat="server" ID="miPersonImage" />
                </div>
            </div>
            
        </div>
    </div>
    <div class="col-md-9">
        <div class="right-content">
            <div id="organizationRow" class="row geni-right-item">
            <span class="geni-label"><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, HREmployeeOrganization %>"></asp:Literal></span>
            <div class="geni-edit">
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
        <div id="departmentRow" class="row geni-right-item">
            <span class="geni-label"><asp:Literal ID="Literal3" runat="server" Text="<%$Resources:ContentManagement, HREmployeeDepartment %>"></asp:Literal></span>
            <div class="geni-edit">
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
        <div id="employeeNumberRow" class="row geni-right-item">
            <span class="geni-label"><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:ContentManagement, HREmployeeNumber %>"></asp:Literal></span>
            <div class="geni-edit">
                             <dx:ASPxTextBox ID="employeeNumber" runat="server" Font-Size="14px" Width="30%"  
                        ClientInstanceName="employeeNumber" ></dx:ASPxTextBox>
                        
            </div>
        </div>
        <div id="employeePositionRow" class="row geni-right-item">
            <span class="geni-label"><asp:Literal ID="Literal6" runat="server" Text="<%$Resources:ContentManagement, HREmployeePosition %>"></asp:Literal></span>
            <div class="geni-edit">
                             <dx:ASPxTextBox ID="employeePosition" runat="server" Font-Size="14px" Width="30%"  
                        ClientInstanceName="employeeNumber" ></dx:ASPxTextBox>
                        
            </div>
        </div>
        <div id="employeeBirthDateRow" class="row geni-right-item">
            <span class="geni-label"><asp:Literal ID="Literal4" runat="server" Text="<%$Resources:ContentManagement, HREmployeeBirthDate %>"></asp:Literal></span>
            <div class="geni-edit">
                             <dx:ASPxDateEdit ID="employeeBirthDate" runat="server" Font-Size="14px" Width="30%"  ></dx:ASPxDateEdit>
                        
            </div>
        </div>
        <div id="employeeHireDateRow" class="row geni-right-item">
            <span class="geni-label"><asp:Literal ID="Literal5" runat="server" Text="<%$Resources:ContentManagement, HREmployeeHireDate %>"></asp:Literal></span>
            <div class="geni-edit">
                             <dx:ASPxDateEdit ID="employeeHireDate" runat="server" Font-Size="14px" Width="30%"  ></dx:ASPxDateEdit>
                        
            </div>
        </div>
        <div id="employeeemail" class="row geni-right-item">
            <span class="geni-label"><asp:Literal ID="Literal7" runat="server" Text="<%$Resources:ContentManagement, HREmployeeEmail %>"></asp:Literal></span>
            <div class="geni-edit">
                             <dx:ASPxTextBox ID="employeeEmail" runat="server" Font-Size="14px" Width="40%"  ></dx:ASPxTextBox>
                        
            </div>
        </div>
        <div id="employeecredential" class="row">
            <span class="geni-label"><asp:Literal ID="Literal8" runat="server" Text="<%$Resources:ContentManagement, HREmployeeUserName %>"></asp:Literal></span>
            <div class="geni-edit">
                             <dx:ASPxTextBox ID="employeeCredential" AutoCompleteType="None" runat="server" Font-Size="14px" Width="40%"  ></dx:ASPxTextBox>
                        
            </div>
        </div>
        <div id="employeecredential2" class="row geni-right-item">
            <span class="geni-label"><asp:Literal ID="Literal9" runat="server" Text="<%$Resources:ContentManagement, HREmployeePassword %>"></asp:Literal></span>
            <div class="geni-edit">
                             <dx:ASPxTextBox ID="employeePassword" runat="server" AutoCompleteType="None" Font-Size="14px" Width="40%" Password="True"  ></dx:ASPxTextBox>
                        
            </div>
        </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
