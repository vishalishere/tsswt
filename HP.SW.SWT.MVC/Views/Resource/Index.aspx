<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CRUD.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HP.SW.SWT.Entities.Resource>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Recursos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Recursos</h2>

    <table>
        <tr>
            <th></th>
            <th>
                T
            </th>
            <th>
                Cluster
            </th>
            <th>
                Nombre
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <a href='#' onclick='showCRUDDialog("Detalles", "<%: Url.Action("Details", new { id=item.T.Replace("\\", "_") }) %>"); return false;'>Ver</a> |
                <a href='#' onclick='showCRUDDialog("Edición", "<%: Url.Action("Edit", new { id=item.T.Replace("\\", "_") }) %>"); return false;'>Editar</a> |
                <a href='#' onclick='showCRUDDialog("Eliminar", "<%: Url.Action("Delete", new { id=item.T.Replace("\\", "_") }) %>"); return false;'>Eliminar</a>
            </td>
            <td>
                <%: item.T %>
            </td>
            <td>
                <%: item.Cluster %>
            </td>
            <td>
                <%: item.Name %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <a href='#' onclick='showCRUDDialog("NuevoRecurso", "<%: Url.Action("Create") %>"); return false;'>Nuevo Recurso</a>
    </p>

</asp:Content>

