var mvarSenderID = -1;
var mvarReceiverId = -1;
var mvarGrpID = -1;
var mvrnn_id = "",mvrnn_heading="", mvrnn_FileUrl=""; 
var mvargrp_name = ""; var mvargrp_by_user_id = ""; var mvargrp_img_url =""; var mvarprp_status = "", mvardate_time = "";


function searchByNameAdmin()
{
    newsLetterMemberAssignSearch();
    newsLetterApproveSearch();
    // call Send For NewsLetter Approve
}


function newsLetterApproveSearch() {
    var varfullName = $('#searchFullNameTxt').val();

    NProgress.start();
    $('#NewsLetterApproveList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/NewsLetterJV.aspx",
            {
                Mode: "NEWSLETTERAPVSRC",
                Full_Name: varfullName
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#NewsLetterApproveList').empty();
                    $('#NewsLetterApproveList').append(VarResponseData);
                    
                    NProgress.done();
                }
                else {
                    $('#NewsLetterApproveList').empty();
                    $('#NewsLetterApproveList').append("No Newsletter found for Approval.");
                    NProgress.done();
                }
            });   

    return false;
}

function newsLetterApproveAction(strnn_id, strnn_status) {
    NProgress.start();
    $.post("Ajax_dev/NewsLetterJV.aspx",
            {
                Mode: "NEWSLETTERAPPACT",
                nn_id: strnn_id,
                nn_status: strnn_status
            },
            function (VarResponseData) {
                if (VarResponseData != '-1') {
                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Newsletter has been approved.</div>";
                    newsLetterApproveSearch();
                    NProgress.done();
                }
                else {
                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Newsletter has been rejected.</div>";
                    newsLetterApproveSearch(); 
                    NProgress.done();
                }
            });
    return false;
}

function newsLetterGetAll() {
    
    NProgress.start();
    $('#NewsLetterGetAll').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");
    $.post("Ajax_dev/NewsLetterJV.aspx",
            {
                Mode: "NEWSLETTERGETALL"
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#NewsLetterGetAll').empty();
                    $('#NewsLetterGetAll').append(VarResponseData);
                 
                    NProgress.done();
                }
                else {
                    $('#NewsLetterGetAll').empty();
                    $('#NewsLetterGetAll').append("No Newsletter found.");
                    NProgress.done();
                }

            });   //End of Ajax

    return false;
}

function newsLetterDelete(varnn_id) {
    var strconfirm = confirm("Are you sure you want to delete?");
    if (strconfirm == true) {
       
        $.post("Ajax_dev/NewsLetterJV.aspx",
                    {
                        Mode: "NEWSLETTERDELETE",
                        nn_id: varnn_id
                        
                    },
                    function (VarResponseData) {
                        if (VarResponseData != '-1') {
                            document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Newsletter has been deleted!.</div>";
                            newsLetterGetMy();
                            NProgress.done();
                        }
                        else {
                            NProgress.done();
                        }
                    });   

    }
    else {
        alert('not Deleted');
    }
}

