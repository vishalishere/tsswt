<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script language='javascript' type='text/javascript'>
    function toggleLogInOut(div, popUp) {
        var jPopUp = $("#" + popUp);
        if (jPopUp.css('display') != 'none') {

            jPopUp.hide();
        } else {

            
            var jDiv = $(div);
            var jDivPos = jDiv.position();
            var jDivWidth = jDiv.outerWidth();
            var jDivHeight = jDiv.outerHeight();
            var jPopUpWidth = jPopUp.innerWidth();

            jPopUp.css({
                top: (jDivPos.top + jDivHeight + 5) + "px",
                left: (jDivPos.left + jDivWidth - jPopUpWidth) + "px"
            }).show();
        }
    }
    
    function toggleLogIn(div) { toggleLogInOut(div, "logIn"); }
    function toggleLogOut(div) { toggleLogInOut(div, "logOut"); }
</script>
<%
    if (Request.IsAuthenticated) {
%>
        <div style="cursor: pointer" onclick='toggleLogOut(this); return false;'>
            <b>
                <%: Membership.GetUser(Page.User.Identity.Name).Comment %> (<%: Page.User.Identity.Name %>)
            </b>
        </div>
<%
    }
    else {
%> 
        <div style="cursor: pointer" onclick='toggleLogIn(this); return false;'>
            <b>
                Anónimo
            </b>
        </div>
<%
    }
%>
<div id="logIn">
    <table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <%: Html.ActionLink("Acceder", "LogOn", "Account") %>
        </td>
    </tr>
    <tr>
        <td>
            <%: Html.ActionLink("Registrarse", "Register", "Account")%>
        </td>
    </tr>
    </table>
</div>
<div id="logOut">
    <table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <%: Html.ActionLink("Salir", "LogOff", "Account")%>
        </td>
    </tr>
    <tr>
        <td>
            <%: Html.ActionLink("Cambiar Contraseña", "ChangePassword", "Account")%>
        </td>
    </tr>
    </table>
</div>
