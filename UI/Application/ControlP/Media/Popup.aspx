<%@ Page Language="C#" MasterPageFile="~/Application/Masters/Popup.master" AutoEventWireup="true"
    CodeFile="Popup.aspx.cs" Inherits="ControlP_Media_Popup" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="Server">
    <script type="text/javascript">
        $(window).ready(function () {
            var data = window.parent.getData();
            if (data.length > 0) {
                $('#<%# hdfData.ClientID %>').val(data);
                if ($('#<%# hdfRefresh.ClientID %>').val().length == 0) {
                    __doPostBack('<%# uplAddEdit.ClientID  %>', '');
                }
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:UpdatePanel ID="uplAddEdit" runat="server" style="text-align: center" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hdfData" runat="server" />
            <asp:HiddenField ID="hdfRefresh" runat="server" EnableViewState="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="Repository">
        <span class="title"><%= Farschidus.Translator.AppTranslate["media.popup.label.repositoryFiles"]%></span>
        <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                    CssClass="gridView" DataKeyNames="IDMedia" Style="margin: 20px auto;">
                    <Columns>
                        <Farschidus:CheckAllBoxField ID="chkList" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["media.popup.grid.fileName"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FileName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["media.popup.grid.fileExtention"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FileExtention").ToString().Replace(".","") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["media.popup.grid.imageLink"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# mGetImageLink(Eval("IDMedia"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </Farschidus:GridView>
                <Farschidus:Pager ID="Pager" runat="server" PageSize="10" CompactModePageCount="7" NormalModePageCount="7"
                    GenerateFirstLastSection="True" GeneratePagerInfoSection="False" GenerateGoToSelect="Static"
                    GoToClause="برو به" GeneratePageSizeSelect="true" PageSizeSelectClause="اندازه صفحه:"
                    PageSizeSelectStart="10" PageSizeSelectInterval="5" MaximumPageSizeSelect="50"
                    OnPageSizeChanged="Pager_PageSizeChanged" OnPageIndexChanged="Pager_PageIndexChanged"
                    GenerateSmartShortCuts="false"></Farschidus:Pager>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Pager" EventName="PageSizeChanged" />
                <asp:AsyncPostBackTrigger ControlID="Pager" EventName="PageIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnAddToPage" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="AddRemove">
        <asp:UpdatePanel ID="uplAddRemove" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:LinkButton ID="btnAddToPage" runat="server" OnClick="btnAddToPage_Click" CssClass="blueButton">
                    <%= Farschidus.Translator.AppTranslate["media.popup.button.addToPage"]%>
                </asp:LinkButton>
                <br />
                <asp:LinkButton ID="btnRemoveFromPage" runat="server" OnClick="btnRemoveFromPage_Click" CssClass="redButton">
                    <%= Farschidus.Translator.AppTranslate["media.popup.button.removeFromPage"]%>
                </asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="Files">
        <span class="title"><%= Farschidus.Translator.AppTranslate["media.popup.label.addedFiles"]%></span>
        <asp:UpdatePanel ID="uplPageList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <Farschidus:GridView ID="grvPageList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                    CssClass="gridView" DataKeyNames="IDMedia, Priority" Style="margin: 20px auto;" OnRowDraged="grvPageList_RowDraged">
                    <Columns>                        
                        <Farschidus:DragField />
                        <Farschidus:CheckAllBoxField ID="chkPageList" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["media.popup.grid.fileName"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FileName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["media.popup.grid.fileExtention"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FileExtention").ToString().Replace(".","") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["media.popup.grid.imageLink"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# mGetImageLink(Eval("IDMedia"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </Farschidus:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
