<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Importar Carga de Horas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Importar Carga de Horas</h2>

    <% using (Html.BeginForm("Import", "Resource", null, FormMethod.Post, new { enctype = "multipart/form-data" }))
       { %>
        <br />
        Per&iacute;odo : <%: Html.DropDownList("periodId", (IEnumerable<SelectListItem>)ViewData["Periods"])%>
        <br />
        Recurso : <%: Html.DropDownList("T", (IEnumerable<SelectListItem>)ViewData["Resources"])%>
        <br />
        Archivo : <input type="file" id="file" name="file" />
        <br />
        <input type="submit" value="Importar" />
        <br />
        <span style="color:<%: ViewData["resultColor"] %>"><%: ViewData["result"] %><//span>
    <% } %>
</asp:Content>
