<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainNews.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.MainNews" %>
<% if(IsInternalBlock){ %>
<div class="block-news-main-container">
    <%} %>
<div  class="slider-wrapper">
    <ul runat="server" id="MainNewsSlider" class="main-slider">
        <asp:Repeater runat="server" ID="MainSliderRepeater">
            <HeaderTemplate>
                
            </HeaderTemplate>
            <ItemTemplate>
                <li>
				  		<div class="slider-block">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h3><%# Eval("ArticleName").ToString() %></h3></a>
							<div class="slider-block-left">
                                <a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'>
								<img runat="server" width="450" height="280" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' />
                                    
                                    </a>
                                
							</div>
                              <div class="slider-block-right">
								<p>
                                    <%# GetDescriptionText(Eval("Description").ToString()).ToString() %>
                                    <a class="more-small" runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'>.....المزيد</a></p>
							</div>
							
						</div>
					</li>
            </ItemTemplate>
            <FooterTemplate>
                
            </FooterTemplate>
        </asp:Repeater>
				
				  	</ul>
				 	
				<asp:Repeater runat="server" ID="SmallSliderRepeater">
                    <HeaderTemplate>
                        <div id="bx-pager">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a data-slide-index='<%= (Index++).ToString() %>' href="">
				  		<div class="slider-block2">
							<img runat="server" width="103" height="56" src='<%# GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' />
							<p><%# Eval("ShortTitle").ToString() %></p>
						</div>
					</a>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
				</asp:Repeater>
				
				  	
				
				</div>
    <% if(IsInternalBlock){ %>
			</div>
<%} %>