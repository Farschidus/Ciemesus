<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LatestList.ascx.cs" Inherits="Client_Ascx_LatestList" %>
<div class="LatestList">
    <h2 class="LatestList-header">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
    </h2>
    <div class="LatestList-content row">
        <asp:Repeater ID="rptSidebar" runat="server">
            <ItemTemplate>
                <div class="<%= ItemClass %> d-flex align-items-stretch my-2 px-2">
                    <div class="card w-100">
                        <a href='<%# mGetURL(Eval("alias").ToString()) %>'>
                            <% if (ShowDate)
                            { %>
                            <h5><%# Eval("Date") %></h5>
                            <% } %>
                            <% if (ShowCoverImg)
                            { %>
                            <img class="card-img-top" src='<%# mGetCoverImage(Eval("IDSubject").ToString()) %>' alt="<%# Eval("Title") %>" />
                            <% } %>
                            <div class="card-body">
                                <h4 class="card-title"><%# Eval("Title") %></h4>
                                <% if (ShowDescription)
                                { %>
                                <p class="card-text"><%# mGetDescription(Eval("Body").ToString(), 300) %></p>
                                <% } %>
                            </div>
                        </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="LatestList-footer">
    </div>
</div>

