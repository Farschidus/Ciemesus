<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Login_Default" Title="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Control Panel Login Page</title>
    <link type="text/css" rel="Stylesheet" href="/Client/Styles/login.css" />
</head>
<body>
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
                        <table cellpadding="0" cellspacing="0" style="border-collapse: collapse; width: 250px;">
                            <tr>
                                <td>
                                    <table cellpadding="0">
                                        <tr>
                                            <td align="center" style="color: #ff4d5b;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                           <%-- <td align="right" style="width: 65px">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"><%= Farschidus.Translator.AppTranslate["login.default.label.userName"]%></asp:Label>
                                            </td>--%>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server" CssClass="loginTextBox username"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl10">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"><%= Farschidus.Translator.AppTranslate["login.default.label.password"]%></asp:Label>
                                            </td>--%>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="loginTextBox password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl10">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" ValidationGroup="ctl10"
                                                    CssClass="login" Text="Login"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </LayoutTemplate>
            </asp:Login>
            </form>
        </div>
            
    </div>
    <div id="developer">
        <span>Developed by <a target="_blank" href="http://Farschidus.com">Farschidus</a></span></div>
</body>
</html>
