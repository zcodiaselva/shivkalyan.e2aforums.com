var mvarAdvertisementID = -1;
var currentdate = "";
var varimgDimension = "";
var varMonth = "";
var varStateID = -1;
var currentImage = "";
$(function () {
    GetAdvertisementListing();
    $('button.close').click(function () {
        NProgress.start();

        $('#modal-Add-Advertisement').hide();
        document.forms["form_Advertisement"].reset();

        $('#BtnSaveAdvertisement').show();
        $('#BtnEditAdvertisement').hide();
       
        $('#headerTitle').html("Add Advertisement")
        NProgress.done();
    });
  
    $('#Advertisement-a').addClass("active");
    FillImgSizeCombo();
    FillCityCombo();
    FillStateCombo();
    FillZoneCombo();
});
function FillStateCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            { Mode: "FILLSTATECOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#cmbState').empty();
                           var opt = document.getElementById("cmbState").options;
                           opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('StateID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('StateID').text());
                               }
                           }); // end of Contents

                           $('#cmbState').trigger('chosen:updated');


                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}
function FillZoneCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            { Mode: "FILLZONECOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#cmbZone').empty();
                           var opt = document.getElementById("cmbZone").options;
                           opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('AdvertisementZoneID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('AdvertisementZoneID').text());
                               }
                           }); // end of Contents

                           $('#cmbZone').trigger('chosen:updated');


                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}
function GetCities(pvarStateID) {
    pvarStateID = $('#cmbState').val();
    //alert(pvarStateID);
    $('#tr_city').show();
    varStateID = pvarStateID;
   
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "FILLCITIESOFSELECTEDSTATE",
                StateID: pvarStateID
            },
               function (varResponseData) {
                   
                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#cmbCity').empty();
                           var opt = document.getElementById("cmbCity").options;
                           opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('CityID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('CityID').text());
                               }
                           }); // end of Contents

                           $('#cmbCity').trigger('chosen:updated');


                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}


function FillImgSizeCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            { Mode: "FILLIMGSIZECOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#cmbImgSizes').empty();
                           var opt = document.getElementById("cmbImgSizes").options;
                           opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('ImageSizeID').text() != "" && $(this).find('ImageSize').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('ImageSize').text(), $(this).find('ImageSizeID').text());
                               }
                           }); // end of Contents

                           $('#cmbImgSizes').trigger('chosen:updated');


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

                           $('#cmbCity').empty();
                           var opt = document.getElementById("cmbCity").options;
                           opt[opt.length] = new Option('Select', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('CityID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('CityID').text());
                               }
                           }); // end of Contents

                           $('#cmbCity').trigger('chosen:updated');


                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}

