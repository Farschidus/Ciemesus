<%@ Page Language="C#" MasterPageFile="~/Application/Masters/CP.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="PSM_Settings_Default" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="cphHeader" runat="Server">
    <script type="text/javascript">
        //$(document).ready(function () {
        //    initialize();
        //    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initialize);
        //});
        //function initialize() {
        //    $("#MediaPopup").draggable({ handle: 'div#dragHandler', containment: '#popupWrapper', scroll: false });
        //    $("#BannerPopup").draggable({ handle: 'div#dragHandler', containment: '#popupWrapper', scroll: false });
        //    $("#PluginPopup").draggable({ handle: 'div#dragHandler', containment: '#popupWrapper', scroll: false });
        //}
        function getData() {
            return $('#<%= hdfData.ClientID %>').val();
        }
        var deleteConfirmMessage = '<%=Farschidus.Translator.AppTranslate["general.message.confirmDelete"]%>';
        var deleteConfirmButtons = { '<%=Farschidus.Translator.AppTranslate["general.button.ok"]%>': true, '<%=Farschidus.Translator.AppTranslate["general.button.cancel"]%>': false };
    </script>
</asp:Content>
<asp:Content ID="SearchContent" ContentPlaceHolderID="cphSearch" runat="Server">
    <div id="Search">
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="cphMain" runat="server">
    <div id="List">
        <%= Farschidus.Translator.AppTranslate["settingPage.default.lable.description"]%>
    </div>
    <div id="AddEdit">
        <asp:UpdatePanel ID="uplAddEdit" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div>
                    <span class="favIconSettingView">
                        <asp:Image ID="imgFaveIcon" runat="server" ImageUrl="~/Client/Images/favicon.ico"></asp:Image>
                    </span>
                    <table width="700px" style="display: inline-block">
                        <tr>
                            <td colspan="2">
                                <asp:HiddenField ID="hdfData" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr" style="width: 122px;">
                                <%= Farschidus.Translator.AppTranslate["settingPage.default.addEdit.favIcon"]%>
                            </td>
                            <td class="left CpLtr">
                                <asp:Literal ID="litImage" runat="server"></asp:Literal>
                                <ajax:AsyncFileUpload ID="fulImage" runat="server" Width="250px" OnUploadedComplete="fulImages_UploadedComplete" ThrobberID="myThrobber" />
                                <asp:Label ID="myThrobber" runat="server"><img alt="uploading" src='/Application/Images/General/uploading.gif' align="absmiddle" /> Please Wait...</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.timezone"]%>
                            </td>
                            <td class="left CpLtr">
                                <asp:DropDownList ID="ddlTimezone" runat="server" Width="550px">
                                    <asp:ListItem Value="-11">(GMT-11:00) International Date Line West</asp:ListItem>
                                    <asp:ListItem Value="-11">(GMT-11:00) Midway Island</asp:ListItem>
                                    <asp:ListItem Value="-11">(GMT-11:00) Samoa</asp:ListItem>
                                    <asp:ListItem Value="-10">(GMT-10:00) Hawaii</asp:ListItem>
                                    <asp:ListItem Value="-9">(GMT-09:00) Alaska</asp:ListItem>
                                    <asp:ListItem Value="-8">(GMT-08:00) Pacific Time (US &amp; Canada)</asp:ListItem>
                                    <asp:ListItem Value="-8">(GMT-08:00) Tijuana</asp:ListItem>
                                    <asp:ListItem Value="-7">(GMT-07:00) Arizona</asp:ListItem>
                                    <asp:ListItem Value="-7">(GMT-07:00) Chihuahua</asp:ListItem>
                                    <asp:ListItem Value="-7">(GMT-07:00) Mazatlan</asp:ListItem>
                                    <asp:ListItem Value="-7">(GMT-07:00) Mountain Time (US &amp; Canada)</asp:ListItem>
                                    <asp:ListItem Value="-6">(GMT-06:00) Central America</asp:ListItem>
                                    <asp:ListItem Value="-6">(GMT-06:00) Central Time (US &amp; Canada)</asp:ListItem>
                                    <asp:ListItem Value="-6">(GMT-06:00) Guadalajara</asp:ListItem>
                                    <asp:ListItem Value="-6">(GMT-06:00) Mexico City</asp:ListItem>
                                    <asp:ListItem Value="-6">(GMT-06:00) Monterrey</asp:ListItem>
                                    <asp:ListItem Value="-6">(GMT-06:00) Saskatchewan</asp:ListItem>
                                    <asp:ListItem Value="-5">(GMT-05:00) Bogota</asp:ListItem>
                                    <asp:ListItem Value="-5">(GMT-05:00) Eastern Time (US &amp; Canada)</asp:ListItem>
                                    <asp:ListItem Value="-5">(GMT-05:00) Indiana (East)</asp:ListItem>
                                    <asp:ListItem Value="-5">(GMT-05:00) Lima</asp:ListItem>
                                    <asp:ListItem Value="-5">(GMT-05:00) Quito</asp:ListItem>
                                    <asp:ListItem Value="-4.5">(GMT-04:30) Caracas</asp:ListItem>
                                    <asp:ListItem Value="-4">(GMT-04:00) Atlantic Time (Canada)</asp:ListItem>
                                    <asp:ListItem Value="-4">(GMT-04:00) La Paz</asp:ListItem>
                                    <asp:ListItem Value="-4">(GMT-04:00) Santiago</asp:ListItem>
                                    <asp:ListItem Value="-3.5">(GMT-03:30) Newfoundland</asp:ListItem>
                                    <asp:ListItem Value="-3">(GMT-03:00) Brasilia</asp:ListItem>
                                    <asp:ListItem Value="-3">(GMT-03:00) Buenos Aires</asp:ListItem>
                                    <asp:ListItem Value="-3">(GMT-03:00) Georgetown</asp:ListItem>
                                    <asp:ListItem Value="-3">(GMT-03:00) Greenland</asp:ListItem>
                                    <asp:ListItem Value="-2">(GMT-02:00) Mid-Atlantic</asp:ListItem>
                                    <asp:ListItem Value="-1">(GMT-01:00) Azores</asp:ListItem>
                                    <asp:ListItem Value="-1">(GMT-01:00) Cape Verde Is.</asp:ListItem>
                                    <asp:ListItem Value="0">(GMT+00:00) Casablanca</asp:ListItem>
                                    <asp:ListItem Value="0">(GMT+00:00) Dublin</asp:ListItem>
                                    <asp:ListItem Value="0">(GMT+00:00) Edinburgh</asp:ListItem>
                                    <asp:ListItem Value="0">(GMT+00:00) Lisbon</asp:ListItem>
                                    <asp:ListItem Value="0">(GMT+00:00) London</asp:ListItem>
                                    <asp:ListItem Value="0">(GMT+00:00) Monrovia</asp:ListItem>
                                    <asp:ListItem Value="0">(GMT+00:00) UTC</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Amsterdam</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Belgrade</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Berlin</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Bern</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Bratislava</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Brussels</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Budapest</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Copenhagen</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Ljubljana</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Madrid</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Paris</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Prague</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Rome</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Sarajevo</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Skopje</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Stockholm</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Vienna</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Warsaw</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) West Central Africa</asp:ListItem>
                                    <asp:ListItem Value="1">(GMT+01:00) Zagreb</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Athens</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Bucharest</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Cairo</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Harare</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Helsinki</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Istanbul</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Jerusalem</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Kyev</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Minsk</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Pretoria</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Riga</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Sofia</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Tallinn</asp:ListItem>
                                    <asp:ListItem Value="2">(GMT+02:00) Vilnius</asp:ListItem>
                                    <asp:ListItem Value="3">(GMT+03:00) Baghdad</asp:ListItem>
                                    <asp:ListItem Value="3">(GMT+03:00) Kuwait</asp:ListItem>
                                    <asp:ListItem Value="3">(GMT+03:00) Moscow</asp:ListItem>
                                    <asp:ListItem Value="3">(GMT+03:00) Nairobi</asp:ListItem>
                                    <asp:ListItem Value="3">(GMT+03:00) Riyadh</asp:ListItem>
                                    <asp:ListItem Value="3">(GMT+03:00) St. Petersburg</asp:ListItem>
                                    <asp:ListItem Value="3">(GMT+03:00) Volgograd</asp:ListItem>
                                    <asp:ListItem Value="3.5">(GMT+03:30) Tehran</asp:ListItem>
                                    <asp:ListItem Value="4">(GMT+04:00) Abu Dhabi</asp:ListItem>
                                    <asp:ListItem Value="4">(GMT+04:00) Baku</asp:ListItem>
                                    <asp:ListItem Value="4">(GMT+04:00) Muscat</asp:ListItem>
                                    <asp:ListItem Value="4">(GMT+04:00) Tbilisi</asp:ListItem>
                                    <asp:ListItem Value="4">(GMT+04:00) Yerevan</asp:ListItem>
                                    <asp:ListItem Value="4.5">(GMT+04:30) Kabul</asp:ListItem>
                                    <asp:ListItem Value="5">(GMT+05:00) Ekaterinburg</asp:ListItem>
                                    <asp:ListItem Value="5">(GMT+05:00) Islamabad</asp:ListItem>
                                    <asp:ListItem Value="5">(GMT+05:00) Karachi</asp:ListItem>
                                    <asp:ListItem Value="5">(GMT+05:00) Tashkent</asp:ListItem>
                                    <asp:ListItem Value="5.5">(GMT+05:30) Chennai</asp:ListItem>
                                    <asp:ListItem Value="5.5">(GMT+05:30) Kolkata</asp:ListItem>
                                    <asp:ListItem Value="5.5">(GMT+05:30) Mumbai</asp:ListItem>
                                    <asp:ListItem Value="5.5">(GMT+05:30) New Delhi</asp:ListItem>
                                    <asp:ListItem Value="5.5">(GMT+05:30) Sri Jayawardenepura</asp:ListItem>
                                    <asp:ListItem Value="5.75">(GMT+05:45) Kathmandu</asp:ListItem>
                                    <asp:ListItem Value="6">(GMT+06:00) Almaty</asp:ListItem>
                                    <asp:ListItem Value="6">(GMT+06:00) Astana</asp:ListItem>
                                    <asp:ListItem Value="6">(GMT+06:00) Dhaka</asp:ListItem>
                                    <asp:ListItem Value="6">(GMT+06:00) Novosibirsk</asp:ListItem>
                                    <asp:ListItem Value="6.5">(GMT+06:30) Rangoon</asp:ListItem>
                                    <asp:ListItem Value="7">(GMT+07:00) Bangkok</asp:ListItem>
                                    <asp:ListItem Value="7">(GMT+07:00) Hanoi</asp:ListItem>
                                    <asp:ListItem Value="7">(GMT+07:00) Jakarta</asp:ListItem>
                                    <asp:ListItem Value="7">(GMT+07:00) Krasnoyarsk</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Beijing</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Chongqing</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Hong Kong</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Irkutsk</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Kuala Lumpur</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Perth</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Singapore</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Taipei</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Ulaan Bataar</asp:ListItem>
                                    <asp:ListItem Value="8">(GMT+08:00) Urumqi</asp:ListItem>
                                    <asp:ListItem Value="9">(GMT+09:00) Osaka</asp:ListItem>
                                    <asp:ListItem Value="9">(GMT+09:00) Sapporo</asp:ListItem>
                                    <asp:ListItem Value="9">(GMT+09:00) Seoul</asp:ListItem>
                                    <asp:ListItem Value="9">(GMT+09:00) Tokyo</asp:ListItem>
                                    <asp:ListItem Value="9">(GMT+09:00) Yakutsk</asp:ListItem>
                                    <asp:ListItem Value="9.5">(GMT+09:30) Adelaide</asp:ListItem>
                                    <asp:ListItem Value="9.5">(GMT+09:30) Darwin</asp:ListItem>
                                    <asp:ListItem Value="10">(GMT+10:00) Brisbane</asp:ListItem>
                                    <asp:ListItem Value="10">(GMT+10:00) Canberra</asp:ListItem>
                                    <asp:ListItem Value="10">(GMT+10:00) Guam</asp:ListItem>
                                    <asp:ListItem Value="10">(GMT+10:00) Hobart</asp:ListItem>
                                    <asp:ListItem Value="10">(GMT+10:00) Melbourne</asp:ListItem>
                                    <asp:ListItem Value="10">(GMT+10:00) Port Moresby</asp:ListItem>
                                    <asp:ListItem Value="10">(GMT+10:00) Sydney</asp:ListItem>
                                    <asp:ListItem Value="10">(GMT+10:00) Vladivostok</asp:ListItem>
                                    <asp:ListItem Value="11">(GMT+11:00) Magadan</asp:ListItem>
                                    <asp:ListItem Value="11">(GMT+11:00) New Caledonia</asp:ListItem>
                                    <asp:ListItem Value="11">(GMT+11:00) Solomon Is.</asp:ListItem>
                                    <asp:ListItem Value="12">(GMT+12:00) Auckland</asp:ListItem>
                                    <asp:ListItem Value="12">(GMT+12:00) Fiji</asp:ListItem>
                                    <asp:ListItem Value="12">(GMT+12:00) Kamchatka</asp:ListItem>
                                    <asp:ListItem Value="12">(GMT+12:00) Marshall Is.</asp:ListItem>
                                    <asp:ListItem Value="12">(GMT+12:00) Wellington</asp:ListItem>
                                    <asp:ListItem Value="13">(GMT+13:00) Nuku'alofa</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.pubDefLang"]%>
                            </td>
                            <td class="left CpLtr">
                                <asp:DropDownList ID="ddlPubDefLang" runat="server" AppendDataBoundItems="true" Width="550px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.cpDefLang"]%>
                            </td>
                            <td class="left CpLtr">
                                <asp:DropDownList ID="ddlCpDefLang" runat="server" AppendDataBoundItems="true" Width="550px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.serverDateFormat"]%>
                            </td>
                            <td class="left Cpltr">
                                <asp:DropDownList ID="ddlServerDateFormat" runat="server" Width="550px">
                                    <asp:ListItem Value="yyyy/MM/dd">yyyy/MM/dd</asp:ListItem>
                                    <asp:ListItem Value="dd/MM/yyyy">dd/MM/yyyy</asp:ListItem>
                                    <asp:ListItem Value="MM/dd/yyyy">MM/dd/yyyy</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.websiteName"]%>
                            </td>
                            <td class="left languageLtr">
                                <asp:TextBox ID="txtwebsiteName" runat="server" Width="550px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.singlePage"]%>
                            </td>
                            <td class="left languageLtr">
                                <asp:CheckBox ID="cbxSinglePage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.redirectToHome"]%>
                            </td>
                            <td class="left languageLtr">
                                <asp:CheckBox ID="cbxRedirectToHome" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table width="700px" style="display: inline-block">
                        <tr>
                            <td class="right ltr" style="width: 122px">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.thumbnail"]%>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr" style="width: 122px">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.thumbnail.width"]%>
                            </td>
                            <td class="left ltr">
                                <asp:TextBox ID="txtThumbWidth" runat="server" Width="250px" MaxLength="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvThumbWidth" runat="server" ErrorMessage="*" ControlToValidate="txtThumbWidth" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
                                
                            </td>
                            <td class="right ltr" style="width: 50px">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.thumbnail.height"]%>
                            </td>
                            <td class="left ltr">
                                <asp:TextBox ID="txtThumbHeight" runat="server" Width="250px" MaxLength="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvThumbHeight" runat="server" ErrorMessage="*" ControlToValidate="txtThumbHeight" ValidationGroup="ValGroup"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table width="700px" style="display: inline-block">
                        <tr>
                            <td class="right ltr" style="width: 122px">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.mailSetting.mail"]%>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">

                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.mailSetting.UserName"]%>
                            </td>
                            <td class="left ltr">
                                <asp:TextBox ID="txtMail" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.mailSetting.password"]%>
                            </td>
                            <td class="left ltr">
                                <asp:TextBox ID="txtMailPass" runat="server" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.mailSetting.host"]%>
                            </td>
                            <td class="left ltr">
                                <asp:TextBox ID="txtMailHost" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td class="right ltr" style="width: 50px">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.mailSetting.port"]%>
                            </td>
                            <td class="left ltr">
                                <asp:TextBox ID="txtMailPort" runat="server" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table width="700px" style="display: inline-block">
                        <tr>
                            <td class="right ltr" style="width: 122px">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.metaTages"]%>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr" style="width: 122px">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.metaTages.keyWords"]%>
                            </td>
                            <td class="left languageLtr">
                                <asp:TextBox ID="txtMetaKeyWord" runat="server" Width="550px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="right ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.metaTages.description"]%>
                            </td>
                            <td class="left languageLtr">
                                <asp:TextBox ID="txtMetaDesc" runat="server" Width="550px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table width="700px" style="display: inline-block">
                        <tr>
                            <td class="right ltr" style="width: 122px">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.listPage"]%>
                            </td>
                        </tr>
                        <tr>
                            <td class="right top ltr" style="width: 122px">

                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.listPage.horizental"]%>
                            </td>
                            <td class="left ltr">
                                <asp:TextBox ID="txtlistPageHorizontal" runat="server" Width="550px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="right top ltr">
                                <%=Farschidus.Translator.AppTranslate["settingPage.default.addEdit.listPage.vertical"]%>
                            </td>
                            <td class="left ltr">
                                <asp:TextBox ID="txtListPageVertical" runat="server" Width="550px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
