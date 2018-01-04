var mvarUserID = -1;

$(function () {
    $('button.close').click(function () {
        NProgress.start();
        $('#modal-View-Rss').hide();
        $('.modal-backdrop').hide();
    });
    $('#Users-a').addClass("active");
    GetUsersListing();
    NProgress.done();
});
function GetUsersListing() {

    $("#TblUsers").empty();
    $("#TblUsers").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETUSERSLISTING',
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
                { display: 'User Type', name: 'UserType', width: 100, sortable: false, align: 'left' },
                { display: 'Occupation', name: 'Occupation', width: 100, sortable: false, align: 'left' },
                { display: 'Action', width: 160, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "DateAndTime",
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
    NProgress.done();
    return false;

}

function MarkUserDisable(pvarUserId, pvarUserName,pvarStatus) {
  
    var message = "";

    if (pvarStatus == 'false')
        message = "Are you sure you want to mark '" + pvarUserName + "' as disabled ?";
    else
        message = "Are you sure you want to mark '" + pvarUserName + "' as enabled ?";


    if (confirm(message) ){
        $.post("Ajax/AjaxUser.aspx",
        {
            Mode: "MARKUSERDISABLE",
            UserId: pvarUserId
        },
        function (VarResponseData) {
            if (VarResponseData != "") {
                if (VarResponseData == "Success") {

                    if (pvarStatus == 'false')                  
                        toastr["success"]("User account disabled successfully");
                    else
                        toastr["success"]("User account enabled successfully");

                    GetUsersListing();

                }
            }
        });        //END OF function (VarResponse...
    }
    return false;
}

function ViewUsersRssFeed(pvarRssUserID) {
 //   alert("hello");
    NProgress.start();
    $('#modal-View-Rss').show();
    $('.modal-backdrop').show();
    $('#div_RssFeedTitle').append("Loading....");
    // alert($("#div_RssFeedTitle").find("li").length);
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETUSERSRSSFEEDTITLELIST",
                UserID:pvarRssUserID
            },
            function (VarResponseData) {

                if (VarResponseData != "") {
                    $('#div_RssFeedTitle').empty();
                    $('#div_RssFeedTitle').append(VarResponseData);
                    $('#div_RssFeedTitle ul li a:first').click();
                  
                    $('.tooltip').tooltipster();
                    NProgress.done();
                }
                else {
                    $('#div_RssFeedTitle').empty();
                    $('#div_RssFeedTitle').append("No Rss Feed found");
                    $('.tooltip').tooltipster();
                    NProgress.done();
                }


                // TablesDatatables.init();
            });   //End of Ajax

    return false;
}
function GetRssFeedDetails(pvarURL, pvarRssFeedID) {
   
    $('#div_RssFeedTitle > ul > li > a > strong').attr('style','color:black');
    $('#li_' + pvarRssFeedID +' > a > strong').attr('style','color:white');
    $("#feedContainer").empty();
    $('#feedContainer').FeedEk({
        FeedUrl: pvarURL,
        MaxCount: 2,
        ShowDesc: true,
        ShowPubDate: false,
        DescCharacterLimit: -1,
        DateFormat: 'MM/DD/YYYY HH:mm',
        DateFormatLang: 'en'
    });
    NProgress.done();
}