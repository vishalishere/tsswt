<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HP.SW.SWT.MVC.Models.DashboardReportModel>" %>
<style>
    #tbData
    {
        width: 100%;
    }

    #tbData th
    {
        text-align: left;
        padding-left: 10px;
    }

    #tbData td
    {
        text-align: right;
        padding-right: 10px;
    }
</style>
<table id="tbData">
<tr>
    <th><%: Html.LabelFor(model => model.Initial) %></th>
    <td><%: Html.DisplayFor(model => model.Initial) %></td>
</tr>
<tr>        
    <th><%: Html.LabelFor(model => model.ScheduledAbsences) %></th>
    <td><%: Html.DisplayFor(model => model.ScheduledAbsences) %></td>
</tr>
<tr>        
    <th><%: Html.LabelFor(model => model.NonScheduledAbsences) %></th>
    <td><%: Html.DisplayFor(model => model.NonScheduledAbsences) %></td>
</tr>
<tr>        
    <th><%: Html.LabelFor(model => model.Rework) %></th>
    <td><%: Html.DisplayFor(model => model.Rework) %></td>
</tr>
<tr>        
    <th><%: Html.LabelFor(model => model.NonCertifiable) %></th>
    <td><%: Html.DisplayFor(model => model.NonCertifiable) %></td>
</tr>
<tr>        
    <th><%: Html.LabelFor(model => model.Leverage) %></th>
    <td><%: Html.DisplayFor(model => model.Leverage) %></td>
</tr>
<tr>        
    <th><%: Html.LabelFor(model => model.Total) %></th>
    <td><%: Html.DisplayFor(model => model.Total)%></td>
</tr>
</table>
