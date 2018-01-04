<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebConference.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<!-- META SECTION -->
<title>E2aforums Admin</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
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
</head>
<body>
      <div>
<!-- START PAGE CONTAINER -->
<div class="page-container page-navigation-top-fixed">


<!-- Top Menu Control Start  --> <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />
   
    <!-- Top Menu Control End  -->

<!-- PAGE CONTENT -->
<div class="page-content">
    <!-- Side Menu Control Start  -->
    <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />
    <!-- side Menu Control End  -->

    <div class="web-cam">
      <iframe src="webCams.aspx" style="width:100%;height:768px">

      </iframe> 
    </div>
     <div class="page-content-wrap bgn"> 
<div class="inner-content-wrap">
    
<div class="tab-content">
    
        


</div>
       
    </div>
         </div> 
   
                

            


         
         </div>

</div><!-- Page Container End -->



<!-- Edit Tip Tech -->







    <!-- Footer BOX-->
    <HM:footerControl runat="server" ID="footerControl" />

<!-- END Footer Box --> 
    <!---Comman Footer Scripts Start -->
    <HM:footerScriptControl runat="server" ID="footerScriptControl" />

    <!-- Comman Footer Scripts End--->


    <!-- Delete--->
  </div>
 <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
    <a href="#" id="to-top"><i class="fa fa-angle-double-up"></i></a>

        <script src="PagesJs/techtips.js" type="text/javascript"></script>
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
 
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>  
    <script src="js/FileReader.js"></script>  
    

    <script src="js/ajaxfileupload.js"></script>
     <script src="PagesJs/Common.js" type="text/javascript"></script>
    <script src="js/jquery.tooltipster.js"></script>
   
   
    
    
    <style>
.profileAddress {
  color: #fff;
  float: left;
  position: absolute;
  right: 22px;
  width: 260px;
}
.profileDes {
  float: left;
  overflow-y: hidden;
  text-align: justify;
  width: 83%;
}
.profileAddress > p {
  display: none;
}
.profilePopHeader {
  float: left;
  height: auto;
}
.newsletter-info p {
  font-size: 11px;
}
</style>
</body>
</html>





