<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="PSM_UserManager_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<%@ Register TagName="AlphabetLinks" Src="~/Application/Ascx/AlphabetLinks.ascx" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="cphHeader" runat="Server">
    <script type="text/javascript">
        var deleteConfirmMessage = '<%=Farschidus.Translator.AppTranslate["general.message.confirmDelete"]%>';
        var deleteConfirmButtons = { '<%=Farschidus.Translator.AppTranslate["general.button.ok"]%>': true, '<%=Farschidus.Translator.AppTranslate["general.button.cancel"]%>': false };
    </script>
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
    <div id="Search">
        <table width="840px" class="left ltr" style="display: inline-block;">
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["userManager.default.search.roles"]%>
                </td>
                <td class="left ltr">
                    <asp:DropDownList ID="ddlRoleSearch" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="--All Roles--" Value="" Selected="True" />
                    </asp:DropDownList>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["userManager.default.search.approval"]%>
                </td>
                <td class="left ltr">
                    <asp:DropDownList ID="ddlApprovalSearch" runat="server">
                        <asp:ListItem Text="--All statuses--" Value="" Selected="True" />
                        <asp:ListItem Text="Approved" Value="True" />
                        <asp:ListItem Text="Unapproved" Value="False" />
                    </asp:DropDownList>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["userManager.default.search.locked"]%>
                </td>
                <td class="left ltr">
                    <asp:DropDownList ID="ddlLockUsersSearch" runat="server">
                        <asp:ListItem Text="--All statuses--" Value="" Selected="True" />
                        <asp:ListItem Text="Unlocked" Value="False" />
                        <asp:ListItem Text="Locked out" Value="True" />
                    </asp:DropDownList>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["userManager.default.search.online"]%>
                </td>
                <td class="left ltr">
                    <asp:DropDownList ID="ddlOnlineUsersSearch" runat="server">
                        <asp:ListItem Text="--All statuses--" Value="" Selected="True" />
                        <asp:ListItem Text="Online" Value="True" />
                        <asp:ListItem Text="Offline" Value="False" />
                    </asp:DropDownList>
                </td>
                <td class="left rtl top">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search">
                        <%= Farschidus.Translator.AppTranslate["general.button.search"]%></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="9" class="alphabetLink center">
                    <%=Farschidus.Translator.AppTranslate["userManager.default.search.usernameFilter"]%>
                    <uc1:AlphabetLinks runat="server" ID="AlphabetLinkList" OnSelectedChanged="AlphabetLinkList_SelectedChanged" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="cphMain" runat="Server">
    <div id="List" style="direction: ltr;">
        <table style="margin: 10px auto; width: 95%;">
            <tr>
                <td align="left">
                    <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView gridViewLTR" DataKeyNames="ProviderUserKey" OnRowEditing="grvList_RowEditing"
                                OnRowDeleting="grvList_RowDeleting" EmptyDataText="There is no result.">
                                <Columns>
                                    <Farschidus:DragField ItemStyle-CssClass="gridDragHandler" />
                                    <Farschidus:CheckAllBoxField ID="chkList" ItemStyle-CssClass="gridCheckbox" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnUnlock" runat="server" CommandName="UnlockUser" OnCommand="UnlockUser"
                                                CssClass="gridUnlock" CommandArgument='<%# Eval("UserName") %>' Visible='<%# Convert.ToBoolean(Eval("IsLockedOut")) %>'></asp:LinkButton>
                                            <a id="btnLock" class="gridLock" style='<%# mGetVisibility(Eval("IsLockedOut")) %>'
                                                href="javascript:void(0)"></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%= Farschidus.Translator.AppTranslate["userManager.default.grid.fullName"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# mGetUSerFullName(Eval("ProviderUserKey")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%= Farschidus.Translator.AppTranslate["userManager.default.grid.userName"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("UserName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%= Farschidus.Translator.AppTranslate["userManager.default.grid.lastActivityDate"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Convert.ToDateTime(Eval("LastActivityDate")).ToShortDateString() %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%= Farschidus.Translator.AppTranslate["userManager.default.grid.changeActivation"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnInactiveUser" runat="server" CssClass="gridInactivate" OnCommand="UserActivity"
                                                CommandName="InactivateUser" CommandArgument='<%# Eval("UserName") %>' Visible='<%# (Convert.ToBoolean(Eval("IsApproved"))) && (Convert.ToString(Eval("UserName")).ToLower()!=Page.User.Identity.Name.ToLower()) %>'></asp:LinkButton>
                                            <asp:LinkButton ID="btnActive" runat="server" CssClass="gridActivate" OnCommand="UserActivity"
                                                CommandName="ActivateUser" CommandArgument='<%# Eval("UserName") %>' Visible='<%# (!Convert.ToBoolean(Eval("IsApproved"))) %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <%= Farschidus.Translator.AppTranslate["userManager.default.grid.changePassword"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnChangePassword" runat="server" CommandName='<%# Eval("UserName") %>'
                                                CssClass="gridChangePassword" OnCommand="ChangePassword"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="edit">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["userManager.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="delete">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["userManager.default.grid.delete"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteRow" runat="server" CommandName="Delete" CssClass="gridDelete"
                                                OnClientClick="return Farschidus.confirmDelete(this ,deleteConfirmMessage, deleteConfirmButtons);"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Farschidus:GridView>
                            <Farschidus:Pager ID="listPager" runat="server" PageSize="10" CompactModePageCount="7" NormalModePageCount="7"
                                GenerateFirstLastSection="True" GeneratePagerInfoSection="False" GenerateGoToSelect="Static"
                                GeneratePageSizeSelect="true" PageSizeSelectStart="10" PageSizeSelectInterval="5" MaximumPageSizeSelect="50"
                                OnPageSizeChanged="Pager_PageSizeChanged" OnPageIndexChanged="Pager_PageIndexChanged"
                                GenerateSmartShortCuts="false"></Farschidus:Pager>
                            <asp:Panel runat="server" ID="pnlChangePassword" Visible="false" class="popupWrapper" DefaultButton="btnChangePassword">
                                <div id="UserManagerPopup">
                                    <div id="UserManagerPopup-Header">
                                        <span id="UserManagerPopup-Title"><%= Farschidus.Translator.AppTranslate["userManager.default.popup.changePassword"]%></span>
                                        <asp:LinkButton ID="btnClose" runat="server" OnClick="btnClose_Click" CausesValidation="false" CssClass="UserManagerPopup-Close">
                                        </asp:LinkButton>
                                    </div>
                                    <div id="UserManagerPopup-Body">
                                        <%= Farschidus.Translator.AppTranslate["userManager.default.popup.userName"]%>
                                        <asp:Label ID="lblPopupUsername" CssClass="UserManagerPopup-Username" runat="server"></asp:Label>
                                        <br />
                                        <br />
                                        <%= Farschidus.Translator.AppTranslate["userManager.default.popup.password"]%>
                                        <asp:TextBox ID="txtPopupNewPassword" runat="server" MaxLength="25" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPopupNewPassword" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtPopupNewPassword" ValidationGroup="NewPassGroup"></asp:RequiredFieldValidator>
                                    </div>
                                    <div id="UserManagerPopup-Footer">
                                        <asp:LinkButton ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click"
                                            ValidationGroup="NewPassGroup" CssClass="search" Style="top: -1px;">
                                            <%= Farschidus.Translator.AppTranslate["general.button.save"]%>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="listPager" EventName="PageSizeChanged" />
                            <asp:AsyncPostBackTrigger ControlID="listPager" EventName="PageIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <div id="AddEdit">
        <asp:UpdatePanel ID="uplAddEdit" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <table width="400px" style="display: inline-block;">
                    <tr>
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["userManager.default.addEdit.roles"]%>
                        </td>
                        <td class="left ltr">
                            <asp:CheckBoxList ID="cblUserRoles" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" />
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr" style="width: 100px">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.username"]%>
                        </td>
                        <td class="left ltr">
                            <asp:Label ID="lblUserName" runat="server" CssClass="BlueLable"></asp:Label>
                            <asp:TextBox ID="txtUserName" runat="server" Width="250" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.password"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtPassword" runat="server" Width="250" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.email"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtEmail" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.firstName"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtFirstName" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.lastName"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtLastName" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.dateOfBirth"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtDateOfBirth" runat="server" Width="250"></asp:TextBox>
                            <ajax:MaskedEditExtender ID="DateExtender" runat="server" TargetControlID="txtDateOfBirth"
                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left"
                                ErrorTooltipEnabled="True" />
                            <ajax:CalendarExtender ID="calExtDate" runat="server" TargetControlID="txtDateOfBirth">
                            </ajax:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.gender"]%>
                        </td>
                        <td class="left ltr">
                            <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                               
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.tel"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtTel" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr top">
                            <%=Farschidus.Translator.AppTranslate["userManager.default.addEdit.address"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtAddress" runat="server" Width="250" Height="100" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
