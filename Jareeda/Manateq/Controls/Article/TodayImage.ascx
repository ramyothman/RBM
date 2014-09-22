<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TodayImage.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Article.TodayImage" %>
<div runat="server" id="MainBlockContainer" class="aside-block">
    <div runat="server" id="TitleDiv" visible="false" class="aside-block-head">

    </div>
    <asp:Repeater runat="server" ID="ImportantNewsRepeater">
                                <HeaderTemplate>
                         <div class="aside-block-content" style="direction:rtl;font-family:'Sakkal_Majalla_mac','Helvetica-Neue', Helvetica, sans-serif;background: #f7f7f7;
border-color: #c8c8c8;font-size: 18px;line-height: 27px;">
                                </HeaderTemplate>
                        <ItemTemplate>
                            <%--<a runat="server" style="text-decoration:none;" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h3 style="text-align:center;margin-top:20px;"><%# Eval("ShortTitle").ToString() %></h3></a><div class="clearfix"></div>--%>
                               <a class="example-image-link" title='<%# Eval("ShortTitle").ToString() %>' href='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>'  data-lightbox='<%= this.ClientID.ToString() %>'><img runat="server" width="325" height="250" src='<%#  GetImagePath(Convert.ToString(Eval("ImagePath"))) %>' style="text-align:center;margin-right: -5px;border: 1px solid #dedede;" alt="" /></a>
                            
                            <div class="overlayImage"><%# Eval("ShortTitle").ToString() %></div>
                            
                            
                        </ItemTemplate>
                                <FooterTemplate>
                                    </div>          
                                </FooterTemplate>
                    </asp:Repeater>
			
		</div>