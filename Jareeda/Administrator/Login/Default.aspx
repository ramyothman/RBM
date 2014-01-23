<%@ Page Theme="EventoLogin" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Login.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="wrapper">
	<div class="logo">
		<a href="#"><img id="Img1" runat="server" src="~/App_Themes/EventoLogin/images/logo.png" alt="Logo" width="662" height="208" /></a>
	</div>
	
    <asp:TextBox runat="server" ID="txtusername" Text="username" CssClass="login-input" onfocus="if(this.value=='username')this.value=''" onblur="if(this.value=='')this.value='username'"  ></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic"  runat="server" ErrorMessage="* Enter Username"
                    ControlToValidate="txtusername"></asp:RequiredFieldValidator>
		<%--<input type="text"  class="login-input" />--%>
        <asp:TextBox runat="server" ID="txtpassword" Text="password"  CssClass="login-input" onfocus="if(this.value=='password' || this.value=='username')this.value=''" onblur="if(this.value=='')this.value='password'" TextMode="Password" ></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic"  runat="server" ErrorMessage="* Enter Password"
                    ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
		<%--<input type="text" class="login-input" />--%>
        <asp:Button ID="btnLogin" CssClass="login-button" runat="server" OnClick="btnLogin_Click" Text="SIGN IN"/>
		<%--<input type="button" class="login-button"  value="Sign in"/>--%>
	
	<div class="clear"></div>
    <div id="ErrorsLogin" style="clear:both;">
        <asp:Label ID="lblError" runat="server" Text=""  ForeColor="#FFFFFF">
        </asp:Label>
    </div>
<%--	<p><a href="#" class="forget">Forget you password?</a></p>--%>
	<div class="footer"><p>2013 copyright . all rights reserved</p></div>
</div>

<%--<div id="loginWrap">
 <div id="loginMain">
  <div id="loginLogin"></div>
  <div id="loginhead"></div>
  <div id="loginform">
  
   <label><asp:TextBox runat="server" ID="txtusername" Text="username" CssClass="input" onfocus="if(this.value=='username')this.value=''" onblur="if(this.value=='')this.value='username'"  ></asp:TextBox> <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Enter Username"
                    ControlToValidate="txtusername"></asp:RequiredFieldValidator></label> 
  <label><asp:TextBox runat="server" ID="txtpassword"  CssClass="input" onfocus="if(this.value=='password')this.value=''" onblur="if(this.value=='')this.value='password'" TextMode="Password" ></asp:TextBox> <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Enter Password"
                    ControlToValidate="txtpassword"></asp:RequiredFieldValidator></label> 
   <label>
   <asp:Button ID="btnLogin" CssClass="button" runat="server" OnClick="btnLogin_Click" Text="SIGN IN"
            Width="60px">
        </asp:Button>
   <div id="ErrorsLogin" style="clear:both;>
        <asp:Label ID="lblError" runat="server" Text=""  ForeColor="#CC0000">
        </asp:Label>
    </div>
   <div class="list">
    <a href="#">forgot password?</a>
    <div class="space"></div>
   
  </div>
 </div>
</div>
</div>--%>


    </form>
</body>
</html>
