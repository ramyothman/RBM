<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListItemsControl.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.ListItemsControl" %>
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