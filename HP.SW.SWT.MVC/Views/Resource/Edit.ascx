<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HP.SW.SWT.Entities.Resource>" %>

    <% using (Html.BeginForm("EditOk"))
       {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Recurso</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.T) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.T) %>
                <%: Html.ValidationMessageFor(model => model.T) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Cluster) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Cluster) %>
                <%: Html.ValidationMessageFor(model => model.Cluster) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <p>
                <input type="submit" value="Grabar" />
            </p>
        </fieldset>

    <% } %>
