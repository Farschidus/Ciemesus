<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PluginManager.ascx.cs" Inherits="Application_Ascx_PluginManager" %>

<a class="pluginManager" href="javascript:togglePopUp('PluginPopup')">
    <span><%= Farschidus.Translator.AppTranslate["ascx.plugin.addPlugin"]%></span>
</a>
<div id="PluginPopup">
    <div class="Popup">
        <div class="header">
            <span><%= Farschidus.Translator.AppTranslate["ascx.plugin.popupTitle"]%></span>
            <a class="close" href="javascript:togglePopUp('PluginPopup')"></a>
        </div>
        <div class="body">
            <iframe runat="server" id='PluginPopupFrame' width='100%' height='100%' src='/Application/ControlP/Plugins/Popup.aspx' frameborder='0'></iframe>
        </div>
    </div>
</div>