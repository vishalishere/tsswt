<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Ticket>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > <%: Model.Title %> > Eliminar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
<style type="text/css">
    
    #delete
    {
        border-left: 0px none White;
    }

    #delete th
    {
        background-color: White;
        border-left: 0px none White;
        padding: 5px 10px;
        text-align: left;
        vertical-align: top;
    }

    #delete td
    {
        background-color: #e8eef4;
        border-top: 1px solid #696969;
        border-bottom: 1px solid #696969;
        border-right: 0px none White;
        padding: 5px 10px;
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

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Html.ActionLink(Model.Title, "Details", new { id = Model.Number })%> > Eliminar</h2>

    <h3>¿Está seguro de que desea eliminar este ticket?</h3>

    <% using (Html.BeginForm()) {%>

    <table id="header" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align: right">
            <input type="submit" value="Eliminar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
        </td>
    </tr> 
    </table>

    <table id="delete" width="100%" border="0">
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

    <table id="footer" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align: right">
            <input type="submit" value="Eliminar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
        </td>
    </tr> 
    </table>

    <% } %>

</asp:Content>
