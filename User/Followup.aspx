<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Followup.aspx.cs" Inherits="User_pro" %>

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
    <script src="js/FileReader.js"></script>
    <script src="js/ajaxfileupload.js"></script>
    <script src="js/jquery.ui.datepicker.js"></script>
    <%--<script src="js/jquery.tooltipster.js"></script>--%>

    <script language="javascript" type="text/javascript">
        var mvarCustomerID = -1;
        $(function () {
            


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
