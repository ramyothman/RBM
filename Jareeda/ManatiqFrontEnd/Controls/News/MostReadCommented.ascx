<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostReadCommented.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.MostReadCommented" %>
<div runat="server" id="MainBlockContainer" class="block-news international">
    
    <div runat="server" id="MostReadCommentedTab" class="txt-wrapper aside-block-content">
        <ul class="tab-nav version2">
							<li><a href="#tabs-3">الأكثر قراءة</a></li>
							<li><a href="#tabs-4">الأكثر تعليقا</a></li>
						</ul>
						<div id="tabs-3">
							<ul class="most-reads">
                                <asp:Repeater runat="server" ID="LayoutNewsRepeater">
                                    <ItemTemplate>
                                        <li><a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><img runat="server" width="64" height="50" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' alt="" /></a><a style="float: right;width:200px;" runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><%# Eval("ShortTitle").ToString() %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
							</ul>
						</div>
						<div id="tabs-4">
							<ul class="most-reads">
								<asp:Repeater runat="server" ID="RepeaterMostCommented">
                                    <ItemTemplate>
                                        <li><a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><img runat="server" width="64" height="50" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' alt="" /></a><a style="float: right;width:200px;" runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><%# Eval("ShortTitle").ToString() %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
							</ul> 
						</div>
    </div>
</div>
