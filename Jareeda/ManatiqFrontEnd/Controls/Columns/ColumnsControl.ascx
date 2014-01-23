<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ColumnsControl.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Columns.ColumnsControl" %>
<div runat="server" id="MainBlockContainer" class="aside-block">
					<div class="aside-block-head">
						<h1 runat="server" id="ModuleTitleText"></h1>
					</div>
                <asp:Repeater runat="server" ID="LayoutRepeater">
                    <HeaderTemplate>
                        <div class="aside-block-content adjst-block_new">
                            <div class="bx-wrapper">
                                <div class="bx-viewport">


                               
						<ul class="bxslider4">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="vote_writers_right">
                                    <a runat="server" href='<%# "~/column/cl3-" + Eval("ArticleId") %>'>
                                        <h2><%# Eval("ArticleName").ToString() %></h2>
                                    </a>
                                    	<img width="65" runat="server"  src='<%# GetWriterImagePath(Eval("AuthorImage").ToString()) %>' alt="" />
                                <a runat="server" href='<%# "~/columnist/cl8-" + Eval("AuthorId") %>'><%# Eval("Author") %></a>
                                  <%--  <a href="#" class="date-artical2">
                                    	<%# GetDate(Convert.ToDateTime(Eval("PostDate").ToString())) %>
                                    </a>--%>
                                	
                            	</div>
                            	<%--<div class="vote_writers_left">
                                
                                </div>--%>
                                
                            </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </div>
                         </div>
                        
                            </div>
                    </FooterTemplate>
                </asp:Repeater>
					
				</div>
				