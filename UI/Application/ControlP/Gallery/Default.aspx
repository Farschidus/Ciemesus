<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true"
    ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="PSM_Gallery_Default" %>

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
        <table width="680px" style="display: inline-block">
            <tr>
                <td class="right ltr" style="width: 100px">
                    <%=Farschidus.Translator.AppTranslate["galleryManaging.default.search.galleryType"]%>
                </td>
                <td class="left CpLtr" colspan="3">
                    <asp:DropDownList ID="ddlGalleryTypeSearch" Width="600px" runat="server" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="right ltr">
                    <%=Farschidus.Translator.AppTranslate["galleryManaging.default.search.title"]%>
                </td>
                <td class="left languageLtr" colspan="3">
                    <asp:TextBox ID="txtTitleSearch" runat="server" Width="600px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right rtl">
                    <%=Farschidus.Translator.AppTranslate["galleryManaging.default.search.alias"]%>
                </td>
                <td class="left languageLtr">
                    <asp:TextBox ID="txtAliasSearch" runat="server" Width="515px"></asp:TextBox>
                </td>
                <td class="left ltr top" colspan="2">
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
                <table style="margin: 10px auto;width: 95%;">
                    <tr>
                        <td class="left ltr">
                            <asp:DropDownList ID="ddlListGalleryType" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlListGalleryType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" DataKeyNames="IDSubject, Priority" OnRowDraged="grvList_RowDraged"
                                OnRowEditing="grvList_RowEditing" OnRowDeleting="grvList_RowDeleting">
                                <Columns>
                                    <Farschidus:DragField ItemStyle-CssClass="gridDragHandler"/>
                                    <Farschidus:CheckAllBoxField ID="chkList" ItemStyle-CssClass="gridCheckbox"/>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.grid.subjectName"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.grid.bannerType"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# mGetGalleryTypeName(Eval("BannerType").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="edit">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.grid.edit"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditRow" runat="server" CommandName="Edit" CssClass="gridEdit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="delete">
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.grid.delete"]%>
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
                <asp:AsyncPostBackTrigger ControlID="ddlListGalleryType" EventName="SelectedIndexChanged" />
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
                            <%= Global.MethodsAndProps.mGetHtmlSpan( (pIDSubject.HasValue) ? pIDSubject.Value.ToString() : string.Empty) %>
                           <asp:HiddenField ID="hdfData" runat="server" />
                        </td>
                    </tr>
                    <tr>
                         <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["general.label.urlLink"]%>
                        </td>
                        <td class="left ltr">
                             <%= Global.MethodsAndProps.mGetHtmlLink(pIDSubject, BLL.BusinessEntity.SubjectTypes.Enum.imageGallery) %>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.addEdit.isActive"]%>
                        </td>
                        <td class="left ltr">
                            <asp:CheckBox ID="cbxIsActive" runat="server"></asp:CheckBox>                                                       
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.addEdit.type"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:DropDownList ID="ddlAddEditGalleryType" runat="server" AppendDataBoundItems="true" Width="780px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.addEdit.category"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="true" Width="780px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.addEdit.alias"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtAlias" runat="server" Width="780px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.addEdit.title"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtTitle" runat="server" Width="780px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr top">
                            <%=Farschidus.Translator.AppTranslate["galleryManaging.default.addEdit.body"]%>
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
