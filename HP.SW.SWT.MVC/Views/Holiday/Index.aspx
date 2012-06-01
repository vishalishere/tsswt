<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HP.SW.SWT.Entities.Holiday>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Feriados
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Feriados</h2>

    <table>
        <tr>
            <th>
                <%= Html.LabelFor(model => model.First().Date) %>
            </th>
            <th>
                <%= Html.LabelFor(model => model.First().Description) %>
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: String.Format("{0:dd/MM/yyyy}", item.Date) %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: Html.ActionLink("Ver", "Details", new { date = item.Date })%> |
                <%: Html.ActionLink("Editar", "Edit", new { date=item.Date }) %> |
                <%: Html.ActionLink("Eliminar", "Delete", new { date=item.Date })%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>
