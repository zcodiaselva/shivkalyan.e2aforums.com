﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="User_pro" %>

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


<!-- Top Menu Control Start  --> <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />
   
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
                                <h2>
                                    Category Listing</h2>
                                <a data-toggle="modal" href="#modal-Add-Category">
                                    <button type="button" id="btnAddCategory" class="btn btn-sm btn-primary" style="float: right;
                                        margin-right: 30px; margin-top: 5px;" onclick="return ResetForm();">
                                        ADD</button></a>
                            </div>
                            <!-- Datatables Content -->
                            <div class="table-responsive">
                           <%-- <div id="TblCategoryDetails_wrapper" class="dataTables_wrapper" role="grid">--%>

                         <div class="row">
                             </div>
                                 
                                <table id="TblCategory" class="table table-vcenter table-condensed table-bordered">
                                </table>
                           <%-- </div>--%>
                            </div>
                              <div id="modal-Add-Category" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
                                <form id="form_Categories" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered" onsubmit="return false;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" id="btn_addClose" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h3 id="headerTitle" class="modal-title">
                                                Add Category
                                            </h3>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                Title:</label>
                                            <div class="col-md-8">
                                                <input id="txtName" name="txtName" class="form-control" placeholder="Title" type="text" />
                                            </div>
                                        </div>
                                         <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                Description:</label>
                                            <div class="col-md-8">
                                              <textarea id="txtDesc" cols="20" rows="4" name="txtDesc" class="form-control" placeholder="Description"></textarea>    
                                                </div>
                                        </div>
                                      
                                        <div class="modal-footer">
                                          
                                            <button type="button" id="BtnSaveCategory" class="btn btn-sm btn-primary">
                                                Save</button>
                                            <button type="button" id="BtnEditCategory" class="btn btn-sm btn-primary"
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

                </div>
                <!-- END Tab Content -->
                 <HP:UserProfile ID="UserProfile" runat="server" />
            


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

    <div id="modal-user-settings" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header text-center">
                    <h2 class="modal-title"><i class="fa fa-pencil"></i>Settings</h2>
                </div>
                <!-- END Modal Header -->

                <!-- Modal Body -->
                <div class="modal-body">
                    <form action="index.html" method="post" enctype="multipart/form-data" class="form-horizontal form-bordered" onsubmit="return false;">
                        <fieldset>
                            <legend>Vital Info</legend>
                            <div class="form-group">
                                <label class="col-md-4 control-label">Username</label>
                                <div class="col-md-8">
                                    <p class="form-control-static">Admin</p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="user-settings-email">Email</label>
                                <div class="col-md-8">
                                    <input type="email" id="user-settings-email" name="user-settings-email" class="form-control" value="admin@example.com">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="user-settings-notifications">Email Notifications</label>
                                <div class="col-md-8">
                                    <label class="switch switch-primary">
                                        <input type="checkbox" id="user-settings-notifications" name="user-settings-notifications" value="1" checked>
                                        <span></span>
                                    </label>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend>Password Update</legend>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="user-settings-password">New Password</label>
                                <div class="col-md-8">
                                    <input type="password" id="user-settings-password" name="user-settings-password" class="form-control" placeholder="Please choose a complex one..">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="user-settings-repassword">Confirm New Password</label>
                                <div class="col-md-8">
                                    <input type="password" id="user-settings-repassword" name="user-settings-repassword" class="form-control" placeholder="..and confirm it!">
                                </div>
                            </div>
                        </fieldset>
                        <div class="form-group form-actions">
                            <div class="col-xs-12 text-right">
                                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">Close</button>
                                <button type="submit" class="btn btn-sm btn-primary">Save Changes</button>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- END Modal Body -->
            </div>
        </div>
    </div>
  <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
    
    <script src="js/plugins.js"></script>
    <script src="PagesJs/Category.js" type="text/javascript"></script>
      <script src="PagesJs/Common.js" type="text/javascript"></script>
    <script src="js/app.js"></script>
    <script language="javascript" type="text/javascript"></script>
      <script src="js/jquery.tooltipster.js"></script>
     <script language="javascript"  type="text/javascript">

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
