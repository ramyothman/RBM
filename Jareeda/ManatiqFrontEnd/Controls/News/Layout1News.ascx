<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Layout1News.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.Layout1News" %>
<div class="block-3">
				<div runat="server" id="BlockHead" class="block-head">
					<h1 runat="server" id="ModuleTitleText"></h1>
                     
				</div>
				<div class="txt-wrapper">
                    <asp:Repeater runat="server" ID="LayoutNewsRepeater">
                        
                        <ItemTemplate>
                            <div class="block-small">
                            <div class="img-wrapper">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><img runat="server" width="181" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' alt="" /></a>
						</div>
						<div class="block-text-wrapper">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h2><%# Eval("ArticleName").ToString() %></h2></a>
							<%--<p class="dots2"><%# GetDescriptionText(Eval("Description").ToString()).ToString() %><a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>' class="more-small">المزيد</a></p>--%>
							<div class="social-wrapper">
							<ul>
                                
			<a href="#" class="facebook_line"></a>
      

								<li><a href="http://www.youtube.com/user/Almnatiq" class="google2" onclick="window.open('<%# GetGoogleLink(Eval("ArticleId").ToString()) %>','google_plus','height=400,width=640'); return false;"></a></li>
								<li><a href="https://twitter.com/almnatiq" class="tweet2" onclick="window.open('<%# GetTwitterLink(Eval("ArticleId").ToString()) %>','twitter','height=250,width=640'); return false;"></a></li>
								<li><a href="https://www.facebook.com/AlMnatiq" class="facebook2" onclick="window.open('<%# GetFacebookLink(Eval("ArticleId").ToString()) %>','facebook','height=400,width=640'); return false;"></a></li>
							</ul>
						</div>
						</div>
                                </div>
                        </ItemTemplate>
                       <FooterTemplate>
                           <%--<a href='<%#  GetMoreLink() %>' runat="server" class="more_btn">المزيد</a>--%>
                       </FooterTemplate> 
                       
                    </asp:Repeater>
                    <div style="float:right;clear:both;height:45px;"></div>
                    
					
					<a href='<%#  GetMoreLink() %>' runat="server" class="more_btn">المزيد</a>
				</div>
		</div>