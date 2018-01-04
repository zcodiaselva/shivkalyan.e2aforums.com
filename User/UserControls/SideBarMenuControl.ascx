<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBarMenuControl.ascx.cs" Inherits="User_UserControls_SideBarControl" %>
<script src="js/jquery-1.7.2.js" type="text/javascript"></script>

<form class="right-sidebar-menu">
  <!-- START PAGE SIDEBAR -->
  <div class="page-sidebar"> 
    <!-- START X-NAVIGATION -->
    <ul class="x-navigation">
      <li class="xn-logo"> <a href="index.aspx">e2afroums</a> <a href="#" class="x-navigation-control"></a> </li>
      <li class="xn-profile"> <a href="#" class="profile-mini"> <img id="sidebar_profilepic"  alt="John Doe"/> </a>
        <div class="profile">
          <div class="profile-image"> <img id="UserMainPic" src="assets/images/users/avatar.jpg" onError="this.onerror=null;this.src='../E2Forums-New/img/default_profile_pic.jpg';" alt=""/> </div>
          <div class="profile-data">
            <div class="profile-data-name"> <span id="lbl_Name"></span></div>
            <div class="profile-data-title"></div>
          </div>
          <div class="profile-controls"> <a href="Profile.aspx" class="profile-control-left"><span class="fa fa-info"></span></a>
          <a href="javascript:void();" class="profile-control-right chat-box-button"><span class="fa fa-comment"></span></a> </div>
        </div>
      </li>
      <li class="xn-title">Navigation</li>
    
    </ul>
       <ul class="sidebar-nav x-navigation">
           
           <li>
                <a id="A23" href="index.aspx">
                    <span class="fa fa-home fa-2"></span> 
                    <p>Home</p>
                </a>
            </li>

            <li>
                <a id="profile-a" href="Profile.aspx">
                    <span class="fa fa-user"></span> 
                    <p>Profile</p>
                </a>
            </li>
           <li>
                <a id="A22" href="Forum_new.aspx">
                    <span class="fa fa-file-text-o"></span>
                    <p>Forum</p>
                </a>
            </li>

            <li class="xn-openable" id="CorporateAdmin" style="display: none">
                <a id="A20" href="index.aspx" data-toggle="tooltip" title="Corporate">
                    <span class="fa fa-briefcase"></span> 
                    <p>Corporate</p>
                </a>
                <ul>
                    <li ><a href="CompUsers.aspx"> <i class="fa fa-users"></i><span class="xn-text"> Add User Under Company </span></a></li>
                </ul>
            </li>

            <li class="xn-openable adminLinks " style="display: none">
                <a id="dashboard-a" href="#" data-toggle="tooltip" title="Account">
                    <span class="fa fa-desktop"></span> 
                    <p>Account</p>
                </a>
                <ul>
                    <li ><a href="Users.aspx"><span class="xn-text">All Users</span></a></li>
                </ul>
            </li>

            <li class="xn-openable adminLinks" id="Li1" style="display: none">
                <a id="A8" href="#" data-toggle="tooltip" title="Manage">
                    <span class="fa fa-users"></span> 
                    <p>Manage</p>
                </a>
                <ul>
                      <li ><a href="LatestNewsAdmin.aspx"> <i class="fa fa-newspaper-o"></i><span class="xn-text"> Latest News</span></a></li>
                    <li ><a href="NewsLetterAdmin.aspx"> <i class="fa fa-envelope-o"></i><span class="xn-text"> Newsletter </span></a></li>
                    <li ><a href="TechTipsAdmin.aspx"><i class="fa fa-lightbulb-o"></i><span class="xn-text"> Tech Tip </span></a></li>
                </ul>
            </li>
           
            <li class="adminLinks" style="display: none">
                <a id="CategoryList-a" href="Category.aspx">
                    <span class="fa fa-sitemap"></span> 
                    <p>Category</p>
                </a>
            </li>

            <li class="adminLinks" style="display: none">
                <a id="Topic-a" href="Topic.aspx">
                    <span class="fa fa-commenting-o"></span> 
                    <p>Topic</p>
                </a>
            </li>    



           <li class="xn-openable adminLinks" id="Li6" style="display: none">
                <a id="A3" href="#" data-toggle="tooltip" title="Manage">
                   <span class="fa fa-envelope-o"></span> 
                    <p>Plan</p>
                </a>
                <ul>
                     <li class="adminLinks" style="display: none"><a id="A1" href="PaymentDetails.aspx"><span class="fa fa-dollar"></span><p>Payment Details</p></a></li>
                     <li class="adminLinks" style="display: none"><a id="A14" href="PlanLog.aspx"><span class="fa fa-dollar"></span><p>Plan Log</p></a></li>
                    <li class="adminLinks" style="display: none"><a id="A24" href="PaymentProfile.aspx"><span class="fa fa-user"></span><p>Payment Profile</p></a></li>
                     </ul>
            </li>




         

            <li class="adminLinks" style="display: none">
                <a id="Experts-a" href="Experts.aspx">
                    <i class="fa fa-users"></i> 
                    <p>Experts</p>
                </a>
            </li>
            <li class="adminLinks"  style="display: none">
                <a id="Calendar-a" href="CalendarEvents.aspx">
                    <span class="fa fa-calendar"></span> 
                    <p>Calendar</p>
                </a>
            </li>

            <li class="adminLinks" style="display: none">
                <a id="A2" href="Newsletter.aspx">
                    <span class="fa fa-envelope-o"></span> 
                    <p>Newsletter</p>
                </a>
            </li>
       
            <li class="adminLinks" style="display: none">
                <a id="A7" href="News.aspx">
                    <span class="fa fa-newspaper-o"></span> 
                    <p>Latest News</p>
                </a>
            </li>
            <li class="adminLinks" style="display: none">
                <a id="A6" href="TechTips.aspx">
                    <i class="fa fa-lightbulb-o"></i> 
                    <p>Tech Tips </p>
                </a>
            </li>
  
            <li class="adminLinks"  style="display: none">
                <a id="RssFeed-menu" href="RSSFeed.aspx">
                    <span class="fa fa-rss"></span> 
                    <p>RSS Feed</p>
                </a>
            </li>

            <li  class="adminLinks" id="li_Courses" style="display: none">
                <a id="Courses-a" href="Courses.aspx">
                    <span class="fa fa-book"></span> 
                    <p>Courses</p>
                </a>
            </li> 
   
            <li style="display:none;" id="li_edu" class="adminLinks">
                <a id="Education-a" href="Education.aspx">
                    <span class="fa fa-flask"></span> 
                    <p>Knowledge Base</p>
                </a>
            </li>
   
   
           <%-- <li class="adminLinks" style="display: none" >
                <a id="Advertisement-a" href="Advertisement.aspx">
                    <span class="fa fa-bullhorn"></span> 
                    <p>Advertisement</p>
                </a>
            </li>
            <li class="adminLinks" style="display: none">
                <a id="AdvertisementZone-a" href="AdvertisementZone.aspx">
                    <i class="fa fa-film sidebar-nav-icon"></i> 
                    <p>Advertisement Zone</p>
                </a>
            </li>   --%>
           
            
            <!-- Expert Linkes --> 
   
   
               


            <li class="expertLinks" style="display: none">
                <a id="A4" href="Newsletter.aspx">
                    <span class="fa fa-envelope-o"></span> 
                    <p>Newsletter</p>
                </a>
            </li>
            <li class="expertLinks" style="display: none">
                <a id="A5" href="LatestNews.aspx">
                    <span class="fa fa-newspaper-o"></span> 
                    <p>Latest News</p>
                </a>
            </li>
            <li class="expertLinks" style="display: none">
                <a id="A9" href="TechTips.aspx">
                    <i class="fa fa-lightbulb-o"></i> 
                    <p>Tech Tips </p>
                </a>
            </li>

            <li class="expertLinks"  style="display: none">
                <a id="A10" href="CalendarEvents.aspx">
                    <span class="fa fa-calendar"></span> 
                    <p>Calendar</p>
                </a>
            </li>
   
            <li class="expertLinks"  style="display: none">
                <a id="A11" href="RSSFeed.aspx">
                    <span class="fa fa-rss"></span> 
                    <p>RSS Feed</p>
                </a>
            </li>

            <li  class="expertLinks" id="li2" style="display: none">
                <a id="A12" href="Courses.aspx">
                    <span class="fa fa-book"></span> 
                    <p>Courses</p>
                </a>
            </li> 
    
            <li class="expertLinks" id="li_clients" style="display: none">
                <a id="Customers-a" href="Customers.aspx">
                    <i class="fa fa-crosshairs"></i>
                    <p>Clients/Prospects</p>
                </a>
            </li> 

            <li class="expertLinks" id="li_followUp" style="display: none">
                <a id="FollowUp-a" href="FollowUp.aspx">
                    <i class="fa fa-group"></i> 
                    <p>Follow-up</p>
                </a>
            </li>
   
            <li class="expertLinks" id="li_UserDoc" style="display: none">
                <a id="UserDocuments-a" href="UserDocuments.aspx">
                    <i class="fa fa-file-text"></i> 
                    <p>User Documents</p>
                </a>
            </li>
            <li class="expertLinks" id="li_products" style="display: none">
                <a id="Products-a" href="Products.aspx">
                    <i class="fa fa-star"></i>
                    <p>Products</p>
            </a>
   
            <li style="display:none;" id="li3" class="expertLinks">
                <a id="A13" href="Education.aspx">
                    <span class="fa fa-flask"></span> 
                    <p>Knowledge Base</p>
                </a>
            </li>


            <!--  UserLinks -->

           


            <li class="userLinks" style="display: none">
                <a id="A15" href="Newsletter.aspx">
                    <span class="fa fa-envelope-o"></span> 
                    <p>Newsletter</p>
                </a>
            </li>
            <li class="userLinks" style="display: none">
                <a id="A16" href="LatestNews.aspx">
                    <span class="fa fa-newspaper-o"></span> 
                    <p>Latest News</p>
                </a>
            </li>
            <li class="userLinks" style="display: none">
                <a id="A17" href="TechTips.aspx">
                    <i class="fa fa-lightbulb-o"></i> 
                    <p>Tech Tips </p>
                </a>
            </li>
  
            <li style="display:none;" id="li4" class="userLinks">
                <a id="A18" href="Education.aspx">
                    <span class="fa fa-flask"></span> 
                    <p>Knowledge Base</p>
                </a>
            </li>
 

            <li  class="userLinks" id="li5" style="display: none">
                <a id="A19" href="Courses.aspx">
                    <span class="fa fa-book"></span> 
                    <p>Courses</p>
                </a>
            </li> 
           <li>
                <a id="A21" href="PaymentDetailsMy.aspx">
                    <span class="fa fa-user"></span> 
                    <p>My Payment Details</p>
                </a>
            </li>

 </ul>
 
    <!-- END X-NAVIGATION --> 
  </div>
  <!-- END PAGE SIDEBAR -->
