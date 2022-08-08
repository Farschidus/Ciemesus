<%@ Page Language="C#" MasterPageFile="~/Application/Masters/Popup.master" AutoEventWireup="true"
    CodeFile="Popup.aspx.cs" Inherits="ControlP_SubjectProperties_Popup" %>

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
    <div id="Repository">
        <asp:UpdatePanel ID="uplAddEdit" runat="server" style="text-align: center" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:HiddenField ID="hdfData" runat="server" />
                <asp:HiddenField ID="hdfRefresh" runat="server" EnableViewState="true" />
                <span class="title"><%= Farschidus.Translator.AppTranslate["property.popup.label.repositoryProperties"]%></span>
                <div class="AddProperty">
                    <table style="width: 100%">
                        <tr>
                            <td class="right ltr">
                                <%= Farschidus.Translator.AppTranslate["property.popup.label.selectProperty"] %>
                            </td>
                            <td class="left CpLtr">
                                <asp:DropDownList ID="ddlProperties" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%= Farschidus.Translator.AppTranslate["property.popup.label.isSearchable"] %>
                            </td>
                            <td class="left ltr">
                                <asp:CheckBox ID="chbIsSearchable" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="AddRemove" style="top: 0;">
        <asp:UpdatePanel ID="uplAddRemove" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:LinkButton ID="btnAddToPage" runat="server" OnClick="btnAddToPage_Click" CssClass="blueButton">
                    <%= Farschidus.Translator.AppTranslate["property.popup.button.addToPage"]%>
                </asp:LinkButton>
                <br />
                <asp:LinkButton ID="btnRemoveFromPage" runat="server" OnClick="btnRemoveFromPage_Click" CssClass="redButton">
                    <%= Farschidus.Translator.AppTranslate["property.popup.button.removeFromPage"]%>
                </asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="Files">
        <span class="title"><%= Farschidus.Translator.AppTranslate["property.popup.label.addedProperties"]%></span>
        <asp:UpdatePanel ID="uplPageList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <Farschidus:GridView ID="grvGroupPropeties" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                    CssClass="gridView" DataKeyNames="IDProperty" Style="margin: 20px auto;">
                    <Columns>
                        <Farschidus:DragField />
                        <Farschidus:CheckAllBoxField ID="chkPageList" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["property.popup.grid.propertyName"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["property.popup.grid.isSearchable"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# mIsSearchable(Eval("IDProperty")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </Farschidus:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
