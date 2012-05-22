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
</style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Html.ActionLink(Model.Title, "Edit") %> > Editar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
    <div style="width: 100%; text-align: right">
        <input type="submit" value="Grabar" />
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
    </div>

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

    <table id="details" width="100%" border="0">
    <tr>
        <th><%: Html.LabelFor(model => model.Title) %></th>
        <td><%: Model.Title %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Resource)%></th>
        <td><%: Model.Resource.Name %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Status)%></th>
        <td><%: Model.Status %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Priority) %></th>
        <td><%: Model.Priority %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Description) %></th>
        <td><%: Model.Description %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Category)%></th>
        <td><%: Model.Category %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Comments)%></th>
        <td style="padding: 0px;">
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
        <td><%: String.Format("{0:dd/MM/yyyy}", Model.DeliveryDate) %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Cluster)%></th>
        <td><%: Model.Cluster %></td>
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

    <table style="width: 100%;">
    <tr>
        <td style="text-align: right">
            Creado el <%: String.Format("0:g", Model.DateCreated) %> por <%: Model.UserCreated.Name %>
            Modificado por última vez el <%: String.Format("0:g", Model.DateLastModified) %> por <%: Model.UserLastModified.Name %>
        </td>
        <td style="text-align: left">
            <input type="submit" value="Grabar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
        </td>
    </tr> 
    </table>
    <% } %>
</asp:Content>
