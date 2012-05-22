<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HP.SW.SWT.Entities.Ticket>>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script language='javascript' type='text/javascript' src='<%= Url.Script("Ticket/Index.js") %>'></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Tickets</h2>

    
    <table style="width:100%" cellpadding="0" cellspacing="0">
    <tr>
        <th colspan="6" align="left" style="border-bottom: solid 1px #e8eef4; padding: 3px;">
            <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Create"}) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                <img src='<%= Url.Contents("Images/sharepoint_new.png") %>' alt="Nuevo Ticket" />Nuevo Ticket
            </a>
        </th>
        <th colspan="5" align="right" style="border-bottom: solid 1px #e8eef4; padding: 3px;">
            <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src='<%= Url.Contents("Images/sharepoint_previous_page.png") %>' alt="Anterior" onclick="previous_page()" style='cursor: pointer; display:<%= (bool)ViewData["FirstPage"] ? "none" : "block" %>' />
                </td>
                <td>
                    <%= ViewData["FirstRowNumber"] %> - <%= ViewData["LastRowNumber"] %>
                </td>
                <td>
                    <img src='<%= Url.Contents("Images/sharepoint_next_page.png") %>' alt="Siguiente" onclick="next_page()" style='cursor: pointer; display:<%= (bool)ViewData["LastPage"] ? "none" : "block" %>' />
                </td>
            </tr>
            </table>
        </th>
    </tr>
    <tr align="center">
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    # Ticket
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "Number"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Título
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "Title"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Asignado A
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "AssignedTo"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Status
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "Status"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Prioridad
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "Priority"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Cluster
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "Cluster"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Sistema
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "System"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Fecha Est. De Entrega
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "DeliveryDate"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Estimación
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "EstimatedHours"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Porcentaje De Avance
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "DonePercentage"); return false;' />
                </td>
            </tr>
            </table>
        </th>
        <th onmouseover="showColumnMenuImage(this); return false;" onmouseout="hideColumnMenuImage(this); return false;">
            <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Fecha Real De Entrega
                </td>
                <td align="right">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "DeliveryDate"); return false;' />
                </td>
            </tr>
            </table>
        </th>
    </tr>

    <% foreach (var item in Model) { %>
    
    <tr align="center">
        <td onmouseover="showRowMenuImage(this); return false;" onmouseout="hideRowMenuImage(this); return false;">
            <table style="width:100%; border: none 0px white" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td style="border: none 0px white">
                    <%: Html.ActionLink(item.Number, "Details", new { id=item.Number }) %>
                </td>
                <td align="right" style="border: none 0px white">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Otras opciones' onclick='rowOptionsClick(this, "<%= item.Number %>"); return false;' />
                </td>
            </tr>
            </table>
        </td>
        <td>
            <%: item.Title %>
        </td>
        <td>
            <%: item.Resource.Name %>
        </td>
        <td>
            <%: item.Status %>
        </td>
        <td>
            <%: item.Priority %>
        </td>
        <td>
            <%: item.Cluster.ShortDescription %>
        </td>
        <td>
            <%: item.System %>
        </td>
        <td>
            <%: String.Format("{0:dd/MM/yyyy}", item.DeliveryDate) %>
        </td>
        <td align="right">
            <%: String.Format("{0:F}", item.EstimatedHours) %>
        </td>
        <td align="right">
            <%: String.Format("{0:F}", item.DonePercentage) %>
        </td>
        <td>
            <%: String.Format("{0:dd/MM/yyyy}", item.RealDeliveryDate)%>
        </td>
    </tr>
    
    <% } %>

    <tr>
        <th colspan="11" align="center">
            <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src='<%= Url.Contents("Images/sharepoint_previous_page.png") %>' alt="Anterior" onclick="previous_page()" style='cursor: pointer; display:<%= (bool)ViewData["FirstPage"] ? "none" : "block" %>' />
                </td>
                <td>
                    <%= ViewData["FirstRowNumber"] %> - <%= ViewData["LastRowNumber"] %>
                </td>
                <td>
                    <img src='<%= Url.Contents("Images/sharepoint_next_page.png") %>' alt="Siguiente" onclick="next_page()" style='cursor: pointer; display:<%= (bool)ViewData["LastPage"] ? "none" : "block" %>' />
                </td>
            </tr>
            </table>
        </th>
    </tr>
    </table>
    <div id="columnNumberOptions" style="display: none; position: absolute; background-color: White">Number</div>
    <div id="columnClusterOptions" style="display: none; position: absolute; background-color: White">Cluster</div>
    <div id="columnStartDateOptions" style="display: none; position: absolute; background-color: White">StartDate</div>
    <div id="columnDeliveryDateOptions" style="display: none; position: absolute; background-color: White">DeliveryDate</div>
    <div id="columnDonePercentageOptions" style="display: none; position: absolute; background-color: White">DonePercentage</div>
    <div id="columnEstimatedHoursOptions" style="display: none; position: absolute; background-color: White">EstimatedHours</div>
    <div id="rowOptions" style="display: none; position: absolute; border: solid 1px LightBlue; width: 125px; background-color: White"></div>
    <div id="rowOptionsTemplate" style="display: none">
        <table cellpadding="0" cellspacing="0" border="1" style="text-align: left; border: solid 1px LightBlue" width="100%">
        <tr>
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
            </td>
            <td style="border: none 0px White">
                <%: Html.ActionLink("Ver Ticket", "Details", new { id = "TICKETNUMBER" }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        <tr>
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
                <a href='<%: Url.RouteUrl(new { Controller= "Ticket", Action= "Edit", id = "TICKETNUMBER" }) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                    <img src='<%= Url.Contents("Images/sharepoint_edit.png") %>' alt="Editar Ticket" />
                </a>
            </td>
            <td style="border: none 0px White">
                <%: Html.ActionLink("Editar Ticket", "Edit", new { id = "TICKETNUMBER" }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        <tr>
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
                <a href='<%: Url.RouteUrl(new { Controller= "Ticket", Action= "Delete", id = "TICKETNUMBER" }) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                    <img src='<%= Url.Contents("Images/sharepoint_delete.png") %>' alt="Eliminar Ticket" />
                </a>
            </td>
            <td style="border: none 0px White">
                <%: Html.ActionLink("Eliminar Ticket", "Delete", new { id = "TICKETNUMBER" }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        <tr>
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
                <a href='<%: Url.RouteUrl(new { Controller= "Ticket", Action= "History", id = "TICKETNUMBER" }) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                    <img src='<%= Url.Contents("Images/sharepoint_history.png") %>' alt="Ver Historial" />
                </a>
            </td>
            <td style="border-top: solid 1px LightBlue">
                <%: Html.ActionLink("Ver Historial", "History", new { id = "TICKETNUMBER" }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        </table>
    </div>
</asp:Content>