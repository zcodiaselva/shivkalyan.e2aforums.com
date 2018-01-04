<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalendarEventsss.aspx.cs" Inherits="User_CalendarEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Calendar</title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">
    <link href="css/toastr.css" rel="stylesheet" type="text/css" />
   
    <link href="../css/Bootstrap2.css" rel="stylesheet" />

    <link rel="stylesheet" href="css/plugins.css">
 
    <link rel="stylesheet" href="css/main.css">
  
    <link href="css/themes/fancy.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/themes.css">
  
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <script src="../js/jquery-1.8.2.js"></script>

    <link href="css/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../css/jquery.fileupload-noscript.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload-ui-noscript.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload-ui.css" rel="stylesheet" />
    <link href="../css/jquery.fileupload.css" rel="stylesheet" />


    <style type="text/css">
        .sidebar-partial #sidebar:hover + #main-container, .sidebar-visible-lg #main-container {
  margin-left: 0 !important;
}
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
    <!-- Page Container -->
    <div id="page-container" class="sidebar-partial sidebar-visible-lg sidebar-no-animations">
      
        <!-- Header -->

        <!-- END Header -->
        <!-- Main Container -->
        <div id="main-container">
     

            <!-- Page content -->
            <div id="page-content">
               
    
                  <HM:SideBar ID="SideBar" runat="server" />
                <!-- Calendar Events -->
                <center>
                     
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
            </center>
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

        <!-- END Page Content -->
        <!-- Footer -->

    </div>



    <!-- END Main Container -->

    <!-- END Page Container -->

    <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
    <a href="#" id="to-top"><i class="fa fa-angle-double-up"></i></a>

    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>--%>
    <script>!window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
    <%--<script src="../js/SJGrid.js"></script>--%>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
    <script src="js/vendor/bootstrap.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>

    <script src="js/ui.draggable.js" type="text/javascript"></script>
    <script src="js/ui.resizable.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="js/fullcalendar.js" type="text/javascript"></script>
    <link href="../css/redmond/jquery-ui.css" rel="stylesheet" />
    <link href="css/jquery-ui-1.8.20.custom.css" rel="stylesheet" />
    <link href="css/fullcalendar.css" rel="stylesheet" />
   <%--  <script src="js/jquery.tooltipster.js"></script>--%>
    <%-- <script type="text/javascript" src="js/pages/formsValidation.js"></script>--%>
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