</form>

<script  type="text/javascript">
    checkMenu();
    function checkMenu() {
        $('.sidebar-nav a').removeClass("active");
        var VarIsAdmin = '<%=IsAdmin%>';
        var VarUserTypeID = '<%=UserTypeID%>';
        var ppOccupationID = '<%=pOccupationID%>';
        var varIsCopAdmin = '<%=IsCompAdmin%>';
        var varPlanActive = '<%=PlanActive%>';
        $(".adminLinks").hide();
        $(".expertLinks").hide();
        $(".userLinks").hide();
        if (ppOccupationID == 0) { 
            document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'><i class='fa fa-warning'></i>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Hi! Presently, you're viewing the website in a restricted mode. Please update your profile to gain full access ,<a href='Profile.aspx'> Click Here</a></div>";
            $(".adminLinks").hide();
            $(".expertLinks").hide();
            $(".userLinks").hide();
            return false;
        }
        else {
            if ( VarIsAdmin=='True') {
                $(".adminLinks").show();
                $(".expertLinks").hide();
                $(".userLinks").hide();
                return false;
            } else {
                if (VarUserTypeID == 2) {
                    $(".adminLinks").hide();
                    $(".userLinks").hide();
                    if (varPlanActive == "YES") {
                        $(".expertLinks").show();
                    }
                    else {
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'><i class='fa fa-warning'></i>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Hello User, Your plan is going to expire. Kindly purchase a plan soon.,<a href='../Pricing.aspx' target='_blank'> Click Here</a></div>";
                        $(".expertLinks").hide();
                    }
                    return false;
                }
                else if (VarUserTypeID == 3) {
                    $(".adminLinks").hide();
                    $(".expertLinks").hide();
                   
                    if (varPlanActive == "YES") {
                        $(".userLinks").show();
                    }
                    else {
                        document.getElementById("validation-msg-container").innerHTML = "<div class='alert alert-danger'><i class='fa fa-warning'></i>  <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Hello User, Your plan is going to expire. Kindly purchase a plan soon.,<a href='../Pricing.aspx' target='_blank'> Click Here</a></div>";
                        $(".userLinks").hide();
                    }
                    return false;
                }
            }
            if (varIsCopAdmin == 'True') {
                $('#CorporateAdmin').show();
            } else {
                $('#CorporateAdmin').hide();

            }
            
            return false;
        }
        if (window.location.href.indexOf("Experts.aspx") != -1) {

            $('#Experts-a').addClass("active");

        }
        else if (window.location.href.indexOf("Forum.aspx") != -1) {
            $('#Forum-a').addClass("active");

        }
        else if (window.location.href.indexOf("index.aspx") != -1) {
            $('#dashboard-a').addClass("active");
            $('#Forum-a').removeClass("active");

        }

        else if (window.location.href.indexOf("Category.aspx") != -1) {
            $('#CategoryList-a').addClass("active");
        }
        else if (window.location.href.indexOf("Message.aspx") != -1) {
            $('#Message-menu').addClass("active");
        }
        else if (window.location.href.indexOf("Profile.aspx") != -1) {
            $('#profile-a').addClass("active");
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
            $('#RssFeed-menu').addClass("active");
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
     

       
    }
    


</script>
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


<script type="text/javascript"   >
    $(function () {

        NProgress.start();

        console.log("1");

        $.post("UserProfile.aspx",
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


                  if ($(this).find('Picture').text() != "") {
                      $("#UserMainPic").attr("src", $(this).find('Picture').text());
                      $("#sidebar_profilepic").attr("src", $(this).find('Picture').text());
                  }
                  else {
                      $("#UserMainPic").attr("src", "../img/AnonymousGuyPic.jpg");
                      $("#sidebar_profilepic").attr("src", "../img/AnonymousGuyPic.jpg");
                  }
              });

          }); //end of Response 
          NProgress.done();
      });                  //End of Ajax

        return false;
    });

</script>





