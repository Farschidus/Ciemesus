<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PSM_SubjectPropertyValues_Default" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="cphHeader" runat="Server">
    <script type="text/javascript">
        var deleteConfirmMessage = '<%=Farschidus.Translator.AppTranslate["general.message.confirmDelete"]%>';
        var deleteConfirmButtons = { '<%=Farschidus.Translator.AppTranslate["general.button.ok"]%>': true, '<%=Farschidus.Translator.AppTranslate["general.button.cancel"]%>': false };
    </script>
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
    <div id="Search">
        <table width="500px" style="display: inline-block">
            <tr>
                <td class="right rtl">
                    <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.search.iDSubject"]%>
                </td>
                <td class="left rtl">
                    <asp:TextBox ID="txtIDSubjectSearch" runat="server"></asp:TextBox>
                </td>
                <td class="right rtl">
                    <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.search.iDProperty"]%>
                </td>
                <td class="left rtl">
                    <asp:TextBox ID="txtIDPropertySearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right rtl">
                    <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.search.value"]%>
                </td>
                <td class="left rtl" colspan="3">
                    <asp:TextBox ID="txtValueSearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right rtl top" colspan="4">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="submit">
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
                                CssClass="ThritaGrid" DataKeyNames="IDSubjectPropertyValue" OnRowDraged="grvList_RowDraged" OnRowEditing="grvList_RowEditing" OnRowDeleting="grvList_RowDeleting">
                                <Columns>
                                    <Farschidus:DragField />
                                    <Farschidus:CheckAllBoxField />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.grid.iDSubject"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("IDSubject") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.grid.iDProperty"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("IDProperty") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.grid.value"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Value") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.grid.delete"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteRow" runat="server" CommandName="Delete" CssClass="gridDelete" OnClientClick="return thrita.confirmDelete(this ,deleteConfirmMessage, deleteConfirmButtons);"></asp:LinkButton>
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
                <table width="500px" style="display: inline-block">
                    <tr>
                        <td class="right rtl">
                            <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.iDSubject"]%>
                        </td>
                        <td class="left rtl">
                            <asp:TextBox ID="txtIDSubject" runat="server"></asp:TextBox>
                        </td>
                        <td class="right rtl">
                            <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.iDProperty"]%>
                        </td>
                        <td class="left rtl">
                            <asp:TextBox ID="txtIDProperty" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right rtl">
                            <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"]%>
                        </td>
                        <td class="left rtl" colspan="3">
                            <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
