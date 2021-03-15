<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AlphabetLinks.ascx.cs"
    Inherits="Application_Ascx_AlphabetLinks" %>
<asp:Repeater runat="server" ID="rptrAlphabetLinks" OnItemDataBound="DisableSelectedLink">
    <ItemTemplate>
        <asp:LinkButton CssClass="alphabetLink" runat="server" ID="link" Text="<%# Container.DataItem %>" CommandName="Filter"
            CommandArgument='<%# DataBinder.Eval(Container, "DataItem")%>' OnCommand="Select" />
    </ItemTemplate>
</asp:Repeater>
