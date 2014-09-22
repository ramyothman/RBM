<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.HumanResources.PaymentType.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
     <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="Manage Payment Types"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
       

    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="AirLineGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="PaymentTypeID"
                Width="100%" DataSourceID="DSAirLine" >
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
                    <dx:GridViewDataTextColumn FieldName="PaymentTypeID" Visible="false" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataCheckColumn FieldName="IsRecurring" Width="50px" VisibleIndex="3">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataTextColumn FieldName="RecurringNumberinDays" Width="50px" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="IsPerItem" Width="50px" VisibleIndex="5">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataTextColumn FieldName="ItemNumber" Width="50px" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>

          <asp:ObjectDataSource ID="DSAirLine" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.HumanResources.PaymentTypeLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_PaymentTypeID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="IsRecurring" Type="Boolean" />
                    <asp:Parameter Name="RecurringNumberinDays" Type="Int32" />
                    <asp:Parameter Name="IsPerItem" Type="Boolean" />
                    <asp:Parameter Name="ItemNumber" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="IsRecurring" Type="Boolean" />
                    <asp:Parameter Name="RecurringNumberinDays" Type="Int32" />
                    <asp:Parameter Name="IsPerItem" Type="Boolean" />
                    <asp:Parameter Name="ItemNumber" Type="Int32" />
                    <asp:Parameter Name="Original_PaymentTypeID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
  
</asp:Content>
