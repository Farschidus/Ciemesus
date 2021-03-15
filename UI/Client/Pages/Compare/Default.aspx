<%@ Page Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Compare_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagName="PageMedia" TagPrefix="uc2" %>
<%@ Register Src="~/Client/Ascx/PagePlugin.ascx" TagName="PagePlugin" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/javascript" src="/Application/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function lookUpForCompare() {
            var a = $('#<%= txtSearchAndCompare.ClientID %>').val().trim();
            if (a.length > 2) {
                $.ajax({
                    type: "POST",
                    url: '/Client/Pages/Compare/Default.aspx/GetGroupItems',
                    data: "{'prefixText':'" + a + "', 'subjectID':'" + $('#<%= hdfGroupID.ClientID %>').val().trim() + "', 'langID':'" + $('#<%= hdfLang.ClientID %>').val().trim() + "'}",
                    processData: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (b) {
                        if (b != null) {
                            $("#comparelookup .suggestions").html(b.d);
                        }
                    },
                    error: function (d, b, c) {
                        alert("Error: " + c);
                    }
                });
                $("#comparelookup").fadeIn();
            }
            else {
                $("#comparelookup").fadeOut();
            }
        };
        $('html').click(function () {
            if (!$('.suggestions').is(':hidden')) {
                $('.suggestions').hide();
            }
        });        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
    <uc1:PageBanner ID="pageBanner" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMain" runat="Server">
    <uc2:PageMedia ID="pageMedia" runat="server" />
    <asp:UpdatePanel ID="uplItemView" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div id="Body">
                <div id="SearchAndCompare">
                    <asp:TextBox ID="txtSearchAndCompare" runat="server" onkeyup="lookUpForCompare()" AutoComplete="off"></asp:TextBox>
                </div>
                <div id="comparelookup" style="display: none;">
                    <ul class="suggestions"></ul>
                </div>
                <asp:HiddenField ID="hdfGroupID" runat="server" />
                <asp:HiddenField ID="hdfLang" runat="server" />
                <br />
                <div id="itemsContainer">
                    <asp:Literal ID="litBody" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc3:PagePlugin ID="pagePlugin" runat="server" />
</asp:Content>
