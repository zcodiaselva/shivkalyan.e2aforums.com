var varCategoryID = -1;
var varTopicID = -1;
var mvarRecevierID = -1;


$(function () {


    //$('button.close').click(function () {
       
    //    NProgress.start();
       
    //    ResetForm();
       
    //    NProgress.done();
    //});

    //jQuery('#default-textarea').linkify();
    $('#Forum-a').addClass("active");

    NProgress.start();
    //GetForumCategory();
    FillCategoryCombo();

    //FillCategoryComboFilter();
    if ($('#forum-categories').show()) {
        $('#Category-a').addClass("active");
        $('#Category-a').tab('show');

    }

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
    //$("a.youtube").YouTubePopup({ idAttribute: 'youtube' });
});


function GetForumCategory() {


    NProgress.start();
    $("#content").hide();
    $("#div_topics").hide();
    $("#forum-categories").show();

    $("#TblForumCategory").empty();
    $("#TblForumCategory").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETFORUMCATEGORY',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                //{ display: '<i class=\"gi gi-user\" style=\"text-allign:center\"></i> ', name: 'PicName', width: 20, sortable: false, align: 'left' },
                { display: 'Categories', name: 'Category', width: 130, sortable: false, align: 'left' },
                { display: 'Topics', name: 'Topics', width: 100, sortable: false, align: 'left' },
                { display: 'Posts ', name: 'Posts', width: 100, sortable: false, align: 'left' },
                { display: 'Last Post', name: 'PostTime', width: 100, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "CategoryID",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        searchText: 'Search Categories',
        qtype: "Title",
        query: '',
        onError: function (errorMsg) {
            NProgress.done();
           
            NProgress.done();
        },
        onSuccess: function () {
            NProgress.done();
        }
    }

    );



    return false;
}

function GetForumTopics(varFlag) {
    $('#Topics-a').addClass("active");
    if (varFlag == true) {
        varCategoryID = $("#cmb_Categories").val();
        //$("#cmb_Categories1").val() = varCategoryID;
    }
    else {
        varCategoryID = -1;
        // $("#cmb_Categories1").val() = varCategoryID;
    }

    // alert(("#cmb_Categories1").val());
    NProgress.start();
    $("#TblForumTopics").empty();
    $("#TblForumTopics").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETFORUMTOPICS&CategoryID=' + varCategoryID,
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Topics', name: 'Topic', width: 280, sortable: false, align: 'left' },
                { display: 'Replies', name: 'Replies', width: 70, sortable: false, align: 'left' },
                { display: 'Views ', name: 'TopicView', width: 70, sortable: false, align: 'left' },
                { display: 'Last Post', name: 'LastPostUser', width: 100, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "TopicID",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "Title",
        query: '',
        onError: function (errorMsg) {
            
            NProgress.done();
        },
        onSuccess: function () {
            NProgress.done();
            //$("a.addTabs").click(function () {

            //    addTab($(this));

            //});

        }
    }

    );



    return false;
}

function AddnewTab(pvarTopicID, pvarTopic, pvarCategoryID) {



    NProgress.start();
    varCategoryID = pvarCategoryID;

    if ($("#tabs").find("li").length == 6) {
        alert('You can add max of 4 Tabs');
        return false;
    }

    $("#forum - topics").show();
    $("#content").show();
    $("#div_topics").hide();
    $("#forum-categories").hide();
    varTopicID = pvarTopicID;

    if ($("#tabs").find("li[name='li_" + pvarTopicID + "']").length == 0) {

        var varTopicName = pvarTopic;
        var varShortTopicName = "";
        var pos = 0;
        if (varTopicName.length > 20) {
            varShortTopicName = varTopicName.substring(0, 20) + "...";
            pos = 120;
        }
        else {
            varShortTopicName = varTopicName;
            pos = 100;
        }

        $("#tabs li").removeClass('active');
        $("#tabs").append("<li title='" + varTopicName + "' id='li_" + pvarTopicID + "'   name='li_" + pvarTopicID + "' class='active'><a class=\"enable-tabs\" onclick='return showTab(" + pvarTopicID + ");'  id='" +
                pvarTopicID + "' href='#'>" + varShortTopicName +
                 "</a><a href='#' title='Click to close the tab'><image  src=\"img/cross-script.png\" style='top:-40px; right:1px; cursor:pointer; position:absolute;height:10px;width:10px;' onclick='return RemoveTab(\"li_" + pvarTopicID + "\");'></a></li>");

        GetForumPosts(pvarTopicID, 'li_' + pvarTopicID);
        NProgress.done();
        $.post("Ajax/AjaxUser.aspx",
        {
            Mode: "GETTOPICVIEWCOUNT",
            TopicID: pvarTopicID
        },
        function (varResponseData) {
        });
    }
    return false;
}

