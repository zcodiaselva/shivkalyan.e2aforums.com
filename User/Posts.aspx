<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Posts.aspx.cs" Inherits="User_Posts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Posts</title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">
    <link href="../css/toastr.css" rel="stylesheet" type="text/css" />
    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="img/favicon.ico">
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
    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="css/plugins.css">
    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="css/main.css">
    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->
    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="css/themes.css">
    <!-- END Stylesheets -->
    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <style type="text/css">
        .image-upload > input {
            display: none;
        }
    </style>
</head>
<body>
    <!-- Page Container -->
    <div id="page-container" >
       <%--<a href="#" ><img src="img/e2aLogo.PNG" />
            </a>--%>
        <!-- Main Container -->
        <div id="main-container">
             
            <!-- Header -->
            <%-- <header class="navbar navbar-default">
                   
                    <!-- Left Header Navigation -->
                    <ul class="nav navbar-nav-custom">
                        <!-- Main Sidebar Toggle Button -->
                        <li>
                            <a href="javascript:void(0)" onClick="App.sidebar('toggle-sidebar');">
                                <i class="fa fa-bars fa-fw"></i>
                            </a>
                        </li>

                    </ul>

                </header>--%>
            <!-- END Header -->
            <!-- Page content -->
            <div id="page-content">
                <!-- Forum Header -->
                <ul class="breadcrumb breadcrumb-top">
                    <li>Posts</li>
                    
                </ul>
                <!-- END Forum Header -->
                <!-- Forum Block -->
                <div class="block">
                   <!-- Tab Content -->
                    <div class="tab-content">
                          <ul class="breadcrumb breadcrumb-top">
                    <li>Pages</li>
                    <li><a href="">Posts</a></li>
                </ul>
                        <!-- Forum -->
                        <div class="tab-pane active" id="forum-categories">
                            <div class="table-responsive">
                                <div id="TblPosts_wrapper" class="dataTables_wrapper" role="grid">
                                    <div class="row">
                                    </div>
                                    <table id="TblPosts" class="table table-borderless table-striped table-vcenter">
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- END Forum -->
                   
                       
                    </div>
                </div>
                <!-- END Tab Content -->
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
    <!-- User Settings, modal which opens from Settings link (found in top right user menu) and the Cog link (found in sidebar user info) -->
  
    <!-- END User Settings -->

    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <%-- <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>--%>
    <script>        !window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/vendor/bootstrap.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>
    <script src="js/toastr.js"></script>    
    <script src="js/FileReader.js"></script>
    <script src="js/ajaxfileupload.js"></script>
    <script language="javascript" type="text/javascript">
        //var varPostID = -1;
        $(function () {
         var varPostID = "<%=PostID %>";
            GetPostsList(varPostID);
        });
        function GetPostsList(varPostID) {
            
            NProgress.start();
            $('#TblPosts').append("Loading....");
            $.post("Ajax/AjaxUser.aspx",
                    {
                        Mode: "GETPOSTSLIST",
                        PostID: varPostID
                    },
                    function (VarResponseData) {

                        $('#TblPosts').empty();
                        $('#TblPosts').append(VarResponseData);
                        NProgress.done();
                        // TablesDatatables.init();
                    });   //End of Ajax

            return false;
        }

    </script>
</body>
</html>
