<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>
<html lang="en">
<head id="head1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="author" content="Farschidus">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="<%= Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Metatags", "Description", "langCode", Global.MethodsAndProps.CurrentLanguageCode) %>" />
    <meta name="keywords" content="<%= Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Metatags", "KeyWords", "langCode", Global.MethodsAndProps.CurrentLanguageCode) %>" />
    <link type="image/x-icon" rel="shortcut icon" href="/Client/Images/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="/client/static/dist/css/spa.min.css?<%= DateTime.UtcNow.ToString("yyyyMMddHHmmss") %>" />
</head>
<body id="page-top" class="index">
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button aria-expanded="false" type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">
                    <img src="Client/Images/Public/Logo.png" /></a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div style="height: 0.8px;" aria-expanded="false" class="navbar-collapse collapse" id="bs-example-navbar-collapse-1">
                <%= mGenerateNavbar()%>
            </div>
            <!-- /.navbar-collapse -->
        </div>
    </nav>
    <header>
        <asp:Literal ID="litHeader" runat="server" />
    </header>
    <asp:Literal ID="litSections" runat="server" />
    <footer>
        <asp:Literal ID="litFooter" runat="server" />
    </footer>
    <script type="text/javascript" src="/client/static/dist/js/spa.min.js?<%= DateTime.UtcNow.ToString("yyyyMMddHHmmss") %>"></script>
    <asp:Literal ID="litScripts" runat="server" />
</body>
</html>
