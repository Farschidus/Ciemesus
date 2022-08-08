<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryList.ascx.cs" Inherits="Client_Ascx_GalleryList" %>
<div class="GalleryBar">
    <h3 class="GalleryBar-title"><%= Farschidus.Translator.AppTranslate["ascx.galleryList.lable.title"]%></h3>
    <div class="GalleryBar-content">
    <asp:Repeater ID="rptGalleryBar" runat="server" >
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="GalleryBar-Item">
                <a href='<%# mGetURL(Eval("Alias")) %>'>
                    <img alt='<%# Eval("Title") %>' title='<%# Eval("Title") %>' src='<%# mGetCoverImage(Eval("IDSubject")) %>' /> 
                </a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    </div>
</div>