<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true" EnableEventValidation="false"
     CodeFile="Default.aspx.cs" Inherits="ControlP_MenuManager_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="Server">
<%--    <link rel="stylesheet" href="/Application/static/src/app/css/jstree-themes/default/style.min.css" />
    <script type="text/javascript" src="/Application/static/src/app/js/jstree.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            webCall();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(webCall);
        });
        var treeType;
        var nodeID;
        var titlu;
        var url;
        var refNode;
        var parentID;
        var position = "inside"
        function MakeTree(result) {
            $("#menuContainer")
                .bind("move_node.jstree", function (none, sender) {
                    FarschidusMove(sender.node.id, sender.parent, sender.position);
                }).bind("rename_node.jstree", function (none, sender) {
                    FarschidusRename(sender.node.id, sender.text);
                }).bind("delete_node.jstree", function (none, sender) {
                    FarschidusDelete(sender.node.id);
                })
                .bind("loaded.jstree", function (event, data) {
                    $(this).jstree("open_all");
                })
                .jstree({
                    "core": {
                        "data": JSON.parse(result),
                        "check_callback": true,
                        "themes": {
                            "theme": "default",
                            "dots": true,
                            "icons": true
                        },
                    },
                    "plugins": ["contextmenu", "dnd"],
                    "contextmenu": {
                        "items": function ($node) {
                            var tree = $("#menuContainer").jstree(true);
                            return {
                                "Rename": {
                                    "label": "Rename",
                                    "action": function (obj) { tree.edit($node); }
                                },
                                "Delete": {
                                    "label": "Delete",
                                    "action": function (obj) { tree.delete_node($node); }
                                }
                            };
                        }
                    }
                });
            };

        function webCall() {
            PageMethods.set_path("/Application/controlP/MenuManager/default.aspx");
            treeType = $('#<%= hdfMenuName.ClientID %>').val();
            PageMethods.LoadSiteMap(treeType, MakeTree);
        }
        function FarschidusMove(NODE, REF_NODE, TYPE) {
            PageMethods.MoveNode(NODE, REF_NODE, TYPE, treeType);
        }
        function FarschidusDelete(NODE_ID) {
            PageMethods.DeleteNode(NODE_ID, treeType);
        }
        function FarschidusRename(NODE_ID, newText) {
            PageMethods.RenameNode(NODE_ID, newText, treeType);
        }
        var deleteConfirmMessage = '<%=Farschidus.Translator.AppTranslate["general.message.confirmDelete"]%>';
        var deleteConfirmButtons = { '<%=Farschidus.Translator.AppTranslate["general.button.ok"]%>': true, '<%=Farschidus.Translator.AppTranslate["general.button.cancel"]%>': false };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <div id="List">
        <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div id="menuContainer"></div>
                <asp:HiddenField ID="hdfMenuName" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="AddEdit">
        <asp:UpdatePanel ID="uplAddEdit" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <table width="450px" style="display: inline-block">
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["menuManager.default.addEdit.title"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["menuManager.default.addEdit.module"]%>
                        </td>
                        <td class="left CpLtr">
                            <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                                OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" Width="306px">
                            </asp:DropDownList>
                            <br />
                            <asp:CheckBox ID="cbxShowRelated" runat="server" Visible="false" />
                        </td>
                    </tr>
                    <tr id="trPage" runat="server">
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["menuManager.default.addEdit.alias"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:DropDownList ID="ddlAlias" runat="server" Enabled="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trListFormat" runat="server">
                        <td class="right top ltr" style="width: 100px">
                            <%=Farschidus.Translator.AppTranslate["menuManager.default.addEdit.listPageFormat"]%>
                        </td>
                        <td class="left ltr">
                            <asp:RadioButtonList ID="rblPageListFormat" runat="server" Width="200px"
                                RepeatDirection="Horizontal" RepeatLayout="Table" TextAlign="Right">                              
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr id="trUrl" runat="server">
                        <td class="right ltr">
                            <%=Farschidus.Translator.AppTranslate["menuManager.default.addEdit.rawUrl"]%>
                        </td>
                        <td class="left languageLtr">
                            <asp:TextBox ID="txtRawUrl" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
