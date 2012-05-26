<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Ticket>" %>
<%@ Import Namespace="HP.SW.SWT.Entities" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tickets > <%: Model.Title %> > Tareas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script language='javascript' type='text/javascript' src='<%= Url.Script("Ticket/Tasks.js") %>'></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
<style type="text/css">
    
    #details 
    {
        border-left: 0px none White;
     }

    #details th
    {
        background-color: White;
        border-left: 0px none White;
        padding: 5px 10px;
        text-align: left;
        vertical-align: top;
    }

    #details td
    {
        background-color: #e8eef4;
        border-top: 1px solid #696969;
        border-bottom: 1px solid #696969;
        border-right: 0px none White;
        padding: 5px 10px;
    }
</style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Html.ActionLink("Tickets", "Index") %> > <%: Html.ActionLink(Model.Title, "Edit", new { id = Model.Number })%> > Tareas</h2>

    <div style="width: 100%; text-align: right">
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Edit", id = Model.Number }) %>';" />
    </div>

    <table id="details" width="100%" border="0">
    <tr>
        <th><%: Html.LabelFor(model => model.Title) %></th>
        <td><%: Model.Title %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Resource)%></th>
        <td><%: Model.Resource == null ? string.Empty : Model.Resource.Name %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Status)%></th>
        <td><%: Model.Status.ToReadableString() %></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(model => model.Description) %></th>
        <td><%: Model.Description %></td>
    </tr>
    </table>

    <% foreach (TaskPhase phase in Enums.Get<TaskPhase>()) { %>
    
    <h3><%: phase.ToReadableString() %></h3>

    <table width="100%">
    <tr>
        <th colspan="2" align="left">
            &nbsp;
            <a href='<%= Url.RouteUrl(new { Controller= "Ticket", Action= "CreateTask", id = Model.Number, phase = phase, number = Model.Tasks.Where(t => t.Phase == phase).Count() }) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                <img src='<%= Url.Contents("Images/sharepoint_task_new.png") %>' alt="Nueva Tarea" style="vertical-align: bottom;" />&nbsp;&nbsp;Nueva Tarea
            </a>
        </th>
    </tr>
    <tr style="height:26px">
        <th align="left">
            <%= Html.LabelFor(model => model.Tasks.First().Description) %>
        </th>
        <th style="width:130px">
            <%= Html.LabelFor(model => model.Tasks.First().EstimatedHours)%>
        </th>
    </tr>

        <% int top = Model.Tasks.Where(t => t.Phase == phase).Count() - 1;
           foreach (var item in Model.Tasks.Where(t => t.Phase == phase).OrderBy(t=>t.Number)) { %>
    
    <tr>
        <td onmouseover="showMenuImage(this); return false;" onmouseout="hideMenuImage(this); return false;">
            <table style="width:100%; border: none 0px white" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td style="border: none 0px white">
                    <%: Html.ActionLink(item.Description, "DetailsTask", new { id = item.ID })%>
                </td>
                <td align="right" style="border: none 0px white">
                    <img src='<%= Url.Contents("Images/sharepoint_arrow_down.png") %>' style='visibility:hidden; cursor: pointer' alt='Otras opciones' onclick='optionsClick(this, "<%= item.ID %>", <%= (item.Number == 0).ToString().ToLowerInvariant() %>, <%= (item.Number == top).ToString().ToLowerInvariant() %>); return false;' />
                </td>
            </tr>
            </table>
        </td>
        <td align="right">
            <%: String.Format("{0:F1}", item.EstimatedHours) %>
        </td>
    </tr>
    
        <% } %>

    </table>

    <% } %>

    <div style="width: 100%; text-align: right">
        <input type="button" value="Cerrar" onclick="window.location = '<%= Url.RouteUrl(new { Controller= "Ticket", Action= "Edit", id = Model.Number }) %>';" />
    </div>

    <div id="rowOptions" style="display: none; position: absolute; border: solid 1px LightBlue; width: 130px; background-color: White"></div>
    <div id="rowOptionsTemplate" style="display: none">
        <table cellpadding="0" cellspacing="0" border="1" style="text-align: left; border: solid 1px LightBlue" width="100%">
        <tr style="height: 26px;">
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
            </td>
            <td style="border: none 0px White">
                <%: Html.ActionLink("Ver Tarea", "DetailsTask", new { id = "TASKID" }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        <tr>
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
                <a href='<%: Url.RouteUrl(new { Controller= "Ticket", Action= "EditTask", id = "TASKID" }) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                    <img src='<%= Url.Contents("Images/sharepoint_task_edit.png") %>' alt="Editar Tarea" />
                </a>
            </td>
            <td style="border: none 0px White">
                <%: Html.ActionLink("Editar Tarea", "EditTask", new { id = "TASKID" }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        <tr id="optionUp">
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
                <a href='<%: Url.RouteUrl(new { Controller= "Ticket", Action= "UpTask", id = "TASKID", ticketNumber = Model.Number }) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                    <img src='<%= Url.Contents("Images/sharepoint_task_up.png") %>' alt="Subir Tarea" />
                </a>
            </td>
            <td style="border: none 0px White">
                <%: Html.ActionLink("Subir Tarea", "UpTask", new { id = "TASKID", ticketNumber = Model.Number }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        <tr id="optionDown">
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
                <a href='<%: Url.RouteUrl(new { Controller= "Ticket", Action= "DownTask", id = "TASKID", ticketNumber = Model.Number  }) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                    <img src='<%= Url.Contents("Images/sharepoint_task_down.png") %>' alt="Bajar Tarea" />
                </a>
            </td>
            <td style="border: none 0px White">
                <%: Html.ActionLink("Bajar Tarea", "DownTask", new { id = "TASKID", ticketNumber = Model.Number }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        <tr>
            <td style="background-color: #e8eef4; border: none 0px #e8eef4">
                <a href='<%: Url.RouteUrl(new { Controller= "Ticket", Action= "DeleteTask", id = "TASKID" }) %>' style='color: #696969; font-weight: normal; text-decoration:none'>
                    <img src='<%= Url.Contents("Images/sharepoint_task_delete.png") %>' alt="Eliminar Tarea" />
                </a>
            </td>
            <td style="border: none 0px White">
                <%: Html.ActionLink("Eliminar Tarea", "DeleteTask", new { id = "TASKID" }, new { style = "color: #696969; font-weight: normal; text-decoration:none" })%>                
            </td>
        </tr>
        </table>
    </div>
</asp:Content>
