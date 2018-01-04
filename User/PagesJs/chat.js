var mvarSenderID = -1;
var mvarReceiverId = -1;
var mvarGrpID = -1;

var mvargrp_name = ""; var mvargrp_by_user_id = ""; var mvargrp_img_url =""; var mvarprp_status = "", mvardate_time = "";
$(function () {
    getUnRdMessCounter();

    
});

function chatGetUsersSearch() {
   
    var varfullName = $('#search1').val();
    NProgress.start();
    $('#searchTargt').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATGETUSERSSEARCH",
                Full_Name : varfullName
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#searchTargt').empty();
                    $('#searchTargt').append(VarResponseData);
                   // $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#searchTargt').empty();
                    $('#searchTargt').append("No user found");
                    NProgress.done();
                }
                if (vOccupationID == 0) {
                    $('#searchTargt').empty();
                    $('#searchTargt').append("Please update your profile");
                    NProgress.done();
                    
                }



                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}
function chatGetUsersSingle() {
    
    NProgress.start();
    $('#chat_users_single_dev').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATGETUSERSSINGLE"
              
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#chat_users_single_dev').empty();
                    $('#chat_users_single_dev').append(VarResponseData);
                    // $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#chat_users_single_dev').empty();
                    $('#chat_users_single_dev').append("No user found");
                    NProgress.done();
                }
                if (vOccupationID == 0) {
                    $('#chat_users_single_dev').empty();
                    $('#chat_users_single_dev').append("Please update your profile");
                    NProgress.done();

                }

                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}
