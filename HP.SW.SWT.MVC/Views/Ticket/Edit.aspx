<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Ticket>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Number) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Number) %>
                <%: Html.ValidationMessageFor(model => model.Number) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Cluster) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Cluster) %>
                <%: Html.ValidationMessageFor(model => model.Cluster) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StartDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StartDate, String.Format("{0:g}", Model.StartDate)) %>
                <%: Html.ValidationMessageFor(model => model.StartDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DeliveryDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DeliveryDate, String.Format("{0:g}", Model.DeliveryDate)) %>
                <%: Html.ValidationMessageFor(model => model.DeliveryDate) %>
            </div>
            
            <p>
                <input type="submit" value="Actualizar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Volver", "Index") %>
    </div>

</asp:Content>
