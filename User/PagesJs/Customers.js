var mvarCustomerID = -1;
var mvarMode = "";
$(document).ready(function () {
    $('#Customers-a').addClass("active");


    //  FillOfcCityCombo();
    GetCustomersListing();
    GetUserName();
    FillStatusCombo();
    //$('#btn_close').click(function () {

    //    HideModal();
    //    return false;

    //});
    $('#BtnSaveCustomer').click(function () {

        SaveCustomerDetails();


        //alert('provide email and password to conitnue..');
        return false;

    });

    $('#BtnEditCustomer').click(function () {

        SaveCustomerDetails();


        //alert('provide email and password to conitnue..');
        return false;

    });
    $('#btnCancel').click(function () {
        GetCustomersListing();
        GetUserName();

        $('#btnAddCategory').show();
        $('#div_AddClient').hide();
        $('#div_customerList').show();

    });
});

function GetMode(pvarMode, pvarCustomerID) {
   
    mvarMode = pvarMode;
    mvarCustomerID = pvarCustomerID;

    if (mvarMode == "Add")
        ResetForm();

    FillCityCombo();

}

function GetCities(pvarStateID) {
    pvarStateID = $('#val_State').val();

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

function GetProvince() {

    var pvarCityID = $('#val_City').val();

    $('#div_State').show();

    $.post("Ajax/AjaxUser.aspx",
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


}

function FillCityCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "FILLCITYCOMBO"
            },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#val_City').empty();
                           $('#val_OfcCity').empty();

                           var optionHtml = "<option value=\"\"></option>";

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('CityID').text() != "" && $(this).find('Title').text() != "") {
                                   var val = $(this).find('CityID').text();
                                   var text = $(this).find('Title').text();

                                   //console.log(val);
                                   //console.log(text);

                                   optionHtml += "<option value=\"" + val + "\">" + text.trim() + "</option>";

                               }
                           }); // end of Contents


                           //alert(optionHtml);
                           //console.log(optionHtml);

                           $('#val_City').append(optionHtml);
                           $('#val_City').trigger('chosen:updated');

                           $('#val_OfcCity').append(optionHtml);
                           $('#val_OfcCity').trigger('chosen:updated');
                           FillStateCombo();

                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


}

function FillStateCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            { Mode: "FILLSTATECOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#val_State').empty();
                           $('#val_OfcState').empty();

                           var optionHtml = "<option value='-1'>Select</option>";

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('StateID').text() != "" && $(this).find('Title').text() != "") {
                                   var val = $(this).find('StateID').text();
                                   var text = $(this).find('Title').text();

                                   //console.log(val);
                                   //console.log(text);

                                   optionHtml += "<option value=\"" + val + "\">" + text.trim() + "</option>";
                               }
                           }); // end of Contents


                           //alert(optionHtml);
                           //console.log(optionHtml);

                           $('#val_State').append(optionHtml);
                           $('#val_State').trigger('chosen:updated');

                           $('#val_OfcState').append(optionHtml);
                           $('#val_OfcState').trigger('chosen:updated');


                       }); //end of Response
                   } //END OF if (VarResponseData

                   if (mvarMode == "Edit")
                      
                       showEditCustomerModel();

               });        //END OF function (VarResponse...


    return false;
}


function FillStatusCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            { Mode: "FILLSTATUSCOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#val_Status').empty();
                           var opt = document.getElementById("val_Status").options;
                           opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('StatusID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('StatusID').text());
                               }
                           }); // end of Contents

                           $('#val_Status').trigger('chosen:updated');


                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}

function GetOfficeProvince() {
    //alert("hello2");
    var pvarOfcCityID = $('#val_OfcCity').val();

    $('#div_OfcState').show();

    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "FILLSTATEOFSELECTEDCITY",
                CityID: pvarOfcCityID
            },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#val_OfcState').empty();
                           var opt = document.getElementById("val_OfcState").options;
                           // opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('StateID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('StateID').text());
                               }
                           }); // end of Contents

                           $('#val_OfcState').trigger('chosen:updated');


                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}



