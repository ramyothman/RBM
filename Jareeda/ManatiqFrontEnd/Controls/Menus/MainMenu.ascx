<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Menus.MainMenu" %>
<nav>
	<div class="container">
        <asp:Repeater runat="server" ID="MainMenuRepeater">
            <HeaderTemplate>
                <ul class="main">
            </HeaderTemplate>
            <ItemTemplate>
                <li class='<%# GetClass(Convert.ToInt32(Eval("MenuEntityItemId"))) %>' ><a runat="server" href='<%# GetLink(Convert.ToInt32(Eval("MenuEntityItemId"))) %>'><%# Eval("Name").ToString() %></a>
                    <% ChildCounter = 0; %>
              <span style="display:none;">     <%# CountChilds = ((BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem)Container.DataItem).ChildItems.Count %></span>
                    <asp:Repeater runat="server" DataSource='<%# ((BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem)Container.DataItem).ChildItems %>'>
                        <HeaderTemplate>
                              <div class="drop-holder">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <% if((ChildCounter % 5) == 0) {%>
                          
		<ul class="dropmenu">
                        <%} %>
                        <%{ %>
                            <li><a runat="server" href='<%# GetLink(Convert.ToInt32(Eval("MenuEntityParentId")), Convert.ToInt32(Eval("MenuEntityItemId"))) %>' > <%# Eval("Name").ToString() %></a></li>
            <% } ChildCounter++; %>
                        <% if((ChildCounter % 5) == 0 || ChildCounter == (CountChilds - 1)) { %>
            </ul>
	
            <%} %>
                        </ItemTemplate>
                        <FooterTemplate>
                         </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
		
		<asp:Repeater runat="server" ID="MainMenuRepeaterLeft">
            <HeaderTemplate>
                <ul class="sub-main">
            </HeaderTemplate>
            <ItemTemplate>
                <li class='<%# GetClassLeft(Convert.ToInt32(Eval("MenuEntityItemId"))) %>' ><asp:HyperLink runat="server" href='<%# GetLinkLeft(Convert.ToInt32(Eval("MenuEntityItemId"))) %>'><%# Eval("Name").ToString() %></asp:HyperLink></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
		
	</div>
</nav>

<div class="nav2">
    <asp:Repeater runat="server" ID="RepeaterMob">
            <HeaderTemplate>
                <ul class="clearfix">
            </HeaderTemplate>
            <ItemTemplate>
                <li><a runat="server" href='<%# GetLink(Convert.ToInt32(Eval("MenuEntityItemId"))) %>'><%# Eval("Name").ToString() %></a></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
		
			
		<a href="#" id="pull">القائمة</a>
</div>