<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ManatiqFrontEnd.Default" %>
<%@ Register Src="~/Controls/News/Urgent.ascx" TagName="NewsControl" TagPrefix="natiq" %>
<%@ Register Src="~/Controls/News/MainNews.ascx" TagName="MainNews" TagPrefix="natiq" %>
<%@ Register Src="~/Controls/News/ImportantNews.ascx" TagName="ImportantNews" TagPrefix="natiq" %>
<%@ Register Src="~/Controls/News/Layout1News.ascx" TagName="Layout1NewsControl" TagPrefix="natiq" %>
<%@ Register Src="~/Controls/News/Layout2News.ascx" TagName="Layout2NewsControl" TagPrefix="natiq" %>
<%@ Register Src="~/Controls/News/Layout3News.ascx" TagName="Layout3NewsControl" TagPrefix="natiq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="ContentPlaceHolderMain1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <%--<natiq:NewsControl runat="server" ID="NatiqUrgentControl" HomePageID="1" />
    <div class="block-1">
        <natiq:MainNews runat="server" ID="NatiqMainNewsControl" HomePageID="2"  />

        <div class="ads2">
				<a href="#"><img height="449" width="310" src="_ui/images/ads2.png" alt="" /></a>
			</div>
    </div>

    <div class="ads3">
			<a href="#"><img src="_ui/images/ads3.png" alt="" /></a>
		</div>

    <div class="block-2">
        <natiq:ImportantNews runat="server" HomePageID="3" ID="NatiqImportantNewsControl" />
        <div class="aside">
				
				<div class="ads4 mrg-top">
					<img src="_ui/images/ads4.png" alt="" />
				</div>
			</div>
    </div>

    <natiq:Layout1NewsControl runat="server" id="TaqarirMosawarControl" HomePageID="4" />
	<natiq:Layout2NewsControl runat="server" ID="Monawa3atControl" HomePageID="7" />
    <div class="block-2 international">
			<div class="wrapper">
                <natiq:Layout3NewsControl runat="server" HomePageID="10" />
                </div>
        </div>--%>
		
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
</asp:Content>
