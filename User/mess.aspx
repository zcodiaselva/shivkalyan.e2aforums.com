<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="index.aspx.cs" Inherits="User_pro" %>

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

    <!-- PAGE CONTENT WRAPPER -->
      <form id="Form1" runat="server">
    <div class="page-content-wrap"> 
      <div class="inner-content-wrap"> 
      <!-- START WIDGETS -->
      <div class="row">
        <div class="col-md-3"> 
          
          <!-- START WIDGET FORUMS -->
          <div class="widget widget-default widget-item-icon forums-counter" >
            <div class="widget-item-left"> <span class="fa fa-life-bouy"></span> </div>
            <div class="widget-data">
              <div class="widget-int num-count"><span id="s_thread"></span></div>
              <div class="widget-title">Forum Threads</div>
              
            </div>
            <div class="widget-controls"> </div>
          </div>
          <!-- END WIDGET FORUMS --> 
          
        </div>
        <div class="col-md-3"> 
          
          <!-- START WIDGET MESSAGES -->
          <div class="widget widget-default widget-item-icon messages-counter" >
            <div class="widget-item-left"> <span class="fa fa-envelope"></span> </div>
            <div class="widget-data">
              <div class="widget-int num-count"><span id="s_message"></span></div>
              <div class="widget-title">New messages</div>
              
            </div>
            <div class="widget-controls"> </div>
          </div>
          <!-- END WIDGET MESSAGES --> 
          
        </div>
        <div class="col-md-3"> 
          
          <!-- START WIDGET REGISTRED -->
          <div class="widget widget-default widget-item-icon events-counter" >
            <div class="widget-item-left"> <span class="fa fa-calendar"></span> </div>
            <div class="widget-data">
              <div class="widget-int num-count"><span id="s_event"></span></div>
              <div class="widget-title">Upcoming Events</div>
              
            </div>
            <div class="widget-controls"> </div>
          </div>
          <!-- END WIDGET REGISTRED --> 
          
        </div>
        <div class="col-md-3"> 
          
          <!-- START WIDGET CLOCK -->
          <div class="widget widget-danger widget-padding-sm">
            <div class="widget-big-int plugin-clock">00:00</div>
            <div class="widget-subtitle plugin-date">Loading...</div>
        
        
          </div>
          <!-- END WIDGET CLOCK --> 
          
        </div>
      </div>
      <!-- END WIDGETS -->
      
      <div class="row">
        <div class="col-md-8"> 
          
          <!-- START SALES BLOCK -->
          <div class="panel panel-default">
            <div class="panel-heading">
              <div class="panel-title-box">
                <h3>Sales</h3>
                <span>Sales activity by period you selected</span> </div>
              <ul class="panel-controls panel-controls-title">
                <li>
                  <div id="reportrange" class="dtrange"> <span></span><b class="caret"></b> </div>
                </li>
                <li><a href="#" class="panel-fullscreen rounded"><span class="fa fa-expand"></span></a></li>
              </ul>
            </div>
            <div class="panel-body">
              <div class="row stacked">
                <div class="col-md-4">
                  <div class="progress-list">
                    <div class="pull-left"><strong>Open</strong></div>
                    <div class="pull-right"> <spam id="TotalCustOpen" ></spam>/<spam class="totalCust"></spam></div>
                    <div class="progress progress-small progress-striped active">
                      <div class="progress-bar progress-bar-primary" id="TotalCustOpenDiv"  role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" >75%</div>
                    </div>
                  </div>
                  <div class="progress-list">
                    <div class="pull-left"><strong>Pre-qualified</strong></div>
                    <div class="pull-right"><spam id="TotalCustPre" ></spam>/<spam class="totalCust"></spam></div>
                    <div class="progress progress-small progress-striped active">
                      <div class="progress-bar progress-bar-primary" id="TotalCustPreDiv" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" >90%</div>
                    </div>
                  </div>
                  <div class="progress-list">
                    <div class="pull-left"><strong class="text-danger">Qualified</strong></div>
                    <div class="pull-right"><spam id="TotalCustQualified" ></spam>/<spam class="totalCust"></spam></div>
                    <div class="progress progress-small progress-striped active">
                      <div class="progress-bar progress-bar-danger" id="TotalCustQualifiedDiv" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" >5%</div>
                    </div>
                  </div>
                  <div class="progress-list">
                    <div class="pull-left"><strong class="text-warning">Disqualified</strong></div>
                    <div class="pull-right"><spam id="TotalCustDisqualified" ></spam>/<spam class="totalCust"></spam></div>
                    <div class="progress progress-small progress-striped active">
                      <div class="progress-bar progress-bar-warning" id="TotalCustDisqualifiedDiv" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" >50%</div>
                    </div>
                  </div>
                    <div class="progress-list">
                    <div class="pull-left"><strong class="text-warning">Closed</strong></div>
                    <div class="pull-right"><spam id="TotalCustClosed" ></spam>/<spam class="totalCust"></spam></div>
                    <div class="progress progress-small progress-striped active">
                      <div class="progress-bar progress-bar-warning" id="TotalCustClosedDiv"  role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100" >10%</div>
                    </div>
                  </div>
  
                </div>
                <div class="col-md-8">
                  <div id="map" class="map-by-location"> </div>
                </div>
              </div>
            </div>
          </div>
          <!-- END SALES BLOCK --> 
          
        </div>
        <div class="col-md-4">
