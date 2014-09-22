<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TotalVisitsWidgetITem.ascx.cs" Inherits="Administrator.Dashboard.Controls.GoogleAnalytics.TotalVisitsWidgetITem" %>
<div class="jareeda-metrics">

    <dx:ASPxCallbackPanel ID="callBackPanel" runat="server" Width="100%" OnCallback="callBackPanel_Callback">

        <PanelCollection>
            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                <span class="fa fa-bar-chart-o"></span><span class="metric" runat="server" id="metricTotalArticles">0</span><span><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, WITotalVisitsTodayTitle %>"></asp:Literal></span>
            </dx:PanelContent>
        </PanelCollection>
        <ClientSideEvents Init="function(s,e){s.PerformCallback('');}" />
    </dx:ASPxCallbackPanel>
    
</div>
