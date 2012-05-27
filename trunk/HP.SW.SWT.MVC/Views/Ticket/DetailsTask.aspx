<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Task>" %>
<%@ Import Namespace="HP.SW.SWT.Entities" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > <%: ((Ticket)ViewData["Ticket"]).Number %> - <%: ((Ticket)ViewData["Ticket"]).Title %> > Tareas > Ver Tarea <%: Model.Description %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
    <link href='<%= Url.Contents("Ticket/Details.css") %>' rel='stylesheet' type='text/css' />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Html.ActionLink(((Ticket)ViewData["Ticket"]).Number + " - " + ((Ticket)ViewData["Ticket"]).Title, "Edit", new { id = ((Ticket)ViewData["Ticket"]).Number })%> > <%: Html.ActionLink("Tareas", "Tasks", new { id = ((Ticket)ViewData["Ticket"]).Number }) %> > Ver Tarea <%: Model.Description %></h2>

    <div style="width: 100%; text-align: right">
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Tasks", id = ((Ticket)ViewData["Ticket"]).Number }) %>';" />
    </div>

    <div id="menu">
        <div style="width:100%; float: left; text-align: left">
            &nbsp;
            <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "EditTask", id= Model.ID }) %>' style='border-style: none; color: #696969; font-weight: normal; text-decoration:none;'>
                <img src='<%= Url.Contents("Images/sharepoint_task_edit.png") %>' alt="Editar Tarea" style="vertical-align: bottom;"  />&nbsp;&nbsp;Editar Tarea
            </a>
            |
            <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "DeleteTask", id= Model.ID }) %>' style='border-style: none; color: #696969; font-weight: normal; text-decoration:none'>
                <img src='<%= Url.Contents("Images/sharepoint_task_delete.png") %>' alt="Eliminar Tarea" style="vertical-align: bottom;" />&nbsp;&nbsp;Eliminar Tarea
            </a>
        </div>
    </div>

    <table id="details" width="100%" border="0">
    <tr>
        <th><%: Html.LabelFor(model => model.Description) %></th>
        <td><%: Model.Description %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.EstimatedHours) %></th>
        <td><%: Model.EstimatedHours %></td>
    </tr>
    </table>

    <div style="width: 100%; text-align: right">
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Tasks", id = ((Ticket)ViewData["Ticket"]).Number }) %>';" />
    </div>

</asp:Content>
