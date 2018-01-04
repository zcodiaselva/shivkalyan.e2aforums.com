<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalendarEventss.aspx.cs" Inherits="User_CalendarEvents" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>Calendar</title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">
    <link href="css/toastr.css" rel="stylesheet" type="text/css" />
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

    <%--<link href="../css/datepicker.css" rel="stylesheet" />--%>
    <%--<script src="js/datepicker.js"></script>--%>
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
       <%-- <link href="css/tooltipster.css" rel="stylesheet" />--%>
    <!-- END Stylesheets -->
    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <script src="../js/jquery-1.8.2.js"></script>
    <%--    <script src="../js/jquery-ui-1.9.2.custom.min.js"></script>--%>
    <link href="css/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../css/jquery.fileupload-noscript.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload-ui-noscript.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload-ui.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload.css" rel="stylesheet" />
<link rel="icon" href="favicon.ico" type="image/x-icon" />
<!-- END META SECTION -->
<!-- CSS INCLUDE -->
<link rel="stylesheet" type="text/css" href="../E2Forums-New/css/cropper/cropper.min.css"/>
<!--  EOF CSS INCLUDE -->
<!-- CSS INCLUDE -->
<link rel="stylesheet" type="text/css" id="theme" href="../E2Forums-New/css/theme-default.css"/>
<link rel="stylesheet" type="text/css" id="Link1" href="../E2Forums-New/css/custom.css"/>
<!-- EOF CSS INCLUDE -->
<link rel="stylesheet" href="css/plugins.css">
     <style type="text/css">
        .image-upload > input {
            display: none;
        }

        .redEvent {
            background-color:#a73232;
            border-color:#a73232;
            color:#ffffff;
        }
        .blueEvent {
            background-color:#36c;
            border-color:#36c;
             color:#ffffff;
        }
         .OrangeEvent {
            background-color:#009900;
            border-color:#009900;
             color:#ffffff;
        }
         .PinkEvent {
            background-color:#FF3399;
            border-color:#FF3399;
             color:#ffffff;
        }
    </style>
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
   <%-- <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />--%>
    <!-- side Menu Control End  -->
     <div class="page-content-wrap"> 
      <div class="inner-content-wrap"> 


        <HM:SideBar ID="SideBar" runat="server" />
        


      
                     
                <h2 id="h_Events">
                   Events</h2>
                  
                        <div style="position:relative;float:right;bottom:5px;width:220px;">
                              <div style="float:left;width:60px;margin:4px;">
                          <label class="fc-header-title" for="text-input" style="text-align:center;margin-left:10px;font-size: small;">
                           City:
                            </label></div>
                          <div style="width:150px;float:right;text-align:left;">
                             
                        <select id="dd_City" name="dd_City" class="select-chosen" onchange="return GetEventsOfCity();" style="width:150px;height: 30px;">
                       </select>
                       </div>
                 </div>
 
                <h2 class="ico_Calendar"></h2>
                <div id="loading" style="width: 1000px; margin: 0px auto; text-align: center; margin-top: 13%; z-index: 9999; position: absolute; display: none;">
                    <img src="../img/progressing.gif" />
                </div>
                <div id='calendar'>
                </div>
            </div>




            <div id="divDialog11" style="display: none;" title="">
                <HM:CalendarEvent ID="CalendarEvents" runat="server" />
            </div>

         </div>
    </div>
    </div>


    <a href="#" id="to-top"><i class="fa fa-angle-double-up"></i></a>

    
    <script>!window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
  
    <script src="js/toastr.js"></script>
 
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>

    <script src="js/ui.draggable.js" type="text/javascript"></script>
    <script src="js/ui.resizable.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="js/fullcalendar.js" type="text/javascript"></script>
    <link href="../css/redmond/jquery-ui.css" rel="stylesheet" />
    <link href="css/jquery-ui-1.8.20.custom.css" rel="stylesheet" />
    <link href="css/fullcalendar.css" rel="stylesheet" />
  
    <script type='text/javascript'>
        $(function () {
            FillCityCombo();
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

        function FillCityCombo() {
            // NProgress.start();
            $.post("Ajax/AjaxUser.aspx",
                    { Mode: "FILLCITYCOMBO" },
                       function (varResponseData) {

                           if (varResponseData.Text != "") {
                               $(varResponseData).find('Response').each(function () {

                                   $('#dd_City').empty();
                                   var opt = document.getElementById("dd_City").options;
                                   opt[opt.length] = new Option('All', -1);

                                   $(varResponseData).find('Contents').each(function () {

                                       if ($(this).find('CityID').text() != "" && $(this).find('Title').text() != "") {
                                           // console.log(varCategoryID);
                                           opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('CityID').text());
                                       }
                                   }); // end of Contents

                                   $('#dd_City').trigger('chosen:updated');


                               }); //end of Response
                           } //END OF if (VarResponseData
                       });        //END OF function (VarResponse...


            return false;
        }
     
    </script>

</body>
</html>
