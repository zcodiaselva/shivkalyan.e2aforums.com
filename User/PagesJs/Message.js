var mvarSenderID = -1;
var mvarReceiverId = -1;
$(function () {
 
    $('#Message-a').addClass("active");
    NProgress.start();
    GetSendersName();
   

});

function GetSendersName() {

    NProgress.start();
    $('#div_Friends').append("Loading....");

    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETSENDERSNAMELIST"
            },
            function (VarResponseData) {
               
                if (VarResponseData != "") {
                    $('#div_Friends').empty();
                    $('#div_Friends').append(VarResponseData);
                    $('#div_Friends ul li a:first').click();
                    NProgress.done();
                }
                else {
                    $('#div_Friends').empty();
                    $('#div_Friends').append("No user found");
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}
function GetMessages(pvarReceiverId) {
 
    $('#div_Friends ul li').removeClass('active');
    $('#li_' + pvarReceiverId).addClass('active');
   
    $('#div_message').append("Loading....");
    mvarReceiverId = pvarReceiverId;

    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETMESSAGELIST",
                ReceiverID: pvarReceiverId
            },
            function (VarResponseData) {

                $('#div_message').empty();
                $('#div_message').append(VarResponseData);
                $('#From_' + pvarReceiverId).html("0");
           
                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}
function PostMessageToUser() {

    if ($('#profile-newsfeed-comment1').val().trim() == '')
        return false;

    NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "POSTMESSAGETOUSER",
                Message: $('#profile-newsfeed-comment1').val(),
                ReceiverID: mvarReceiverId

            },

                function (VarResponseData) {
                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {

                        toastr["success"]("Message sent successfully");
                        NProgress.done();
                        GetMessages(mvarReceiverId);
                        $('#profile-newsfeed-comment1').val() = '';
                        //GetForumPosts(pvarTopicID, obj);
                    }
                });


    return false;
}