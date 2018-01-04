<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="User_pro" %>

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
    <link rel="stylesheet" type="text/css" href="../E2Forums-New/css/cropper/cropper.min.css" />
    <!--  EOF CSS INCLUDE -->
    <!-- CSS INCLUDE -->
    <link rel="stylesheet" type="text/css" id="theme" href="../E2Forums-New/css/theme-default.css" />
    <link rel="stylesheet" type="text/css" id="Link1" href="../E2Forums-New/css/custom.css" />
    <link rel="stylesheet" type="text/css" id="Link2" href="css/plugins.css" />
    <!-- EOF CSS INCLUDE -->
</head>
<body>

    <!-- START PAGE CONTAINER -->
    <div class="page-container page-navigation-top-fixed">


        <!-- Top Menu Control Start  -->
        <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />

        <!-- Top Menu Control End  -->

        <!-- PAGE CONTENT -->
        <div class="page-content">
            <!-- Side Menu Control Start  -->
            <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />
            <!-- side Menu Control End  -->

            <div class="page-content-wrap">
                <div class="inner-content-wrap">
                    <div class="page-title">
                        <h2><span class="fa fa-cogs"></span>Edit Profile</h2>
                    </div>
                    <div id="validation-msg-container"></div>

                    <div class="col-md-3 col-sm-4 col-xs-12">
                        <div class="col-md-12 col-xs-12">
                            <div class="panel panel-default">
                                <div class="panel-body">

                                    <a href="javascript:void(0)" class="edit-profile-image-done" id="edit-profile-image-done" style="display: none;"><i class="fa fa-times fa-2"></i>Cancel</a>
                                    <h3><span class="fa fa-user"></span>
                                        <span id="UserNameHead"></span></h3>

                                    <div id="user_image22" class="text-center user_image">
                                        <img id="UserImagEditPage22" class="img-thumbnail" src="img/default_profile_pic.jpg" onerror="this.onerror=null;this.src='../E2Forums-New/img/default_profile_pic.jpg';">
                                        <div class="hoverOverlay">
                                            <a href="javascript:void(0)" title="Edit Profile Picture" class="edit-profile-image" id="edit-profile-image"><i class="fa fa-folder-open-o"></i>Edit Profile Picture</a>
                                        </div>
                                    </div>


                                    <div id="edit-profile-image-target" style="display: none;">
                                        <div class="row">
                                            <div class="form-group">

                                                <label class="col-md-12 control-label" for="ProfilePic">
                                                    Profile Pic:
                                                </label>
                                                <div class="col-md-12">

                                                    <input type="file" name="fileUploadUpd" class="fileinput btn-primary" id="fileUploadUpd" onchange="showimagepreview(this)" />
                                                    <input type="submit" value="Update" onclick="return profilePicUpd();" class="btn btn-info" />

                                                    <a href="" id="imgprev-a" target="_blank" style="display: none;">
                                                        <img id="imgprvw" height="50" style="width: 50px; margin: 5px;" alt="" src="" />
                                                    </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-body form-group-separated">


                                    <div class="form-group">

                                        <label class="col-md-3 col-xs-5 control-label">Email</label>
                                        <div class="col-md-9 col-xs-7"><span id="UserEmail_desk"></span></div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="lbl_msg_success" runat="server" Text=""></asp:Label>
                            <asp:Panel ID="Panel_passupd" runat="server">

                                <form id="Form1" runat="server">
                                    <fieldset>
                                        <legend><span class="fa fa-key" aria-hidden="true"></span>Update Password</legend>


                                        <div class="row-form">

                                            <div class="span6">
                                                <div class="span3">New Password<span class="astrik">*</span></div>
                                                <div class="span9">
                                                    <div class="field-wrapper">
                                                        <i class="fa fa-key"></i>
                                                        <asp:TextBox ID="txt_newpswd" runat="server" CssClass="text_box"
                                                            TextMode="Password"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="txt_newpswd" ErrorMessage="Please Enter New Password!"
                                                        ForeColor="Red" ValidationGroup="v1">*</asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-form">

                                            <div class="span6">
                                                <div class="span3">Confirm Password<span class="astrik">*</span></div>
                                                <div class="span9">
                                                    <div class="field-wrapper">
                                                        <i class="fa fa-key"></i>
                                                        <asp:TextBox ID="txt_confirmpswd" runat="server" CssClass="text_box"
                                                            TextMode="Password"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ControlToValidate="txt_confirmpswd" ErrorMessage="Please Enter Confirm Password!"
                                                        ForeColor="Red" ValidationGroup="v1">*</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="comparePasswords"
                                                        runat="server"
                                                        ControlToCompare="txt_newpswd"
                                                        ControlToValidate="txt_confirmpswd"
                                                        ErrorMessage="Your confirm passwords not matched!"
                                                        Display="Dynamic" ValidationGroup="v1">*</asp:CompareValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="span6">
                                            <asp:Button ID="Button1" runat="server" CssClass="btn vali fl"
                                                Text="Change Password" ValidationGroup="v1" OnClick="btn_changePswd_Click" />
                                            <input type="reset" value="Clear All" class="btn reset float-l" />

                                        </div>

                                        <div class="span6">
                                            <div class="span3">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="v1" />
                                            </div>
                                        </div>

                                    </fieldset>
                                </form>
                            </asp:Panel>
                        </div>
                    </div>


                    <div class="col-md-8 col-xs-12">



                        <!-- Newsfeed Block -->
                        <div class="panel-body show-profile" id="div_profile">
                        </div>
                        <!-- END Newsfeed Content -->
                        <div class="block" style="display: none;" id="profileEditForm">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="block-options pull-right"><a data-original-title="Back to Profile" title="" data-toggle="tooltip" class="btn btn-sm btn-alt btn-default" id="backToViewForm" href=""><i class="fa fa-arrow-left"></i></a></div>
                                    <h3><span class="fa fa-pencil"></span>Edit Profile</h3>
                                </div>
                                <div class="panel-body form-group-separated">

                                    <form id="form-validation" action="" class="form-horizontal form-bordered">

                                        <!-- First Step -->
                                        <div id="first" class="step">
                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_firstname">
                                                    Name <span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">
                                                    <input type="text" id="val_FullName" name="val_FullName" class="form-control" placeholder="First Name">
                                                </div>
                                            </div>


                                            <div class="form-group ">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_Occupation">
                                                    Occupation <span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">
                                                    <select id="val_Occupation" name="val_Occupation" class="select-chosen form-control" style="width: 250px;" onchange="return SelectOtherOccupation();">
                                                    </select>

                                                </div>
                                            </div>

                                            <div class="form-group" id="div_OtherOccupation" style="display: none;">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_Occupation">
                                                    Other Occupation <span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">

                                                    <input type="text" id="val_OtherOccupation" name="val_OtherOccupation" class="form-control" placeholder="Other Occupation" />


                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_Organization">
                                                    Designation<span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">
                                                    <input type="text" id="val_designation" name="val_designation" class="form-control" placeholder="Designation Name" />
                                                </div>
                                            </div>
                                        </div>
                                        <!-- END First Step -->
                                        <!-- Second Step -->
                                        <div id="second" class="step">
                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_Organization">
                                                    Organization<span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">
                                                    <input type="text" id="val_Organization" name="val_Organization" class="form-control" placeholder="Organization Name">
                                                </div>
                                            </div>
                                            <div class="form-group" id="div_ProfileVideo">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_ProfileVideo">
                                                    Video URL<span class="text-danger"></span>
                                                </label>
                                                <div class="col-md-6">

                                                    <input type="text" id="val_ProfileVideo" name="val_ProfileVideo" class="form-control" placeholder="Enter Valid URL..." />

                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_Address">
                                                    Address<span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">
                                                    <input type="text" id="address1" name="address1" class="form-control" placeholder="Street address 1"><br />
                                                    <input type="text" id="address2" name="address2" class="form-control" placeholder="Street address 2"><br />
                                                    <input type="text" id="address3" name="address3" class="form-control" placeholder="Street address 3">
                                                </div>
                                            </div>
                                            <div class="form-group" id="div_cities">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_City">
                                                    City <span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">
                                                    <select id="val_City" name="val_City" class="select-chosen form-control" data-placeholder="Choose a City..." style="width: 250px;" onchange="return GetProvince(this);">
                                                    </select>

                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_State">
                                                    Province <span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">
                                                    <select id="val_State" name="val_State" class="select-chosen form-control" data-placeholder="Choose a City..." style="width: 250px;">
                                                    </select>

                                                </div>
                                            </div>


                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_ Dealer">
                                                    Dealer Name
                                                </label>
                                                <div class="col-md-6">
                                                    <input type="text" id="val_DealerName" name="val_DealerName" class="form-control" placeholder="Dealer Name">
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_Address">
                                                    MGA
                                                </label>
                                                <div class="col-md-6">
                                                    <input type="text" id="val_MGA" name="val_MGA" class="form-control" placeholder="MGA">
                                                </div>
                                            </div>



                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_Address">
                                                    Governing Body
                                                </label>
                                                <div class="col-md-6">
                                                    <input type="text" id="val_GoverningBody" name="val_GoverningBody" class="form-control" placeholder="Governing Body">
                                                </div>
                                            </div>


                                            <div class="form-group">
                                                <label class="col-md-3 col-xs-5 control-label" for="val_Address">
                                                    In Business Since<span class="text-danger">*</span>
                                                </label>
                                                <div class="col-md-6">
                                                    <input type="text" id="val_BusinessSince" name="val_BusinessSince" class="form-control" placeholder="Business">
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-5 control-label" for="PhoneNumber">
                                                Phone Number 
                                            </label>
                                            <div class="col-md-6">
                                                <input type="text" id="PhoneNumber" name="PhoneNumber" placeholder="(999) 999-9999"
                                                    class="form-control">
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-5 control-label" for="val_AboutMe">
                                                About Me
                                            </label>
                                            <div class="col-md-6">

                                                <textarea style="resize: none" rows="4" cols="50" id="val_AboutMe" name="val_AboutMe" class="form-control"></textarea>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-5 control-label" for="ProfilePic">
                                                Profile Pic:
                                            </label>
                                            <div class="col-md-6">
                                                <input type="file" name="fileUpload" class="fileinput btn-primary" id="fileUpload" onchange="showimagepreview(this)" />
                                                <a href="" id="imgprev-a" target="_blank" style="display: none;">
                                                    <img id="imgprvw" height="50" style="width: 50px; margin: 5px;" alt="" src="" /></a>
                                            </div>
                                        </div>



                                        <div class="form-group">
                                            <label class="col-md-3 col-xs-5 control-label"></label>
                                            <div class="col-md-9 col-xs-7">
                                                As per Canada's  Anti-spam legislation Do you give us your consent to communicate : 
                        <span>
                            <input id="Radio3" type="radio" value="Yes" name="consent" class="radioconsent icheckbox">
                            Yes &nbsp; 
                                      <input id="Radio4" type="radio" value="No" name="consent" class="radioconsent icheckbox">
                            No </span>



                                            </div>
                                        </div>





                                        <div class="form-group">
                                            <div class="col-md-12 col-md-offset-4">
                                                <button type="button" id="btn-signup" class="btn btn-sm btn-primary" onclick="return UpdateUserDetails();">Update</button>

                                                <a href="#">
                                                    <button type="button" class="btn btn-sm btn-default" onclick="return ResetForm();">Cancel </button>
                                                </a>
                                            </div>
                                        </div>


                                    </form>

                                </div>
                            </div>
                        </div>
                        <!-- END Newsfeed Block -->


                    </div>

                </div>
            </div>





        </div>
        <!-- Page Container End -->

        <!-- Footer BOX-->
        <HM:footerControl runat="server" ID="footerControl" />

        <!-- END Footer Box -->
        <!---Comman Footer Scripts Start -->
        <HM:footerScriptControl runat="server" ID="footerScriptControl" />

        <!-- Comman Footer Scripts End--->


        <!-- Delete--->
    </div>





    <script src="../js/SJGrid.js"></script>

    <script src="js/toastr.js"></script>

    <script src="js/plugins.js"></script>

    <script src="js/FileReader.js"></script>
    <script src="dev/Profile.js" type="text/javascript"></script>
    <script src="js/ajaxfileupload.js"></script>
    <script lang="javascript" type="text/javascript">
        $("#edit-profile-image").click(function () {
            $(".user_image").fadeOut();
            $("#edit-profile-image").hide();
            $("#edit-profile-image-done").show();
            $("#edit-profile-image-target").fadeIn();
        });

        $("#edit-profile-image-done").click(function () {
            $(".user_image").fadeIn();
            $("#edit-profile-image").show();
            $("#edit-profile-image-done").hide();
            $("#edit-profile-image-target").fadeOut();
        });
        $(function () {

            NProgress.start();

            console.log("1");

            $.post("UserProfile.aspx",
            {
                Mode: "GETUSERDET"

            },
          function (VarResponseData) {

              //alert(VarResponseData);


              //console.log("hello1234");
              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('AdminData').each(function () {
                      console.log("hello");
                      console.log($(this).find('Full_Name').text());
                      if ($(this).find('Full_Name').text() != "") {
                          $('#UserNameHead').html($(this).find('Full_Name').text());
                          $('#UserNameHead').attr('readonly', 'readonly');
                      }

                      if ($(this).find('Picture').text() != "")
                          $("#UserImagEditPage22").attr("src", $(this).find('Picture').text());
                      else
                          $("#UserImagEditPage22").attr("src", "../img/AnonymousGuyPic.jpg");

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
