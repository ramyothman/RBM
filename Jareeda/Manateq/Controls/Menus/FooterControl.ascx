<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterControl.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Menus.FooterControl" %>
<div class="footer-wrapper">
    <asp:Repeater runat="server" ID="MainMenuRepeater">
            <HeaderTemplate>
                
            </HeaderTemplate>
            <ItemTemplate>
                <ul class="footer-list">
                <li><h3><asp:HyperLink runat="server" href='<%# GetLink(Convert.ToInt32(Eval("MenuEntityItemId"))) %>'><%# Eval("Name").ToString() %></asp:HyperLink></h3></li>
                <asp:Repeater runat="server" ID="Layout2NewsDetailsItemsRepeater"  DataSource='<%# ((BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem)Container.DataItem).ChildItems %>'>
                            <ItemTemplate>
                                <li><asp:HyperLink runat="server" href='<%# GetLink(Convert.ToInt32(Eval("MenuEntityItemId"))) %>'><%# Eval("Name").ToString() %></asp:HyperLink></li>
                            </ItemTemplate>
                        </asp:Repeater>
                     </ul>
            </ItemTemplate>
            <FooterTemplate>
               
            </FooterTemplate>
        </asp:Repeater>
				

			</div>