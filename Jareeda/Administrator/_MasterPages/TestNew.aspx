<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestNew.aspx.cs" Inherits="Administrator._MasterPages.TestNew" %>

<%@ Register Src="~/Controls/Common/BootstrapMenu.ascx" TagName="MainMenuControl" TagPrefix="natiq" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jareeda</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="/App_Themes/Evento/application.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="main-container">
        <natiq:MainMenuControl runat="server" />
        <div>
            <div class="header-control-box">
            </div>
            <div class="box-container">

            </div>
        </div>
        <footer class="footer">
            <div class="pull-left">
                <img src="/App_Themes/Evento/images/jareeda.png" height="40" />
                System Version 2.0</div>
            <div class="pull-right">powered by 
                <img src="/App_Themes/Evento/images/logo-wide-small.png" height="40" /></div>

        </footer>
        <div>
        </div>
    </form>
    <script src="/Assets/JS/jquery-1.10.2.min.js"></script>
    <script src="/Assets/JS/bootstrap.min.js"></script>
</body>
</html>
