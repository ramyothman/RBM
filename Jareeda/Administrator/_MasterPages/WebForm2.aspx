<%@ Page Theme="EventoAdmin" Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Administrator._MasterPages.WebForm2" %>
<%@ Register Src="~/Controls/EventoControls/VerticalMenu.ascx" TagName="VerticalMenuControl" TagPrefix="evento" %>

<asp:Content ID="Content2" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
    <evento:VerticalMenuControl ID="VerticalMenuControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


</asp:Content>
