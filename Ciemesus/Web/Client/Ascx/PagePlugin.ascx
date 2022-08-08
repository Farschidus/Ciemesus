<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PagePlugin.ascx.cs" Inherits="Client_Ascx_PagePlugin" %>
<asp:UpdatePanel ID="uplPlugins" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Literal ID="litCSS" runat="server"></asp:Literal>
    </ContentTemplate>
</asp:UpdatePanel>
