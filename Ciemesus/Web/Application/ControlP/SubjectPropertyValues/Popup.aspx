<%@ Page Language="C#" MasterPageFile="~/Application/Masters/Popup.master" AutoEventWireup="true"
    CodeFile="Popup.aspx.cs" Inherits="ControlP_SubjectPropertyValues_Popup" %>

<%@ Register Assembly="Farschidus" Namespace="Farschidus.Web.UI.WebControls" TagPrefix="Farschidus" %>
<%@ Register Src="~/Application/Ascx/JalaliDatePiker.ascx" TagPrefix="uc1" TagName="JalaliDatePiker" %>

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
                <span class="title"><%= Farschidus.Translator.AppTranslate["propertyValue.popup.label.repositoryProperties"]%></span>
                <table style="margin: 20px auto">
                    <tr>
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["propertyTypes.default.addEdit.name"] %>
                        </td>
                        <td class="left CpLtr">
                            <asp:DropDownList ID="ddlSubjectProperties" runat="server" EnableViewState="true" AutoPostBack="true"
                                AppendDataBoundItems="true" OnSelectedIndexChanged="ddlSubjectProperties_SelectedIndexChanged" Width="320px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trText" runat="server" visible="false">
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtText" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trInteger" runat="server" visible="false">
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtInteger" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revInteger" runat="server" ErrorMessage="EnterNumber"
                                ControlToValidate="txtInteger"> </asp:RegularExpressionValidator>                           
                        </td>
                    </tr>
                    <tr id="trFloati" runat="server" visible="false">
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtFloati" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revFloati" runat="server" ErrorMessage="000,000"
                                ControlToValidate="txtFloati" ValidationExpression="[-+]?[0-9]{0,3}\.?[0-9]{1,3}"></asp:RegularExpressionValidator>                           
                        </td>
                    </tr>
                    <tr id="trSingleSelect" runat="server" visible="false">
                        <td class="left ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <Farschidus:GridView ID="grvSingleSelect" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" DataKeyNames="IDPropertyItem" Style="margin: 20px auto;">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyItems.default.grid.title"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input id="htmRadioButton" type="radio" name="singleSelectRadioGroup" Checked="Checked"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyItems.default.grid.title"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Farschidus:GridView>
                            <asp:RadioButtonList ID="rblSingleSelect" runat="server" RepeatDirection="Vertical"></asp:RadioButtonList>
                        </td>
                    </tr>   
                    <tr id="trMultiSelect" runat="server" visible="false">
                        <td class="left ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <Farschidus:GridView ID="grvMultiSelect" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                                CssClass="gridView" DataKeyNames="IDPropertyItem" Style="margin: 20px auto;">
                                <Columns>
                                    <Farschidus:CheckAllBoxField ID="chkItemsList" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%=Farschidus.Translator.AppTranslate["propertyItems.default.grid.title"]%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Eval("Title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </Farschidus:GridView>
                        </td>
                    </tr>                    
                    <tr id="trTrueFalse" runat="server" visible="false">
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <asp:CheckBox ID="chbTrueFalse" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr id="trDate" runat="server" visible="false">
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <ajax:MaskedEditExtender ID="DateExtender" runat="server" TargetControlID="txtDate"
                                Mask="99/99/9999" MessageValidatorTip="true" MaskType="Date" ErrorTooltipEnabled="True" />
                            <ajax:CalendarExtender ID="calExtDate" runat="server" TargetControlID="txtDate">
                            </ajax:CalendarExtender>
                        </td>
                    </tr>
                    <tr id="trDatePe" runat="server" visible="false">
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <uc1:JalaliDatePiker runat="server" ID="ucJalaliDatePiker" CssClass="persianDatepicker.css" />
                        </td>
                    </tr>
                    <tr id="trTime" runat="server" visible="false">
                        <td class="right ltr">
                            <%= Farschidus.Translator.AppTranslate["subjectPropertyValues.default.addEdit.value"] %>
                        </td>
                        <td class="left ltr">
                            <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
                            <ajax:MaskedEditExtender ID="meeTime" runat="server" TargetControlID="txtTime" AcceptAMPM="false" Mask="99:99"
                                MessageValidatorTip="true" MaskType="Time" ErrorTooltipEnabled="True" AutoComplete="true" />
                            <ajax:MaskedEditValidator ID="mevTime" runat="server" ControlExtender="meeTime" ControlToValidate="txtTime"
                                IsValidEmpty="false" MaximumValue="23:59" MinimumValue="00:01" MaximumValueMessage="23:59"
                                InvalidValueBlurredMessage="Time is Invalid" MinimumValueMessage="Time must be grater than 00:00:00"
                                EmptyValueBlurredText="*" ValidationGroup="save"></ajax:MaskedEditValidator>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="right ltr" colspan="2">
                            <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="blueButton" ValidationGroup="save">
                                <%= Farschidus.Translator.AppTranslate["general.button.save"]%>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="Files">
        <span class="title"><%= Farschidus.Translator.AppTranslate["propertyValue.popup.label.addedProperties"]%></span>
        <asp:UpdatePanel ID="uplPageList" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <Farschidus:GridView ID="grvListPropertyValues" runat="server" ViewStateMode="Enabled" AutoGenerateColumns="false"
                    CssClass="gridView" DataKeyNames="IDProperty" Style="margin: 20px auto;"
                    OnRowDeleting="grvListPropertyValues_RowDeleting">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.popup.grid.propertyName"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# mGetPropertyName(Eval("IDProperty")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["subjectPropertyValues.default.grid.value"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# mGetCorrectValue(Eval("IDProperty"), Eval("Value").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="delete">
                            <HeaderTemplate>
                                <%=Farschidus.Translator.AppTranslate["pagesManaging.default.grid.delete"]%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDeleteRow" runat="server" CommandName="Delete" CssClass="gridDelete"
                                    OnClientClick="return Farschidus.confirmDelete(this ,deleteConfirmMessage, deleteConfirmButtons);"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </Farschidus:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
