var mvarSenderID = -1;
var mvarReceiverId = -1;
var mvarGrpID = -1;
var mvrtt_id = "",mvrtt_heading="", mvrtt_FileUrl=""; 
var mvargrp_name = ""; var mvargrp_by_user_id = ""; var mvargrp_img_url =""; var mvarprp_status = "", mvardate_time = "";
$(function () {
    
    TechTipsMemberAssignSearch();
});

function searchByNameAdmin()
{
    TechTipsMemberAssignSearch();
    TechTipsApproveSearch();
    // call Send For TechTips Approve
}


function TechTipsApproveSearch() {
    var varfullName = $('#searchFullNameTxt').val();

    NProgress.start();
    $('#techTipsApproveList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/techTipsJV.aspx",
            {
                Mode: "TECHTIPSAPVSRC",
                Full_Name: varfullName
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#techTipsApproveList').empty();
                    $('#techTipsApproveList').append(VarResponseData);
                    
                    NProgress.done();
                }
                else {
                    $('#techTipsApproveList').empty();
                    $('#techTipsApproveList').append("No user found");
                    NProgress.done();
                }
            });   

    return false;
}


function TechTipsApproveAction(strtt_id, strtt_status) {
    NProgress.start();
    $.post("Ajax_dev/techTipsJV.aspx",
            {
                Mode: "TECHTIPSAPPACT",
                tt_id: strtt_id,
                tt_status: strtt_status
            },
            function (VarResponseData) {
                if (VarResponseData == "1") {
                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Tech Tip  has been approved.</div>";
                    TechTipsApproveSearch();
                    NProgress.done();
                }
                else {
                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Tech Tips has been rejected.</div>";
                    TechTipsApproveSearch();
                    NProgress.done();
                }
            });
    return false;
}

function TechTipsGetAll() {
    
    NProgress.start();
    $('#techtipGetAll').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");
    $.post("Ajax_dev/techTipsJV.aspx",
            {
                Mode: "TECHTIPSGETALL"
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#techtipGetAll').empty();
                    $('#techtipGetAll').append(VarResponseData);
                 
                    NProgress.done();
                }
                else {
                    $('#techtipGetAll').empty();
                    $('#techtipGetAll').append("No user found");
                    NProgress.done();
                }

            });   //End of Ajax

    return false;
}

