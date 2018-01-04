var mvarChapterID = -1;
var mvarSubTitleID = -1;
var varYouTubeUrl = "";
var varUrlLink = "";
var varDocument = "";
var pdfname = "";
var varIsPaid = "";
//var pdfname = "";
$(function () {
    $('#Education-a').addClass("active");
    GetChaptersListing();
    $('#form_Chapter').validate({

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
            }
        },
        messages: {
            txtTitle:
                {
                    required: 'Please enter name '
                },
            txtDesc:
              {
                  required: 'Please enter Description '
              }
        }

    });

    $('#form_SubTitles').validate({

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
            txtSubTitle: {
                required: true
            },
            txtTitleDesc: {
                required: true
            }
        },
        messages: {
            txtSubTitle:
                {
                    required: 'Please enter title '
                },
            txtTitleDesc:
              {
                  required: 'Please enter Description '
              }
        }

    });
    $('#BtnSaveChapter').click(function () {
        if ($('#form_Chapter').valid()) {
           
            AddEditChapter();

        } else {
            return false;
        }
    });
    $('#BtnEditChapter').click(function () {
        if ($('#form_Chapter').valid()) {
            AddEditChapter();

        } else {
           return false;
        }
    });
    $('#BtnSaveSubTitle').click(function () {
        if ($('#form_SubTitles').valid()) {
            AddEditSubTitles();

        } else {
            return false;
        }
    });
    $('#BtnEditSubTitle').click(function () {
        if ($('#form_SubTitles').valid()) {
            AddEditSubTitles();

        } else {
            return false;
        }
    });
});





function GetChaptersListing() {

    $("#TblChapters").empty();
    $("#TblChapters").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETCHAPTERSLISTING',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Course', name: 'Title', width: 130, sortable: false, align: 'left' },
                { display: 'User ', name: 'Author', width: 100, sortable: false, align: 'left' },
                { display: 'Description', name: 'Description', width: 100, sortable: false, align: 'left' },
                { display: 'Action', width: 160, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "DateAndTime",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "Title",
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

function DeleteChapters(pvarChapterID) {

    var varApproved = "Are  you sure you want to delete this Chapter and its subtitles?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxUser.aspx",
                  {

                      Mode: "DELETECHAPTERS",
                      ChapterID: pvarChapterID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {

                              toastr["success"]("Course deleted successfully");
                              GetChaptersListing();
                          }
                      }


                  });
    }
    return false;

}

function showEditChapterModel(pvarChapterID) {
    mvarChapterID = pvarChapterID
    $('#BtnSaveChapter').hide();
    $('#BtnEditChapter').show();
    $('#headerTitle').html("Edit Course");
    $('#modal-Add-Chapter').show();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETCHAPTERDETAILS",
                ChapterID: mvarChapterID
            },

          function (VarResponseData) {
              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('ChapterData').each(function () {
                      if ($(this).find('Title').text() != "") {
                          $('#txtTitle').val($(this).find('Title').text());
                      }
                      if ($(this).find('Description').text() != "") {
                          $('#txtDesc').val($(this).find('Description').text());
                      }

                  });
              }); //end of Response   
          });                 //End of Ajax

    return false;
}

function AddEditChapter() {
    
    $.post("Ajax/AjaxUser.aspx",
      {
          Mode: "ADDEDITCHAPTER",
          Title: $('#txtTitle').val(),
          Description: $('#txtDesc').val(),
          ChapterID: mvarChapterID
      },
          function (VarResponseData) {

              if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                  if (mvarChapterID == -1) {
                      toastr.options = { "onHidden": function () { $('.close').click(); GetChaptersListing(); } };
                      $('.close').click();
                      toastr["success"]("Course added successfully");
                      mvarChapterID = -1;
                     
                  }
                  else {
                      toastr.options = { "onHidden": function () { $('.close').click(); GetChaptersListing(); } };
                      $('.close').click();
                      toastr["success"]("Course updated successfully");
                      mvarChapterID = -1;
                      

                  }
              }
              else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                  toastr["error"]("Course Name already exists");

              }
          });


    return false;
}

