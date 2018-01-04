<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customers.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>E2aforums Admin</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
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
    <link rel="stylesheet" type="text/css" id="Link2" href="css/plugins.css"/>
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
      <div class="inner-content-wrap">
          <div id="validation-msg-container"></div>
     <!-- Forum Block -->
                <div id="div_customers" class="block">
                    <!-- Tab Content -->
                    <div class="tab-content">
                        <!-- Forum -->
                        <div class="block-title" id="div_customerListing">
                            <h2 id="headerMainTitle" class="modal-title" style="color: #F31455;"></h2>
                            <%-- <h2>Customers Listing</h2>--%>
                            <%--<a data-toggle="modal" href="#modal-Upload-Excel">
                                <button type="button" id="UploadExcelModel" class="btn btn-sm btn-primary" style="float: right; margin-right: 30px; margin-top: 5px;">
                                    Upload</button></a>--%>

                            <a data-toggle="modal" href="#">
                             <%--   <button type="button" id="btnAddCategory" class="btn btn-sm btn-primary" style="float: right; margin-right: 15px; margin-top: 5px;"
                                    onclick="return ResetForm();">--%>
                                   <button type="button" id="btnAddCategory" class="btn btn-sm btn-primary" style="float: right; margin-right: 15px; margin-top: 5px;"
                                    onclick="return GetMode('Add', -1);">
                                    ADD</button></a>
                        </div>
                        <br><br><br>
                        <!-- Datatables Content -->
                        <div class="table-responsive" id="div_customerList">
                            <%-- <div id="TblCategoryDetails_wrapper" class="dataTables_wrapper" role="grid">--%>

                            <div class="row">
                            </div>

                            <table id="TblCustomers" class="table table-vcenter table-condensed table-bordered">
                            </table>
                            <%-- </div>--%>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="block full panel-body form-group-separated" id="div_AddClient" style="display: none;">
                                    <%-- <div class="block-title" style="color: #F31455;">
                                        <h3 id="headerTitle" class="modal-title" style="color: #F31455;">Add Clients/Prospects
                                            </h3>

                                    </div>--%>
                                    <form id="form_Customer" action="" class="form-horizontal form-bordered">

                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                Title<span class="text-danger">*</span></label>
                                            <div class="col-md-1">
                                                <input id="txtTitle" name="txtTitle" class="form-control" placeholder="Title" type="text" />
                                            </div>
                                            <label class="col-md-3 control-label" for="text-input" style="width: 11%;">
                                                First Name<span class="text-danger">*</span></label>
                                            <div class="col-md-3">
                                                <input id="txtFirstName" name="txtFirstName" class="form-control" placeholder="First Name" type="text" />
                                            </div>
                                            <label class="col-md-2 control-label" for="text-input" style="width: 10%;">
                                                Last Name<span class="text-danger">*</span></label>
                                            <div class="col-md-2">
                                                <input id="txtLastName" name="txtLastName" class="form-control" placeholder="Last Name" type="text" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                Date of Birth<span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">
                                                <input id="datepickerDOB" name="datepickerDOB" class="form-control input-datepicker" data-date-format="yyyy/mm/dd" placeholder="yyyy/mm/dd" type="text" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                Anniversary 
                                            </label>
                                            <div class="col-md-4">
                                                <input id="datepickerAnniversary" name="datepickerAnniversary" class="form-control input-datepicker" data-date-format="yyyy/mm/dd" placeholder="yyyy/mm/dd" type="text" />

                                            </div>
                                        </div>
                                        <div class="form-group" id="div_Status">
                                            <label class="col-md-3 control-label" for="val_Status">
                                                Status <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">

                                                <select id="val_Status" name="val_Status" class="form-control">
                                                </select>

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="val_Address">
                                                Residential Address<span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">
                                                <input type="text" id="address1" name="address1" class="form-control" placeholder="Street Address" /><br />
                                                <input type="text" id="address2" name="address2" class="form-control" placeholder="Unit/Appartment" />
                                            </div>
                                        </div>
                                        <div class="form-group" id="div_cities">
                                            <label class="col-md-3 control-label" for="val_City">
                                                City <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">
                                                <select id="val_City" name="val_City" class="select-chosen form-control" onchange="GetProvince();">

                                                </select>

                                            </div>
                                        </div>
                                        <div class="form-group" id="div_State">
                                            <label class="col-md-3 control-label" for="val_State">
                                                Province <span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">
                                                <select id="val_State" name="val_State" class="form-control" data-placeholder="Choose a Province..." style="width: 250px;">
                                                </select>

                                                <%--  <select id="val_State" name="val_State" class="form-control" >
                                                </select>--%>

                                                <%-- <select id="val_State" name="val_State" class="form-control" onchange="return GetCities(this);">
                                                </select>--%>
                                            </div>
                                        </div>
                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="PhoneNumber">
                                                Postal Code:
                                            </label>
                                            <div class="col-md-4">
                                                <input type="text" id="PostalCode" name="PostalCode" placeholder="Postal Code"
                                                    class="form-control" />

                                            </div>
                                        </div>
                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="PhoneNumber">
                                                Phone Number<span class="text-danger">*</span>
                                            </label>
                                            <div class="col-md-4">
                                                <input type="text" id="PhoneNumber" name="PhoneNumber" placeholder="Residence" class="form-control" /><br />
                                                <input type="text" id="Mobile" name="Mobile" placeholder="Cell(Optional)" class="form-control" /><br />
                                                <input type="text" id="txtTelephone" name="txtTelephone" placeholder="Office" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="val_Address">
                                                Office Address:
                                            </label>
                                            <div class="col-md-4">
                                                <input type="text" id="Officeaddress1" name="Officeaddress1" class="form-control" placeholder="Street Address" /><br />
                                                <input type="text" id="Officeaddress2" name="Officeaddress2" class="form-control" placeholder="Suite" />
                                            </div>
                                        </div>
                                        <div class="form-group" id="div_OfcCities">
                                            <label class="col-md-3 control-label" for="val_City">
                                                Office City:
                                            </label>
                                            <div class="col-md-4">
                                                <select id="val_OfcCity" name="val_OfcCity" class="select-chosen form-control" data-placeholder="Choose a office City..." onchange="GetOfficeProvince();">
                                                </select>

                                            </div>
                                        </div>
                                        <div class="form-group" id="div_OfcState" >
                                            <label class="col-md-3 control-label" for="val_State">
                                                Office Province:
                                            </label>
                                            <div class="col-md-4">
                                                <select id="val_OfcState" name="val_State" class="form-control" data-placeholder="Choose a Province..." style="width: 250px;">
                                                </select>
                                            </div>
                                        </div>

                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="TxtWork">
                                                Work:
                                            </label>
                                            <div class="col-md-3">
                                                <input type="text" id="TxtWork" name="TxtWork" placeholder="Work"
                                                    class="form-control" />


                                            </div>
                                            <label class="col-md-2 control-label" for="txtExtension">
                                                Extension:
                                            </label>
                                            <div class="col-md-3">
                                                <input type="text" id="txtExtension" name="txtExtension" placeholder="External"
                                                    class="form-control" />

                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="text-input">
                                                Email<span class="text-danger">*</span></label>
                                            <div class="col-md-4">
                                                <input id="txtEmail" name="txtEmail" class="form-control" placeholder="Home" type="text" /><br />
                                                <input id="txtOfficeEmail" name="txtOfficeEmail" class="form-control" placeholder="Office (Optional)" type="text" />

                                            </div>
                                        </div>
                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="PhoneNumber">
                                                Fax:
                                            </label>
                                            <div class="col-md-4">
                                                <input type="text" id="HomeFax" name="HomeFax" placeholder="Home" class="form-control" /><br /> 
                                                <input type="text" id="OfficeFax" name="OfficeFax" placeholder="Office" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="CustomerPic">
                                                Customer Pic:
                                            </label>
                                            <div class="col-md-4">
                                                <input type="file" name="fileUpload" id="fileUpload" onchange="showimagepreview(this)" />
                                                <a href="" id="imgprev-a" target="_blank">
                                                    <img id="imgprvw" height="50" style="width: 50px; margin: 5px;" alt="" src="" /></a>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="val_MaritalStatus">
                                                Marital Status:
                                            </label>
                                            <div class="col-md-4">

                                                <select id="val_MaritalStatus" name="val_MaritalStatus" class="form-control">
                                                    <option value="-1">Select</option>
                                                    <option value="0">Single</option>
                                                    <option value="1">Married</option>
                                                </select>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="val_Dependent">
                                                Dependent:
                                            </label>
                                            <div class="col-md-4">

                                                <select id="val_Dependent" name="val_Dependent" class="form-control">
                                                    <option value="-1">Select</option>
                                                    <option value="0">Yes</option>
                                                    <option value="1">No</option>
                                                </select>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label" for="val_CallTime">
                                                Best time To call:
                                            </label>
                                            <div class="col-md-4">

                                                <select id="val_CallTime" name="val_CallTime" class="form-control">
                                                    <option value="-1">Select</option>
                                                    <option value="0">AM</option>
                                                    <option value="1">PM</option>
                                                </select>

                                            </div>
                                        </div>
                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="TxtRefferedBy">
                                                Referred By:
                                            </label>
                                            <div class="col-md-4">
                                                <input type="text" id="TxtRefferedBy" name="TxtRefferedBy" placeholder="Work"
                                                    class="form-control" />

                                            </div>
                                        </div>
                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="val_ColdLead">
                                                Cold Lead:
                                            </label>
                                            <div class="col-md-4">
                                                <select id="val_ColdLead" name="val_ColdLead" class="form-control">
                                                    <option value="-1">Select</option>
                                                    <option value="0">Yes</option>
                                                    <option value="1">No</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="datepickerFirstContact">
                                                First Contact:
                                            </label>
                                            <div class="col-md-4">
                                                <input id="datepickerFirstContact" name="datepickerFirstContact"  class="form-control input-datepicker" data-date-format="yyyy/mm/dd" placeholder="yyyy/mm/dd" type="text"/>

                                            </div>
                                        </div>
                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="TxtNextContact">
                                                Next Contact:
                                            </label>
                                            <div class="col-md-4">
                                                <input id="TxtNextContact" name="TxtNextContact" class="form-control input-datepicker" data-date-format="yyyy/mm/dd" placeholder="yyyy/mm/dd"  type="text"/>

                                            </div>
                                        </div>
                                        <div class="form-group showOnlyForUser">
                                            <label class="col-md-3 control-label" for="TxtDiscussed">
                                                Discussed:
                                            </label>
                                            <div class="col-md-4">
                                                <textarea id="TxtDiscussed" cols="20" rows="4" name="TxtDiscussed" class="form-control" placeholder="Discussed"></textarea>


                                            </div>
                                        </div>
                                        <div class="modal-footer" style="text-align: center;">

                                            <button type="button" id="BtnSaveCustomer" class="btn btn-sm btn-primary">
                                                Save</button>
                                            <button type="button" id="BtnEditCustomer" class="btn btn-sm btn-primary"
                                                style="display: none;">
                                                Update</button>
                                            <button type="button" id="btnCancel" class="btn btn-sm btn-default" data-dismiss="modal">
                                                Cancel</button>
                                        </div>

                                    </form>
                                </div>

                                <div id="modal-Upload-Excel" class="modal" tabindex="-1" role="dialog" aria-hidden="true">

                                    <iframe id="frmUploadFile" src="UploadExcelFile.aspx" frameborder="0"
                                        scrolling="no" height="240px" style="width: 100%;"></iframe>
                                </div>

                                <div class="block full" id="div_SeekPermission" style="display: none;">
                                    <div class="block-title" style="color: #F31455;">
                                        <h2 id="headerPermission"></h2>

                                    </div>
                                    <form id="form-SeekPermission" action="" class="form-horizontal form-bordered">
                                        <!-- Datatables Content -->
                                        <div class="form-group" style="text-align: center">
                                            <label class="col-md-5 control-label" for="text-input">
                                                Select an expert whose help is being sought
                                            </label>
                                            <div class="col-md-3">

                                                <select id="val_Experts" name="val_Experts" class="form-control">
                                                </select>

                                            </div>

                                        </div>
                                        <div class="form-group" style="text-align: center">
                                            <label class="col-md-12" for="text-input">
                                                Click on the following button to get authorization for client to share his 
                                      documents/records with selected expert
                                            </label>
                                        </div>
                                        <div class="form-group" style="text-align: center">
                                            <button type="button" id="BtnSeekPermission" class="btn btn-sm btn-primary"
                                                style="text-align: center" onclick="return SendMailToClient();">
                                                Seek Permission</button>
                                            <%--  <button type="button" class="btn btn-sm btn-default" data-dismiss="modal" >
                                                    Cancel</button>--%>
                                        </div>
                                        <div id="div_success" class="form-group" style="text-align: center; display: none;">
                                            <label class="col-md-12" for="text-input" id="lblEmailSuccess">
                                                A mail has been sent to the client for seeking permission to share his 
                                      documents/records with selected expert.
                                            </label>
                                        </div>
                                    </form>



                                </div>



                            </div>

                        </div>

                        </div>
                    </div>

                <div id="div_map" class="block" style="display: none;">
                            <div class="gmap" id="gmap-geolocation"></div>
                        </div>

                 <div id="modal-regular-Profile" class="modal" tabindex="-1" role="dialog" aria-hidden="true" style="display: none;">
                <form action="" method="post" enctype="multipart/form-data" class="form-horizontal "
                    onsubmit="return false;">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="closeprofile">
                                    &times;</button>
                                <h3 id="header_Title" class="modal-title">User Profile
                                </h3>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Name:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_name" for="text-input">
                                    </label>
                                    <div class="form-control-static" id="profilepic" style="float: right; width: 220px; height: 32px; margin-right: 20px; margin-top: 0px;">
                                    </div>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Date Of Birth:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_DOB" for="text-input">
                                    </label>
                                   
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Status:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_Status" for="text-input">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Address:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_address1" for="text-input">
                                    </label>
                                </div>
                            </div>
                            <%--<div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    City:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_City" for="text-input">
                                    </label>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Postal Code:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_PostalCode" for="text-input">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Phone No.:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_Phoneno" for="text-input">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Office Address:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_OfficeAddress" for="text-input">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                   Work:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_Work" for="text-input">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Email address:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_Email" for="text-input">
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="text-input">
                                    Fax:</label>
                                <div class="col-md-8">
                                    <label class="form-control-static" id="p_Fax" for="text-input">
                                    </label>
                                </div>
                            </div>
                         
                        </div>

                    </div>

                </form>
            </div>
                        <!-- END Tab Content -->
                        <HP:UserProfile ID="UserProfile" runat="server" />





