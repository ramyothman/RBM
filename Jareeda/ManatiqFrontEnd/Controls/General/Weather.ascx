<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Weather.ascx.cs" Inherits="ManatiqFrontEnd.Controls.General.Weather" %>

<div runat="server" id="MainBlockContainer" class="aside-block">
    <div runat="server" id="weather2" class="aside-block-content widget weather" style="direction:rtl;">
        <asp:Repeater ID="WeatherRepeater" runat="server">
            <ItemTemplate>
                <div id="<%= "tab-" + IndexCounter %>" class="<%= "city " + IsVisibleFirst %>">
                  <div class="main-title">درجات الحرارة و حالة الطقس</div>
                  <div class="city-name">مدينة<br><%# Eval("CityArabic") %></div>
                  <img class="icon" src="<%# Eval("WeatherIcon") %>" />
                  <div class="temperature"><%# Eval("Temperature") %></div> 
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="WeatherTabsRepeater" runat="server">
            <HeaderTemplate>
                <ul class="tabs">
            </HeaderTemplate>
            <ItemTemplate>
                <li><a href="<%= "#tab-" + IndexCounter %>" ><%# Eval("CityArabic") %></a></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
                                
                
                                
        </div>          
</div>
