<%@ Page Title="افزودن نقش جدید" Language="C#" MasterPageFile="~/Application/Masters/CP.master"
    AutoEventWireup="true" CodeFile="AddRole.aspx.cs" Inherits="ControlP_UserManager_AddRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="Server">
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <h3>
        افزودن نقش کاربری جدید:
    </h3>
    <br />
    عنوان:
    <asp:TextBox runat="server" ID="NewRole"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" OnClick="AddRole" Text="ایجاد نقش" />
    <div runat="server" id="ConfirmationMessage" class="alert">
    </div>
    <hr />
    <h3>
        نقش‌های کاربری موجود:
    </h3>
    <table class="webparts">
        <tr>
            <td class="details" valign="top" style="width: 450px;">
                <br />
                <asp:GridView runat="server" ID="UserRoles" AutoGenerateColumns="false" CssClass="list"
                    AlternatingRowStyle-CssClass="odd" GridLines="none">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                عنوان</HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Role Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                تعداد کاربر</HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("User Count") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" OnCommand="DeleteRole" CommandName="DeleteRole"
                                    CommandArgument='<%# Eval("Role Name") %>' Text="حذف" OnClientClick="return confirm('Are you sure?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
