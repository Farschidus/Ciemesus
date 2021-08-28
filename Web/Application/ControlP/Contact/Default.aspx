<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="PSM_Contacts_Default" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="cphHeader" runat="Server">
    <script type="text/javascript">
        var deleteConfirmMessage = '<%=Farschidus.Translator.AppTranslate["general.message.confirmDelete"]%>';
        var deleteConfirmButtons = { '<%=Farschidus.Translator.AppTranslate["general.button.ok"]%>': true, '<%=Farschidus.Translator.AppTranslate["general.button.cancel"]%>': false };
    </script>
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
    <div id="Search">
        <table width="350px" style="display: inline-block">
            <tr>
                <td class="left ltr">
                    <%=Farschidus.Translator.AppTranslate["contactManaging.default.search.title"]%>
                </td>
                <td class="right ltr">
                    <asp:TextBox ID="txtTitleSearch" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="right top">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search">
                <%= Farschidus.Translator.AppTranslate["general.button.search"] %></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="cphMain" runat="server">
    <div id="List">
        <table style="margin: 10px auto; width: 95%;">
            <tr>
                <td align="left">
                    <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" DataKeyNames="id" OnRowDraged="grvList_RowDraged" OnRowEditing="grvList_RowEditing"
                                OnRowDeleting="grvList_RowDeleting">
                                <Columns>
                                    <Farschidus:DragField ItemStyle-CssClass="gridDragHandler" />
                                    <Farschidus:CheckAllBoxField ID="chkList" ItemStyle-CssClass="gridCheckbox" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.grid.title"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.grid.email"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("email") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="edit">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="delete">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.grid.delete"]%>
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
                <table width="320px" style="display: inline-block">
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.addEdit.title"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.addEdit.subject"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtSubject" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.addEdit.email"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr top">
                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.addEdit.phone"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtPhone" runat="server" Height="100px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.addEdit.fax"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtFax" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr top">
                            <%=Farschidus.Translator.AppTranslate["contactManaging.default.addEdit.address"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtAddress" runat="server" Height="100px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
