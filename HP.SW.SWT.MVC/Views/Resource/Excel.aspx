<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HP.SW.SWT.Entities.ExcelRow>>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>
<%@ Import Namespace="HP.SW.SWT.Entities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Carga de Horas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script language='javascript' type='text/javascript' src='<%= Url.Script("dateutil.js") %>'></script>
    <script language='javascript' type='text/javascript' src='<%= Url.Script("Resource/Excel.js") %>'></script>
    <script language='javascript' type='text/javascript' src='<%= Url.Script("jquery/jquery.ui.datepicker.js") %>'></script>
    <script language='javascript' type="text/javascript">
        $(function () {
            $("[jType=txtDatePicker]").datepicker({
                buttonImage: '<%= Url.Contents("Images/calendar.png")%>',
                buttonImageOnly: true,
                dateFormat: 'dd/mm/yy',
                showOn: 'input'
            });
        });
    </script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Carga de Horas</h2>

    <p style="text-align: center">
        <img src='<%= Url.Contents("Images/ok.png") %>' id='imgOkTemplate' style='display:none' alt='grabar' />
		<%--<img src='<%= Url.Contents("Images/cancel.png") %>' id='imgCancelTemplate' style='display:none' alt='cancelar' />        --%>
        <img src='<%= Url.Contents("Images/delete.png") %>' id='imgDeleteTemplate' style='display:none' alt='borrar' />
        <button type="button" onclick="newTask();">Nueva Tarea</button>
        <button type="button" onclick="closeTask();">Cerrar Tarea</button>
        <button type="button" onclick="OkSave();">Grabar</button>
    </p>

    <table width="100%" id="tbExcel" style="text-align:center">
        <tr>
            <th>
                Fecha
            </th>
            <th>
                Hora Inicio
            </th>
            <th>
                Hora Fin
            </th>
            <th>
                Horas
            </th>
            <th>
                Ticket
            </th>
            <th>
                Descripci&oacute;n
            </th>
            <th>
                Cluster
            </th>
            <th>
                ¿Cargadas?
            </th>
            <th>
                Horas Cargadas
            </th>
            <th>
                Cargadas al Ticket
            </th>
            <th>
                Cargadas al usuario
            </th>
            <th style="display: none"></th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr onclick="editRow(this);" style="vertical-align:top">
            <td>
                <%--<label><%: String.Format("{0:dd/MM/yyyy}", item.Date) %></label><input type="hidden" value="<%: item.Id %>" />--%>
                <%--<label><%: String.Format("{0:dd/MM}", item.Date) %></label><input type="hidden" value="<%: item.Id %>" />--%>
                <%: String.Format("{0:dd/MM}", item.Date) %><input type="hidden" value="<%: item.Id %>" />
                <%--<input id="RowDate" jType="txtDatePicker" name="RowDate" readonly="readonly" style="width: 70px;" type="text" value="<%: String.Format("{0:dd/MM}", item.Date) %>" /><input type="hidden" value="<%: item.Id %>" />--%>
                <%--<input id="RowDate" jType="txtDatePicker" name="RowDate" readonly="readonly" style="width: 70px;" type="text" value="' + getDayString(new Date()) + '" />--%>
            </td>
            <td><%: String.Format("{0:HH:mm}", item.StartHour) %></td>
            <td><%: String.Format("{0:HH:mm}", item.EndHour)%></td>
            <td><%: String.Format("{0:F}", item.Hours) %></td>
            <td><%: item.Ticket %></td>
            <td><%: item.Description %></td>
            <td><%: item.Cluster %></td>
            <td><%: (item.SCPCharged == 0 ? "No" : "Si") %></td>
            <td><%: String.Format("{0:F}", item.SCPHours) %></td>
            <td><%: item.SCPTicket %></td>
            <td><%: item.SCPT %></td>
            <td style="display:none"></td>
<%--            <td style="display:none">
                <img src='<%= Url.Contents("Images/ok.png") %>' onclick='okRow(this);' style='cursor:pointer' alt='ok' />&nbsp;&nbsp;
                <img src='<%= Url.Contents("Images/cancel.png") %>' onclick='cancelRow(this);' style='cursor:pointer' alt='cancel' />
            </td>--%>
            <td style="display:none">
		        <%--<img src='<%= Url.Contents("Images/ok.png") %>' onclick='okRow(this);' style='cursor:pointer' alt='grabar' />&nbsp;&nbsp;--%>
		        <%--<img src='<%= Url.Contents("Images/cancel.png") %>' onclick='cancelRow(this);' style='cursor:pointer' alt='cancelar' />&nbsp;&nbsp;--%>
		        <img src='<%= Url.Contents("Images/delete.png") %>' onclick='deleteRow(this);' style='cursor:pointer' alt='borrar' />
            </td>
        </tr>
    
    <% } %>

    </table>
    <div style="display: none">
     <% using (Html.BeginForm("", "", FormMethod.Post, new { @id="form1"}))
        {%>        
            <input id="rowIndex" name="rowIndex" type="text" />
            <%: Html.TextBoxFor(model => model.FirstOrDefault().Id)%>
            <%--<%: Html.TextBoxFor(model => model.FirstOrDefault().Date)%>--%>
            <%: Html.DateBoxFor(model => model.FirstOrDefault().Date)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().StartHour)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().EndHour)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().Ticket)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().Description)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().Cluster)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().SCPCharged)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().SCPHours)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().SCPTicket)%>
            <%: Html.TextBoxFor(model => model.FirstOrDefault().SCPT)%>
    <% } %>
    </div>
</asp:Content>
