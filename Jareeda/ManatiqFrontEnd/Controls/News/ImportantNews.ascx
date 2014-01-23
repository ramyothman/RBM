<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportantNews.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.ImportantNews" %>
<div runat="server" id="MainBlockContainer" class="block-news">
				<div class="block-head">
					<h1 runat="server" id="ModuleTitleText"></h1>
                     <a href="#" id="MoreLink" runat="server" class="more_btn-head">المزيد</a>
				</div>
				<div class="txt-wrapper">
                    <asp:Repeater runat="server" ID="ImportantNewsRepeater">
                        <ItemTemplate>
                            <div class="block-small">
						<div class="img-wrapper">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><img runat="server" width="182" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' /></a>
						</div>
						<div class="block-text-wrapper">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h2><%# Eval("ArticleName").ToString() %></h2></a>
							
                           <p>
                               <%# GetDescriptionText(Eval("Description").ToString()).ToString() %>
                                <a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>' class="more-small">.....المزيد</a></p>
						</div>
						<div runat="server"  class="social-wrapper">
							<ul>
								
									<li><a href="javascript:window.open('<%# GetGoogleLink(Eval("ArticleId").ToString()) %>','google_plus','height=400,width=640');" class="google2" onclick="window.open('<%# GetGoogleLink(Eval("ArticleId").ToString()) %>','google_plus','height=400,width=640'); return false;"></a></li>
								<li><a href="javascript:void(0);" onclick="window.open('<%# GetTwitterLink(Eval("ArticleId").ToString()) %>','twitter','height=250,width=640'); return false;" class="tweet2" ></a></li>
								<li><a href="javascript:window.open('<%# GetFacebookLink(Eval("ArticleId").ToString()) %>','facebook','height=400,width=640');" class="facebook2"></a></li>
							</ul>
						</div>
					</div>
                        </ItemTemplate>
                    </asp:Repeater>
					
					<div class="block-large">
					<asp:Repeater runat="server" ID="FirstItemsRepeater">
                        <HeaderTemplate>
                            <ul class="more-news">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h2>
                                <%# Eval("ShortTitle").ToString() %>
                                            </h2></a></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
					</asp:Repeater>

                       <asp:Repeater runat="server" ID="SecondItemsRepeater">
                        <HeaderTemplate>
                            <ul class="more-news">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h2>
                                <%# Eval("ShortTitle").ToString() %>
                                            </h2></a></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                           
                        </FooterTemplate>
					</asp:Repeater>
					
					</div>
					
					
					
				</div>
			</div>