</div> <!-- inner-content-wrap End -->
</div><!-- Page Content End -->

    <!-- Footer BOX-->
    <HM:footerControl runat="server" ID="footerControl" />

<!-- END Footer Box --> 
    <!---Comman Footer Scripts Start -->
    <HM:footerScriptControl runat="server" ID="footerScriptControl" />

    <!-- Comman Footer Scripts End--->


    <!-- Delete--->
  </div>


    
           
           
           
            
           
</body>
</html>
 <script src="../js/SJGrid.js"></script>
            <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
            <script src="js/toastr.js"></script>
            <script src="js/vendor/bootstrap.min.js"></script>
            <script src="js/plugins.js"></script>
          <%--  <script src="../js/jquery-ui.js"></script>--%>
            <script src="js/app.js"></script>
            <script src="PagesJs/Customers.js" type="text/javascript"></script>
            <script src="PagesJs/Common.js" type="text/javascript"></script>
            <script src="js/FileReader.js"></script>
            <script src="js/ajaxfileupload.js"></script>
           <%-- <script src="js/jquery.ui.datepicker.js"></script>--%>
            <%--<script src="js/jquery.tooltipster.js"></script>--%>
            <!-- Google Maps API + Gmaps Plugin, must be loaded in the page you would like to use maps (Remove 'http:' if you have SSL) -->
            <script src="https://maps.google.com/maps/api/js?js?v=3.exp&sensor=false"></script>
            <script src="js/helpers/gmaps.min.js"></script>

            <!-- Load and execute javascript code used only in this page -->
            <script src="js/pages/compMaps.js"></script>
            <script>        $(function () { });//CompMaps.init(); });</script>

            <script language="javascript" type="text/javascript">
                var geocoder;
                var map;
                var mvarlat;
                var mvarlong;


                $(function () {

                    $("#datepickerDOB").datepicker({
                        inline: true,
                        showOtherMonths: true,
                        dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                        dateFormat: "dd-M-yyyy",
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

                    $("#datepickerAnniversary").datepicker({
                        inline: true,
                        showOtherMonths: true,
                        dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                        dateFormat: "dd-M-yyyy",
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
                    $("#datepickerFirstContact").datepicker({
                        inline: true,
                        showOtherMonths: true,
                        dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                        dateFormat: "dd-M-yyyy",
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

                function HideUploadModal() {
                    //$('.close').click();
                    //$('#frmUploadFile').hide();
                    //$('#modal-Upload-Excel').hide();
                    // alert("hide");
                    window.location.reload();

                    //  GetCustomersListing();
                }






                function codeAddress(pvarAddress) {

                    $('#div_customers').hide();
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