<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FBSuccess.aspx.cs" Inherits="User_FBSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://connect.facebook.net/en_US/all.js#xfbml=1&appId=551080798330891"></script>
    <script type="text/javascript">

        function redirectToProfile() {
          
          FB.getLoginStatus(handleSessionResponse);
        
        }

        //handle a session response from any of the auth related calls
        function handleSessionResponse(response) {
       
            FB.logout(function (resonse) {
                window.location = "User/index.aspx";
            });
           
        }

        function ShowMessage(message, EmailExistanceStatus) {
            if (EmailExistanceStatus == 1)
                alert(message);
            if (EmailExistanceStatus == 0)
                window.location = "User/index.aspx";
               // window.location = "User/UserDetail.aspx";
            else
                redirectToProfile();
        }

        function ShowProfileMessage(message, status) {
         
            if (message != '')
                alert(message);

            redirectToProfile();

        }

    </script>
</head>
<body>
     <script>
         window.fbAsyncInit = function () {
             FB.init({
                 appId: '551080798330891', // App ID
                 status: false, // check login status
                 cookie: true, // enable cookies to allow the server to access the session
                 xfbml: true  // parse XFBML               

             });

             FB.getLoginStatus(handleSessionResponse);

             // Additional initialization code here
         };
    </script>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
