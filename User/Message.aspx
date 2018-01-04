<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="User_Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">

    <title>Messages</title>

    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">

    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="img/circularlogo.png">
    <link rel="apple-touch-icon" href="img/icon57.png" sizes="57x57">
    <link rel="apple-touch-icon" href="img/icon72.png" sizes="72x72">
    <link rel="apple-touch-icon" href="img/icon76.png" sizes="76x76">
    <link rel="apple-touch-icon" href="img/icon114.png" sizes="114x114">
    <link rel="apple-touch-icon" href="img/icon120.png" sizes="120x120">
    <link rel="apple-touch-icon" href="img/icon144.png" sizes="144x144">
    <link rel="apple-touch-icon" href="img/icon152.png" sizes="152x152">
    <!-- END Icons -->

    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <%-- <link rel="stylesheet" href="css/bootstrap.min.css">--%>
    <link href="../css/Bootstrap2.css" rel="stylesheet" />
    <link href="css/toastr.css" rel="stylesheet" />
    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="css/plugins.css">

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="css/main.css">

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->
    <%-- <link id="theme-link" rel="stylesheet" href="css/themes/fire.css">--%>
    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
      <link href="css/themes/fancy.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/themes.css">
    <!-- END Stylesheets -->

    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
</head>
<body>
    <!-- Page Container -->
    <div id="page-container" class="sidebar-partial sidebar-visible-lg sidebar-no-animations">
        <HM:SideBar ID="SideBar" runat="server" />

        <!-- Main Container -->
        <div id="main-container">
            <!-- Header -->
            <HR:TopBar ID="TopBar" runat="server" />
            <!-- END Header -->

            <!-- Page content -->
            <div id="page-content">
              <%--  <ul class="breadcrumb breadcrumb-top">
                    <li>Pages</li>
                    <li><a href="">Messages</a></li>
                </ul>--%>
                <!-- Forum Block -->
                   <!-- Inbox Content -->
                    <div class="row">
                        <!-- Inbox Menu -->
                        <div class="col-sm-4 col-lg-3">
                            <!-- Menu Block -->
                            <div class="block full">
                                <!-- Menu Title -->
                                <div class="block-title clearfix">
                                    <div class="block-options pull-right">
                                        <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Refresh"><i class="fa fa-refresh"></i></a>
                                    </div>
                                    <div class="block-options pull-left">
                                        <h2>Friends </h2>
                                    </div>
                                </div>
                                  <div id="div_Friends">
                                 </div>
                                <!-- END Menu Title -->

                                <!-- Menu Content -->
                                
                                <!-- END Menu Content -->
                            </div>
                            <!-- END Menu Block -->
						</div>
                        <!-- END Inbox Menu -->

                        <!-- Messages List -->
                        <div class="col-sm-8 col-lg-9">
                            <!-- Messages List Block -->
                            <div class="block">
                                <!-- Messages List Title -->
                                <div class="block-title">
                                    <h2>Messages</strong></h2>
                                </div>
                                <!-- END Messages List Title -->

                                <!-- Messages List Content -->
                                 <div class="table-responsive">
                              
                                	 <div class="media-body" id="div_message">
                                           
                                           
                                            <!-- Comments -->
                                           
                                            <!-- END Comments -->
                                        </div>
                                 
                                 </div>
                                <!-- END Messages List Content -->

                            </div>
                            <!-- END Messages List Block -->
                             <HP:UserProfile ID="UserProfile" runat="server" />
                        </div>
                        <!-- END Messages List -->
                    </div>
                    <!-- END Inbox Content -->
                </div>
            <!-- END Forum Block -->
            <footer class="clearfix">
                <!--<div class="pull-right">
                        Crafted with <i class="fa fa-heart text-danger"></i> by <a href="http://goo.gl/vNS3I" target="_blank">pixelcave</a>
                    </div>-->
                <div class="pull-left">
                    <span id="year-copy"></span>&copy; <a href="#">e2aForums</a>
                </div>
            </footer>
        </div>
        <!-- END Page Content -->

        <!-- Footer -->

        <!-- END Footer -->
    </div>
    <!-- END Main Container -->

    <!-- END Page Container -->

    <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
    <a href="#" id="to-top"><i class="fa fa-angle-double-up"></i></a>

    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>!window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
    <script src="js/vendor/bootstrap.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>    
    <script src="PagesJs/Message.js" type="text/javascript"></script>
    <script src="PagesJs/Common.js" type="text/javascript"></script>
      <script language="javascript"  type="text/javascript"> 
          $(function () {

              if ("<%=IsAdmin%>" == 'True') {
                  $('.adminLinks').show();
                  $('.UserLinks').hide();
              }
              if (VarUserTypeID != 2) {
                  $('.UserLinks').show();
              }
               maxLength = $("textarea#txtmsg").attr("maxlength");
               $("textarea#txtmsg").after("<div><span id='remainingLengthTempId'>"
                     + maxLength + "</span> remaining</div>");

               $("textarea#txtmsg").bind("keyup change", function () { checkMaxLength(this.id, maxLength); })


           });
      </script>
</body>
</html>
