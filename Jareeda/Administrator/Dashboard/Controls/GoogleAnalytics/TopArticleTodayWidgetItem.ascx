<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopArticleTodayWidgetItem.ascx.cs" Inherits="Administrator.Dashboard.Controls.GoogleAnalytics.TopArticleTodayWidgetItem" %>
<div class="jareeda-metrics">
    <h1>
        <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, WITopArticleTitle %>"></asp:Literal>
    </h1>
    <dx:ASPxCallbackPanel ID="callBackPanel" runat="server" Width="100%" OnCallback="callBackPanel_Callback">

        <PanelCollection>
            <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                
                <div class="widget-data">
                    <div class="img-wrapper">
                        <img runat="server" id="WriterImage" width="60" src="~/images/writters-s.jpg" />
                    &nbsp;</img>&nbsp;</img>&nbsp;</img>&nbsp;</img></div>
                    <div  class="writer">
                        <div runat="server" id="Writer"></div>
                        <div runat="server" id="ArticleShortName" class="article"></div>
                    </div>
                    
                </div>
                <div class="row detail" style="clear:both;">
                <span class="fa fa-thumbs-up"></span><span><asp:Literal ID="AFTitle" runat="server" ></asp:Literal></span>
                    </div>
            </dx:PanelContent>
        </PanelCollection>
        <ClientSideEvents Init="function(s,e){s.PerformCallback('');}" />
    </dx:ASPxCallbackPanel>
    
</div>
