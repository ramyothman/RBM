<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Urgent.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.Urgent" %>

<div runat="server" class="emergency">
    <h1 runat="server" id="ModuleTitleText"></h1>
    <div runat="server"  id="UrgentNewsItems" style="width:90%;" >
<asp:Repeater runat="server" ID="UrgentNewsRepeater">
    
   
    <ItemTemplate>
        
            <div>
			<img runat="server" width="77" height="41" src='<%# BusinessLogicLayer.Common.NewsImages + Eval("ImagePath") %>' visible='<%# Convert.ToBoolean(Eval("HasImage").ToString()) %>' alt="" />
			<a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'><%# Eval("ArticleName").ToString() %></a>	
        </div>
    </ItemTemplate>
  
</asp:Repeater>
        </div>
</div>
