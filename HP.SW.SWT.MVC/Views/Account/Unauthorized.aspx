<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.MVC.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Acceso no autorizado
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Acceso no autorizado</h2>
    <p>
        Bienvenido a SWT. 

        Ha tratado de acceder a <a href='<%: ViewData["OriginalUrl"] %>'><%: ViewData["Title"] %></a> para la cual no está habilitado. 
        
        Si cree que esto es incorrecto, por favor contacte al administrador del sistema.
    </p>

</asp:Content>
