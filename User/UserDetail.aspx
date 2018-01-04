<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="User_UserDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>User Details</title>
    <script src="js/jquery-1.7.2.js"></script>
    <script src="js/script.js"></script>
    <script src="js/jquery.validationEngine.js"></script>
    <script src="js/toastr.js"></script>

    <meta name="description" content="log in" />
    <meta name="author" content="PetCloud" />
    <meta name="robots" content="noindex, nofollow" />
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0" />
    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="img/favicon.ico" />
    <link rel="apple-touch-icon" href="img/icon57.png" sizes="57x57" />
    <link rel="apple-touch-icon" href="img/icon72.png" sizes="72x72" />
    <link rel="apple-touch-icon" href="img/icon76.png" sizes="76x76" />
    <link rel="apple-touch-icon" href="img/icon114.png" sizes="114x114" />
    <link rel="apple-touch-icon" href="img/icon120.png" sizes="120x120" />
    <link rel="apple-touch-icon" href="img/icon144.png" sizes="144x144" />
    <link rel="apple-touch-icon" href="img/icon152.png" sizes="152x152" />

    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/plugins.css" />
    <link href="css/toastr.css" rel="stylesheet" />
    <style type="text/css">
        #nprogress .bar {
            background-color: #ac2929;
        }
    </style>

    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/themes.css" />
    <link href="css/toastr.css" rel="stylesheet" />
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <link href="css/validationEngine.css" rel="stylesheet" />


    <script src="js/pages/uiProgress.js"></script>
    <script>        $(function () { UiProgress.init(); });</script>
