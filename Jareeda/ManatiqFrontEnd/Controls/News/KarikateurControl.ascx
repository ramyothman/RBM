<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KarikateurControl.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.KarikateurControl" %>
<div runat="server" id="MainBlockContainer" class="aside-block-head">
						<h1 runat="server" id="ModuleTitleText"></h1>
					</div>
					<div class="aside-block-content commics">
						<div class="slider">
                             <ul runat="server" id="KarikateurNewsItems" class="bxslider3">
                            <asp:Repeater runat="server" ID="ImportantNewsRepeater">
                                <HeaderTemplate>
                                   
                                </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <%# Eval("ArticleContent").ToString() %>
                            </li>
                      
                        </ItemTemplate>
                                <FooterTemplate>

                                </FooterTemplate>
                    </asp:Repeater>
							
							</ul>	
								
						</div>
					</div>
				