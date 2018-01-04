var varCategoryID = -1;
var varTopicID = -1;
var mvarRecevierID = -1;

$(function () {

    $('button.close').click(function () {
        NProgress.start();

        ResetForm();

        NProgress.done();
    });

    //jQuery('#default-textarea').linkify();
    $('#Courses-a').addClass("active");
    GetAllCourses();
    NProgress.start();

});


function GetAllCourses() {

    NProgress.start();
   
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETALLCOURSES"
            },
            function (VarResponseData) {
               
                $('#div_allCourses').empty();
                $('#div_allCourses').append(VarResponseData);
          
                NProgress.done();
                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}

