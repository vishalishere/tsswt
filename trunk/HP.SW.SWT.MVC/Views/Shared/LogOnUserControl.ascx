<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        <b><%: Html.Encode(Membership.GetUser(Page.User.Identity.Name).Comment) %> (<%: Page.User.Identity.Name %>)</b>
<%
    }
    else {
%> 
        <b>Anónimo</b>
<%
    }
%>
