<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tinyMCE.ascx.cs" Inherits="Application_Ascx_tinyMCE" %>
<script type="text/javascript" src="/Application/Scripts/tinyMCE/tiny_mce.js"></script>
<script type="text/javascript" src="/Application/Scripts/tinyMCE/jquery.tinymce.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        initializetinyMCE();
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initializetinyMCE);
    });
    function initializetinyMCE() {
        $('.miniTinyMCE').tinymce({
            mode: "textareas",
            theme: "advanced",
            width: "780px",
            Height: "370px",
            directionality: ChangeDirection(),
            language: "en",
            convert_urls: false,
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            plugins: "directionality,fullscreen,paste",
            theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,ltr,rtl,|,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,forecolor,backcolor,|,sub,sup,|,fullscreen",
            theme_advanced_buttons3: "",
            file_browser_callback: "filebrowser",
            extended_valid_elements: "video[width|height|controls],source[src|type],input[aria-invalid|placeholder|required|class|id|type],textarea[aria-invalid|placeholder|required|class|id|type],figure"
        });
        setTimeout(TinyMceEncode, 300);
    }
    function filebrowser(field_name, url, type, win) {
        fileBrowserURL = "/Application/ControlP/FileManager/Default.aspx?sessionid=<%= Session.SessionID.ToString() %>";
        tinyMCE.activeEditor.windowManager.open({
            title: "File Manager",
            url: fileBrowserURL,
            width: 950,
            height: 650,
            inline: 0,
            maximizable: 1,
            close_previous: 0
        }, {
            window: win,
            input: field_name,
            sessionid: '<%= Session.SessionID.ToString() %>'
            }
		    );
        }
        function TinyMceEncode() {
            $('.miniTinyMCE').val($('#<%= TCMEValue.ClientID %>').val().replace(/&lt;/g, "<").replace(/&gt;/g, ">"));
        }
        function TinyMceDecode() {
            $('#<%= TCMEValue.ClientID %>').val($('.miniTinyMCE').val().replace(/</g, "&lt;").replace(/>/g, "&gt;"));
            setTimeout(TinyMceEncode, 300);
        }
</script>

<asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Width="780px" Height="370px"
    class="miniTinyMCE"></asp:TextBox>
<asp:HiddenField ID="TCMEValue" runat="server" EnableViewState="true" />
