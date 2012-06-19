<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.MVC.Models.LogErrorIndexModel>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Log de Errores
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Log de Errores</h2>

<% using (Html.BeginForm()) {%>
    <table>
        <tr>
            <td class="editor-label">
                <%: Html.LabelFor(model => model.Filter.Id) %>
            </td>
            <td class="editor-field">
                <%: Html.TextBoxFor(model => model.Filter.Id)%>
            </td>

            <td class="editor-label">
                <%: Html.LabelFor(model => model.Filter.DateFrom)%>
            </td>
            <td class="editor-field">
                <%: Html.DateBoxFor(model => model.Filter.DateFrom)%>
            </td>

            <td class="editor-label">
                <%: Html.LabelFor(model => model.Filter.DateTo)%>
            </td>
            <td class="editor-field">
                <%: Html.DateBoxFor(model => model.Filter.DateTo)%>
            </td>
           
        </tr>
    </table>
<% } %>
    <table>
        <tr>
            <th></th>
            <th>
                ID
            </th>
            <th>
                Date
            </th>
            <th>
                Message
            </th>
            <th>
                StackTrace
            </th>
        </tr>

    <% foreach (var item in Model.Data) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Details", "Details", new { id=item.ID })%> |               
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.Date) %>
            </td>
            <td>
                <%: item.Message %>
            </td>
            <td>
                <%: item.StackTrace %>
            </td>
        </tr>
    
    <% } %>

    </table>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

