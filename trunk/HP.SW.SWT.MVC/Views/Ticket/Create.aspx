<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Ticket>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > Nuevo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script language='javascript' type='text/javascript' src='<%= Url.Script("jquery/jquery.ui.datepicker.js") %>'></script>
    <script language='javascript' type="text/javascript">
        $(function () {
            $("[jType=txtDatePicker]").datepicker({
                buttonImage: '<%= Url.Contents("Images/calendar.png")%>',
                buttonImageOnly: true,
                dateFormat: 'dd/mm/yy',
                showOn: 'button'
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
    <link href='<%= Url.Contents("Redmond.css") %>' rel='stylesheet' type='text/css' />
    <link href='<%= Url.Contents("Ticket/Create.css") %>' rel='stylesheet' type='text/css' />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > Nuevo</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
    <table id="header" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align: right">
            <input type="submit" value="Grabar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
        </td>
    </tr> 
    </table>
    <div id="menu">
        <div style="width:70%; float: left; text-align: left">
            &nbsp;
        </div>
        <div style="width:30%; float: left;">
            <div style="width: 100%; height: 4px;">
            </div>
            <div style="width: 100%; text-align: right; vertical-align: bottom">
                <span style="color: Red">*</span> indicates a required field&nbsp;
            </div>
        </div>
    </div>
    <table id="create" width="100%" border="0">
    <tr>
        <th><%: Html.LabelFor(model => model.Number) %>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.TextBoxFor(model => model.Number)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Title) %>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.TextBoxFor(model => model.Title) %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Resource)%></th>
        <td><%: Html.DropDownListFor(model => model.Resource.T, (IEnumerable<SelectListItem>)ViewData["Resources"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Status)%>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.DropDownListFor(model => model.Status, (IEnumerable<SelectListItem>)ViewData["Statuses"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Priority) %>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.DropDownListFor(model => model.Priority, (IEnumerable<SelectListItem>)ViewData["Priorities"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Description) %>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.TextAreaFor(model => model.Description, new { rows = 4 })%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Category)%>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.DropDownListFor(model => model.Category, (IEnumerable<SelectListItem>)ViewData["Categories"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Comments)%></th>
        <td><%: Html.TextAreaFor(model => model.NewComment, new { rows = 4 })%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.DeliveryDate)%></th>
        <td><%: Html.DateBoxFor(model => model.DeliveryDate)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Cluster)%>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.DropDownListFor(model => model.Cluster.ID, (IEnumerable<SelectListItem>)ViewData["Clusters"], "--seleccione--")%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.System)%>&nbsp;<span style="color: Red">*</span></th>
        <td><%: Html.TextBoxFor(model => model.System)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.RealDeliveryDate)%></th>
        <td><%: Html.DateBoxFor(model => model.RealDeliveryDate)%></td>
    </tr>
    </table>
    <table id="footer" style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td rowspan="2" style="text-align: right">
            <input type="submit" value="Grabar" />
            <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Index"}) %>';" />
        </td>
    </tr> 
    </table>
    <% } %>
</asp:Content>
