<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LatestList.ascx.cs" Inherits="Client_Ascx_LatestList" %>
<div class="SideBar">
    <h3 class="SideBar-header">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
    </h3>
    <div class="SideBar-content">
        <asp:Repeater ID="rptSidebar" runat="server" >
            <ItemTemplate>
                <div class="SideBar-item">
                    <a href='<%# mGetURL(Eval("alias").ToString()) %>'>
                        <img class='img-fluid SideBar-itemImage' src='<%# mGetCoverImage(Eval("IDSubject").ToString()) %>'></img>                   
                        <span class="SideBar-itemTitle"><%# Eval("Title") %></span>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="SideBar-footer">
    </div>
</div>