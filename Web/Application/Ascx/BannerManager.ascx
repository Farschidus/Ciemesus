<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerManager.ascx.cs" Inherits="Application_Ascx_BannerManager" %>

<a class="bannerManager" href="javascript:togglePopUp('BannerPopup')">
    <span><%= Farschidus.Translator.AppTranslate["ascx.banner.setHeaderTitle"]%></span>
</a>
<div id="BannerPopup">
    <div class="Popup">
        <div class="header">
            <span><%= Farschidus.Translator.AppTranslate["ascx.banner.popupTitle"]%></span>
            <a class="close" href="javascript:togglePopUp('BannerPopup')"></a>
        </div>
        <div class="body">
            <iframe runat="server" id='BannerPopupFrame' width='100%' height='100%' src='/Application/ControlP/Banner/Popup.aspx' frameborder='0'></iframe>
        </div>
    </div>
</div>