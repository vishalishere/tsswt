<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HP.SW.SWT.Entities.LogError>" %>
<style>
    #tbData
    {
        width: 100%;
    }

    #tbData th
    {
        text-align: left;
        padding-left: 10px;
        width: 120px;
    }

    #tbData td
    {
        text-align: right;
        padding-right: 10px;
        width: 600px;
    }
</style>
<table id="tbData">
<tr>
    <th><%: Html.LabelFor(model => model.Date) %></th>
    <td><%: String.Format("{0:dd/MM/yyyy hh:mm:ss}", Model.Date) %></td>
</tr>
<tr>
    <th><%: Html.LabelFor(model => model.Message) %></th>
    <td><%: Model.Message %></td>
</tr>
<tr>
    <th><%: Html.LabelFor(model => model.Message) %></th>
    <td><%: Model.User.Name + " (" + Model.User.Logon + ")" %></td>
</tr>
<tr>        
    <th><%: Html.LabelFor(model => model.StackTrace) %></th>
    <td><%: Model.StackTrace %></td>
</tr>
</table>