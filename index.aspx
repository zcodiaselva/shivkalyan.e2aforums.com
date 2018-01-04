<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script type="text/javascript">
            window.onbeforeunload = function (e) {
                gapi.auth.signOut();
            };
            (function () {
                var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true;
                po.src = 'https://apis.google.com/js/client:plusone.js?onload=render';
                var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s);
            })();
            function render() {
                gapi.signin.render('customBtn', {
                    'clientid': '844508888657-bllu707iejjnpj4l1b7socb673ui9h76.apps.googleusercontent.com',
                    'cookiepolicy': 'single_host_origin',
                    'scope': 'email',
                    'callback': 'onSignInCallback'
                });
                gapi.signin.render('customBtn1', {
                    'clientid': '844508888657-bllu707iejjnpj4l1b7socb673ui9h76.apps.googleusercontent.com',
                    'cookiepolicy': 'single_host_origin',
                    'scope': 'email',
                    'callback': 'onSignInCallback'
                });
            }
            function onSignInCallback(resp) {

                if (resp['g-oauth-window']) {
                    gapi.client.load('plus', 'v1', apiClientLoaded);
                } else if (resp['error']) {
                    console.log('error')
                }


            }
            function apiClientLoaded() {
                gapi.client.plus.people.get({ userId: 'me' }).execute(handleEmailResponse);
            }
            function handleEmailResponse(resp) {
                if (resp.code != 403) {
                    var primaryEmail = "";
                    var gender = "";
                    var fullname = "";
                    for (var i = 0; i < resp.emails.length; i++) {
                        if (resp.emails[i].type === 'account') primaryEmail = resp.emails[i].value;
                    }
                    gender = resp.gender;
                    fullname = resp.displayName;

                    if (primaryEmail != '' || primaryEmail != undefined) {
                        $('#hiddEmail').val(primaryEmail);
                        $('#hiddGender').val(gender);
                        $('#hiddName').val(fullname);
                        $('#hiddMode').val('Reg');
                        $('#frmGoogleLogin').attr('action', 'GmaiAuth.aspx');
                        $('#frmGoogleLogin').submit();

                    }
                }
            }
    </script>
  <script type="text/javascript" src="https://connect.facebook.net/en_US/all.js#xfbml=1&appId=551080798330891"></script>
  <script type="text/javascript">
        function SendMessage() {
            var vaa = 1;

            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
            var email_chk = $('#txtNewsEmail').val();
            if (email_chk == '') {
                alert('Email ID canot not be empty!')
            }
            else if (reg.test(email_chk) == false) {
                vaa = -1;
                alert('Please provide a valid email address');
            }
            else if (email_chk != '' && reg.test(email_chk) == true) {
                //  txtNewsEmail
                //  btn_saveNewslatter"
                $.post("Ajax/AjaxUser.aspx",
                        {
                            Mode: "EMAILNEWSLATTER",
                            EMAILNEWSLATTER: $('#txtNewsEmail').val()

                        },
                            function (mstrResponseData) {

                                if (mstrResponseData == "SUCCESS") {
                                    $('#txtNewsEmail').val("");
                                    $('.signup_tour_output').css({ display: 'block' });
                                    $('.signup_tour_inner').css({ display: 'none' });
                                    $('#out_p').html("Successfully Subscribed");
                                    $('#out_p').css({ color: 'green' });


                                }
                                else {

                                    $('.signup_tour_inner').css({ display: 'none' });
                                    $('.signup_tour_output').css({ display: 'block' });

                                    $('#out_p ').html("Already Subscribed");
                                    $('#out_p').css({ color: 'red' });

                                }

                            });


                return false;
            }
        }
    </script>
  <script type="text/javascript">
        $(document).ready(function () {

            document.forms["frmGoogleLogin"].reset();

        });
        function fbAuth() {

            FB.login(function (response) {

                // handle the response
            }, { scope: 'email' });
            return false;

        }
        function OpenGmailauth() {
            myRef = popupwindow('GmaiAuth.aspx', 'Gmail Authentication', 500, 600);
            myRef.focus();
            return false;
        }
        function OpenLinkauth() {
            myRef = popupwindow('linkauth.aspx', 'LinkedIn Authentication', 550, 700);
            myRef.focus();
            return false;
        }
        function popupwindow(url, title, w, h) {
            var left = (screen.width / 2) - (w / 2);
            var top = 0;// (screen.height/2)-(h/2);
            return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }
    </script>
  <script>
          window.fbAsyncInit = function () {
              FB.init({
                  appId: '551080798330891', // App ID
                  status: false, // check login status
                  cookie: true, // enable cookies to allow the server to access the session
                  xfbml: true  // parse XFBML               

              });

              // Additional initialization code here
          };
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <form id="form1" runat="server" class="form-horizontal" autocomplete="off">
  <div class="main_slider">
    <div class="container">
      <div class="slider-wrap">
        <div class="baner_text">
          <h6>Log in <a href="Register.aspx">or Sign Up</a></h6>
          <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
          <div class="form-group">
            <div class="col-sm-12">
              <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email">--%>
              <asp:TextBox ID="txtRegEmail" placeholder="Email" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Email required"
                                    ForeColor="Red" ControlToValidate="txtRegEmail"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="form-group">
            <div class="col-sm-12">
              <%--  <input type="password" class="form-control" id="inputPassword3" placeholder="Password">--%>
              <asp:TextBox ID="txtRegPwd" TextMode="Password" runat="server" class="form-control input-lg" MaxLength="25" placeholder="Password"></asp:TextBox>
            </div>
            <div class="col-sm-12">
              <div class="error-alert">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" * Password required"
