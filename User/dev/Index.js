var mvarUserID = -1;

$(function () {
    
    NProgress.start();
    GetIndexCount();
  
});

function GetIndexCount() {

    NProgress.start();

    console.log("1");

    $.post("Ajax_dev/A_index.aspx",
    {
        Mode: "GETINDEXCOUNT"

    },
  function (VarResponseData) {

      //alert(VarResponseData);


      //console.log("hello1234");
      $(VarResponseData).find('Response').each(function () {
          $(VarResponseData).find('AdminData').each(function () {
              var val_total = "";
              console.log("hello");

              console.log($(this).find('Full_Name').text());
              if ($(this).find('TotalThread').text() != "") {
                  $('#s_thread').html($(this).find('TotalThread').text());
                  $('#s_thread').attr('readonly', 'readonly');
              } else
                  $("#s_thread").html('-');
              
              if ($(this).find('TotalMessage').text() != "") {
                  $('#s_message').html($(this).find('TotalMessage').text());
                  $('#s_message').attr('readonly', 'readonly');
                  $('#s_message2').html($(this).find('TotalMessage').text());
                  $('#s_message2').attr('readonly', 'readonly');
              }
              else
                  $("#s_message").html('-');

              if ($(this).find('TotalEvent').text() != "") {
                  $('#s_event').html($(this).find('TotalEvent').text());
                  $('#s_event').attr('readonly', 'readonly');
              }
              else
                  $("#s_event").html('-');

            
              if ($(this).find('TotalCust').text() != "") {
                  $('.totalCust').html($(this).find('TotalCust').text());
                  $('.totalCust').attr('readonly', 'readonly');
                  val_total = parseFloat( $(this).find('TotalCust').text());

                 
              }
              else
                  $(".totalCust").html('-');

              if ($(this).find('TotalCustOpen').text() != "") {
                  $('#TotalCustOpen').html($(this).find('TotalCustOpen').text());
                  $('#TotalCustOpen').attr('readonly', 'readonly');

                  var act_val =(parseFloat($(this).find('TotalCustOpen').text())*100)/val_total;
                  $("#TotalCustOpenDiv").css("width", act_val+"%");
              }
              else
                  $("#TotalCustOpen").html('-');

              if ($(this).find('TotalCustPre').text() != "") {
                  $('#TotalCustPre').html($(this).find('TotalCustPre').text());
                  $('#TotalCustPre').attr('readonly', 'readonly');

                  var act_val = (parseFloat($(this).find('TotalCustPre').text()) * 100) / val_total;
                  $("#TotalCustPreDiv").css("width", act_val + "%");
              }
              else
                  $("#TotalCustPre").html('-');


              if ($(this).find('TotalCustQualified').text() != "") {
                  $('#TotalCustQualified').html($(this).find('TotalCustQualified').text());
                  $('#TotalCustQualified').attr('readonly', 'readonly');

                  var act_val = (parseFloat($(this).find('TotalCustQualified').text()) * 100) / val_total;
                  $("#TotalCustQualifiedDiv").css("width", act_val + "%");
              }
              else
                  $("#TotalCustQualified").html('-');

              if ($(this).find('TotalCustDisqualified').text() != "") {
                  $('#TotalCustDisqualified').html($(this).find('TotalCustDisqualified').text());
                  $('#TotalCustDisqualified').attr('readonly', 'readonly');

                  var act_val = (parseFloat($(this).find('TotalCustDisqualified').text()) * 100) / val_total;
                  $("#TotalCustDisqualifiedDiv").css("width", act_val + "%");
              }
              else
                  $("#TotalCustDisqualified").html('-');

              if ($(this).find('TotalCustClosed').text() != "") {
                  $('#TotalCustClosed').html($(this).find('TotalCustClosed').text());
                  $('#TotalCustClosed').attr('readonly', 'readonly');

                  var act_val = (parseFloat($(this).find('TotalCustClosed').text()) * 100) / val_total;
                  $("#TotalCustClosedDiv").css("width", act_val + "%");
              }
              else
                  $("#TotalCustClosed").html('-');

              if ($(this).find('TotalNot').text() != "") {
                  $('#NotificationCount').html($(this).find('TotalNot').text());
                  $('#NotificationCount').attr('readonly', 'readonly');
              }
              else
                  $("#NotificationCount").html('0');

              if ($(this).find('count_event').text() != "") {
                  $('#lbl_alert_count').html($(this).find('count_event').text());
                  $('#lbl_alert_count').attr('readonly', 'readonly');
              }
              else
                  $("#lbl_alert_count").html('0');
              


          });

      }); //end of Response 
      NProgress.done();

  }); //End of Ajax
}
      
