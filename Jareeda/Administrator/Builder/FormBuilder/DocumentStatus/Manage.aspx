<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.Builder.FormBuilder.DocumentStatus.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
   <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="Manage Document Status"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
       

    </div>
   


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="gridDocumentStatus" runat="server" 
        AutoGenerateColumns="False" DataSourceID="DocumentObjectDS" Width="100%" 
        KeyFieldName="FormDocumentStatusID">
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
             <dx:GridViewDataTextColumn Caption="Id" FieldName="FormDocumentStatusID" 
                VisibleIndex="1" Width="50px" Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="StatusName" VisibleIndex="2">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
        </Columns>
                    <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" PopupEditFormWidth="450px" />
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="DocumentObjectDS" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
        TypeName="BusinessLogicLayer.Components.FormBuilder.FormDocumentStatusLogic" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_FormDocumentStatusID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FormDocumentStatusID" Type="Int32" />
            <asp:Parameter Name="StatusName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FormDocumentStatusID" Type="Int32" />
            <asp:Parameter Name="StatusName" Type="String" />
            <asp:Parameter Name="Original_FormDocumentStatusID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
           
</asp:Content>
