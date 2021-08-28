<%@ Page Language="C#" MasterPageFile="~/Application/Masters/Popup.master" AutoEventWireup="true" CodeFile="Popup.aspx.cs" Inherits="ControlP_Banner_Popup" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="Server">
    <script type="text/javascript">
        $(window).ready(function () {
            var data = window.parent.getData();
            if (data.length > 0) {
                $('#ctl00_ctl00_cphMainMaster_cphMain_hdfData').val(data);
                if ($('#ctl00_ctl00_cphMainMaster_cphMain_hdfRefresh').val().length == 0) {
                    __doPostBack('ctl00_ctl00_cphMainMaster_cphMain_uplAddEdit', '');
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
            <div id="Popup">
                <div class="select">
                    <table>
                        <tr>
                            <td class="left center">
                                <%= Farschidus.Translator.AppTranslate["banner.popup.label.selectType"]%>
                            </td>
                        </tr>
                        <tr>
                            <td class="left ltr">
                                <asp:RadioButtonList ID="rblTypes" runat="server" RepeatDirection="Vertical" AutoPostBack="true"
                                    OnSelectedIndexChanged="rblTypes_SelectedIndexChanged" AppendDataBoundItems="true">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px">
                                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="blueButton">
                            <%= Farschidus.Translator.AppTranslate["general.button.save"]%>
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="PopupDetail">
                    <table class="inactive">
                        <tr id="trInActive" runat="server">
                            <td>
                                <h1>
                                    <%=Farschidus.Translator.AppTranslate["banner.popup.label.inactive"] %>
                                </h1>
                            </td>
                        </tr>
                    </table>              
                    <table class="picture">
                        <tr id="trPicture" visible="false" runat="server">
                            <td>
                                <span><%= Farschidus.Translator.AppTranslate["banner.popup.label.selectPicture"]%></span><br />
                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                <br />
                                <Farschidus:GridView ID="grvList" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                    CssClass="gridView" DataKeyNames="IDMedia" Width="560px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <%=Farschidus.Translator.AppTranslate["banner.popup.grid.fileName"]%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Eval("FileName") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <%=Farschidus.Translator.AppTranslate["banner.popup.grid.fileExtention"]%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Eval("FileExtention").ToString().Replace(".","") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <%=Farschidus.Translator.AppTranslate["banner.popup.grid.select"]%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnSelectRow" runat="server" CommandName="Select" CommandArgument='<%#Eval("IDMedia")%>'
                                                    OnCommand="grvList_Select" CssClass="gridSelect">
                                            <%# mCheckMediaSebject(Convert.ToInt32(Eval("IDMedia")))%>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </Farschidus:GridView>
                                <Farschidus:Pager ID="Pager" runat="server" PageSize="5" CompactModePageCount="7" NormalModePageCount="7"
                                    GenerateFirstLastSection="True" GeneratePagerInfoSection="False" GenerateGoToSelect="Static"
                                    GoToClause="برو به" GeneratePageSizeSelect="true" PageSizeSelectClause="اندازه صفحه:"
                                    PageSizeSelectStart="5" PageSizeSelectInterval="5" MaximumPageSizeSelect="30"
                                    OnPageSizeChanged="Pager_PageSizeChanged" OnPageIndexChanged="Pager_PageIndexChanged"
                                    GenerateSmartShortCuts="false"></Farschidus:Pager>
                            </td>
                        </tr>
                    </table>                
                    <table class="gallery">
                        <tr id="trGallery" visible="false" runat="server">
                            <td>
                                <table>
                                    <tr>
                                        <td class="right ltr">
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.selectGalleryType"]%>
                                        </td>
                                        <td class="left CpLtr">
                                            <asp:DropDownList ID="ddlGalleryType" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                                                OnSelectedIndexChanged="ddlGalleryType_SelectedIndexChanged" Width="240px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="right ltr" style="width: 90px">
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.selectGallery"]%> 
                                        </td>
                                        <td class="left CpLtr">
                                            <asp:DropDownList ID="ddlGallery" runat="server" AppendDataBoundItems="true" Width="240px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="right ltr">
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.selectPlugin"]%> 
                                        </td>
                                        <td class="left CpLtr" colspan="3">
                                            <asp:DropDownList ID="ddlPlugins" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlPlugins_SelectedIndexChanged" Width="578px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="right ltr">
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.generateTitle"]%>
                                        </td>
                                        <td class="left ltr" colspan="3">
                                            <asp:CheckBox ID="cbxGenerateTitle" runat="server" />
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.generateDescription"]%>

                                            <asp:CheckBox ID="cbxGenerateDescription" runat="server" />
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.generateAnchor"]%>
                                            <asp:CheckBox ID="cbxGenerateAnchor" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="right ltr">
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.generateDate"]%>
                                        </td>
                                        <td class="left ltr">
                                            <asp:CheckBox ID="cbxGenerateDate" runat="server" />
                                        </td>
                                        <td class="right ltr">
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.dateFormat"]%>
                                        </td>
                                        <td class="left ltr">
                                            <asp:TextBox ID="txtDateFormat" runat="server" Width="226px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="right top ltr">
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.options"]%> 
                                        </td>
                                        <td class="left CpLtr" colspan="3">
                                            <asp:TextBox ID="txtOptions" runat="server" TextMode="MultiLine" Height="100" Width="564px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="right top ltr">
                                            <%= Farschidus.Translator.AppTranslate["banner.popup.label.css"]%>
                                        </td>
                                        <td class="left CpLtr" colspan="3">
                                            <asp:TextBox ID="txtCSS" runat="server" TextMode="MultiLine" Height="100" Width="564px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
