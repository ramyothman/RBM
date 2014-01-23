<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMainFull.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Administrator.Person.View" %>
<%@ Register Src="~/Controls/EventoControls/ImageUpload.ascx" TagName="ImageUploadControl" TagPrefix="evento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <%--<script src="../_Scripts/jquery.Jcrop.js"></script>--%>
    <script src="../_Scripts/jquery.Jcrop.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width:18%;float:left;"><h1>Person: </h1></div>
    <div style="float:left;margin-top:12px;width:40%;" class="TopInformation"><dx:ASPxTextBox runat="server" ID="miPersonName" Width="100%" Font-Size="18px" NullText="Person Name"></dx:ASPxTextBox></div>
    
    <div class="toolbar">
        <ul>
            
            <li>
                <asp:Button runat="server" ID="btnSave" CssClass="button-link icon-32-apply" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);"  Text="Save" OnClick="btnSave_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="btnSaveandClose" CssClass="button-link icon-32-save" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);" Text="Save & Close" OnClick="btnSaveandClose_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="SaveandNew" CssClass="button-link icon-32-save-new" OnClientClick="return ASPxClientEdit.ValidateGroup('', false);" Text="Save & New" OnClick="SaveandNew_Click"/>
            </li>
            <li>
                <asp:Button runat="server" ID="btnCancel" CssClass="button-link icon-32-cancel" Text="Cancel" OnClick="btnCancel_Click"/>
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
         </div>
    <div id="MenuRow" class="row" style="margin-left:10px;">
        <div class="editor">
            <dx:ASPxNavBar ID="ProfileNavigation" runat="server" Width="95%">
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

    <div class="admin-form-main">
        <h1>Organization</h1>
        <br />
                <div id="organizationName" class="row margin-seperator">
                    <div class="label-col">Name:</div>
                    <div class="editor-col">
                        <dx:ASPxTextBox ID="OrganizationName" runat="server" Width="250px" Font-Size="16px"></dx:ASPxTextBox>
                        </div>
                    </div>
        <div id="organizationDepartment" class="row margin-seperator">
                    <div class="label-col">Department:</div>
                    <div class="editor-col">
                        <dx:ASPxTextBox ID="OrganizationDepartment" runat="server" Width="250px" Font-Size="16px"></dx:ASPxTextBox>
                        </div>
                    </div>
        <div id="organizationAddress" class="row margin-seperator">
                    <div class="label-col">Address:</div>
                    <div class="editor-col">
                        <dx:ASPxTextBox ID="OrganizationAddress" runat="server" Width="250px" Font-Size="16px"></dx:ASPxTextBox>
                        </div>
                    </div>
        </div>
    <br />
     <div class="admin-form-main">
        <h1>Extra Information</h1>
        <br />
         <dx:ASPxPageControl ID="extraInfoPageControl" runat="server" ActiveTabIndex="0" Width="100%">
             <TabPages>
                 <dx:TabPage Name="Registration" Text="Registrations">
                     <ContentCollection>
                         <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                             <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="RegistrationsObjectDS" KeyFieldName="ConferenceRegistererId" Width="100%">
                                 <Columns>
                                     <dx:GridViewDataTextColumn Caption="Id" FieldName="ConferenceRegistererId" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="0" Width="40px">
                                         <EditFormSettings Visible="False" />
                                     </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn Caption="Conference" FieldName="ConferenceId" ShowInCustomizationForm="True" VisibleIndex="2">
                                     </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataDateColumn FieldName="DateRegistered" ShowInCustomizationForm="True" VisibleIndex="1" Width="50px">
                                     </dx:GridViewDataDateColumn>
                                     <dx:GridViewDataTextColumn FieldName="DiscountAmount" ShowInCustomizationForm="True" VisibleIndex="6" Width="60px">
                                     </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn FieldName="AmountPaid" ShowInCustomizationForm="True" VisibleIndex="5" Width="60px">
                                     </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn FieldName="RegitrationCategory" ShowInCustomizationForm="True" VisibleIndex="3" Width="120px">
                                     </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn Caption="Reg. Type" FieldName="ConferenceRegistrationTypeId" ShowInCustomizationForm="True" VisibleIndex="4" Width="80px">
                                     </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataCheckColumn FieldName="IsActive" ShowInCustomizationForm="True" VisibleIndex="72" Width="60px">
                                     </dx:GridViewDataCheckColumn>
                                 </Columns>
                             </dx:ASPxGridView>
                             <asp:ObjectDataSource ID="RegistrationsObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Conference.ConferenceRegisterationsLogic" UpdateMethod="Update">
                                 <DeleteParameters>
                                     <asp:Parameter Name="Original_ConferenceRegistererId" Type="Int32" />
                                 </DeleteParameters>
                                 <InsertParameters>
                                     <asp:Parameter Name="SponsorId" Type="Int32" />
                                     <asp:Parameter Name="PersonId" Type="Int32" />
                                     <asp:Parameter Name="ConferenceId" Type="Int32" />
                                     <asp:Parameter Name="DateRegistered" Type="DateTime" />
                                     <asp:Parameter Name="DiscountAmount" Type="Decimal" />
                                     <asp:Parameter Name="AmountPaid" Type="Decimal" />
                                     <asp:Parameter Name="DiscountReason" Type="String" />
                                     <asp:Parameter Name="RegitrationCategory" Type="String" />
                                     <asp:Parameter Name="LicenseNumber" Type="String" />
                                     <asp:Parameter Name="Address" Type="String" />
                                     <asp:Parameter Name="POBox" Type="String" />
                                     <asp:Parameter Name="ZipCode" Type="String" />
                                     <asp:Parameter Name="City" Type="String" />
                                     <asp:Parameter Name="Country" Type="String" />
                                     <asp:Parameter Name="PhoneNumberCountryCode" Type="String" />
                                     <asp:Parameter Name="PhoneNumberAreaCode" Type="String" />
                                     <asp:Parameter Name="PhoneNumber" Type="String" />
                                     <asp:Parameter Name="FaxNumberCountryCode" Type="String" />
                                     <asp:Parameter Name="FaxNumberAreaCode" Type="String" />
                                     <asp:Parameter Name="FaxNumber" Type="String" />
                                     <asp:Parameter Name="MobileNumberCountryCode" Type="String" />
                                     <asp:Parameter Name="MobileNumberAreaCode" Type="String" />
                                     <asp:Parameter Name="MobileNumber" Type="String" />
                                     <asp:Parameter Name="Email" Type="String" />
                                     <asp:Parameter Name="AcademicInformationPosition" Type="String" />
                                     <asp:Parameter Name="AcademicInformationDegree" Type="String" />
                                     <asp:Parameter Name="AcademicInformationHealthCarePro" Type="Boolean" />
                                     <asp:Parameter Name="AcademicInformationHealthCareProValue" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteName" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteDepartment" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteAddress" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteZipCode" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteCity" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteCountry" Type="String" />
                                     <asp:Parameter Name="HospitalInstitutePOBox" Type="String" />
                                     <asp:Parameter Name="ConferenceRegistrationTypeId" Type="Int32" />
                                     <asp:Parameter Name="PreConferenceWorkShopIncluded" Type="Boolean" />
                                     <asp:Parameter Name="SubscribeToNewsLetter" Type="Boolean" />
                                     <asp:Parameter Name="AOAAdministrator" Type="Boolean" />
                                     <asp:Parameter Name="AOARetired" Type="Boolean" />
                                     <asp:Parameter Name="AOAClinicalResearcher" Type="Boolean" />
                                     <asp:Parameter Name="AOABasicResearcher" Type="Boolean" />
                                     <asp:Parameter Name="AOATeacherEducator" Type="Boolean" />
                                     <asp:Parameter Name="AOAIndustryRepresentative" Type="Boolean" />
                                     <asp:Parameter Name="AOAClinicalPractitioner" Type="Boolean" />
                                     <asp:Parameter Name="AOAAlliedHealthProfessional" Type="Boolean" />
                                     <asp:Parameter Name="AOAStudent" Type="Boolean" />
                                     <asp:Parameter Name="AOAOther" Type="Boolean" />
                                     <asp:Parameter Name="AOAOtherText" Type="String" />
                                     <asp:Parameter Name="AOAMCNAcuteKidneyInjury" Type="Boolean" />
                                     <asp:Parameter Name="AOAMCNChronicKidneyDisease" Type="Boolean" />
                                     <asp:Parameter Name="AOAMCNHypertension" Type="Boolean" />
                                     <asp:Parameter Name="AOAMCNGlomerulonephritis" Type="Boolean" />
                                     <asp:Parameter Name="AOAMCNNephrolithiasis" Type="Boolean" />
                                     <asp:Parameter Name="AOAMRRTHemodialysis" Type="Boolean" />
                                     <asp:Parameter Name="AOAMRRTPertionealDialysis" Type="Boolean" />
                                     <asp:Parameter Name="AOAMRRTCRRT" Type="Boolean" />
                                     <asp:Parameter Name="AOAMPediatricNephrology" Type="Boolean" />
                                     <asp:Parameter Name="AOAMGenetics" Type="Boolean" />
                                     <asp:Parameter Name="AOAMUrology" Type="Boolean" />
                                     <asp:Parameter Name="AOAMMineralMetabolism" Type="Boolean" />
                                     <asp:Parameter Name="AOAMAnemia" Type="Boolean" />
                                     <asp:Parameter Name="AOAMDiabetes" Type="Boolean" />
                                     <asp:Parameter Name="AOAMImmunology" Type="Boolean" />
                                     <asp:Parameter Name="AOAMPathology" Type="Boolean" />
                                     <asp:Parameter Name="AOAMIterventionalCCN" Type="Boolean" />
                                     <asp:Parameter Name="AOAMOther" Type="Boolean" />
                                     <asp:Parameter Name="AOAMOtherText" Type="String" />
                                     <asp:Parameter Name="SponsorName" Type="String" />
                                     <asp:Parameter Name="DeductedAmount" Type="Decimal" />
                                     <asp:Parameter Name="IsActive" Type="Boolean" />
                                     <asp:Parameter Name="IsMember" Type="Boolean" />
                                     <asp:Parameter Name="IsSelfSponsor" Type="Boolean" />
                                 </InsertParameters>
                                 <UpdateParameters>
                                     <asp:Parameter Name="SponsorId" Type="Int32" />
                                     <asp:Parameter Name="PersonId" Type="Int32" />
                                     <asp:Parameter Name="ConferenceId" Type="Int32" />
                                     <asp:Parameter Name="DateRegistered" Type="DateTime" />
                                     <asp:Parameter Name="DiscountAmount" Type="Decimal" />
                                     <asp:Parameter Name="AmountPaid" Type="Decimal" />
                                     <asp:Parameter Name="DiscountReason" Type="String" />
                                     <asp:Parameter Name="RegitrationCategory" Type="String" />
                                     <asp:Parameter Name="LicenseNumber" Type="String" />
                                     <asp:Parameter Name="Address" Type="String" />
                                     <asp:Parameter Name="POBox" Type="String" />
                                     <asp:Parameter Name="ZipCode" Type="String" />
                                     <asp:Parameter Name="City" Type="String" />
                                     <asp:Parameter Name="Country" Type="String" />
                                     <asp:Parameter Name="PhoneNumberCountryCode" Type="String" />
                                     <asp:Parameter Name="PhoneNumberAreaCode" Type="String" />
                                     <asp:Parameter Name="PhoneNumber" Type="String" />
                                     <asp:Parameter Name="FaxNumberCountryCode" Type="String" />
                                     <asp:Parameter Name="FaxNumberAreaCode" Type="String" />
                                     <asp:Parameter Name="FaxNumber" Type="String" />
                                     <asp:Parameter Name="MobileNumberCountryCode" Type="String" />
                                     <asp:Parameter Name="MobileNumberAreaCode" Type="String" />
                                     <asp:Parameter Name="MobileNumber" Type="String" />
                                     <asp:Parameter Name="Email" Type="String" />
                                     <asp:Parameter Name="AcademicInformationPosition" Type="String" />
                                     <asp:Parameter Name="AcademicInformationDegree" Type="String" />
                                     <asp:Parameter Name="AcademicInformationHealthCarePro" Type="Boolean" />
                                     <asp:Parameter Name="AcademicInformationHealthCareProValue" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteName" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteDepartment" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteAddress" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteZipCode" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteCity" Type="String" />
                                     <asp:Parameter Name="HospitalInstituteCountry" Type="String" />
                                     <asp:Parameter Name="HospitalInstitutePOBox" Type="String" />
                                     <asp:Parameter Name="ConferenceRegistrationTypeId" Type="Int32" />
                                     <asp:Parameter Name="PreConferenceWorkShopIncluded" Type="Boolean" />
                                     <asp:Parameter Name="SubscribeToNewsLetter" Type="Boolean" />
                                     <asp:Parameter Name="AOAAdministrator" Type="Boolean" />
                                     <asp:Parameter Name="AOARetired" Type="Boolean" />
                                     <asp:Parameter Name="AOAClinicalResearcher" Type="Boolean" />
                                     <asp:Parameter Name="AOABasicResearcher" Type="Boolean" />
                                     <asp:Parameter Name="AOATeacherEducator" Type="Boolean" />
                                     <asp:Parameter Name="AOAIndustryRepresentative" Type="Boolean" />
                                     <asp:Parameter Name="AOAClinicalPractitioner" Type="Boolean" />
                                     <asp:Parameter Name="AOAAlliedHealthProfessional" Type="Boolean" />
                                     <asp:Parameter Name="AOAStudent" Type="Boolean" />
                                     <asp:Parameter Name="AOAOther" Type="Boolean" />
                                     <asp:Parameter Name="AOAOtherText" Type="String" />
                                     <asp:Parameter Name="AOAMCNAcuteKidneyInjury" Type="Boolean" />
                                     <asp:Parameter Name="AOAMCNChronicKidneyDisease" Type="Boolean" />
                                     <asp:Parameter Name="AOAMCNHypertension" Type="Boolean" />
                                     <asp:Parameter Name="AOAMCNGlomerulonephritis" Type="Boolean" />
                                     <asp:Parameter Name="AOAMCNNephrolithiasis" Type="Boolean" />
                                     <asp:Parameter Name="AOAMRRTHemodialysis" Type="Boolean" />
                                     <asp:Parameter Name="AOAMRRTPertionealDialysis" Type="Boolean" />
                                     <asp:Parameter Name="AOAMRRTCRRT" Type="Boolean" />
                                     <asp:Parameter Name="AOAMPediatricNephrology" Type="Boolean" />
                                     <asp:Parameter Name="AOAMGenetics" Type="Boolean" />
                                     <asp:Parameter Name="AOAMUrology" Type="Boolean" />
                                     <asp:Parameter Name="AOAMMineralMetabolism" Type="Boolean" />
                                     <asp:Parameter Name="AOAMAnemia" Type="Boolean" />
                                     <asp:Parameter Name="AOAMDiabetes" Type="Boolean" />
                                     <asp:Parameter Name="AOAMImmunology" Type="Boolean" />
                                     <asp:Parameter Name="AOAMPathology" Type="Boolean" />
                                     <asp:Parameter Name="AOAMIterventionalCCN" Type="Boolean" />
                                     <asp:Parameter Name="AOAMOther" Type="Boolean" />
                                     <asp:Parameter Name="AOAMOtherText" Type="String" />
                                     <asp:Parameter Name="SponsorName" Type="String" />
                                     <asp:Parameter Name="DeductedAmount" Type="Decimal" />
                                     <asp:Parameter Name="IsActive" Type="Boolean" />
                                     <asp:Parameter Name="IsMember" Type="Boolean" />
                                     <asp:Parameter Name="IsSelfSponsor" Type="Boolean" />
                                     <asp:Parameter Name="Original_ConferenceRegistererId" Type="Int32" />
                                 </UpdateParameters>
                             </asp:ObjectDataSource>
                         </dx:ContentControl>
                     </ContentCollection>
                 </dx:TabPage>
                 <dx:TabPage Name="Abstract" Text="Abstracts">
                     <ContentCollection>
                         <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                         </dx:ContentControl>
                     </ContentCollection>
                 </dx:TabPage>
                 <dx:TabPage Name="Membership" Text="Memberships">
                     <ContentCollection>
                         <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                         </dx:ContentControl>
                     </ContentCollection>
                 </dx:TabPage>
             </TabPages>
         </dx:ASPxPageControl>
         </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
