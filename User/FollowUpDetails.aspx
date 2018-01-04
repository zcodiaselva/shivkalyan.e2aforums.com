<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FollowUpDetails.aspx.cs" Inherits="User_pro" %>

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
         
                <!-- Forum Block -->
                <div class="block">
                    <!-- Tab Content -->
                    <div class="tab-content">
                        <!-- Forum -->
                        <div class="row">
                    <div class="col-sm-12">
                        <!-- Timeline Style Block -->
                        <div class="block full">
                            <!-- Timeline Style Title -->
                            <div class="block-title">
                               
                                <h2 id="headerMainTitle" style="color: #F31455;"><strong></strong></h2>
                            </div>
                            <!-- END Timeline Style Title -->

                            <!-- Timeline Style Content -->
                            <!-- You can remove the class .block-content-full if you want the block to have its regular padding -->
                            <div id="div_followUpDetails">
                           
                                </div>
                        </div>
                               <div id="div_map" class="block" style="display: none;">
                            <div class="gmap" id="gmap-geolocation"></div>
                        </div>
                        <!-- END Timeline Style Block -->
                    </div>
                   
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


    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>

    <script src="js/plugins.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="js/app.js"></script>
    <script src="PagesJs/Common.js" type="text/javascript"></script>
     <script src="https://maps.google.com/maps/api/js?js?v=3.exp&sensor=false"></script>
            <script src="js/helpers/gmaps.min.js"></script>

            <!-- Load and execute javascript code used only in this page -->
            <script src="js/pages/compMaps.js"></script>
    <script src="PagesJs/FollowUpDetails.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var mvarCustomerID = -1;

        $(document).ready(function () {

            $('#Customers-a').addClass("active");
            mvarCustomerID = '<%=CustomerID%>';
            GetUserName();
            GetFollowUpDetails();

        });
        function GetUserName() {

            $.post("Ajax/AjaxCustomers.aspx",
            {
                Mode: "GETCUSTOMERNAME",
                CustomerID: mvarCustomerID

            },
          function (VarResponseData) {

              $('#headerMainTitle').html("" + VarResponseData + "'s" + "  " + "Follow-Up Details");

          });                  //End of Ajax

            return false;
        }

        function GetFollowUpDetails() {
            $.post("Ajax/AjaxCustomers.aspx",
           {
               Mode: "GETFOLLOWUPDETAILS",
               CustomerID: mvarCustomerID

           },
         function (VarResponseData) {

             $('#div_followUpDetails').empty();
             $('#div_followUpDetails').append(VarResponseData);

         });                  //End of Ajax

            return false;
        }

        function codeAddress(pvarAddress) {

            $('#div_followUpDetails').hide();
            $('#div_map').show();
            geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(0, 0);
            var mapOptions = { zoom: 8, center: latlng }
            map = new google.maps.Map('', mapOptions);

            //alert(pvarAddress);
            var address = pvarAddress;

            geocoder.geocode({ 'address': address }, function (results, status) {
                // alert(pvarAddress);
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);

                    var lat = results[0].geometry.location.lat();
                    var long = results[0].geometry.location.lng();

                    //alert(lat +" " + long);
                    PlotMaps(lat, long, address);


                } else {
                    NProgress.done();
                    toastr["error"]("Geocode was not successful for the following reason: " + status, "Error");
                    //alert('Geocode was not successful for the following reason: ' + status);
                }
            });
        }

        function PlotMaps(pvarLat, pvarLong, pvarAddress) {
            $('.gmap').css('height', '350px');

            var gmapGeolocation = new GMaps({
                div: '#gmap-geolocation',
                lat: pvarLat,
                lng: pvarLong,
                scrollwheel: true
            }).addMarkers([
                { lat: pvarLat, lng: pvarLong, title: '' + pvarAddress + '', animation: google.maps.Animation.DROP, infoWindow: { content: '<strong>' + pvarAddress + '</strong>' } }
            ]);

            // GMaps.setMyLocationEnabled(false);

            GMaps.geolocate({
                success: function (position) {

                    gmapGeolocation.setCenter(position.coords.latitude, position.coords.longitude);

                    //gmapGeolocation.setMyLocationEnabled(false);

                    gmapGeolocation.addMarker({
                        lat: position.coords.latitude,
                        lng: position.coords.longitude,
                        animation: google.maps.Animation.DROP,
                        title: 'GeoLocation',
                        infoWindow: {
                            content: '<div class="text-success"><i class="fa fa-map-marker"></i> <strong>' + pvarAddress + '</strong></div>'
                        }
                    });

                },
                error: function (error) {
                    NProgress.done();
                    //alert('Geolocation failed: ' + error.message);
                    toastr["error"]("Geolocation failed", "Error");
                },
                not_supported: function () {
                    NProgress.done();
                    toastr["error"]("Your browser does not support geolocation", "Error");
                },
                always: function () {
                    // Message when geolocation succeed
                    NProgress.done();
                }
            });

        }
    </script>
   
    
    
</body>
</html>
