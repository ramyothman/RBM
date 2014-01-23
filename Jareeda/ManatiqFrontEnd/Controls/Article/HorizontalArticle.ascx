<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HorizontalArticle.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Article.HorizontalArticle" %>
<div runat="server" id="MainBlockContainer" class="block-news">
    <div runat="server" id="TitleDiv" visible="false" class="block-head">

    </div>
    <asp:Repeater runat="server" ID="ImportantNewsRepeater">
                                <HeaderTemplate>
                         <div class="txt-wrapper" style="direction:rtl;font-family:'Sakkal_Majalla_mac','Helvetica-Neue', Helvetica, sans-serif;background: #f7f7f7;
border-color: #c8c8c8;font-size: 18px;line-height: 27px;">
                                </HeaderTemplate>
                        <ItemTemplate>
                            <a runat="server" style="text-decoration:none;" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h3 style="text-align:right;margin-top:20px;margin-right:10px;"><%# Eval("ShortTitle").ToString() %></h3></a><div class="clearfix"></div>
                               <a class="example-image-link" title='<%# Eval("ShortTitle").ToString() %>' href='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>'  data-lightbox='<%= this.ClientID.ToString() %>'><img runat="server" width="182" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' style="float:right;text-align:center;margin:10px;border: 1px solid #dedede;padding:2px;" alt="" /></a><div style="padding:10px;"><%# Eval("Description").ToString() %> <a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>' class="more-small">.....المزيد</a></div> 
                        </ItemTemplate>
                                <FooterTemplate>
                                    </div>          
                                </FooterTemplate>
                    </asp:Repeater>
			
		</div>