function chatGetUsersGroup() {

    NProgress.start();
    $('#chat_users_Group_dev').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATGETUSERSGROUP"

            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#chat_users_Group_dev').empty();
                    $('#chat_users_Group_dev').append(VarResponseData);
                    // $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#chat_users_Group_dev').empty();
                    $('#chat_users_Group_dev').append("No user found");
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}
function chat_create_group() {
    var varGrpName = $('#txtGrpName').val();
    var varGrpIconUrl = $('#fileUpload').val();
    if ($('#fileUpload').val() != '') {

        var varImgFileExtn = $('#fileUpload').val().substr($('#fileUpload').val().lastIndexOf("."), $('#fileUpload').val().length);

        if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
            alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 1');
            return false;
        }
    }


    $.ajaxFileUpload({
        url: 'dev/UploadProfilePics.ashx?Mode=UPLOADPROFILEPICS',
        secureuri: false,
        fileElementId: 'fileUpload',
        dataType: 'text',
        data: { name: 'logan', id: 'id' },
        success: function (data, status) {

            data = data.replace("<pre>", "").replace("<PRE>", "")
            data = data.replace("</pre>", "").replace("</PRE>", "")
            if (data.indexOf("SUCCESS") != -1) {
              
                $.post("Ajax_dev/chat.aspx",
                 {
                     
                     Mode: "CHATCREATEGROUP",
                     GrpName: varGrpName,
                     GrpIconUrl: data.split("##")[1]
                    
                 },
                 function (VarResponseData) {
                     if (VarResponseData != '-1') {
                         $("#createdGroup").fadeIn(600);
                         $("#createNewGrp").fadeOut(600);
                         mvarGrpID = VarResponseData;
                         get_chat_group_info(mvarGrpID);
                         get_chat_group_existing_member(mvarGrpID);
                         
                         NProgress.done();
                     }
                     else {
                         alert('Group with same name already exist!');
                       
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

    return false;
}
function chat_get_message(var_sender_id,var_destination_type, var_destination_id) {
   // alert(var_destination_type);
    NProgress.start();
    $('#chat_box_dev').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATGETMESSAGE",
                sender_id: var_sender_id,
                destination_type: var_destination_type,
                destination_id: var_destination_id
            },
            function (VarResponseData) {
                if (VarResponseData != "")
                {
                    $('#chat_box_dev').empty();
                    $('#chat_box_dev').append(VarResponseData);
                    getUnRdMessCounter();
                    NProgress.done();
                }
                else {
                    $('#chat_box_dev').empty();
                    $('#chat_box_dev').append("No user found");
                    NProgress.done();
                }
                var chatscrlID = document.getElementById('chatscrl');
                chatscrlID.scrollTop = chatscrlID.scrollHeight;
                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}

function chat_send_message(var_sender_id, var_destination_type, var_destination_id) {

    if ($('#chat_message_dev').val().trim() == '')
    {
        alert('Please enter message.');
        return false;
    }
    
   
    NProgress.start();
    $('#chat_box_dev').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'></span>");

    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATSENDMESSAGE",
                message: $('#chat_message_dev').val(),
                sender_id: var_sender_id,
                destination_type: var_destination_type,
                destination_id: var_destination_id
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#chat_message_dev').val('');
                    $('#chat_box_dev').empty();
                    chat_get_message(var_sender_id, var_destination_type, var_destination_id);
                   
                    NProgress.done();
                }
                else {
                    $('#chat_box_dev').empty();
                    chat_get_message(var_sender_id, var_destination_type, var_destination_id);
                    NProgress.done();
                }
                var chatscrlID = document.getElementById('chatscrl');
                chatscrlID.scrollTop = chatscrlID.scrollHeight;
                // TablesDatatables.init();
            });   //End of Ajax
   
    return false;
}

function chat_group_member_get_all(var_grp_id)
{
    
    NProgress.start();
    $('#GrpChtMbrModal').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATGROUPMEMBERGETALL" ,          
                Grp_ID: var_grp_id
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#GrpChtMbrModal').empty();
                    $('#GrpChtMbrModal').append(VarResponseData);
                    // $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#GrpChtMbrModal').empty();
                    $('#GrpChtMbrModal').append("No user found");
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}

function chat_group_edit_get_UsersSearch() {
    var varfullName = $('#edit_grp_chat_user_search').val();
    NProgress.start();
    $('#chat_grp_search_users_list').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATGRPGETUSERSSEARCH",
                Full_Name: varfullName
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#chat_grp_search_users_list').empty();
                    $('#chat_grp_search_users_list').append(VarResponseData);
                    // $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#chat_grp_search_users_list').empty();
                    $('#chat_grp_search_users_list').append("No user found");
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}
function chatGroupMemberAdd(var_grp_user_id) {
  
    NProgress.start();
    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATGROUPMEMBERADD",
                Grp_ID:mvarGrpID,
                Grp_User_ID: var_grp_user_id
                    
                    
            },
            function (VarResponseData) {
                if (VarResponseData == "1") {
                   // alert('Group member added successfully!');
                    chat_group_member_get_edit(mvarGrpID);
                    NProgress.done();
                }
                else {
                    alert('Not Added');
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}


function get_chat_group_info(var_grp_id) {

    NProgress.start();
    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "GETCHATGRPINFO",
                Grp_ID: var_grp_id
            },
         function (VarResponseData) {
             $(VarResponseData).find('Response').each(function () {
                 $(VarResponseData).find('UserData').each(function () {
                     if ($(this).find('grp_id').text() != "") {
                           mvarGrpID= $(this).find('grp_id').text();
                           
                     }
                     if ($(this).find('grp_name').text() != "") {
                         mvargrp_name = $(this).find('grp_name').text();
                     }
                     if ($(this).find('grp_by_user_id').text() != "") {
                         mvargrp_by_user_id = $(this).find('grp_by_user_id').text();
                     }
                     if ($(this).find('grp_img_url').text() != "") {
                         mvargrp_img_url = $(this).find('grp_img_url').text();
                     }
                     if ($(this).find('prp_status').text() != "") {
                         mvarprp_status = $(this).find('prp_status').text();
                     }
                     if ($(this).find('date_time').text() != "") {
                         mvardate_time = $(this).find('date_time').text();
                     }
                     try{
                         $("#grp_crt_img_url").attr("src", mvargrp_img_url);
                         $("#grp_crt_name").html(mvargrp_name);
                     }
                     catch(err)
                     {}
                 });
             }); 
             NProgress.done();
         });

    return false;
}

function get_chat_group_existing_member(var_grp_id)
{

    NProgress.start();
    $('#existingMemberdev').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "GETCHATGRPEXTMEM",
                Grp_ID: var_grp_id
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#existingMemberdev').empty();
                    $('#existingMemberdev').append(VarResponseData);
                    // $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#existingMemberdev').empty();
                    $('#existingMemberdev').append("No user found");
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}



function get_chat_group_Search_member() {
   
    var varfullName = $('#txt_grp_member_name_search').val();
    NProgress.start();
    $('#groupMemberSearchList').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {
                
                Mode: "GETCHATGRPSRCMEM",
                Full_Name: varfullName,
                Grp_ID: mvarGrpID
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#groupMemberSearchList').empty();
                    $('#groupMemberSearchList').append(VarResponseData);
                    NProgress.done();
                }
                else {
                    $('#groupMemberSearchList').empty();
                    $('#groupMemberSearchList').append("No user found");
                    NProgress.done();
                }
                
            });  

    return false;
}

