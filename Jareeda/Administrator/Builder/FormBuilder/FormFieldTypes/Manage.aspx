<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.Builder.FormBuilder.FormFieldTypes.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
   <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="Manage Form Field Types"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
      

    </div>
   


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <dx:ASPxGridView ID="gridDocumentStatus" runat="server" 
        AutoGenerateColumns="False" DataSourceID="DocumentObjectDS" 
        KeyFieldName="FormFieldTypeId" Width="100%">
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
            <dx:GridViewDataTextColumn Caption="Id" FieldName="FormFieldTypeId" 
                VisibleIndex="1" Width="50px" Visible="False">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Template" Visible="False" 
                VisibleIndex="3">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
        </Columns>
                    <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" PopupEditFormWidth="450px" />
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="DocumentObjectDS" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
        TypeName="BusinessLogicLayer.Components.FormBuilder.FormFieldTypeLogic" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_FormFieldTypeId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FormFieldTypeId" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Template" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FormFieldTypeId" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Template" Type="String" />
            <asp:Parameter Name="Original_FormFieldTypeId" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
