<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LatestNewsAdmin.aspx.cs" Inherits="User_pro" %>

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
    <!-- PAGE CONTENT WRAPPER -->
         <div class="search-area-wrapper">
            <div class="search-area container">
            
                <p class="search-tag-line">Assign & Approve user for Latest News submission.</p>

                <div class="search-form clearfix" id="search-form">
                    <input type="text" title="* Please enter a search term!"  placeholder="Type your search terms here"  id="searchFullNameTxt" class="search-term required" autocomplete="off"/>
                    <input type="submit" onclick="searchByNameAdmin()" value="Search" class="search-btn"/>
                    <div id="search-error-container"></div>
                </div>
            </div>
        </div>

<div class="container">
<div class="row">
  <section class="col-md-8 col-sm-6 col-xs-12">

<div class="panel-body">

                            <div class="panel panel-default tabs">
                                <ul class="nav nav-tabs nav-justified">
                                    <li class="active"><a href="#techTip" onclick="searchByNameAdmin()" data-toggle="tab">Assign Latest News</a></li>
                                    <li><a href="#approveTechTip" onclick="return latestNewsApproveSearch();" data-toggle="tab">Approve Latest News</a></li>
                                </ul>


                                <div class="panel-body tab-content">
                                    <div class="tab-pane active" id="techTip">

                                <div class="panel-body list-group list-group-contacts scroll" style="height:300px">                                
                                 <div id="AssignlatestNewsMemberList">


                                 </div>

                                             
                                </div>
                                    </div>

                                    <div class="tab-pane" id="approveTechTip">

             <div class="panel-body list-group list-group-contacts scroll" style="height:300px">                                
              <div id="latestNewsApproveList">


              </div>
                
                </div>
                                    </div>
                                
                                </div>
                            </div>  
</div>
          
  </section> 
  <aside class="col-md-4 col-sm-6 col-xs-12">
    <div class="panel-body">
    <div class="support-widget">
    <h3 class="title">Support</h3>
    <p class="intro">Need more support? If you did not found an answer, <br><strong><a target="_blank" href="../support.aspx">contact us </a></strong>  for further help.</p>
    </div>
    </div>
  </aside>
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

 <script type="text/javascript">
     latestNewsMemberAssignSearch();

 </script>
    <script src="PagesJs/latestNews.js" type="text/javascript"></script>
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
