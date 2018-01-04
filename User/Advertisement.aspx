<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Advertisement.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>e2aforum </title>
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
                            <h2>Advertisement Listing</h2>
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
                            <%-- </div>--%>
                        </div>
                        <div id="modal-Add-Advertisement" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
                            <form id="form_Advertisement" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered" onsubmit="return false;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" id="btn_addAdvertisementClose" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h3 id="headerTitle" class="modal-title">Add Advertisement
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
                                                <label class="col-md-3 control-label">
                                                    Image Size:
                                                </label>
                                                <div class="col-md-3">
                                                    <div class="input-group">
                                                        <select id="cmbImgSizes" name="cmbImgSizes" style="width: 140px; height: 30px;" class="form-control" onchange="return ChooseImage();">
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group" id="div_fileupload" style="display: none;">
                                                <label class="col-md-3 control-label">
                                                    Image:
                                                </label>
                                                <div class="col-md-3">
                                                    <input type="file" name="fileUpload" id="fileUpload" onchange="showimagepreview(this)" />
                                                    <a href="" id="imgprev-a" target="_blank" style="display: none;">
                                                        <img id="imgprvw" height="50" style="width: 50px; margin: 5px;" alt="" src="" /></a>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Click URL:
                                                </label>
                                                <div class="col-md-3">
                                                    <input id="txtClickUrl" name="txtClickUrl" class="form-control" placeholder="Enter URL..."
                                                        style="width: 200px;" type="text" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Zone:
                                                </label>
                                                <div class="col-md-3">
                                                    <select id="cmbZone" name="cmbZone" style="width: 140px; height: 30px;" class="form-control">
                                                    </select>

                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    From Date: 
                                                </label>
                                                <div class="col-md-3">
                                                    <input type="text" id="datepickerFrom" name="datepickerFrom" class="form-control"
                                                        style="width: 150px; margin: 0px 0px 0px -10px; float: left;" />


                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    To Date: 
                                                </label>
                                                <div class="col-md-3">
                                                    <input type="text" id="datepickerTo" name="datepickerTo" class="form-control"
                                                        style="width: 150px; margin: 0px 0px 0px -10px; float: left;" />



                                                </div>
                                            </div>
                                             <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                   From Time:
                                                </label>
                                                <div class="col-md-3">
                                                    <select id="cmbStartHH" name="cmbStartHH" style="width: 70px; height: 30px;" class="form-control">
                                                                <option value="-1">HH</option>
                                                                <option value="00">00</option>
                                                                <option value="01">01</option>
                                                                <option value="02">02</option>
                                                                <option value="03">03</option>
                                                                <option value="04">04</option>
                                                                <option value="05">05</option>
                                                                <option value="06">06</option>
                                                                <option value="07">07</option>
                                                                <option value="08">08</option>
                                                                <option value="09">09</option>
                                                                <option value="10">10</option>
                                                                <option value="11">11</option>
                                                                <option value="12">12</option>
                                                            </select>
                                                    </div>
                                                    <div class="col-md-3">  <select id="cmbStartMM" name="cmbStartMM" style="width: 70px; height: 30px;" class="form-control">
                                                                <option value="-1">MM</option>
                                                                <option value="00">00</option>
                                                                <option value="01">01</option>
                                                                <option value="02">02</option>
                                                                <option value="03">03</option>
                                                                <option value="04">04</option>
                                                                <option value="05">05</option>
                                                                <option value="06">06</option>
                                                                <option value="07">07</option>
                                                                <option value="08">08</option>
                                                                <option value="09">09</option>
                                                                <option value="10">10</option>
                                                                <option value="11">11</option>
                                                                <option value="12">12</option>
                                                                <option value="13">13</option>
                                                                <option value="14">14</option>
                                                                <option value="15">15</option>
                                                                <option value="16">16</option>
                                                                <option value="17">17</option>
                                                                <option value="18">18</option>
                                                                <option value="19">19</option>
                                                                <option value="20">20</option>
                                                                <option value="21">21</option>
                                                                <option value="22">22</option>
                                                                <option value="23">23</option>
                                                                <option value="24">24</option>
                                                                <option value="25">25</option>
                                                                <option value="26">26</option>
                                                                <option value="27">27</option>
                                                                <option value="28">28</option>
                                                                <option value="29">29</option>
                                                                <option value="30">30</option>
                                                                <option value="31">31</option>
                                                                <option value="32">32</option>
                                                                <option value="33">33</option>
                                                                <option value="34">34</option>
                                                                <option value="35">35</option>
                                                                <option value="36">36</option>
                                                                <option value="37">37</option>
                                                                <option value="38">38</option>
                                                                <option value="39">39</option>
                                                                <option value="40">40</option>
                                                                <option value="41">41</option>
                                                                <option value="42">42</option>
                                                                <option value="43">43</option>
                                                                <option value="44">44</option>
                                                                <option value="45">45</option>
                                                                <option value="46">46</option>
                                                                <option value="47">47</option>
                                                                <option value="48">48</option>
                                                                <option value="49">49</option>
                                                                <option value="50">50</option>
                                                                <option value="51">51</option>
                                                                <option value="52">52</option>
                                                                <option value="53">53</option>
                                                                <option value="54">54</option>
                                                                <option value="55">55</option>
                                                                <option value="56">56</option>
                                                                <option value="57">57</option>
                                                                <option value="58">58</option>
                                                                <option value="59">59</option>
                                                            </select></div>
                                                     <div class="col-md-3"> <select id="cmbStartAMPM" name="cmbStartAMPM" style="width: 100px; height: 30px;" class="form-control">
                                                                <option value="-1">Select</option>
                                                                <option value="AM">AM</option>
                                                                <option value="PM">PM</option>
                                                            </select>


                                                </div>
                                            </div>
                                             <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                   To Time:
                                                </label>
                                                <div class="col-md-3">
                                                   <select id="cmbTotHH" name="cmbTotHH" style="width: 70px; height: 30px;" class="form-control">
                                                                <option value="-1">HH</option>
                                                                <option value="00">00</option>
                                                                <option value="01">01</option>
                                                                <option value="02">02</option>
                                                                <option value="03">03</option>
                                                                <option value="04">04</option>
                                                                <option value="05">05</option>
                                                                <option value="06">06</option>
                                                                <option value="07">07</option>
                                                                <option value="08">08</option>
                                                                <option value="09">09</option>
                                                                <option value="10">10</option>
                                                                <option value="11">11</option>
                                                                <option value="12">12</option>
                                                            </select></div>
                                               <div class="col-md-3"><select id="cmbToMM" name="cmbToMM" style="width: 70px; height: 30px;" class="form-control">
                                                                <option value="-1">MM</option>
                                                                <option value="00">00</option>
                                                                <option value="01">01</option>
                                                                <option value="02">02</option>
                                                                <option value="03">03</option>
                                                                <option value="04">04</option>
                                                                <option value="05">05</option>
                                                                <option value="06">06</option>
                                                                <option value="07">07</option>
                                                                <option value="08">08</option>
                                                                <option value="09">09</option>
                                                                <option value="10">10</option>
                                                                <option value="11">11</option>
                                                                <option value="12">12</option>
                                                                <option value="13">13</option>
                                                                <option value="14">14</option>
                                                                <option value="15">15</option>
                                                                <option value="16">16</option>
                                                                <option value="17">17</option>
                                                                <option value="18">18</option>
                                                                <option value="19">19</option>
                                                                <option value="20">20</option>
                                                                <option value="21">21</option>
                                                                <option value="22">22</option>
                                                                <option value="23">23</option>
                                                                <option value="24">24</option>
                                                                <option value="25">25</option>
                                                                <option value="26">26</option>
                                                                <option value="27">27</option>
                                                                <option value="28">28</option>
                                                                <option value="29">29</option>
                                                                <option value="30">30</option>
                                                                <option value="31">31</option>
                                                                <option value="32">32</option>
                                                                <option value="33">33</option>
                                                                <option value="34">34</option>
                                                                <option value="35">35</option>
                                                                <option value="36">36</option>
                                                                <option value="37">37</option>
                                                                <option value="38">38</option>
                                                                <option value="39">39</option>
                                                                <option value="40">40</option>
                                                                <option value="41">41</option>
                                                                <option value="42">42</option>
                                                                <option value="43">43</option>
                                                                <option value="44">44</option>
                                                                <option value="45">45</option>
                                                                <option value="46">46</option>
                                                                <option value="47">47</option>
                                                                <option value="48">48</option>
                                                                <option value="49">49</option>
                                                                <option value="50">50</option>
                                                                <option value="51">51</option>
                                                                <option value="52">52</option>
                                                                <option value="53">53</option>
                                                                <option value="54">54</option>
                                                                <option value="55">55</option>
                                                                <option value="56">56</option>
                                                                <option value="57">57</option>
                                                                <option value="58">58</option>
                                                                <option value="59">59</option>
                                                            </select></div>
                                                     <div class="col-md-3"> <select id="cmbToAMPM" name="cmbToAMPM" style="width: 100px; height: 30px;" class="form-control">
                                                                <option value="-1">Select</option>
                                                                <option value="AM">AM</option>
                                                                <option value="PM">PM</option>
                                                            </select>


                                                </div>
                                            </div>
                                        </fieldset>

                                        <div class="modal-footer">
                                            <button type="button" id="BtnSaveAdvertisement" class="btn btn-sm btn-primary" onclick="return AddNewAdvertisement();">
                                                Save</button>
                                            <button type="button" id="BtnEditAdvertisement" class="btn btn-sm btn-primary" onclick="return AddNewAdvertisement();"
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


    <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
    <a href="#" id="to-top"><i class="fa fa-angle-double-up"></i></a>


    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>!window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
  
    <script src="js/plugins.js"></script>
    <script src="PagesJs/Advertisement.js" type="text/javascript"></script>
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
