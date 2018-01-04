<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBarControl.ascx.cs" Inherits="User_UserControls_SideBarControl" %>
<script src="js/jquery-1.7.2.js" type="text/javascript"></script>

<!-- END Alternative Sidebar -->
<!-- Main Sidebar -->

<!-- END Main Sidebar -->
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-61242415-1', 'auto');
    ga('send', 'pageview');

</script>
<script language="javascript" type="text/javascript">

    $(function () {
        var VarIsAdmin = '<%=IsAdmin%>';

        var VarUserTypeID = '<%=UserTypeID%>';

        if ("<%=IsAdmin%>" == 'True') {

            $('.adminLinks').show();
            $('.UserLinks').hide();
            $('#li_Courses').hide();
           
        }
        if (VarUserTypeID == 1) {
            $('#li_edu').show();
        }
        if (VarUserTypeID != 2) {
            $('.UserLinks').show();
           
        }
        if (VarUserTypeID == 3) {
            $('.Usertabs').show();
            $('#li_Courses').show();
           
        }
        if (VarUserTypeID == 4) {
            $('#li_Courses').show();
        }
        if (VarUserTypeID == 2) {
            $('#li_clients').show();
            $('#li_followUp').show();
            $('#li_UserDoc').show();
            $('#li_products').show();
        }
        else {
            $('.Usertabs').hide();
        }
        if (window.location.href.indexOf("Experts.aspx") != -1) {
            $('#Experts-a').addClass("active");
        }
        else if (window.location.href.indexOf("Forum.aspx") != -1) {
            $('#Forum-a').addClass("active");

        }
        else if (window.location.href.indexOf("Category.aspx") != -1) {
            $('#CategoryList-a').addClass("active");
        }
        else if (window.location.href.indexOf("Message.aspx") != -1) {
            $('#Message-a').addClass("active");
        }
        else if (window.location.href.indexOf("Profile.aspx") != -1) {
            $('#Profile-a').addClass("active");
        }
        else if (window.location.href.indexOf("CalendarEvents.aspx") != -1) {
            $('#Calendar-a').addClass("active");

        }
        else if (window.location.href.indexOf("Topic.aspx") != -1) {
            $('#Topic-a').addClass("active");

        }
        else if (window.location.href.indexOf("Advertisement.aspx") != -1) {
            $('#Advertisement-a').addClass("active");

        }
        else if (window.location.href.indexOf("RSSFeed.aspx") != -1) {
            $('#RssFeed-a').addClass("active");
        }
        else if (window.location.href.indexOf("Education.aspx") != -1) {
            $('#Education-a').addClass("active");
        }
        else if (window.location.href.indexOf("Education.aspx") != -1) {
            $('#Education-a').addClass("active");
        }
        else if (window.location.href.indexOf("Courses.aspx") != -1) {
            $('#Courses-a').addClass("active");
        }
        else if (window.location.href.indexOf("Customers.aspx") != -1) {
            $('#Customers-a').addClass("active");
        }
        else if (window.location.href.indexOf("Followup.aspx") != -1) {
            $('#FollowUp-a').addClass("active");
        }
        else if (window.location.href.indexOf("UserDocuments.aspx") != -1) {
            $('#UserDocuments-a').addClass("active");
        }
        getLoggedInUserDet();

        if (VarIsAdmin == 'False') {
            ShowAdvertisement();
        }

    });
  

  
    function getLoggedInUserDet() {

        NProgress.start();

        console.log("1");

        $.post("Ajax/AjaxUser.aspx",
        {
            Mode: "GETUSERDET"

        },
      function (VarResponseData) {

          //alert(VarResponseData);


          //console.log("hello1234");
          $(VarResponseData).find('Response').each(function () {
              $(VarResponseData).find('AdminData').each(function () {
                  console.log("hello");
                  console.log($(this).find('Full_Name').text());
                  if ($(this).find('Full_Name').text() != "") {
                      $('#lbl_Name').html($(this).find('Full_Name').text());
                      $('#lbl_Name').attr('readonly', 'readonly');
                  }

                  if ($(this).find('Picture').text() != "")
                      $("#sidebar_profilepic").attr("src", "../" + $(this).find('Picture').text());
                  else
                      $("#sidebar_profilepic").attr("src", "../img/AnonymousGuyPic.jpg");

              });

          }); //end of Response 
          NProgress.done();
      });                  //End of Ajax

        return false;
    }

    function ViewNotifications(mvarReferenceID, mvarNotificationType, mvarNotificationID) {

        $('#hiddId').val(mvarReferenceID);
        $('#hiddType').val(mvarNotificationType);
        $('#hiddNotificationID').val(mvarNotificationID);
        document.forms["frmNotification"].submit();
        return false;
    }

    function ShowAdvertisement() {
        

        var VarIsAdmin = '<%=IsAdmin%>';

        if (VarIsAdmin == "False") {

            NProgress.start();

            $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "SHOWADVERTISEMENT"

            },

          function (VarResponseData) {

              $('#ul_advertisement').empty();
              $('#ul_advertisement').append(VarResponseData.split('#')[0]);
              $('#ul_TopBaradvertisement').empty();
              $('#ul_TopBaradvertisement').append(VarResponseData.split('#')[1]);

              // $('#ul_advertisement').append(VarResponseData);
              NProgress.done();
          });
        }//End of Ajax

        return false;
    }

    //function GetAdvertisementViewersCount(pvarAdvertisementID, pvarClickUrl) {
    //    $('#advertclick').attr('href', pvarClickUrl);

    //    $.post("Ajax/AjaxUser.aspx",
    //       {
    //           Mode: "GETADVERTISEMENTVIEWERSCOUNT",
    //           AdvertisementID: pvarAdvertisementID

    //       },
    //        function (varResponseData) {

    //            if (varResponseData != "") {

    //                if ((varResponseData == "SUCCESS")) {                         
    //                    $('#advertclick').get(0).click();
    //                }
    //            }
    //        });

    //    return false;
    //}
</script>
