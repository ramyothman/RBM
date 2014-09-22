<%@ Page Theme="GeniAdminEn" Title="" Language="C#" MasterPageFile="~/_MasterNew/MasterTest.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Administrator._MasterNew.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Article Manager
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    
    <div class="col-md-12">
        <div id="clickme">success test</div>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" KeyFieldName="ArticleId" Width="100%">
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ArticleId" ReadOnly="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SectionName" ReadOnly="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AuthorName" ReadOnly="True" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="PostDate" VisibleIndex="7">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ModifiedDate" VisibleIndex="10">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataCheckColumn FieldName="EnableModeteration" VisibleIndex="12">
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataTextColumn FieldName="ViewsCount" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CommentsCount" VisibleIndex="16">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ArticleName" VisibleIndex="18">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ArticleAttachment" VisibleIndex="20">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior AllowFocusedRow="True" />
        <SettingsPager >
        </SettingsPager>
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        
    </dx:ASPxGridView>
        </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleLogic"></asp:ObjectDataSource>
</asp:Content>
