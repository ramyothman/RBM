<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedNews.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.RelatedNews" %>
<div runat="server" id="MainBlockContainer" class="block-news international">
    <div class="block-head">
        <h1 runat="server" id="ModuleTitleText"></h1>
        <a href="#" id="MoreLink" runat="server" visible="false" class="more_btn-head">المزيد</a>
    </div>
    <div class="txt-wrapper">

        <asp:Repeater runat="server" ID="LayoutNewsRepeater">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <ul class="international-list-small">

                    <li><a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'>
                        <div class="img-wrapper">
                            <img runat="server" width="120" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' alt="" />
                        </div>
                        <h2><%# Eval("ShortTitle").ToString() %></h2>
                    </a>
                    </li>
                </ul>
            </ItemTemplate>
            <FooterTemplate>
                <%--<a href='<%#  GetMoreLink() %>' runat="server" class="more_btn">المزيد</a>--%>
            </FooterTemplate>
        </asp:Repeater>






    </div>
</div>
