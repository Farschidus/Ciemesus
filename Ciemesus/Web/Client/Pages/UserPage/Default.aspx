<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="Pages_UserPage_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagName="PageMedia" TagPrefix="uc2" %>
<%@ Register Src="~/Client/Ascx/PagePlugin.ascx" TagName="PagePlugin" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <uc1:PageBanner ID="pageBanner" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <uc2:PageMedia ID="pageMedia" runat="server" />
    <div id="Body">
        <asp:Literal ID="litBody" runat="server" />
    </div>
    <uc3:PagePlugin ID="pagePlugin" runat="server" />
</asp:Content>
