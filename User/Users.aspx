<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>E2aforums Admin</title>
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

        
                <!-- Forum Block -->
                <div class="block">
                    <!-- Tab Content -->
                    <div class="tab-content">
                        <!-- Forum -->
                        <div class="block-title">
                            <h2>User Listing</h2>

                        </div>
                        <!-- Datatables Content -->
                        <div class="table-responsive">
                           <%-- <div id="TblUserDetails_wrapper" class="dataTables_wrapper" role="grid">--%>

                                <div class="row"></div>

                                <table id="TblUsers" class="table table-vcenter table-condensed table-bordered">
                                </table>
                           <%-- </div>--%>
                        </div>

                    </div>
                    <div id="modal-View-Rss" class="modal" tabindex="-1" role="dialog" aria-hidden="true" style="display: none;overflow:auto;max-height:600px;">
                        <form id="form_View-Rss" action="" method="post" enctype="multipart/form-data"
                            class="form-horizontal form-bordered" onsubmit="return false;">
                            <div class="modal-dialog" style="width:700px;">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" id="btn_hideViewRssModal" data-dismiss="modal" aria-hidden="true">
                                            &times;</button>
                                        <h3 id="headerTitle" class="modal-title">View RSS Feed
                                        </h3>
                                    </div>
                                    <div style="background-color:#ffffff;width:690px;min-height:200px;overflow:auto;">
                                 <div id="div_RssFeedTitle" class="mousescroll" style="min-height:200px;overflow:auto;width:150px;float:left;margin-left:10px;">
                                 </div>

                                    	 <div class="media-body" id="feedContainer" style="width:500px;float:right;margin-right:7px;overflow:auto;max-height:450px;">
                                         
                                        </div>
                                        </div>
                                </div>
                     
                            </div>
                        </form>
                            </div>
                    </div>


                    <footer class="clearfix">
                        <!--<div class="pull-right">
                        Crafted with <i class="fa fa-heart text-danger"></i> by <a href="http://goo.gl/vNS3I" target="_blank">pixelcave</a>
                    </div>-->
                        <div class="pull-left">
                            <span id="year-copy"></span>&copy; <a href="#">e2aForums</a>
                        </div>
                    </footer>
                    <!-- END Forum Block -->

               
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
            <script src="js/plugins.js"></script>
           
            <script src="js/FeedEk.js" type="text/javascript"></script>
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
