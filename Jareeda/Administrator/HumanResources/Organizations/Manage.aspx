<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.HumanResources.Organizations.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
     <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="Manage Organizations"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
        <ul>
            <li>
            </li>
        </ul>

    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="OrganizationGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="OrganizationId"
                Width="100%" DataSourceID="ObjectDS" >
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
                    <dx:GridViewDataTextColumn FieldName="OrganizationId" ReadOnly="True" VisibleIndex="1" Caption="Id" Width="50px" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="OrganizationName" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="OrganizationDescription" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone1" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone2" VisibleIndex="5" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Phone3" VisibleIndex="6" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Fax1" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    
                    
                    <dx:GridViewDataTextColumn FieldName="Fax2" VisibleIndex="8" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine1" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine2" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    
                    
                </Columns>
                <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" PopupEditFormCaption="Save Organization" />
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="OrganizationLanguagesGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="OrganizationLanguagesId"
                Width="100%" DataSourceID="DSAirLine" OnBeforePerformDataSelect="OrganizationLanguagesGrid_BeforePerformDataSelect" >
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
                    <dx:GridViewDataTextColumn FieldName="OrganizationLanguagesId" ReadOnly="True" VisibleIndex="0" Caption="Id">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="OrganizationId" VisibleIndex="1" Visible="False">
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageId" VisibleIndex="2">
                        <propertiescombobox datasourceid="LanguagesObjectDS" textfield="Name" valuefield="LanguageId" valuetype="System.Int32"></propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="OrganizationName" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="OrganizationDescription" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine1" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AddressLine2" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
    <asp:ObjectDataSource ID="ObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.HumanResources.OrganizationsLogic" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_OrganizationId" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="OrganizationName" Type="String" />
                            <asp:Parameter Name="OrganizationDescription" Type="String" />
                            <asp:Parameter Name="Phone1" Type="String" />
                            <asp:Parameter Name="Phone2" Type="String" />
                            <asp:Parameter Name="Phone3" Type="String" />
                            <asp:Parameter Name="Fax1" Type="String" />
                            <asp:Parameter Name="Fax2" Type="String" />
                            <asp:Parameter Name="AddressLine1" Type="String" />
                            <asp:Parameter Name="AddressLine2" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="OrganizationName" Type="String" />
                            <asp:Parameter Name="OrganizationDescription" Type="String" />
                            <asp:Parameter Name="Phone1" Type="String" />
                            <asp:Parameter Name="Phone2" Type="String" />
                            <asp:Parameter Name="Phone3" Type="String" />
                            <asp:Parameter Name="Fax1" Type="String" />
                            <asp:Parameter Name="Fax2" Type="String" />
                            <asp:Parameter Name="AddressLine1" Type="String" />
                            <asp:Parameter Name="AddressLine2" Type="String" />
                            <asp:Parameter Name="Original_OrganizationId" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>

      <asp:ObjectDataSource ID="DSAirLine" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByOrganizationId" TypeName="BusinessLogicLayer.Components.HumanResources.OrganizationLanguagesLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_OrganizationLanguagesId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:SessionParameter DefaultValue="0" Name="OrganizationId" SessionField="OrganizationId" Type="Int32" />
                    <asp:Parameter Name="LanguageId" Type="Int32" />
                    <asp:Parameter Name="OrganizationName" Type="String" />
                    <asp:Parameter Name="OrganizationDescription" Type="String" />
                    <asp:Parameter Name="AddressLine1" Type="String" />
                    <asp:Parameter Name="AddressLine2" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="OrganizationId" SessionField="OrganizationId" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:SessionParameter DefaultValue="0" Name="OrganizationId" SessionField="OrganizationId" Type="Int32" />
                    <asp:Parameter Name="LanguageId" Type="Int32" />
                    <asp:Parameter Name="OrganizationName" Type="String" />
                    <asp:Parameter Name="OrganizationDescription" Type="String" />
                    <asp:Parameter Name="AddressLine1" Type="String" />
                    <asp:Parameter Name="AddressLine2" Type="String" />
                    <asp:Parameter Name="Original_OrganizationLanguagesId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>

    
            
    <asp:ObjectDataSource ID="LanguagesObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
</asp:Content>
