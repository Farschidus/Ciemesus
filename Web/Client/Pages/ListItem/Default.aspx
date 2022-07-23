<%@ Page Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="Pages_ListItem_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagName="PageMedia" TagPrefix="uc2" %>
<%@ Register Src="~/Client/Ascx/PagePlugin.ascx" TagName="PagePlugin" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <uc1:PageBanner ID="pageBanner" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="Server">
    <section id="PageTitle">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <a class="backToList" href="javascript:history.back()">
                        <%= Farschidus.Translator.AppTranslate["list.page.default.backToList"]%>
                    </a>
                </div>
                <div class="col-md-12">
                    <h1>
                        <asp:Literal ID="litPageTitle" runat="server"></asp:Literal>
                    </h1>
                </div>
            </div>
        </div>
    </section>
    <div id="Body">
        <div class="container">
            <asp:Literal ID="litBody" runat="server" />
            <asp:Literal ID="litAddedFiles" runat="server" />
        </div>
    </div>
    <uc2:PageMedia ID="pageMedia" runat="server" />
    <uc3:PagePlugin ID="pagePlugin" runat="server" />
</asp:Content>
