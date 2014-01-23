<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.HumanResources.Employees.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="g12 widgets">
			<div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
				<span class="handle"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, HRMTitle %>"></asp:Literal>
                     <span style="float:right;margin-right:5px;margin-left:5px;">
                    <dx:ASPxButton ID="btnAddNew" runat="server" Text="<%$Resources:ContentManagement, AddNew %>" 
                        onclick="btnAddNew_Click" >
                    </dx:ASPxButton>
                </span>
				</h3>
				<div class="inner-content">
            <dx:ASPxGridView ID="EmployeeGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="EmployeeId"
                Width="100%" DataSourceID="DSAirLine" >
                 <ClientSideEvents CustomButtonClick="function(s, e) {
	window.location.href ='Save.aspx?Code=' + s.GetRowKey(s.GetFocusedRowIndex());
}" />
                <Columns>
        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        <EditButton>
                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                            </Image>
                        </EditButton>
                        <NewButton>
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
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton Text="Edit">
                                <Image AlternateText="Edit" Height="16px" Url="~/images/editgrid.png" 
                                    Width="16px">
                                </Image>
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="EmployeeId" ReadOnly="True" VisibleIndex="0" Caption="<%$Resources:ContentManagement, HRMEmployeeID %>">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DisplayName" VisibleIndex="2" Caption="<%$Resources:ContentManagement, HRMDisplayName %>" ReadOnly="True" Width="250px">
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
                        <PropertiesImage ImageUrlFormatString="~/ContentData/Sites/Conferences/{0}" ImageWidth="150px">
                        </PropertiesImage>
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HRMCode %>" FieldName="EmployeeNumber" VisibleIndex="1">
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
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>
            </div>

            <asp:ObjectDataSource ID="DSAirLine" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllView" TypeName="BusinessLogicLayer.Components.HumanResources.EmployeesLogic" DeleteMethod="Delete">
                <DeleteParameters>
                    <asp:Parameter Name="Original_EmployeeId" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="2" Name="LanguageID" SessionField="EmpLanguageID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
                </div>
         </div>
</asp:Content>
