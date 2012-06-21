<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.MVC.Models.LogErrorIndexModel>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Log de Errores
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script language="javascript" type="text/javascript" src="<%= Url.Script("LogError/index.js") %>"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Log de Errores</h2>

<% using (Html.BeginForm("Index", "LogError", FormMethod.Post)) {%>
    <table border="0" style="border: 0px none white;">
    <tr style="border: 0px none white;">
        <td style="border: 0px none white; padding-right: 5px">
            <%: Html.LabelFor(model => model.Filter.Id) %>
        </td>
        <td colspan="3" style="border: 0px none white;">
            <%: Html.TextBoxFor(model => model.Filter.Id)%>
        </td>
    </tr>
    <tr style="border: 0px none white;">
        <td style="border: 0px none white; padding-right: 5px">
            <%: Html.LabelFor(model => model.Filter.DateFrom)%>
        </td>
        <td style="border: 0px none white;">
            <%: Html.DateBoxFor(model => model.Filter.DateFrom)%>
        </td>
        <td style="border: 0px none white; padding-right: 5px; padding-left:10px;">
            <%: Html.LabelFor(model => model.Filter.DateTo)%>
        </td>
        <td style="border: 0px none white;">
            <%: Html.DateBoxFor(model => model.Filter.DateTo)%>
        </td>
    </tr>
    <tr style="border: 0px none white;">
        <td colspan="4" align="left" style="border: 0px none white;">
            <input type="submit" value="Buscar" />
        </td>
    </tr>
    </table>
<% } %>
    <table width="100%">
    <tr align="center">
        <th>
            <%: Html.LabelFor(model => model.Data.FirstOrDefault().ID)%>
        </th>
        <th>
            <%: Html.LabelFor(model => model.Data.FirstOrDefault().Date)%>
        </th>
        <th>
            <%: Html.LabelFor(model => model.Data.FirstOrDefault().User)%>
        </th>
        <th>
            <%: Html.LabelFor(model => model.Data.FirstOrDefault().Message)%>
        </th>
    </tr>
    <% foreach (var item in Model.Data) { %>
    <tr align="center">
        <td>
            <a href="#" onclick="showDetails('<%: (item.Message.Length > 30 ? item.Message.Substring(0, 30) : item.Message) + " (" + item.ID + ")" %>', '<%: Url.Action("Details", new { id = item.ID })%>'); return false;"><%: item.ID %></a>
        </td>
        <td>
            <%: String.Format("{0:dd/MM/yyyy hh:mm:ss}", item.Date) %>
        </td>
        <td>
            <%: item.User.Name + " (" + item.User.Logon + ")" %>
        </td>
        <td>
            <%: item.Message %>
        </td>
    </tr>
    <% } %>
    </table>
    <div id="divDetails" style="display:none" />
</asp:Content>

