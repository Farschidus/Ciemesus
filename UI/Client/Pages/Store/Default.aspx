<%@ Page Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Store_Default" %>

<%@ Register Src="~/Client/Ascx/PageBanner.ascx" TagName="PageBanner" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Ascx/PageMedia.ascx" TagName="PageMedia" TagPrefix="uc2" %>
<%@ Register Src="~/Client/Ascx/PagePlugin.ascx" TagName="PagePlugin" TagPrefix="uc3" %>
<%@ Register Src="~/Client/Ascx/ListGroups.ascx" TagName="ListGroups" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/javascript">
        function togglePopUp(panelId, uplItemViewClientID, iDSubject, doPostbak) {
            $('#' + panelId).toggleClass('ModalOpen');
            if (doPostbak) {
                __doPostBack(uplItemViewClientID, iDSubject);
            }
            else {
                $(".ItemBody").html("");
                $("#<%= litItemTitle.ClientID%>").html("");
            }
        }
        function closePopup() {
            $('#StoreItemView').removeClass('ModalOpen');
            $(".ItemBody").html("");
            $("#<%= litItemTitle.ClientID%>").html("");
            showMiniCard();
        }
        function showMiniCard() {
            $(".miniCard").before("<div class='curtain'></div>");
            $(".curtain").bind("click", function () { closeMiniCart(); });
            $(".miniCard").addClass('active');
        }
        function closeMiniCart() {
            $(".curtain").remove();
            $(".miniCard").removeClass('active');
        }
        function farschidus(val) {
            $('#<%=hfdQuantity.ClientID%>').val(val);
        }
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
                                    <a style="display: inline-block; float: left; font-size: 16px;" class="btn btn-primary" href="javascript:showMiniCard()"><i class="glyphicon glyphicon-shopping-cart" style="top: 4px; margin-left: 7px;"></i>نمایش سبد خرید</a>
                                </h1>
                            </div>
                        </div>
                    </div>
                </section>
                <section id="Body">
                    <div class="container">
                        <asp:Literal ID="litDesc" runat="server" />
                        <asp:DropDownList ID="ddlGroups" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true"
                            OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Literal ID="litBody" runat="server" />
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="StoreItemView">
        <asp:UpdatePanel ID="uplItemView" runat="server" UpdateMode="Conditional" class="Popup">
            <ContentTemplate>
                <div class="ItemHeader">
                    <span>
                        <asp:Literal ID="litItemTitle" runat="server"></asp:Literal></span>
                    <a class="close" href="javascript:togglePopUp('StoreItemView','','',false)"><span></span></a>
                </div>
                <div class="ItemBody">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-4 pull-right text-center">
                                <asp:Literal ID="litAttachments" runat="server"></asp:Literal>
                            </div>
                            <div class="col-md-8 pull-left">
                                <div class="attributes">
                                    <br />
                                    <span>نوع:</span>
                                    <asp:RadioButtonList ID="rblType" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CssClass="radios"
                                        OnSelectedIndexChanged="rblType_SelectedIndexChanged" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <asp:UpdatePanel ID="uplCapacity" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <span>حجم:</span>
                                            <asp:RadioButtonList ID="rblCapacity" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CssClass="radios"
                                                OnSelectedIndexChanged="rblCapacity_SelectedIndexChanged" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="uplPrice" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <span>قیمت:&nbsp;&nbsp;&nbsp;</span>
                                            <asp:Literal ID="litPrice" runat="server"></asp:Literal>
                                            <asp:Literal ID="litUnit" runat="server"></asp:Literal>
                                            <br />
                                            <span>تعداد:&nbsp;&nbsp;&nbsp;</span>
                                            <asp:Literal ID="litQuantity" runat="server"></asp:Literal>
                                            <asp:HiddenField ID="hfdQuantity" runat="server" />
                                            <br />
                                            <asp:Button ID="btnAddToBasket" runat="server" Text="افزودن به سبد خرید" CssClass="btn btn-primary"
                                                OnClick="btnAddToBasket_Click" Visible="false" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <uc3:PagePlugin ID="itemPlugin" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="uplMiniCard" runat="server" UpdateMode="Conditional" class="miniCard" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="miniCardHeader">
                <span><i class="glyphicon glyphicon-shopping-cart" style="top: 4px; margin-left: 7px;"></i>سبد خرید</span>
                <a class="close" href="javascript:closeMiniCart()"><span></span></a>
            </div>
            <div class="miniCardContent">
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
                <asp:Panel ID="pnlDetailed" runat="server" Visible="false" CssClass="form-horizontal">
                    <div class="form-group">
                        <label class="col-md-2 pull-right text-left">نام:</label>
                        <div class="col-md-10 pull-left text-right">
                            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-2 pull-right text-left">تلفن:</label>
                        <div class="col-md-10 pull-left text-right">
                            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-2 pull-right text-left">آدرس:</label>
                        <div class="col-md-10 pull-left text-right">
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:LinkButton ID="btnSend" runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnSend_Click"><i class="glyphicon glyphicon-send" style="top:4px;margin-left:7px;"></i>ارسال سفارش</asp:LinkButton>
                    </div>
                </asp:Panel>
            </div>
            <div class="miniCardFooter">
                <asp:LinkButton ID="btnCheckout" runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnCheckout_Click"><i class="glyphicon glyphicon-send" style="top:4px;margin-left:7px;"></i>ارسال سفارش</asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc3:PagePlugin ID="pagePlugin1" runat="server" />
</asp:Content>
