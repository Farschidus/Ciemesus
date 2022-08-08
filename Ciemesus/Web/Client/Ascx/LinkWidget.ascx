<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkWidget.ascx.cs" Inherits="Client_Ascx_LinkWidget" %>
<div class="Widget">
    <h3 class="Widget-title"><asp:Label ID="lblTitle" runat="server"></asp:Label></h3>
    <div class="Widget-content">
        <asp:Literal ID="litWidget" runat="server"></asp:Literal>
    </div>
    <div class="Widget-footer"></div>
</div>