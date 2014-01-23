<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PollResult.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Forms.PollResult" %>
<div class="contentWhiteBg" >
      
						<h2 runat="server" id="QuestionTitle" ></h2>
					
        <strong>عدد الأصوات <asp:Literal ID="LtrlVotesCounter" runat="server"></asp:Literal></strong>
        
        <br />
        <br />
        <asp:Repeater ID="RptrResult" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <%# Eval("FieldValue") %>
                    <br />
                    <div style="font-size: small">
                        <img runat="server" id="percentImage" alt="" src="" height="11" />
                        <asp:Literal ID="LtrlPercent" runat="server"></asp:Literal>
                        %
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>