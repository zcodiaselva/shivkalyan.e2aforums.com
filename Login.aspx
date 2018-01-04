<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="E2aForums.User_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="320, initial-scale=1.0" />
    <meta name="viewport" content="width=320,user-scalable=false, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="viewport" content="width=device-width">
    <meta charset="utf-8" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <title>Login</title>

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

    <meta name="description" content="log in" />
    <meta name="author" content="PetCloud" />
    <meta name="robots" content="noindex, nofollow" />
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0" />
    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="User/img/circularlogo.png">
    <link rel="apple-touch-icon" href="img/icon57.png" sizes="57x57" />
    <link rel="apple-touch-icon" href="img/icon72.png" sizes="72x72" />
    <link rel="apple-touch-icon" href="img/icon76.png" sizes="76x76" />
    <link rel="apple-touch-icon" href="img/icon114.png" sizes="114x114" />
    <link rel="apple-touch-icon" href="img/icon120.png" sizes="120x120" />
    <link rel="apple-touch-icon" href="img/icon144.png" sizes="144x144" />
    <link rel="apple-touch-icon" href="img/icon152.png" sizes="152x152" />
    <!-- END Icons -->
    <link href="css/e2aforums-style.css" rel="stylesheet" />
    <link rel="stylesheet" href="bootstrap.min.css" />
    <link rel="stylesheet" href="css/plugins.css" />
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/themes.css" />
    <link rel="stylesheet" href="css/instynt-style.css" />
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

            $("#loginPick").click(function () {
                $("#midtableLogin").toggle(0);
                $("#midtableRegister").toggle(0);
                $("#txtEmailID").val('');
                $("#txtpwd").val('');
                $("#txtConfPwd").val('');
                $("#RequiredFieldValidator1").hide();
                $("#RegularExpressionValidator1").hide();
                $("#RequiredFieldValidator4").hide();
                $("#RegularExpressionValidator2").hide();
               // $("#CompareValidator1").hide();
                
            });

            $("#registerPick").click(function () {
                $("#midtableLogin").toggle(0);
                $("#midtableRegister").toggle(0);
                //$("#txtRegEmail").val('');
                //$("#txtRegPwd").val('');
                $("#frmLogin").val('');
            });

            $("#midtableLogin").hide();

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
<body style="background-color: #0044a5;">
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

    <!--Start of Panel-->

    <form id="form1" runat="server">
        <div id="main" style="display: block;" class="animation-fadeIn">
            <div id="mid">
                <table id="midtableRegister">
                    <tr class="guidance-space title-bar">
                        <td colspan="2" class="login-register">
                            <img src="User/img/logoblue.png" style="margin-top: 10px; margin-left: 90px; text-align: center;" />
                            <br />
                        </td>
                    </tr>
                    <tr class="guidance-space title-bar">
                        <td colspan="2" id="login-register1" class="login-register">
                            <h1 style="display: block;">

                                <span style="margin-top: 10px; margin-left: 90px; text-align: center;">Register</span>
                                <a id="loginPick">Login</a>

                            </h1>
                            <br />
                        </td>
                    </tr>
           
                    <tr style="margin-bottom: -6px;">
                        <td class="input-field">E-Mail:
                        </td>
                        <td class="">
                            <asp:TextBox ID="txtEmailID" runat="server" MaxLength="150"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr style="margin-bottom: -4px;">
                        <td class="input-field">&nbsp;
                        </td>
                        <td class="">
                            <asp:RequiredFieldValidator Style="margin-left: 0px;margin-top:3px;font-size:small;" ID="RequiredFieldValidator1"
                                runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="txtEmailID"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Style="font-size:small;margin-top:3px;" ID="RegularExpressionValidator1"
                                runat="server" ErrorMessage="* Email is invalid." ControlToValidate="txtEmailID"
                                ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="margin-bottom: -6px;">
                        <td class="input-field">Password:
                        </td>
                        <td class="">
                            <asp:TextBox ID="txtpwd" TextMode="Password" runat="server" MaxLength="25"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="margin-bottom: -4px;">
                        <td class="input-field">&nbsp;
                        </td>
                        <td class="">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Style="margin-left: 0px;margin-top:3px;font-size:small;" 
                                runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="txtpwd"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Style="font-size:small;margin-top:3px;"  ID="RegularExpressionValidator2"
                                runat="server" ErrorMessage="* use atleast 1 number & letter" ControlToValidate="txtpwd"
                                ForeColor="Red" Display="Dynamic" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{6,15})$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="margin-bottom: -6px;">
                        <td class="input-field">Confirm Password:
                        </td>
                        <td class="">
                            <asp:TextBox ID="txtConfPwd" TextMode="Password" runat="server" MaxLength="25"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr style="margin-bottom: -4px;">
                        <td class="input-field" style="margin-bottom: -8px;">&nbsp;
                        </td>
                        <td class="">
                            <asp:CompareValidator ID="CompareValidator1" Style="margin-left: 0px;font-size:small;margin-top:3px;"  runat="server"
                                ErrorMessage="* Passwords don't match." ControlToCompare="txtpwd" ControlToValidate="txtConfPwd"
                                ForeColor="Red">
                            </asp:CompareValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="2" align="center">  
                            <asp:Button ID="btn_Advisor" class="btn btn-sm btn-primary" CausesValidation="false" runat="server" Text="Go to Advisor's site" style="background-color:#0044a5;width:200px;float:left;margin-left:170px;" OnClick="btn_Advisor_Click"
                                /></td>
                       
                    </tr>--%>
                    <tr style="margin-top: 5px;">

                        <td class="smaller" style="margin-top: -5px;" colspan="2">
                            <%--<input id="legalBox" type="checkbox" onfocus="OnFocusInput('legalBox')" onblur="OnBlurInput()" />--%>
                            <asp:CheckBox ID="check1" Checked="true" Text="" AutoPostBack="false" runat="server" />
                            I agree to the <a href="TermsOfUse.aspx" target="_blank" style="color: #f31455;">Terms of Use</a> and <a target="_blank" href="PrivacyPolicy.aspx" style="color: #f31455;">Privacy
                            Policy</a> &nbsp;<asp:CustomValidator ID="custValidPP" runat="server" EnableClientScript="true"
                                ErrorMessage="* required" ForeColor="Red" OnServerValidate="CheckBoxRequired_ServerValidate"
                                ClientValidationFunction=""></asp:CustomValidator><asp:CheckBox ID="chknewsletterBox" Text="" AutoPostBack="false" runat="server" Style="float: left;" />
                            <span style="float: left; margin-top: -4px;">&nbsp;Receive discounts/newsletter via e-mail</span>
                        </td>
                    </tr>
                    <tr style="margin-bottom: 5px;">
                        <td colspan="2" align="center">
                            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"
                                Class="mysubmit" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <%-- <h5>
                                <asp:Label ID="lblMessageReg" runat="server" Style="margin-left: 115px;"
                                    Text="Email ID is already registerd" Visible="false"></asp:Label></h5>--%>
                            <asp:Literal Text="" ID="lblMessageSignIn" runat="server" />
                        </td>
                    </tr>
                    <tr class="guidance-space social-buttons">
                        <td colspan="2" align="center">
                            <%--<div class="fb-login-button" data-show-faces="true" data-width="400" data-max-rows="1"
                            scope="email">
                        </div>--%>
                            <a href="#" onclick="javascript:return fbAuth();" style="margin-left: 4%;">
                                <img src="img/fbbutton-register.gif" height="22px" width="237px" alt="Register with Facebook" /></a><br />
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
                            <div id="customBtn" class="customGPlusSignIn">
                                <span class="icon"></span>
                                <span class="buttonText"></span>
                            </div>
                            <a href="#" onclick="javascript:$('#customBtn1').click();" style="margin-left: 4%;">
                                <img src="img/googlebutton-register.gif" style="text-align: center;" height="22px" width="237px" alt="Register with Google" /></a>
                            <div>
                                <a href="#" onclick="javascript:return OpenLinkauth();" style="margin-left: 4%;">
                                    <img src="img/linkedinbutton-register.gif" style="text-align: center;" height="22px" width="237px" alt="Register with Google" /></a>
                            </div>
                        </td>
                    </tr>
                    <tr class="guidance-space" align="center">
                        <td colspan="2" id="guidance1" hidden>Instynt is hip. We're best viewed in modern browsers
                        </td>
                    </tr>
                </table>

                <!--<iframe id="frmLogin" src="Login.aspx" frameborder="0" style="margin: 0px; padding: 0px;"
                        scrolling="no" width="" height="400px"></iframe>-->

                <table id="midtableLogin">
                    <tr class="guidance-space title-bar">
                        <td colspan="2" class="login-register">
                            <img src="User/img/logoblue.png" style="margin-top: 10px; margin-left: 90px; text-align: center;" />
                            <br />
                        </td>
                    </tr>
                    <tr class="guidance-space title-bar">
                        <td colspan="2" id="login-register2" class="login-register">
                            <h1>
                                <a id="registerPick" style="margin-top: 10px; margin-left: 90px; text-align: center;">Register</a> <span>Login</span></h1>
                            <br />
                        </td>
                    </tr>
                    <tr id="LoginTr" style="margin-bottom: -8px;">
                        <td class="input-field" colspan="2" style="width: 50%;">
                            <iframe class="iframelogin" id="frmLogin" src="LogInPanel.aspx" frameborder="0"
                                scrolling="no" height="240px" style="width: 100%;"></iframe>
                        </td>
                    </tr>
                    <tr id="forgPassTr" style="display: none; margin-bottom: -8px;">
                        <td colspan="2">
                            <iframe id="frmForgotPass" src="ForgotPassword.aspx" frameborder="0" style="margin: 0px; padding: 0px;"
                                scrolling="no" width="" height="250px"></iframe>
                        </td>
                    </tr>
                    <tr id="loginSocialTr" class="guidance-space social-buttons" style="margin-bottom: -8px;">
                        <td colspan="3" align="center">
                            <a href="#" onclick="javascript:return fbAuth();">
                                <img src="img/fbbutton-login.gif" height="22px" width="237px" style="text-align: center; margin-left: 120px;" alt="Login with Facebook" /></a><br />
                            <%--<a href="#" onclick="javascript:return OpenGmailauth();">
                                <img src="img/googlebutton-login.gif" height="22px" width="237px" alt="Register with Google" /></a><br />--%>
                            <div id="customBtn1" class="customGPlusSignIn">
                                <span class="icon"></span>
                                <span class="buttonText"></span>
                            </div>
                            <a href="#" onclick="javascript:$('#customBtn').click();">
                                <img src="img/googlebutton-login.gif" style="text-align: center; margin-left: 120px;" height="22px" width="237px" alt="Register with Google" /></a>
                            <div>
                                <a href="#" onclick="javascript:return OpenLinkauth();">
                                    <img src="img/linkedinbutton-login.gif" style="text-align: center; margin-left: 120px;" height="22px" width="237px" alt="Register with Google" /></a>
                            </div>
                            <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/linkedinbutton-login.gif"
                            OnClick="RegFromLinedIn" CausesValidation="false" BorderStyle="None" />--%>
                        </td>
                    </tr>
                    <tr class="guidance-space" align="center">
                        <td colspan="2" id="guidance2" hidden>Note: e2aforum is hip. We're best viewed in modern browsers
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </div>
    </form>
    <form id="frmGoogleLogin" action="#" method="post">
        <input type="hidden" name="Email" id="hiddEmail" value="" />
        <input type="hidden" name="Gender" id="hiddGender" value="" />
        <input type="hidden" name="Name" id="hiddName" value="" />
        <input type="hidden" name="Mode" id="hiddMode" value="" />
    </form>
    <!--End of Start of Panel-->



    <!-- Load and execute javascript code used only in this page -->
    <%--    <script src="../User/js/pages/uiProgress.js"></script>
    <script>        $(function () { UiProgress.init(); });</script>
    <script src="../js/jquery.validate.min.js"></script>
    <script src="js/toastr.js"></script>--%>

    <!-- common.js user for Google Analytics Object code-->
    <%--<script src="js/Common.js"></script>--%>
    <script>
        // Include the UserVoice JavaScript SDK (only needed once on a page)
        UserVoice = window.UserVoice || []; (function () { var uv = document.createElement('script'); uv.type = 'text/javascript'; uv.async = true; uv.src = '//widget.uservoice.com/22uLZYvqn0yTLcjfgPEZMQ.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(uv, s) })();

        //
        // UserVoice Javascript SDK developer documentation:
        // https://www.uservoice.com/o/javascript-sdk
        //

        // Set colors
        UserVoice.push(['set', {
            accent_color: '#448dd6',
            trigger_color: 'white',
            trigger_background_color: 'rgba(46, 49, 51, 0.6)'
        }]);

        // Identify the user and pass traits
        // To enable, replace sample data with actual user traits and uncomment the line
        UserVoice.push(['identify', {
            //email:      'john.doe@example.com', // User’s email address
            //name:       'John Doe', // User’s real name
            //created_at: 1364406966, // Unix timestamp for the date the user signed up
            //id:         123, // Optional: Unique id of the user (if set, this should not change)
            //type:       'Owner', // Optional: segment your users by type
            //account: {
            //  id:           123, // Optional: associate multiple users with a single account
            //  name:         'Acme, Co.', // Account name
            //  created_at:   1364406966, // Unix timestamp for the date the account was created
            //  monthly_rate: 9.99, // Decimal; monthly rate of the account
            //  ltv:          1495.00, // Decimal; lifetime value of the account
            //  plan:         'Enhanced' // Plan name for the account
            //}
        }]);

        // Add default trigger to the bottom-right corner of the window:
        UserVoice.push(['addTrigger', { mode: 'contact', trigger_position: 'bottom-right' }]);

        // Or, use your own custom trigger:
        //UserVoice.push(['addTrigger', '#id', { mode: 'contact' }]);

        // Autoprompt for Satisfaction and SmartVote (only displayed under certain conditions)
        UserVoice.push(['autoprompt', {}]);
    </script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-54240303-1', 'auto');
        ga('send', 'pageview');

    </script>
</body>
</html>
