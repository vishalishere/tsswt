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

    <%: Html.ActionLink("Nuevo Ticket", "Create") %>
    <table style="width:100%" cellpadding="0" cellspacing="0">
        <tr align="center">
            <th onmouseover="showMenuImage(this); return false;" onmouseout="hideMenuImage(this); return false;">
                <table style="width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Número
                    </td>
                    <td align="right">
                        <img src='<%= Url.Contents("Images/arrowDown.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "Number"); return false;' />
                    </td>
                </tr>
                </table>
            </th>
            <th onmouseover="showMenuImage(this); return false;" onmouseout="hideMenuImage(this); return false;">
                <table style="width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Cluster
                    </td>
                    <td align="right">
                        <img src='<%= Url.Contents("Images/arrowDown.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "Cluster"); return false;' />
                    </td>
                </tr>
                </table>
            </th>
            <th onmouseover="showMenuImage(this); return false;" onmouseout="hideMenuImage(this); return false;">
                <table style="width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Fecha de Inicio
                    </td>
                    <td align="right">
                        <img src='<%= Url.Contents("Images/arrowDown.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "StartDate"); return false;' />
                    </td>
                </tr>
                </table>
            </th>
            <th onmouseover="showMenuImage(this); return false;" onmouseout="hideMenuImage(this); return false;">
                <table style="width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Fecha de Entrega
                    </td>
                    <td align="right">
                        <img src='<%= Url.Contents("Images/arrowDown.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "DeliveryDate"); return false;' />
                    </td>
                </tr>
                </table>
            </th>
            <th onmouseover="showMenuImage(this); return false;" onmouseout="hideMenuImage(this); return false;">
                <table style="width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Porcentaje de avance
                    </td>
                    <td align="right">
                        <img src='<%= Url.Contents("Images/arrowDown.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "DonePercentage"); return false;' />
                    </td>
                </tr>
                </table>
            </th>
            <th onmouseover="showMenuImage(this); return false;" onmouseout="hideMenuImage(this); return false;">
                <table style="width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Horas Estimadas
                    </td>
                    <td align="right">
                        <img src='<%= Url.Contents("Images/arrowDown.png") %>' style='visibility:hidden; cursor: pointer' alt='Opciones' onclick='showColumnOptions(this, "EstimatedHours"); return false;' />
                    </td>
                </tr>
                </table>
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr align="center">
            <td onmouseover="showMenuImage(this); return false;" onmouseout="hideMenuImage(this); return false;">
                <table style="width:100%; border: none 0px white" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border: none 0px white">
                        <%: Html.ActionLink(item.Number, "Details", new { id=item.Number }) %>
                    </td>
                    <td align="right" style="border: none 0px white">
                        <img src='<%= Url.Contents("Images/arrowDown2.png") %>' style='visibility:hidden; cursor: pointer' alt='Otras opciones' onclick='showRowOptions(this, "<%= item.Number %>"); return false;' />
                    </td>
                </tr>
                </table>
            </td>
            <td>
                <%: item.Cluster %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.StartDate) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DeliveryDate) %>
            </td>
            <td align="right">
                <%: String.Format("{0:F}", item.DonePercentage) %>
            </td>
            <td align="right">
                <%: String.Format("{0:F}", item.EstimatedHours) %>
            </td>
        </tr>
    
    <% } %>

    </table>
    <div id="columnNumberOptions" style="display: none; position: absolute; top: 10px; left: 10px; background-color: White">Number</div>
    <div id="columnClusterOptions" style="display: none; position: absolute; top: 10px; left: 10px; background-color: White">Cluster</div>
    <div id="columnStartDateOptions" style="display: none; position: absolute; top: 10px; left: 10px; background-color: White">StartDate</div>
    <div id="columnDeliveryDateOptions" style="display: none; position: absolute; top: 10px; left: 10px; background-color: White">DeliveryDate</div>
    <div id="columnDonePercentageOptions" style="display: none; position: absolute; top: 10px; left: 10px; background-color: White">DonePercentage</div>
    <div id="columnEstimatedHoursOptions" style="display: none; position: absolute; top: 10px; left: 10px; background-color: White">EstimatedHours</div>
    <div id="rowOptions" style="display: none; position: absolute; top: 10px; left: 10px; width: 100px; background-color: White"></div>
    <div id="rowOptionsTemplate" style="display: none">
        <table cellpadding="0" cellspacing="0" style="text-align: right" width="100%">
        <tr>
            <td>
                <%: Html.ActionLink("Ver", "Details", new { id = "TICKETNUMBER" }) %>                
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new { id = "TICKETNUMBER" })%>                
            </td>
        </tr>
        <tr>
            <td>
                <%: Html.ActionLink("Eliminar", "Delete", new { id = "TICKETNUMBER" })%>                
            </td>
        </tr>
        </table>
    </div>
</asp:Content>