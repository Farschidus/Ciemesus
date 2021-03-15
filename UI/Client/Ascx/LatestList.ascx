<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LatestList.ascx.cs" Inherits="Client_Ascx_LatestList" %>
<div class="SideBar">
    <h3 class="SideBar-title">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
        <a href="#" id="ticker-previous"></a> <a href="#" id="ticker-next"></a>
    </h3>
    <div class="SideBar-content">
        <asp:Repeater ID="rptSidebar" runat="server" >
        <HeaderTemplate>
            <ul class="SideBar-SlideContainer">
        </HeaderTemplate>
        <ItemTemplate>
            <li class="item">
                <a href='<%# mGetURL(Eval("alias").ToString()) %>'>
                    <img class='item-Image' src='<%# mGetCoverImage(Eval("IDSubject").ToString()) %>' width="225" height="190"></img><br />                    
                    <span class="item-title"><%# Eval("Title") %></span>
                </a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
         </ul>
        </FooterTemplate>
    </asp:Repeater>
    </div>
    <div class="SideBar-footer">
    </div>
</div>