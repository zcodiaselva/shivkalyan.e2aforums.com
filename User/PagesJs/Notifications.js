var mvarRecevierID = -1;
var mvarReferenceID = -1;
var mvarNotificationType = "";
var varCategoryID = -1;
var varTopicID = -1;

function CViewNotifications(mvarReferenceID, mvarNotificationType, pvarNotificationID) {
 
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "VIEWNOTIFICATIONS",
                ReferenceID: mvarReferenceID,
                NotificationType: mvarNotificationType,
                NotificationID: pvarNotificationID
            },
            function (VarResponseData) {

                $('#TblNotifications').empty();
                $('#TblNotifications').append(VarResponseData);

                try {
                    GetAllNotifications();
                    GetNotificationsCount();
                } catch (e) {

                }

                NProgress.done();
                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}

function LikePosts(pvarTopicID, pvarPostID) {
   
    $.post("Ajax/AjaxUser.aspx",
          {
              Mode: "LIKEPOST",
              TopicID: pvarTopicID,
              PostID: pvarPostID

          },

              function (varResponseData) {

                  if (varResponseData != "") {

                      if ((varResponseData == "SUCCESS") || (varResponseData == "success")) {
                          toastr["success"]("Post liked successfully");

                          $('#LikePost_' + pvarPostID).hide();
                          $('#UnLikePost_' + pvarPostID).show();

                      }

                  }


              });

    return false;

}

function UnlikePosts(pvarTopicID, pvarPostID) {

    $.post("Ajax/AjaxUser.aspx",
          {
              Mode: "UNLIKEPOSTS",
              TopicID: pvarTopicID,
              PostID: pvarPostID

          },

              function (varResponseData) {

                  if (varResponseData != "") {

                      if ((varResponseData == "SUCCESS") || (varResponseData == "success")) {
                          toastr["success"]("Post unliked successfully");

                          $('#LikePost_' + pvarPostID).show();
                          $('#UnLikePost_' + pvarPostID).hide();

                      }

                  }


              });

    return false;

}
function AddPostComments(varPostID) {

    if ($('#profile-newsfeed-comment' + varPostID).val().trim() == '')
        return false;

    NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "ADDPOSTCOMMENTS",
                Comment: $('#profile-newsfeed-comment' + varPostID).val(),
                PostID: varPostID
            },

                function (VarResponseData) {

                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                        toastr["success"]("Comment posted successfully");

                        GetNotificationDetails(mvarReferenceID, mvarNotificationType);
                    }
                    NProgress.done();
                });


    return false;
}

function showSendMsgModel(pvarReceiverUserID, pvarRecevierName) {
   
    mvarRecevierID = pvarReceiverUserID;
   
    $('#txtReceiver').val(pvarRecevierName);
    $('#txtmsg').val("");
    $(remainingLengthTempId).text(500);
    $('#headerTitle').html("Send Messaage");
    $('#modal-Send-Msg').show();
    return false;
}
$('#BtnSendMsg').click(function () {
       
    if ($('#form_sendmsg').valid()) {
        SendMessage();

    }
});

function SendMessage() {
   
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "SENDMESSAGE",
                RecevierID: mvarRecevierID,
                Message: $('#txtmsg').val()
            },
                function (VarResponseData) {

                    if (VarResponseData == "SUCCESS") {
                        toastr["success"]("Message sent successfully");
                        $('#btn_CloseMsg').click();

                    }

                });


    return false;
}
function showSendMsgModelOfPostCreator(pvarid) {
    alert(pvarid);
    return false;
}

function PostMessageToUser1(pvarReceiverID) {
 
    if ($('#profile-newsfeed-comment1').val().trim() == '')
        return false;

    NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "POSTMESSAGETOUSER",
                Message: $('#profile-newsfeed-comment1').val(),
                ReceiverID: pvarReceiverID

            },

                function (VarResponseData) {
                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {

                        toastr["success"]("Message sent successfully");
                        NProgress.done();
                        GetNotificationDetails(mvarReferenceID, mvarNotificationType);
                        $('#profile-newsfeed-comment1').val() = '';
                        //GetForumPosts(pvarTopicID, obj);
                    }
                });


    return false;
}