function GetForumPosts(pvarTopicID, obj) {

    NProgress.start();
    $('#TblForumDiscussions').append("Loading....");
    $("#tabs li").removeClass('active');
    $('#' + obj).addClass('active');
    $("#div_topics").hide();
    $("#forum-topics").show();
    $("#content").show();
    $("#forum-categories").hide();

    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETFORUMPOSTS",
                TopicID: pvarTopicID
            },
            function (VarResponseData) {
                console.log(VarResponseData);
                $('#TblForumDiscussions').empty();
                $('#TblForumDiscussions').append(VarResponseData);
               // $("a.youtube").YouTubePopup({ idAttribute: 'youtube' });
               // $("a.youtube").YouTubePopup({ idAttribute: 'youtube' });
               // $("a.youtube").YouTubePopup({ idAttribute: 'youtube' });
             //  $("a.youtube").YouTubePopup().click();
                NProgress.done();
                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}

function FillCategoryComboFilter() {

    $("#content").hide();
    $("#div_topics").show();
    $("#forum-categories").hide();

    if ($('#cmb_Categories').val() == -1)
        return false;

    NProgress.start();

    NProgress.start();
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

                           if (varCategoryID != -1)
                               $('#cmb_Categories').val(varCategoryID);
                           $('#cmb_Categories').trigger('chosen:updated');
                           if (varCategoryID == -1)
                               GetForumTopics(false);
                           else
                               GetForumTopics(true);

                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}

function ShowTopicDiv(pvarCategoryID) {
    NProgress.start();
    // alert(pvarCategoryID);
    varCategoryID = pvarCategoryID;
    FillCategoryComboFilter();
    $('#Topics-a').tab('show');
    NProgress.done();
    //$('#Topics-a').click();
}

function RemoveTab(pvarTopicID) {

    $('#TblForumDiscussions').empty();
    $('#' + pvarTopicID).remove();
    var cnt = $("#tabs").find("li").length;
    var obj = $("#tabs").find("li")[cnt - 1];

    if (obj.id != "") {


        $('#TblForumDiscussions').append("Loading....");
        GetForumPosts(obj.id.replace("li_", ""), obj.id);
        // $('#li_' + obj).addClass('active');
    }
    else {
        //window.location.reload();        
        $('#TblForumDiscussions').empty();
        varCategoryID = -1;
        FillCategoryComboFilter();
        $('#Topics-a').addClass("active");
        $('#Topics-a').tab('show');
    }
    return false;
}

function AddPostComments(varPostID) {
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
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

                            GetForumPosts(varTopicID, 'li_' + varTopicID);
                        }
                        NProgress.done();
                    });
        return false;
    }

   
}

function showTab(id) {

    varTopicID = id;
    GetForumPosts(id, 'li_' + id);
    $('#li_' + id).tab('show');
    $("#tabs li").removeClass('active');
    $('#li_' + id).addClass('active');
    return false;
}

function showSendMsgModel(pvarReceiverUserID, pvarRecevierName) {
   
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
   else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
        mvarRecevierID = pvarReceiverUserID;
        $("#Message-a").click();
        $('#txtReceiver').val(pvarRecevierName);
        $('#txtmsg').val("");
        $(remainingLengthTempId).text(500);
        $('#headerTitle').html("Send Messaage");
        document.forms["form_sendmsg"].reset();
        //$('#form_sendmsg').show();
        //$('#modal-Send-Msg').show();
        return false;

    }



  
}

