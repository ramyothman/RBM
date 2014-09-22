<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/Master.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ManatiqFrontEnd.News.WebForm1" %>
<%@ Register Src="~/Controls/News/List.ascx" TagName="ListControl" TagPrefix="natiq" %>
<%@ Register Src="~/Controls/Forms/PollResult.ascx" TagName="PollResultControl" TagPrefix="natiq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <natiq:ListControl runat="server"></natiq:ListControl>
</asp:Content>
