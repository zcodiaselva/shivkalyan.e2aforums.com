<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<html lang="en" class="body-full-height">
<meta http-equiv="content-type" content="text/html;charset=UTF-8" />

<head>
    <!-- META SECTION -->
    <title>e2aforums User Registration  </title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- CSS INCLUDE -->
    <link rel="stylesheet" type="text/css" id="theme" href="E2Forums-New/css/theme-default.css" />
    <link rel="stylesheet" type="text/css" id="Link1" href="E2Forums-New/css/custom.css" />
    <!-- EOF CSS INCLUDE -->
    <script type="text/javascript" src="https://connect.facebook.net/en_US/all.js#xfbml=1&appId=551080798330891"></script>
    <script src="js/script.js"></script>

    <script type="text/javascript">
        window.onbeforeunload = function (e) {
            gapi.auth.signOut();
        };

        (function () {
            var po = document.createElement('script');
            po.type = 'text/javascript';
            po.async = true;
            po.src = 'https://apis.google.com/js/client:plusone.js?onload=render';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(po, s);
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
            gapi.client.plus.people.get({
                userId: 'me'
            }).execute(handleEmailResponse);
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
            }, {
                scope: 'email'
            });
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
            var top = 0; // (screen.height/2)-(h/2);
            return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }
    </script>
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: '551080798330891', // App ID
                status: false, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true // parse XFBML
            });
            // Additional initialization code here
        };
    </script>
    <script>


        function ChangeForm() {
            if($('#ChkCop1').is(':checked')) {
                $('#reg_title').html("Sign Up for an Individual Account");
                $("#CompTxt").hide();
                $("#Compbtn").hide();
                $("#btn").show();
            }  else{
                $('#reg_title').html("Sign Up for a Corporate Account");
                $("#CompTxt").show();
                $("#Compbtn").show();
                $("#btn").hide();
            }
        }





        /*
        function ChangeForm() {
            //if ($('#CompTxt').css('display') == 'none') {
            if (document.getElementById('ChkCop').checked) {
              
            
                document.getElementById("AccountType").innerHTML = "Sign Up for a Corporate Account.";
         
                document.getElementById("reg_title").innerHTML = " Sign Up for a Corporate Account";
                document.getElementById("CompTxt").style.display = "block";
                document.getElementById("Compbtn").style.display = "block";
                document.getElementById("btn").style.display = "none";
                document.getElementById('ChkCop').checked =false;
                return false;
            } else {
                document.getElementById("reg_title").innerHTML = "Sign Up for an Individual Account";
                document.getElementById("AccountType").innerHTML = "Sign Up for a Corporate Account";
                document.getElementById("CompTxt").style.display = "none";
                document.getElementById("Compbtn").style.display = "none";
                document.getElementById("btn").style.display = "block";
            
                document.getElementById('ChkCop').checked = true;
                return false;
            }



        }*/

    </script>

</head>
<!--Head-->




<body>

    <!-- Body-->





    <div class="registration-container">
        <div class="registration-box animated fadeInDown">
            <a href="http://e2aforums.com/">
                <div class="registration-logo"></div>
            </a>
            <div class="registration-body">
                <div class="registration-title" id="reg_title">Sign Up for an Individual Account.</div>

                <form id="formregister" runat="server" class="form-horizontal form-bordered form-control-borderless" autocomplete="off">

                    <div class="col-md-12">
                        <!-- CompanyName-->
                        <div style="color: white; margin-bottom: 5px">We are offering a free 14-day trial to all the new members of e2aforums. No credit card information required.</div>
                    </div>
                    <div id="CompTxt" class="form-group" style="display: none;">
                        <div class="col-md-12">

                            <asp:TextBox ID="txtCompanyName" placeholder="Company Name" runat="server" class="form-control"></asp:TextBox>
                            <div class="error">

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Company Name is required!" ForeColor="Red" ControlToValidate="txtCompanyName"></asp:RequiredFieldValidator>


                            </div>

                        </div>
                    </div>

                    <!-- CompanyName-->


                    <!-- Email-->
                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtEmailID" placeholder="Email" runat="server" class="form-control" MaxLength="150"></asp:TextBox>
                            <div class="error">

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="ab" ErrorMessage="Email is required!" ForeColor="Red" ControlToValidate="txtEmailID"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator Style="font-size: small; margin-top: 3px;" ValidationGroup="ab" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email is invalid!" ControlToValidate="txtEmailID" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                            </div>

                        </div>
                    </div>
                    <!-- Email-->

                    <!-- Pasword-->
                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtpwd" TextMode="Password" runat="server" class="form-control input-lg" MaxLength="25" placeholder="Password"></asp:TextBox>



                            <div class="error">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ab" runat="server" ErrorMessage="Password is required!" ForeColor="Red" ControlToValidate="txtpwd"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="ab" runat="server" ErrorMessage="Password: Use atleast 1 number & letter and min length of 6 characters." ControlToValidate="txtpwd" ForeColor="Red" Display="Dynamic" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{6,15})$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>

                    <!-- Pasword-->

                    <!-- Re Pasword-->

                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:TextBox ID="txtConfPwd" TextMode="Password" runat="server" class="form-control input-lg" placeholder="Confirm Password" MaxLength="25"></asp:TextBox>


                            <div class="error">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Confirm password is required!" ValidationGroup="ab" ForeColor="Red" ControlToValidate="txtConfPwd"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="passwordcompare" ControlToCompare="txtpwd" ValidationGroup="ab" ErrorMessage=" Confirm Password didn't match" ControlToValidate="txtConfPwd" runat="server" ForeColor="Red"></asp:CompareValidator>
                            </div>


                        </div>
                    </div>

                    <!-- Re Pasword-->
                    <!-- First Name-->

                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:TextBox ID="TxtFirstName" placeholder="First Name" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                            <div class="error">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ab" runat="server" ErrorMessage="First Name is required!" ForeColor="Red" ControlToValidate="TxtFirstName"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <!-- First Name-->

                    <!-- Last Name-->
                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:TextBox ID="TxtLastName" placeholder="Last Name" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                        </div>
                    </div>
                    <!-- Last Name-->

                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:ValidationSummary CssClass="alert alert-danger validation-msg" ID="ValidationSummary1" ValidationGroup="ab" runat="server" />

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-12">
                            <label class="checkbox-inline login-subtitle">





                                <asp:CheckBox ID="check1" Checked="true" Text="" AutoPostBack="false" runat="server" />
                                I agree to the <a href="TermsOfUse.aspx" target="_blank" style="color: #4dffff;">Terms of Use</a> and <a target="_blank" href="PrivacyPolicy.aspx" style="color: #4dffff;">Privacy
                            Policy</a>
                                <br />
                                <asp:CustomValidator ID="custValidPP" runat="server" EnableClientScript="true" ErrorMessage="Terms of Use is required!" OnServerValidate="CheckBoxRequired_ServerValidate" ForeColor="Red" ClientValidationFunction=""></asp:CustomValidator>

                            </label>

                            <label class="checkbox-inline margin-left-0 login-subtitle">
                                <asp:CheckBox ID="chknewsletterBox" Text="" AutoPostBack="false" runat="server" />
                                Receive discounts/newsletter via e-mail
                            </label>
                            <label class="checkbox-inline margin-left-0 login-subtitle" style="padding-left:0px;">