function techTipDelete(vartt_id) {
    var strconfirm = confirm("Are you sure you want to delete?");
    if (strconfirm == true) {
       
        $.post("Ajax_dev/techTipsJV.aspx",
                    {
                        Mode: "TECHTIPSDELETE",
                        tt_id: vartt_id
                        
                    },
                    function (VarResponseData) {
                        if (VarResponseData != '-1') {
                            document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Tech Tip has been deleted!.</div>";
                            TechTipsGetMy();
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

function TechTipsMemberAssignSearch() {
    var varfullName = $('#searchFullNameTxt').val();
    
    NProgress.start();
    $('#AssignTechTipsMemberList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/techTipsJV.aspx",
            {
                Mode: "TECHTIPSMEMASSSRC",
                Full_Name : varfullName
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#AssignTechTipsMemberList').empty();
                    $('#AssignTechTipsMemberList').append(VarResponseData);
                   // $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#AssignTechTipsMemberList').empty();
                    $('#AssignTechTipsMemberList').append("No user found");
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}

function TechTipsMemberAssign(var_tt_user_id) {
    NProgress.start();
    $.post("Ajax_dev/techTipsJV.aspx",
            {
                Mode: "TECHTIPSMEMBERASSIGN",
                tt_user_id: var_tt_user_id
            },
            function (VarResponseData) {
                if (VarResponseData == "1" || VarResponseData == "2" ||  VarResponseData == "3") {

                    if (VarResponseData == "1")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Tech Tip Authorization is Successful !</div>";
                    else if (VarResponseData == "2")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Tech Tip Authorization is Revoked !</div>";
                    else if (VarResponseData == "3")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Tech Tip Authorization is Successful ! </div>";
                    TechTipsMemberAssignSearch();
                    NProgress.done();
                }
                else {
                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Tech Tip Authorization is not successful ! </div>";
                    NProgress.done();
                }
            });   

    return false;
}

function TechTipsMemberAssignCheck(var_tt_user_id) {
    NProgress.start();
    $.post("Ajax_dev/techTipsJV.aspx",
            {
                Mode: "TECHTIPSMEMBERASSIGNCHK",
                tt_user_id: var_tt_user_id
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

function TechTips_send() {
    var varTechTipHeading = $('#techTipFileHeading').val();
    var varTechTipsFileUrl = $('#fileUpload').val();
    if ($('#fileUpload').val() != '') {

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

                    $.post("Ajax_dev/techTipsJV.aspx",
                     {
                         Mode: "TECHTIPSSEND",
                         tt_heading: varTechTipHeading,
                         tt_file_url: data.split("##")[1]
                     },
                     function (VarResponseData) {
                         if (VarResponseData != '-1') {
                             $('#techTipFileHeading').val('');
                             $('#fileUpload').val('');
                             document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Tech Tip has been  Sent !</div>";
                             TechTipsGetMy();
                             NProgress.done();
                         }
                         else {
                             document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Tech Tip not sent! !</div>";
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

function TechTipsGetMy() {
    NProgress.start();
    $('#MytechtipsList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/techTipsJV.aspx",
            {
                Mode: "TECHTIPSGETMY"
               
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#MytechtipsList').empty();
                    $('#MytechtipsList').append(VarResponseData);
                   
                    NProgress.done();
                }
                else {
                    $('#MytechtipsList').empty();
                    $('#MytechtipsList').append("No user found");
                    NProgress.done();
                }
            });   

    return false;
}


function techTips_get_edit(var_tt_id,vartt_heading,vartt_file) {
    mvrtt_id = var_tt_id;
    mvrtt_heading = vartt_heading;
    mvrtt_FileUrl = vartt_file;

    $('#txt_edittt_heading').val(mvrtt_heading);
    
}

function tech_tip_info_update() {
    var varImg = '';
    var varHeading = '';
    if ($('#txt_edittt_heading').val() != '') {
        varHeading = $('#txt_edittt_heading').val();
    } else {
        varHeading = mvrtt_heading;
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
                     
                   
                    $.post("Ajax_dev/techTipsJV.aspx",
                      {

                          Mode: "TECHTIPSUPD",
                          tt_heading: varHeading,
                          tt_file_url: varImg,
                          tt_id: mvrtt_id

                      },
                      function (VarResponseData) {
                          if (VarResponseData != '-1') {
                              $('#txt_edittt_heading').val('');
                              $('#Editfilename').val('');
                              document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong>Tech Tip has been  Updated !.</div>";
                              $('#editTipTech').fadeOut();
                              TechTipsGetAll();
                              TechTipsGetMy();
                              NProgress.done();
                          }
                          else {
                              document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Tech Tip  with same heading already exist!</div>";
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
        $.post("Ajax_dev/techTipsJV.aspx",
                                       {

                                           Mode: "TECHTIPSUPD",
                                           tt_heading: varHeading,
                                           tt_file_url: mvrtt_FileUrl,
                                           tt_id: mvrtt_id

                                       },
                                       function (VarResponseData) {
                                           if (VarResponseData != '-1') {
                                               $('#txt_edittt_heading').val('');
                                               $('#Editfilename').val('');
                                               document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Tech Tip has been  Updated !.</div>";
                                               $('#editTipTech').fadeOut();
                                               TechTipsGetAll();
                                               TechTipsGetMy();
                                               NProgress.done();
                                           }
                                           else {
                                               document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Tech Tip  with same heading already exist!</div>";
                                               NProgress.done();
                                           }


                                           // TablesDatatables.init();
                                       });   //End of Ajax
    }




    return false;
}