function checkMaxLength(textareaID, maxLength) {

    currentLengthInTextarea = $("#" + textareaID).val().length;
    $(remainingLengthTempId).text(parseInt(maxLength) - parseInt(currentLengthInTextarea));

    if (currentLengthInTextarea > (maxLength)) {
        // Trim the field current length over the maxlength.
        $("textarea#txtmsg").val($("textarea#txtmsg").val().slice(0, maxLength));
        $(remainingLengthTempId).text(0);

    }
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


                        // toastr.options = { "onHidden": function () { window.location.reload(); } };
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

function showUploadModel() {
    $('#modal-Upload-File').show();
    $('#btn_UploadFileClose').click();
    return false;
}

function PostTopicComments(pvarIsUrl) {
   
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
        var selectedval = $('input[name=PostType]:checked').val();

        NProgress.start();
        if ($('#default-textarea').val().trim() == '') {
            toastr["error"]("Please enter text");
            return false;
        }
        else if (selectedval == 'Images') {
            if ($('#filUpload1').val() != "" || $('#filUpload2').val() != "" || $('#filUpload3').val() != "") {

                UploadFile();
            }
            else {
                toastr["error"]("Please select Image");
                return false;
            }
        }
        else if (selectedval == 'Video') {
            if ($('#txtVideoURL').val() != '') {

                var url = $('#txtVideoURL').val();
                var regExp = /.*(?:youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=)([^#\&\?]*).*/;
                var match = url.match(regExp);

                if (match) {
                   
                    NProgress.start();
                    $.post("Ajax/AjaxUser.aspx",
                            {
                                Mode: "POSTVIDEO",
                                Content: $('#default-textarea').val(),
                                TopicID: varTopicID,
                                CategoryID: varCategoryID,
                                IsUrl: pvarIsUrl,
                                YouTubeURL: url
                            },

                                function (VarResponseData) {
                                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                                        GetForumPosts(varTopicID, 'li_' + varTopicID);
                                        toastr["success"]("Post added successfully");
                                        NProgress.done();

                                        //GetForumPosts(pvarTopicID, obj);
                                    }
                                });

                    $('#download-btn').fadeOut('fast');
                    $('#loading').fadeIn('slow');
                    setTimeout("getVideo('" + match[1] + "')", 2000);
                }
                else {
                    alert('Invalid URL!');
                    $('#url').val("");
                    $('#url').focus();
                }
            }
            else {
                toastr["error"]("Please enter youtube URL");
                return false;
            }
        }
        else {

            $.post("Ajax/AjaxUser.aspx",
                    {
                        Mode: "POSTTOPICCOMMENTS",
                        Content: $('#default-textarea').val(),
                        TopicID: varTopicID,
                        CategoryID: varCategoryID,
                        IsUrl: pvarIsUrl,
                    },

                        function (VarResponseData) {
                            if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                                GetForumPosts(varTopicID, 'li_' + varTopicID);
                                toastr["success"]("Post added successfully");
                                NProgress.done();

                                //GetForumPosts(pvarTopicID, obj);
                            }
                        });

        }
        return false;
    }
  
}

