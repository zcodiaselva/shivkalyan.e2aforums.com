<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forum2old.aspx.cs" Inherits="User_Forum" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Forums</title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">
    <link href="../css/toastr.css" rel="stylesheet" type="text/css" />
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
        
    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="css/plugins.css">
    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="css/main.css">
    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->
    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
     <link href="css/themes/fancy.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/themes.css">
    <!-- END Stylesheets -->
    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <script src="../js/jquery-1.8.2.js"></script>
  
 
    <link href="../css/jquery.fileupload-noscript.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload-ui-noscript.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload-ui.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload.css" rel="stylesheet" />
    <%--<link href="../css/style1.css" rel="stylesheet" />--%>
    <%--<link href="../css/demo1-ie8.css" rel="stylesheet" />--%>
    <%-- <link href="../css/demo1.css" rel="stylesheet" />--%>
  
  
    <style type="text/css">
        .image-upload > input {
            display: none;
        }
    </style>
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
                <!-- Forum Header -->
                <%-- <ul class="breadcrumb breadcrumb-top">
                    <li>Pages</li>
                    <li><a href="">Forum</a></li>
                </ul>--%>
                <!-- END Forum Header -->
                <!-- Forum Block -->
                <div class="block">
                    <!-- Forum Tabs Title -->

                    <div class="block-title">
                        <ul class="nav nav-tabs" data-toggle="tabs" id="tabs">
                            <li><a id="Category-a" class="enable-tabs" href="#forum-categories" onclick="return GetForumCategory();">Categories</a></li>
                            <li><a id="Topics-a" class="enable-tabs" href="#forum-topics" onclick="javascript:varCategoryID=-1;FillCategoryComboFilter();">Topics</a></li>
                        </ul>
                          <a data-toggle="modal" style="display:none;" id="a_modalAddTopic" href="#modal-Add-Topic">
                            </a>
                        
                            <button type="button" id="btnAddTopic" class="btn btn-sm btn-primary" style="float: right; margin-right: 35px;position: relative; top: -35px;"
                                onclick="return ResetForm();">
                                ADD TOPIC</button>
                    </div>


                    <!-- END Forum Tabs -->
                    <!-- Tab Content -->
                    <div class="tab-content">
                        <!-- Forum -->
                        <div class="tab-pane active" id="forum-categories">
                            <div class="table-responsive">
                              <%--  <div id="TblForumCategoryDetails_wrapper" class="dataTables_wrapper" role="grid">--%>
                                    <div class="row">
                                    </div>
                                    <table id="TblForumCategory" class="table table-borderless table-striped table-vcenter">
                                    </table>
                                <%--</div>--%>
                            </div>
                        </div>

                        <!-- END Forum -->
                        <!-- Topics -->
                        <div class="tab-pane" id="forum-topics">
                            <div class="table-responsive" id="div_topics">
                                <div class="row">
                                    <div style="position: relative;" id="div_Category">
                                        <label class="col-md-4 control-label" for="text-input" style="width: 100px; font-size: small; margin-top: 9px; margin-left: 5px;">
                                            Categories:
                                        </label>
                                        <div style="width: 200px; margin-left: 105px;">
                                            <select id="cmb_Categories" name="cmb_Categories" class="select-chosen" onchange="return GetForumTopics(true);">
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <table id="TblForumTopics" class="table table-borderless table-striped table-vcenter">
                                </table>
                            </div>
                            <div class="table-responsive" id="content">
                                <table id="TblForumDiscussions" class="table table-borderless table-striped table-vcenter">
                                </table>
                            </div>
                        </div>
                        <!-- END Topics -->
                        <div id="modal-Add-Topic" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
                            <form id="form_Topic" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered" onsubmit="return false;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h3 id="headerTitle1" class="modal-title">Add Topic
                                            </h3>
                                        </div>
                                        <fieldset>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Title:
                                                </label>
                                                <div class="col-md-3">
                                                    <div class="input-group">
                                                        <input id="txtTitle" name="txtTitle" class="form-control" placeholder="Enter Title..."
                                                            style="width: 200px;" type="text" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label" for="text-input">
                                                    Description:</label>
                                                <div class="col-md-8">
                                                    <textarea id="txtDesc" cols="20" rows="4" name="txtDesc" class="form-control" placeholder="Description"></textarea>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Category:
                                                </label>
                                                <div class="col-md-3" style="width: 240px;">
                                                    <select id="cmb_Categories1" name="cmb_Categories1" class="select-chosen" style="width: 300px;">
                                                    </select>
                                                </div>
                                            </div>

                                        </fieldset>

                                        <div class="modal-footer">
                                            <button type="button" id="BtnSaveTopic" class="btn btn-sm btn-primary">
                                                Save</button>
                                            <button type="button" id="BtnEditTopic" class="btn btn-sm btn-primary"
                                                style="display: none;">
                                                Update</button>
                                            <button type="button" class="btn btn-sm btn-default" data-dismiss="modal" style="display: none;">
                                                Cancel</button>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>

                    <HP:UserProfile ID="UserProfile" runat="server" />
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
    <div id="modal-user-settings" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header text-center">
                    <h2 class="modal-title">
                        <i class="fa fa-pencil"></i>Settings</h2>
                </div>
                <!-- END Modal Header -->
                <!-- Modal Body -->
                <div class="modal-body">
                    <form action="index.html" method="post" enctype="multipart/form-data" class="form-horizontal form-bordered"
                        onsubmit="return false;">
                        <fieldset>
                            <legend>Vital Info</legend>
                            <div class="form-group">
                                <label class="col-md-4 control-label">
                                    Username</label>
                                <div class="col-md-8">
                                    <p class="form-control-static">
                                        Admin
                                    </p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="user-settings-email">
                                    Email</label>
                                <div class="col-md-8">
                                    <input type="email" id="user-settings-email" name="user-settings-email" class="form-control"
                                        value="admin@example.com">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="user-settings-notifications">
                                    Email Notifications</label>
                                <div class="col-md-8">
                                    <label class="switch switch-primary">
                                        <input type="checkbox" id="user-settings-notifications" name="user-settings-notifications"
                                            value="1" checked>
                                        <span></span>
                                    </label>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend>Password Update</legend>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="user-settings-password">
                                    New Password</label>
                                <div class="col-md-8">
                                    <input type="password" id="user-settings-password" name="user-settings-password"
                                        class="form-control" placeholder="Please choose a complex one..">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="user-settings-repassword">
                                    Confirm New Password</label>
                                <div class="col-md-8">
                                    <input type="password" id="user-settings-repassword" name="user-settings-repassword"
                                        class="form-control" placeholder="..and confirm it!">
                                </div>
                            </div>
                        </fieldset>
                        <div class="form-group form-actions">
                            <div class="col-xs-12 text-right">
                                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                                    Close</button>
                                <button type="submit" class="btn btn-sm btn-primary">
                                    Save Changes</button>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- END Modal Body -->
            </div>
        </div>
    </div>
    <!-- END User Settings -->


    <div id="modal-Send-Msg" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
        <form id="form_sendmsg" action="" method="post" enctype="multipart/form-data" class="form-horizontal form-bordered"
            onsubmit="return false;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" id="btn_CloseMsg" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                        <h3 id="headerTitle" class="modal-title">Message
                        </h3>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label" for="text-input">
                            To:</label>
                        <div class="col-md-8">
                            <input id="txtReceiver" name="txtReceiver" class="form-control" type="text" disabled="disabled" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 control-label" for="text-input">
                            Message:</label>
                        <div class="col-md-8">
                            <textarea id="txtmsg" maxlength="500" cols="20" rows="4" name="txtmsg" class="form-control" placeholder="Your message"></textarea>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="BtnSendMsg" class="btn btn-sm btn-primary">
                            Send</button>

                    </div>
                </div>
            </div>
        </form>
    </div>


    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <script>        !window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/vendor/bootstrap.min.js"></script>

    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>
    <script src="js/toastr.js"></script>
  
    <script src="js/FileReader.js"></script>
   
    <script src="PagesJs/Common.js" type="text/javascript"></script>   
    <script src="js/ajaxfileupload.js"></script>
 
    <script language="javascript" type="text/javascript">

        // Global variables
        var mvarTopicID = -1;
        var mvarTopic = "";
        var mvarID = -1;
        var mvarCategoryID = -1;
        var mvarMode = "";
        var mvarUserTypeID = -1;
        var mvarOccupationID = -1;

        //ready funtion.
        $(function () {

         
         if ("<%=lbnIsPostID%>" == 'True') {            
                window.close();  
                return false;
            }
            mvarOccupationID = '<%=OccupationID %>';
            mvarTopicID = '<%=TopicID %>';
            mvarTopic = '<%=Topic %>';
            mvarID = '<%=ID %>';
            mvarCategoryID = '<%=CategoryID %>';
            mvarMode = '<%=Mode %>';
            mvarUserTypeID = '<%=UserTypeID %>';
           
            if ("<%=IsAdmin%>" == 'True') {
                $('.adminLinks').show();
                $('.UserLinks').hide();
            }
            if (mvarOccupationID == 7) {
                $('#btnAddTopic').hide();
            }
            //if (VarUserTypeID == 3 ) {
            //    $('#btnAddTopic').hide();
            // }
           //if (VarUserTypeID != 2 ) {
           //     $('.UserLinks').show();
           // }

           //if (mvarUserTypeID == 2 || mvarUserTypeID == 1)
           //    $('#btnAddTopic').show();
           //else
           //    $('#btnAddTopic').hide();
            //}
            //if (mvarUserTypeID == 3 || mvarUserTypeID == 4) {
            //    $("#btnAddTopic").hide();
            //}
            maxLength = $("textarea#txtmsg").attr("maxlength");
            $("textarea#txtmsg").after("<div><span id='remainingLengthTempId'>"
                  + maxLength + "</span> remaining</div>");

            $("textarea#txtmsg").bind("keyup change", function () { checkMaxLength(this.id, maxLength); })
            if (mvarMode == "ShowTopic") {
                AddnewTabInForum(mvarTopicID, mvarTopic, mvarCategoryID, mvarID);
                return false;
            }

        });


        function showimagepreview(input) {

            if (input.files && input.files[0]) {

                var filerdr = new FileReader();

                filerdr.onload = function (e) {

                    $("#" + input.id + "Img").attr('src', e.target.result);
                    $("#" + input.id + "Img").fadeIn();
                    $("#" + input.id + "-a").fadeIn();

                }

                filerdr.readAsDataURL(input.files[0]);

            }

        }

        function RemoveImage(ctrl) {

            if (confirm('Are you sure, you want to remove this image..')) {
                var cntrol = $('#' + ctrl);
                $('#' + ctrl + "Img").attr('src', '');
                $('#' + ctrl + "Img").hide();
                $("#" + ctrl + "-a").hide();
                reset_form_element(cntrol);
                e.preventDefault();
            }
        }

        function reset_form_element(e) {
            e.wrap('<form>').parent('form').trigger('reset');
            e.unwrap();
        }

    </script>
     <script src="PagesJs/Forum.js" type="text/javascript"></script>
</body>
</html>
