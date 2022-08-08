<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PropertyManager.ascx.cs" Inherits="Application_Ascx_PropertyManager" %>

<a class="propertyManager" href="javascript:togglePopUp('PropertyPopup')">
    <span><%= Farschidus.Translator.AppTranslate["ascx.property.addProperties"]%></span>
</a>
<div id="PropertyPopup">
    <div class="Popup">
        <div class="header">
            <span><%= Farschidus.Translator.AppTranslate["ascx.property.popupTitle"]%></span>
            <a class="close" href="javascript:togglePopUp('PropertyPopup')"></a>
        </div>
        <div class="body">
            <iframe runat="server" id='PropertyPopupFrame' width='100%' height='100%' src='/Application/ControlP/SubjectProperties/Popup.aspx' frameborder='0'></iframe>
        </div>
    </div>
</div>