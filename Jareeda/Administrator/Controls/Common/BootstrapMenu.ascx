<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BootstrapMenu.ascx.cs" Inherits="Administrator.Controls.Common.BootstrapMenu" %>
<header class="navbar navbar-inverse navbar-fixed-top esperto-nav" role="banner">
    <div>
        <div class="navbar-header">
            <button class="navbar-toggle collapsed" type="button" data-toggle="collapse" data-target=".bs-navbar-collapse">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a href="#" class="navbar-brand">
                <div class="img-wrapper">
                    <img src="/images/natiq-logo-small-white.png" height="40" /></div>
            </a>
        </div>
        <nav class="navbar-collapse bs-navbar-collapse collapse" role="navigation" style="height: 1px;">
            <asp:Repeater runat="server" ID="MainMenuRepeater">
                <HeaderTemplate>
                    <ul class="nav navbar-nav">
                </HeaderTemplate>

                <ItemTemplate>
                    <li class='<%# GetClass(Convert.ToInt32(Eval("MenuEntityItemId"))) %>'>
                        <a runat="server" href='<%# GetLink(Convert.ToInt32(Eval("MenuEntityItemId"))) %>'><%# Eval("Name").ToString() %></a>


                        <asp:Repeater runat="server" DataSource='<%# ((BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem)Container.DataItem).ChildItems %>'>
                            <HeaderTemplate>
                                <div style='<%# "display:" + (((ICollection)((Repeater)Container.Parent).DataSource).Count == 0 ? "none": "block") %>'>
                                    <ul class="dropdown-menu" role="menu">
                            </HeaderTemplate>

                            <ItemTemplate>
                                <li>
                                    <a runat="server" href='<%# GetLink(Convert.ToInt32(Eval("MenuEntityParentId")), Convert.ToInt32(Eval("MenuEntityItemId"))) %>'><%# Eval("Name").ToString() %></a>
                                </li>
                            </ItemTemplate>

                            <FooterTemplate>
                                </ul>
                            </div>
                            </FooterTemplate>

                        </asp:Repeater>


                </ItemTemplate>

                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>


            <ul class="nav navbar-nav navbar-right">
                <li runat="server" visible="false" id="AccountLogin">
                    <p>
                        Logged in as <span runat="server" id="UserNameSpan"></span>
                    </p>
                </li>
                <li runat="server" visible="false" id="AccountLogout"><a runat="server" href="~/Default.aspx?Logout=true">
                    <img width="16" height="16" class="logout" alt="picture" runat="server" src="~/images/icon_logout.gif" /><asp:Literal runat="server" Text="<%$Resources:ContentManagement, AccountLogout %>"></asp:Literal></a>

                </li>
            </ul>
        </nav>
    </div>
</header>
