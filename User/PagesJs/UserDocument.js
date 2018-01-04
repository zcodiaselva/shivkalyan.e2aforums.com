var mvarDocID = -1;
$(function () {

    $('#UserDocuments-a').addClass("active");
  
    GetUserName();
    GetUserDocListing();

    $('#BtnSaveDocument').click(function () {

        SaveUserDocuments();
        return false;

    });
    $('#BtnEditDocument').click(function () {

        SaveUserDocuments();
        return false;

    });

});

function GetUserName() {

    $.post("Ajax/AjaxCustomers.aspx",
    {
        Mode: "GETUSERNAME"

    },
  function (VarResponseData) {


      $('#headerMainTitle').html("" + VarResponseData + "'s" + "  " + "Documents listing");

  });                  //End of Ajax

    return false;
}

function showEditDocumentModel(pvarDocID) {
    mvarDocID = pvarDocID;
    $('#modal-Add-Document').addClass('modal');
    $('#BtnSaveDocument').hide();
    $('#BtnEditDocument').show();
    $('#headerTitle').html("Edit Document");
    $('#btn_addClose').click();
    $.post("Ajax/AjaxCustomers.aspx",
            {
                Mode: "GETDOCUMENTDETAILS",
                DocID: mvarDocID
            },

          function (VarResponseData) {

              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('DocData').each(function () {

                      if ($(this).find('Description').text() != "") {
                          $('#txtTitleDesc').val($(this).find('Description').text());
                      }
                      //if ($(this).find('UploadDocFile').text() != "") {
                      //    $('#FileUpload').val($(this).find('UploadDocFile').text());
                      //}
                      if ($(this).find('UploadDocFile').text() != "") {
                          $('#lblFileName').show();
                          $('#lblFileName').text($(this).find('UploadDocFile').text());
                         
                      }
                  });
              }); //end of Response   
          });                  //End of Ajax

    return false;
}

function SaveUserDocuments() {
   var varDocument = $('#FileUpload').val();
   var varDescription = $('#txtTitleDesc').val();
   if(varDescription=="")
   {
       alert("Please enter text");
   }
   else if (varDocument=="") {
       alert("Please choose file for upload.")
   }
   $.ajaxFileUpload
         (
             {

                 url: 'Ajax/UploadProfilePics.ashx?Mode=UPLOADUSERDOCUMENTS',
                 secureuri: false,
                 fileElementId: 'FileUpload',
                 dataType: 'text',
                 data: { name: 'logan', id: 'id' },
                 success: function (data, status) {

                     data = data.replace("<pre>", "").replace("<PRE>", "");
                     data = data.replace("</pre>", "").replace("</PRE>", "");

                     if (data.indexOf("SUCCESS") != -1) {

                         var pdfname = data.split("##")[1];
                         NProgress.start();
                         $.post("Ajax/AjaxCustomers.aspx",
                             {
                                 Mode: "SAVEUSERDOCUMENTS",
                                 Description: $('#txtTitleDesc').val(),
                                 PdfDocument: pdfname,
                                 DocID: mvarDocID
                             },

                                 function (VarResponseData) {
                                     if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                                         if (mvarDocID == -1) {
                                             toastr.options = { "onHidden": function () { $('.close').click(); GetUserDocListing(); } };
                                             toastr["success"]("Document added successfully");
                                             mvarDocID = -1;
                                             NProgress.done();
                                         }
                                         else {
                                             toastr.options = { "onHidden": function () { $('.close').click(); GetUserDocListing(); } };
                                             toastr["success"]("Document updated successfully");
                                             mvarDocID = -1;


                                         }
                                     }
                                     //else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                                     //    toastr["error"]("Document already exists");
                                     //    mvarDocID = -1;
                                     //}
                                 });


                     }
                     else {
                         alert(data);
                     }
                 },
                 error: function (data, status, e) {
                     alert(e);
                 }
             }
         )
}

function GetUserDocListing() {

    $("#TblUserDocument").empty();
    $("#TblUserDocument").SJGrid
    (
    {
        url: 'Ajax/AjaxCustomers.aspx?Mode=GETUSERDOCLISTING',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Description', name: 'Description', width: 150, sortable: false, align: 'left' },
                { display: 'File Name', name: 'UploadDocFile', width: 150, sortable: false, align: 'left' },
                { display: 'Action', width: 160, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "DateAndTime",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "DateAndTime",
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

function ResetForm() {
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    $('#BtnSaveDocument').show();
    $('#BtnEditDocument').hide();
    document.forms["form_Document"].reset();
    $('#headerTitle').html("Add Document");
    $('#FileUpload').empty();
    $('#lblFileName').empty();
   
}

function DeleteDocument(pvarDocID) {
    var varApproved = "Are  you sure you want to delete this document?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxCustomers.aspx",
                  {

                      Mode: "DELETEDOCUMENT",
                      DocID: pvarDocID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {

                              toastr["success"]("Document deleted successfully");
                              GetUserDocListing();
                          }
                      }


                  });
    }
    return false;
}