function getchatGroupMemberAdd(var_grp_user_id) {
    chatGroupMemberAdd(var_grp_user_id);
    
    get_chat_group_Search_member();
    get_chat_group_existing_member(mvarGrpID);
}

function getchatGroupMemberAddextUp(var_grp_user_id) {
    chatGroupMemberAdd(var_grp_user_id);
    get_chat_group_Search_member();
    get_chat_group_existing_member(mvarGrpID);
}

function getUnRdMessCounter() {
    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "GETUNRDMESSCOUNTER"

            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#MessCounterChat').empty();
                    $('#MessCounterChat').append(VarResponseData);
                }
                else {
                    $('#MessCounterChat').empty();
                    $('#MessCounterChat').append("0");
                }
            });
    return false;
}

// Create new group Validation 

function validateChatForm() {
    var getUserval = document.getElementById("txtGrpName");
    if (getUserval.value != "") {
        document.getElementById('GrpBtn').disabled = false;
    } else {
        document.getElementById('GrpBtn').disabled = true;
    }
};

function chat_group_member_get_edit(var_grp_id) {
    mvarGrpID = var_grp_id;
    editGroupInfoGet(var_grp_id);
    edit_chat_group_existing_member(var_grp_id);
    edit_chat_group_member_search();
}

function editGroupInfoGet(var_grp_id)
{
    NProgress.start();
    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "GETCHATGRPINFO",
                Grp_ID: var_grp_id
            },
         function (VarResponseData) {
             $(VarResponseData).find('Response').each(function () {
                 $(VarResponseData).find('UserData').each(function () {
                     if ($(this).find('grp_id').text() != "") {
                          mvarGrpID= $(this).find('grp_id').text();

                     }
                     if ($(this).find('grp_name').text() != "") {
                         mvargrp_name = $(this).find('grp_name').text();
                     }
                     if ($(this).find('grp_by_user_id').text() != "") {
                         mvargrp_by_user_id = $(this).find('grp_by_user_id').text();
                     }
                     if ($(this).find('grp_img_url').text() != "") {
                         mvargrp_img_url = $(this).find('grp_img_url').text();
                     }
                     if ($(this).find('prp_status').text() != "") {
                         mvarprp_status = $(this).find('prp_status').text();
                     }
                     if ($(this).find('date_time').text() != "") {
                         mvardate_time = $(this).find('date_time').text();
                     }
                     try {
                         $("#EditGrpImg_url").attr("src", mvargrp_img_url);
                         $("#editGrpName").html(mvargrp_name);
                         $("#txt_editgroup_name").val(mvargrp_name)
                      
                         
                     }
                     catch (err)
                     { }
                 });
             });
             NProgress.done();
         });

    return false;

}

function edit_chat_group_existing_member(var_grp_id) {

    NProgress.start();
    $('#editExistingMembers').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");
    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "EDITCHATGRPEXTMEM",
                Grp_ID: var_grp_id
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#editExistingMembers').empty();
                    $('#editExistingMembers').append(VarResponseData);
                   
                    NProgress.done();
                }
                else {
                    $('#editExistingMembers').empty();
                    $('#editExistingMembers').append("No user found");
                    NProgress.done();
                }


              
            });   //End of Ajax

    return false;
}


