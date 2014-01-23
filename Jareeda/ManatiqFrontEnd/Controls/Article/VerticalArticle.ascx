<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VerticalArticle.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Article.VerticalArticle" %>
<div runat="server" id="MainBlockContainer" class="aside-block">
    <div runat="server" id="TitleDiv" visible="false" class="aside-block-head">

    </div>
    <asp:Repeater runat="server" ID="ImportantNewsRepeater">
                                <HeaderTemplate>
                         <div class="aside-block-content" style="direction:rtl;font-family:'Sakkal_Majalla_mac','Helvetica-Neue', Helvetica, sans-serif;background: #f7f7f7;
border-color: #c8c8c8;font-size: 18px;line-height: 27px;">
                                </HeaderTemplate>
                        <ItemTemplate>
                            <a runat="server" style="text-decoration:none;" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h3 style="text-align:center;margin-top:20px;"><%# Eval("ShortTitle").ToString() %></h3></a><div class="clearfix"></div>
                               <a class="example-image-link" title='<%# Eval("ShortTitle").ToString() %>' href='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>'  data-lightbox='<%= this.ClientID.ToString() %>'><img runat="server" width="300" height="140" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' style="text-align:center;margin:10px;border: 1px solid #dedede;" alt="" /></a> <div style="padding:10px;"><%# Eval("Description").ToString() %> <a runat="server" style='<%# GetDisplay(Convert.ToInt32(Eval("ArticleId"))) %>' href='<%# "~/ns2-" + Eval("ArticleId") %>' class="more-small">.....المزيد</a></div> 
                        </ItemTemplate>
                                <FooterTemplate>
                                    </div>          
                                </FooterTemplate>
                    </asp:Repeater>
			
		</div>