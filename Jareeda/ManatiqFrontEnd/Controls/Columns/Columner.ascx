<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Columner.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Columns.Columner" %>
<div class="block-news-main-container">
    <div class="columnist-box">
        <div class="columnist-image">
            <img runat="server" id="MainImage" width="148" height="191" src="http://admin.almnatiq.com/ContentData/Sites/Conferences/thumb2013114-104749-1920456366-297540_10150345721508678_1063587556_n.jpg" />
        </div>

        <div class="columnist-details">
            <h2 id="AuthorAlilas" runat="server">زهران الجمعاني</h2>
            <h3 runat="server" id="PositionLabel">كاتب سعودي</h3>
        </div>
    </div>

    <div class="block-news columns-all">
        <div class="head">
            <span>اقرأ له</span>
        </div>
        <div class="txt-wrapper">
            <asp:Repeater runat="server" ID="ArticlesRepeater">
                <ItemTemplate>
                    <div class="block-small">

                        <div class="block-text-wrapper-columnist">
                            <a runat="server" href='<%# "~/column/cl3-" + Eval("ArticleId") %>'>
                                <h2><%# Eval("ArticleName").ToString() %></h2>
                            </a>
                            <span class="date-artical"><%# GetDate(Convert.ToDateTime(Eval("PostDate").ToString())) %> </span>
                            <p>
                                <%# GetDescriptionText(Eval("Description").ToString()).ToString() %>
                                <a runat="server" href='<%# "~/column/cl3-" + Eval("ArticleId") %>' class="more-small">.....المزيد</a>
                            </p>
                        </div>
                        <div runat="server" class="social-wrapper">
                            <ul>

                                <li><a href="javascript:window.open('<%# GetGoogleLinkColumn(Eval("ArticleId").ToString()) %>','google_plus','height=400,width=640');" class="google2" onclick="window.open('<%# GetGoogleLink(Eval("ArticleId").ToString()) %>','google_plus','height=400,width=640'); return false;"></a></li>
                                <li><a href="javascript:void(0);" onclick="window.open('<%# GetTwitterLinkColumn(Eval("ArticleId").ToString()) %>','twitter','height=250,width=640'); return false;" class="tweet2"></a></li>
                                <li><a href="javascript:window.open('<%# GetFacebookLinkColumn(Eval("ArticleId").ToString()) %>','facebook','height=400,width=640');" class="facebook2"></a></li>
                            </ul>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</div>
