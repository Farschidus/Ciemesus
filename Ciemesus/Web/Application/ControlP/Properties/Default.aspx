<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PSM_Properties_Default" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="cphHeader" runat="Server">
    <script type="text/javascript">
        var deleteConfirmMessage = '<%=Farschidus.Translator.AppTranslate["general.message.confirmDelete"]%>';
        var deleteConfirmButtons = { '<%=Farschidus.Translator.AppTranslate["general.button.ok"]%>': true, '<%=Farschidus.Translator.AppTranslate["general.button.cancel"]%>': false };
    </script>
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
    <div id="Search">
        <table style="width: 800px; display: inline-block;">
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["propertyManaging.default.addEdit.propetyType"]%>
                </td>
                <td class="left CpLtr">
                    <asp:TextBox ID="txtIDTypeSearch" runat="server"></asp:TextBox>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["propertyManaging.default.search.name"]%>
                </td>
                <td class="left ltr" colspan="3">
                    <asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right rtl top" colspan="4">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search">
                <%=Farschidus.Translator.AppTranslate["general.button.search"] %></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="cphMain" runat="server">
    <div id="List">
        <table style="display: inline-block">
            <tr>
                <td align="left">
                    <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" DataKeyNames="IDProperty" OnRowDraged="grvList_RowDraged"
                                OnRowEditing="grvList_RowEditing" OnRowDeleting="grvList_RowDeleting">
                                <Columns>
                                    <Farschidus:DragField ItemStyle-CssClass="gridDragHandler" />
                                    <Farschidus:CheckAllBoxField ID="chkList" ItemStyle-CssClass="gridCheckbox"/>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.grid.name"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.grid.propetyType"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# mGetPropertyTypeName(Eval("IDType")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.grid.delete"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteRow" runat="server" CommandName="Delete" CssClass="gridDelete"
                                                OnClientClick="return thrita.confirmDelete(this ,deleteConfirmMessage, deleteConfirmButtons);"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Farschidus:GridView>
                            <Farschidus:Pager ID="listPager" runat="server" PageSize="10" CompactModePageCount="7" NormalModePageCount="7"
                                GenerateFirstLastSection="True" GeneratePagerInfoSection="False" GenerateGoToSelect="Static"
                                GoToClause="برو به" GeneratePageSizeSelect="true" PageSizeSelectClause="اندازه صفحه:"
                                PageSizeSelectStart="10" PageSizeSelectInterval="5" MaximumPageSizeSelect="50"
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
                <table width="450px" style="display: inline-block">
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.addEdit.propetyType"]%>
                        </td>
                        <td class="left CpLtr">
                            <asp:DropDownList ID="ddlProprtyTypes" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlProprtyTypes_SelectedIndexChanged" Width="306px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.addEdit.name"]%>
                        </td>
                        <td class="left CpLtr">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                ValidationGroup="ValGroup" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trSingleSelectItem" runat="server" visible="false">
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.addEdit.itemTitle"]%>
                        </td>
                        <td class="left CpLtr">
                            <asp:TextBox ID="txtSingleSelectItem" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSingleSelectItem" runat="server" ControlToValidate="txtSingleSelectItem"
                                ValidationGroup="item" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:LinkButton ID="btnAddItem" runat="server" OnClick="btnAddItem_Click" ValidationGroup="item" CssClass="greenButton">
                                <%= Farschidus.Translator.AppTranslate["media.popup.button.addToPage"]%>
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="trItems" runat="server" visible="false">
                        <td colspan="2">
                            <Farschidus:GridView ID="grvSingleSelectItems" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" OnRowEditing="grvSingleSelectItems_RowEditing" OnRowUpdating="grvSingleSelectItems_RowUpdating"
                                OnRowDeleting="grvSingleSelectItems_RowDeleting" OnRowCommand="grvSingleSelectItems_RowCommand"
                                OnRowCancelingEdit="grvSingleSelectItems_RowCancelingEdit" DataKeyNames="IDPropertyItem">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.grid.itemTitle"]%>
                                        </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtGridItemTitle" Text='<%#Eval("Title")%>' Width="90" runat="server" />
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvGridTitle" ControlToValidate="txtGridItemTitle"
                                                Display="Dynamic" Text="*" runat="server" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnSaveItem" runat="server" CommandName="Save" CssClass="gridSave"
                                                CommandArgument='<%#Eval("IDPropertyItem") %>'></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyManaging.default.grid.delete"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteItem" runat="server" CommandName="Delete" CssClass="gridDelete"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnCancelItem" runat="server" CommandName="Cancel" CssClass="gridCancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Farschidus:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>