<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GmaiAuth.aspx.cs" Inherits="User_GmaiAuth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
     <script type="text/javascript">
     
         function ShowMessage(message, EmailExistanceStatus) {
          
             if (EmailExistanceStatus == 1){
                 alert(message);
                 window.location = "https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://e2aforums.com/User/index.aspx";
                 self.close();

             }
             else if (EmailExistanceStatus == 0) {

                 window.location = "https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://e2aforums.com/User/index.aspx";
                self.close();
                }
             
         }

         function redirectToProfile() {
             window.location = "https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://e2aforums.com/User/index.aspx";
             self.close();
         }
        function ShowProfileMessage(message, status) {

            if (message != '')
                alert(message);

            if (status == 's')
                window.opener.GetLinkedAccounts();
               
            self.close();
        }

    </script>  
</head>
<body>
    <form id="form1" runat="server">
    <div>    
    </div>
    </form>
    <script src="js/GoogleAnalytics.js"></script>    
</body>
</html>
