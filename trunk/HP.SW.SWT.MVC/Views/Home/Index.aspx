<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="HP.SW.SWT.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Servicio Web Tracking Tool
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script language='javascript' type='text/javascript' src='<%= Url.Script("holiday.ashx") %>'></script>
    <script language='javascript' type='text/javascript' src='<%= Url.Script("dateutil.js") %>'></script>
    <script language='javascript' type='text/javascript' src='<%= Url.Script("canvasutil.js") %>'></script>
    <script language='javascript' type='text/javascript' src='<%= Url.Script("jquery/jquery.ui.datepicker.js") %>'></script>
    <script language='javascript' type='text/javascript' src='<%= Url.Script("Home/Index.js") %>'></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="StyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <img id='imgCanvasInfo' src='<%= Url.Contents("Images/canvasinfo.png") %>' alt='canvas info' style='display:none' onload='reloadDashboard();' />
    <div style='width:30%; float:left;text-align:right;border-right: solid 1px blue; height:760px;'>
		<img src='<%= Url.Contents("Images/reload.png") %>' onclick='reloadAssignments();' style='cursor:pointer' alt='reload' />
		<table id='resourceAssignment' style='width:100%; text-align:center'></table>
	</div>
	<div style='width:70%;float:left'>
        <div style='width:70%;float:left;text-align:left'>
            &nbsp;&nbsp;
            Fecha:  <input type="text" id="dashboardDate" style="width:70px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            Orden:  <select id='dashboardOrder' onchange='reloadDashboard();'>
                        <option value='0' selected='selected'>
                            Por porcentaje de completitud (menor)
                        </option>
                        <option value='1'>
                            Por porcentaje de completitud (mayor)
                        </option>
                        <option value='2'>
                            Por desvio en horas (menor)
                        </option>
                        <option value='3'>
                            Por desvio en horas (mayor)
                        </option>
                        <option value='4'>
                            Por desvio en fecha (menor)
                        </option>
                        <option value='5'>
                            Por desvio en fecha (mayor)
                        </option>
                    </select>
            &nbsp;&nbsp;&nbsp;&nbsp;
            Cluster:  <select id='dashboardCluster' onchange='reloadDashboard();'>
                        <option value='' selected='selected'>
                            Todos
                        </option>
                        <option value='HR'>
                            HR
                        </option>
                        <option value='MANT'>
                            Mantenimiento
                        </option>
                        <option value='QST'>
                            QST
                        </option>
                        <option value='TMC'>
                            TMC
                        </option>
                    </select>
        </div>
        <div style='width:30%;float:left;text-align:right'>
		    <img src='<%= Url.Contents("Images/reload.png") %>' onclick='reloadDashboard();' style='cursor:pointer' alt='reload' />
        </div>
    	<div style='width:100%; height: 730px; overflow-y:scroll; text-align:center'>
		    <canvas id='cnvTrackingTool' style='border:solid 1px black;' width='900px'></canvas>
        </div>
	</div>
</asp:Content>