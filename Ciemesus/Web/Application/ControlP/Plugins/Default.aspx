<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="PSM_Plugins_Default" %>

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
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.search.name"]%>
                </td>
                <td class="left languageLtr" colspan="3">
                    <asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.search.jSfileName"]%>
                </td>
                <td class="left languageLtr">
                    <asp:TextBox ID="txtJSfileNameSearch" runat="server"></asp:TextBox>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.search.version"]%>
                </td>
                <td class="left languageLtr">
                    <asp:TextBox ID="txtVersionSearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.search.description"]%>
                </td>
                <td class="left languageLtr">
                    <asp:TextBox ID="txtDescriptionSearch" runat="server"></asp:TextBox>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.search.settings"]%>
                </td>
                <td class="left languageLtr">
                    <asp:TextBox ID="txtSettingsSearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.search.css"]%>
                </td>
                <td class="left languageLtr">
                    <asp:TextBox ID="txtCssSearch" runat="server"></asp:TextBox>
                </td>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.search.jSinit"]%>
                </td>
                <td class="left languageLtr" colspan="3">
                    <asp:TextBox ID="txtJSinitSearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right ltr top" colspan="4">
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search">
                <%= Farschidus.Translator.AppTranslate["general.button.search"] %></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="cphMain" runat="server">
    <div id="List">
        <table style="margin: 10px auto;width: 95%;">
            <tr>
                <td align="left">
                    <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" DataKeyNames="IDPlugin" OnRowDraged="grvList_RowDraged" OnRowEditing="grvList_RowEditing"
                                OnRowDeleting="grvList_RowDeleting">
                                <Columns>
                                    <Farschidus:CheckAllBoxField ID="chkList" ItemStyle-CssClass="gridCheckbox" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.grid.name"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.grid.version"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Version") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.grid.description"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Global.MethodsAndProps.mGetLimitedString(50, Eval("Description").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="edit">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="delete">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.grid.delete"]%>
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
                <table width="850px" style="display: inline-block">
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.addEdit.jSfileName"]%>
                        </td>
                        <td class="left ltr" width="350px">
                            <ajax:AsyncFileUpload ID="fulFile" runat="server" Width="300px" OnUploadedComplete="fulFile_UploadedComplete"
                                ThrobberID="myThrobber" />
                        </td>
                        <td class="left ltr">
                            <asp:Label ID="myThrobber" runat="server">
                            <img alt="uploading" src='/Application/Images/General/uploading.gif' align="absmiddle" />Please Wait...</asp:Label>
                            <asp:Literal ID="litPopupJS" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.addEdit.name"]%>
                        </td>
                        <td class="left languageLtr" colspan="2">
                            <asp:TextBox ID="txtName" runat="server" Width="750px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.addEdit.version"]%>
                        </td>
                        <td class="left languageLtr" colspan="2">
                            <asp:TextBox ID="txtVersion" runat="server" Width="750px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr top">
                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.addEdit.description"]%>
                        </td>
                        <td class="left languageLtr" colspan="2">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="750px"
                                Height="45px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr top">
                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.addEdit.jSinit"]%>
                        </td>
                        <td class="left languageLtr" colspan="2">
                            <asp:TextBox ID="txtJSinit" runat="server" TextMode="MultiLine" Width="750px" Height="45px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right rtl top">
                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.addEdit.settings"]%>
                        </td>
                        <td class="left ltr" colspan="2">
                            <asp:TextBox ID="txtSettings" runat="server" TextMode="MultiLine" Width="750px" Height="130px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right rtl top">
                            <%=Farschidus.Translator.AppTranslate["pluginsManaging.default.addEdit.css"]%>
                        </td>
                        <td class="left ltr" colspan="2">
                            <asp:TextBox ID="txtCss" runat="server" TextMode="MultiLine" Width="750px" Height="130px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
