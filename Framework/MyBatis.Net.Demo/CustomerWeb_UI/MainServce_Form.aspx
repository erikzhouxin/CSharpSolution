<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainServce_Form.aspx.cs" Inherits="CustomerWeb_UI.MainServce_Form" %>

<%@ Register assembly="ComponentArt.Web.UI" namespace="ComponentArt.Web.UI" tagprefix="ComponentArt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test OF MyBatis Data Access Famework</title>

	<script src="http://cdn.jquerytools.org/1.2.5/full/jquery.tools.min.js"></script> 
	<link rel="stylesheet" type="text/css" href="http://static.flowplayer.org/tools/css/standalone.css"/>	
	<link rel="stylesheet" type="text/css" href="http://static.flowplayer.org/tools/css/tabs.css" /> 
    <script src="JavaScript/jquery.tablesorter.js"></script>
    <link  rel="stylesheet" type="text/css"  href="CSS/style.css" />
    <script>
        $(document).ready(function () {
            $("#myTable").tablesorter();
            }
        );

        $(document).ready(function () {
            $("#myTable").tablesorter({ sortList: [[0, 0], [1, 0]] });
            }
        ); 
    </script>
	<style>
	
    /* tab pane styling */
    .panes div {
	    display:none;		
	    padding:15px 10px;
	    border:1px solid #999;
	    border-top:0;
	    height:300px;
	    font-size:14px;
	    background-color:#fff;
              }
              
              
	</style> 
</head>


<body>
    <form id="Main_Service_Form" runat="server">

    <!-- This JavaScript snippet activates those tabs -->
          <script>

    // perform JavaScript after the document is scriptable.
    $(function () {
        // setup ul.tabs to work as tabs for each div directly under div.panes
        $("ul.tabs").tabs("div.panes > div");
    });
</script> 
    <!-- the tabs --> 
 <ul class="tabs"> 
	<li><a href="#">View All Services</a></li> 
	<li><a href="#">Add Room Service</a></li> 
	<li><a href="#">Update</a></li> 
    <li><a href="#">Delete</a></li> 
 </ul> 

  
<!-- tab "panes" --> 
<div class="panes"> 
	<div><table id="myTable" class="tablesorter"> 
<thead> 
<tr> 
    <th>Product ID</th> 
    <th>Product Name</th> 
    <th>Product Company</th> 
    <th>SignOn Data</th> 
    <th>Update Data</th> 
</tr> 
</thead> 
<tbody> 
<%=this.RefreshDateFromDevice() %>
</tbody> 
</table> 

</div>
    


	<div>Second tab content</div> 
	<div>Third tab content</div> 
    <div>Delete TAble</div>
</div> 
 
    <div>
        <asp:Button CssClass="panes" ID="InsertCus_But" runat="server" Height="30px" 
            onclick="InsertCus_But_Click" Text="Button" Width="130px" />

        <asp:Button ID="RefreshDate_But" runat="server" Text="Refresh Data"   onclick="RefreshDate_But_Click"  />
    </div>


    </form>
</body>
</html>
