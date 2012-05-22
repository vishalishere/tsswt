<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Ticket>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > <%: Model.Title %> > Editar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
<style type="text/css">
    
    #menu
    {
        width: 100%; 
        height: 22px; 
        padding: 2px; 
        margin-bottom: 10px; 
        text-align: left; 
        background-color: #e8eef4;
    }
     
    #edit 
    {
        border-left: 0px none White;
    }

    #edit th
    {
        background-color: White;
        border-left: 0px none White;
        padding: 5px 10px;
        text-align: left;
        vertical-align: top;
    }

    #edit td
    {
        background-color: #e8eef4;
        border-top: 1px solid #696969;
        border-bottom: 1px solid #696969;
        border-right: 0px none White;
        padding: 5px 10px;
    }

    #edit td input
    {
        width: 100%;
    }

    #edit td textarea
    {
        width: 100%;
    }

    #edit td select
    {
        width: 100%;
    }

    #header, #footer 
    {
        border: 0px none White;
    }

    #header td, #footer td
    {
        border: 0px none White;
    }
</style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Html.ActionLink(Model.Title, "Details", new { id = Model.Number })%> > Editar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
    <table id="header" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td rowspan="2" style="text-align: right">
            <input type="submit" value="Grabar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
        </td>
    </tr> 
    </table>

    <div id="menu">
        &nbsp;
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Attach", id= Model.Number}) %>' style='color: #696969; font-weight: normal; text-decoration:none;'>
            <img src='<%= Url.Contents("Images/sharepoint_attach.png") %>' alt="Adjuntar Archivo" style="vertical-align: bottom;"  />&nbsp;&nbsp;Adjuntar Archivo
        </a>
        |
        <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Delete", id= Model.Number}) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
            <img src='<%= Url.Contents("Images/sharepoint_delete.png") %>' alt="Eliminar Ticket" style="vertical-align: bottom;"  />&nbsp;&nbsp;Eliminar Ticket
        </a>
    </div>

    <table id="edit" width="100%" border="0">
    <tr>
        <th><%: Html.LabelFor(model => model.Title) %></th>
        <td><%: Html.TextBoxFor(model => model.Title) %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Resource)%></th>
        <td><%: Html.DropDownListFor(model => model.Resource.T, (IEnumerable<SelectListItem>)ViewData["Resources"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Status)%></th>
        <td><%: Html.DropDownListFor(model => model.Status, (IEnumerable<SelectListItem>)ViewData["Statuses"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Priority) %></th>
        <td><%: Html.DropDownListFor(model => model.Priority, (IEnumerable<SelectListItem>)ViewData["Priorities"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Description) %></th>
        <td><%: Html.TextAreaFor(model => model.Description, new { rows = 4 })%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Category)%></th>
        <td><%: Html.DropDownListFor(model => model.Category, (IEnumerable<SelectListItem>)ViewData["Categories"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Comments)%></th>
        <td>
            <%: Html.TextAreaFor(model => model.NewComment, new { rows = 4 })%>
            <table>
    <% foreach (var comment in Model.Comments.OrderByDescending(c => c.Date)) { %>
            <tr>
                <td style="border: none 0px White">
                    <%: comment.User.Name %> &nbsp;(<%: String.Format("{0:g}", comment.Date)%>)
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
        <td><%: Html.TextBoxFor(model => model.DeliveryDate)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Cluster)%></th>
        <td><%: Html.DropDownListFor(model => model.Cluster.ID, (IEnumerable<SelectListItem>)ViewData["Clusters"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.System)%></th>
        <td><%: Html.TextBoxFor(model => model.System)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.EstimatedHours)%></th>
        <td><%: String.Format("{0:F1}", Model.EstimatedHours)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.DonePercentage)%></th>
        <td><%: String.Format("{0:P0}", Model.DonePercentage / 100)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.RealDeliveryDate)%></th>
        <td><%: Html.TextBoxFor(model => model.RealDeliveryDate)%></td>
    </tr>
    </table>

    <table id="footer" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align: left">
            Creado el <%: String.Format("{0:g}", Model.DateCreated) %> por <%: Model.UserCreated.Name %>
        </td>
        <td rowspan="2" style="text-align: right">
            <input type="submit" value="Grabar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
        </td>
    </tr> 
    <tr> 
        <td style="text-align: left">
            Modificado por última vez el <%: String.Format("{0:g}", Model.DateLastModified) %> por <%: Model.UserLastModified.Name %>
        </td>
    </tr> 
    </table>
    <% } %>
</asp:Content>
