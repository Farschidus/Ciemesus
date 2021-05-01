<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Masters/Public.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="Pages_Page_Default" %>

<%@ Register Src="~/Client/Ascx/Contact.ascx" TagName="Contact" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        input[type="radio"] {
            margin: 0 5px 0 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMain" runat="Server">
    <section id="PageTitle">
        <div class="container">
            <div class="row">
                <div class="col-md-12 title-green">
                    <h1>
                        <asp:Literal ID="litPageTitle" runat="server"></asp:Literal>
                    </h1>
                </div>
            </div>
        </div>
    </section>
    <div id="Body" class="contact">
        <div class="container">
            <uc1:Contact ID="Contact1" runat="server" TypeVisibility="true" />
        </div>
    </div>
</asp:Content>