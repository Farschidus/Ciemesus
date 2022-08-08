<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BodyGalleryManager.ascx.cs"  Inherits="Application_Ascx_BodyGalleryManager" %>

<a class="bodyGalleryManager" href="javascript:togglePopUp('BodyGalleryPopup')">
    <span><%= Farschidus.Translator.AppTranslate["ascx.bodyGallery.addFile"]%></span>
</a>
<div id="BodyGalleryPopup">
    <div class="Popup">
        <div class="header">
            <span><%= Farschidus.Translator.AppTranslate["ascx.bodyGallery.popupTitle"]%></span>
            <a class="close" href="javascript:togglePopUp('BodyGalleryPopup')"></a>
        </div>
        <div class="body">
            <iframe runat="server" id='BodyGalleryPopupFrame' width='100%' height='100%' src='/Application/ControlP/Media/BodyGalleryPopup.aspx' frameborder='0'></iframe>
        </div>
    </div>
</div>
