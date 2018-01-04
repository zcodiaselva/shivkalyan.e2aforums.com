<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Experts.aspx.cs" Inherits="User_pro" %>

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
            
         
             <!-- Forum -->
                        <div class="block-title">
                            <h2>Experts Listing</h2>

                        </div>
                        <!-- Datatables Content -->
                        <div class="table-responsive">
                           <%-- <div id="TblExpertsDetails_wrapper" class="dataTables_wrapper" role="grid">--%>

                                <div class="row"></div>

                                <table id="TblExperts" class="table table-vcenter table-condensed table-bordered">
                                </table>
                            <%--</div>--%>
                        </div>
             
            



          </div>
         </div>

</div><!-- Page Container End -->
     <HP:UserProfile ID="UserProfile" runat="server" />
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
    <script src="PagesJs/Common.js" type="text/javascript"></script>
   
  
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
            <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
            <a href="#" id="A1"><i class="fa fa-angle-double-up"></i></a>
        
            <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
            <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
            <script>!window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
            <script src="../js/SJGrid.js"></script>
            <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
            
            <script src="js/toastr.js"></script>
            <script src="js/vendor/bootstrap.min.js"></script>
            <script src="js/plugins.js"></script>
           
            <script src="js/FeedEk.js" type="text/javascript"></script>
            <script src="PagesJs/Experts.js" type="text/javascript"></script>
            <script src="PagesJs/Common.js" type="text/javascript"></script>
            <script src="js/app.js"></script>
            <script src="js/jquery.tooltipster.js"></script>
        

            <script language="javascript" type="text/javascript">

                $(function () {

                    if ("<%=IsAdmin%>" == 'True') {
                        $('.adminLinks').show();
                        $('.UserLinks').hide();
                    }
                    //if (VarUserTypeID != 2) {
                    //    $('.UserLinks').show();
                    //}
                    maxLength = $("textarea#txtmsg").attr("maxlength");
                    $("textarea#txtmsg").after("<div><span id='remainingLengthTempId'>"
                          + maxLength + "</span> remaining</div>");

                    $("textarea#txtmsg").bind("keyup change", function () { checkMaxLength(this.id, maxLength); })
                });



            </script>
</body>
</html>
