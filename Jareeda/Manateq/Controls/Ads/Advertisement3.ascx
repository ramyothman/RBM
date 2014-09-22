<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Advertisement3.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Ads.Advertisement3" %>
<div class="ads5">
				  <asp:Repeater runat="server" ID="ImportantNewsRepeater">
                                <HeaderTemplate>
                                   
                                </HeaderTemplate>
                        <ItemTemplate>
                            
                                <%# Eval("ArticleContent").ToString() %>
                            
                      
                        </ItemTemplate>
                                <FooterTemplate>

                                </FooterTemplate>
                    </asp:Repeater>
			</div>