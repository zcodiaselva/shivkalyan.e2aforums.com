var mvarSenderID = -1;
var mvarReceiverId = -1;
var mvarGrpID = -1;
var mvrln_id = "",mvrln_heading="", mvrln_FileUrl=""; 
var mvargrp_name = ""; var mvargrp_by_user_id = ""; var mvargrp_img_url =""; var mvarprp_status = "", mvardate_time = "";
$(function () {
    
   
});

function searchByNameAdmin()
{
    latestNewsMemberAssignSearch();
    latestNewsApproveSearch();
    // call Send For latestNews Approve
}


function latestNewsApproveSearch() {
    var varfullName = $('#searchFullNameTxt').val();

    NProgress.start();
    $('#latestNewsApproveList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/LatestNewsJV.aspx",
            {
                Mode: "LATESTNEWSAPVSRC",
                Full_Name: varfullName
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#latestNewsApproveList').empty();
                    $('#latestNewsApproveList').append(VarResponseData);
                    
                    NProgress.done();
                }
                else {
                    $('#latestNewsApproveList').empty();
                    $('#latestNewsApproveList').append("No Latest News found for Approval.");
                    NProgress.done();
                }
            });   

    return false;
}


function latestNewsApproveAction(strln_id, strln_status) {
    NProgress.start();
    $.post("Ajax_dev/LatestNewsJV.aspx",
            {
                Mode: "LATESTNEWSAPPACT",
                ln_id: strln_id,
                ln_status: strln_status
            },
            function (VarResponseData) {
                if (VarResponseData != '-1') {
                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Latest News has been approved.</div>";
                    latestNewsApproveSearch();
                    NProgress.done();
                }
                else {
                    document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Latest News has been rejected.</div>";
                    latestNewsApproveSearch();
                    NProgress.done();
                }
            });
    return false;
}

function latestNewsGetAll() {
    
    NProgress.start();
    $('#latestNewsGetAll').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");
    $.post("Ajax_dev/LatestNewsJV.aspx",
            {
                Mode: "LATESTNEWSGETALL"
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#latestNewsGetAll').empty();
                    $('#latestNewsGetAll').append(VarResponseData);
                 
                    NProgress.done();
                }
                else {
                    $('#latestNewsGetAll').empty();
                    $('#latestNewsGetAll').append("No Latest News found.");
                    NProgress.done();
                }

            });   //End of Ajax

    return false;
}

