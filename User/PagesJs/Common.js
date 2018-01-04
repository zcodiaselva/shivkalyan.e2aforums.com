$('button.close').click(function () {
    NProgress.start();

    $('#modal-regular-Profile').hide();
     NProgress.done();
});
function ShowProfileModal(pvarUserID) {
 
    NProgress.start();
    // $('#modal-Add-Topic').show();
   
    //$('#closeprofile').click();
   // $('#modal-regular-Profile').show();
   // $('modal-regular-Profile').addClass('modal');
    $('#modal-regular-Profile').show();
    //$('.close').click();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "VIEWUSERPROFILE",

                UserID: pvarUserID
            },

          function (VarResponseData) {
              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('UserData').each(function () {


                      if ($(this).find('Full_Name').text() != "") {
                          $('#p_name').html($(this).find('Full_Name').text());
                      }
                      if ($(this).find('Picture').text() != "") {
                          $('#profilepic').html($(this).find('Picture').text());
                      }
                      if ($(this).find('EMail').text() != "") {
                          $('#p_email').html($(this).find('EMail').text());
                      }
                     
                      if ($(this).find('Address_line1').text() != "") {
                          $('#p_address1').html($(this).find('Address_line1').text());
                      }
                      if ($(this).find('Address_Line2').text() != "") {
                          $('#p_address1').html($('#p_address1').html() + "<br/>" + $(this).find('Address_Line2').text());
                      }
                      if ($(this).find('Address_Line3').text() != "") {
                          $('#p_address1').html($('#p_address1').html() + "<br/>" + $(this).find('Address_Line3').text());
                      }
                      if ($(this).find('City').text() != "") {
                          $('#p_City').html($(this).find('City').text());
                      }
                      if ($(this).find('Organization').text() != "") {
                          $('#p_Organization').html($(this).find('Organization').text());
                      }
                      if ($(this).find('Mobile_Phone').text() != "") {
                          $('#p_Mobile').html($(this).find('Mobile_Phone').text());
                      }
                      if ($(this).find('Occupation').text() != "") {
                          $('#p_Occupation').html($(this).find('Occupation').text());
                      }
                      if ($(this).find('DealerName').text() != "") {
                          $('#p_DealerName').html($(this).find('DealerName').text());
                      }
                      if ($(this).find('MGA').text() != "") {
                          $('#p_MGA').html($(this).find('MGA').text());
                      }
                      if ($(this).find('GoverningBody').text() != "") {
                          $('#p_GoverningBody').html($(this).find('GoverningBody').text());
                      }
                      if ($(this).find('InBusinessSince').text() != "") {
                          $('#p_InBusinessSince').html($(this).find('InBusinessSince').text());
                      }

                      if ($(this).find('Designation').text() != "") {
                          $('#p_Designation').html($(this).find('Designation').text());
                      }
                      
                      if ($(this).find('AboutMe').text() != "") {
                          $('#lbl_aboutME').html($(this).find('AboutMe').text());
                      }
                      if ($(this).find('ProfileYoutubeURL').text() != "") {
                          $('#divYoutubeVideo').html($(this).find('ProfileYoutubeURL').text());
                      }
                  });

              }); //end of Response   
              NProgress.done();
          });                 //End of Ajax

    return false;
}
function ResetViewProfileModal() {

    $('#div_documents').hide();
    $('#Div_Basic').hide();
    $('#div_Payment').hide();
    $('#div_verification').hide();

}