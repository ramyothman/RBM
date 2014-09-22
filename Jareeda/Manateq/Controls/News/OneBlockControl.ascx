<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OneBlockControl.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.OneBlockControl" %>
<div runat="server" id="MainBlockContainer" class="aside-block">

    <asp:Repeater runat="server" ID="Layout2NewsRepeater">
        <HeaderTemplate>
            <div class="aside-block-head">
					<ul class="sections-list">
        </HeaderTemplate>
        <ItemTemplate>
             <li><h1><a href='<%#  "~/list/5-" + Eval("SectionId") %>' runat="server"><%# Eval("SectionName") %></a></h1></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
				</div>
        </FooterTemplate>
    </asp:Repeater>
			<asp:Repeater runat="server" ID="Layout2NewsDetailsRepeater">
                <HeaderTemplate>
                    <div class="aside-block-content">
                        <ul class="sections-list mrg-top">
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="display-table">
                        <% ItemIndex = 0; %>
                        <%--<h1><%# Eval("SectionName") %></h1>--%>
                        <asp:Repeater runat="server" ID="Layout2NewsDetailsItemsRepeater"  DataSource='<%# ((BusinessLogicLayer.Entities.ContentManagement.ModuleSection)Container.DataItem).Articles %>'>
                            <ItemTemplate>

                                <% if(ItemIndex == 0) { %>
                                
                                    <a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'>
							<img runat="server" width="282" height="150" src='<%#  GetImagePath(Convert.ToString(Eval("ArticleAttachment"))) %>' alt="" />
							<h2><%# Eval("ShortTitle").ToString() %></h2></a>
							<p><%# GetDescriptionText(Eval("ArticleDescription").ToString()).ToString() %> <a class="more-small" runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'>المزيد</a></p>
							<div runat="server" visible="false" class="social-wrapper">
							<ul>
								<li><a href="http://www.youtube.com/user/Almnatiq" class="google2"></a></li>
								<li><a href="https://twitter.com/almnatiq" class="tweet2"></a></li>
								<li><a href="https://www.facebook.com/AlMnatiq" class="facebook2"></a></li>
							</ul>
						</div>
                                <%} else {%>
                                <a runat="server" class="titles" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h4><%# Eval("ShortTitle").ToString() %></h4></a>
                                <%} %>
                                <% ItemIndex++; %>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%--<a href="#" class="more_btn">المزيد</a>--%>
                                <%--<a href='<%#  GetMoreLink() %>' runat="server" style="vertical-align:bottom;" class="more_btn display-table-cell">المزيد</a>--%>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                    </div>
                </FooterTemplate>
			</asp:Repeater>
				
		</div>