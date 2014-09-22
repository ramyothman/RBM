<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Content.MultimediaType.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
     <div class="col-md-4">
        <h1>
            <asp:Literal ID="Literal1" runat="server" Text="Manage Multimedia Types"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
      

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="MultimediaTypeGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="MultimediaTypeID"
                Width="100%" DataSourceID="MultimediaTypeObjectDS" >
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
                    <dx:GridViewDataTextColumn Caption="Id" FieldName="MultimediaTypeID" ReadOnly="True" VisibleIndex="1" Width="50px">
                        <editformsettings visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" FieldName="Name" VisibleIndex="2">
                        <propertiestextedit>
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiestextedit>
                    </dx:GridViewDataTextColumn>
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>
     <asp:ObjectDataSource ID="MultimediaTypeObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MultimediaTypeLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_MultimediaTypeID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Original_MultimediaTypeID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
</asp:Content>
