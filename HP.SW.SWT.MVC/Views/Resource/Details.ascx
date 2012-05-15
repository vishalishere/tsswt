<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HP.SW.SWT.Entities.Resource>" %>

    <fieldset>
        <legend>Recurso</legend>
        
        <div class="display-label">T</div>
        <div class="display-field"><%: Model.T %></div>
        
        <div class="display-label">Cluster</div>
        <div class="display-field"><%: Model.Cluster %></div>
        
        <div class="display-label">Nombre</div>
        <div class="display-field"><%: Model.Name %></div>
        
    </fieldset>


