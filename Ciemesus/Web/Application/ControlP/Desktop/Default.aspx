<%@ Page Title="میزکار مدیر سایت" Language="C#" MasterPageFile="~/Application/Masters/CP.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ControlP_Desktop_Default" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <div style="margin: 20px">
        <p>
            <%= Farschidus.Translator.AppTranslate["desktop.default.message.welcome"]%>
        </p>
        <br />
        <%----%><asp:LinkButton ID="btnRegenerateIcon" runat="server" OnClick="btnRegenerateIcon_Click" CssClass="blueButton">
            <span><%= Farschidus.Translator.AppTranslate["desktop.default.button.regenThumbs"]%></span>
        </asp:LinkButton>
        <br />
        <p>
            <asp:Literal ID="litMembers" runat="server"></asp:Literal><br />
        </p>
    </div>
</asp:Content>