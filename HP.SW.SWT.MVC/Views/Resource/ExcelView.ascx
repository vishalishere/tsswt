<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<HP.SW.SWT.Entities.ExcelRow>>" %>

<table width="100%">
<tr>
    <th>
        <%= Html.LabelFor(model => model.First().Date) %>
    </th>
    <th>
        <%= Html.LabelFor(model => model.First().StartHour) %>
    </th>
    <th>
        <%= Html.LabelFor(model => model.First().EndHour) %>
    </th>
    <th>
        <%= Html.LabelFor(model => model.First().Hours) %>
    </th>
    <th>
        <%= Html.LabelFor(model => model.First().Ticket) %>
    </th>
    <th>
        <%= Html.LabelFor(model => model.First().Description) %>
    </th>
    <th>
        <%= Html.LabelFor(model => model.First().Cluster) %>
    </th>
    <th>
        <%= Html.LabelFor(model => model.First().SCPCharged) %>
    </th>
    <th>
        <%= Html.LabelFor(model => model.First().SCPHours) %>
    </th>
<%--    <th>
        <%= Html.LabelFor(model => model.First().SCPTicket) %>
    </th>--%>
    <th>
        <%= Html.LabelFor(model => model.First().SCPT)%>
    </th>
</tr>

<% foreach (var item in Model) { %>
<tr align="center">
    <td>
        <%: String.Format("{0:dd/MM/yyyy}", item.Date) %>
    </td>
    <td>
        <%: String.Format("{0:hh:mm:ss}", item.StartHour) %>
    </td>
    <td>
        <%: String.Format("{0:hh:mm:ss}", item.EndHour) %>
    </td>
    <td align="right">
        <%: String.Format("{0:F1}", item.Hours) %>
    </td>
    <td>
        <%: item.Ticket %>
    </td>
    <td align="left">
        <%: item.Description %>
    </td>
    <td>
        <%: item.Cluster %>
    </td>
    <td>
        <%: item.SCPCharged == 1 ? "SI": "NO" %>
    </td>
    <td align="right">
        <%: String.Format("{0:F1}", item.SCPHours) %>
    </td>
<%--    <td>
        <%: item.SCPTicket %>
    </td>--%>
    <td>
        <%: item.SCPT %>
    </td>
</tr>
<% } %>

</table>