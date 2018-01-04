var varChapterID="";
$(function () {

    $('#Courses-a').addClass("active");
    //GetAllLessons(varChapterID);
    NProgress.start();

});
function GetAllLessons(varChapterID) {

    NProgress.start();

    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETALLLESSONS",
                ChapterID:varChapterID
            },
            function (VarResponseData) {

                $('#div_lessons').empty();
                $('#div_lessons').append(VarResponseData);

                NProgress.done();
                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}
