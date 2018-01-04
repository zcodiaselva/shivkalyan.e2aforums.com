<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalendarEvents.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>e2aforums Admin</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link rel="icon" href="favicon.ico" type="image/x-icon" />
<!-- END META SECTION -->
<!-- CSS INCLUDE -->
<link rel="stylesheet" type="text/css" href="../E2Forums-New/css/cropper/cropper.min.css"/>
<!--  EOF CSS INCLUDE -->
<!-- CSS INCLUDE -->
<link rel="stylesheet" type="text/css" id="theme" href="../E2Forums-New/css/theme-default.css"/>
<link rel="stylesheet" type="text/css" id="Link1" href="../E2Forums-New/css/custom.css"/>
<!-- EOF CSS INCLUDE -->
    <style>

iframe
{
    border:none;
}
    </style>
</head>
<body>
      
<!-- START PAGE CONTAINER -->
<div class="page-container page-navigation-top-fixed">


<!-- Top Menu Control Start  --> 
    <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />
   
    <!-- Top Menu Control End  -->

<!-- PAGE CONTENT -->


<div class="page-content">
    <!-- Side Menu Control Start  -->
    <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />
    <!-- side Menu Control End  -->
     <div class="page-content-wrap"> 
      <div class="inner-content-wrap"> 

     <iframe src="CalendarEventsss.aspx" style="width:100%;height:768px"></iframe> 

   <HP:UserProfile ID="UserProfile" runat="server" />
               
             

          </div>
         </div>







</div>

    <!-- Footer BOX-->
    <HM:footerControl runat="server" ID="footerControl" />
    <!-- END Footer Box --> 
    <!---Comman Footer Scripts Start -->
    <HM:footerScriptControl runat="server" ID="footerScriptControl" />
    <!-- Comman Footer Scripts End--->


    <!-- Delete--->
  </div><!-- Page Container End -->


            <script src="../js/SJGrid.js"></script>
            <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
            
            <script src="js/toastr.js"></script>
            <script src="js/vendor/bootstrap.min.js"></script>
            <script src="js/plugins.js"></script>
           
            <script  src="js/FeedEk.js" type="text/javascript"></script>
            <script src="PagesJs/Users.js" type="text/javascript"></script>
            <script src="PagesJs/Common.js" type="text/javascript"></script>
            <script src="js/app.js"></script>
            <script src="js/jquery.tooltipster.js"></script>
        

            <script language="javascript" type="text/javascript">

                $(function () {

                    if ("<%=IsAdmin%>" == 'True') {
                        $('.adminLinks').show();
                        $('.UserLinks').hide();
                    }
                    if (VarUserTypeID != 2) {
                        $('.UserLinks').show();
                    }

                });



            </script>
    
</body>
</html>
