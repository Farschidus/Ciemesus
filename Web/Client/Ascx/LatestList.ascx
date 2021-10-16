<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LatestList.ascx.cs" Inherits="Client_Ascx_LatestList" %>
<div class="LatestList">
    <h3 class="LatestList-header">
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
    </h3>
    <div class="LatestList-content row">
        <asp:Repeater ID="rptSidebar" runat="server" >
            <ItemTemplate>
                <div class="col-md-3 col-sm-6 d-flex align-items-stretch my-2 px-1">
                  <div class="card w-100">
                    <a href='<%# mGetURL(Eval("alias").ToString()) %>'>
                        <asp:Literal ID="litDate" runat="server"></asp:Literal>
                        <img class="card-img-top" src='<%# mGetCoverImage(Eval("IDSubject").ToString()) %>' alt="<%# Eval("Title") %>"></img> 
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Title") %></h5>
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

