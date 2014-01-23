<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout3News.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.Layout3News" %>
<div runat="server" id="MainBlockContainer" class="block-news international">
				<div class="block-head">
					<h1 runat="server" id="ModuleTitleText"></h1>
                     <a href="#" id="MoreLink" runat="server" class="more_btn-head">المزيد</a>
				</div>
				<div class="txt-wrapper">
                    <% ItemIndex = 0; %>
                    <asp:Repeater runat="server" ID="LayoutNewsRepeater">
                        <HeaderTemplate>

                        </HeaderTemplate>
                        <ItemTemplate>
                            <% if(ItemIndex == 0) { %>
                            <div class="block-small">
						<div class="img-wrapper">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><img runat="server" width="182" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' alt="" /></a>
						</div>
						<div class="block-text-wrapper">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h2><%# Eval("ArticleName").ToString() %></h2></a>
							<p><%# GetDescriptionText(Eval("Description").ToString()).ToString() %><a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>' class="more-small">.....المزيد</a></p>
							<div runat="server" visible="false" class="social-wrapper">
							<ul>
								<li><a href="http://www.youtube.com/user/Almnatiq" class="google2"></a></li>
								<li><a href="https://twitter.com/almnatiq" class="tweet2"></a></li>
								<li><a href="https://www.facebook.com/AlMnatiq" class="facebook2"></a></li>
							</ul>
						</div>
						</div>
						
					</div>
                            <%} else {%>
                             <% if(ItemIndex == 1) { %>
                            <ul class="international-list">
                                <%} %>
						<li><a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'>
							<div class="img-wrapper">
								<img runat="server" width="182" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' alt="" />
							</div>
							<h2><%# Eval("ShortTitle").ToString() %></h2></a>
						</li>
						
                                <% if (ItemIndex == ItemCount)
                                   { %>
					</ul>
                            <% } %>
                             <%} %>
                                <% ItemIndex++; %>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%--<a href='<%#  GetMoreLink() %>' runat="server" class="more_btn">المزيد</a>--%>
                        </FooterTemplate>
                        </asp:Repeater>
					
					
					
					
					
					
				</div>
			</div>