function ResetForm() {
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    $('#BtnSaveChapter').show();
    $('#BtnEditChapter').hide();
    document.forms["form_Chapter"].reset();
    $('#headerTitle').html("Add Course");



}

function ResetSubTitlesForm() {
    mvarSubTitleID = -1;
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    $('#BtnSaveSubTitle').show();
    $('#BtnEditSubTitle').hide();
    document.forms["form_SubTitles"].reset();
    $('#headerTitle1').html("Add Sub-Titles");
    $('#lblFileName').empty();


}

function ShowSubtitleBlock(pvarChapterID)
{
    mvarChapterID = pvarChapterID;
    $('#SubTitleBlock').show();
    $('#ChapterBlock').hide();
    NProgress.start();
    $.post("Ajax/AjaxUser.aspx",
    {
        Mode: "GETCOURSENAME",
        ChapterID: mvarChapterID
    },

    function (VarResponseData) {

        $('#headerSubtitleListing').html("Lessons Of  " + VarResponseData);
        $("#TblSkillQuestions").hide();

        GetCourseSubTitlesListing();
        NProgress.done();
    }); //End of Ajax           

    return false;
}

function AddEditSubTitles()
{
   
    varDocument = $('#FileUpload').val();

   if ($('#txtURL').val() != '') {
       console.log("1");
        var txt = $('#txtURL').val();
        var re = /^(www.)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/;
        
        if (re.test(txt)) {
            varUrlLink = txt;
        }
        else {
            toastr["error"]("Please enter valid URL link");
            return false;
        }
    }
    if ($('#txtYoutubeURL').val() != '') {
       
        var url = $('#txtYoutubeURL').val();
        var regExp = /.*(?:youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=)([^#\&\?]*).*/;
        var match = url.match(regExp);
          if (match) {
            varYouTubeUrl = url;
        }
        else {
            toastr["error"]("Please enter valid youtube URL");
            return false;
        }
    }
    
    if (varDocument != null || varDocument != "")
    {
       UploadPdfFile();
    }
   else {
        AddLessons();
        return false;
    }

}

function AddLessons() {
    NProgress.start();
    if ($('#IsPaid').is(":checked")) {
        varIsPaid = "True";
    }
    else {
        varIsPaid = "False";
    }
 
    $.post("Ajax/AjaxUser.aspx",
        {
            Mode: "ADDEDITSUBTITLES",
            ChapterID: mvarChapterID,
            SubTitle: $('#txtSubTitle').val(),
            Description: $('#txtTitleDesc').val(),
            PdfDocument: pdfname,
            YouTubeURL: varYouTubeUrl,
            URL: varUrlLink,
            SubTitleID: mvarSubTitleID,
            IsPaid:varIsPaid
        },

            function (VarResponseData) {
                $('#form_SubTitles').reset();
                if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                    if (mvarSubTitleID == -1) {
                        toastr.options = { "onHidden": function () { $('.close').click(); GetCourseSubTitlesListing(); } };
                        toastr["success"]("Lesson added successfully");

                        NProgress.done();
                    }
                    else {
                        toastr.options = { "onHidden": function () { $('.close').click(); GetCourseSubTitlesListing(); } };
                        toastr["success"]("Lesson updated successfully");
                        mvarSubTitleID = -1;


                    }
                }
                else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                    toastr["error"]("Lesson already exists");

                }
            });
}

