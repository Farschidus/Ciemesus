<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="PSM_List_Default" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
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
        <table width="660px" style="display: inline-block">
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["listItemManaging.default.search.subjectType"]%>
                </td>
                <td class="left CpLtr" colspan="3">
                    <asp:UpdatePanel ID="uplSearch" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlListTypeSearch" runat="server" AppendDataBoundItems="true" Width="600px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["listItemManaging.default.search.title"]%>
                </td>
                <td class="left languageLtr" colspan="3">
                    <asp:TextBox ID="txtTitleSearch" runat="server" Width="600px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["listItemManaging.default.search.alias"]%>
                </td>
                <td class="left languageLtr">
                    <asp:TextBox ID="txtAliasSearch" runat="server" Width="515px"></asp:TextBox>
                </td>
                <td class="right top" colspan="2">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search">
                    <%= Farschidus.Translator.AppTranslate["general.button.search"] %></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="cphMain" runat="server">
    <div id="List">
        <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <table style="margin: 10px auto; width: 95%;">
                    <tr>
                        <td class="left languageLtr">
                            <asp:DropDownList ID="ddlListType" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlListType_SelectedIndexChanged" Width="100%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" DataKeyNames="IDSubject, Priority" OnRowDraged="grvList_RowDraged"
                                OnRowEditing="grvList_RowEditing" OnRowDeleting="grvList_RowDeleting">
                                <Columns>
                                    <Farschidus:DragField ItemStyle-CssClass="gridDragHandler" />
                                    <Farschidus:CheckAllBoxField ID="chkList" ItemStyle-CssClass="gridCheckbox" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.grid.subjectName"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.grid.bannerType"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# mGetGalleryTypeName(Eval("BannerType").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="edit">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="delete">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.grid.delete"]%>
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
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="listPager" EventName="PageSizeChanged" />
                <asp:AsyncPostBackTrigger ControlID="listPager" EventName="PageIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlListType" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
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
                            <%= Global.MethodsAndProps.mGetHtmlSpan((pIDSubject.HasValue) ? pIDSubject.Value.ToString() : string.Empty) %>
                            <asp:HiddenField ID="hdfData" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["general.label.urlLink"]%>
                        </td>
                        <td class="left ltr">
                            <%= Global.MethodsAndProps.mGetHtmlLink(pIDSubject, BLL.BusinessEntity.SubjectTypes.Enum.listItem) %>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.addEdit.isActive"]%>
                        </td>
                        <td class="left ltr">
                            <asp:CheckBox ID="cbxIsActive" runat="server"></asp:CheckBox>                        
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.addEdit.date"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="*" ControlToValidate="txtDate"
                                ValidationGroup="valGrouop"></asp:RequiredFieldValidator>                        
                            <ajax:MaskedEditExtender ID="DateExtender" runat="server" TargetControlID="txtDate"
                                Mask="9999/99/99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" ErrorTooltipEnabled="True" />
                            <ajax:CalendarExtender ID="calExtDate" runat="server" TargetControlID="txtDate" Format="yyyy/MM/dd">
                            </ajax:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.addEdit.alias"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtAlias" runat="server" Width="780px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.addEdit.title"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtTitle" runat="server" Width="780px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr top">
                            <%=Farschidus.Translator.AppTranslate["listItemManaging.default.addEdit.body"]%>
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
