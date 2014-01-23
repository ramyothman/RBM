<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ManatiqFrontEnd.News.Default" %>

<%@ Register Src="~/Controls/News/NewsDetail.ascx" TagName="NewsDetailControl" TagPrefix="natiq" %>
<%@ Register Src="~/Controls/News/Comments.ascx" TagName="CommentsControl" TagPrefix="natiq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta runat="server" id="ogDescription" property="og:description"              /> 
    <meta runat="server" id="ogSiteName" property="og:site_name"             content="المناطق" /> 
<meta runat="server" id="ogTitle" property="og:title"            /> 
<meta runat="server" id="ogImage" property="og:image"         />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
   
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