function UploadFile() {

    if ($('#filUpload1').val() != '') {

        var varImgFileExtn = $('#filUpload1').val().substr($('#filUpload1').val().lastIndexOf("."), $('#filUpload1').val().length);

        if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
            alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 1');
            return false;
        }
    }

    if ($('#filUpload2').val() != '') {

        var varImgFileExtn = $('#filUpload2').val().substr($('#filUpload2').val().lastIndexOf("."), $('#filUpload2').val().length);

        if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
            alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 2');
            return false;
        }
    }

    if ($('#filUpload3').val() != '') {

        var varImgFileExtn = $('#filUpload3').val().substr($('#filUpload3').val().lastIndexOf("."), $('#filUpload3').val().length);

        if (varImgFileExtn.toUpperCase() != ".PNG" && varImgFileExtn.toUpperCase() != ".JPG" && varImgFileExtn.toUpperCase() != ".JPEG" && varImgFileExtn.toUpperCase() != ".GIF") {
            alert('Please select *.png/ *. jpg/ *.jpeg/ *.gif file for Image 3');
            return false;
        }
    }



    $.ajaxFileUpload({
        url: 'Ajax/UploadImages.ashx',
        secureuri: false,
        fileElementId: 'filUpload1,filUpload2,filUpload3',
        dataType: 'text',
        data: { name: 'logan', id: 'id' },
        success: function (data, status) {

            data = data.replace("<pre>", "").replace("<PRE>", "")
            data = data.replace("</pre>", "").replace("</PRE>", "")

            if (data.indexOf("SUCCESS") != -1) {

                $.post("Ajax/AjaxUser.aspx",
                {
                    Mode: "POSTTOPICCOMMENTS",
                    Content: $('#default-textarea').val(),
                    TopicID: varTopicID,
                    CategoryID: varCategoryID,
                    Images: data.split("##")[1]
                },
                function (VarResponseData) {
                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {



                        GetForumPosts(varTopicID, 'li_' + varTopicID);
                        toastr["success"]("Post added successfully");
                        NProgress.done();
                    }
                });
            }
            else {
                alert(data);
                NProgress.done();
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

function LikePosts(pvarTopicID, pvarPostID) {
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
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
}

function UnlikePosts(pvarTopicID, pvarPostID) {
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
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
}

function FillCategoryCombo() {
    // NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
            { Mode: "FILLCATEGORYCOMBO" },
               function (varResponseData) {

                   if (varResponseData.Text != "") {
                       $(varResponseData).find('Response').each(function () {

                           $('#cmb_Categories1').empty();
                           var opt = document.getElementById("cmb_Categories1").options;
                           opt[opt.length] = new Option('All', -1);

                           $(varResponseData).find('Contents').each(function () {

                               if ($(this).find('CategoryID').text() != "" && $(this).find('Title').text() != "") {
                                   // console.log(varCategoryID);
                                   opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('CategoryID').text());
                               }
                           }); // end of Contents
                          
                           $('#cmb_Categories1').trigger('chosen:updated');
                         
                       }); //end of Response
                   } //END OF if (VarResponseData
               });        //END OF function (VarResponse...


    return false;
}

function AddNewTopic() {

    var varIsFlagged = "";
    if (varCategoryID == -1) {
        varCategoryID = $('#cmb_Categories1').val();
    }

    if ($("#Topic_IsFlagged").attr("checked", false)) {
        varIsFlagged = "False"
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
                TopicID: varTopicID,
                IsFlagged: varIsFlagged
            },

                function (VarResponseData) {
                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                        if (varTopicID == -1) {
                          toastr.options = { "onHidden": function () { $('.close').click(); GetForumTopics(false); } };
                          toastr["success"]("Topic added successfully");
                           varTopicID = -1;
                           
                        }
                        else {
                            toastr.options = { "onHidden": function () { $('.close').click(); GetForumTopics(false); } };
                            toastr["success"]("Topic updated successfully");
                            varTopicID = -1;
                            
                        }

                    }
                    else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                        toastr["error"]("Topic Name already exists");

                    }
                });


    return false;

}