function showEditCustomerModel() {

    // FillCityCombo();
    // FillStateCombo();    
    // FillOfcStateCombo();
    //   mvarCustomerID = pvarCustomerID;

    $('#headerMainTitle').html("Edit Clients/Prospects");
    $('#BtnSaveCustomer').hide();
    $('#BtnEditCustomer').show();
    $('#btnAddCategory').hide();
    $('#div_AddClient').show();
    $('#div_customerList').hide();

    //  $('#btn_addClose').click();
    $.post("Ajax/AjaxCustomers.aspx",
            {
                Mode: "GETCUSTOMERDETAILS",
                CustomerID: mvarCustomerID
            },

          function (VarResponseData) {

              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('CustomerData').each(function () {

                      if ($(this).find('Title').text() != "") {
                          $('#txtTitle').val($(this).find('Title').text());
                      }
                      if ($(this).find('Full_Name').text() != "") {
                          var FullNameArray = $(this).find('Full_Name').text().split(' ');
                          var Firstname = FullNameArray[0];
                          var LastName = FullNameArray[1];
                          $('#txtFirstName').val(Firstname);
                          $('#txtLastName').val(LastName);
                      }
                      if ($(this).find('DateOfBirth').text() != "") {
                          $('#datepickerDOB').val($(this).find('DateOfBirth').text());
                      }
                      if ($(this).find('Anniversary').text() != "") {
                          $('#datepickerAnniversary').val($(this).find('Anniversary').text());
                      }
                      if ($(this).find('StatusID').text() != "") {

                          $('#val_Status').val($(this).find('StatusID').text());
                          $('#val_Status').trigger('chosen:updated');
                      }
                      if ($(this).find('Address_line1').text() != "") {
                          $('#address1').val($(this).find('Address_line1').text());
                      }
                      if ($(this).find('Address_Line2').text() != "") {
                          $('#address2').val($(this).find('Address_Line2').text());
                      }
                      if ($(this).find('CityID').text() != "") {
                          console.log($(this).find('CityID').text());
                          $('#val_City').val($(this).find('CityID').text());
                          $('#val_City').trigger('chosen:updated');
                      }
                      if ($(this).find('ProvinceID').text() != "") {
                          console.log($(this).find('ProvinceID').text());
                          $('#val_State').val($(this).find('ProvinceID').text());
                          $('#val_State').trigger('chosen:updated');
                          $('#div_State').show();
                      }
                      if ($(this).find('PostalCode').text() != "") {
                          $('#PostalCode').val($(this).find('PostalCode').text());
                      }
                      if ($(this).find('Mobile_Phone').text() != "") {
                          $('#PhoneNumber').val($(this).find('Mobile_Phone').text());
                      }
                      if ($(this).find('Mobile').text() != "") {
                          $('#Mobile').val($(this).find('Mobile').text());
                      }
                      if ($(this).find('Telephone').text() != "") {
                          $('#txtTelephone').val($(this).find('Telephone').text());
                      }
                      if ($(this).find('OfficeAddress1').text() != "") {
                          $('#Officeaddress1').val($(this).find('OfficeAddress1').text());
                      }
                      if ($(this).find('OfficeAddress2').text() != "") {
                          $('#Officeaddress2').val($(this).find('OfficeAddress2').text());
                      }
                      if ($(this).find('OfficeCityID').text() != "") {
                          if ($(this).find('OfficeCityID').text() != "-1") {
                              console.log($(this).find('OfficeCityID').text());
                              $('#val_OfcCity').val($(this).find('OfficeCityID').text());
                              $('#val_OfcCity').trigger('chosen:updated');
                          }

                      }
                      if ($(this).find('OfficeStateID').text() != "") {
                          console.log($(this).find('OfficeStateID').text());
                          $('#val_OfcState').val($(this).find('OfficeStateID').text());
                          $('#val_OfcState').trigger('chosen:updated');
                          $('#div_OfcState').show();
                      }
                      if ($(this).find('Work').text() != "") {
                          $('#TxtWork').val($(this).find('Work').text());
                      }

                      if ($(this).find('ExtensionField').text() != "") {
                          $('#txtExtension').val($(this).find('ExtensionField').text());
                      }
                      if ($(this).find('Email').text() != "") {
                          $('#txtEmail').val($(this).find('Email').text());
                      }
                      if ($(this).find('OfficialEmailID').text() != "") {
                          $('#txtOfficeEmail').val($(this).find('OfficialEmailID').text());
                      }
                      if ($(this).find('HomeFax').text() != "") {
                          $('#HomeFax').val($(this).find('HomeFax').text());
                      }
                      if ($(this).find('OfficeFax').text() != "") {
                          $('#OfficeFax').val($(this).find('OfficeFax').text());
                      }

                      if ($(this).find('Picture').text() != "") {
                          currentImage = $(this).find('Picture').text();
                          //$('#div_fileupload').show();
                          $("#imgprev-a").show();

                          $("#imgprev-a").attr("href", "../" + $(this).find('Picture').text());
                          $("#imgprvw").attr("src", "../" + $(this).find('Picture').text());
                          $("#imgprvw").attr("target", "_blank");

                      }
                      if ($(this).find('MaritalStatus').text() != "") {

                          $('#val_MaritalStatus').val($(this).find('MaritalStatus').text());
                          $('#val_MaritalStatus').trigger('chosen:updated');
                      }
                      if ($(this).find('Dependents').text() != "") {

                          $('#val_Dependent').val($(this).find('Dependents').text());
                          $('#val_Dependent').trigger('chosen:updated');
                      }
                      if ($(this).find('CallTime').text() != "") {

                          $('#val_CallTime').val($(this).find('CallTime').text());
                          $('#val_CallTime').trigger('chosen:updated');
                      }
                      if ($(this).find('ReferredBy').text() != "") {
                          $('#TxtRefferedBy').val($(this).find('ReferredBy').text());
                      }
                      if ($(this).find('ColdLead').text() != "") {

                          $('#val_ColdLead').val($(this).find('ColdLead').text());
                          $('#val_ColdLead').trigger('chosen:updated');
                      }
                      if ($(this).find('FirstContact').text() != "") {
                          $('#datepickerFirstContact').val($(this).find('FirstContact').text());
                      }
                      if ($(this).find('NextContact').text() != "") {
                          $('#TxtNextContact').val($(this).find('NextContact').text());
                      }
                      if ($(this).find('Discussed').text() != "") {
                          $('#TxtDiscussed').val($(this).find('Discussed').text());
                      }
                  });
              }); //end of Response   
          });                  //End of Ajax

    return false;
}

