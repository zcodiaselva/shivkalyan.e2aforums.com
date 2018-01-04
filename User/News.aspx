<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>





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
      
<!-- START PAGE CONTAINER -->
<div class="page-container page-navigation-top-fixed">


<!-- Top Menu Control Start  --> <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />
   
    <!-- Top Menu Control End  -->

<!-- PAGE CONTENT -->
<div class="page-content">
    <!-- Side Menu Control Start  -->
    <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />
    <!-- side Menu Control End  -->
     <div class="page-content-wrap bgn"> 

               <div class="page-title">
      <h2><i class="fa fa-envelope-o"></i> News</h2>
    </div>
    <!-- PAGE CONTENT WRAPPER -->
    
    <div class="row">
      <div class="col-md-12">
        <div class="col-md-3"> 
          <!-- CONTACT ITEM -->
          <div class="panel panel-default">
            <div class="panel-body profile">
              <div class="profile-image"> <img alt="" src="../ashi/images/vinay-khosla.jpg"> </div>
              <div class="profile-data">
                <div class="profile-data-name">Changes to Tax Rates </div>
              </div>
              <div class="profile-controls"> 
                  <a onclick="return ShowProfileModal(20260)" data-toggle="modal" class="profile-control-left"  href="#modal-regular-Profile">
                  <span   class="fa fa-info"></span></a> <a class="profile-control-right" target="_blank" href="../UserDocs/ChangestoTaxRates.pdf"><i class="fa fa-download"></i></span></a> </div>
            </div>
            <div class="panel-body">
              <div class="newsletter-info">
                <div class="col-md-6">
                  <div class="row">
                    <p><small><i class="fa fa-calendar"></i>Date Posted</small><br>
                    Oct 27, 2015</p>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="row">
                    <p><small><i class="fa fa-user"></i>Submitted By</small><br>
                    Vinay Khosla</p>
                  </div>
                </div>
              </div>
            </div>
          </div>

                <div class="panel panel-default">
            <div class="panel-body profile">
              <div class="profile-image"> <img alt="" src="../ashi/images/vinay-khosla.jpg"> </div>
              <div class="profile-data">
                <div class="profile-data-name">The Ontario Retirement Pension Plan</div>
              </div>
              <div class="profile-controls"> 
                  <a onclick="return ShowProfileModal(20260)" data-toggle="modal" class="profile-control-left"  href="#modal-regular-Profile">
                  <span   class="fa fa-info"></span></a> <a class="profile-control-right" target="_blank" href="../UserDocs/TheOntarioRetirementPensionPlan.pdf"><i class="fa fa-download"></i></span></a> </div>
            </div>
            <div class="panel-body">
              <div class="newsletter-info">
                <div class="col-md-6">
                  <div class="row">
                    <p><small><i class="fa fa-calendar"></i>Date Posted</small><br>
                     Aug 17, 2015</p>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="row">
                    <p><small><i class="fa fa-user"></i>Submitted By</small><br>
                     Vinay Khosla</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!-- END CONTACT ITEM --> 
        </div>
      </div>
    </div> 
   
                

            <HP:UserProfile ID="UserProfile" runat="server" />


         
         </div>

</div><!-- Page Container End -->

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


    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
 
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>  
    <script src="js/FileReader.js"></script>  
    
     <script src="PagesJs/Common.js" type="text/javascript"></script>   
    
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
