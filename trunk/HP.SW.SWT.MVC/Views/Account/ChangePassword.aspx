<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.MVC.Models.ChangePasswordModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Cambio de clave
</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cambio de clave</h2>
    <p>
        Use el formulario para cambiar su clave.
    </p>
    <p>
        La nueva clave debe tener como mínimo <%: ViewData["PasswordLength"] %> caracteres.
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "El cambio de clave falló. Por favor corrija los errores e intentelo de nuevo.") %>
        <div>
            <fieldset>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.OldPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.OldPassword) %>
                    <%: Html.ValidationMessageFor(m => m.OldPassword) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.NewPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.NewPassword) %>
                    <%: Html.ValidationMessageFor(m => m.NewPassword) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </div>
                
                <p>
                    <input type="submit" value="Cambiar clave" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
