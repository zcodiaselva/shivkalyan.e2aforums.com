var mvarTopicID = -1;
var varCategoryID = -1;

$(function () {
    $('button.close').click(function () {
        NProgress.start();
       
        $('#modal-Add-Topic').hide();
        document.forms["form_Topic"].reset();

        $('#BtnSaveTopic').show();
        $('#BtnEditTopic').hide();
       // $('#cmb_CategoryFilter').val(-1);
        $('#headerTitle').html("Add Topic")
        NProgress.done();
    });
    $('#Topic-a').addClass("active");
   // GetTopicListing();
  FillCategoryCombo();
  FillCategoryComboFilter();

    $('#form_Topic').validate({

        highlight: function (e) {
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            // You can use the following if you would like to highlight with green color the input after successful validation!
            e.closest('.form-group').removeClass('has-success has-error'); // e.closest('.form-group').removeClass('has-success has-error').addClass('has-success');
            e.closest('.help-block').remove();
        },
        rules: {
            txtTitle: {
                required: true
            },
            txtDesc: {
                required: true
            },
            cmb_Categories: {
                required: true,
                chosen: true
    }
        },
        messages: {
            txtTitle:
                {
                    required: 'Please enter title '
                },
            txtDesc:
              {
                  required: 'Please enter Description '
              },
            cmb_Categories: {
                required: 'Please select any Category'
            }
        }

    });


    $('#BtnSaveTopic').click(function () {
        if ($('#form_Topic').valid()) {
            AddNewTopic();

        } else {
            //alert('provide email and password to conitnue..');
            return false;
        }
    });
    $('#BtnEditTopic').click(function () {
        if ($('#form_Topic').valid()) {
            AddNewTopic();

        } else {
            //alert('provide email and password to conitnue..');
            return false;
        }
    });
});

function GetTopicListing(varFlag) {
  
    if (varFlag == true) {
        varCategoryID = $("#cmb_CategoryFilter").val();
    }
    else {
        varCategoryID = -1;
    }
    $("#TblTopic").empty();
    $("#TblTopic").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETTOPICLISTING&CategoryID=' + varCategoryID,
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Topics', name: 'Topic', width: 280, sortable: false, align: 'left' },
                { display: 'Replies', name: 'Replies', width: 70, sortable: false, align: 'left' },
                { display: 'Views ', name: 'TopicView', width: 70, sortable: false, align: 'left' },
                { display: 'Last Post', name: 'LastPostUser', width: 100, sortable: false, align: 'left' },
                { display: 'Action', width: 160, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "TopicID",
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

function DeleteTopic(pvarTopicID) {
   
    var varApproved = "Are  you sure you want to delete this topic and its posts?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxUser.aspx",
                  {

                      Mode: "DELETETOPIC",
                      TopicID: pvarTopicID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {
                              document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Topic has been deleted .</div>";
                           
                              GetTopicListing(true);
                              //window.location.reload();
                          }
                      }


                  });
    }
    return false;

}

function FillCategoryCombo() {
   // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            { Mode: "FILLCATEGORYCOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#cmb_Categories').empty();
                           var opt = document.getElementById("cmb_Categories").options;
                           opt[opt.length] = new Option('All', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('CategoryID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('CategoryID').text());
                               }
                           }); // end of Contents
                          
                           $('#cmb_Categories').trigger('chosen:updated');
                         

                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}

function showEditTopicModel(pvarTopicID) {

    mvarTopicID = pvarTopicID
    $('#modal-Add-Topic').addClass('modal');
    $('#BtnSaveTopic').hide();
    $('#BtnEditTopic').show();
    $('#headerTitle').html("Edit Topic");
   // $('#modal-Add-Topic').show();
    $('#btnAddTopic').click();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETTOPICDETAILS",
                TopicID: mvarTopicID
            },

          function (VarResponseData) {

              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('TopicData').each(function () {

                      if ($(this).find('Title').text() != "") {
                          $('#txtTitle').val($(this).find('Title').text());
                      }
                      if ($(this).find('Description').text() != "") {
                          $('#txtDesc').val($(this).find('Description').text());
                      }
                      if ($(this).find('CategoryID').text() != "") {

                          $('#cmb_Categories').val($(this).find('CategoryID').text());
                          $('#cmb_Categories').trigger('chosen:updated');
                      }

                  });
              }); //end of Response   
          });                  //End of Ajax

            return false;
}
function ResetForm() {
    if (varCategoryID == -1) {

        $('#cmb_Categories').val(varCategoryID);
        $('#cmb_Categories').trigger('chosen:updated');
    }
    else {

        $('#cmb_Categories').val(varCategoryID);
        $('#cmb_Categories').trigger('chosen:updated');
    }
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    document.forms["form_Topic"].reset();

}
function AddNewTopic() {
    var varIsFlagged = "";
    if (varCategoryID == -1)
    {
        varCategoryID = $('#cmb_Categories').val();
    }
    if ($("#Topic_IsFlagged").attr("checked", false)) {
        varIsFlagged="False"
    }
    else {
        varIsFlagged = "True"
    }
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "ADDNEWTOPIC",
                Title: $('#txtTitle').val(),
                Description: $('#txtDesc').val(),
                CategoryID: varCategoryID,
                TopicID: mvarTopicID,
                IsFlagged: varIsFlagged
            },
                function (VarResponseData) {
                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                        if (mvarTopicID == -1) {
                            toastr.options = { "onHidden": function () { $('.close').click(); GetTopicListing(true); } };
                            $('.close').click();
                            document.forms["form_Topic"].reset();
                            document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Topic has been added.</div>";
                            $('#form_Topic').fadeOut();
                            GetTopicListing(true);
                            mvarTopicID = -1;
                       
                        }
                        else {
                            toastr.options = { "onHidden": function () { $('.close').click(); GetTopicListing(true); } };
                            $('.close').click();
                            document.forms["form_Topic"].reset();
                            document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Topic has been updated.</div>";
                            $('#form_Topic').fadeOut();
                            GetTopicListing(true);
                            mvarTopicID = -1;
                            
                        }
                      
                    }
                    else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                        document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Topic Name already exists !</div>";
                       
                    }
                });


                return false;
                   
}


function FillCategoryComboFilter() {
    NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            { Mode: "FILLCATEGORYCOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#cmb_CategoryFilter').empty();
                           var opt = document.getElementById("cmb_CategoryFilter").options;
                           opt[opt.length] = new Option('All', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('CategoryID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('CategoryID').text());
                               }
                           }); // end of Contents

                           if (varCategoryID != -1)
                               $('#cmb_CategoryFilter').val(varCategoryID);
                           $('#cmb_CategoryFilter').trigger('chosen:updated');
                        
                           if (varCategoryID == -1)
                              
                               GetTopicListing(false);
                           else
                               GetTopicListing(true);
                           NProgress.done();
                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}