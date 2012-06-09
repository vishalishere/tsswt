<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.MVC.Models.MonthlyHoursModel>" %>
<%@ Import Namespace="HP.SW.SWT.Entities" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>
<%@ Import Namespace="HP.SW.SWT.MVC.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Horas Mensuales <%: Model.Period == null ? string.Empty : "de " + Model.Period.Description %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script language='javascript' type='text/javascript' src='<%= Url.Script("Period/MonthlyHours.js") %>'></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
    <link href='<%= Url.Contents("Redmond.css") %>' rel='stylesheet' type='text/css' />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

<%  using (Html.BeginForm()) 
    { %>
    <h2>
        Horas Mensuales de <%: Html.DropDownListFor(model => model.Period.ID, (IEnumerable<SelectListItem>)ViewData["Periods"], new { onchange = "this.form.submit();" })%>
        <img src='<%= Url.Contents("Images/MonthlyHoursDashboardReport.png") %>' alt='Informe para Dashboard' onclick='showDashboardReport("<%: "Informe para Dashboard de " +  Model.Period.Description %>", "<%: Url.Action("DashboardReport", new { id = Model.Period.ID })%>"); return false;' style="cursor: pointer; margin-bottom: -5px;" />
    </h2>
<%  } %>

    <table width="100%">
    <tr align="left">
        <th rowspan="2" style="background-color: White; border: 0px none white; vertical-align:middle;">Estimadas</th>
<%  
    DateTime firstDayOfTheMonth = new DateTime(Model.Period.StartDate.Year, Model.Period.StartDate.Month, 1);
    DateTime lastDayOfTheMonth = firstDayOfTheMonth.AddMonths(1).AddDays(-1);
    int firstMonthDays = lastDayOfTheMonth.Day - Model.Period.StartDate.Day + 1; %>
        <th colspan="<%: firstMonthDays %>"  style="padding: 3px 5px; background-color: #c8ced4; border: solid 1px #c8ced4;">
            <%: Model.Period.StartDate.ToString("MMMM").ToCapitalizedString() %>
        </th>
        <th colspan="<%: Model.Period.EndDate.Value.Day %>" style="padding: 3px 5px;">
            <%: Model.Period.EndDate.Value.ToString("MMMM").ToCapitalizedString() %>
        </th>
        <th rowspan="2" align="center" style="padding: 3px 0px;">
            Total
        </th>
    </tr>
    <tr align="center">
<%  for (int i = Model.Period.StartDate.Day; i <= lastDayOfTheMonth.Day; i++) 
    { %>
        <th style="padding: 3px 0px; background-color: #c8ced4; border: solid 1px #c8ced4;">
            <%: i %>
        </th>
<%  } %>

<%  for (int i = 1; i <= Model.Period.EndDate.Value.Day; i++) 
    { %>
        <th style="padding: 3px 0px;">
            <%: i %>
        </th>
<%  } %>
    </tr>
<%  foreach (MonthlyHoursModelEstimated r in Model.MonthlyHoursEstimated) 
    { %>
    <tr align="right">
        <th align="left">
            <%: r.Resource.Name %>
        </th>
    <%  foreach (ResourceAssignmentDay rae in r.HoursByDay) 
        {
            if (DateHelper.IsWorkingDay(rae.Date))
            { %>
        <td>
        <%  } 
            else 
            { %> 
        <td style='background-color: #C9C9C9'>
        <%  } %> 
            &nbsp;<%: string.Format("{0:F1}", rae.Hours) %>&nbsp;
        </td>
    <%  } %>
        <th>
            &nbsp;<%: string.Format("{0:F1}", r.HoursByDay.Sum(rae => rae.Hours)) %>&nbsp;
        </th>
    </tr>
<%  } %>
    <tr align="right">
        <th align="left" style="background-color: White; border: 0px none white; vertical-align:middle;">Total</th>
    <%  for (DateTime d = Model.Period.StartDate; d <= Model.Period.EndDate.Value; d = d.AddDays(1))
        {
            if (DateHelper.IsWorkingDay(d))
            { %>
        <th>
        <%  } 
            else 
            { %> 
        <th style='background-color: #C9C9C9'>
        <%  } %> 
            &nbsp;<%: string.Format("{0:F1}", Model.MonthlyHoursEstimated.Sum(rmhm => rmhm.HoursByDay.Where(rae => rae.Date == d).Sum(rae => rae.Hours))) %>&nbsp;
        </th>
    <%  } %>
        <th>
            &nbsp;<%: string.Format("{0:F1}", Model.MonthlyHoursEstimated.Sum(rmhm => rmhm.HoursByDay.Sum(rae => rae.Hours))) %>&nbsp;
        </th>
    </tr>
    <tr><td colspan="<%: firstMonthDays + Model.Period.EndDate.Value.Day + 2 %>">&nbsp;</td></tr>
    <tr align="left">
        <th rowspan="2" style="background-color: White; border: 0px none white; vertical-align:middle;">Reales</th>
        <th colspan="<%: firstMonthDays %>"  style="padding: 3px 5px; background-color: #c8ced4; border: solid 1px #c8ced4;">
            <%: Model.Period.StartDate.ToString("MMMM").ToCapitalizedString() %>
        </th>
        <th colspan="<%: Model.Period.EndDate.Value.Day %>" style="padding: 3px 5px;">
            <%: Model.Period.EndDate.Value.ToString("MMMM").ToCapitalizedString() %>
        </th>
        <th rowspan="2" align="center" style="padding: 3px 0px;">
            Total
        </th>
    </tr>
    <tr align="center">