function AddNewAdvertisement() {
    var txt = $('#txtClickUrl').val();
    var re = /^(https:\/\/|http:\/\/|www.)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/;//=/^(?:(?:https?|ftp):\/\/)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3})
    varimgDimension = ImgWidth + "x" + ImgHeight;
    NProgress.start();
    var e = document.getElementById("cmbImgSizes");
    var strImageSize = e.options[e.selectedIndex].text;

    if ($('#txtTitle').val().trim() == '')
    {
        toastr["error"]("Please enter title");
        return false;
    }
 
    else if ($('#fileUpload').val() == '' && mvarAdvertisementID == -1) {
        toastr["error"]("Please select image");
        return false;
    }
    else if ($('#cmbImgSizes').val() == -1) {
        toastr["error"]("Please select image size");
        return false;

    }
    else if (strImageSize != varimgDimension ) {
            toastr["error"]("Please select image of selected dimensions.");
            return false;

        }
   
    else if ($('#txtClickUrl').val().trim() == '' || !re.test(txt))
    {
            toastr["error"]("Please enter valid Click url");
            return false;
        
    }

    else if ($('#cmbZone').val() == -1) {
        toastr["error"]("Please select zone");
        return false;

     }
    else if ($('#datepickerFrom').val().trim() == '') {
        toastr["error"]("Please select start date");
        return false;
    }
   
    else if ($('#datepickerTo').val().trim() == '') {
        toastr["error"]("Please select end date");
        return false;
    }
    else if ($('#cmbStartHH').val() == -1) {
        toastr["error"]("Please select start hours");
        return false;
    }
    else if ($('#cmbStartMM').val() == -1) {
        toastr["error"]("Please select start minutes");
        return false;
    }
    else if ($('#cmbStartAMPM').val() == -1) {
        toastr["error"]("Please select start am/pm");
        return false;
    }
    else if ($('#cmbTotHH').val() == -1) {
        toastr["error"]("Please select end hours");
        return false;
    }
    else if ($('#cmbToMM').val() == -1) {
        toastr["error"]("Please select end minutes");
        return false;
    }
    else if ($('#cmbToAMPM').val() == -1) {
        toastr["error"]("Please select end am/pm");
        return false;
   
    }
  
    
    if (mvarAdvertisementID != -1 && $('#fileUpload').val() == '')
    {

        var varStartHH = $('#cmbStartHH').val();
        var varStartMM = $('#cmbStartMM').val();
        var varEndHH = $('#cmbTotHH').val();
        var varEndMM = $('#cmbToMM').val();
        var varStartAMPM = $('#cmbStartAMPM').val();
        var varEndAMPM = $('#cmbToAMPM').val();
        if (varStartAMPM == "PM" && varStartHH != parseInt("12")) {
            varStartHH = parseFloat(varStartHH) + parseInt(12);
        }
        if (varEndAMPM == "PM" && varEndHH != parseInt("12")) {
            varEndHH = parseFloat(varEndHH) + parseInt(12);
        }

        var varFromTime = varStartHH + ":" + varStartMM + " " + varStartAMPM;
        var varToTime = varEndHH + ":" + varEndMM + " " + varEndAMPM;

        if (varFromTime >= varToTime) {
            alert("Start time should not be greater than or equal to the End time.");
            return false;
        }

        $.post("Ajax/AjaxUser.aspx",
        {
            Mode: "ADDNEWADVERTISEMENT",
            Title: $('#txtTitle').val(),
            ImageName: currentImage,
            ClickUrl: $('#txtClickUrl').val(),
            FromDateTime: $('#datepickerFrom').val(),
            ToDateTime: $('#datepickerTo').val(),
            FromTime: varFromTime,
            ToTime: varToTime,
            ImageSizeID: $('#cmbImgSizes').val(),
            AdvertisementZoneID: $('#cmbZone').val(),
            //StateID: $('#cmbState').val(),
            //CityID: $('#cmbCity').val(),
            AdvertisementID: mvarAdvertisementID

        },
            function (VarResponseData) {

                if (VarResponseData == "SUCCESS") {
                    if (mvarAdvertisementID == -1) {
                        toastr["success"]("Advertisement added successfully");
                        $('#btn_addAdvertisementClose').click();
                        GetAdvertisementListing();
                    }
                    else {
                        toastr["success"]("Advertisement updated successfully");
                        $('#btn_addAdvertisementClose').click();
                        GetAdvertisementListing();
                    }

                    NProgress.done();
                }

            });
    }
    else {
        UploadFile();
    }
    
     return false;
   
}

