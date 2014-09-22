<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.List" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<div runat="server" id="MainContainer" class="block-news">

</div>
<div visible="false"  runat="server" id="DivMainContainer" class="block-news mrg-top">
    <div runat="server" id="MainBlockContainer" class="aside-block">
        <div class="aside-block-head">
            </div>
        <div class="aside-block-content">
    <asp:Repeater runat="server" ID="ListNewsContainer">
        <ItemTemplate>
            <div class="block-small">
						<div class="img-wrapper">
							<a href="#"><img runat="server" width="182" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ArticleAttachment"))) %>' /></a>
						</div>
						<div class="block-text-wrapper">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h2><%# Eval("ArticleName").ToString() %></h2></a>
							
                           <p>
                             <%# GetDescriptionText(Eval("ArticleDescription").ToString()).ToString() %>  
                                <a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>' class="more-small">.....المزيد</a></p>
						</div>
						
					</div>
        </ItemTemplate>
        <FooterTemplate>
            <div id="more_news" ></div>
            <div class="clear clearfix clear-fix"></div>
            <div class="readMoreList">
                <img id="loadingMore" style="display:none;" src="~/images/DXR.gif" runat="server" />
                <a href="javascript:void(0);" onclick="alert('test1');listCallBack.PerformCallback();" >تحميل أكثر</a>
            </div>
        </FooterTemplate>
    </asp:Repeater>
            </div>
    </div>
</div>
 
<%--<dx:ASPxCallback ID="callBackList" ClientInstanceName="listCallBack" runat="server" OnCallback="callBackList_Callback">
    <ClientSideEvents BeginCallback="function(s, e) {
        alert('test');
	$('#loadingMore').show();
}" EndCallback="function(s, e) {
		$('#loadingMore').hide();
        #('#more_news').append(e.result);
}" />
</dx:ASPxCallback>--%>
