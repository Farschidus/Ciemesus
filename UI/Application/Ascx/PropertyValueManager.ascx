<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PropertyValueManager.ascx.cs" Inherits="Application_Ascx_PropertyValueManager" %>

<a class="propertyValueManager" href="javascript:togglePopUp('PropertyValuePopup')">
    <span><%= Farschidus.Translator.AppTranslate["ascx.propertyValue.addPropertyValue"]%></span>
</a>
<div id="PropertyValuePopup">
    <div class="Popup">
        <div class="header">
            <span><%= Farschidus.Translator.AppTranslate["ascx.propertyValue.popupTitle"]%></span>
            <a class="close" href="javascript:togglePopUp('PropertyValuePopup')"></a>
        </div>
        <div class="body">
            <iframe runat="server" id='PropertyValuePopupFrame' width='100%' height='100%' src='/Application/ControlP/SubjectPropertyValues/Popup.aspx' frameborder='0'></iframe>
        </div>
    </div>
</div>