function ResetMyForm() {
    if (mvarOccupationID == 0) {

        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
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
        $('#modal-Add-Topic').show();
        //document.forms["form_Topic"].reset();

        //$("#a_modalAddTopic").click();
        //varTopicID = -1;
    }

}
function ResetForm() {
   if (mvarOccupationID == 0) {
       
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else{
        if (varCategoryID == -1) {

            $('#cmb_Categories1').val(varCategoryID);
            $('#cmb_Categories1').trigger('chosen:updated');
        }
        else {

            $('#cmb_Categories1').val(varCategoryID);
            $('#cmb_Categories1').trigger('chosen:updated');
        }

        $('.form-group').removeClass('has-success has-error');
        $('.help-block').remove();
        $('.error').hide();
        $('#modal-Add-Topic').show();
        document.forms["form_Topic"].reset();

        $("#a_modalAddTopic").click();
        varTopicID = -1;
   }
   
}

(function ($) {

    var url1 = /(^|&lt;|\s)(www\..+?\..+?)(\s|&gt;|$)/g,
        url2 = /(^|&lt;|\s)(((https?|ftp):\/\/|mailto:).+?)(\s|&gt;|$)/g,

        linkifyThis = function () {
            var childNodes = this.childNodes,
                i = childNodes.length;
            while (i--) {
                var n = childNodes[i];
                if (n.nodeType == 3) {
                    var html = $.trim(n.nodeValue);
                    if (html) {
                        html = html.replace(/&/g, '&amp;')
                                   .replace(/</g, '&lt;')
                                   .replace(/>/g, '&gt;')
                                   .replace(url1, '$1<a href="http://$2">$2</a>$3')
                                   .replace(url2, '$1<a href="$2">$2</a>$5');
                        $(n).after(html).remove();
                    }
                }
                else if (n.nodeType == 1 && !/^(a|button|textarea)$/i.test(n.tagName)) {
                    linkifyThis.call(n);
                }
            }
        };

    $.fn.linkify = function () {
        return this.each(linkifyThis);
    };

})(jQuery);

function PostTopicUrl(pvarIsUrl) {
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
        var txt = $('#default-textarea').val();

        var re = /^(www.)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/;

        if (re.test(txt)) {

            NProgress.start();
            $.post("Ajax/AjaxUser.aspx",
                    {
                        Mode: "POSTTOPICURL",
                        Content: txt,
                        TopicID: varTopicID,
                        CategoryID: varCategoryID,
                        IsUrl: pvarIsUrl
                    },

                        function (VarResponseData) {
                            if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                                GetForumPosts(varTopicID, 'li_' + varTopicID);
                                toastr["success"]("Post added successfully");
                                NProgress.done();

                                //GetForumPosts(pvarTopicID, obj);
                            }
                        });

        }
        else {
            toastr["error"]("Please enter valid url.");
        }
        return false;
    }

}

function LikeTopic(pvarTopicID) {
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
        $.post("Ajax/AjaxUser.aspx",
              {
                  Mode: "LIKETOPIC",
                  TopicID: pvarTopicID
              },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if ((varResponseData == "SUCCESS") || (varResponseData == "success")) {
                              toastr["success"]("Topic liked successfully");

                              $('#LikeTopic_' + pvarTopicID).hide();
                              $('#UnLikeTopic_' + pvarTopicID).show();

                          }

                      }


                  });

        return false;
    }

}

function UnlikeTopic(pvarTopicID) {
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
        $.post("Ajax/AjaxUser.aspx",
              {
                  Mode: "UNLIKETOPIC",
                  TopicID: pvarTopicID

              },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if ((varResponseData == "SUCCESS") || (varResponseData == "success")) {
                              toastr["success"]("Topic unliked successfully");

                              $('#LikeTopic_' + pvarTopicID).show();
                              $('#UnLikeTopic_' + pvarTopicID).hide();

                          }

                      }


                  });

        return false;
    }

}

function AddnewTabInForum(pvarTopicID, pvarTopic, pvarCategoryID, pvarNotificationID) {

    NProgress.start();
    varCategoryID = pvarCategoryID;

    if ($("#tabs").find("li").length == 6) {
        alert('You can add max of 4 Tabs');
        return false;
    }

    $("#forum - topics").show();
    $("#content").show();
    $("#div_topics").hide();
    $("#forum-categories").hide();
    varTopicID = pvarTopicID;

    if ($("#tabs").find("li[name='li_" + pvarTopicID + "']").length == 0) {

        var varTopicName = pvarTopic;
        var varShortTopicName = "";
        var pos = 0;
        if (varTopicName.length > 20) {
            varShortTopicName = varTopicName.substring(0, 20) + "...";
            pos = 120;
        }
        else {
            varShortTopicName = varTopicName;
            pos = 100;
        }

        $("#tabs li").removeClass('active');
        $("#tabs").append("<li title='" + varTopicName + "' id='li_" + pvarTopicID + "'   name='li_" + pvarTopicID + "' class='active'><a class=\"enable-tabs\" onclick='return showTab(" + pvarTopicID + ");'  id='" +
                pvarTopicID + "' href='#'>" + varShortTopicName +
                 "</a><a href='#' title='Click to close the tab'><image  src=\"img/cross-script.png\" style='top:-40px;left:" + pos + "px;position:absolute;height:10px;width:10px;' onclick='return RemoveTab(\"li_" + pvarTopicID + "\");'></a></li>");
        console.log("1");
        GetForumPosts(pvarTopicID, 'li_' + pvarTopicID);
        console.log(pvarTopicID + "hello");
        NProgress.done();
        $.post("Ajax/AjaxUser.aspx",
        {
            Mode: "REMOVENOTIFICATION",
            NotificationID: pvarNotificationID
        },
        function (varResponseData) {
        });
    }
    return false;
}