<%  for (int i = Model.Period.StartDate.Day; i <= lastDayOfTheMonth.Day; i++) 
    { %>
        <th style="padding: 3px 0px; background-color: #c8ced4; border: solid 1px #c8ced4;">
            <%: i %>
        </th>
<%  } %>

<%  for (int i = 1; i <= Model.Period.EndDate.Value.Day; i++) 
    { %>
        <th style="padding: 3px 0px;">
            <%: i %>
        </th>
<%  } %>
    </tr>
<%  foreach (MonthlyHoursModelReal r in Model.MonthlyHoursReal) 
    { %>
    <tr align="right">
        <th align="left">
            <%: r.Resource.Name %>
        </th>
    <%  foreach (ResourceRealDay rae in r.HoursByDay) 
        { 
            if (DateHelper.IsWorkingDay(rae.Date))
            { %>
        <td>
        <%  } 
            else 
            { %> 
        <td style='background-color: #C9C9C9'>
        <%  }
            if (rae.IsReal)
            { %> 
            &nbsp;<a href='#' onclick='showExcelView("<%: "Horas de " + r.Resource.Name + " el día " + string.Format("{0:dd/MM/yyyy}", rae.Date) %>", "<%: Url.Action("ExcelView", "Resource", new { t = r.Resource.T, date = rae.Date })%>"); return false;'><%: string.Format("{0:F1}", rae.HoursInDay) %></a>&nbsp;
        <%  } 
            else 
            { %> 
            &nbsp;<%: string.Format("{0:F1}", rae.HoursInDay) %>&nbsp;
        <%  } %> 
        </td>
    <%  } %>
        <th>
            &nbsp;<%: string.Format("{0:F1}", r.HoursByDay.Sum(rae => rae.HoursInDay)) %>&nbsp;
        </th>
    </tr>
<%  } %>
    <tr align="right">
        <th align="left" style="background-color: White; border: 0px none white; vertical-align:middle;">Total</th>
    <%  for (DateTime d = Model.Period.StartDate; d <= Model.Period.EndDate.Value; d = d.AddDays(1))
        {
            if (DateHelper.IsWorkingDay(d))
            { %>
        <th>
        <%  } 
            else 
            { %> 
        <th style='background-color: #C9C9C9'>
        <%  } %> 
            &nbsp;<%: string.Format("{0:F1}", Model.MonthlyHoursReal.Sum(rmhm => rmhm.HoursByDay.Where(rae => rae.Date == d).Sum(rae => rae.HoursInDay))) %>&nbsp;
        </th>
    <%  } %>
        <th>
            &nbsp;<%: string.Format("{0:F1}", Model.MonthlyHoursReal.Sum(rmhm => rmhm.HoursByDay.Sum(rae => rae.HoursInDay))) %>&nbsp;
        </th>
    </tr>
    </table>
    <div id="dashboardReport" style="display:none;"></div>
    <div id="excelView" style="display:none;"></div>
</asp:Content>