ForeColor="Red" ControlToValidate="txtRegPwd"></asp:RequiredFieldValidator>
                <br>
                <asp:Literal Text="" ID="lblMessageSignIn" runat="server" />
              </div>
            </div>
          </div>
          <div class="form-group remb">
            <div class="col-sm-offset-2 col-sm-12">
              <div class="checkbox">
                <label>
                  <asp:CheckBox ID="chkRememberMe" Checked="true" Text="" AutoPostBack="false" runat="server" />
                  Remember me </label>
                <asp:LinkButton ID="lnkForgot" Text="Forgot password ?" runat="server" CausesValidation="false" OnClick="Unnamed1_Click" />
              </div>
            </div>
          </div>
          <div class="form-group">
            <div class="col-sm-offset-2 col-sm-12">
              <%-- <button type="submit" class="btn btn-default">Log in</button>--%>
              <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="btn btn-default" OnClick="btnSignIn_Click" />
            </div>
          </div>
          <div class="social_contact">
            <div class="join"><span> Sign In With</span></div>
            <span class="social-contact-btn"> <span class="facebook"> <a href="#" onclick="javascript:return fbAuth();"> <i class="fa fa-facebook"></i> Facebook </a> 
            <script>
			   FB.Event.subscribe('auth.authResponseChange', function (response) {
				   if (response.status === 'connected') {
					   var uid = response.authResponse.userID;
					   var accessToken = response.authResponse.accessToken;

					   var form = document.createElement("form");
					   form.setAttribute("method", 'post');
					   form.setAttribute("action", 'FacebookLogin.ashx'); //'FBSuccess.aspx');

					   var field = document.createElement("input");
					   field.setAttribute("type", "hidden");
					   field.setAttribute("name", 'accessToken');
					   field.setAttribute("value", accessToken);
					   form.appendChild(field);

					   document.body.appendChild(form);
					   form.submit();

				   } else if (response.status === 'not_authorized') {
					   alert('User not authorized');
					   // the user is logged in to Facebook, 
					   // but has not authenticated your app
				   } else {
					   // the user isn't logged in to Facebook.
					   alert('User was unable to login to Facebook');
				   }
			   });

			</script> 
            </span> <span class="gplus">
            <div id="customBtn" class="customGPlusSignIn hidden" data-gapiattached="true"> <span class="icon"></span> <span class="buttonText"></span> </div>
            <a href="#" onclick="javascript:$('#customBtn').click();"> <i class="fa fa-google-plus"></i> Google+</a> </span> <span class="linked"> <a href="#" onclick="javascript:return OpenLinkauth();"> <i class="fa fa-linkedin"></i> Linkedin</a> </span> </div>
        </div>
        </ContentTemplate>
        <Triggers>
          <asp:PostBackTrigger ControlID="btnSignIn" />
          <asp:PostBackTrigger ControlID="lnkForgot" />
        </Triggers>
        </asp:UpdatePanel>
      </div>
    </div>
  </div>
  </div>
  
  <!--==========mainslider ends========-->
  <div class="content_part">
    <div class="container">
      <div class="row">
        <div class="col-md-9 col-sm-8">
          <div class="about_forums">
            <div class="heading">
              <h3>About e2aforums</h3>
            </div>
            <div class="about_forums_text">
              <p>www.e2aforums.com is about connecting experts and advisors from different fields of financial industry such as Insurance, Investments, Tax Planning, Accounting, Mortgage Brokers, Financial Coaching, Lawyers specializing in Tax, Estate Planning, Real Estate etc.</p>
              <p>It's also about learning and sharing your knowledge with others. As a member you can build your own sphere of influence, attract new clients, build new relationships and provide qualified advice to your clients. Manage your clients with a simplified Client Relationship Management program.  This is truly your "one stop go to" site to learn about current topics affecting the financial industry and educating others and public at large. Sign up is easy!!</p>
            </div>
          </div>
          <div class="hot_threads">
            <div class="heading">
              <h3>Hot Threads</h3>
            </div>
            <div class="hot_threads_text"><img src="ashi/images/hot_ques.jpg" alt=""> <a href="Register.aspx">Sign up to join our discussion</a> </div>
          </div>
        </div>
        <div class="col-md-3 col-sm-4 aside">
          <div class="website-user-counter">
            <h4>counter</h4>
            <div class="flip-couter-wrapper">
              <ul>
                <li>
                  <asp:Label ID="lbl_digit6_TotalOnlineUsers" runat="server" Text="0"></asp:Label>
                </li>
                <li>
                  <asp:Label ID="lbl_digit5_TotalOnlineUsers" runat="server" Text="0"></asp:Label>
                </li>
                <li>
                  <asp:Label ID="lbl_digit4_TotalOnlineUsers" runat="server" Text="0"></asp:Label>
                </li>
                <li>
                  <asp:Label ID="lbl_digit3_TotalOnlineUsers" runat="server" Text="0"></asp:Label>
                </li>
                <li>
                  <asp:Label ID="lbl_digit2_TotalOnlineUsers" runat="server" Text="0"></asp:Label>
                </li>
                <li>
                  <asp:Label ID="lbl_digit1_TotalOnlineUsers" runat="server" Text="0"></asp:Label>
                </li>
              </ul>
            </div>
            <ul class="members-counter">
              <li><span>Members:</span><span>
                <asp:Label ID="lbl_Member_count" runat="server" Text="0"></asp:Label>
                </span></li>
              <li><span>Posts:</span><span>
                <asp:Label ID="lbl_Topic_count" runat="server" Text="0"></asp:Label>
                </span></li>
            </ul>
          </div>
          <div id="fb-root"></div>
          <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.4&appId=649923888378198";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
          <div class="fb-page" data-href="https://www.facebook.com/join.e2aforums" data-width="312px" data-height="450" data-small-header="false" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true" data-show-posts="true">
            <div class="fb-xfbml-parse-ignore">
              <blockquote cite="https://www.facebook.com/join.e2aforums"><a href="https://www.facebook.com/join.e2aforums">E2aforums</a></blockquote>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  
  <!--====Our Experts======-->
  <div class="our_experts text-center">
    <h3>Our Top Experts</h3>
    <div class="container">
      <ul class="experts_img" >
        <li><a data-toggle="modal" data-target="#expert_info"  onclick="return ShowProfileModal(20260)" > <img width="101" src="ashi/images/vinay-khosla.jpg" class="img-responsive img-circle" alt="Vinay Khosla">
          <h6>Vinay Khosla</h6>
          </a> </li>
        <li> <a data-toggle="modal" data-target="#expert_info"  onclick="return ShowProfileModal(20241)" > <img width="101" src="ashi/images/christine.jpg" class="img-responsive img-circle" alt="Christine Hughes">
          <h6>Christine Hughes</h6>
          </a> </li>
        <li> <a data-toggle="modal" data-target="#expert_info"  onclick="return ShowProfileModal(-1)" > <img width="101" src="ashi/images/steve.jpg" class="img-responsive img-circle" alt="Steve Reesor">
          <h6>Steve Reesor</h6>
          </a> </li>
        <li> <a data-toggle="modal" data-target="#expert_info"  onclick="return ShowProfileModal(27)" > <img width="101" src="ashi/images/troy.jpg" class="img-responsive img-circle" alt="Troy McLean">
          <h6>Troy McLean</h6>
          </a> </li>
        <li> <a data-toggle="modal" data-target="#expert_info"  onclick="return ShowProfileModal(31)" > <img width="101" src="ashi/images/Avraham.jpg" class="img-responsive img-circle" alt="">
          <h6>Avraham Byers</h6>
          </a> </li>
        <li> <a data-toggle="modal" data-target="#expert_info"  onclick="return ShowProfileModal(20251)" > <img width="101" src="ashi/images/ME.png" class="img-responsive img-circle" alt="">
          <h6>Charlie Conron</h6>
          </a> </li>
        <li> <a data-toggle="modal" data-target="#expert_info"  onclick="return ShowProfileModal(20258)" > <img width="101" src="ProfilePics/Jason1511131240.png" class="img-responsive img-circle" alt="">
          <h6>Jason Heath</h6>
          </a> </li>
      </ul>
      <a href="Register.aspx">
      <button type="button"  class="btn btn-default login_button">Sign Up Now</button>
      </a> </div>
  </div>
  
  <!--====Our Experts Ends======--> 
  
  <!--====Newsletter======-->
  <div class="signup_tour">
  <div class="signup_tour_inner">
  <div class="signup_login"><img src="ashi/images/signup.png" class="img-responsive" alt=""></div>
  <h3>Sign up for Our NewsLetter</h3>
  <p>Join over 5,000 people who get free and fresh content delivered automatically each time we publish.</p>
  <div class="signup-form">
  <form>
    <input type="email" class="" ID="txtNewsEmail" placeholder="ENTER YOUR EMAIL HERE"/>
    <%-- <asp:TextBox  placeholder="ENTER YOUR EMAIL HERE" runat="server"></asp:TextBox>--%>
    <%--<asp:Button  Text="Sign Up Now" />--%>
    <input  id="btn_saveNewslatter" onclick="SendMessage()" class="btn btn-default center-block login_button"  type="button" value="Sign Up Now" />
  </form>
  </div>
  </div>
  <div class="signup_tour_output" style="display:none">
    <h3>Sign up for Our NewsLetter</h3>
    <p id="out_p" > </p>
  </div>
  </div>
  <!--====Newsletter ends======--> 
  
  <!--=====forums=====-->
  <div class=" forums">
    <h3>Why Use e2aforums?</h3>
    <div class="container">
      <div class="forum_data">
        <div class="left_forum_data">
          <div class="askquestion"> <img src="ashi/images/askquestion.png" class="img-responsive ask" alt="">
            <div class="text_2">
              <h4>Ask Questions from Industry Experts</h4>
              <p>Ask questions from the experts, who are members on this site and seek their opinion on any topic of your choice.</p>
            </div>
          </div>
          <div class="askquestion"> <img src="ashi/images/premiumvideos.png" class="img-responsive ask" alt="">
            <div class="text_2">
              <h4>Get Access to Premium Video Tutorials</h4>
              <p>Our members obtain easy access to premium video tutorials related to their domain or interest. </p>
            </div>
          </div>
          <div class="askquestion"> <img src="ashi/images/Manageclients.png" class="img-responsive ask" alt="">
            <div class="text_2">
              <h4>Convert Leads & Manage Clients</h4>
              <p>We offer a complete leads management system so you never lose track of your prospects or clients, resulting in a more efficient business.</p>
            </div>
          </div>
        </div>
        <div class="tab"> <img src="ashi/images/tab.png" class="img-responsive" alt=""> <a class="btn btn-default signUpBtn" href="Register.aspx">Sign Up</a> </div>
        <div class="right_forum_data">
          <div class="calender"> <img src="ashi/images/calender.png" class="img-responsive document" alt=""/>
            <div class="text_2">
              <h4>Calender, Tasks & Reminder</h4>
              <p>Using e2aforums, you can tackle your to-do list with complete ease. Set up reminders and never miss an important date.</p>
            </div>
          </div>
          <div class="calender mttop2"> <img src="ashi/images/document_storage.png" class="img-responsive document" alt="">
            <div class="text_2">
              <h4>Document Storage</h4>
              <p>We make it simple to move and store your business documents off-site. Store all your docs online at one place for quick retrieval.</p>
            </div>
          </div>
          <div class="calender sttop"> <img src="ashi/images/rss.png" class="img-responsive document" alt=""/>
            <div class="text_2">
              <h4>Customized RSS feeds to Your Favorite Website</h4>
              <p>Subscribe to your favorite RSS feeds and browse them at one place conveniently.</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  
  <!--=====forums end here=====--> 
  
  <!--expert_info Biography Modal Start -->
  <div id="expert_info" class="modal fade" role="dialog">
    <div class="modal-dialog customModel"> 
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-body">
          <div class="profilePopHeader">
            <div id="profilePic"> </div>
            <div class="profileDes"> <span class="eprofileName"><i class="fa fa-user"></i> -</span><br>
              <span class="eprofileEmail"><i class="fa fa-envelope-o"></i> -</span> </div>
            <div class="profileAddress">
              <div class="closePopup"  data-dismiss="modal">Press esc to exit <i class="fa fa-sign-in"></i></div>
            </div>
          </div>
        </div>
        <div class="profilePopBody">
          <div class="row">
            <div class="col-md-12">
              <p id="eaboutMe">-</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- expert_info Biography Modal End-->
  </form>
  <form id="frmGoogleLogin"  action="#" method="post">
    <input type="hidden" name="Email" id="hiddEmail" value="" />
    <input type="hidden" name="Gender" id="hiddGender" value="" />
    <input type="hidden" name="Name" id="hiddName" value="" />
    <input type="hidden" name="Mode" id="hiddMode" value="" />
  </form>
  <!-- jQuery -->
  <%--<script  defer="defer">
    var ref = ('' + document.referrer + '');
    var w_h = window.screen.width + " x " + window.screen.height;
    document.write('<script src="http://s1.freehostedscripts.net/ocounter.php?site=ID4964481&e1=Online User&e2=Online Users&r=' + ref + '&wh=' + w_h + '"><\/script>');
