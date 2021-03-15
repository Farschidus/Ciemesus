<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="Pages_RSS_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagName="PageMedia" TagPrefix="uc2" %>
<%@ Register Src="~/Client/Ascx/PagePlugin.ascx" TagName="PagePlugin" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script>
        $(document).ready(function () {
            $('#Content').css('background', 'transparent url(/Client/User_Files/RTE/bg.jpg) no-repeat center 200px');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <div id="Banner">
        <div id="ctl00_ctl00_cphMainMaster_cphHeadContent_pageBanner_uplBanner">
            <asp:Image runat="server" id="imgPageBanner" class="img-responsive" style="border-width: 0px;" align="absmiddle" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
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
</asp:Content>
