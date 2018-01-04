<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FBAuthentication.aspx.cs" Inherits="User_FBAuthentication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://connect.facebook.net/en_US/all.js"></script>
</head>
<body>
    <div id="fb-root">
    </div>
    <script>
        window.fbAsyncInit = function () {
            FB.init({
                appId: '551080798330891', // App ID
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML               

            });

            // Additional initialization code here
        };
    </script>
    <div class="fb-login-button" style="display:none" data-show-faces="true" data-width="400" data-max-rows="1" scope="email">
    </div>
    <script>
        FB.Event.subscribe('auth.authResponseChange', function (response) {
            if (response.status === 'connected') {
                var uid = response.authResponse.userID;
                var accessToken = response.authResponse.accessToken;

                var form = document.createElement("form");
                form.setAttribute("method", 'post');
                form.setAttribute("action", 'FacebookLogin.ashx');//'FBSuccess.aspx');

                var field = document.createElement("input");
                field.setAttribute("type", "hidden");
                field.setAttribute("name", 'accessToken');
                field.setAttribute("value", accessToken);
                form.appendChild(field);

                document.body.appendChild(form);
                form.submit();

            } else if (response.status === 'not_authorized') {
                alert('un auth');
                // the user is logged in to Facebook, 
                // but has not authenticated your app
            } else {
                // the user isn't logged in to Facebook.
                alert('isnt logged');
            }
        });
    </script>
</body>
</html>
