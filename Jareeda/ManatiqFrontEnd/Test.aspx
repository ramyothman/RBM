<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/Master.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ManatiqFrontEnd.Test" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<dx:ASPxDataView ID="ASPxDataView1" runat="server" DataSourceID="ObjectDataSource1">
<PagerSettings ShowNumericButtons="False"></PagerSettings>
                            <ItemTemplate>
                                <b>ArticleId</b>:
                                <asp:Label ID="ArticleIdLabel" runat="server" Text='<%# Eval("ArticleId") %>' />
                                <br/>
                                <b>SiteSectionId</b>:
                                <asp:Label ID="SiteSectionIdLabel" runat="server" Text='<%# Eval("SiteSectionId") %>' />
                                <br/>
                                <b>CurrentSection</b>:
                                <asp:Label ID="CurrentSectionLabel" runat="server" Text='<%# Eval("CurrentSection") %>' />
                                <br/>
                                <b>SectionName</b>:
                                <asp:Label ID="SectionNameLabel" runat="server" Text='<%# Eval("SectionName") %>' />
                                <br/>
                                <b>CreatorId</b>:
                                <asp:Label ID="CreatorIdLabel" runat="server" Text='<%# Eval("CreatorId") %>' />
                                <br/>
                                <b>ArticleStatusId</b>:
                                <asp:Label ID="ArticleStatusIdLabel" runat="server" Text='<%# Eval("ArticleStatusId") %>' />
                                <br/>
                                <b>AuthorId</b>:
                                <asp:Label ID="AuthorIdLabel" runat="server" Text='<%# Eval("AuthorId") %>' />
                                <br/>
                                <b>Author</b>:
                                <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                                <br/>
                                <b>AuthorName</b>:
                                <asp:Label ID="AuthorNameLabel" runat="server" Text='<%# Eval("AuthorName") %>' />
                                <br/>
                                <br/>
                            </ItemTemplate>
</dx:ASPxDataView>

<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleLogic"></asp:ObjectDataSource>
 
</asp:Content>
