<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Content.OfferPackage.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div class="col-md-4">
        <h1>
            <asp:Literal ID="Literal1" runat="server" Text="Manage Offer Package"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
      

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
     <dx:ASPxGridView ID="SourcesGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="MediaSourceID"
                Width="100%" DataSourceID="SourcesObjectDS" >
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
                    <dx:GridViewDataTextColumn FieldName="MediaSourceID" ReadOnly="True" VisibleIndex="1" Caption="Id" Width="50px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                        <propertiestextedit>
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiestextedit>
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="Site" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Rss" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="PrivateUrl" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>
    <asp:ObjectDataSource ID="SourcesObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MediaSourceLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_MediaSourceID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Site" Type="String" />
                    <asp:Parameter Name="Rss" Type="String" />
                    <asp:Parameter Name="PrivateUrl" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Site" Type="String" />
                    <asp:Parameter Name="Rss" Type="String" />
                    <asp:Parameter Name="PrivateUrl" Type="String" />
                    <asp:Parameter Name="Original_MediaSourceID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
</asp:Content>