</head>
<body class="loginbg">

    <script type="text/javascript" lang="ja">


        $(document).ready(function () {
            $('input:radio[name=consent]')[0].checked = true;
            getOccupations();
            getuserdetails();
            FillStateCombo();
        });

        function FillStateCombo() {
            // NProgress.start();
            $.post("Ajax/AjaxUser.aspx",
                    { Mode: "FILLSTATECOMBO" },
                       function (varResponseData) {

                           if (varResponseData.Text != "") {
                               $(varResponseData).find('Response').each(function () {

                                   $('#val_State').empty();
                                   var opt = document.getElementById("val_State").options;
                                   opt[opt.length] = new Option('Select', -1);

                                   $(varResponseData).find('Contents').each(function () {

                                       if ($(this).find('StateID').text() != "" && $(this).find('Title').text() != "") {
                                           // console.log(varCategoryID);
                                           opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('StateID').text());
                                       }
                                   }); // end of Contents

                                   $('#val_State').trigger('chosen:updated');


                               }); //end of Response
                           } //END OF if (VarResponseData
                       });        //END OF function (VarResponse...


            return false;
        }

        function GetCities(pvarStateID) {
            pvarStateID = $('#val_State').val();
            //alert(pvarStateID);
            $('#div_cities').show();

            $.post("Ajax/AjaxUser.aspx",
                    {
                        Mode: "FILLCITIESOFSELECTEDSTATE",
                        StateID: pvarStateID
                    },
                       function (varResponseData) {

                           if (varResponseData.Text != "") {
                               $(varResponseData).find('Response').each(function () {

                                   $('#val_City').empty();
                                   var opt = document.getElementById("val_City").options;
                                   opt[opt.length] = new Option('Select', -1);

                                   $(varResponseData).find('Contents').each(function () {

                                       if ($(this).find('CityID').text() != "" && $(this).find('Title').text() != "") {
                                           // console.log(varCategoryID);
                                           opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('CityID').text());
                                       }
                                   }); // end of Contents

                                   $('#val_City').trigger('chosen:updated');


                               }); //end of Response
                           } //END OF if (VarResponseData
                       });        //END OF function (VarResponse...


            return false;
        }


        function getuserdetails() {

            $.post("Ajax/AjaxUser.aspx",
          {
              Mode: "GETUSERDET"
          },
          function (varResponseData) {
              if (varResponseData != "") {

                  $(varResponseData).find('Response').each(function () {

                      $(varResponseData).find('AdminData').each(function () {

                          if ($(this).find('Full_Name').text() != "" && $(this).find('Full_Name').text() != " ") {

                              var fullName = $(this).find('Full_Name').text();

                              if (fullName != "") {

                                  var firstname = fullName.split(" ")[0];
                                  var lastname = fullName.split(" ")[1];

                                  $("#val_firstname").empty();
                                  $("#val_lastname").empty();

                                  $("#val_firstname").val(firstname);
                                  $("#val_lastname").val(lastname);
                              }
                          }

                          if ($(this).find('UserTypeId').text() != "" && $(this).find('UserTypeId').text() != " ") {

                              var UserTypeId = $(this).find('UserTypeId').text();

                              if (UserTypeId != 3) {
                                  $(".showOnlyForUser").hide();
                              }

                          }

                      }); // end of AdminData

                  }); //end of Response
              }
          }
          );

            return false;
        }

        function SaveUserDet() {



            var varProfileVideo = "";
            var url = $('#val_ProfileVideo').val();
            var regExp = /.*(?:youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=)([^#\&\?]*).*/;
            var match = url.match(regExp);

            if ($('#val_ProfileVideo').val() != '') {
                if (match) {
                    varProfileVideo = url;
                }
                else {
                    toastr["error"]("Please valid URL");
                    return false;
                }
            }
            else {
                varProfileVideo = "";
            }
            var varFirstName = $('#val_firstname').val();
            var varLastname = $('#val_lastname').val();
            var varOccuID = $('#val_Occupation').val();
            var varOccupation = $('#val_OtherOccupation').val();
            var varOrg = $('#val_Organization').val();
            var varAddress1 = $('#address1').val();
            var varAddress2 = $('#address2').val();
            var varDealer = $('#val_dealer').val();
            var varMga = $('#val_MGA').val();
            var varGovBody = $('#val_GoverningBody').val();
            var varSince = $('#val_Since').val();
            var varPhoneNo = $('#PhoneNumber').val();
            var varStateID = $('#val_State').val();
            var varCityID = $('#val_City').val();
            var varConsent = $('input:radio[name=consent]:checked').val();
            var varOccupationText = $('#val_Occupation option:selected').text();
            var varCityText = $('#val_City option:selected').text();
            if (varConsent == "yes")
                varConsent = 1;
            else
                varConsent = 0;

            if (varFirstName.trim() == "") {
                toastr["info"]("Please enter first name");
                return false;
            }

            else if (varLastname.trim() == "") {
                $('#val_OtherOccupation').hide();
                toastr["info"]("Please enter last name");
                return false;
            }

            if (varOccuID == "-1") {
                toastr["info"]("Please select an occupation");
                return false;
            }

            else if ((varOccupation.trim() == "" && varOccuID == 7) && $('#div_OtherOccupation').is(':visible')) {
                $('#val_OtherOccupation').show();
                toastr["info"]("Please enter other occupation");
                return false;

            }

            if ($('.showOnlyForUser').is(':visible')) {

                if (varOrg.trim() == "") {
                    toastr["info"]("Please enter an organization");
                    return false;
                }

                else if (varSince.trim() == "") {
                    toastr["info"]("Please enter in business since");
                    return false;
                }
            }

            else if (varAddress1.trim() == "") {
                toastr["info"]("Please enter an address to save details..");
                return false;
            }
            else if (varStateID == "-1") {
                toastr["info"]("Please select a state to save details..");
                return false;
            }
            else if (varCityID == "-1") {
                toastr["info"]("Please select a city to save details..");
                return false;
            }

            $.post("Ajax/AjaxUser.aspx",
          {
              Mode: "ADDUSERDET",
              FirstName: varFirstName,
              Lastname: varLastname,
              Organization: varOrg,
              OtherOccupation: varOccupation,
              Address_line1: varAddress1,
              Address_Line2: varAddress2,
              DealerName: varDealer,
              Mga: varMga,
              GoverningBody: varGovBody,
              InBusinessSince: varSince,
              Mobile_Phone: varPhoneNo,
              OccupationID: varOccuID,
              CommunicateConsent: varConsent,
              OccupationText: varOccupationText,
              StateID: varStateID,
              CityID: varCityID,
              CityText: varCityText,
              ProfileYoutubeURL: varProfileVideo

          },
          function (varResponseData) {

              console.log(varResponseData);

              if (varResponseData != "") {
                  if (varResponseData == "SUCCESS") {

                      $('#setup-container').hide();
                      $('#div_message').show();
                      $('#lblmessage').text('Yours profile details has been updated successfully.');
                  }
                  if (varResponseData == "EXPERT") {
                      $('#setup-container').hide();
                      $('#div_message').show();
                      $('#lblmessage').text('Yours profile details has been updated successfully. Your account is awaiting administrator' + "'" + 's approval. Please wait for the confirmation email with in 48 hours.');


                  }
              }
          }
          );

            return false;

        }



        //#A Sahil:072314 - function for showing HomePage
        function redirectToHome() {

            window.location = "Forum.aspx";
        }



        function getOccupations() {
            console.log("getOccupations");
            $.post("Ajax/AjaxUser.aspx",
            { Mode: "GetOccupations" },
                function (varResponseData) {
                    console.log(varResponseData);

                    if (varResponseData.Text != "") {

                        $(varResponseData).find('Response').each(function () {
                            $(varResponseData).find('GetTypes').each(function () {
                                $('#val_Occupation').empty();

                                var opt = document.getElementById("val_Occupation").options;
                                opt[opt.length] = new Option('Choose an Occupation...', -1);

                                $(varResponseData).find('Contents').each(function () {
                                    if ($(this).find('ID').text() != "" && $(this).find('Name').text() != "") {
                                        opt[opt.length] = new Option($(this).find('Name').text(), $(this).find('ID').text());
                                    }
                                }); // end of Contents

                            }); // 
                        }); //end of Response
                    } //END OF if (VarResponseData
                });     //END OF function (VarResponse...

            return false;
        }

        function SelectOtherOccupation() {
            var varSelectedoccupationID = $('#val_Occupation').val();

            if (varSelectedoccupationID == '7') {

                $('#div_OtherOccupation').show();
            }
            else {
                $('#div_OtherOccupation').hide();
            }

            return false;
        }

        function CloseMessage() {
            window.location = "../../Logout.aspx";
        }
    </script>

    <!-- Login Background -->
    <div id="login-background">
        <!-- For best results use an image with a resolution of 2560x400 pixels (prefer a blurred image for smaller file size) -->
        <!--<img src="img/placeholders/headers/login_header.jpg" alt="Login Background" class="animation-pulseSlow">-->
    </div>
    <!-- END Login Background -->
    <!-- Login Container -->
    <div id="login-container" class="animation-fadeIn">
        <!-- Login Title -->

        <div style="padding: 3px 3px 3px 13px;" class="login-title text-left">
            <h1>
                <small><strong style="font-size: 20px;">Welcome and thanks for choosing E2A Forums</strong></small>
            </h1>
        </div>
        <div id="setup-container">
            <!-- END Login Title -->
            <!-- Login Block -->
            <div class="block remove-margin" id="div_forUserRegsitration">

                <form id="basic-wizard" action="#" class="form-horizontal form-bordered text-info">
                    <!-- First Step -->
                    <div id="first" class="step text-info">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="val_firstname">
                                First Name <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_firstname" name="val_firstname" class="form-control" placeholder="First Name" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-4 control-label" for="val_lastname">
                                Last Name <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_lastname" name="val_lastname" class="form-control" placeholder="Last Name" />
                                </div>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="col-md-4 control-label" for="val_Occupation">
                                Occupation <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">
                                <select id="val_Occupation" name="val_Occupation" class="form-control" onchange="return SelectOtherOccupation();">
                                </select>

                            </div>
                        </div>

                        <div class="form-group" id="div_OtherOccupation" style="display: none;">
                            <label class="col-md-4 control-label" for="val_OtherOccupation">
                                Other Occupation <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_OtherOccupation" name="val_OtherOccupation" class="form-control" placeholder="Other Occupation" />
                                </div>
                            </div>
                        </div>
                        <!-- Form Buttons -->
                        <div class="form-group form-actions">
                            <div class="col-md-12 text-center">
                                <button type="button" class="btn btn-sm btn-default text-left" onclick="window.location ='../signin.aspx'; return false;">Exit Wizard</button>

                                <input type="submit" class="btn btn-sm btn-primary" id="next" value="Next" />
                            </div>
                        </div>
                        <!-- END Form Buttons -->

                    </div>
                    <!-- END First Step -->

                    <!-- Second Step -->
                    <div id="second" class="step">
                        <div class="form-group showOnlyForUser">
                            <label class="col-md-4 control-label" for="val_Organization">
                                Organization<span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_Organization" name="val_Organization" class="form-control" placeholder="Organization Name" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-md-4 control-label" for="val_Address">
                                Address<span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">
                                <input type="text" id="address1" name="address1" class="form-control" placeholder="Street address 1" />
                                <input type="text" id="address2" name="address2" class="form-control" placeholder="Street address 2" />
                            </div>
                        </div>
                        <%--  <div class="form-group">
                        <label class="col-md-4 control-label" for="city">
                            City
                        </label>
                        <div class="col-md-6">
                            <input type="text" id="city" name="city" class="form-control" placeholder="Which one?" />
                        </div>
                    </div>--%>
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="val_State">
                                Province <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">

                                <select id="val_State" name="val_State" class="form-control" onchange="return GetCities(this);">
                                </select>

                            </div>
                        </div>
                        <div class="form-group" id="div_cities" style="display: none;">
                            <label class="col-md-4 control-label" for="val_City">
                                City <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">

                                <select id="val_City" name="val_City" class="form-control">
                                </select>

                            </div>
                        </div>
                        <div class="form-group showOnlyForUser" id="div_ProfileVideo">
                            <label class="col-md-4 control-label" for="val_OtherOccupation">
                                Profile Video <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_ProfileVideo" name="val_ProfileVideo" class="form-control" placeholder="Enter Valid URL..." />
                                </div>
                            </div>
                        </div>
                        <div class="form-group showOnlyForUser">
                            <label class="col-md-4 control-label" for="val_ Dealer">
                                Dealer Name
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_dealer" name="val_dealer" class="form-control" placeholder="Dealer Name" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group showOnlyForUser">
                            <label class="col-md-4 control-label" for="val_Address">
                                MGA
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_MGA" name="val_MGA" class="form-control" placeholder="MGA" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group showOnlyForUser">
                            <label class="col-md-4 control-label" for="val_Address">
                                Governing Body
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_GoverningBody" name="val_GoverningBody" class="form-control" placeholder="Governing Body" />
                                </div>
                            </div>
                        </div>


                        <div class="form-group showOnlyForUser">
                            <label class="col-md-4 control-label" for="val_Address">
                                In Business Since<span class="text-danger">*</span>
                            </label>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <input type="text" id="val_Since" name="val_Since" class="form-control" maxlength="4" placeholder="1970" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group showOnlyForUser">
                            <label class="col-md-4 control-label" for="PhoneNumber">
                                Phone Number 
                            </label>
                            <div class="col-md-6">
                                <input type="text" id="PhoneNumber" name="PhoneNumber" placeholder="(999) 999-9999"
                                    class="form-control" />
                            </div>
                        </div>


                        <div class="form-group">
                            <strong>As per Canada's  Anti-spam legislation Do you give us your consent to communicate : 
                                  <span style="margin-left: 0px;">
                                      <input type="radio" value="yes" name="consent" />
                                      Yes &nbsp;
                                      <input type="radio" value="No" name="consent" />
                                      No </span></strong>

                        </div>


                        <div class="form-group form-actions">
                            <div class="col-md-12 col-md-offset-4">
                                <%--<button type="button" class="btn btn-sm btn-default" onclick="window.location ='page_ready_forum.html'; return false;">Exit SetUp Wizard    	 </button>--%>
                                <input type="reset" class="btn btn-sm btn-warning ui-wizard-content ui-formwizard-button" id="back" value="Back" />
                                <input type="button" class="btn btn-sm btn-primary" id="Next2" value="Save" onclick="SaveUserDet();" />
                            </div>
                        </div>

                    </div>
                    <!-- END Second Step -->

                </form>
                <!-- END Form Validation Example Content -->

            </div>
        </div>
    <!-- END Login Block -->
    <div id="div_message" class="col-lg-12 text-center" style="height: 200px; display: none; background-color: rgba(255,255,255,0.9);">        
        <div class="form-group form-actions text-center">
            <h3 class="text-primary" id="lblmessage"></h3>
            <br />
            <br />
            <button type="button" id="btn_Closemessage" class="btn btn-sm btn-primary" onclick="return CloseMessage();">
                Go back to login</button>
        </div>

    </div>
    </div>

    <!-- END Login Container -->
    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>        !window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/vendor/bootstrap.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>
    <script src="js/pages/formsWizard.js"></script>
    <!-- Load and execute javascript code used only in this page -->
    <script src="js/pages/formsValidation.js"></script>
    <!-- common.js user for Google Analytics Object code-->

    <script>

        $(function () {


            FormsWizard.init();
            $('#PhoneNumber').mask('(999) 999-9999');
            $("#Country").val('United States');
            $('#Country').trigger('chosen:updated');

            $('#PhoneNumber').mask('(999) 999-9999');
        });

    </script>
</body>
</html>
