<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head>
    <meta charset="utf-8">
    <title>Login e2aForums</title>
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
    <script src="js/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="https://connect.facebook.net/en_US/all.js#xfbml=1&appId=551080798330891"></script>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <script src="js/script.js"></script>
    <style type="text/css">
        #customBtn, #customBtn1 {
            display: none;
            background: #dd4b39;
            color: white;
            width: 237px;
            height: 24px;
            white-space: nowrap;
            margin-left: 74px;
        }

            #customBtn:hover, #customBtn:hover {
                background: #e74b37;
                cursor: hand;
                cursor: pointer;
            }

        span.icon {
            background: url('images/googlesmall.gif') transparent no-repeat;
            display: inline-block;
            vertical-align: middle;
            width: 21px;
            height: 22px;
            border-right: #bb3f30 1px solid;
        }

        span.buttonText {
            padding: 5px;
            font-size: 12px;
            font-weight: bold;
            /*  Use the Roboto font that is loaded in the <head> */
            font-family: 'Roboto',arial,sans-serif;
        }
    </style>

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
        <%-- <script>
            (function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id))
                    return;
                js = d.createElement(s); js.id = id;
                js.src = "http://connect.facebook.net/en_US/all.js#xfbml=1&appId=551080798330891";
                fjs.parentNode.insertBefore(js, fjs);
            }
            (document, 'script', 'facebook-jssdk'));
        </script>--%>
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
                <small><strong>Login</strong></small>
            </h1>
        </div>
        <!-- END Login Title -->
        <!-- Login Block -->
        <div class="block remove-margin">
            <!-- Register Form -->
            <form id="form1" runat="server" class="form-horizontal form-bordered form-control-borderless" autocomplete="off">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="gi gi-envelope"></i></span>
                                    <asp:TextBox ID="txtRegEmail" placeholder="Email" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-11 col-xs-offset-1 text-left">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Email required"
                                    ForeColor="Red" ControlToValidate="txtRegEmail"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                                    <asp:TextBox ID="txtRegPwd" TextMode="Password" runat="server" class="form-control input-lg" MaxLength="25" placeholder="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-11 col-xs-offset-1 text-left text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" * Password required"
                                    ForeColor="Red" ControlToValidate="txtRegPwd"></asp:RequiredFieldValidator><br />
                                <asp:Literal Text="" ID="lblMessageSignIn" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-11 col-xs-offset-1 text-left text-info">
                                <asp:CheckBox ID="chkRememberMe" Checked="true" Text="" AutoPostBack="false" runat="server" />
                                Remember Password
                            </div>
                        </div>
                        <div class="form-group  form-actions">
                            <div class="col-sm-5 col-sm-offset-1">
                                <div class="input-group text-info text-left">
                                    <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="btn btn-sm btn-primary" OnClick="btnSignIn_Click" />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="input-group text-info text-left checkbox-inline">
                                    <asp:LinkButton ID="lnkForgot" Text="Forgot password or e-mail?" runat="server" CausesValidation="false"
                                        ForeColor="Navy" OnClick="Unnamed1_Click" />
                                </div>
                            </div>

                        </div>

                        <div class="form-group">
                            <div style="margin-top: 5px;" class="col-sm-4 text-center">
                                <a href="#" onclick="javascript:return fbAuth();">
                                    <img src="img/fsignin.png" alt="sign in with Facebook" /></a>
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
                            <div style="margin-top: 5px;" class="col-sm-4 text-center">
                                <div id="customBtn" class="customGPlusSignIn" data-gapiattached="true">
                                    <span class="icon"></span>
                                    <span class="buttonText"></span>
                                </div>
                                <a href="#" style="margin-top: 10px;" onclick="javascript:$('#customBtn').click();">
                                    <img src="img/gsignin.png" alt="Sign In with Google" /></a>

                            </div>
                            <div style="margin-top: 5px;" class="col-sm-4 text-center">
                                <a href="#" onclick="javascript:return OpenLinkauth();">
                                    <img src="img/lsignin.png" alt="Sign In with Linkedin" /></a>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <p class="text-center remove-margin text-info">
                                    <small>Don't have an account? 
                                    </small>
                                    <a style="color: #F39" href="home.aspx">Register</a>
                                </p>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSignIn" />
                        <asp:PostBackTrigger ControlID="lnkForgot" />
                    </Triggers>
                </asp:UpdatePanel>
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
        });
    </script>
</body>
</html>
