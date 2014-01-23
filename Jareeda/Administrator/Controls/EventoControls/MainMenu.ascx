<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="Administrator.Controls.EventoControls.MainMenu" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dx" %>

<dx:ASPxMenu ID="dxMainMenu" CssPostfix="DXConnect" runat="server" ItemSpacing="0px" SeparatorHeight="36px" Height="36px"
                        ClientInstanceName="tabbedMenu" AllowSelectItem="True" SelectParentItem="True" OnItemClick="dxMainMenu_ItemClick">
                        
                    </dx:ASPxMenu>