function edit_chat_group_member_search() {

    var varfullName = $('#EditgroupMemberTobesearchtxt').val();
    NProgress.start();
    $('#Edit_chat_grp_Member_search_list').append("<span class=\"loader\"><img src='../E2Forums-New/img/loader.png' alt='Loading'> <br> Loading...</span>");

    $.post("Ajax_dev/chat.aspx",
            {

                Mode: "EDITCHATGRPSRCMEM",
                Full_Name: varfullName,
                Grp_ID: mvarGrpID
            },
            function (VarResponseData) {
                if (VarResponseData != "") {
                    $('#Edit_chat_grp_Member_search_list').empty();
                    $('#Edit_chat_grp_Member_search_list').append(VarResponseData);
                    NProgress.done();
                }
                else {
                    $('#Edit_chat_grp_Member_search_list').empty();
                    $('#Edit_chat_grp_Member_search_list').append("No user found");
                    NProgress.done();
                }

            });

    return false;
}


function edit_group_ext_member_status_upd(var_grp_user_id)
{
    editchatGroupMemberAdd(var_grp_user_id);
    edit_chat_group_member_search();
    edit_chat_group_existing_member(mvarGrpID);
}

function edit_grp_member_search_status_upd(var_grp_user_id)
{
   
    editchatGroupMemberAdd(var_grp_user_id);
    edit_chat_group_member_search();
    edit_chat_group_existing_member(mvarGrpID);
}


function editchatGroupMemberAdd(var_grp_user_id) {

    NProgress.start();
    
    $.post("Ajax_dev/chat.aspx",
            {
                Mode: "CHATGROUPMEMBERADD",
                Grp_ID: mvarGrpID,
                Grp_User_ID: var_grp_user_id
            },
            function (VarResponseData) {
                if (VarResponseData == "1") {
                    NProgress.done();
                }
                else {
                    alert('Not Added');
                    NProgress.done();
                }
            });   //End of Ajax

    return false;
}


function edit_chatgrp_info_update()
{
    var varImg = '';
    var varGrpName = '';
    if ($('#txt_editgroup_name').val() != '') {
        varGrpName = $('#txt_editgroup_name').val();
    } else {
        varGrpName = mvargrp_name;
    }

    var varGrpIconUrl = $('#Editfilename').val();
    if ($('#Editfilename').val() != '')
    {

                var varImgFileExtn = $('#Editfilename').val().substr($('#Editfilename').val().lastIndexOf("."), $('#Editfilename').val().length);

                if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
                    alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 1');
                    return false;
                }

                $.ajaxFileUpload({
                    url: 'dev/UploadProfilePics.ashx?Mode=UPLOADGRPFILEPICS',
                    secureuri: false,
                    fileElementId: 'Editfilename',
                    dataType: 'text',
                    data: { name: 'logan', id: 'id' },
                    success: function (data, status) {

                        data = data.replace("<pre>", "").replace("<PRE>", "")
                        data = data.replace("</pre>", "").replace("</PRE>", "")
                        if (data.indexOf("SUCCESS") != -1) {
                            if ($('#Editfilename').val() != '') {
                                varImg = data.split("##")[1];
                            } else {
                                varImg=mvargrp_img_url;
                            }
                                     $.post("Ajax_dev/chat.aspx",
                                       {

                                           Mode: "CHATUPDGROUP",
                                           GrpName: varGrpName,
                                           GrpIconUrl: varImg,
                                           Grp_ID: mvarGrpID

                                       },
                                       function (VarResponseData) {
                                           if (VarResponseData != '-1') {
                                               $('#txt_editgroup_name').val('');
                                               $('#Editfilename').val('');
                                               $('#GroupEdit').fadeOut();
                                               editGroupInfoGet(mvarGrpID);
                                               chatGetUsersGroup();
                                               NProgress.done();
                                           }
                                           else {
                                               alert('Group with same name already exist!');

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
        $.post("Ajax_dev/chat.aspx",
                                       {

                                           Mode: "CHATUPDGROUP",
                                           GrpName: varGrpName,
                                           GrpIconUrl: mvargrp_img_url,
                                           Grp_ID: mvarGrpID

                                       },
                                       function (VarResponseData) {
                                           if (VarResponseData != '-1') {
                                               $('#txt_editgroup_name').val('');
                                               $('#Editfilename').val('');
                                               $('#GroupEdit').fadeOut();
                                               editGroupInfoGet(mvarGrpID);
                                               chatGetUsersGroup();
                                               NProgress.done();
                                           }
                                           else {
                                               alert('Group with same name already exist!');

                                               NProgress.done();
                                           }
                                         

                                           // TablesDatatables.init();
                                       });   //End of Ajax
    }
    
   
  

    return false;
}



