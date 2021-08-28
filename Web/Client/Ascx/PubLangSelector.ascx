<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PubLangSelector.ascx.cs" Inherits="Client_Ascx_PubLangSelector" %>

<asp:Literal ID="litLanguages" runat="server" Visible="false"></asp:Literal>
<asp:DropDownList ID="ddlLanguages" runat="server" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged">
</asp:DropDownList>