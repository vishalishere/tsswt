<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HP.SW.SWT.Entities.Holiday>" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Date) %>
            </div>
            <div class="editor-field">
                <%: Html.DateBoxFor(model => model.Date)%>
                <%: Html.ValidationMessageFor(model => model.Date) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
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