﻿var mvarUserID = -1;

$(function () {
    
    NProgress.start();
    GetUserDetails();
    FillStateCombo();
    FillOccupationCombo();
    FillCityCombo();
});
//function used to get user details
function GetUserDetails() {
    NProgress.start();
    $.post("UserProfile.aspx",
    {
        Mode: "GETUSERDETAILS"
    },
    function (VarResponseData) {
        $('#div_profile').empty();
        $('#div_profile').append(VarResponseData);
        NProgress.done();

    }); //End of Ajax

    return false;


}
function GetProvince(pvarCityID) {
    pvarCityID = $('#val_City').val();

    $('#div_State').show();

    $.post("UserProfile.aspx",
            {
                Mode: "FILLSTATEOFSELECTEDCITY",
                CityID: pvarCityID
            },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#val_State').empty();
                           var opt = document.getElementById("val_State").options;
                           // opt[opt.length] = new Option('Select', -1);

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
function FillOccupationCombo() {

    $.post("UserProfile.aspx",
            { Mode: "FILLOCCUPATIONCOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#val_Occupation').empty();
                           var opt = document.getElementById("val_Occupation").options;
                           opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('OccupationID').text() != "" && $(this).find('Title').text() != "") {
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('OccupationID').text());
                               }
                           }); // end of Contents

                           $('#val_Occupation').trigger('chosen:updated');
                       }); //end of Response
                   } //END OF if (VarResponseData

               });        //END OF function (VarResponse...


    return false;
}
function FillStateCombo() {
    // NProgress.start();
    $.post("UserProfile.aspx",
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
    varStateID = pvarStateID;

    $.post("UserProfile.aspx",
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
function FillCityCombo() {
    // NProgress.start();
    $.post("UserProfile.aspx",
            { Mode: "FILLCITYCOMBO" },
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
function showEditProfileDiv() {
    $('#divProfileForm').show();
    $('#div_profile').hide();
    $('#profileEditForm').show();
    $.post("UserProfile.aspx",
   {
       Mode: "GETUSERDETAILSFOREDITING"
   },

function (VarResponseData) {
    $(VarResponseData).find('Response').each(function () {
        $(VarResponseData).find('UserData').each(function ()
        {
            

            if ($(this).find('Full_Name').text() != "") {
                $('#val_FullName').val($(this).find('Full_Name').text());
            }

            if ($(this).find('OccupationID').text() != "") {
                $('#val_Occupation').val($(this).find('OccupationID').text());
                $('#val_Occupation').trigger('chosen:updated');
            }

            if ($(this).find('designation').text() != "") {
                $('#val_designation').val($(this).find('designation').text());
                $('#val_designation').trigger('chosen:updated');
            }

            if ($(this).find('OccupationID').text() == "7") {
                $('#div_OtherOccupation').show();
                $('#val_OtherOccupation').val($(this).find('OtherOccupation').text());
            }
            if ($(this).find('ProfileYoutubeURL').text() != "") {
                $('#val_ProfileVideo').val($(this).find('ProfileYoutubeURL').text());
            }

            if ($(this).find('Organization').text() != "") {
                $('#val_Organization').val($(this).find('Organization').text());
            }
            if ($(this).find('Address_line1').text() != "") {
                $('#address1').val($(this).find('Address_line1').text());
            }
            if ($(this).find('Address_Line2').text() != "") {
                $('#address2').val($(this).find('Address_Line2').text());
            }
            if ($(this).find('Address_Line3').text() != "") {
                $('#address3').val($(this).find('Address_Line3').text());
            }
            //if ($(this).find('City').text() != "") {
            //    $('#city').val($(this).find('City').text());
            //}
            if ($(this).find('StateID').text() != "") {
                $('#val_State').val($(this).find('StateID').text());
                $('#val_State').trigger('chosen:updated');
            }
            if ($(this).find('CityID').text() != "") {
                $('#div_cities').show();
                $('#val_City').val($(this).find('CityID').text());
                $('#val_City').trigger('chosen:updated');
            }
            if ($(this).find('DealerName').text() != "") {
                $('#val_DealerName').val($(this).find('DealerName').text());
            }
            if ($(this).find('Mga').text() != "") {
                $('#val_MGA').val($(this).find('Mga').text());
            }
            if ($(this).find('GoverningBody').text() != "") {
                $('#val_GoverningBody').val($(this).find('GoverningBody').text());
            }
            if ($(this).find('InBusinessSince').text() != "") {
                $('#val_BusinessSince').val($(this).find('InBusinessSince').text());
            }
            if ($(this).find('Mobile_Phone').text() != "") {
                $('#PhoneNumber').val($(this).find('Mobile_Phone').text());
            }
            if ($(this).find('AboutMe').text() != "") {
                $('#val_AboutMe').val($(this).find('AboutMe').text());
            }
           
           
            if ($(this).find('Picture').text() != "") {
                $("#imgprev-a").show();
                //$('#fileUpload').val($(this).find('Picture').text());
                $("#imgprev-a").attr("href", "../" + $(this).find('Picture').text());
                $("#imgprvw").attr("src", "../" + $(this).find('Picture').text());
                $("#UserMainPic").attr("href", "../" + $(this).find('Picture').text());
                $("#UserImagEditPage").attr("href", "../" + $(this).find('Picture').text());
                
            }
            else
                $("#imgprvw").attr("src", "../img/AnonymousGuyPic.jpg");

            if ($(this).find('CommunicateConsent').text() == "True") {
                $('#rd_yes').attr('checked', true);
                $('#rd_no').attr('checked', false);

            }
            else if ($(this).find('CommunicateConsent').text() == "False") {
                $('#rd_yes').attr('checked', false);
                $('#rd_no').attr('checked', true);
            }
            else {
                $('#rd_yes').attr('checked', false);
                $('#rd_no').attr('checked', false);
            }

        });
    }); //end of Response
    NProgress.done();
});                //End of Ajax

    return false;
}
var varConsent =0;
function UpdateUserDetails() {
    var val_designation = $('#val_designation').val();
    var val_FullName = $('#val_FullName').val();
    var varProfileVideo = "";
    var varStateID = $('#val_State').val();
    var varCityID = $('#val_City').val();
    var varOccupationID = $('#val_Occupation').val();
    var varAddress1 = $('#address1').val();
    var varOrganisation = $('#val_Organization').val();
    var varAboutMe = $('#val_AboutMe').val();
    var varPhoneNumber = $('#PhoneNumber').val();
  //  var regExp = /.*(?:youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=)([^#\&\?]*).*/;
 //  var match = url.match(regExp);
    varConsent = ($('input[name=consent]:checked').val() == "Yes" ? 1 : 0);

    varProfileVideo = $('#val_ProfileVideo').val();
    var pattern = /^\d{10}$/;
    if(val_FullName == ""){
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> Please enter your Name </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    }
    else if (varOccupationID == "-1") {
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> Please select your Occupation </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    }

    else if (val_designation == "") {
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> Please enter Designation </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    }
    else if (varOrganisation == "") {
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> Please enter Organisation </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
   }
    else if (varAddress1 == "") {
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> Please enter Address . </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    }
    


    else if (varCityID == "-1") {
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> Please select a city to save details. </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);

        return false;
    }
    else if (varStateID == "-1") {
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> Please select a state to save details. </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);

        return false;
    }
    else if (varPhoneNumber == "") {
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> Please enter Phone Number. </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    }

    
    else if (!pattern.test(varPhoneNumber)) {
        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> It is not valid Phone number.input 10 digits number!. </div>";
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    }

   else if ($('#fileUpload').val() != "") {
       UploadProfilePic();
   }
  

    else {
       $.post("UserProfile.aspx",
                      {
                          Mode: "UPDATEUSERDETAILS",
                          Full_Name: $('#val_FullName').val(),
                          OccupationID: $('#val_Occupation').val(),
                          Designation: $('#val_designation').val(),
                          OtherOccupation: $('#val_OtherOccupation').val(),
                          Organization: $('#val_Organization').val(),
                          Address_line1: $('#address1').val(),
                          Address_Line2: $('#address2').val(),
                          Address_Line3: $('#address3').val(),
                          StateID: $('#val_State').val(),
                          CityID: $('#val_City').val(),
                          DealerName: $('#val_DealerName').val(),
                          Mga: $('#val_MGA').val(),
                          GoverningBody: $('#val_GoverningBody').val(),
                          InBusinessSince: $('#val_BusinessSince').val(),
                          Mobile_Phone: $('#PhoneNumber').val(),
                          Images: '',
                          CommunicateConsent: varConsent,
                          ProfileYoutubeURL: varProfileVideo,
                          AboutMe: varAboutMe
                      },
                          function (VarResponseData) {

                              if (VarResponseData == "SUCCESS") {
                                  
                                  
                                  document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> User Details Updated successfully. </div>";
                                  $("html, body").animate({scrollTop: 0}, 700);
                                  GetUserDetails();
                                  $('#divProfileForm').hide();
                                  $('#div_profile').show();
                                  $('#profileEditForm').hide();
                                 window.location.href = 'Profile.aspx';
                                  NProgress.done();
                              }

                          });


   }

    return false;
}
function user_set() {
  
    $('<%=txt_u.clientid %>').val('22');
    alert($('#val_occupation').val());

}
function ResetForm() {
    $('#divProfileForm').hide();
    $('#div_profile').show();
    $('#profileEditForm').hide();
    GetUserDetails();
}
function UploadProfilePic() {

    varProfileVideo = $('#val_ProfileVideo').val();
       
  
    if ($('#fileUpload').val() != '') {

        var varImgFileExtn = $('#fileUpload').val().substr($('#fileUpload').val().lastIndexOf("."), $('#fileUpload').val().length);

        if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
            alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 1');
            return false;
        }
    }
 
   
    $.ajaxFileUpload({
        url: 'dev/UploadProfilePics.ashx?Mode=UPLOADPROFILEPICS',
        secureuri: false,
        fileElementId: 'fileUpload',
        dataType: 'text',
        data: { name: 'logan', id: 'id' },
        success: function (data, status) {

            data = data.replace("<pre>", "").replace("<PRE>", "")
            data = data.replace("</pre>", "").replace("</PRE>", "")
            if (data.indexOf("SUCCESS") != -1)
            {
                varConsent2 = ($('input[name=consent]:checked').val() == "Yes" ? 1 : 0);
                var Varabm = $('#val_AboutMe').val();
                $.post("UserProfile.aspx",
                       {
                           Mode: "UPDATEUSERDETAILS",
                           Full_Name: $('#val_FullName').val(),
                           OccupationID: $('#val_Occupation').val(),
                           OtherOccupation: $('#val_OtherOccupation').val(),
                           Organization: $('#val_Organization').val(),
                           Address_line1: $('#address1').val(),
                           Address_Line2: $('#address2').val(),
                           Address_Line3: $('#address3').val(),
                           StateID: $('#val_State').val(),
                           CityID: $('#val_City').val(),
                           DealerName: $('#val_DealerName').val(),
                           Mga: $('#val_MGA').val(),
                           GoverningBody: $('#val_GoverningBody').val(),
                           InBusinessSince: $('#val_BusinessSince').val(),
                           Mobile_Phone: $('#PhoneNumber').val(),
                           Images: data.split("##")[1],
                           CommunicateConsent: varConsent2,
                           ProfileYoutubeURL: $('#val_ProfileVideo').val(),
                           AboutMe: Varabm
                       },
                           function (VarResponseData) {

                               if (VarResponseData == "SUCCESS") {


                                   document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Warning!</strong> User Details Updated successfully. </div>";
                                   $("html, body").animate({ scrollTop: 0 }, 700);
                                   GetUserDetails();
                                   $('#divProfileForm').hide();
                                   $('#div_profile').show();
                                   $('#profileEditForm').hide();
                                   window.location.href = 'Profile.aspx';
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

function profilePicUpd() {

    


    if ($('#fileUploadUpd').val() != '') {

        var varImgFileExtn = $('#fileUploadUpd').val().substr($('#fileUploadUpd').val().lastIndexOf("."), $('#fileUploadUpd').val().length);

        if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
            alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 1');
            return false;
        }
    }


    $.ajaxFileUpload({
        url: 'dev/UploadProfilePics.ashx?Mode=UPLOADPROFILEPICSUPD',
        secureuri: false,
        fileElementId: 'fileUploadUpd',
        dataType: 'text',
        data: { name: 'logan', id: 'id' },
        success: function (data, status) {

            data = data.replace("<pre>", "").replace("<PRE>", "")
            data = data.replace("</pre>", "").replace("</PRE>", "")
            if (data.indexOf("SUCCESS") != -1) {
                $.post("UserProfile.aspx",
                       {
                           Mode: "UPDATEUSERPROPIC",
                           Images: data.split("##")[1]
                       },
                           function (VarResponseData) {
                               if (VarResponseData == "SUCCESS") {
                                   document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-success'></i> Success!</strong> User profile picture updated ! </div>";
                                   $("html, body").animate({ scrollTop: 0 }, 700);
                                   GetUserDetails();
                                   window.location.href = 'Profile.aspx';
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