<div class="radio">
  <label><asp:RadioButton ID="ChkCop1" onclick="return ChangeForm()" Checked="true" GroupName="a" Text=""  runat="server" /><div id="AccountType">Sign Up for an Individual Account.</div></label>
</div>

                                
<div class="radio">
  <label><asp:RadioButton ID="ChkCop2" onclick="return ChangeForm()" Text="" GroupName="a"  runat="server" /><div id="Div1">Sign Up for a Corporate Account.</div></label>
</div>
                                

                            </label>


                        </div>
                    </div>

                    <div id="Compbtn" style="display: none">
                        <div class="form-group push-up-30">

                            <div class="col-md-6">

                                <asp:Button ID="btn_reg_coprate" runat="server" CssClass="btn btn-danger btn-block" Text="Create" ValidationGroup="ab" class="mysubmit" OnClick="btnRegisterCoprate_Click" />



                            </div>
                        </div>
                    </div>
                    <div id="btn">

                        <div class="form-group push-up-30">
         
                            <div class="col-md-6">

                                <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-danger btn-block" Text="Sign Up" ValidationGroup="ab" class="mysubmit" OnClick="btnRegister_Click" />



                            </div>
                                               <div class="col-md-6">
                                <a href="Login.aspx" class="btn btn-link btn-block ">Already have account?</a>
                            </div>
                        </div>

                        <div class="login-or">OR</div>

                        <div class="form-group">

                            <div class="col-md-6">
                                <!-- Facebook Login API -->
                                <a href="#" onclick="javascript:return fbAuth();" class="btn btn-info btn-block btn-facebook">
                                    <span class="fa fa-facebook"></span>Facebook
                                </a>
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

                                <!-- Facebook Login API -->


                            </div>


                            <div class="col-md-6">
                                <span class="gplus">
                                    <div id="customBtn" class="customGPlusSignIn" data-gapiattached="true">
                                        <span class="icon"></span>
                                        <span class="buttonText"></span>
                                    </div>




                                    <a  href="#" class="btn btn-info btn-block btn-google" onclick="javascript:$('#customBtn').click();"><span class="fa fa-google-plus"></span>Google+</a>
                            </span>
                                    </div>
                            <!--
                            <div class="col-md-4">
  
                                <button class="btn btn-block btn-linkedin" onclick="javascript:return OpenLinkauth();"><span class="fa fa-linkedin"></span> Linkedin</button>
                            </div> -->
                        </div>
                    </div>
                </form>
            </div>
            <div class="registration-footer">
                <div class="pull-left">
                    &copy; 2015 e2aforums
                </div>
                <div class="pull-right">
                    <a href="http://e2aforums.com/">Home</a> |
                        <a href="AboutUs.aspx">About</a> |
                        <a href="Support.aspx">Contact Us</a>
                </div>
            </div>
        </div>

    </div>

    <asp:Literal Text="" ID="lblMessageSignIn" runat="server" />

    <form id="frmGoogleLogin" action="#" method="post">
        <input type="hidden" name="Email" id="hiddEmail" value="" />
        <input type="hidden" name="Gender" id="hiddGender" value="" />
        <input type="hidden" name="Name" id="hiddName" value="" />
        <input type="hidden" name="Mode" id="hiddMode" value="" />
    </form>


    <!-- Footer-->

    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
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

    <style>
        .btn.btn-google
        {
            width: 100% !important;
        }
    </style>
</body>


</html>
