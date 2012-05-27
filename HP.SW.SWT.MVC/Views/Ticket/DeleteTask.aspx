<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Task>" %>
<%@ Import Namespace="HP.SW.SWT.Entities" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > <%: ((Ticket)ViewData["Ticket"]).Number %> - <%: ((Ticket)ViewData["Ticket"]).Title %> > Tareas > Eliminar Tarea <%: Model.Description %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
    <link href='<%= Url.Contents("Ticket/Delete.css") %>' rel='stylesheet' type='text/css' />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Html.ActionLink(((Ticket)ViewData["Ticket"]).Number + " - " + ((Ticket)ViewData["Ticket"]).Title, "Edit", new { id = ((Ticket)ViewData["Ticket"]).Number })%> > <%: Html.ActionLink("Tareas", "Tasks", new { id = ((Ticket)ViewData["Ticket"]).Number }) %> > Eliminar Tarea <%: Model.Description %></h2>

    <h3>¿Está seguro de que desea eliminar esta tarea?</h3>

    <% using (Html.BeginForm()) {%>

    <table id="header" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align: right">
            <input type="submit" value="Eliminar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Tasks", id = Model.TicketNumber }) %>';" />
        </td>
    </tr> 
    </table>

    <%: Html.HiddenFor(model => model.TicketNumber) %>
    <table id="delete" width="100%" border="0">
    <tr>
        <th><%: Html.LabelFor(model => model.Description) %></th>
        <td><%: Model.Description %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.EstimatedHours) %></th>
        <td><%: Model.EstimatedHours %></td>
    </tr>
    </table>

    <table id="footer" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align: right">
            <input type="submit" value="Eliminar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Tasks", id = Model.TicketNumber }) %>';" />
        </td>
    </tr> 
    </table>

    <% } %>

</asp:Content>
