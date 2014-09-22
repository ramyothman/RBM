<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Advertisement2.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Ads.Advertisement2" %>
<div class="ads2">
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