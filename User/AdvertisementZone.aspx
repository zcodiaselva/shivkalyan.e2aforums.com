<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvertisementZone.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>e2aforums Admin</title>
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
                        <div class="block-title">
                            <h2>Advertisement Zone Listing</h2>
                            <a data-toggle="modal" href="#modal-Add-Advertisement">
                                <button type="button" id="btnAddAdvertisement" class="btn btn-sm btn-primary" style="float: right; margin-right: 30px; margin-top: 5px;"
                                    onclick="return ResetForm();">
                                    ADD</button></a>
                        </div>
                        <!-- Datatables Content -->
                        <div class="table-responsive">
                           <%-- <div id="TblAdvertisementDetails_wrapper" class="dataTables_wrapper" role="grid">--%>
                                <div class="row">
                                </div>

                                <table id="TblAdvertisement" class="table table-vcenter table-condensed table-bordered">
                                </table>
                          <%--  </div>--%>
                        </div>
                        <div id="modal-Add-Advertisement" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
                            <form id="form_Advertisement" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered" onsubmit="return false;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" id="btn_addAdvertisementClose" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h3 id="headerTitle" class="modal-title">Add Advertisement Zone
                                            </h3>
                                        </div>
                                        <fieldset>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Title:
                                                </label>
                                                <div class="col-md-6">
                                                    <input id="txtTitle" name="txtTitle" class="form-control" placeholder="Title..."
                                                        type="text" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Description:
                                                </label>
                                                <div class="col-md-6">
                                                    <textarea cols="4" rows="4" id="txtDescription" name="txtDescription" class="form-control" placeholder="Description..."></textarea>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                        <label class="col-md-3 control-label" for="text-input"">
                                                            Is Open:</label>
                                                        <div class="col-md-8">
                                                            <label class="switch switch-primary">
                                                                <input type="checkbox" id="CbIsOpen" name="CbIsOpen" checked="" onchange="return ShowProvinceDiv();"/>
                                                              <span></span>
                                                            </label>

                                                        </div>
                                                    </div>
                                            <div class="form-group" id="divProvince" style="display:none;">
                                                <label class="col-md-3 control-label">
                                                    Province:
                                                </label>
                                                <div class="col-md-6">
                                                    <select id="cmbState" name="cmbState" class="form-control" onchange="return GetCities(this);">
                                                    </select>
                                                </div>
                                            </div>
                                            <div id="tr_city" class="form-group" style="display:none">
                                                <label class="col-md-3 control-label">
                                                    City:
                                                </label>
                                                <div class="col-md-6">
                                                    <select multiple="multiple" id="cmbCity" name="example-chosen-multiple" class="select-chosen" data-placeholder="Select Cities for zone"></select>
                                                </div>
                                            </div>
                                        </fieldset>
                                        <div class="modal-footer">
                                            <button type="button" id="BtnSaveAdvertisement" class="btn btn-sm btn-primary" onclick="return AddNewAdvertisement();">
                                                Save</button>
                                            <button type="button" id="BtnEditAdvertisement" class="btn btn-sm btn-primary" onclick="return AddNewAdvertisement();"
                                                style="display: none;">
                                                Update</button>
                                            <button id="btn_addAdvertisementClosebtn" type="button" class="btn btn-sm btn-default" data-dismiss="modal">
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



    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
   
    <script src="js/plugins.js"></script>
    <script src="PagesJs/AdvertisementZone.js" type="text/javascript"></script>
    <script src="PagesJs/Common.js" type="text/javascript"></script>
    <script src="js/ajaxfileupload.js"></script>
    <script src="js/app.js"></script>
    <script src="../js/jquery-ui.js"></script>

    <script src="js/jquery.ui.datepicker.js"></script>
    <%--<script src="js/jquery.tooltipster.js"></script>--%>
    <script src="js/FileReader.js"></script>
    <script language="javascript" type="text/javascript">

        $(function () {

            $("#datepickerFrom").datepicker({
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

            $("#datepickerTo").datepicker({
                inline: true,
                showOtherMonths: true,
                dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                dateFormat: "dd-M-yy"
            });

            if ("<%=IsAdmin%>" == 'True') {
                $('.adminLinks').show();
                $('.UserLinks').hide();
            }
            if (VarUserTypeID != 2) {
                $('.UserLinks').show();
            }
        });

        var ImgHeight = 0;
        var ImgWidth = 0;
        var img;
        function showimagepreview(input) {

            if (input.files && input.files[0]) {

                var filerdr = new FileReader();

                filerdr.onload = function (e) {
                    console.log(e);
                    $('#imgprvw').attr('src', e.target.result);
                    $("#imgprvw").fadeIn();
                    $("#imgprev-a").fadeIn();

                    img = document.createElement('img');
                    img.onload = imageLoaded;
                    img.style.display = 'none'; // If you don't want it showing
                    img.src = e.target.result;
                    document.body.appendChild(img);


                }

                function imageLoaded() {
                    ImgWidth = img.width
                    ImgHeight = img.height;
                    img.parentNode.removeChild(img);
                    img = undefined;


                }
                filerdr.readAsDataURL(input.files[0]);

            }

        }

        function ChooseImage() {
            if ($('#cmbImgSizes').val() == "" || $('#cmbImgSizes').val() == -1) {
                $('#div_fileupload').hide();
            }
            else {
                $('#div_fileupload').show();
            }
        }
    </script>
    
</body>
</html>