<div class="weather-wrapper">
<div id="weather">
</div>
<div class="weather-loader">
<IMG SRC="../E2Forums-New/img/Preloader.gif">
<h5>Loading your Weather...</h5>
<div class="random-facts">
  <h1>Did you Know?</h1>
  <p id="quote"></p>
</div>
</div> 
</div>
</div>
      </div>

        
        <!-- START PROJECTS BLOCK -->
        <div class="panel panel-default display-none">
          <div class="panel-heading">
            <div class="panel-title-box">
              <h3>Projects</h3>
              <span>Projects activity</span> 

              
            </div>
            <ul class="panel-controls" style="margin-top: 2px;">
              <li><a href="#" class="panel-fullscreen"><span class="fa fa-expand"></span></a></li>
              <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>

            </ul>
          </div>
          <div class="panel-body panel-body-table">
            <div class="table-responsive">
               
               
            </div>
          </div>
        </div>
        <!-- END PROJECTS BLOCK --> 
        

   


    <div class="row">
      <div class="col-md-6"> 
         
        <!-- START PROJECTS BLOCK -->
        <div class="panel panel-default">
          <div class="panel-heading">
            <div class="panel-title-box">
              <h3>Your Posts</h3>
              <span>Projects activity</span> </div>
            <ul class="panel-controls" style="margin-top: 2px;">
              <li><a href="#" class="panel-fullscreen"><span class="fa fa-expand"></span></a></li>
              <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>

            </ul>
          </div>
          <div class="panel-body panel-body-table">
            <div class="table-responsive">
              
                
                      <asp:Panel ID="Panel1" ScrollBars="Horizontal" Height="300px" Width="100%" runat="server">
           <asp:GridView ID="grdDemo" runat="server" Width="100%" EmptyDataText="No data present !" EmptyDataRowStyle-HorizontalAlign="Center">
    </asp:GridView></asp:Panel>
                   
            </div>
          </div>
        </div>
        <!-- END PROJECTS BLOCK --> 
        
      </div>
      <div class="col-md-6"> 
        
        <!-- START PROJECTS BLOCK -->
        <div class="panel panel-default">
          <div class="panel-heading">
            <div class="panel-title-box">
              <h3>News Feed (RSS)</h3>
                <span id="rssfeedtitle_show"  href="javascript:void(0)">Click to see more Categories <i class="fa fa-arrow-circle-o-right"></i></span>
 
              </div>

            <ul class="panel-controls" style="margin-top: 2px;">
              <li><a href="#" class="panel-fullscreen"><span class="fa fa-expand"></span></a></li>
              <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>

            </ul>
            </div>
            <div class="panel-body panel-body-table">
                <div id="div_RssFeedTitle-wrapper">
                  
<div id="div_RssFeedTitle">

