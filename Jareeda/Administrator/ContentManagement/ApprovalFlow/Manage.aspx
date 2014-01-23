<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.ContentManagement.ApprovalFlow.Manage"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="g12 widgets">
			<div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
				<h3 class="handle"> <asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, AFTitle %>"></asp:Literal> </h3>
				<div class="inner-content">
                    

            <dx:ASPxGridView ID="SourcesGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="ApprovalFlowID"
                Width="100%" DataSourceID="SourcesObjectDS"  >
                <Columns>
                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" " >
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
                    <dx:GridViewDataTextColumn FieldName="ApprovalFlowID" Visible="false" ReadOnly="True" VisibleIndex="1" Caption="Id" >
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, AFSection %>" FieldName="SectionID" VisibleIndex="2" >
                        <propertiescombobox datasourceid="SectionDS" textfield="Name" valuefield="SiteSectionId" valuetype="System.Int32"></propertiescombobox>
                    </dx:GridViewDataComboBoxColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="Title" Caption="<%$Resources:ContentManagement, AFTitle %>" VisibleIndex="3" Width="120px" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="DateStart" Caption="<%$Resources:ContentManagement, AFDateStart %>" VisibleIndex="4" >
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="DateEnd" Caption="<%$Resources:ContentManagement, AFDateEnd %>" VisibleIndex="5" >
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="ApprovedBy" Caption="<%$Resources:ContentManagement, AFApprovedBy %>" VisibleIndex="6" Visible="False" >
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                <settingsdetail allowonlyonemasterrowexpanded="True" showdetailrow="True" />
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView id="OfferFlowDetailGrid" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" KeyFieldName="ApprovalFlowDetailID" Width="100%" OnBeforePerformDataSelect="OfferFlowDetailGrid_BeforePerformDataSelect" >
                            <Columns>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" "  ShowInCustomizationForm="True">
                        <EditButton Visible="True">
                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                            </Image>
                        </EditButton>
                        <NewButton Visible="True">
                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                            </Image>
                        </NewButton>
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
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
                                <dx:GridViewDataTextColumn Caption="ID" Visible="false" FieldName="ApprovalFlowDetailID" ReadOnly="True" VisibleIndex="1"  ShowInCustomizationForm="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ApprovalFlowID" Visible="False" VisibleIndex="2"  ShowInCustomizationForm="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OrderNumber" Caption="<%$Resources:ContentManagement, AFOrderNumber %>"  VisibleIndex="3"  ShowInCustomizationForm="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, AFStatus %>" FieldName="ArticleStatusID" VisibleIndex="4"  ShowInCustomizationForm="True">
                                    <propertiescombobox datasourceid="statusObjectDS" textfield="Name" valuefield="ArticleStatusId" valuetype="System.Int32"></propertiescombobox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, AFUser %>" FieldName="UserID" VisibleIndex="5"  ShowInCustomizationForm="True">
                                    <propertiescombobox datasourceid="usersObjectDS" textfield="DisplayName" valuefield="BusinessEntityId" valuetype="System.Int32"></propertiescombobox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="StatusDurationInHours" VisibleIndex="6"  Caption="<%$Resources:ContentManagement, AFStatusDurationInHours %>" ShowInCustomizationForm="True">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <settingsediting mode="PopupEditForm" />
                            <settings showfilterrow="True" />
                        </dx:ASPxGridView>
                        
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByApprovalFlowID" TypeName="BusinessLogicLayer.Components.ContentManagement.ApprovalFlowDetailLogic" UpdateMethod="Update">
                            <DeleteParameters>
                                <asp:Parameter Name="Original_ApprovalFlowDetailID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="ApprovalFlowDetailID" Type="Int32" />
                                <asp:SessionParameter DefaultValue="0" Name="ApprovalFlowID" SessionField="ApprovalFlowID" Type="Int32" />
                                <asp:Parameter Name="OrderNumber" Type="Int32" />
                                <asp:Parameter Name="ArticleStatusID" Type="Int32" />
                                <asp:Parameter Name="UserID" Type="Int32" />
                                <asp:Parameter Name="StatusDurationInHours" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="ApprovalFlowID" SessionField="ApprovalFlowID" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ApprovalFlowDetailID" Type="Int32" />
                               <asp:SessionParameter DefaultValue="0" Name="ApprovalFlowID" SessionField="ApprovalFlowID" Type="Int32" />
                                <asp:Parameter Name="OrderNumber" Type="Int32" />
                                <asp:Parameter Name="ArticleStatusID" Type="Int32" />
                                <asp:Parameter Name="UserID" Type="Int32" />
                                <asp:Parameter Name="StatusDurationInHours" Type="Int32" />
                                <asp:Parameter Name="Original_ApprovalFlowDetailID" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </DetailRow>
                </Templates>
            </dx:ASPxGridView>
            </div>
                <asp:ObjectDataSource ID="statusObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleStatusLogic"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="usersObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.Persons.PersonLogic"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="SourcesObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ApprovalFlowLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_ApprovalFlowID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="SectionID" Type="Int32" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="DateStart" Type="DateTime" />
                    <asp:Parameter Name="DateEnd" Type="DateTime" />
                    <asp:Parameter Name="ApprovedBy" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SectionID" Type="Int32" />
                    <asp:Parameter Name="Title" Type="String" />
                    <asp:Parameter Name="DateStart" Type="DateTime" />
                    <asp:Parameter Name="DateEnd" Type="DateTime" />
                    <asp:Parameter Name="ApprovedBy" Type="Int32" />
                    <asp:Parameter Name="Original_ApprovalFlowID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="SectionDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic"></asp:ObjectDataSource>
            <br />
                </div>
         </div>
</asp:Content>
