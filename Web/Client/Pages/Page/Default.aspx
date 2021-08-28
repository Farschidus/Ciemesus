<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="Pages_Page_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagName="PageMedia" TagPrefix="uc2" %>
<%@ Register Src="~/Client/Ascx/PagePlugin.ascx" TagName="PagePlugin" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#PageTitle").hide();
            $Clickables = $(".clickable");
            if ($Clickables.length > 0) {
                $Clickables.click(function () {
                    $('#' + $(this).attr("id") + 'Desc').addClass('ModalOpen');
                })
                $('.closee').click(function () {
                    $(this).parent().removeClass('ModalOpen');
                })
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <uc1:PageBanner ID="pageBanner" runat="server" />
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
            <uc2:PageMedia ID="pageMedia" runat="server" />
            <uc3:PagePlugin ID="pagePlugin" runat="server" />
        </div>
    </section>
</asp:Content>