function SaveCustomerDetails() {

    var email = $('#txtEmail').val();
    var varOfficeEmail = $('#txtOfficeEmail').val();
    var filter = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
    var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    var postalCodeRegex = /^([A-Za-z][0-9][A-Za-z][0-9][A-Za-z][0-9]$)/;
    var varTitle = $('#txtTitle').val();
    var varFirstName = $('#txtFirstName').val();
    var varLastName = $('#txtLastName').val();
    var varAddress1 = $('#address1').val();
    var varAddress2 = $('#address2').val();
    var varOfficeAddress1 = $('#Officeaddress1').val();
    var varOfficeAddress2 = $('#Officeaddress2').val();
    var varPhoneNo = $('#PhoneNumber').val();
    var varMobileNo = $('#Mobile').val();
    var varStateID = $('#val_State').val();
    var varCityID = $('#val_City').val();
    var varDOB = $('#datepickerDOB').val();
    var varAnniversary = $('#datepickerAnniversary').val();
    var thisYearAnniversayDate = "";
    var thisYearDOB = "";
    var thisReminderDOB = "";
    var thisReminderAnniversary = "";
    if (varAnniversary != "") {

        var d = new Date();
        var thisYearAnniversayDate = new Date(varAnniversary);
        thisYearAnniversayDate.setYear(d.getFullYear());
        var mm = thisYearAnniversayDate.getDate();
        var  dd = thisYearAnniversayDate.getMonth() + 1; //January is 0!

        var yyyy = thisYearAnniversayDate.getFullYear();
        if (dd < 10) {
            dd = '0' + dd
        }
        if (mm < 10) {
            mm = '0' + mm
        }
        var thisReminderAnniversary = dd + '/' + mm + '/' + yyyy;
       
    }
    if (varDOB != "") {

        var d = new Date();
        var thisYearDOB = new Date(varDOB);
        thisYearDOB.setYear(d.getFullYear());

        thisYearDOB.setYear(d.getFullYear());
        var dd = thisYearDOB.getDate();
        var mm = thisYearDOB.getMonth() + 1; //January is 0!

        var yyyy = thisYearDOB.getFullYear();
        if (dd < 10) {
            dd = '0' + dd
        }
        if (mm < 10) {
            mm = '0' + mm
        }
        var thisReminderDOB = dd + '/' + mm + '/' + yyyy;
      
    }
    var varStatus = $('#val_Status').val();
    var varFaxNo = $('#HomeFax').val();
    var varOfficeFaxNo = $('#OfficeFax').val();
    var varExtensionField = $('#txtExtension').val();
    var varOfcStateID = $('#val_OfcState').val();
    var varOfcCityID = $('#val_OfcCity').val();
    var varOfcTelephone = $('#txtTelephone').val();
    var varPostalCode = $('#PostalCode').val();
    var varWork = $('#TxtWork').val();
    var varMaritalstatus = $('#val_MaritalStatus').val();
    var varDependent = $('#val_Dependent').val();
    var varCallTime = $('#val_CallTime').val();;
    var varReferredBy = $('#TxtRefferedBy').val();;
    var varColdLead = $('#val_ColdLead').val();
    var varFirstContact = $('#datepickerFirstContact').val();
    var varNextContact = $('#TxtNextContact').val();;
    var varDiscussed = $('#TxtDiscussed').val();

    if (varTitle.trim() == "") {
        toastr["error"]("Please enter title");
        return false;
    }
    else if (varFirstName.trim() == "") {
        toastr["error"]("Please enter first name");
        return false;
    }
    else if (varLastName.trim() == "") {
        toastr["error"]("Please enter last name");
        return false;
    }
        else if (varDOB == "") {
            toastr["error"]("Please select date of birth.");
            return false;
        }
      
    
    else if (varStatus == "-1") {
        toastr["error"]("Please select status.");
        return false;
    }
    else if (varAddress1.trim() == "") {
        toastr["error"]("Please enter an address to save details..");
        return false;
    }
    else if (varStateID == "-1") {
        toastr["error"]("Please select a state to save details..");
        return false;
    }
    else if (varCityID == "-1") {
        toastr["error"]("Please select a city to save details..");
        return false;
    }
    else if (varPostalCode != "" && (!postalCodeRegex.test(varPostalCode))) {

        toastr["error"]("Please enter valid postal code.");
        varPostalCode.focus;
        return false;

    }
    else if (varPhoneNo == "") {
        toastr["error"]("Please enter valid Residence phone no. of 10 digit");
        return false;
    }
    else if (varPhoneNo != "" && (!phoneno.test(varPhoneNo))) {

        toastr["error"]("Please enter valid phone no. of 10 digit");
        varPhoneNo.focus;
        return false;

    }
    else if (varMobileNo != "" && (!phoneno.test(varMobileNo))) {

        toastr["error"]("Please enter valid mobile no. of 10 digit");
        varMobileNo.focus;
        return false;

    }


    else if (varOfcTelephone != "" && (!phoneno.test(varOfcTelephone))) {

        toastr["error"]("Please enter valid office number.");
        varOfcTelephone.focus;
        return false;

    }
    else if (!filter.test(email)) {
        toastr["error"]("Please provide a valid email address");
        email.focus;
        return false;
    }
    else if (varOfficeEmail != "" && !filter.test(varOfficeEmail)) {
        toastr["error"]("Please provide a valid office email address");
        varOfficeEmail.focus;
        return false;
    }


    else if (varFaxNo != "" && (!phoneno.test(varFaxNo))) {

        toastr["error"]("Please enter valid fax no. of 10 digit");
        varFaxNo.focus;
        return false;

    }
    else if (varOfficeFaxNo != "" && (!phoneno.test(varOfficeFaxNo))) {

        toastr["error"]("Please enter Office Fax mobile no. of 10 digit");
        varOfficeFaxNo.focus;
        return false;

    }

    else if ($('#fileUpload').val() != "") {
        UploadCustProfilePic();
    }

    else {
       
        $.post("Ajax/AjaxCustomers.aspx",
                      {
                          Mode: "SAVECUSTOMERDETAILS",
                          Title: varTitle,
                          FirstName: varFirstName,
                          LastName: varLastName,
                          Email: email,
                          OfficialEmailID: varOfficeEmail,
                          Address_line1: varAddress1,
                          Address_Line2: varAddress2,
                          OfficeAddress1: varOfficeAddress1,
                          OfficeAddress2: varOfficeAddress2,
                          StatusID: varStatus,
                          ProvinceID: varStateID,
                          CityID: varCityID,
                          DateOfBirth: varDOB,
                          Anniversary: varAnniversary,
                          ReminderAnniversary: varAnniversary,
                          ReminderDOB: varDOB,
                          Mobile_Phone: varPhoneNo,
                          Picture: '',
                          Mobile: varMobileNo,
                          HomeFax: varFaxNo,
                          OfficeFax: varOfficeFaxNo,
                          ExtensionField: varExtensionField,
                          PostalCode: varPostalCode,
                          CustomerID: mvarCustomerID,
                          OfficeCityID: varOfcCityID,
                          OfficeStateID: varOfcStateID,
                          Telephone: varOfcTelephone,
                          Work: varWork,
                          MaritalStatus: varMaritalstatus,
                          Dependents: varDependent,
                          CallTime: varCallTime,
                          ReferredBy: varReferredBy,
                          ColdLead: varColdLead,
                          FirstContact: varFirstContact,
                          NextContact: varNextContact,
                          Discussed: varDiscussed

                      },
                          function (VarResponseData) {

                              if (VarResponseData == "SUCCESS") {
                                  if (mvarCustomerID == -1) {
                                      //toastr.options = { "onHidden": function () { $('.close').click(); GetCustomersListing(); } };
                                      //// $('.close').click();
                                      toastr["success"]("Client/Prospect added successfully");
                                      GetCustomersListing();
                                      GetUserName();
                                      $('#div_AddClient').hide();
                                      $('#btnAddCategory').show();
                                      $('#div_customerList').show();
                                      document.forms["form_Customer"].reset();
                                      mvarCustomerID = -1
                                  }
                                  else {
                                      toastr.options = { "onHidden": function () { $('.close').click(); GetCustomersListing(); } };
                                      // $('.close').click();
                                      toastr["success"]("Client/Prospect details updated successfully sandy");
                                      GetCustomersListing();
                                      GetUserName();
                                      $('#div_AddClient').hide();
                                      $('#btnAddCategory').show();
                                      $('#div_customerList').show();
                                      document.forms["form_Customer"].reset();
                                      mvarCustomerID = -1
                                  }
                                  NProgress.done();
                              }
                              else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                                  toastr["error"]("Customer already exists");
                                  GetCustomersListing();
                                  GetUserName();
                                  $('#div_AddClient').hide();
                                  $('#btnAddCategory').show();
                                  $('#div_customerList').show();

                              }
                          });
    }
    return false;
}

