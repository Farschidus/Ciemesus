<%@ Page Language="C#" MasterPageFile="~/Application/Masters/Popup.master" AutoEventWireup="true" CodeFile="Popup.aspx.cs" Inherits="ControlP_Plugin_Popup" %>

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
    <asp:UpdatePanel ID="uplAddEdit" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hdfData" runat="server" />
            <asp:HiddenField ID="hdfRefresh" runat="server" EnableViewState="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="Repository">
        <span class="title"><%= Farschidus.Translator.AppTranslate["plugin.popup.repositoryPlugins"]%></span>
        <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <table width="590px" class="ltr">
                    <tr>
                        <td class="ltr left" colspan="2">
                            <asp:DropDownList ID="ddlPlugins" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                Width="575" OnSelectedIndexChanged="ddlPlugins_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="ltr left" width="455" colspan="2">
                            <asp:Label ID="lblVersion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ltr left" colspan="2">
                            <asp:Label ID="lblDescription" runat="server" Width="570"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ltr left" colspan="2">
                            <asp:TextBox ID="txtOptions" runat="server" TextMode="MultiLine" Width="570" Height="130"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ltr left" colspan="2">
                            <asp:TextBox ID="txtCSS" runat="server" TextMode="MultiLine" Width="570" Height="130"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="AddRemove">
        <asp:UpdatePanel ID="uplAddRemove" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:LinkButton ID="btnAddToPage" runat="server" OnClick="btnAddToPage_Click" CssClass="blueButton">
                    <%= Farschidus.Translator.AppTranslate["plugin.popup.button.addToPage"]%>
                </asp:LinkButton>
                <br />
                <asp:LinkButton ID="btnRemoveFromPage" runat="server" OnClick="btnRemoveFromPage_Click" CssClass="redButton">
                    <%= Farschidus.Translator.AppTranslate["plugin.popup.button.removeFromPage"]%>
                </asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="Files">
        <span class="title"><%= Farschidus.Translator.AppTranslate["plugin.popup.addedPlugins"]%></span>
        <asp:UpdatePanel ID="uplPageList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <table width="590px" class="ltr">
                    <tr>
                        <td class="ltr left" colspan="2">
                            <asp:DropDownList ID="ddlAddedPlugins" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                                Width="575" OnSelectedIndexChanged="ddlAddedPlugins_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="ltr left" width="315">
                            <asp:Label ID="lbladdedVersion" runat="server"></asp:Label>
                        </td>
                        <td class="ltr right">
                            <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="blueButton">
                                  <%= Farschidus.Translator.AppTranslate["plugin.popup.button.save"]%>
                            </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="ltr left" colspan="2">
                            <asp:Label ID="lblAddedDescription" runat="server" Width="570"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="ltr left" colspan="2">
                            <asp:TextBox ID="txtAddedOptions" runat="server" TextMode="MultiLine" Width="570" Height="130"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="ltr left" colspan="2">
                            <asp:TextBox ID="txtAddedCSS" runat="server" TextMode="MultiLine" Width="570" Height="130"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>