var mvarAdvertisementID = -1;
var currentdate = "";
var varimgDimension = "";
var varMonth = "";
var varStateID = -1;
var currentImage = "";
var varIsOpen = "";
$(function () {
    GetAdvertisementListing();
    $('button.close').click(function () {
        NProgress.start();

        $('#modal-Add-Advertisement').hide();
        document.forms["form_Advertisement"].reset();

        $('#BtnSaveAdvertisement').show();
        $('#BtnEditAdvertisement').hide();

        $('#headerTitle').html("Add Advertisement Zone")
        NProgress.done();
    });

    $('#AdvertisementZone-a').addClass("active");
    FillStateCombo();

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
                           opt[opt.length] = new Option('Select Province', -1);

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

function GetCities(pvarStateID) {

    pvarStateID = $('#cmbState').val();
    //alert(pvarStateID);
    $('#tr_city').show();
    varStateID = pvarStateID;

    $(".search-choice").hide();

    var alreadySeletedCities = $("#cmbCity").val();
    console.log("alreadySeletedCities " + alreadySeletedCities);

    var citieslength = $('#cmbCity').length;
    console.log("citieslength " + citieslength);


    if (alreadySeletedCities != -1) {

        $("#cmbCity option:not(:selected)").remove();
    }
    else {
        $('#cmbCity').empty();
    }

    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "FILLCITIESOFSELECTEDSTATE",
                StateID: pvarStateID
            },
               function (varResponseData) {
                   //return false;

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           var opt = document.getElementById("cmbCity").options;
                           //opt[opt.length] = new Option('Select', -1);

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
                           //opt[opt.length] = new Option('Select', -1);

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

function ShowProvinceDiv() {
    if ($('#CbIsOpen').is(":checked")) {
        varIsOpen = "True";
        $('#divProvince').hide();
       $('#tr_city').hide();
    }
    else {
        varIsOpen = "False";
        $('#divProvince').show();
       // $('#tr_city').show();
    }
}

function AddNewAdvertisement() {
   
    var cityIds = -1;
    if ($('#txtTitle').val().trim() == '') {
        toastr["error"]("Please provide title..");
        return false;
    }
    if ($('#CbIsOpen').is(":checked")) {
        varIsOpen = "True";
        $('#divProvince').hide();
        $('#tr_city').hide();
    }
    else {
        varIsOpen = "False";
        $('#divProvince').show();
        $('#tr_city').show();
        var _cities = $('#cmbCity').val();


        if ($('#cmbState').val() == -1) {

            if (mvarAdvertisementID == -1) {
                toastr["error"]("Please select state");
                return false;
            }

        }
        else if ($('#cmbCity').val() == -1) {
            toastr["error"]("Please select city");
            return false;
        }

         cityIds = _cities.toString();
    }


    $.post("Ajax/AjaxUser.aspx",
    {
        Mode: "ADDNEWADVERTISEMENTZONE",
        Title: $('#txtTitle').val(),
        Description: $('#txtDescription').val(),
        StateID: $('#cmbState').val(),
        CityID: cityIds,
        AdvertisementZoneID: mvarAdvertisementID,
        IsOpen:varIsOpen

    },
        function (VarResponseData) {

            if (VarResponseData == "SUCCESS") {

                if (mvarAdvertisementID == -1) {

                    toastr["success"]("Advertisement group added successfully");
                    $('#btn_addAdvertisementClose').click();

                    GetAdvertisementListing();
                }
                else {

                    toastr["success"]("Advertisement group updated successfully");
                    $('#btn_addAdvertisementClose').click();

                    GetAdvertisementListing();
                }

                NProgress.done();
            }

        });

}


function GetAdvertisementListing() {

    $("#TblAdvertisement").empty();
    $("#TblAdvertisement").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETADVERTISEMENTZONELISTING',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },               
                { display: 'Title', name: 'Title', width: 130, sortable: false, align: 'left' },
                { display: 'Description', name: 'Description', width: 100, sortable: false, align: 'left' },
                { display: 'Cities ', name: 'Cities', width: 200, sortable: false, align: 'left' },                
                { display: 'Action', width: 100, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "AdvertisementZoneID",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "Title",
        query: '',
        onError: function (errorMsg) {
            console.log("error");
        },
        onSuccess: function () {

        }
    }

    );
    return false;
}

/*
*#param bajwa- 120214- function to delete advertisement zone/group.
*/
function DeleteAdvertisementZone(pvarAdvertisementZoneID) {

    var varApproved = "Are  you sure you want to delete this Advertisement zone?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxUser.aspx",
                  {

                      Mode: "DELETEADVERTISEMENTZONE",
                      AdvertisementZoneID: pvarAdvertisementZoneID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {

                              toastr["success"]("Advertisement zone deleted successfully");
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
    $('#divProvince').hide();
    $('#tr_city').hide();
    $('#cmbCity').val("-1");
    $('#cmbCity').trigger('chosen:updated');   

    NProgress.done()
}

function showEditAdvertisementModel(pvarAdvertisementID) {

    mvarAdvertisementID = pvarAdvertisementID;

    $('#BtnSaveAdvertisement').hide();
    $('#BtnEditAdvertisement').show();
    $('#headerTitle').html("Edit Advertisement Zone");
    $('#modal-Add-Advertisement').show();

    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETADVERTISEMENTZONEDETAILS",
                AdvertisementZoneID: mvarAdvertisementID
            },

          function (VarResponseData) {

              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('AdvertisementData').each(function () {

                      if ($(this).find('Title').text() != "") {
                          $('#txtTitle').val($(this).find('Title').text());
                      }                      

                      if ($(this).find('Description').text() != "") {
                          $('#txtDescription').val($(this).find('Description').text());
                      }
                     
                      if ($(this).find('City').text() != "") {

                          $('#tr_city').show();

                          var cities = $(this).find('City').text();                          

                          var ArrCities = cities.split("##");
                         
                          var count = ArrCities.length;                         

                          $('#cmbCity').empty();
                          var opt = document.getElementById("cmbCity").options;

                          for (var i = 0; i < count; i++) {

                              var idAndText = ArrCities[i].split(","); 
                              opt[opt.length] = new Option(idAndText[0], idAndText[1]);
                          }

                          $("#cmbCity option").attr("selected", "selected");
                          $('#cmbCity').trigger('chosen:updated');                         
                      }
                      if ($(this).find('CbIsOpen').text() == "True") {
                          $("#CbIsOpen").attr("checked", true);
                      }
                      else {
                          $("#CbIsOpen").attr("checked", false);
                      }
                     
                     
                  });
              }); //end of Response   
          });                  //End of Ajax

    return false;
}

