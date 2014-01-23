<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.Conference.Reviewers.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="g12 widgets">
        <div class="widget widget-header-blue" id="widget_charts">
            <h3 class="handle">
                Manage Reviewers</h3>
            <div class="inner-content">
                <dx:ASPxGridView ID="gridReviewers" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="ReviewersObjectDS" KeyFieldName="AbstractReviewerId" Width="100%">
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
                        <dx:GridViewDataTextColumn FieldName="AbstractReviewerId" ReadOnly="True" 
                            Visible="False" VisibleIndex="1" Caption="Id">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Reviewer" FieldName="PersonId" 
                            VisibleIndex="2">
                            <PropertiesComboBox DataSourceID="PersonObjectDS" 
                                IncrementalFilteringMode="Contains" TextField="FullName" 
                                ValueField="BusinessEntityId" ValueType="System.Int32">
                                <Columns>
                                    <dx:ListBoxColumn FieldName="FullName" />
                                    <dx:ListBoxColumn FieldName="UserName" />
                                </Columns>
                                <ValidationSettings CausesValidation="True" Display="Dynamic" 
                                    ErrorDisplayMode="Text">
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataCheckColumn FieldName="IsInternal" VisibleIndex="3" Width="80px" Caption="Internal Reviewer">
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataDateColumn FieldName="DateCreated" Visible="False" 
                            VisibleIndex="4" Width="80px">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataCheckColumn FieldName="IsActive" VisibleIndex="5" Width="80px">
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                    <SettingsBehavior ConfirmDelete="True" />
                    <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" 
                        PopupEditFormWidth="400px" />
                    <Settings ShowFilterRow="True" />
                    <SettingsText ConfirmDelete="Are you sure you want to delete this reviewer?" />
                </dx:ASPxGridView>
                <asp:ObjectDataSource ID="ReviewersObjectDS" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.Conference.AbstractReviewerLogic" 
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_AbstractReviewerId" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="PersonId" Type="Int32" />
                        <asp:Parameter Name="IsInternal" Type="Boolean" />
                        <asp:Parameter Name="DateCreated" Type="DateTime" />
                        <asp:Parameter Name="IsActive" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="PersonId" Type="Int32" />
                        <asp:Parameter Name="IsInternal" Type="Boolean" />
                        <asp:Parameter Name="DateCreated" Type="DateTime" />
                        <asp:Parameter Name="IsActive" Type="Boolean" />
                        <asp:Parameter Name="Original_AbstractReviewerId" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="PersonObjectDS" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                    TypeName="BusinessLogicLayer.Components.Persons.PersonLogic">
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
