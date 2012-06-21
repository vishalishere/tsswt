<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script language='javascript' type='text/javascript'>
    function hideAllSubMenus() {
        $("#tbMenu").hide();
        $("#divHours").hide();
        $("#divAdmin").hide();
        $("#tbMenu").show();
    }
    function toggleSubMenu(td, popUp) {

        var jPopUp = $("#" + popUp);
        var isVisible = jPopUp.css("display") != "none";

        hideAllSubMenus();

        if (!isVisible) {

            var jTD = $(td);
            var jTDPos = jTD.position();
            var jTDWidth = jTD.outerWidth();
            var jTDHeight = jTD.outerHeight();
            var jPopUpWidth = jPopUp.innerWidth();

            jPopUp.css({
                top: (jTDPos.top + jTDHeight) + "px",
                left: jTDPos.left + "px"
            }).show();
        }
    }
</script>
<table id="tbMenu" border="0" cellpadding="0" cellspacing="0">
<tr>
    <td>
        <%: Html.ActionLink("Ticket", "Index", "Ticket") %>
    </td>
    <td style="cursor: pointer; width: 52px;" onclick="toggleSubMenu(this, 'divHours'); return false;">
        Horas
    </td>
    <td style="cursor: pointer; width: 92px;" onclick="toggleSubMenu(this, 'divAdmin'); return false;">
        Administración
    </td>
</tr>
</table>
<div id="divAdmin" style="background-color: White; display: none; position: absolute">
<table border="0" cellpadding="0" cellspacing="0" style="width: 102px;">
<tr>
    <td>
        <%: Html.ActionLink("Errores", "Index", "LogError") %>
    </td>
</tr>
<tr>
    <td>
        <%: Html.ActionLink("Cluster", "Index", "Cluster") %>
    </td>
</tr>
<tr>
    <td>
        <%: Html.ActionLink("Recursos", "Index", "Resource") %>
    </td>
</tr>
</table>
</div>
<div id="divHours" style="background-color: White; display: none; position: absolute">
<table border="0" cellpadding="0" cellspacing="0" style="width: 192px;">
<tr>
    <td>
        <%: Html.ActionLink("Carga de Horas", "Excel", "Resource") %>
    </td>
</tr>
<tr>
    <td>
        <%: Html.ActionLink("Reporte de Horas Mensuales", "MonthlyHours", "Period") %>
    </td>
</tr>
</table>
</div>