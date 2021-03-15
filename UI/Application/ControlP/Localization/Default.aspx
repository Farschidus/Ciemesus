<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true" 
    ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="Application_ControlP_Localization_Default"  %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cphHeader" runat="Server">
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="cphMain" runat="Server">
    <div id="List">
        <asp:UpdatePanel ID="uplList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <table width="820px" style="display: inline-block">
                    <tr>
                        <td class="right rtl">
                            <%=Farschidus.Translator.AppTranslate["localization.lable.section"]%>
                        </td>
                        <td class="left CpLtr">
                            <asp:DropDownList ID="ddlSection" EnableViewState="true" AutoPostBack="true" Width="200px"
                                runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="right rtl">
                            <%=Farschidus.Translator.AppTranslate["localization.lable.module"]%>
                        </td>
                        <td class="left CpLtr">
                            <asp:DropDownList ID="ddlModules" runat="server" EnableViewState="true" AutoPostBack="true" Width="200px"
                                OnSelectedIndexChanged="ddlModules_SelectedIndexChanged" AppendDataBoundItems="true" Enabled="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="AddEdit">
        <asp:UpdatePanel ID="uplAddEdit" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Table ID="tblModuleDetails" Style="display: inline-block; Width: 820px" runat="server">
                </asp:Table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

