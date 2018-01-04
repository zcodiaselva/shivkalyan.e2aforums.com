<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDocuments.aspx.cs" Inherits="User_pro" %>

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

          
                <!-- Forum Block -->
                <div class="block">
                    <!-- Tab Content -->
                    <div class="tab-content">
                        <!-- Forum -->
                        <div class="block-title">
                            <h2 id="headerMainTitle" class="modal-title" style="color: #F31455;"></h2>
                            <a data-toggle="modal" href="#modal-Add-CustomerDocs">
                                <button type="button" id="btnAddDocuments" class="btn btn-sm btn-primary" style="float: right; margin-right: 15px; margin-top: 5px;"
                                    onclick="return ResetForm();">
                                    ADD</button></a>
                            <br />
                            <h4 id="h4_Title" class="modal-title" style="color: #F31455; text-align: center; font-weight: 800;margin-left: 40%;"></h4>
                       </div>
                        <!-- Datatables Content -->
                        <div style="width: 100%; min-height: 80%; margin-left: 2%; float: left;">
                            
                            <iframe id="obj_model" src="" style="width: 95%; height: 600px; margin: 10px auto;display:none;">
                                <a id="file_a" href=""></a>
                            </iframe>
                             
                            <%--<img alt="" src="..//CustomerDocs//Hydrangeas1502181650.jpg" />--%>
                            <%-- <a href="..//CustomerDocs//Hydrangeas1502181650.pdf"></a>--%>
                            <%--  <a href="..//CustomerDocs//template1502181616.pdf"></a>--%>
                        </div>
                     <button id="btnPrev" type="button" class="btn btn-success btn-primary" onclick="return prevRecord()" style="margin-left: 40%;display:none;"><i class="fa fa-arrow-left"></i>prev</button>

                        <button id="btnNext" type="button" class="btn btn-success btn-primary" onclick="return nextRecord()" style="display:none;">next <i class="fa fa-arrow-right"></i></button>

                        <div id="modal-Add-CustomerDocs" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
                            <form id="form_CustomerDocs" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered" onsubmit="return false;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h3 id="headerTitle2" class="modal-title" style="color: #F31455;">Add Documents
                                            </h3>
                                        </div>
                                        <fieldset>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label" for="text-input">
                                                    Title:</label>
                                                <div class="col-md-8">
                                                    <input id="txtName" name="txtName" class="form-control" placeholder="Title" type="text" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Document:
                                                </label>
                                                <div class="col-md-6">
                                                    <div class="input-group">
                                                        <input type="file" id="FileUpload" name="FileUpload" />
                                                        <label class="col-md-12" id="lblFileName">
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>

                                        <div class="modal-footer">

                                            <button type="button" id="BtnUpload" class="btn btn-sm btn-primary">
                                                Save</button>

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

    <script language="javascript" type="text/javascript">

        var mvarCustomerID = -1;
        var globalRecordCounter = 0;
        $(document).ready(function () {

            $('#Customers-a').addClass("active");
            mvarCustomerID = '<%=CustomerID%>';
            GetUserName();
            GetCustomerFiles();
            $('#BtnUpload').click(function () {

                UploadFileForCustomer();
                //alert('provide email and password to conitnue..');
                return false;

            });

        });

        function GetUserName() {

            $.post("Ajax/AjaxCustomers.aspx",
            {
                Mode: "GETCUSTOMERNAME",
                CustomerID: mvarCustomerID

            },
          function (VarResponseData) {

              $('#headerMainTitle').html("" + VarResponseData + "'s" + "  " + "Documents");

          });                  //End of Ajax

            return false;
        }

        function UploadFileForCustomer() {
            var varTitle = $('#txtName').val();
            if (varTitle == "") {
                toastr["error"]("Please enter title.");
                return false;
            }
            $.ajaxFileUpload({
                url: 'Ajax/UploadProfilePics.ashx?Mode=UPLOADCUSTOMERDOCUMENTS',
                secureuri: false,
                fileElementId: 'FileUpload',
                dataType: 'text',
                data: { name: 'logan', id: 'id' },
                success: function (data, status) {

                    data = data.replace("<pre>", "").replace("<PRE>", "")
                    data = data.replace("</pre>", "").replace("</PRE>", "")
                    if (data.indexOf("SUCCESS") != -1) {

                        $.post("Ajax/AjaxCustomers.aspx",
                        {
                            Mode: "SAVECUSTOMERDOCUMENTS",
                            Title: varTitle,
                            File: data.split("##")[1],
                            CustomerID: mvarCustomerID

                        },
                            function (VarResponseData) {
                                if (VarResponseData == "SUCCESS") {

                                    toastr.options = { "onHidden": function () { $('.close').click(); GetCustomerFiles(); } };
                                    // $('.close').click();
                                    toastr["success"]("Document added successfully");
                                    //  GetCustomerFiles();
                                    NProgress.done();
                                }

                            });


                    }




                },
                error: function (data, status, e) {
                    alert(e);
                    NProgress.done();

                }
            }
             );

            return false;
        }

        var globalCustomerData = new Array();

        function GetCustomerFiles() {

            $("#btnNext").removeAttr("disabled", "disabled");
            $("#btnPrev").attr("disabled", "disabled");

            $.post("Ajax/AjaxCustomers.aspx",
           {
               Mode: "GETCUSTOMERFILES",
               CustomerID: mvarCustomerID

           },
         function (varResponseData) {

             //alert(varResponseData);

             if (varResponseData != "") {

                 $(varResponseData).find('Response').each(function () {

                     $(varResponseData).find('GetFiles').each(function () {

                         $(varResponseData).find('Contents').each(function () {

                             var title = "";
                             var customerDocs = "";

                             if ($(this).find('Title').text() != "" && $(this).find('Title').text() != "") {
                                 title = $(this).find('Title').text();
                             }

                             if ($(this).find('CustomerDocs').text() != "" && $(this).find('CustomerDocs').text() != "") {

                                 customerDocs = $(this).find('CustomerDocs').text();
                             }

                             var obj = { "Title": title, "CustomerDocs": customerDocs }

                             globalCustomerData.push(obj);

                         }); // end of Contents
                         //$('#val_Occupation').trigger('chosen:updated');

                         //console.log(globalCustomerData[0].Title);
                         globalRecordCounter = globalCustomerData.length - 1;
                         if (globalCustomerData.length > 0) {

                             $("#h4_Title").html(globalCustomerData[0].Title);
                             $("#btnPrev").show();
                             $("#btnNext").show();
                             $("#obj_model").show();
                             $("#obj_model").attr("src", globalCustomerData[0].CustomerDocs);
                             $("#file_a").attr("href", globalCustomerData[0].CustomerDocs);
                         }
                         else {
                             $("#h4_Title").html("No Record Found");
                             $("#obj_model").hide();
                             $("#btnPrev").hide();
                             $("#btnPrev").hide();
                             $("#btnNext").hide();
                         }

                     });
                 }); //end of Response
             } //END OF if (VarResponseData             

         }); //end of Response   
        }

        var recordNo = 0;

        function nextRecord() {



            if (recordNo < globalRecordCounter) {

                $("#btnPrev").removeAttr("disabled", "disabled");

                recordNo++;

                $("#h4_Title").html(globalCustomerData[recordNo].Title);
                $("#obj_model").attr("src", globalCustomerData[recordNo].CustomerDocs);
                $("#file_a").attr("href", globalCustomerData[recordNo].CustomerDocs);



                if ((recordNo + 1) == globalRecordCounter) {
                    $("#btnNext").attr("disabled", "disabled");
                }
            }

        }

        function prevRecord() {


            if (recordNo > 0) {

                $("#btnNext").removeAttr("disabled", "disabled");

                recordNo--;

                $("#h4_Title").html(globalCustomerData[recordNo].Title);
                $("#obj_model").attr("src", globalCustomerData[recordNo].CustomerDocs);
                $("#file_a").attr("href", globalCustomerData[recordNo].CustomerDocs);



                if (recordNo == 0) {
                    $("#btnPrev").attr("disabled", "disabled");
                }

            }

        }

        function ResetForm() {
            $('.form-group').removeClass('has-success has-error');
            $('.help-block').remove();
            $('.error').hide();
            document.forms["form_CustomerDocs"].reset();
            $('#headerTitle').html("Add Document");
        }
    </script>
</body>
</html>