function UploadFile() {
   
    var varStartHH = $('#cmbStartHH').val();
    var varStartMM = $('#cmbStartMM').val();
    var varEndHH = $('#cmbTotHH').val();
    var varEndMM = $('#cmbToMM').val();
    var varStartAMPM = $('#cmbStartAMPM').val();
    var varEndAMPM = $('#cmbToAMPM').val();
   if (varStartAMPM == "PM" && varStartHH != parseInt("12")) {
        varStartHH = parseFloat(varStartHH) + parseInt(12);
    }
   if (varEndAMPM == "PM" && varEndHH != parseInt("12")) {
        varEndHH = parseFloat(varEndHH) + parseInt(12);
    }
  
   var varFromTime = varStartHH + ":" + varStartMM + " " + varStartAMPM ;
   var varToTime = varEndHH + ":" + varEndMM + " " + varEndAMPM ;
 
    if (varFromTime >= varToTime) {
        alert("Start time should not be greater than or equal to the End time.");
        return false;
    }
   
    if ($('#fileUpload').val() != '') {

        var varImgFileExtn = $('#fileUpload').val().substr($('#fileUpload').val().lastIndexOf("."), $('#fileUpload').val().length);

        if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
            alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 1');
            return false;
        }
    }
  
    console.log("calling upload");

    $.ajaxFileUpload({
        url: 'Ajax/UploadAdvertImages.ashx',
        secureuri: false,
        fileElementId: 'fileUpload',
        dataType: 'text',
        data: { name: 'logan', id: 'id' },
        success: function (data, status) {

            data = data.replace("<pre>", "").replace("<PRE>", "")
            data = data.replace("</pre>", "").replace("</PRE>", "")
          
            console.log("file uploaded");
            console.log(data);
            if (data.indexOf("SUCCESS") != -1) {
               
           $.post("Ajax/AjaxUser.aspx",
            {
               Mode: "ADDNEWADVERTISEMENT",
               Title: $('#txtTitle').val(),
               ImageName: data.split("##")[1],
               ClickUrl: $('#txtClickUrl').val(),
               FromDateTime: $('#datepickerFrom').val(),
               ToDateTime: $('#datepickerTo').val(),
               FromTime: varFromTime,
               ToTime: varToTime,
               ImageSizeID: $('#cmbImgSizes').val(),
               AdvertisementZoneID: $('#cmbZone').val(),
               //StateID: $('#cmbState').val(),
               //CityID: $('#cmbCity').val(),
               AdvertisementID: mvarAdvertisementID

           },
            function (VarResponseData) {

                console.log("ajax resp");
                console.log(VarResponseData);
                if (VarResponseData == "SUCCESS") {
                    if (mvarAdvertisementID == -1) {
                        toastr["success"]("Advertisement added successfully");
                        $('#btn_addAdvertisementClose').click();
                        GetAdvertisementListing();
                    }
                    else {
                        toastr["success"]("Advertisement updated successfully");
                        $('#btn_addAdvertisementClose').click();
                        GetAdvertisementListing();
                    }

                    NProgress.done();
                }

            });

               /* $.post("Ajax/AjaxUser.aspx",
                {
                    Mode: "ADDNEWADVERTISEMENT",
                    Title: $('#txtTitle').val(),
                    ImageName: data.split("##")[1],
                    ClickUrl: $('#txtClickUrl').val(),
                    FromDateTime: $('#datepickerFrom').val(),
                    ToDateTime: $('#datepickerTo').val(),
                    FromTime: varFromTime,
                    ToTime: varToTime,
                    ImageSizeID: $('#cmbImgSizes').val(),
                    StateID: $('#cmbState').val(),
                    CityID: $('#cmbCity').val(),
                    AdvertisementID: mvarAdvertisementID

                },
                    function (VarResponseData) {

                        if (VarResponseData == "SUCCESS") {
                            if (mvarAdvertisementID == -1) {
                                toastr["success"]("Advertisement added successfully");
                                $('#btn_addAdvertisementClose').click();
                                GetAdvertisementListing();
                            }
                            else {
                                toastr["success"]("Advertisement updated successfully");
                                $('#btn_addAdvertisementClose').click();
                                GetAdvertisementListing();
                            }
                        
                            NProgress.done();
                        }

                    });*/


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

function GetAdvertisementListing() {

    $("#TblAdvertisement").empty();
    $("#TblAdvertisement").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETADVERTISEMENTLISTING',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'ImageName', name: 'ImageName', width: 130, sortable: false, align: 'left' },
                { display: 'Title', name: 'Title', width: 130, sortable: false, align: 'left' },
                { display: 'ClickUrl', name: 'ClickUrl', width: 100, sortable: false, align: 'left' },
                { display: 'Zone ', name: 'AdvertisementZoneID', width: 100, sortable: false, align: 'left' },
                { display: 'Views ', name: 'ViewCount', width: 100, sortable: false, align: 'left' },
                { display: 'Action', width: 160, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "AdvertisementID",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "Title",
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

function DeleteAdvertisement(pvarAdvertisementID) {

    var varApproved = "Are  you sure you want to delete this Advertisement?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxUser.aspx",
                  {

                      Mode: "DELETEADVERTISEMENT",
                      AdvertisementID: pvarAdvertisementID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {

                              toastr["success"]("Advertisement deleted successfully");
                              GetAdvertisementListing();
                          }
                      }


                  });
    }
    return false;

}

function ResetForm() {
    document.forms["form_Advertisement"].reset();
    NProgress.start();
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    mvarAdvertisementID = -1;
    if ($('#cmbImgSizes').val() == "" || $('#cmbImgSizes').val() == -1) {
        $('#div_fileupload').hide();
    }
    $('#fileUpload').empty();//="";

    $('#cmbImgSizes').val("-1");
    $('#cmbImgSizes').trigger('chosen:updated');
    $('#cmbCity').val("-1");
    $('#cmbCity').trigger('chosen:updated');
    $('#cmbStartHH').val("-1");
    $('#cmbStartHH').trigger('chosen:updated');
    $('#cmbStartMM').val("-1");
    $('#cmbStartMM').trigger('chosen:updated');
    $('#cmbStartAMPM').val("-1");
    $('#cmbStartAMPM').trigger('chosen:updated');
    $('#cmbTotHH').val("-1");
    $('#cmbTotHH').trigger('chosen:updated');
    $('#cmbToMM').val("-1");
    $('#cmbToMM').trigger('chosen:updated');
    $('#cmbToAMPM').val("-1");
    $('#cmbToAMPM').trigger('chosen:updated');
    $('#cmbZone').val("-1");
    $('#cmbZone').trigger('chosen:updated');
    NProgress.done()
}

function showEditAdvertisementModel(pvarAdvertisementID) {
    mvarAdvertisementID = pvarAdvertisementID;
    $('#BtnSaveAdvertisement').hide();
    $('#BtnEditAdvertisement').show();
    $('#headerTitle').html("Edit Advertisement");
    $('#modal-Add-Advertisement').show();
  
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETADVERTISEMENTDETAILS",
                AdvertisementID: mvarAdvertisementID
            },

          function (VarResponseData) {

              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('AdvertisementData').each(function () {
                   
                      if ($(this).find('Title').text() != "") {
                          $('#txtTitle').val($(this).find('Title').text());
                      }
                      if ($(this).find('ImageName').text() != "") {
                          currentImage = $(this).find('ImageName').text();
                          $('#div_fileupload').show();
                          $("#imgprev-a").show();
                     
                          $("#imgprev-a").attr("href", "../" + $(this).find('ImageName').text());
                          $("#imgprvw").attr("src", "../" + $(this).find('ImageName').text());

                      }
                    
                      if ($(this).find('ClickUrl').text() != "") {
                          $('#txtClickUrl').val($(this).find('ClickUrl').text());
                      }
                      if ($(this).find('ImageSizeID').text() != "") {
                          
                          $('#cmbImgSizes').val($(this).find('ImageSizeID').text());
                          $('#cmbImgSizes').trigger('chosen:updated');
                      }
                    
                      if ($(this).find('AdvertisementZoneID').text() != "") {
                          $('#cmbZone').val($(this).find('AdvertisementZoneID').text());
                          $('#cmbZone').trigger('chosen:updated');
                      }
                      if ($(this).find('FromDateTime').text() != "") {
                          $('#datepickerFrom').val($(this).find('FromDateTime').text());
                      }
                      if ($(this).find('ToDateTime').text() != "") {
                          $('#datepickerTo').val($(this).find('ToDateTime').text());
                      }
                      if ($(this).find('StartHours').text() != "") {
                          $('#cmbStartHH').val($(this).find('StartHours').text());
                      }

                      if ($(this).find('StartMinutes').text() != "") {
                          $('#cmbStartMM').val($(this).find('StartMinutes').text());
                      }
                      if ($(this).find('STARTAMPM').text() != "") {

                          $('#cmbStartAMPM').val($(this).find('STARTAMPM').text());

                      }
                      if ($(this).find('ToHours').text() != "") {
                          $('#cmbTotHH').val($(this).find('ToHours').text());
                      }
                      if ($(this).find('ToMinutes').text() != "") {
                          $('#cmbToMM').val($(this).find('ToMinutes').text());
                      }
               
                      if ($(this).find('TOAMPM').text() != "") {
                          $('#cmbToAMPM').val($(this).find('TOAMPM').text());

                      }
                      console.log($(this).find('StartHours').text());
                      console.log($(this).find('ToHours').text());
                      console.log($(this).find('StartMinutes').text());
                  });
              }); //end of Response   
          });                  //End of Ajax

    return false;
}