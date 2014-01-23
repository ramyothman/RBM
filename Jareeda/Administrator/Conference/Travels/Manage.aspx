<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.Conference.Travels.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <div class="g12 widgets">
			<div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
				<h3 class="handle">Manage Travels </h3>
				<div class="inner-content">
            <dx:ASPxGridView ID="TravelsGrid" runat="server" AutoGenerateColumns="False" DataSourceID="DSTravels"
                KeyFieldName="ID" Width="100%">
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
                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1" Visible="False" Width="50px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="TransportationTypeID" ShowInCustomizationForm="True"
                        VisibleIndex="4" Caption="Transportation Type" Width="120px">
                        <PropertiesComboBox DataSourceID="TransportationTypeDS" TextField="TypeName" ValueField="ID"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataMemoColumn FieldName="Description" VisibleIndex="6" Width="200px">
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Conference" FieldName="ConferenceID" 
                        VisibleIndex="3" Width="200px">
                        <PropertiesComboBox DataSourceID="ConferenceObjectDS" 
                            TextField="ConferenceName" ValueField="ConferenceId" ValueType="System.Int32">
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                </Columns>    
                <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True" />           
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                    EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="dsTravelLang" 
                            AutoGenerateColumns="False" KeyFieldName="ID" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect">
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
                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="TransportationTypeID" ShowInCustomizationForm="True"
                        VisibleIndex="3" Caption="Transportation Type">
                        <PropertiesComboBox DataSourceID="TransportationTypeDS" TextField="TypeName" ValueField="ID"
                            ValueType="System.Int32">
                        </PropertiesComboBox>
                        <EditFormSettings ColumnSpan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="NewRecord" Visible="False" VisibleIndex="5">
                    </dx:GridViewDataCheckColumn>
                     <dx:GridViewDataTextColumn FieldName="ParentID" VisibleIndex="4" Visible="false">
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataComboBoxColumn Caption="Language" FieldName="LanguageID" 
                        VisibleIndex="22">
                        <PropertiesComboBox DataSourceID="dsLanguages" TextField="Name" ValueField="LanguageId"></PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                </Columns>               
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                    EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />                                
                        </dx:ASPxGridView>
                          <asp:ObjectDataSource ID="dsLanguages" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
            </asp:ObjectDataSource> 
                        <asp:ObjectDataSource ID="dsTravelLang" runat="server" DeleteMethod="Delete" 
                            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="GetAll" 
                            TypeName="BusinessLogicLayer.Components.Conference.TravellanguageLogic" 
                            UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_ID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="TransportationTypeID" Type="Int32" />
                                <asp:Parameter Name="Description" Type="String" />
                                <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Name" Type="String" />
                                <asp:Parameter Name="TransportationTypeID" Type="Int32" />
                                <asp:Parameter Name="Description" Type="String" />
                                <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" />
                                <asp:Parameter Name="LanguageID" Type="Int32" />
                                <asp:Parameter Name="Original_ID" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            </div>
            <asp:ObjectDataSource ID="DSTravels" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Conference.TravelLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="TransportationTypeID" Type="Int32" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="ConferenceID" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="TransportationTypeID" Type="Int32" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="ConferenceID" Type="Int32" />
                    <asp:Parameter Name="Original_ID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="TransportationTypeDS" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Conference.TransportationTypeLogic">
            </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ConferenceObjectDS" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.Conference.ConferencesLogic">
                </asp:ObjectDataSource>
            <br />
        </div>
    </div>
</asp:Content>
