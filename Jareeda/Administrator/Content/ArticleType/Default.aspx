<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Content.ArticleType.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div class="col-md-4">
        <h1>
            <asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, SAArticleType %>"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
      

    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="GridObjectDS" KeyFieldName="ArticleTypeID" Width="100%">
        <Columns>
            <dx:GridViewCommandColumn ButtonType="Image" ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButton="True" VisibleIndex="0" Width="50px">
                 <EditButton Visible="True">
                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                            </Image>
                        </EditButton>
                <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                <NewButton Visible="True" >
                               <Image Height="16px" Url="/images/newgrid.png" Width="16px">
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
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ArticleTypeID" ReadOnly="True" Visible="False" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="3" Width="100px">
                <EditFormSettings ColumnSpan="2" />
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowFilterRow="True" />
        <SettingsPopup>
            <EditForm Width="450px" />
        </SettingsPopup>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="GridObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleTypeLogic" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_ArticleTypeID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ArticleTypeID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ArticleTypeID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Code" Type="String" />
            <asp:Parameter Name="Original_ArticleTypeID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