function UploadCustProfilePic() {
    var email = $('#txtEmail').val();
    var varTitle = $('#txtTitle').val();
    var varFirstName = $('#txtFirstName').val();
    var varLastName = $('#txtLastName').val();
    var filter = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
    var varOfficeAddress1 = $('#Officeaddress1').val();
    var varOfficeAddress2 = $('#Officeaddress2').val();
    var varMobileNo = $('#Mobile').val();
    var varFaxNo = $('#HomeFax').val();
    var varOfficeFaxNo = $('#OfficeFax').val();
    var varExtensionField = $('#txtExtension').val();
    var varPostalCode = $('#PostalCode').val();
    var varOfficeEmail = $('#txtOfficeEmail').val();
    var varAnniversary = $('#datepickerAnniversary').val();
    var varOfcStateID = $('#val_OfcState').val();
    var varOfcCityID = $('#val_OfcCity').val();
    var varOfcTelephone = $('#txtTelephone').val();
    var varWork = $('#TxtWork').val();
    var varMaritalstatus = $('#val_MaritalStatus').val();
    var varDependent = $('#val_Dependent').val();
    var varCallTime = $('#val_CallTime').val();;
    var varReferredBy = $('#TxtRefferedBy').val();;
    var varColdLead = $('#val_ColdLead').val();
    var varFirstContact = $('#datepickerFirstContact').val();
    var varNextContact = $('#TxtNextContact').val();;
    var varDiscussed = $('#TxtDiscussed').val();

    if ($('#fileUpload').val() != '') {

        var varImgFileExtn = $('#fileUpload').val().substr($('#fileUpload').val().lastIndexOf("."), $('#fileUpload').val().length);

        if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
            alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 1');
            return false;
        }
    }
    else if (!filter.test(email)) {
        toastr["error"]("Please provide a valid email address");
        //alert('Please provide a valid email address');
        email.focus;
        return false;
    }
    else if (varOfficeEmail != "" && !filter.test(varOfficeEmail)) {
        toastr["error"]("Please provide a valid office email address");
        //alert('Please provide a valid email address');
        Officeemail.focus;
        return false;
    }
    $.ajaxFileUpload({
        url: 'Ajax/UploadProfilePics.ashx?Mode=UPLOADCUSTOMERPICS',
        secureuri: false,
        fileElementId: 'fileUpload',
        dataType: 'text',
        data: { name: 'logan', id: 'id' },
        success: function (data, status) {

            data = data.replace("<pre>", "").replace("<PRE>", "")
            data = data.replace("</pre>", "").replace("</PRE>", "")
            if (data.indexOf("SUCCESS") != -1) {

                $.post("Ajax/AjaxCustomers.aspx",
                {
                    Mode: "SAVECUSTOMERDETAILS",
                    Title: varTitle,
                    FirstName: varFirstName,
                    LastName: varLastName,
                    Email: email,
                    OfficialEmailID: varOfficeEmail,
                    Address_line1: $('#address1').val(),
                    Address_Line2: $('#address2').val(),
                    OfficeAddress1: varOfficeAddress1,
                    OfficeAddress2: varOfficeAddress2,
                    StatusID: $('#val_Status').val(),
                    ProvinceID: $('#val_State').val(),
                    CityID: $('#val_City').val(),
                    DateOfBirth: $('#datepickerDOB').val(),
                    Anniversary: varAnniversary,
                    Mobile_Phone: $('#PhoneNumber').val(),
                    Picture: data.split("##")[1],
                    Mobile: varMobileNo,
                    HomeFax: varFaxNo,
                    OfficeFax: varOfficeFaxNo,
                    ExtensionField: varExtensionField,
                    PostalCode: varPostalCode,
                    CustomerID: mvarCustomerID,
                    OfficeCityID: varOfcCityID,
                    OfficeStateID: varOfcStateID,
                    Telephone: varOfcTelephone,
                    Work: varWork,
                    MaritalStatus: varMaritalstatus,
                    Dependents: varDependent,
                    CallTime: varCallTime,
                    ReferredBy: varReferredBy,
                    ColdLead: varColdLead,
                    FirstContact: varFirstContact,
                    NextContact: varNextContact,
                    Discussed: varDiscussed

                },
                    function (VarResponseData) {
                        if (VarResponseData == "SUCCESS") {
                            if (mvarCustomerID == -1) {
                                // toastr.options = { "onHidden": function () { $('.close').click(); GetCustomersListing(); } };
                                //   $('.close').click();
                                toastr["success"]("Client/Prospect added successfully");
                                GetCustomersListing();
                                GetUserName();
                                $('#div_AddClient').hide();
                                $('#btnAddCategory').show();
                                $('#div_customerList').show();
                                document.forms["form_Customer"].reset();
                                mvarCustomerID = -1
                                $('#sidebar_profilepic').attr('src', data.split("##")[1]);
                                $('#imgprvw').attr('src', data.split("##")[1]);
                                $('#imgprev-a').show();
                                NProgress.done();
                            }
                            else {
                                //toastr.options = { "onHidden": function () { $('.close').click(); GetCustomersListing(); } };

                                toastr["success"]("Client/Prospect details updated successfully Dev");
                                GetCustomersListing();
                                GetUserName();
                                $('#div_AddClient').hide();
                                $('#btnAddCategory').show();
                                $('#div_customerList').show();
                                document.forms["form_Customer"].reset();
                                mvarCustomerID = -1

                            }
                            NProgress.done();
                        }
                        else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                            toastr["error"]("Client/Prospect already exists");
                            GetCustomersListing();
                            GetUserName();
                            $('#div_AddClient').hide();
                            $('#btnAddCategory').show();
                            $('#div_customerList').show();

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

function GetCustomersListing() {

    $("#TblCustomers").empty();
    $("#TblCustomers").SJGrid
    (
    {
        url: 'Ajax/AjaxCustomers.aspx?Mode=GETCUSTOMERSLISTING',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Picture', name: 'Picture', width: 70, sortable: false, align: 'left' },
                { display: 'Name', name: 'Full_Name', width: 70, sortable: false, align: 'left' },
                { display: 'DOB ', name: 'DateOfBirth', width: 60, sortable: false, align: 'left' },
                //{ display: 'Anniversary', name: 'Anniversary', width: 60, sortable: false, align: 'left' },
                { display: 'Email', name: 'Email', width: 70, sortable: false, align: 'left' },
                { display: 'Address', name: 'Address', width: 100, sortable: false, align: 'left' },
                { display: 'Mobile', name: 'Mobile_Phone', width: 70, sortable: false, align: 'left' },
                { display: 'Status', name: 'Status', width: 70, sortable: false, align: 'left' },
                { display: 'Action', width: 190, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "DateAndTime",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "DateAndTime",
        query: '',
        onError: function (errorMsg) {
            alert("error");
        },
        onSuccess: function () {

        }
    }

    );
    return false;
}

function ResetForm() {

    mvarCustomerID = -1;
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    $('#div_AddClient').show();
    //$('#UploadExcelModel').hide();
    $('#btnAddCategory').hide();
    $('#div_customerList').hide();
    $('#BtnSaveCustomer').show();
    $('#BtnEditCustomer').hide();
    document.forms["form_Customer"].reset();
    $('#headerMainTitle').html("Add Clients/Prospects");
    $('#fileUpload').empty();
    $('#val_City').empty();
    $('#val_State').empty();
    $('#val_OfcCity').empty();
    $('#val_OfcState').empty();
    $('#imgprvw').attr('src', '');
    $('#imgprvw').hide();

    //  FillCityCombo();
    // FillStateCombo();


}

function GetUserName() {

    $.post("Ajax/AjaxCustomers.aspx",
    {
        Mode: "GETUSERNAME"

    },
  function (VarResponseData) {


      $('#headerMainTitle').html("" + VarResponseData + "'s" + "  " + "Client/Prospect Listing");

  });                  //End of Ajax

    return false;
}

function DeleteCustomer(pvarCustomerID) {
    var varApproved = "Are  you sure you want to delete this customer?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxCustomers.aspx",
                  {

                      Mode: "DELETECUSTOMER",
                      CustomerID: pvarCustomerID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {

                              toastr["success"]("Customer deleted successfully");
                              GetCustomersListing();
                          }
                      }


                  });
    }
    return false;
}

function AddDocument(pvarCustomerID) {
    window.location.href = "CustomerDocuments.aspx?CustomerID=" + pvarCustomerID;
}

function ShowFollowUpDetails(pvarCustomerID) {
    window.location.href = "FollowUpDetails.aspx?CustomerID=" + pvarCustomerID;
}

function ShowSeekPermissionBlock(pvarCustomerID) {
    mvarCustomerID = pvarCustomerID;
    $('#div_SeekPermission').show();
    $('#div_customerListing').hide();
    $('.table-responsive').hide();
    $.post("Ajax/AjaxCustomers.aspx",
   {
       Mode: "GETCUSTOMERNAME",
       CustomerID: mvarCustomerID

   },
 function (VarResponseData) {

     $('#headerPermission').html("Obtain " + VarResponseData + "'s" + "  " + "Permission");
     FillExpertsCombo();

 });                  //End of Ajax

    return false;

}



function FillExpertsCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxCustomers.aspx",
            { Mode: "FILLEXPERTSCOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#val_Experts').empty();
                           var opt = document.getElementById("val_Experts").options;
                           opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('UserID').text() != "" && $(this).find('Full_Name').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Full_Name').text(), $(this).find('UserID').text());
                               }
                           }); // end of Contents

                           $('#val_Experts').trigger('chosen:updated');


                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}

function SendMailToClient() {

    $.post("Ajax/AjaxCustomers.aspx",
  {
      Mode: "SENDMAILTOCLIENT",
      CustomerID: mvarCustomerID,
      ExpertID: $('#val_Experts').val()

  },
function (VarResponseData) {
    $('#div_success').show();
    $("#BtnSeekPermission").attr("disabled", "disabled");
    //  $('#headerPermission').html("Obtain " + VarResponseData + "'s" + "  " + "Permission");
    //FillExpertsCombo();

});                  //End of Ajax

    return false;
}

function GetFollowUpDetails(pvarCustomerID) {
    window.location.href = "FollowUpDetails.aspx?CustomerID=" + pvarCustomerID;
}


function ShowCustomerProfileModal(pvarCustomerID) {
    NProgress.start();
    // alert(pvarCustomerID);
    $('#modal-regular-Profile').show();

    $.post("Ajax/AjaxCustomers.aspx",
            {
                Mode: "VIEWCUSTOMERPROFILE",

                CustomerID: pvarCustomerID
            },

          function (VarResponseData) {
              //  alert(VarResponseData);
              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('CustomerData').each(function () {


                      if ($(this).find('Full_Name').text() != "") {
                          $('#header_Title').html("" + $(this).find('Full_Name').text() + "'s" + "  " + "Profile");
                          $('#p_name').html($(this).find('Full_Name').text());
                      }
                      if ($(this).find('Picture').text() != "") {
                          $('#profilepic').html($(this).find('Picture').text());
                      }
                      if ($(this).find('DateOfBirth').text() != "") {
                          $('#p_DOB').html($(this).find('DateOfBirth').text());
                      }
                      if ($(this).find('Status').text() != "") {
                          $('#p_Status').html($(this).find('Status').text());
                      }
                      if ($(this).find('Address_line1').text() != "") {
                          $('#p_address1').html($(this).find('Address_line1').text());
                      }
                      if ($(this).find('Address_Line2').text() != "") {
                          $('#p_address1').html($('#p_address1').html() + "<br/>" + $(this).find('Address_Line2').text());
                      }
                      if ($(this).find('City').text() != "") {
                          $('#p_address1').html($('#p_address1').html() + "<br/>City : " + $(this).find('City').text());
                          // $('#p_City').html($(this).find('City').text());
                      }
                      if ($(this).find('State').text() != "") {
                          $('#p_address1').html($('#p_address1').html() + "<br/> State : " + $(this).find('State').text());
                          // $('#p_City').html($(this).find('City').text());
                      }
                      if ($(this).find('OfficeAddress1').text() != "") {
                          $('#p_OfficeAddress').html($(this).find('OfficeAddress1').text());
                      }
                      if ($(this).find('OfficeAddress2').text() != "") {
                          $('#p_OfficeAddress').html($('#p_OfficeAddress').html() + "<br/>" + $(this).find('OfficeAddress2').text());
                      }
                      if ($(this).find('OfficeCity').text() != "") {
                          $('#p_OfficeAddress').html($('#p_OfficeAddress').html() + "<br/> City : " + $(this).find('OfficeCity').text());
                          // $('#p_City').html($(this).find('City').text());
                      }
                      if ($(this).find('OfficeState').text() != "") {
                          $('#p_OfficeAddress').html($('#p_OfficeAddress').html() + "<br/> State : " + $(this).find('OfficeState').text());
                          // $('#p_City').html($(this).find('City').text());
                      }
                      if ($(this).find('PostalCode').text() != "") {
                          $('#p_PostalCode').html($(this).find('PostalCode').text());
                      }
                      if ($(this).find('Mobile_Phone').text() != "") {
                          $('#p_Phoneno').html($(this).find('Mobile_Phone').text());
                      }

                      if ($(this).find('Work').text() != "") {
                          $('#p_Work').html($(this).find('Work').text());
                      }
                      if ($(this).find('Email').text() != "") {
                          $('#p_Email').html($(this).find('Email').text());
                      }
                      if ($(this).find('HomeFax').text() != "") {
                          $('#p_Fax').html($(this).find('HomeFax').text());
                      }

                  });

              }); //end of Response   
              NProgress.done();
          });                 //End of Ajax
    // }
    return false;
}