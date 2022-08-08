<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="PSM_UserPages_Default" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<%@ Register TagName="AlphabetLinks" Src="~/Application/Ascx/AlphabetLinks.ascx" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="cphHeader" runat="Server">
    <%@ Register Src="~/Application/Ascx/tinyMCE.ascx" TagPrefix="uc1" TagName="tinyMCE" %>
    <script type="text/javascript">
        function getData() {
            return $('#<%= hdfData.ClientID %>').val();
        }
        var deleteConfirmMessage = '<%=Farschidus.Translator.AppTranslate["general.message.confirmDelete"]%>';
        var deleteConfirmButtons = { '<%=Farschidus.Translator.AppTranslate["general.button.ok"]%>': true, '<%=Farschidus.Translator.AppTranslate["general.button.cancel"]%>': false };
    </script>
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
    <div id="Search">
        <table width="840px" class="left ltr" style="display: inline-block;">
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["membersPageManager.default.search.roles"]%>
                </td>
                <td class="left languageLtr">
                    <asp:DropDownList ID="ddlRoleSearch" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="--All Roles--" Value="" Selected="True" />
                    </asp:DropDownList>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["membersPageManager.default.search.approval"]%>
                </td>
                <td class="left ltr">
                    <asp:DropDownList ID="ddlApprovalSearch" runat="server">
                        <asp:ListItem Text="--All statuses--" Value="" Selected="True" />
                        <asp:ListItem Text="Approved" Value="True" />
                        <asp:ListItem Text="Unapproved" Value="False" />
                    </asp:DropDownList>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["membersPageManager.default.search.locked"]%>
                </td>
                <td class="left ltr">
                    <asp:DropDownList ID="ddlLockUsersSearch" runat="server">
                        <asp:ListItem Text="--All statuses--" Value="" Selected="True" />
                        <asp:ListItem Text="Unlocked" Value="False" />
                        <asp:ListItem Text="Locked out" Value="True" />
                    </asp:DropDownList>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["membersPageManager.default.search.online"]%>
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
                    <%=Farschidus.Translator.AppTranslate["membersPageManager.default.search.usernameFilter"]%>
                    <uc1:AlphabetLinks runat="server" ID="AlphabetLinkList" OnSelectedChanged="AlphabetLinkList_SelectedChanged" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="cphMain" runat="Server">
    <div id="List" style="direction: ltr;">
        <table style="margin: 10px auto;width: 95%;">
            <tr>
                <td align="left">
                    <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView gridViewLTR" DataKeyNames="ProviderUserKey" OnRowEditing="grvList_RowEditing"
                                OnRowDeleting="grvList_RowDeleting" EmptyDataText="There is no result.">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%= Farschidus.Translator.AppTranslate["membersPageManager.default.grid.fullName"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# mGetUSerFullName(Eval("ProviderUserKey")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%= Farschidus.Translator.AppTranslate["membersPageManager.default.grid.userName"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("UserName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                  
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="edit">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["membersPageManager.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Farschidus:GridView>
                            <Farschidus:Pager ID="listPager" runat="server" PageSize="10" CompactModePageCount="7" NormalModePageCount="7"
                                GenerateFirstLastSection="True" GeneratePagerInfoSection="False" GenerateGoToSelect="Static"
                                GeneratePageSizeSelect="true" PageSizeSelectStart="10" PageSizeSelectInterval="5" MaximumPageSizeSelect="50"
                                OnPageSizeChanged="Pager_PageSizeChanged" OnPageIndexChanged="Pager_PageIndexChanged"
                                GenerateSmartShortCuts="false"></Farschidus:Pager>
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
                <table width="850px" style="display: inline-block">
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["pagesManaging.default.addEdit.pageID"]%>
                        </td>
                        <td class="left ltr">
                            <%= Global.MethodsAndProps.mGetHtmlSpan( (pIDUser.HasValue) ? pIDUser.Value.ToString() : string.Empty) %>
                            <asp:HiddenField ID="hdfData" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["membersPageManager.default.addEdit.isActive"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:CheckBox ID="cbxIsActive" runat="server"></asp:CheckBox>                            
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["membersPageManager.default.addEdit.title"]%>
                        </td>
                        <td class="ledt languageLtr">
                            <asp:TextBox ID="txtTitle" runat="server" Width="780px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right rtl top">
                            <%=Farschidus.Translator.AppTranslate["membersPageManager.default.addEdit.body"]%>
                        </td>
                        <td class="left ltr">
                            <uc1:tinyMCE runat="server" ID="tinyMCE" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>