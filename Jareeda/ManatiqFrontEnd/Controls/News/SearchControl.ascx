<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchControl.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.SearchControl" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<div runat="server" id="MainBlockContainer" class="block-news">
				<div class="block-head">
					<h1 runat="server" id="ModuleTitleText">بحث</h1>
				</div>
				<div class="txt-wrapper clear">
                    <dx:ASPxDataView ID="ImportantNewsRepeater" runat="server" ColumnCount="1" EnableDefaultAppearance="False" ItemSpacing="0px" RowPerPage="20" Width="100%" Height="100%" RightToLeft="True">
                        <ItemTemplate>
                            <div class="block-small">
						<div class="img-wrapper">
							<a href="#"><img runat="server" width="182" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ArticleAttachment"))) %>' /></a>
						</div>
						<div class="block-text-wrapper">
							<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h2><%# Eval("ArticleName").ToString() %></h2></a>
							
                           <p>
                               <%# Eval("ArticleDescription").ToString() %>
                                <a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>' class="more-small">.....المزيد</a></p>
						</div>
						
					</div>
                        </ItemTemplate>
                       
                        <EmptyDataTemplate>
                            لا يوجد نتائج لهذا البحث
                        </EmptyDataTemplate>
                    </dx:ASPxDataView>
                    
					
					
					
					
					
				</div>
			</div>