function newsLetterMemberAssignSearch() {
    
    var varfullName = $('#searchFullNameTxt').val();
   
    NProgress.start();
    $('#AssignNewsLetterMemberList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/NewsLetterJV.aspx",
            {
                Mode: "NEWSLETTERMEMASSSRC",
                Full_Name : varfullName
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#AssignNewsLetterMemberList').empty();
                    $('#AssignNewsLetterMemberList').append(VarResponseData);
                  
                    NProgress.done();
                }
                else {
                    $('#AssignNewsLetterMemberList').empty();
                    $('#AssignNewsLetterMemberList').append("No user found");
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}

function newsLetterMemberAssign(var_nn_user_id) {
    NProgress.start();
    $.post("Ajax_dev/NewsLetterJV.aspx",
            {
                Mode: "NEWSLETTERMEMBERASSIGN",
                nn_user_id: var_nn_user_id
            },
            function (VarResponseData) {
                if (VarResponseData == "1" || VarResponseData == "2" ||  VarResponseData == "3") {
                    if (VarResponseData == "1")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Newsletter Authorization is Successful !</div>";
                    else if (VarResponseData == "2")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Newsletter Authorization is Revoked !</div>";
                    else if (VarResponseData == "3")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Newsletter Authorization is Successful ! </div>";
                    newsLetterMemberAssignSearch();
                    NProgress.done();
                }
                else {
                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Newsletter Authorization is not successful ! </div>";

                    NProgress.done();
                }
                
            });   

    return false;
}

function newsLetterMemberAssignCheck(var_nn_user_id) {
    NProgress.start();
    $.post("Ajax_dev/NewsLetterJV.aspx",
            {
                Mode: "NEWSLETTERMEMBERASSIGNCHK",
                nn_user_id: var_nn_user_id
            },
            function (VarResponseData) {
                if (VarResponseData == "1") {
                    $("#addPost").show();
                    NProgress.done();
                }
                else {
                    $("#addPost").hide();
                    NProgress.done();
                }
            }); 
    return false;
}

function newsLetter_send() {
    var varTechTipHeading = $('#newsLetterFileHeading').val();
    var varNewsLetterFileUrl = $('#fileUpload').val();
    if ($('#fileUpload').val()  != '') {

        $.ajaxFileUpload({
            url: 'dev/UploadProfilePics.ashx?Mode=UPLOADTECHTIPSNEW',
            secureuri: false,
            fileElementId: 'fileUpload',
            dataType: 'text',
            data: { name: 'logan', id: 'id' },
            success: function (data, status) {

                data = data.replace("<pre>", "").replace("<PRE>", "")
                data = data.replace("</pre>", "").replace("</PRE>", "")
                if (data.indexOf("SUCCESS") != -1) {

                    $.post("Ajax_dev/NewsLetterJV.aspx",
                     {
                         Mode: "NEWSLETTERSEND",
                         nn_heading: varTechTipHeading,
                         nn_file_url: data.split("##")[1]
                     },
                     function (VarResponseData) {
                         if (VarResponseData != '-1') {
                             document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Newsletter has been  Sent !.</div>";
                             newsLetterGetMy();
                             NProgress.done();
                         }
                         else {
                             document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Newsletter Not sent! !.</div>";
                             NProgress.done();
                         }
                         // TablesDatatables.init();
                     });   //End of Ajax



                }

            },
            error: function (data, status, e) {
                alert(e);
                NProgress.done();

            }
        }
         );
    }
    else {
        alert('Select File First !');
    }
    return false;
}

function newsLetterGetMy() {
    NProgress.start();
    $('#MyNewsLetterList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/NewsLetterJV.aspx",
            {
                Mode: "NEWSLETTERGETMY"
               
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#MyNewsLetterList').empty();
                    $('#MyNewsLetterList').append(VarResponseData);
                   
                    NProgress.done();
                }
                else {
                    $('#MyNewsLetterList').empty();
                    $('#MyNewsLetterList').append("No Newsletter found");
                    NProgress.done();
                }
            });   

    return false;
}


function newsLetter_get_edit(var_nn_id,varnn_heading,varnn_file) {
    mvrnn_id = var_nn_id;
    mvrnn_heading = varnn_heading;
    mvrnn_FileUrl = varnn_file;

    $('#txt_editnn_heading').val(mvrnn_heading);
    
}

function newsLetter_info_update() {
    var varImg = '';
    var varHeading = '';
    if ($('#txt_editnn_heading').val() != '') {
        varHeading = $('#txt_editnn_heading').val();
    } else {
        varHeading = mvrnn_heading;
    }

  
    var varGrpIconUrl = $('#Editfilename').val();
   
   
    if ($('#Editfilename').val() != '') {
       
        $.ajaxFileUpload({
            url: 'dev/UploadProfilePics.ashx?Mode=UPLOADTECHTIPS',
            secureuri: false,
            fileElementId: 'Editfilename',
            dataType: 'text',
            data: { name: 'logan', id: 'id' },
            success: function (data, status) {

                data = data.replace("<pre>", "").replace("<PRE>", "")
                data = data.replace("</pre>", "").replace("</PRE>", "")
                if (data.indexOf("SUCCESS") != -1) {
                   
                        varImg = data.split("##")[1];
                     
                   
                    $.post("Ajax_dev/NewsLetterJV.aspx",
                      {

                          Mode: "NEWSLETTERUPD",
                          nn_heading: varHeading,
                          nn_file_url: varImg,
                          nn_id: mvrnn_id

                      },
                      function (VarResponseData) {
                          if (VarResponseData != '-1') {
                              $('#txt_editnn_heading').val('');
                              $('#Editfilename').val('');
                              document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Newsletter has been  Updated !.</div>";
                              $('#editTipTech').fadeOut();
                              newsLetterGetAll();
                              newsLetterGetMy();
                              NProgress.done();
                          }
                          else {
                             
                              document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Newsletter with same heading already exist! .</div>";
                              NProgress.done();
                          }


                          // TablesDatatables.init();
                      });   //End of Ajax
                }

            },
            error: function (data, status, e) {
                alert(e);
                NProgress.done();

            }
        }
    );
    }
    else {
        $.post("Ajax_dev/NewsLetterJV.aspx",
                                       {

                                           Mode: "NEWSLETTERUPD",
                                           nn_heading: varHeading,
                                           nn_file_url: mvrnn_FileUrl,
                                           nn_id: mvrnn_id

                                       },
                                       function (VarResponseData) {
                                           if (VarResponseData != '-1') {
                                               $('#txt_editnn_heading').val('');
                                               $('#Editfilename').val('');
                                               document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Newsletter has been  Updated !.</div>";
                                               $('#editTipTech').fadeOut();
                                               newsLetterGetAll();
                                               newsLetterGetMy();
                                               NProgress.done();
                                           }
                                           else {
                                              
                                               document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Newsletter with same heading already exist!.</div>";
                                               NProgress.done();
                                           }


                                           // TablesDatatables.init();
                                       });   //End of Ajax
    }




    return false;
}