</div> 
</div> 
<div  id="feedContainer">
</div>
          </div>
          </div>
          
        </div>
        <!-- END PROJECTS BLOCK -->
        
        <div class="col-md-4"> 
          
          <!-- START SALES & EVENTS BLOCK -->
          <div class="panel panel-default display-none">
            <div class="panel-heading">
              <div class="panel-title-box">
                <h3>Sales & Event</h3>
                <span>Event "Purchase Button"</span> </div>
              <ul class="panel-controls" style="margin-top: 2px;">
                <li><a href="#" class="panel-fullscreen"><span class="fa fa-expand"></span></a></li>
                <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>

              </ul>
            </div>
            <div class="panel-body padding-0">
              <div class="chart-holder" id="dashboard-line-1" style="height: 200px;"></div>
            </div>
          </div>
          <!-- END SALES & EVENTS BLOCK --> 
          
        </div>
        <div class="col-md-4"> 
          
          <!-- START USERS ACTIVITY BLOCK -->
          <div class="panel panel-default display-none">
            <div class="panel-heading">
              <div class="panel-title-box">
                <h3>Users Activity</h3>
                <span>Users vs returning</span> </div>
              <ul class="panel-controls" style="margin-top: 2px;">
                <li><a href="#" class="panel-fullscreen"><span class="fa fa-expand"></span></a></li>
                <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>
  
              </ul>
            </div>
            <div class="panel-body padding-0">
              <div class="chart-holder" id="dashboard-bar-1" style="height: 200px;"></div>
            </div>
          </div>
          <!-- END USERS ACTIVITY BLOCK --> 
          
        </div>
        <div class="col-md-4"> 
          
          <!-- START VISITORS BLOCK -->
          <div class="panel panel-default display-none">
            <div class="panel-heading">
              <div class="panel-title-box">
                <h3>Visitors</h3>
                <span>Visitors (last month)</span> </div>
              <ul class="panel-controls" style="margin-top: 2px;">
                <li><a href="#" class="panel-fullscreen"><span class="fa fa-expand"></span></a></li>
                <li><a href="#" class="panel-refresh"><span class="fa fa-refresh"></span></a></li>
                <li class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="fa fa-cog"></span></a>
                  <ul class="dropdown-menu">
                    <li><a href="#" class="panel-collapse"><span class="fa fa-angle-down"></span> Collapse</a></li>
                    <li><a href="#" class="panel-remove"><span class="fa fa-times"></span> Remove</a></li>
                  </ul>
                </li>
              </ul>
            </div>
            <div class="panel-body padding-0">
              <div class="chart-holder" id="dashboard-donut-1" style="height: 200px;"></div>
            </div>
          </div>
          <!-- END VISITORS BLOCK --> 
          
        </div>
      </div>
    </div>
    
    <!-- START DASHBOARD CHART -->
    <div class="block-full-width display-none">
      <div id="dashboard-chart" style="height: 250px; width: 100%; float: left; display:none;"></div>
      <div class="chart-legend">
        <div id="dashboard-legend"></div>
      </div>
    </div>
    <!-- END DASHBOARD CHART --> 
   </div>



          </form>  
  </div>



    <!-- Footer BOX-->
    <HM:footerControl runat="server" ID="footerControl" />

<!-- END Footer Box --> 
    <!---Comman Footer Scripts Start -->
    <HM:footerScriptControl runat="server" ID="footerScriptControl" />

    <!-- Comman Footer Scripts End--->


    <!-- Delete--->
  </div>







<!-- ====================This Page Script ===============================-->

    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
   

    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>
    <script src="js/toastr.js"></script>
    <script src="js/FileReader.js"></script>
    <script src="PagesJs/Common.js" type="text/javascript"></script>   
    <script src="js/ajaxfileupload.js"></script>
     <script src="PagesJs/Forum.js" type="text/javascript"></script>
    


<script src="../E2Forums-New/js/plugins/weather/jquery.simpleWeather.min.js"></script> 
<script type="text/javascript">
    $(function () {

        setTimeout(function () {
            /* Does your browser support geolocation? */
            if ("geolocation" in navigator) {
                $('.js-geolocation').show();
            } else {
                $('.js-geolocation').hide();
            }
            /* Where in the world are you? */

            navigator.geolocation.getCurrentPosition(function (position) {
                loadWeather(position.coords.latitude + ',' + position.coords.longitude); //load weather using your lat/lng coordinates
            });

            //$(document).ready(function() {
            // loadWeather('Delhi',''); //@params location, woeid
            //});

            function loadWeather(location, woeid) {
                $.simpleWeather({
                    location: location,
                    woeid: woeid,
                    unit: 'c',
                    success: function (weather) {
                        $('.weather-loader').hide();
                        html = '<h2><i class="icon-' + weather.code + '"></i>' + weather.temp + '&deg;' + weather.units.temp + '</h2>';
                        html += '<ul class="weather-condition"><li><span class="fa fa-map-marker"></span> ' + weather.city + ', ' + weather.region + '</li>';
                        html += '<li class="currently"><i class="icon-' + weather.code + '"></i>' + weather.currently + '</li>';
                        html += '<li><span class="fa fa-tachometer"></span>' + weather.alt.temp + '&deg;F</li></ul>';

                        $("#weather").html(html);
                    },
                    error: function (error) {
                        $("#weather").html('<p>' + error + '</p>');
                    }
                });

            }
        }, 3000);
    });