</script>--%>
  
  <!-- jQuery (necessary for Bootstrap's JavaScript plugins) --> 
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script> 
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script> 
  <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js"></script> 
  <script src="User/js/plugins.js"></script> 
  <script src="User/js/app.js"></script> 
  <!-- Load and execute javascript code used only in this page --> 
  <script src="User/js/pages/login.js"></script> 
  <script>
    document.addEventListener("keypress", function (e) {
        var getKeyCode = e.keyCode;
        if (getKeyCode == 27) {
            var getCodeId = document.getElementById("expert_info");
            getCodeId.classList.remove("in");
            var selements = document.getElementsByClassName('modal-backdrop');
            for (var i = 0; i < selements.length; ++i)
                selements[i].classList.remove("in");
        }
    });
</script> 
  <script>

        $(function () {
            Login.init();
        });

        function ShowProfileModal(pvarUserID) {
            $.post("Ajax/AjaxUser.aspx",
                    {
                        Mode: "VIEWUSERPROFILE",
                        UserID: pvarUserID
                    },
                  function (VarResponseData) {
                      $(VarResponseData).find('Response').each(function () {
                          $(VarResponseData).find('UserData').each(function () {


                              if ($(this).find('AboutMe').text() != "") {
                                  $('#eaboutMe').html($(this).find('AboutMe').text());
                              }
                              else {
                                  $('#eaboutMe').html('-');
                              }

                              if ($(this).find('Full_Name').text() != "") {
                                  $('.eprofileName').html($(this).find('Full_Name').text());
                              } else {
                                  $('.eprofileName').html('-');
                              }
                              if ($(this).find('EMail').text() != "") {
                                  $('.eprofileEmail').html($(this).find('EMail').text());
                              } else {
                                  $('.eprofileEmail').html('-');
                              }
                              if ($(this).find('Picture').text() != "") {
                                  $('#profilePic').html($(this).find('Picture').text());
                              }


                              //if ($(this).find('Address_line1').text() != "") {
                              //    $('#p_address1').html($(this).find('Address_line1').text());
                              //}
                              //if ($(this).find('Address_Line2').text() != "") {
                              //    $('#p_address1').html($('#p_address1').html() + "<br/>" + $(this).find('Address_Line2').text());
                              //}
                              //if ($(this).find('Address_Line3').text() != "") {
                              //    $('#p_address1').html($('#p_address1').html() + "<br/>" + $(this).find('Address_Line3').text());
                              //}
                              //if ($(this).find('City').text() != "") {
                              //    $('#p_City').html($(this).find('City').text());
                              //}
                              //if ($(this).find('Organization').text() != "") {
                              //    $('#p_Organization').html($(this).find('Organization').text());
                              //}
                              //if ($(this).find('Mobile_Phone').text() != "") {
                              //    $('#p_Mobile').html($(this).find('Mobile_Phone').text());
                              //}
                              //if ($(this).find('Occupation').text() != "") {
                              //    $('#p_Occupation').html($(this).find('Occupation').text());
                              //}
                              //if ($(this).find('DealerName').text() != "") {
                              //    $('#p_DealerName').html($(this).find('DealerName').text());
                              //}
                              //if ($(this).find('MGA').text() != "") {
                              //    $('#p_MGA').html($(this).find('MGA').text());
                              //}
                              ////if ($(this).find('GoverningBody').text() != "") {
                              //    $('#p_GoverningBody').html($(this).find('GoverningBody').text());
                              //}
                              //if ($(this).find('InBusinessSince').text() != "") {
                              //    $('#p_InBusinessSince').html($(this).find('InBusinessSince').text());
                              //}

                              //if ($(this).find('ProfileYoutubeURL').text() != "") {
                              //    $('#divYoutubeVideo').html($(this).find('ProfileYoutubeURL').text());
                              //}
                          });

                      }); //end of Response   
                      NProgress.done();
                  });                 //End of Ajax

            return false;
        }
    </script> 
</asp:Content>
