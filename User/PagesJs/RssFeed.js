var mvarRssFeedID = -1;
$(function () {
    GetRssFeedTitleList();
    $('button.close').click(function () {
        NProgress.start();
        $('.tooltip').tooltipster();
        $('#modal-Add-RSS').hide();
        document.forms["form_RssFeed"].reset();

        $('#BtnSaveRSS').show();
        $('#BtnEditRSS').hide();
        // $('#cmb_CategoryFilter').val(-1);
        $('#headerTitle').html("Add RSS Feed")
        NProgress.done();
    });
    $('#RssFeed-a').addClass("active");

    $('#form_RssFeed').validate({

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
            txtUrl: {
                required: true
            }
        },
        messages: {
            txtTitle:
                {
                    required: 'Please enter title '
                },
            txtUrl:
              {
                  required: 'Please enter url '
              }
        }

    });


    $('#BtnSaveRSS').click(function () {
        if ($('#form_RssFeed').valid()) {
            AddRssFeed();
           

        } else {

            return false;
        }
    });
    $('#BtnEditRSS').click(function () {
        if ($('#form_RssFeed').valid()) {
            AddRssFeed();

        } else {

            return false;
        }
    });


});

function DeleteRssFeed(pvarRssFeedID) {
    var varApproved = "Are  you sure you want to delete this Rss Feed?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxUser.aspx",
                  {

                      Mode: "DELETERSSFEED",
                      RssFeedID: pvarRssFeedID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {

                              toastr["success"]("RssFeed deleted successfully");
                              GetRssFeedTitleList();
                          }
                      }


                  });
    }
    return false;

}

function AddRssFeed() {
    var varIsPublic = "";
    //varIsPublic = $("#UrlPublic").val(($(this).is(':checked')) ? "1" : "0");
    if ($('#UrlPublic').is(":checked"))
        {
          varIsPublic = "True";
    }
    else
    {
        varIsPublic = "False";
    }
   
    var txt = $('#txtUrl').val();

    var re = /(http(s)?:\\)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?/

    if (re.test(txt)) {
  

        $.post("Ajax/AjaxUser.aspx",
                {
                    Mode: "ADDRSSFEED",
                    Title: $('#txtTitle').val(),
                    URL: $('#txtUrl').val(),
                    RssFeedID: mvarRssFeedID,
                    IsPublic: varIsPublic

                },

                    function (VarResponseData) {
                        
                        if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                            if (mvarRssFeedID == -1) {
                                toastr.options = { "onHidden": function () { $('.close').click(); GetRssFeedTitleList(); } };
                                //$('.close').click();
                                toastr["success"]("Rss Feed added successfully");
                              
                               
                            }
                            else {
                                toastr.options = { "onHidden": function () { $('.close').click(); GetRssFeedTitleList(); } };
                               // $('.close').click();
                                toastr["success"]("Rss Feed updated successfully");
                              
                              
                            }

                        }
                        else {
                            toastr["error"]("Please enter valid Url");
                            //$('#btn_addRSSClose').click();
                        }

                    });
    }
    else {
        toastr["error"]("Please enter valid url.");
    }
    return false;
}

function GetRssFeedTitleList() {

    NProgress.start();
    $('#div_RssFeedTitle').append("Loading....");
   // alert($("#div_RssFeedTitle").find("li").length);
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETRSSFEEDTITLELIST"
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
    
     $('#div_RssFeedTitle ul li').removeClass('active');
     $('#li_' + pvarRssFeedID).addClass('active');
     $("#feedContainer").empty();
    $('#feedContainer').FeedEk({
        FeedUrl: pvarURL,
        MaxCount: 3,
        ShowDesc: true,
        ShowPubDate: false,
        DescCharacterLimit: -1,
        DateFormat: 'MM/DD/YYYY HH:mm',
        DateFormatLang: 'en'
    });
    NProgress.done();
}

function ResetForm()
{
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    $("#UrlPublic").attr("checked", false);
    document.forms["form_RssFeed"].reset();
}

function ShowEditModalForRssFeed(pvarRssFeedID) {

    mvarRssFeedID = pvarRssFeedID
    $('#BtnSaveRSS').hide();
    $('#BtnEditRSS').show();
    $('#headerTitle').html("Edit Rss Feed");
    $('#btnAddRSS').click();
    //$('#btn_addTopicClose').click();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETRSSFEEDDETAILS",
                RssFeedID: mvarRssFeedID
            },

          function (VarResponseData) {

              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('RssFeedData').each(function () {
                    
                      if ($(this).find('Title').text() != "") {
                          $('#txtTitle').val($(this).find('Title').text());
                      }
                      if ($(this).find('URL').text() != "") {
                          $('#txtUrl').val($(this).find('URL').text());
                      }
                      if ($(this).find('IsPublic').text() == "True") {
                          $("#UrlPublic").attr("checked", true);
                      }

                      else {
                          $("#UrlPublic").attr("checked", false);
                      }
                     
                  });
              }); //end of Response   
             
          });                  //End of Ajax

    return false;
}
