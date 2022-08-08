<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListAndDateFilter.ascx.cs"
    Inherits="Client_Ascx_ListAndDateFilter" %>
<div id="ListAndDateFilter">
    <span class="titleListAndDateFilter"><%= Farschidus.Translator.AppTranslate["ascx.listAndDateFilter.lable.category"]%></span>
    <span class="itemListAndDateFilter"><asp:Literal ID="litCategories" runat="server" /></span>
    <br />
    <span class="titleListAndDateFilter"><%= Farschidus.Translator.AppTranslate["ascx.listAndDateFilter.lable.date"]%></span>
    <span class="itemListAndDateFilter"><asp:Literal ID="litDates" runat="server" /></span>
</div>
