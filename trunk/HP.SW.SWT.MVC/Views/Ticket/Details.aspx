<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Ticket>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > <%: Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Model.Title %></h2>

    <div style="width: 100%; text-align: right">
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
    </div>

    <div style="width: 100%; height: 22px; padding: 2px; text-align: left; background-color: #e8eef4">
        &nbsp;
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Create"}) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
            <img src='<%= Url.Contents("Images/sharepoint_new.png") %>' alt="Nuevo Ticket" style="vertical-align: bottom;" />&nbsp;&nbsp;Nuevo Ticket
        </a>
        |
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Edit", id= Model.Number}) %>' style='color: #696969; font-weight: normal; text-decoration:none;'>
            <img src='<%= Url.Contents("Images/sharepoint_edit.png") %>' alt="Editar Ticket" style="vertical-align: bottom;"  />&nbsp;&nbsp;Editar Ticket
        </a>
        |
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Delete", id= Model.Number}) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
            <img src='<%= Url.Contents("Images/sharepoint_delete.png") %>' alt="Eliminar Ticket" style="vertical-align: bottom;"  />&nbsp;&nbsp;Eliminar Ticket
        </a>
        |
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "History", id= Model.Number}) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
            <img src='<%= Url.Contents("Images/sharepoint_history.png") %>' alt="Ver Historial" style="vertical-align: bottom;"  />&nbsp;&nbsp;Ver Historial
        </a>
    </div>

    <table width="100%">
    <tr>
        <td class="display-label">Number</td>
        <td class="display-field"><%: Model.Number %></td>
    </tr>
    <tr>
        <td class="display-label">Title</td>
        <td class="display-field"><%: Model.Title %></td>
    </tr>
    <tr>
        <td class="display-label">Description</td>
        <td class="display-field"><%: Model.Description %></td>
    </tr>
    <tr>
        <td class="display-label">Cluster</td>
        <td class="display-field"><%: Model.Cluster %></td>
    </tr>
    <tr>
        <td class="display-label">System</td>
        <td class="display-field"><%: Model.System %></td>
    </tr>
    <tr>
        <td class="display-label">StartDate</td>
        <td class="display-field"><%: String.Format("{0:g}", Model.StartDate) %></td>
    </tr>
    <tr>
        <td class="display-label">DeliveryDate</td>
        <td class="display-field"><%: String.Format("{0:g}", Model.DeliveryDate) %></td>
    </tr>
    <tr>
        <td class="display-label">RealDeliveryDate</td>
        <td class="display-field"><%: String.Format("{0:g}", Model.RealDeliveryDate) %></td>
    </tr>
    <tr>
        <td class="display-label">ConsumedHours</td>
        <td class="display-field"><%: String.Format("{0:F}", Model.ConsumedHours) %></td>
    </tr>
    <tr>
        <td class="display-label">EstimatedHours</td>
        <td class="display-field"><%: String.Format("{0:F}", Model.EstimatedHours) %></td>
    </tr>
    <tr>
        <td class="display-label">PendingHours</td>
        <td class="display-field"><%: String.Format("{0:F}", Model.PendingHours) %></td>
    </tr>
    <tr>
        <td class="display-label">ConsumedHoursForecast</td>
        <td class="display-field"><%: String.Format("{0:F}", Model.ConsumedHoursForecast) %></td>
    </tr>
    <tr>
        <td class="display-label">StartDateForecast</td>
        <td class="display-field"><%: String.Format("{0:g}", Model.StartDateForecast) %></td>
    </tr>
    <tr>
        <td class="display-label">DeliveryDateForecast</td>
        <td class="display-field"><%: String.Format("{0:g}", Model.DeliveryDateForecast) %></td>
    </tr>
    <tr>
        <td class="display-label">DonePercentage</td>
        <td class="display-field"><%: String.Format("{0:F}", Model.DonePercentage) %></td>
    </tr>
    </table>

    <div style="width: 100%; text-align: right">
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
    </div>
</asp:Content>
