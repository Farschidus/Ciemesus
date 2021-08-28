<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Home_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagPrefix="uc1" TagName="PageBanner" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagPrefix="uc2" TagName="PageMedia" %>
<%@ Register Src="~/Client/Ascx/PagePlugin.ascx" TagPrefix="uc4" TagName="PagePlugin" %>
<%@ Register Src="~/Client/Ascx/LatestList.ascx" TagPrefix="uc1" TagName="LatestList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <uc1:PageBanner ID="pageBanner" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <uc2:PageMedia ID="pageMedia" runat="server" />
    <div id="Body">
        <div class="container">
            <asp:Literal ID="litBody" runat="server" />
        </div>
    </div>
    <div id="ProjectsWidget">
        <div class="container">
            <uc1:LatestList runat="server" ID="LatestList" Limit="3" SubjectType="Market_Sectors_and_Projects,پروژه_ها" />
        </div>
    </div>
    <uc4:PagePlugin ID="pagePlugin1" runat="server" />
</asp:Content>
