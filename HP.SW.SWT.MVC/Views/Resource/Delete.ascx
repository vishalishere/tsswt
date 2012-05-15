<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HP.SW.SWT.Entities.Resource>" %>

    <h3>Está seguro que desea eliminar este recurso?</h3>
    <fieldset>
        <legend>Recurso</legend>
        
        <div class="display-label">T</div>
        <div class="display-field"><%: Model.T %></div>
        
        <div class="display-label">Cluster</div>
        <div class="display-field"><%: Model.Cluster %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
    </fieldset>
    <% using (Html.BeginForm("DeleteOk")) { %>
        <p>
		    <input type="submit" value="Borrar" />
        </p>
    <% } %>