function UploadPdfFile() {

    //varIsPaid = $("#IsPaid").val(($(this).is(':checked')) ? "1" : "0");
    if ($('#IsPaid').is(":checked")) {
        varIsPaid = "True";
    }
    else {
        varIsPaid = "False";
    }
 
    $.ajaxFileUpload
           (
               {
                 
                   url: 'Ajax/UploadPdfDocument.ashx',
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
                            $.post("Ajax/AjaxUser.aspx",
                                {
                                    Mode: "ADDEDITSUBTITLES",
                                    ChapterID: mvarChapterID,
                                    SubTitle: $('#txtSubTitle').val(),
                                    Description: $('#txtTitleDesc').val(),
                                    PdfDocument: pdfname,
                                    YouTubeURL: varYouTubeUrl,
                                    URL: varUrlLink,
                                    SubTitleID: mvarSubTitleID,
                                    IsPaid:varIsPaid
                                },

                                    function (VarResponseData) {
                                        if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                                            if (mvarSubTitleID == -1) {
                                                console.log("4");
                                                toastr.options = { "onHidden": function () { $('.close').click(); GetCourseSubTitlesListing(); } };
                                                toastr["success"]("Lesson added successfully");

                                                NProgress.done();
                                            }
                                            else {
                                                toastr.options = { "onHidden": function () { $('.close').click(); GetCourseSubTitlesListing(); } };
                                                toastr["success"]("Lesson updated successfully");
                                                mvarSubTitleID = -1;


                                            }
                                        }
                                        else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                                            toastr["error"]("Lesson already exists");

                                        }
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
    return false;
}

function GetCourseSubTitlesListing() {
    NProgress.start();
    $("#TblSubTitles").empty();
    $("#TblSubTitles").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETCOURSESUBTITLESLISTING&ChapterID=' + mvarChapterID,
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Lesson', name: 'Subtitle', width: 80, sortable: false, align: 'left' },
                { display: 'Video URL', name: 'YoutubeURL', width: 80, sortable: false, align: 'left' },
                { display: 'Pdf File', name: 'PdfDocument', width: 80, sortable: false, align: 'left' },
                { display: 'URL Link', name: 'URL', width: 80, sortable: false, align: 'left' },
                { display: 'Author', name: 'Author', width: 70, sortable: false, align: 'left' },
                { display: 'Description', name: 'Description', width: 70, sortable: false, align: 'left' },
                { display: 'Action', width: 120, sortable: false, align: 'left' }

        ],
        generateFooter: false,
        sortname: "DateAndTime",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "Subtitle",
        query: '',
        onError: function (errorMsg) {
            alert("error");
            NProgress.done();
        },
        onSuccess: function () {
            NProgress.done();
        }
    }

    );

   // ResetForm();

    return false;

}

function ShowEditSubTitlesModel(pvarSubTitleID) {
    mvarSubTitleID = pvarSubTitleID
    $('#BtnSaveSubTitle').hide();
    $('#BtnEditSubTitle').show();
    $('#headerTitle1').html("Edit Lesson");
    $('#modal-Add-SubTitles').show();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETSUBTITLESDETAILS",
                SubTitleID: mvarSubTitleID
            },

          function (VarResponseData) {
              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('SubTitleData').each(function () {
                      
                     
                      if ($(this).find('SubTitle').text() != "") {
                          $('#txtSubTitle').val($(this).find('SubTitle').text());
                      }
                      if ($(this).find('Description').text() != "") {
                          $('#txtTitleDesc').val($(this).find('Description').text());
                      }
                 
                          if ($(this).find('PdfDocument').text() != "") {
                              $('#lblFileName').text($(this).find('PdfDocument').text());
                             
                          }
                          if ($(this).find('YoutubeURL').text() != "") {
                              $('#txtYoutubeURL').val($(this).find('YoutubeURL').text());
                          }
                          if ($(this).find('URL').text() != "") {
                              $('#txtURL').val($(this).find('URL').text());
                          }
                          if ($(this).find('IsPaid').text() == "True") {
                              $("#IsPaid").attr("checked", true);
                          }

                          else {
                              $("#IsPaid").attr("checked", false);
                          }

                         
                  });
              }); //end of Response   
          });                 //End of Ajax

    return false;
}

function DeleteSubTitles(pvarSubTitlesID) {
    var varApproved = "Are  you sure you want to delete this subtitle?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxUser.aspx",
                  {

                      Mode: "DELETESUBTITLES",
                      SubTitleID: pvarSubTitlesID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {

                              toastr["success"]("Lesson deleted successfully");
                              GetCourseSubTitlesListing();
                          }
                      }


                  });
    }
    return false;
}

function GoBackToChapterListing() {
    $('#SubTitleBlock').hide();
    $('#ChapterBlock').show();
    $('#TblChapters').show();
    $("#TblChapters").dataTable().fnDestroy();
    GetChaptersListing();
   

}