function latestNewsDelete(varln_id) {
    var strconfirm = confirm("Are you sure you want to delete?");
    if (strconfirm == true) {
       
        $.post("Ajax_dev/LatestNewsJV.aspx",
                    {
                        Mode: "LATESTNEWSDELETE",
                        ln_id: varln_id
                        
                    },
                    function (VarResponseData) {
                        if (VarResponseData != '-1') {
                            document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Latest News has been deleted!.</div>";
                            latestNewsGetMy();
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

function latestNewsMemberAssignSearch() {
    var varfullName = $('#searchFullNameTxt').val();
    
    NProgress.start();
    $('#AssignlatestNewsMemberList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/LatestNewsJV.aspx",
            {
                Mode: "LATESTNEWSMEMASSSRC",
                Full_Name : varfullName
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#AssignlatestNewsMemberList').empty();
                    $('#AssignlatestNewsMemberList').append(VarResponseData);
                   // $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#AssignlatestNewsMemberList').empty();
                    $('#AssignlatestNewsMemberList').append("No user found");
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}

function latestNewsMemberAssign(var_ln_user_id) {
    NProgress.start();
    $.post("Ajax_dev/LatestNewsJV.aspx",
            {
                Mode: "LATESTNEWSMEMBERASSIGN",
                ln_user_id: var_ln_user_id
            },
            function (VarResponseData) {
                if (VarResponseData == "1" || VarResponseData == "2" ||  VarResponseData == "3") {
                    if (VarResponseData == "1")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Latest News Authorization is Successful !</div>";
                    else if (VarResponseData == "2")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Latest News Authorization is Revoked !</div>";
                    else if (VarResponseData == "3")
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Latest News Authorization is Successful ! </div>";
                
                    latestNewsMemberAssignSearch();
                    NProgress.done();
                }
                else {
                    alert('Not Added');
                    NProgress.done();
                }
                
            });   

    return false;
}

function latestNewsMemberAssignCheck(var_ln_user_id) {
    NProgress.start();
    $.post("Ajax_dev/LatestNewsJV.aspx",
            {
                Mode: "LATESTNEWSMEMBERASSIGNCHK",
                ln_user_id: var_ln_user_id
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

function latestNews_send() {
    var varTechTipHeading = $('#latestNewsFileHeading').val();
    var varlatestNewsFileUrl = $('#fileUpload').val();
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

                    $.post("Ajax_dev/LatestNewsJV.aspx",
                     {
                         Mode: "LATESTNEWSSEND",
                         ln_heading: varTechTipHeading,
                         ln_file_url: data.split("##")[1]
                     },
                     function (VarResponseData) {
                         if (VarResponseData != '-1') {
                             document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Latest News has been  Sent !.</div>";
                             latestNewsGetMy();
                             NProgress.done();
                         }
                         else {
                             document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Latest News Not sent! !.</div>";
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

function latestNewsGetMy() {
    NProgress.start();
    $('#MylatestNewsList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/LatestNewsJV.aspx",
            {
                Mode: "LATESTNEWSGETMY"
               
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#MylatestNewsList').empty();
                    $('#MylatestNewsList').append(VarResponseData);
                   
                    NProgress.done();
                }
                else {
                    $('#MylatestNewsList').empty();
                    $('#MylatestNewsList').append("No Latest News found");
                    NProgress.done();
                }
            });   

    return false;
}


function latestNews_get_edit(var_ln_id,varln_heading,varln_file) {
    mvrln_id = var_ln_id;
    mvrln_heading = varln_heading;
    mvrln_FileUrl = varln_file;

    $('#txt_editln_heading').val(mvrln_heading);
    
}

function latestNews_info_update() {
    var varImg = '';
    var varHeading = '';
    if ($('#txt_editln_heading').val() != '') {
        varHeading = $('#txt_editln_heading').val();
    } else {
        varHeading = mvrln_heading;
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
                     
                   
                    $.post("Ajax_dev/LatestNewsJV.aspx",
                      {

                          Mode: "LATESTNEWSUPD",
                          ln_heading: varHeading,
                          ln_file_url: varImg,
                          ln_id: mvrln_id

                      },
                      function (VarResponseData) {
                          if (VarResponseData != '-1') {
                              $('#txt_editln_heading').val('');
                              $('#Editfilename').val('');
                              document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Latest News has been  Updated !.</div>";
                              $('#editTipTech').fadeOut();
                              latestNewsGetAll();
                              latestNewsGetMy();
                              NProgress.done();
                          }
                          else {

                              document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Latest News with same heading already exist! .</div>";

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
        $.post("Ajax_dev/LatestNewsJV.aspx",
                                       {

                                           Mode: "LATESTNEWSUPD",
                                           ln_heading: varHeading,
                                           ln_file_url: mvrln_FileUrl,
                                           ln_id: mvrln_id

                                       },
                                       function (VarResponseData) {
                                           if (VarResponseData != '-1') {
                                               $('#txt_editln_heading').val('');
                                               $('#Editfilename').val('');
                                               document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-warning'></i> Success ! ,</strong> Latest News has been  Updated !.</div>";
                                               $('#editTipTech').fadeOut();
                                               latestNewsGetAll();
                                               latestNewsGetMy();
                                               NProgress.done();
                                           }
                                           else {
                                               document.getElementById("outputMessage").innerHTML = "<div class='alert alert-success'>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong><i class='fa fa-danger'></i> Error ! ,</strong> Latest News with same heading already exist!.</div>";

                                               NProgress.done();
                                           }


                                           // TablesDatatables.init();
                                       });   //End of Ajax
    }




    return false;
}


