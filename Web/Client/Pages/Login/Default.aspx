<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Login_Default" Title="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Control Panel Login Page</title>
    <link type="text/css" rel="Stylesheet" href="/Client/static/dist/css/client.min.css?<%= System.Configuration.ConfigurationManager.AppSettings["Version"] %>" />
</head>
<body>
    <div id="LoginContainer">
        <div id="loginDistance">
        </div>
        <div id="body">
            <div id="logo">
            <span id="welcome">Welcom to<br /><span>Ciemesus</span></span>
            </div>        
            <div id="login" >
                <form id="form1" runat="server" style="padding-top:25px;">
                <asp:Login runat="server" DisplayRememberMe="False" ID="LoginControl" DestinationPageUrl="~/Application/ControlP/Desktop/"
                    OnLoggedIn="LoginControl_LoggedIn" >
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton">
                            <div class="form-group">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="UserName" runat="server" CssClass="loginTextBox username"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl10">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="loginTextBox password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl10">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" ValidationGroup="ctl10" CssClass="login" Text="Login"></asp:Button>
                            </div>
                            <%--<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"><%= Farschidus.Translator.AppTranslate["login.default.label.userName"]%></asp:Label>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"><%= Farschidus.Translator.AppTranslate["login.default.label.password"]%></asp:Label>--%>
                        </asp:Panel>
                    </LayoutTemplate>
                </asp:Login>
                </form>
            </div>
        </div>
        <div id="developer">
            <span>Developed by <a target="_blank" href="http://Farschidus.com">Farschidus</a></span>
        </div>
    </div>
</body>
</html>
