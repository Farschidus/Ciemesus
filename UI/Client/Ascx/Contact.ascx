<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contact.ascx.cs" Inherits="Client_Ascx_Contact" %>
<div class="container">
    <div class="row">
        <div class="col-md-6">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d17069.514748195197!2d12.064713249999999!3d57.67076414999999!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x464ff17af66de73f%3A0x8d6906f098434ade!2sHeleneviksv%C3%A4gen%2037%2C%20431%2036%20M%C3%B6lndal!5e0!3m2!1sen!2sse!4v1615833022037!5m2!1sen!2sse" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
        </div>
        <div class="col-md-6">
            <asp:UpdatePanel ID="uplContact" runat="server">
                <ContentTemplate>
                    <div class="form-horizontal">
                        <div class="form-group row">
                            <label class="col-sm-4 control-label font-weight-bold">
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            </label>
                            <div class="col-sm-8"></div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 control-label text-right font-weight-bold"><%= Farschidus.Translator.AppTranslate["ascx.contact.lable.phone"]%></label>
                            <div class="col-sm-10">
                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 control-label text-right font-weight-bold"><%= Farschidus.Translator.AppTranslate["ascx.contact.lable.fax"]%></label>
                            <div class="col-sm-10">
                                <asp:Label ID="lblFax" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 control-label text-right font-weight-bold"><%= Farschidus.Translator.AppTranslate["ascx.contact.lable.email"]%></label>
                            <div class="col-sm-10">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 control-label text-right font-weight-bold"><%= Farschidus.Translator.AppTranslate["ascx.contact.lable.address"]%></label>
                            <div class="col-sm-10">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-group row">
                            <label class="col-sm-12 control-label">
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                    ControlToValidate="txtEmail" ValidationGroup="ContactGroup"></asp:RegularExpressionValidator>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </label>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 control-label text-right font-weight-bold"><%= Farschidus.Translator.AppTranslate["ascx.contact.lable.department"]%></label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlType" runat="server" class="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 control-label text-right font-weight-bold">
                                <%= Farschidus.Translator.AppTranslate["ascx.contact.lable.name"]%>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"
                                    ValidationGroup="ContactGroup"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ValidationGroup="ContactGroup"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 control-label text-right font-weight-bold">
                                <%= Farschidus.Translator.AppTranslate["ascx.contact.lable.senderEmail"]%>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"
                                    ValidationGroup="ContactGroup"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="ContactGroup"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 control-label text-right font-weight-bold">
                                <%= Farschidus.Translator.AppTranslate["ascx.contact.lable.body"]%>
                                <asp:RequiredFieldValidator ID="rfvBody" runat="server" ErrorMessage="*" ControlToValidate="txtBody"
                                    ValidationGroup="ContactGroup"></asp:RequiredFieldValidator>
                            </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" CssClass="form-control" ValidationGroup="ContactGroup"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-success" ValidationGroup="ContactGroup">
                                        <%= Farschidus.Translator.AppTranslate["ascx.contact.button.send"]%>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
