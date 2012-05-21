<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Ticket>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Ver ticket <%: Model.Number %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ticket <%: Model.Number %></h2>

    <fieldset>

        <div class="display-label"><%: Html.LabelFor(model => model.Cluster) %></div>
        <div class="display-field"><%: Model.Cluster %></div>
        
        <div class="display-label"><%: Html.LabelFor(model => model.StartDate) %></div>
        <div class="display-field"><%: String.Format("{0:dd/MM/yyyy}", Model.StartDate)%></div>
        
        <div class="display-label"><%: Html.LabelFor(model => model.DeliveryDate) %></div>
        <div class="display-field"><%: String.Format("{0:dd/MM/yyyy}", Model.DeliveryDate)%></div>
        
        <div class="display-label"><%: Html.LabelFor(model => model.DonePercentage)%></div>
        <div class="display-field"><%: String.Format("{0:F}", Model.DonePercentage) %></div>
        
        <div class="display-label"><%: Html.LabelFor(model => model.EstimatedHours)%></div>
        <div class="display-field"><%: String.Format("{0:F}", Model.EstimatedHours) %></div>

        <div class="display-label"><%: Html.LabelFor(model => model.Comments)%></div>
        <div class="display-field">
        <table width="100%" style="border: none 0px white">
    <% foreach (var comment in Model.Comments.OrderBy(c => c.Date)) { %>
        <tr>
            <td colspan="2" style="border: none 0px white">
                <span style="font-weight: bold"><%: comment.User.Name %></span> 
                - <span style="font-style:italic"><%: String.Format("{0:dd/MM/yyyy hh:mm:ss}", comment.Date)%></span>
            </td>
        </tr>
        <tr>
            <td style="border: none 0px white; ">
                <span style="margin: 20px; ">
                    <%: comment.Comment %> 
                </span>
            </td>
        </tr>
    <% }%>
        </table>
        </div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id = Model.Number }) %> |
        <%: Html.ActionLink("Volver", "Index") %>
    </p>

</asp:Content>
