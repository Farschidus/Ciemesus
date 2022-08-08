<%@ Page Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Pages_PageList_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagName="PageMedia" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#backPages').hide();
        });
        var $left = -250;
        var LastItem = [];
        var isFirst = true;
        function next(sender) {
            originUL = $(sender).parent().parent();
            tragetUL = $(sender).next();
            tragetUL.show();
            originUL.animate({ left: $left });
            if (isFirst) {
                $left = $left + 250;
                isFirst = false;
                $('#backPages').slideToggle('fast');
            }
            LastItem.push(originUL);
        }
        function prev() {
            if (LastItem.length > 0) {
                var last = LastItem[LastItem.length - 1];
                if (LastItem.length > 1) {
                    LastItem[LastItem.length - 1].animate({ left: 250 }, function () { last.find("ul").hide(); });
                }
                else {
                    isFirst = true;
                    $left = -250;
                    LastItem[LastItem.length - 1].animate({ left: 0 }, function () { last.find("ul").hide(); });
                    $('#backPages').slideToggle('fast');
                }
                LastItem.pop(LastItem.length - 1)
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <uc1:PageBanner ID="pageBanner" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="Server">
    <div id="relatedPages">
        <h3><%= Farschidus.Translator.Translate("page.default.pageList.title")%></h3>
        <div id="backPages">
            <a href="#" onclick="prev(this)">&lt;&lt; Back</a>
        </div>
        <ul style="display: block; left: 0">
            <asp:Literal ID="litRelatedPages" runat="server"></asp:Literal>
        </ul>
    </div>
    <uc2:PageMedia ID="pageMedia" runat="server" />
    <asp:UpdatePanel ID="uplItemView" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="Body">
                <asp:Literal ID="litBody" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