</script>

<!-- Random Facts JS --> 
<script src="../E2Forums-New/js/plugins/random-fact/random-fact.js"></script> 
<!-- Random Facts JS End --> 
    <!-- Google Map --> 
<script>
    // Note: This example requires that you consent to location sharing when
    // prompted by your browser. If you see the error "The Geolocation service
    // failed.", it means you probably did not give permission for the browser to
    // locate you.
    function initMap() {
        var map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: -34.397, lng: 150.644 },
            zoom: 2
        });
        var infoWindow = new google.maps.InfoWindow({ map: map });

        // Try HTML5 geolocation.
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };

                infoWindow.setPosition(pos);
                infoWindow.setContent('You Are Currently Here!');
                map.setCenter(pos);
            }, function () {
                handleLocationError(true, infoWindow, map.getCenter());
            });
        } else {
            // Browser doesn't support Geolocation
            handleLocationError(false, infoWindow, map.getCenter());
        }
    }

    function handleLocationError(browserHasGeolocation, infoWindow, pos) {
        infoWindow.setPosition(pos);
        infoWindow.setContent(browserHasGeolocation ?
                              'Error: The Geolocation service failed.' :
                              'Error: Your browser doesn\'t support geolocation.');
    }

</script> 
<script src="https://maps.googleapis.com/maps/api/js?signed_in=true&callback=initMap" async defer> </script> 

<!-- Google Map End -->
<script>
    $('#div_RssFeedTitle').on('click', 'ul.nav li', function () {
        $("#div_RssFeedTitle").fadeOut(1000);
        return false; // prevent default click action from happening!
        e.preventDefault(); // same thing as above
    });
    $("#rssfeedtitle_show").click(function () {
        $("#div_RssFeedTitle").fadeIn(1000);
        return false; // prevent default click action from happening!
        e.preventDefault(); // same thing as above
    });
</script>

<!-- ===========================This Page Script End================================-->



<script src="dev/Index.js"></script>
  

<!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    
   
   
  
<script src="PagesJs/RssFeed.js" type="text/javascript"></script>
  
<link href="css/FeedEk.css" rel="stylesheet" />
<script src="js/FeedEk.js" type="text/javascript"></script>
<script src="js/jquery.tooltipster.js"></script>

    
<script language="javascript" type="text/javascript">


    $(function () {

        NProgress.start();

        console.log("1");

        $.post("UserProfile.aspx",
        {
            Mode: "GETUSERDET"

        },
        function (VarResponseData) {
            $(VarResponseData).find('Response').each(function () {
                $(VarResponseData).find('AdminData').each(function () {
                    console.log("hello");
                    console.log($(this).find('Full_Name').text());
                    if ($(this).find('Full_Name').text() != "") {
                        $('#UserNameHead').html($(this).find('Full_Name').text());
                        $('#UserNameHead').attr('readonly', 'readonly');
                    }

                    if ($(this).find('Picture').text() != "")
                        $("#UserImagEditPage").attr("src", $(this).find('Picture').text());
                    else
                        $("#UserImagEditPage").attr("src", "../img/AnonymousGuyPic.jpg");

                    if ($(this).find('EMail').text() != "")
                        $("#UserEmail_desk").html($(this).find('EMail').text());
                    else
                        $("#UserEmail_desk").html('-');
                });

            }); //end of Response 
            NProgress.done();


            return false;
        });

    });                  //End of Ajax

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


function showimagepreview(input) {

    if (input.files && input.files[0]) {

        var filerdr = new FileReader();

        filerdr.onload = function (e) {

            $('#imgprvw').attr('src', e.target.result);
            $("#imgprvw").fadeIn();
            $("#imgprev-a").fadeIn();

        }

        filerdr.readAsDataURL(input.files[0]);

    }

}

</script>




</body>
</html>
