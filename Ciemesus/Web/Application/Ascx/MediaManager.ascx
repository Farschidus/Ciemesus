<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MediaManager.ascx.cs"  Inherits="Application_Ascx_MediaManager" %>

<a class="mediaManager" href="javascript:togglePopUp('MediaPopup')">
    <span><%= Farschidus.Translator.AppTranslate["ascx.media.addFile"]%></span>
</a>
<div id="MediaPopup">
    <div class="Popup">
        <div class="header">
            <span><%= Farschidus.Translator.AppTranslate["ascx.media.popupTitle"]%></span>
            <a class="close" href="javascript:togglePopUp('MediaPopup')"></a>
        </div>
        <div class="body">
            <iframe runat="server" id='MediaPopupFrame' width='100%' height='100%' src='/Application/ControlP/Media/Popup.aspx' frameborder='0'></iframe>
        </div>
    </div>
</div>
