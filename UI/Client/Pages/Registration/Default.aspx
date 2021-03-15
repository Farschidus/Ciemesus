<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true"
    ValidateRequest="true" CodeFile="Default.aspx.cs" Inherits="Pages_Registration_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script>
        $(function () {
            $("input[name='ctl00$ctl00$cphMainMaster$cphMain$rblActivityType']").on("click", function () {
                if ($(this).val() == 1)
                    $('span.descToChange').html('نوع محصول و سطح زیر کشت');
                if ($(this).val() == 2)
                    $('span.descToChange').html('توضیحات');
                if ($(this).val() == 3)
                    $('span.descToChange').html('نام مجموعه و زمینه فعالیت');
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <section id="Body">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1><asp:Literal ID="litPageTitle" runat="server"></asp:Literal></h1>
                </div>
                <div class="col-md-12">
                    <div id="Registration" style="width: 100%; text-align: center; margin-bottom: 40px;">
                        <asp:UpdatePanel ID="uplRegistration" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.username")%><sup>
                                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUserNameCreate" ValidationGroup="regGroup" /></sup>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtUserNameCreate" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                            <asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.password")%><sup>
                                                <asp:RequiredFieldValidator ID="rfvPasswordCreate" runat="server" ErrorMessage="*" ControlToValidate="txtPasswordCreate" ValidationGroup="regGroup" /></sup>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtPasswordCreate" TextMode="Password" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.repeatPassword")%><sup>
                                                <asp:RequiredFieldValidator ID="rfvRepeatPassword" runat="server" ErrorMessage="*" ControlToValidate="txtRepeatPassword" ValidationGroup="regGroup" /></sup>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtRepeatPassword" TextMode="Password" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                            <asp:CompareValidator ID="cmvPassword" runat="server" ErrorMessage="تکرار روز عبور مشابه پسورد نمی‌باشد"
                                                ValidationGroup="regGroup" ControlToValidate="txtRepeatPassword" ControlToCompare="txtPasswordCreate"></asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.AppTranslate["registration.page.default.gender"]%>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radios">
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.firstName")%><sup>
                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="*" ControlToValidate="txtFirstName" ValidationGroup="regGroup" /></sup>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control input-md"></asp:TextBox>                                            
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.lastName")%><sup>
                                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="*" ControlToValidate="txtLastName" ValidationGroup="regGroup" /></sup>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.email")%><sup>
                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="regGroup" /></sup>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email is incorrect"
                                                ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                ControlToValidate="txtEmail" ValidationGroup="regGroup"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.tel")%>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.mobile")%><sup>
                                                <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="*" ControlToValidate="txtMobile" ValidationGroup="regGroup" /></sup>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.state")%>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtState" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.city")%>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <%=Farschidus.Translator.Translate("registration.page.default.address")%>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-md" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 col-xs-4 pull-right text-left">
                                            <span class="descToChange"><%=Farschidus.Translator.Translate("registration.page.default.description")%></span>
                                        </label>
                                        <div class="col-md-10 col-xs-8 pull-left text-right">
                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control input-md" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-12 col-xs-12 text-center">
                                            <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-success" ValidationGroup="regGroup">
                                            <%= Farschidus.Translator.Translate("registration.page.button.register")%></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
