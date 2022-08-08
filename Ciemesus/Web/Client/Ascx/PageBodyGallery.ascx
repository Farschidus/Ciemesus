<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageBodyGallery.ascx.cs" Inherits="Client_Ascx_PageBodyGallery" %>
<asp:UpdatePanel ID="uplMedia" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Repeater ID="rptMedia" runat="server">
            <HeaderTemplate>
                <div id="MediaBar">
                    <div class="SideBar">
                        <h3 class="SideBar-title">
                            <%= Farschidus.Translator.AppTranslate["general.message.media.title"]%></h3>
                        <div class="SideBar-content">
                            <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><a target="_blank" href='<%# mGetUrl(Eval("IDMedia").ToString(), Eval("FileExtention").ToString()) %>'>
                    <%# Eval("FileName")%>&nbsp;&nbsp;<%# Eval("Description") %> </a></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></div></div></div>
            </FooterTemplate>
        </asp:Repeater>
    </ContentTemplate>
</asp:UpdatePanel>
