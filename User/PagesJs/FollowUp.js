$(document).ready(function () {
    $('#FollowUp-a').addClass("active");
 
    FillStateCombo();
    FillCityCombo();
    $('#BtnSaveFollowUp').click(function () {

        SaveFollowUp();


        //alert('provide email and password to conitnue..');
        return false;

    });
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
    varStateID = pvarStateID;

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

function GetProvince(pvarCityID) {
    pvarCityID = $('#val_City').val();

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


    return false;
}

function FillCityCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
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

function SaveFollowUp() {
    var varCUstomerID = $('#val_Customers').val();
    var varFollowUpText = $('#txtFollowUp').val();
    var varFollowUpDesc = $('#txtFollowUpDesc').val();
    var varFollowUpDate = $('#datepickerFollowUp').val();
    var varStartTime = $('#Starttimepicker').val();
    var varEndTime = $('#Endtimepicker').val();
    var varStateID = $('#val_State').val();
    var varCityID = $('#val_City').val();
    var varVenue = $('#txtVenue').val();
    
     if (varFollowUpText == "")
    {
        toastr["error"]("Please enter followUp text.");
        return false;
     }
     else if (varCUstomerID == -1) {
         toastr["error"]("Please select customer.");
         return false;
     }
    else if (varFollowUpDate == "") {
        toastr["error"]("Please choose date.");
        return false;
    }
    else if (varStartTime == "") {
        toastr["error"]("Please choose start time.");
        return false;
    }
    else if (varEndTime == "") {
        toastr["error"]("Please choose end time.");
        return false;
    }
    else if (varVenue == "") {
        toastr["error"]("Please enter venue.");
        return false;
    }
    $.post("Ajax/AjaxCustomers.aspx",
           {
               Mode: "SAVEFOLLOWUP",
               CustomerID:varCUstomerID,
               FollowUpText: varFollowUpText,
               Description: varFollowUpDesc,
               FollowUpDateAndTime: varFollowUpDate,
               StartTime: varStartTime,
               EndTime: varEndTime,
               StateID: varStateID,
               CityID: varCityID,
               Venue: varVenue
           },
               function (VarResponseData) {
                 
                   if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                     
                       toastr["success"]("Customer assigned for followUp");
                       document.forms["form-FollowUp"].reset();
                       document.getElementById("val_State").value = -1;
                       document.getElementById("val_City").value = -1;
                      // $('#val_State').selectmenu("refresh");
                      // $('#val_City').val = -1;
                      // $('#val_State').val = -1;
                       // $('#val_City').val(-1);
                      
                       }
                  
               });


    return false;
}