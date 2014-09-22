<%@ Page Theme="GeniAdminEn" Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Administrator._GeniMaster.WebForm1" %>

<%@ Register Src="~/_Geni/Controls/ContentManagement/MenuManager/Menus.ascx" TagName="MenuControl" TagPrefix="geni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_MasterNew/styles/images/ribbon/menu.png" /></div>
        <div class="title-text">Menu Manager</div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="grid.AddNewRow();"><span class="fa fa-plus-circle fa-align-left"></span>New</div>
        <asp:Button runat="server" CssClass="btn btn-default btn-export btn-export-excel" Text="Excel" />
        <asp:Button runat="server" CssClass="btn btn-default btn-export btn-export-word" Text="Word" />
        <asp:Button runat="server" CssClass="btn btn-default btn-export btn-export-pdf" Text="PDF" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <geni:MenuControl runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