function shareOnFacebook(_caption, _description, pvarTopicID) {
    if (mvarOccupationID == 0) {
        toastr["error"]("Please update your profile to enjoy fully- featured 14 days free trial .");
        return false;
    }
    else if (mvarOccupationID == 7) {
        toastr["error"]("You are not athunticated.");
        return false;
    }
    else {
        while (_caption.indexOf("#@#@") != -1)
            _caption = _caption.replace("#@#@", '"');

        while (_description.indexOf("#@#@") != -1)
            _description = _description.replace("#@#@", '"');

        while (_caption.indexOf("#@#") != -1)
            _caption = _caption.replace("#@#", "'");

        while (_description.indexOf("#@#") != -1)
            _description = _description.replace("#@#", "'");

      
        share_url = 'https://www.facebook.com/dialog/feed?';
        share_url += 'app_id=551080798330891'
        share_url += '&link=' + 'http://e2aforums.com';
        share_url += '&picture=' + 'http://e2aforums.com/user/img/e2aLogoTrans.jpg';
        share_url += '&name=' + 'E2A FORUMS';
        share_url += '&caption=' + _caption;
        share_url += '&description=' + _description;
        share_url += '&redirect_uri=' + 'http://localhost:1253/User/Forum.aspx?TopicID=' + pvarTopicID;

        var myWindow = window.open(share_url, 'sharer', 'toolbar=0,status=0,width=750,height=650');

    }

}
function ShowPostVideoSection() {
    var selectedval = $('input[name=PostType]:checked').val();
    if (selectedval == 'Video') {
        $("#divPostVideo").show();
        $('#divImages').hide();
    }
    else if (selectedval == 'Images')
    {
        $("#divPostVideo").hide();
        $('#divImages').show();
        $('#txtVideoURL').val('');
    }
    //$('#cboxVideo').click(function () {
    //    if ($(this).is(':checked')) {
    //        $("#divPostVideo").show();
    //    } else {
    //        $("#divPostVideo").hide();
    //    }
    //});
}

