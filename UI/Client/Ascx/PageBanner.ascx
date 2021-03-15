<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageBanner.ascx.cs" Inherits="Client_Ascx_PageBanner" %>
<asp:UpdatePanel ID="uplBanner" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Repeater ID="rptGallery" runat="server" EnableViewState="false">
            <HeaderTemplate>
                <div class="slides_container">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="slide">
                    <img class="img-responsive" alt="<%# Eval("FileName")%>" src="<%# Eval("FilePath")%>">
                    <%# mGenerateImageInfo(Eval("FileName").ToString(), Eval("Description").ToString(), Convert.ToDateTime(Eval("Date"))) %>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Image ID="imgPageBanner" runat="server" ImageAlign="AbsMiddle" Visible="false" class="img-responsive" />
        <asp:Literal ID="litJS" runat="server"></asp:Literal>
        <asp:Literal ID="litCSS" runat="server"></asp:Literal>
    </ContentTemplate>
</asp:UpdatePanel>
