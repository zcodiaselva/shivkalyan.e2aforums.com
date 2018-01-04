<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Followup2.aspx.cs" Inherits="User_Followup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">

    <title>Follow up</title>

    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">

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
    <link href="css/toastr.css" rel="stylesheet" />
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
    <link href="css/datepicker.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .ui-autocomplete {
            max-height: 100px;
            overflow-y: auto; /*prevent horizontal scrollbar */
            overflow-x: hidden; /* add padding to account for vertical scrollbar */
            padding-right: 20px;
        }
        /* IE 6 doesn't support max-height
	 * we use height instead, but this forces the menu to always be this tall
	 */
        * html .ui-autocomplete {
            height: 100px;
        }



        .ui-datepicker {
            width: 216px;
            height: auto;
            margin: 5px auto 0;
            font: 9pt Arial, sans-serif;
            -webkit-box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, .5);
            -moz-box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, .5);
            box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, .5);
        }

            .ui-datepicker a {
                text-decoration: none;
            }


            .ui-datepicker table {
                width: 100%;
            }


        .ui-datepicker-header {
            background: url('Images/dark_leather.png') repeat 0 0 #000;
            color: #e0e0e0;
            font-weight: bold;
            -webkit-box-shadow: inset 0px 1px 1px 0px rgba(250, 250, 250, 2);
            -moz-box-shadow: inset 0px 1px 1px 0px rgba(250, 250, 250, .2);
            box-shadow: inset 0px 1px 1px 0px rgba(250, 250, 250, .2);
            text-shadow: 1px -1px 0px #000;
            filter: dropshadow(color=#000, offx=1, offy=-1);
            line-height: 30px;
            border-width: 1px 0 0 0;
            border-style: solid;
            border-color: #111;
        }


        .ui-datepicker-title {
            text-align: center;
        }

        .ui-datepicker-prev, .ui-datepicker-next {
            display: inline-block;
            width: 30px;
            height: 30px;
            text-align: center;
            cursor: pointer;
            background-image: url('Images/arrow.png');
            background-repeat: no-repeat;
            line-height: 600%;
            overflow: hidden;
        }


        .ui-datepicker-prev {
            float: left;
            background-position: center -30px;
        }

        .ui-datepicker-next {
            float: right;
            background-position: center 0px;
        }

        .ui-datepicker thead {
            background-color: #f7f7f7;
            border-bottom: 1px solid #bbb;
            background-image: linear-gradient(top, #f7f7f7 0%,#f1f1f1 100%);
        }

        .ui-datepicker th {
            text-transform: uppercase;
            font-size: 6pt;
            padding: 5px 0;
            color: #666666;
            text-shadow: 1px 0px 0px #fff;
            filter: dropshadow(color=#fff, offx=1, offy=0);
        }


        .ui-datepicker tbody td {
            padding: 0;
            border-right: 1px solid #bbb;
        }


            .ui-datepicker tbody td:last-child {
                border-right: 0px;
            }

        .ui-datepicker tbody tr {
            border-bottom: 1px solid #bbb;
        }

            .ui-datepicker tbody tr:last-child {
                border-bottom: 0px;
            }

        .ui-datepicker tbody tr {
            border-bottom: 1px solid #bbb;
        }

            .ui-datepicker tbody tr:last-child {
                border-bottom: 0px;
            }


        /*sahil*/

        .ui-datepicker td span, .ui-datepicker td a {
            display: inline-block;
            font-weight: bold;
            text-align: center;
            width: 30px;
            height: 30px;
            line-height: 30px;
            color: #666666;
            text-shadow: 1px 1px 0px #fff;
            filter: dropshadow(color=#fff, offx=1, offy=1);
        }

        .ui-datepicker-calendar .ui-state-default {
            background: #ededed;
            background: -moz-linear-gradient(top, #ededed 0%, #dedede 100%);
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#ededed), color-stop(100%,#dedede));
            background: -webkit-linear-gradient(top, #ededed 0%,#dedede 100%);
            background: -o-linear-gradient(top, #ededed 0%,#dedede 100%);
            background: -ms-linear-gradient(top, #ededed 0%,#dedede 100%);
            background: linear-gradient(top, #ededed 0%,#dedede 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ededed', endColorstr='#dedede',GradientType=0 );
            -webkit-box-shadow: inset 1px 1px 0px 0px rgba(250, 250, 250, .5);
            -moz-box-shadow: inset 1px 1px 0px 0px rgba(250, 250, 250, .5);
            box-shadow: inset 1px 1px 0px 0px rgba(250, 250, 250, .5);
        }

        .ui-datepicker-unselectable .ui-state-default {
            background: #f4f4f4;
            color: #b4b3b3;
        }


        .ui-datepicker-calendar .ui-state-hover {
            background: #f7f7f7;
        }

        .ui-datepicker-calendar .ui-state-active {
            background: #6eafbf;
            -webkit-box-shadow: inset 0px 0px 10px 0px rgba(0, 0, 0, .1);
            -moz-box-shadow: inset 0px 0px 10px 0px rgba(0, 0, 0, .1);
            box-shadow: inset 0px 0px 10px 0px rgba(0, 0, 0, .1);
            color: #e0e0e0;
            text-shadow: 0px 1px 0px #4d7a85;
            filter: dropshadow(color=#4d7a85, offx=0, offy=1);
            border: 1px solid #55838f;
            position: relative;
            margin: -1px;
        }

        .ui-datepicker-calendar td:first-child .ui-state-active {
            width: 29px;
            margin-left: 0;
        }

        .ui-datepicker-calendar td:last-child .ui-state-active {
            width: 29px;
            margin-right: 0;
        }

        .ui-datepicker-calendar tr:last-child .ui-state-active {
            height: 29px;
            margin-bottom: 0;
        }

        .image-upload > input {
            display: none;
        }
    </style>
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
        <HM:SideBar ID="SideBar" runat="server" />

        <!-- Main Container -->
        <div id="main-container">
            <!-- Header -->
          <%--  <HR:TopBar ID="TopBar" runat="server" />--%>
            <!-- END Header -->

            <!-- Page content -->
            <div id="page-content">
                <!-- Forum Block -->
                <div class="block">
                    <!-- Tab Content -->
                    <div class="tab-content">
                        <!-- Forum -->
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="block full">
                                    <div class="block-title" style="color: #F31455;">
                                        <h2>Follow-UP</h2>

                                    </div>
                                    <form id="form-FollowUp" action="" class="form-horizontal form-bordered">
                                        <!-- Datatables Content -->
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                FollowUp Text <span class="text-danger">*</span></label>
                                            <div class="col-md-4">
                                                <input id="txtFollowUp" name="txtFollowUp" class="form-control" placeholder="Title" type="text" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                Description:</label>
                                            <div class="col-md-4">
                                                <textarea id="txtFollowUpDesc" cols="20" rows="4" name="txtFollowUpDesc" class="form-control" placeholder="Description"></textarea>
                                            </div>
                                        </div>
                                        <div class="form-group" id="div_Status">
                                            <label class="col-md-3 control-label" for="val_Status">
                                                Clients/Prospects <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">

                                                <select id="val_Customers" name="val_Customers" class="form-control">
                                                </select>

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                Venue <span class="text-danger">*</span></label>
                                            <div class="col-md-4">
                                                <textarea id="txtVenue" cols="20" rows="4" name="txtVenue" class="form-control" placeholder="Venue"></textarea>
                                            </div>
                                        </div>
                                           <div class="form-group" id="div_cities">
                                            <label class="col-md-3 control-label" for="val_City">
                                                City <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">
                                          <select id="val_City" name="val_City" class="select-chosen" data-placeholder="Choose a City..." style="width: 250px;" onchange="return GetProvince(this);">
                                          </select>

                                            </div>
                                        </div>
                                        <div class="form-group" id="div_State">
                                            <label class="col-md-3 control-label" for="val_State">
                                                Province <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">
                                                   <select id="val_State" name="val_State" class="select-chosen" data-placeholder="Choose a City..." style="width: 250px;" >
                                          </select>
                                                
                                              </div>
                                        </div>
                                        <%-- <div class="form-group">
                                            <label class="col-md-3 control-label" for="val_State">
                                                Province <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">

                                                <select id="val_State" name="val_State" class="form-control" onchange="return GetCities(this);">
                                                </select>

                                            </div>
                                        </div>
                                        <div class="form-group" id="div_cities" style="display: none;">
                                            <label class="col-md-3 control-label" for="val_City">
                                                City <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">

                                                <select id="val_City" name="val_City" class="form-control">
                                                </select>

                                            </div>
                                        </div>--%>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                FollowUp Date <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">
                                                <input id="datepickerFollowUp" name="datepickerFollowUp" class="form-control input-datepicker" data-date-format="dd/mm/yy" placeholder="dd/mm/yy" type="text" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="example-timepicker">Start Time <span class="text-danger">*</span></label>
                                            <div class="col-md-4">
                                                <div class="input-group bootstrap-timepicker">
                                                    <input type="text" id="Starttimepicker" style="z-index: 0;" name="Starttimepicker" class="form-control input-timepicker24">
                                                    <span class="input-group-btn">
                                                        <a href="javascript:void(0)" class="btn btn-primary"><i class="fa fa-clock-o"></i></a>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="example-timepicker">End Time <span class="text-danger">*</span></label>
                                            <div class="col-md-4">
                                                <div class="input-group bootstrap-timepicker">
                                                    <input type="text" id="Endtimepicker" name="Endtimepicker" style="z-index: 0;" class="form-control input-timepicker24">
                                                    <span class="input-group-btn">
                                                        <a href="javascript:void(0)" class="btn btn-primary"><i class="fa fa-clock-o"></i></a>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <button type="button" id="BtnSaveFollowUp" class="btn btn-sm btn-primary"
                                                style="margin-left: 33%;">
                                                SAVE</button>
                                            <%--  <button type="button" class="btn btn-sm btn-default" data-dismiss="modal" >
                                                    Cancel</button>--%>
                                        </div>
                                    </form>



                                </div>
                            </div>

                        </div>
                    </div>

                </div>
                <!-- END Tab Content -->
                <HP:UserProfile ID="UserProfile" runat="server" />
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
    <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
    <a href="#" id="to-top"><i class="fa fa-angle-double-up"></i></a>
    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>!window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
    <script src="js/vendor/bootstrap.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="js/app.js"></script>

    <script src="PagesJs/Common.js" type="text/javascript"></script>
    <script src="js/FileReader.js"></script>
    <script src="js/ajaxfileupload.js"></script>
    <script src="js/jquery.ui.datepicker.js"></script>
    <%--<script src="js/jquery.tooltipster.js"></script>--%>

    <script language="javascript" type="text/javascript">
        var mvarCustomerID = -1;
        $(function () {
            mvarCustomerID = '<%= CustomerID%>';

            FillCustomerCombo()
            $("#datepickerFollowUp").datepicker({
                inline: true,
                showOtherMonths: true,
                dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                dateFormat: "dd-M-yy",
                minDate: 0,
                onSelect: function (date) {
                    var dt2 = $('#datepickerTo');
                    var startDate = $(this).datepicker('getDate');
                    var minDate = $(this).datepicker('getDate');
                    dt2.datepicker('setDate', minDate);
                    startDate.setDate(startDate.getDate() + 30);
                    //sets dt2 maxDate to the last day of 30 days window
                    dt2.datepicker('option', 'maxDate', startDate);
                    dt2.datepicker('option', 'minDate', minDate);
                    // $(this).datepicker('option', 'minDate', minDate);
                }
            });
        });
        function FillCustomerCombo() {
            // NProgress.start();
            $.post("Ajax/AjaxCustomers.aspx",
                        {
                            Mode: "FILLCUSTOMERCOMBO",
                            CustomerID: mvarCustomerID
                        },
                           function (varResponseData) {

                               if (varResponseData.Text != "") {
                                   $(varResponseData).find('Response').each(function () {

                                       //$('#val_Customers').empty();
                                       var opt = document.getElementById("val_Customers").options;
                                       if (mvarCustomerID == -1) {
                                           opt[opt.length] = new Option('Select', mvarCustomerID);

                                           $(varResponseData).find('Contents').each(function () {

                                               if ($(this).find('CustomerID').text() != "" && $(this).find('Full_Name').text() != "") {
                                                   // console.log(varCategoryID);
                                                   opt[opt.length] = new Option($(this).find('Full_Name').text(), $(this).find('CustomerID').text());
                                               }
                                           }); // end of Contents
                                       }
                                       else {
                                           opt[opt.length] = new Option($(this).find('Full_Name').text(), mvarCustomerID);
                                           // $('#val_Customers').val($(this).find('Full_Name').text());
                                       }
                                       $('#val_Customers').trigger('chosen:updated');


                                   }); //end of Response
                               } //END OF if (VarResponseData
                           });        //END OF function (VarResponse...


            return false;

        }
    </script>
    <script src="PagesJs/FollowUp.js" type="text/javascript"></script>
</body>
</html>