function PostVideo() {
    var url = $('#txtVideoURL').val();
    var regExp = /.*(?:youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=)([^#\&\?]*).*/;
    var match = url.match(regExp);
    if (match) {
        NProgress.start();
        $.post("Ajax/AjaxUser.aspx",
                {
                    Mode: "POSTVIDEO",
                    Content: txt,
                    TopicID: varTopicID,
                    CategoryID: varCategoryID,
                    IsUrl: pvarIsUrl
                },

                    function (VarResponseData) {
                        if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                            GetForumPosts(varTopicID, 'li_' + varTopicID);
                            toastr["success"]("Post added successfully");
                            NProgress.done();

                            //GetForumPosts(pvarTopicID, obj);
                        }
                    });

        $('#download-btn').fadeOut('fast');
        $('#loading').fadeIn('slow');
        setTimeout("getVideo('" + match[1] + "')", 2000);
    }
    else {
        alert('Invalid URL!');
        $('#url').val("");
        $('#url').focus();
    }

}

function DeletePost(pvarUserID, pvarPostID)
{
    var varApproved = "Are  you sure you want to delete this post?";
    if (confirm(varApproved)) {
        $.post("Ajax/AjaxUser.aspx",
                {
                    Mode: "DELETEPOST",
                    UserID: pvarUserID,
                    PostID: pvarPostID
                },

                    function (varResponseData) {

                        if (varResponseData != "") {

                            if ((varResponseData == "SUCCESS") || (varResponseData == "success")) {
                                toastr["success"]("Post Deleted successfully");
                                GetForumPosts(varTopicID, 'li_' + varTopicID);

                            }

                        }


                    });
    }
    return false;
}

function DeletePostComments(pvarUserID, pvarPostCommentID) {
    var varApproved = "Are  you sure you want to delete this comment?";
    if (confirm(varApproved)) {
        $.post("Ajax/AjaxUser.aspx",
                {
                    Mode: "DELETEPOSTCOMMENTS",
                    UserID: pvarUserID,
                    PostCommentID: pvarPostCommentID
                },

                    function (varResponseData) {

                        if (varResponseData != "") {

                            if ((varResponseData == "SUCCESS") || (varResponseData == "success")) {
                                toastr["success"]("Comment Deleted successfully");
                                GetForumPosts(varTopicID, 'li_' + varTopicID);

                            }

                        }


                    });
    }
    return false;
}


function GetMyForumTopics(varUserId) {
    $('#Topics-a').addClass("active");
    
   
   
    NProgress.start();
    $("#TblForumTopics").empty();
    $("#TblForumTopics").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETMYFORUMTOPICS&UserID=' + varUserId,
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Topics', name: 'Topic', width: 280, sortable: false, align: 'left' },
                { display: 'Replies', name: 'Replies', width: 70, sortable: false, align: 'left' },
                { display: 'Views ', name: 'TopicView', width: 70, sortable: false, align: 'left' },
                { display: 'Last Post', name: 'LastPostUser', width: 100, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "TopicID",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "Title",
        query: '',
        onError: function (errorMsg) {
          
            NProgress.done();
        },
        onSuccess: function () {
            NProgress.done();
            //$("a.addTabs").click(function () {

            //    addTab($(this));

            //});

        }
    }

    );



    return false;
}
















//function sharePostImageOnFacebook(_caption, _description) {
//    alert("hello");
//    alert(_caption + "__" + _description); 
//    while (_caption.indexOf("#@#@") != -1)
//        _caption = _caption.replace("#@#@", '"');

//    while (_caption.indexOf("#@#") != -1)
//        _caption = _caption.replace("#@#", "'");

//    while (_description.indexOf("#@#") != -1)
//        _description = _description.replace("#@#", "//");

//    console.log(_caption);
//    console.log(_description);
//    share_url = 'https://www.facebook.com/dialog/feed?';
//    share_url += 'app_id=551080798330891'
//    share_url += '&link=' + 'http://e2aforums.com';
//    share_url += '&picture=' + 'http://e2aforums.com/user/img/e2aLogoTrans.jpg';
//    share_url += '&name=' + 'E2A FORUMS';
//    share_url += '&caption=' + _caption;
//    share_url += '&description= '+ '<img src=\"http://e2aforums.com '+ _description + '\">';
//    //share_url += '&description=' + 'http://e2aforums.com' + _description;
//    share_url += '&redirect_uri=' + 'http://www.e2aforums.com/User/Forum.aspx';

//    var myWindow = window.open(share_url, 'sharer', 'toolbar=0,status=0,width=750,height=650');



//}

//function sharePostOnFacebook(_caption) {

//    while (_caption.indexOf("#@#@") != -1)
//        _caption = _caption.replace("#@#@", '"');

//    while (_caption.indexOf("#@#") != -1)
//        _caption = _caption.replace("#@#", "'");


//    console.log(_caption);
//    console.log(_description);
//    share_url = 'https://www.facebook.com/dialog/feed?';
//    share_url += 'app_id=551080798330891'
//    share_url += '&link=' + 'http://e2aforums.com';
//    share_url += '&picture=' + 'http://e2aforums.com/user/img/e2aLogoTrans.jpg';
//    share_url += '&name=' + 'E2A FORUMS';
//    share_url += '&caption=' + _caption;
//    share_url += '&redirect_uri=' + 'http://www.e2aforums.com/User/Forum.aspx';

//    var myWindow = window.open(share_url, 'sharer', 'toolbar=0,status=0,width=750,height=650');



//}