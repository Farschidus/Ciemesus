<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThumbnailManager.ascx.cs" Inherits="Application_Ascx_ThumbnailManager" %>

<a class="thumbnailManager" href="javascript:togglePopUp('ThumbnailPopup')">
    <span><%= Farschidus.Translator.AppTranslate["ascx.thumbnail.setHeaderTitle"]%></span>
</a>
<div id="ThumbnailPopup">
    <div class="Popup">
        <div class="header">
            <span><%= Farschidus.Translator.AppTranslate["ascx.thumbnail.popupTitle"]%></span>
            <a class="close" href="javascript:togglePopUp('ThumbnailPopup')"></a>
        </div>
        <div class="body">
            <iframe runat="server" id='ThumbnailPopupFrame' width='100%' height='100%' src='/Application/ControlP/Thumbnail/Popup.aspx' frameborder='0'></iframe>
        </div>
    </div>
</div>
