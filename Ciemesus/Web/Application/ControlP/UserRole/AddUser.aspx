<%@ Page Title="افزودن کاربر جدید" Language="C#" MasterPageFile="~/Application/Masters/CP.master"
    AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="ControlP_UserManager_AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="Server">
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <table>
        <tr>
            <td valign="top">
                <h3>
                    افزودن نقش به کاربر:
                </h3>
                <asp:CheckBoxList ID="UserRoles" runat="server" RepeatDirection="Horizontal" RepeatColumns="9" />
                <h3>
                    اطلاعات کاربر:
                </h3>
                <table>
                    <tr>
                        <td colspan="2">
                            فعال:<asp:CheckBox ID="isapproved" runat="server" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td dir="ltr">
                            <asp:TextBox ID="username" runat="server"></asp:TextBox>
                        </td>
                        <td dir="ltr" align="right">
                            Username:
                        </td>
                    </tr>
                    <tr>
                        <td dir="ltr">
                            <asp:TextBox ID="password" runat="server"></asp:TextBox>
                        </td>
                        <td dir="ltr" align="right">
                            Password:
                        </td>
                    </tr>
                    <tr>
                        <td dir="ltr">
                            <asp:TextBox ID="email" runat="server"></asp:TextBox>
                        </td>
                        <td dir="ltr" align="right">
                            Email:
                        </td>
                    </tr>
                    <tr>
                        <td dir="ltr">
                            <asp:TextBox ID="txtFirstNameEn" runat="server"></asp:TextBox>
                        </td>
                        <td dir="ltr" align="right">
                            First Name (English):
                        </td>
                    </tr>
                    <tr>
                        <td dir="ltr">
                            <asp:TextBox ID="txtLastNameEn" runat="server"></asp:TextBox>
                        </td>
                        <td dir="ltr" align="right">
                            Last Name (English):
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            نام (فارسی):
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstNamePe" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            نام خانوادگی (فارسی):
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastNamePe" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            توضیحات:
                        </td>
                        <td>
                            <asp:TextBox ID="comment" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr runat="server" id="trUnits">
                        <td>
                            واحد مربوط:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUnits" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="ConfirmationMessage" runat="server" style="color: #ff4e00; direction: ltr;
                                text-align: center">
                                <br />
                            </div>
                            <input type="submit" value="ایجاد" />&nbsp;
                            <input type="reset" value="شروع مجدد" />
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="MemberData" runat="server" DataObjectTypeName="System.Web.Security.MembershipUser"
                    SelectMethod="GetUser" UpdateMethod="UpdateUser" TypeName="System.Web.Security.Membership">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="username" QueryStringField="username" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
