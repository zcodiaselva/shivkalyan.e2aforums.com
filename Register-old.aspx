<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register-old.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head>
    <meta charset="utf-8">
    <title>Register e2aForums</title>
    <meta name="description" content="e2aforums">
    <meta name="author" content="e2aforums">
    <meta name="robots" content="noindex, nofollow">
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">
    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="img/favicon.ico">
    <link rel="apple-touch-icon" href="img/icon57.png" sizes="57x57">
    <link rel="apple-touch-icon" href="img/icon72.png" sizes="72x72">
    <link rel="apple-touch-icon" href="img/icon76.png" sizes="76x76">
    <link rel="apple-touch-icon" href="img/icon114.png" sizes="114x114">
    <link rel="apple-touch-icon" href="img/icon120.png" sizes="120x120">
    <link rel="apple-touch-icon" href="img/icon144.png" sizes="144x144">
    <link rel="apple-touch-icon" href="img/icon152.png" sizes="152x152">
    <!-- END Icons -->
    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <link rel="stylesheet" href="User/css/bootstrap.min.css">
    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="User/css/plugins.css">
    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="User/css/main.css">
    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->
    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="User/css/themes.css">
    <!-- END Stylesheets -->
    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="User/js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <script src="js/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="https://connect.facebook.net/en_US/all.js#xfbml=1&appId=551080798330891"></script>
    <script src="js/script.js"></script>
    <%-- <script src="js/GoogleAnalytics.js"></script>--%>
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {

            //window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
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
</head>
<body class="loginbg">
    <div id="facebook1">
        <div id="fb-root"></div>
    </div>
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
    <!-- Login Container -->
    <div id="login-container" class="animation-fadeIn">
        <!-- Login Title -->
        <div class="login-title text-center">
            <h1>
                <img src="User/img/logoblue2.png" /><br>
                <small><strong>Register</strong></small>
            </h1>
        </div>
        <!-- END Login Title -->
        <!-- Login Block -->
        <div class="block remove-margin">
            <!-- Register Form -->
            <form id="formregister" runat="server" class="form-horizontal form-bordered form-control-borderless" autocomplete="off">
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-envelope"></i></span>
                            <asp:TextBox ID="txtEmailID" placeholder="Email" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-11 col-xs-offset-1 text-left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="txtEmailID"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-11 col-xs-offset-1 text-left">
                        <asp:RegularExpressionValidator Style="font-size: small; margin-top: 3px;" ID="RegularExpressionValidator2"
                            runat="server" ErrorMessage="* Email is invalid." ControlToValidate="txtEmailID"
                            ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                            <asp:TextBox ID="txtpwd" TextMode="Password" runat="server" class="form-control input-lg" MaxLength="25" placeholder="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-11 col-xs-offset-1 text-left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                            runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="txtpwd"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-11 col-xs-offset-1 text-left">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server" ErrorMessage="* use atleast 1 number & letter and min length of 6 characters" ControlToValidate="txtpwd" ValidationGroup="password"
                            ForeColor="Red" Display="Dynamic" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{6,15})$"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                            <asp:TextBox ID="txtConfPwd" TextMode="Password" runat="server" class="form-control input-lg" placeholder="Confirm Password" MaxLength="25"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="col-xs-11 col-xs-offset-1 text-left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="txtConfPwd"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-11 col-xs-offset-1 text-left">
                        <asp:CompareValidator ID="passwordcompare" ControlToCompare="txtpwd" ErrorMessage="* password didn't match" ControlToValidate="txtConfPwd" runat="server" ForeColor="Red"></asp:CompareValidator>

                    </div>
                </div>
                   <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-user"></i></span>
                            <asp:TextBox ID="TxtFirstName" placeholder="First Name" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-11 col-xs-offset-1 text-left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="TxtFirstName"></asp:RequiredFieldValidator>
                    </div>
                   
                </div>
                 <div class="form-group">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="gi gi-user"></i></span>
                            <asp:TextBox ID="TxtLastName" placeholder="Last Name" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                        </div>
                    </div>
                   <%-- <div class="col-xs-11 col-xs-offset-1 text-left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                            runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="TxtName"></asp:RequiredFieldValidator>
                    </div>--%>
                   
                </div>
                <div class="form-group form-actions">
                    <div class="col-xs-11 col-xs-offset-1 text-danger text-left">
                        <asp:Literal Text="" ID="lblMessageSignIn" runat="server" />
                    </div>
                    <div class="col-sm-9">
                        <div class="input-group text-info text-left checkbox-inline">
                            <asp:CheckBox ID="check1" Checked="true" Text="" AutoPostBack="false" runat="server" />
                            I agree to the <a href="TermsOfUse.aspx" target="_blank" style="color: #f31455;">Terms of Use</a> and <a target="_blank" href="PrivacyPolicy.aspx" style="color: #f31455;">Privacy
                            Policy</a><br />
                            <asp:CustomValidator ID="custValidPP" runat="server" EnableClientScript="true"
                                ErrorMessage="* required" OnServerValidate="CheckBoxRequired_ServerValidate" ForeColor="Red"
                                ClientValidationFunction=""></asp:CustomValidator>
                        </div>
                        <div class="input-group text-info text-left checkbox-inline">
                            <asp:CheckBox ID="chknewsletterBox" Text="" AutoPostBack="false" runat="server" />
                            Receive discounts/newsletter via e-mail
                        </div>

                    </div>
                    <div class="col-sm-2 text-center">
                        <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-sm btn-primary" Text="Register"
                            class="mysubmit" OnClick="btnRegister_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <div style="margin-top: 5px;" class="col-sm-4 text-center">
                        <a href="#" onclick="javascript:return fbAuth();">
                            <img src="img/fsignup.png" alt="Register with Facebook" /></a>
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
                    </div>
                    
                    <div class="col-sm-4 text-center" style="margin-top: 5px;"> 
                        <div id="customBtn1" class="customGPlusSignIn" style="text-align: center;position:absolute;">
                                <span class="icon"></span>
                                <span class="buttonText"></span>
                            </div>
                        <a href="#" onclick="javascript:$('#customBtn1').click();">
                       <%-- <a href="#" style="margin-top: 10px;" onclick="javascript:return OpenGmailauth();">--%>
                            <img src="img/gsignup.png" alt="Register with Google" /></a>

                    </div>
                    <div style="margin-top: 5px;" class="col-sm-4 text-center">
                        <a href="#" onclick="javascript:return OpenLinkauth();">
                            <img src="img/lsignup.png" alt="Register with Linkedin" /></a>

                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <p class="text-center remove-margin text-info">
                            <small>Oops, you have an account?</small>
                            <a style="color: #F39" href="Login.aspx">Login!</a>
                        </p>
                    </div>
                </div>
            </form>
            <!-- END Register Form -->
        </div>
        <!-- END Login Block -->
    </div>
    <!-- END Login Container -->
    <form id="frmGoogleLogin" action="#" method="post">
        <input type="hidden" name="Email" id="hiddEmail" value="" />
        <input type="hidden" name="Gender" id="hiddGender" value="" />
        <input type="hidden" name="Name" id="hiddName" value="" />
        <input type="hidden" name="Mode" id="hiddMode" value="" />
    </form>
    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>        !window.jQuery && document.write(unescape('%3Cscript src="js/vendor/jquery-1.11.0.min.js"%3E%3C/script%3E'));</script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="User/js/vendor/bootstrap.min.js"></script>
    <script src="User/js/plugins.js"></script>
    <script src="User/js/app.js"></script>
    <!-- Load and execute javascript code used only in this page -->
    <script src="User/js/pages/login.js"></script>
  
    <script>

        $(function () {
            Login.init();

            $("#register-email").val('');
            $("#register-email").val('');

        });


    </script>


</body>
</html>
