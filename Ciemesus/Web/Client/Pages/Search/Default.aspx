﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="Pages_Search_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <uc1:PageBanner ID="pageBanner" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <div id="Body">
        <div class="container">
            <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="searchInput form-control rounded-end pe-5 default-value w-100" Style="height: 35px;"></asp:TextBox>
                <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="searchButton btn">
                     <%= Farschidus.Translator.AppTranslate["general.button.search"]%>
                </asp:LinkButton>
            </asp:Panel>
            <asp:Literal ID="litBody" runat="server" />
        </div>
    </div>
</asp:Content>
