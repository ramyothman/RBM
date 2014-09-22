<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Default" %>

<%@ Register Src="~/Dashboard/Controls/Content/TotalArticlesWidgetItem.ascx" TagName="TotalArticlesControl" TagPrefix="jareeda" %>
<%@ Register Src="~/Dashboard/Controls/Content/TotalArticlesTodayWidgetItem.ascx" TagName="TotalArticlesTodayControl" TagPrefix="jareeda" %>
<%@ Register Src="~/Dashboard/Controls/Content/LastArticleModifiedWidgetItem.ascx" TagName="LastModifiedArticleControl" TagPrefix="jareeda" %>
<%@ Register Src="~/Dashboard/Controls/Content/TotalSectionsWidgetItem.ascx" TagName="TotalSectionsControl" TagPrefix="jareeda" %>

<%@ Register Src="~/Dashboard/Controls/GoogleAnalytics/TotalVisitsWidgetITem.ascx" TagName="TotalVisitsControl" TagPrefix="jareeda" %>
<%@ Register Src="~/Dashboard/Controls/GoogleAnalytics/TopArticleTodayWidgetItem.ascx" TagName="TopArticlesTodayControl" TagPrefix="jareeda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="col-md-3 left-content">
        <div class="form">
            <jareeda:TotalVisitsControl runat="server" />
            <jareeda:TopArticlesTodayControl runat="server" />
            <jareeda:LastModifiedArticleControl runat="server" />
            <jareeda:TotalArticlesControl runat="server" />
            <jareeda:TotalArticlesTodayControl runat="server" />
        </div>
    </div>
    <div class="col-md-9">
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
