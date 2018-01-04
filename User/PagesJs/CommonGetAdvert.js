var mvarUserID = -1;

$(function () {

    NProgress.start();
    ShowAdvertisementToUser();
});
//function used to get user details
function ShowAdvertisementToUser() {
    NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "SHOWADVERTISEMENTTOUSER"

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
