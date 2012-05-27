<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Task>" %>
<%@ Import Namespace="HP.SW.SWT.Entities" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > <%: ((Ticket)ViewData["Ticket"]).Number %> - <%: ((Ticket)ViewData["Ticket"]).Title %> > Tareas > Editar Tarea <%: Model.Description %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
    <link href='<%= Url.Contents("Ticket/Edit.css") %>' rel='stylesheet' type='text/css' />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Html.ActionLink(((Ticket)ViewData["Ticket"]).Number + " - " + ((Ticket)ViewData["Ticket"]).Title, "Edit", new { id = ((Ticket)ViewData["Ticket"]).Number })%> > <%: Html.ActionLink("Tareas", "Tasks", new { id = ((Ticket)ViewData["Ticket"]).Number }) %> > Editar Tarea <%: Model.Description %></h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

    <table id="header" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align: right">
            <input type="submit" value="Grabar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Tasks", id = ((Ticket)ViewData["Ticket"]).Number }) %>';" />
        </td>
    </tr> 
    </table>

    <div id="menu">
        <div style="width:70%; float: left; text-align: left">
            &nbsp;
            <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "DeleteTask", id= Model.ID }) %>' style='border-style: none; color: #696969; font-weight: normal; text-decoration:none'>
                <img src='<%= Url.Contents("Images/sharepoint_task_delete.png") %>' alt="Eliminar Tarea" style="vertical-align: bottom;" />&nbsp;&nbsp;Eliminar Tarea
            </a>
        </div>
        <div style="width:30%; float: left;">
            <div style="width: 100%; height: 4px;">
            </div>
            <div style="width: 100%; text-align: right; vertical-align: bottom">
                <span style="color: Red">*</span> indicates a required field&nbsp;
            </div>
        </div>
    </div>

    <%: Html.HiddenFor(model => model.TicketNumber) %>
    <%: Html.HiddenFor(model => model.Phase) %>
    <%: Html.HiddenFor(model => model.Number) %>
    <table id="edit" width="100%" border="0">
    <tr>
        <th><%: Html.LabelFor(model => model.Description) %>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.TextBoxFor(model => model.Description) %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.EstimatedHours) %>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.TextBoxFor(model => model.EstimatedHours) %></td>
    </tr>
    </table>

    <table id="footer" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align: right">
            <input type="submit" value="Grabar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Tasks", id = ((Ticket)ViewData["Ticket"]).Number }) %>';" />
        </td>
    </tr> 
    </table>

    <% } %>

</asp:Content>
