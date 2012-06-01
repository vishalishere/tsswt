<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Ticket>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > <%: Model.Number %> - <%: Model.Title %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
    <link href='<%= Url.Contents("Ticket/Details.css") %>' rel='stylesheet' type='text/css' />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Model.Number %> - <%: Model.Title %></h2>

    <div style="width: 100%; text-align: right">
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
    </div>

    <div id="menu">
        &nbsp;
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Create"}) %>' style='border-style: none; color: #696969; font-weight: normal; text-decoration:none'>
            <img src='<%= Url.Contents("Images/sharepoint_new.png") %>' alt="Nuevo Ticket" style="vertical-align: bottom;" />&nbsp;&nbsp;Nuevo Ticket
        </a>
        |
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Edit", id= Model.Number}) %>' style='border-style: none; color: #696969; font-weight: normal; text-decoration:none;'>
            <img src='<%= Url.Contents("Images/sharepoint_edit.png") %>' alt="Editar Ticket" style="vertical-align: bottom;"  />&nbsp;&nbsp;Editar Ticket
        </a>
        |
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Delete", id= Model.Number}) %>' style='border-style: none; color: #696969; font-weight: normal; text-decoration:none'>
            <img src='<%= Url.Contents("Images/sharepoint_delete.png") %>' alt="Eliminar Ticket" style="vertical-align: bottom;"  />&nbsp;&nbsp;Eliminar Ticket
        </a>
        |
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "History", id= Model.Number}) %>' style='border-style: none; color: #696969; font-weight: normal; text-decoration:none'>
            <img src='<%= Url.Contents("Images/sharepoint_history.png") %>' alt="Ver Historial" style="vertical-align: bottom;"  />&nbsp;&nbsp;Ver Historial
        </a>
    </div>

    <table id="details" width="100%" border="0">
    <tr>
        <th><%: Html.LabelFor(model => model.Title) %></th>
        <td><%: Model.Title %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Resource)%></th>
        <td><%: Model.Resource == null ? string.Empty : Model.Resource.Name %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Status)%></th>
        <td><%: Model.Status.ToReadableString() %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Priority) %></th>
        <td><%: Model.Priority.ToReadableString() %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Description) %></th>
        <td><%: Model.Description %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Category)%></th>
        <td><%: Model.Category.ToReadableString()%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Comments)%></th>
        <td style="padding: 0px;">
            <table>
    <% foreach (var comment in Model.Comments.OrderByDescending(c => c.Date)) { %>
            <tr>
                <td style="border: none 0px White">
                    <%: comment.User.Name %> &nbsp;(<%: String.Format("{0:dd/MM/yyyy hh:mm:ss}", comment.Date)%>)
                </td>
            </tr>
            <tr>
                <td style="border: none 0px White; padding-left: 20px">
                    <%: comment.Comment %> 
                </td>
            </tr>
    <% } %>
            </table>
        </td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.DeliveryDate)%></th>
        <td><%: String.Format("{0:dd/MM/yyyy}", Model.DeliveryDate) %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Cluster)%></th>
        <td><%: Model.Cluster.Description %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.System)%></th>
        <td><%: Model.System %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.EstimatedHours)%></th>
        <td><%: String.Format("{0:F1}", Model.EstimatedHours) %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.DonePercentage)%></th>
        <td><%: String.Format("{0:P0}", Model.DonePercentage / 100)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.RealDeliveryDate)%></th>
        <td><%: String.Format("{0:dd/MM/yyyy}", Model.RealDeliveryDate) %></td>
    </tr>
    </table>

    <div style="width: 100%; text-align: right">
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
    </div>
</asp:Content>
