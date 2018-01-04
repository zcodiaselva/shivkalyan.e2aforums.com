<%@ Page Language="C#" AutoEventWireup="true"  MaintainScrollPositionOnPostback="false" CodeFile="Forum_new.aspx.cs" Inherits="User_pro"  %>

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
      
<!-- START PAGE CONTAINER -->
<div class="page-container page-navigation-top-fixed">


<!-- Top Menu Control Start  --> <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />
   
    <!-- Top Menu Control End  -->

<!-- PAGE CONTENT -->
<div class="page-content">
    <!-- Side Menu Control Start  -->
    <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />
    <!-- side Menu Control End  -->

      <!-- PAGE CONTENT WRAPPER -->
      
    <div class="page-content-wrap"> 
      <div class="inner-content-wrap"> 
      <!-- START WIDGETS -->
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
                            <li><a id="Topics-a" class="enable-tabs active" href="javascript:void(0);" data-toggle="forum-topics" onclick="javascript:varCategoryID=-1;FillCategoryComboFilter();">Topics</a></li>
                             <li><a id="Category-a" class="enable-tabs" href="javascript:void(0);" data-toggle="forum-categories" onclick="return GetForumCategory();">Categories</a></li>
                           
                        </ul>
                          <a data-toggle="modal" style="display:none;" id="a_modalAddTopic" href="#modal-Add-Topic">
                            </a>
                        <form runat="server"> 
                        <asp:Button id="btnAddTopic" runat="server" class="btn btn-sm btn-primary" style="float: right; margin-right: 35px;position: relative; top: -35px;" Text="Add Topic" OnClick="btnAddTopic_Click"></asp:Button>
                            </form>
                           <%-- <button type="button" id="btnAddTopic" class="btn btn-sm btn-primary" style="float: right; margin-right: 35px;position: relative; top: -35px;"
                                onclick="return ResetForm();">
                                ADD TOPIC</button>--%>
                    </div>


                    <!-- END Forum Tabs -->
                    <!-- Tab Content -->
                    <div class="tab-content">
                       
                        <!-- Topics -->
                        <div class="tab-pane active" id="forum-topics">
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
                         <!-- Forum -->
                        <div class="tab-pane " id="forum-categories">
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
                        






                      
                    </div>

                    <HP:UserProfile ID="UserProfile" runat="server" />
                </div>
                <!-- END Tab Content -->
            </div>  
      
      
      </div>
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
 


 <script type="text/javascript">

    function AddNewTopic() {
        var varTopicID = -1;

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Forum_new.aspx/InsertData",
                data: "{'Title':'" + $('#txtTitle').val() + "','CategoryID':'123','TopicID':'-1' ,'emp_id':'123'}",
                dataType: "json",
                success: function (VarResponseData) {
                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                        if (varTopicID == -1) {
                          
                            document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'> <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong> <i class='fa fa-check'></i> Success!</strong> Topic added successfully.</div>";
                            varTopicID = -1;
                            $('#form_Topic').fadeOut();
                            document.forms["form_Topic"].reset();


                        }
                        else {

                            document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'> <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong> <i class='fa fa-check'></i> Success!</strong> Topic updated successfully</div>";
                            $('#form_Topic').fadeOut();
                            varTopicID = -1;
                            document.forms["form_Topic"].reset();


                        }

                    }
                    else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                        
                        document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Topic Name already exists !</div>";
                    }
                   
                },
                error: function (result) {
                    alert('error');
                }
            });


       
    }
    


   </script>
   
 
    <%--<script>
        function AddNewTopic() {
 

            $.post("Ajax/AjaxUser.aspx",
                    {
                        Mode: "ADDNEWTOPIC",
                        Title: $('#txtTitle').val(),
                        CategoryID: varCategoryID,
                        TopicID: varTopicID,
                        IsFlagged: varIsFlagged
                    },

                        function (VarResponseData) {
                            if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                                if (varTopicID == -1) {
                                    toastr.options = { "onHidden": function () { $('.close').click(); GetForumTopics(false); } };
                                    // toastr["success"]("Topic added successfully");
                                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'> <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong> <i class='fa fa-check'></i> Success!</strong> Topic added successfully.</div>";
                                    varTopicID = -1;
                                    $('#form_Topic').fadeOut();
                                    document.forms["form_Topic"].reset();


                                }
                                else {
                                    toastr.options = { "onHidden": function () { $('.close').click(); GetForumTopics(false); } };
                                    //toastr["success"]("Topic updated successfully");
                                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'> <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong> <i class='fa fa-check'></i> Success!</strong> Topic updated successfully</div>";
                                    $('#form_Topic').fadeOut();
                                    varTopicID = -1;
                                    document.forms["form_Topic"].reset();


                                }

                            }
                            else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                                //toastr["error"]("Topic Name already exists");
                                document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Topic Name already exists !</div>";
                            }
                        });


            return false;

        }

    </script>--%>
    <script type="text/javascript">
// Javascript to enable link to tab
var url = document.location.toString();
if (url.match('#')) {
    $('.nav-tabs a[href=#'+url.split('#')[1]+']').tab('show') ;
} 

// Change hash for page-reload
$('.nav-tabs a').on('shown.bs.tab', function (e) {
    window.location.hash = e.target.hash;
})
    </script>

    <script src="../js/SJGrid.js"></script>


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
        var varPlanActiveL = -1;

        //ready funtion.
        $(function () {
            $('#Forum-a').addClass("active");

            NProgress.start();
          // GetForumCategory();
            FillCategoryCombo();

           

            varCategoryID = -1;
            FillCategoryComboFilter();

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
            varPlanActiveL= '<%=PlanActivel%>';
            if ("<%=IsAdmin%>" == 'True') {
                $('.adminLinks').show();
                $('.UserLinks').hide();
            }
            if (mvarOccupationID == 7) {
                $('#btnAddTopic').hide();
            }
            
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
    <script>
    //function activaTab(tab) {
    //$('.nav-tabs a[href="#' + tab + '"]').tab('show');
    //};
    //activaTab('forum-topics');
    </script>
     <script>
         function activeTab() {

             $("#forum-categories").hide();
             $("#forum-topics").css('display', 'block');
             $("#div_topics").css('display', 'block');
             $("#content").css('display', 'block');
             $(".enable-tabs").css('background', 'white');

         }

         $(".enable-tabs").onClick(function () {
             alert('clicked');
             $("#forum-categories").hide();
             $("#forum-topics").css('display', 'block');
             $("#div_topics").css('display', 'block');
             $("#content").css('display', 'block');
             $(".enable-tabs").css('background', 'white');
         });


    </script>
   
     <script src="PagesJs/Forum.js" type="text/javascript"></script>
     <script src="js/toastr.js"></script>
</body>
</html>
