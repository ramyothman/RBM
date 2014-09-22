<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Advertisement1.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Ads.Advertisement1" %>
<div runat="server" class="ads3">
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