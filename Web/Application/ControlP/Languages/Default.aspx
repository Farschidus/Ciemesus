<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="PSM_Languages_Default" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="cphHeader" runat="Server">
    <script type="text/javascript">
        var deleteConfirmMessage = '<%=Farschidus.Translator.AppTranslate["general.message.confirmDelete"]%>';
        var deleteConfirmButtons = { '<%=Farschidus.Translator.AppTranslate["general.button.ok"]%>': true, '<%=Farschidus.Translator.AppTranslate["general.button.cancel"]%>': false };
    </script>
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
    <div id="Search">
        <table width="480px" style="display: inline-block">
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["languages.default.search.title"]%>
                </td>
                <td class="left CpLtr">
                    <asp:TextBox ID="txtTitleSearch" runat="server"></asp:TextBox>
                </td>
                <td class="right ltr" style="width: 50px">
                    <asp:CheckBox ID="cbxIsRTLSearch" runat="server" />
                </td>
                <td class="left rtl">
                    <%=Farschidus.Translator.AppTranslate["languages.default.search.isRTL"]%>                    
                </td>                
            </tr>
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["languages.default.search.code"]%>
                </td>
                <td class="left CpLtr">
                    <asp:TextBox ID="txtCodeSearch" runat="server"></asp:TextBox>
                </td>
                <td class="right rtl">
                   <asp:CheckBox ID="cbxIsActiveSearch" runat="server" />
                </td>
                <td class="left rtl">                    
                     <%=Farschidus.Translator.AppTranslate["languages.default.search.isActive"]%>
                </td>                
            </tr>
            <tr>
                <td></td>
                <td class="left ltr top" >
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="search">
                        <%= Farschidus.Translator.AppTranslate["general.button.search"] %>
                    </asp:LinkButton>
                </td>
                <td class="right rtl">
                    <asp:CheckBox ID="cbxIsDefaultSearch" runat="server" />
                </td>
                <td class="left rtl">
                    <%=Farschidus.Translator.AppTranslate["languages.default.search.isDefault"]%>                    
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
                                CssClass="gridView" DataKeyNames="IDLanguage, Priority" OnRowDraged="grvList_RowDraged"
                                OnRowEditing="grvList_RowEditing" OnRowDeleting="grvList_RowDeleting">
                                <Columns>
                                    <Farschidus:DragField ItemStyle-CssClass="gridDragHandler"/>
                                    <Farschidus:CheckAllBoxField ID="chkList" ItemStyle-CssClass="gridCheckbox"/>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["languages.default.grid.isActive"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# (Convert.ToBoolean(Eval("IsActive"))) ? Global.Constants.HTML_IMAGE_CHECK : Global.Constants.HTML_IMAGE_ERROR %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["languages.default.grid.title"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["languages.default.grid.code"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Code") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["languages.default.grid.isDefault"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# (Convert.ToBoolean(Eval("IsDefault"))) ? Global.Constants.HTML_IMAGE_CHECK : Global.Constants.HTML_IMAGE_ERROR%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["languages.default.grid.isRTL"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# mGetDirection(Convert.ToBoolean(Eval("IsRTL"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="edit">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["languages.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="delete">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["languages.default.grid.delete"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteRow" runat="server" CommandName="Delete" CssClass="gridDelete"
                                                OnClientClick="return Farschidus.confirmDelete(this ,deleteConfirmMessage, deleteConfirmButtons);"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Farschidus:GridView>
                            <Farschidus:Pager ID="listPager" runat="server" PageSize="10" CompactModePageCount="7" NormalModePageCount="7"
                                GenerateFirstLastSection="True" GeneratePagerInfoSection="false" GenerateGoToSelect="Static"
                                GeneratePageSizeSelect="True" PageSizeSelectStart="10" PageSizeSelectInterval="5" MaximumPageSizeSelect="50"
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
                <table width="400px" style="display: inline-block">
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["languages.default.addEdit.title"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right languageLtr">
                            <%=Farschidus.Translator.AppTranslate["languages.default.addEdit.code"]%>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr" style="width: 300px;">
                            <%=Farschidus.Translator.AppTranslate["languages.default.addEdit.isRTL"]%>
                        </td>
                        <td class="left ltr">                            
                            <asp:CheckBox ID="cbxIsRTL" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["languages.default.addEdit.isActive"]%>
                        </td>
                        <td class="left ltr">                            
                            <asp:CheckBox ID="cbxIsActive" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                           <%=Farschidus.Translator.AppTranslate["languages.default.addEdit.isDefault"]%>
                        </td>
                        <td class="left ltr">                            
                             <asp:CheckBox ID="cbxIsDefault" runat="server" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
