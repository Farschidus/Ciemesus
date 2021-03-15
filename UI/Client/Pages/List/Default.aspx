<%@ Page Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_List_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagName="PageMedia" TagPrefix="uc2" %>
<%@ Register Src="~/Client/Ascx/PagePlugin.ascx" TagName="PagePlugin" TagPrefix="uc3" %>
<%@ Register Src="~/Client/Ascx/ListGroups.ascx" TagName="ListGroups" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ItemView').hide();
            $(document).on("click", 'span.ReturnToList', function () {
                $('#ItemView').fadeOut('fast', function () { $('#List').fadeIn('fast'); });
                $('#<%= uplItemView.ClientID %>').html("");
                $('#BannerContainer').html("");
            });
            $(document).on('click', '#List a', function () {
                $('#List').fadeOut('fast', function () { $('#ItemView').fadeIn('fast'); });
            });
            $('#List div.List-ItemDataGrid').hover(function () {
                $(this).find('div.List-ItemBodyGrid').stop().animate({ 'top': '180px' }, 300);
            }, function () {
                $(this).find('div.List-ItemBodyGrid').stop().animate({ 'top': '212px' }, 300);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <uc3:PagePlugin ID="pagePluginForList" runat="server" />
    <uc1:PageBanner ID="pageBanner" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="Server">
    <div id="List">
        <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <section id="PageTitle">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <h1>
                                    <asp:Literal ID="litPageTitle" runat="server"></asp:Literal>
                                </h1>
                            </div>
                        </div>
                    </div>
                </section>
                <section id="Body">
                    <div class="container">
                        <asp:Literal ID="litBody" runat="server" />
                    </div>
                </section>
                <%--<uc4:ListGroups runat="server" ID="listGroups" GenerateAjaxUrl="true" />--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="ItemView">
        <uc2:PageMedia ID="pageMedia" runat="server" />
        <asp:UpdatePanel ID="uplItemView" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="ListItemBanner">
                    <div class="container">
                        <uc1:PageBanner ID="itemBanner" runat="server" />
                    </div>
                </div>
                <section id="ItemTitle">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-2">
                                <span class="ReturnToList"><%= Farschidus.Translator.AppTranslate["list.page.default.backToList"] %>&nbsp;<i class="glyphicon <%= Farschidus.Translator.AppTranslate["list.page.default.backToList.arrow"] %>" aria-hidden="true"></i></span>
                            </div>
                            <div class="col-md-10">
                                <h1>
                                    <asp:Literal ID="litItemTitle" runat="server"></asp:Literal>
                                </h1>
                            </div>
                        </div>
                    </div>
                </section>
                <div id="ItemBody">
                    <div class="container">
                        <div class="listItemCoverinBody">
                            <asp:Literal ID="litCoverImage" runat="server" />
                        </div>
                        <asp:Literal ID="litItemBody" runat="server" />
                        <asp:Literal ID="litAttachments" runat="server"></asp:Literal>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <uc3:PagePlugin ID="pagePlugin1" runat="server" />
</asp:Content>
