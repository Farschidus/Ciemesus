<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="ControlP_Home_Default" %>

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
        <table width="500px" style="display: inline-block">
            <tr>
                <td class="left rtl">
                    <%=Farschidus.Translator.AppTranslate["homePageManaging.default.search.iDHeaderGallery"]%>
                </td>
                <td class="right rtl">
                    <asp:TextBox ID="txtIDHeaderGallerySearch" runat="server"></asp:TextBox>
                </td>
                <td class="left rtl">
                    <%=Farschidus.Translator.AppTranslate["homePageManaging.default.search.bannerType"]%>
                </td>
                <td class="right rtl">
                    <asp:TextBox ID="txtBannerTypeSearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="left rtl">
                    <%=Farschidus.Translator.AppTranslate["homePageManaging.default.search.alias"]%>
                </td>
                <td class="right rtl">
                    <asp:TextBox ID="txtAliasSearch" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="left rtl top" colspan="4">
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
                <td align="languageLeft">
                    <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" DataKeyNames="IDSubject" OnRowEditing="grvList_RowEditing">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["homePageManaging.default.grid.subjectName"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["homePageManaging.default.grid.bannerType"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# mGetGalleryTypeName(Eval("BannerType").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="edit">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["homePageManaging.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Farschidus:GridView>
                        </ContentTemplate>
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
                            <%= Global.MethodsAndProps.mGetHtmlSpan( (pIDSubject.HasValue) ? pIDSubject.Value.ToString() : string.Empty) %>
                            <asp:HiddenField ID="hdfData" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["general.label.urlLink"]%>
                        </td>
                        <td class="left ltr">
                            <%= Global.MethodsAndProps.mGetHtmlLink(pIDSubject, BLL.BusinessEntity.SubjectTypes.Enum.home) %>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["homePageManaging.default.addEdit.isActive"]%>
                        </td>
                        <td class="left ltr">
                            <asp:CheckBox ID="cbxIsActive" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["homePageManaging.default.addEdit.title"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtTitle" runat="server" Width="780px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr top">
                            <%=Farschidus.Translator.AppTranslate["homePageManaging.default.addEdit.body"]%>
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
