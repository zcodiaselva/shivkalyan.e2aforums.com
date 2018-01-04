var mvarUserID = -1;

$(function () {
   
    $('#Expertss-a').addClass("active");
    GetExpertsListing();

});

function GetExpertsListing() {
    $("#TblExperts").empty();
    $("#TblExperts").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETEXPERTSLISTING',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Picture', name: 'Picture', width: 130, sortable: false, align: 'left' },
                { display: 'Name', name: 'Full_Name', width: 130, sortable: false, align: 'left' },
                { display: 'Email', name: 'EMail', width: 100, sortable: false, align: 'left' },
                { display: 'Phone ', name: 'Mobile_Phone', width: 100, sortable: false, align: 'left' },
                { display: 'Occupation', name: 'Occupation', width: 100, sortable: false, align: 'left' },
                { display: 'Action', width: 160, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "Full_Name",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "Full_Name",
        query: '',
        onError: function (errorMsg) {
            alert("error, " + errorMsg);
        },
        onSuccess: function () {

        }
    }

    );
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