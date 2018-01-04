<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RSSFeed.aspx.cs" Inherits="User_pro" %>

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
                <!-- Page content -->
                   <!-- Inbox Content -->
                <div><a data-toggle="modal" href="#modal-Add-RSS">
                                    <button type="button" id="btnAddRSS" class="btn btn-sm btn-primary" style="float: right;
                                        margin-right: 30px; margin-top:-12px;" onclick="return ResetForm();">
                                        ADD</button></a></div> 
                    <div class="row" >
                        <!-- Inbox Menu -->
                        <div class="col-sm-4 col-lg-3" style="margin-top:26px;">
                            <!-- Menu Block -->
                            <div class="block full" >
                                <!-- Menu Title -->
                                <div class="block-title clearfix" >
                                    <%--<div class="block-options pull-right">
                                        <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Refresh"><i class="fa fa-refresh"></i></a>
                                    </div>--%>
                                    <div class="block-options pull-left">
                                        <h2>RSS Feed </h2>
                                    </div>
                                </div>
                                  <div id="div_RssFeedTitle" class="mousescroll" style="max-height:400px;">
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
                            <div class="block" style="margin-top:10px;">
                                <!-- Messages List Title -->
                                <%--<div class="block-title">
                                    <h2>Messages</strong></h2>
                                </div>--%>
                                <!-- END Messages List Title -->

                                <!-- Messages List Content -->
                                 <div class="table-responsive">
                            
                                	 <div class="media-body" id="feedContainer">
                                           
                                        
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
                   <div id="modal-Add-RSS" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
                                <form id="form_RssFeed" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered" onsubmit="return false;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" id="btn_addRSSClose" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h3 id="headerTitle" class="modal-title">
                                                Add RSS
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
                                                URL:</label>
                                            <div class="col-md-3">
                                                    <div class="input-group">
                                                        <input id="txtUrl" name="txtUrl" class="form-control" placeholder="Enter URL..."
                                                            style="width: 200px;" type="text" />
                                                    </div>
                                                </div>
                                        </div>
                                            <div class="form-group">
                                                        <label class="col-md-3 control-label" for="text-input"">
                                                            Make Public:</label>
                                                        <div class="col-md-8">
                                                            <label class="switch switch-primary">
                                                                <input type="checkbox" id="UrlPublic" name="UrlPublic" checked=""/>
                                                              <span></span>
                                                            </label>

                                                        </div>
                                                    </div>
                                        </fieldset>
                                       
                                        <div class="modal-footer">
                                            <button type="button" id="BtnSaveRSS" class="btn btn-sm btn-primary">
                                                Save</button>
                                            <button type="button" id="BtnEditRSS" class="btn btn-sm btn-primary"
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
    <script src="PagesJs/RssFeed.js" type="text/javascript"></script>
    <script src="PagesJs/Common.js" type="text/javascript"></script>
     <link href="css/FeedEk.css" rel="stylesheet" />
     <script src="js/FeedEk.js" type="text/javascript"></script>
  
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
