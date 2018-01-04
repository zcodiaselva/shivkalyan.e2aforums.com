<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Callback.aspx.cs" Inherits="User_Callback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function ShowMessage(message, EmailExistanceStatus) {

             if (EmailExistanceStatus == 1)
                 alert(message);

             if (EmailExistanceStatus == 0) {
                 window.opener.location.href = "User/Forum.aspx";
                 self.close();
             }
             else
                 redirectToProfile();


         }

         function redirectToProfile() {

             window.opener.location.href = "User/Forum.aspx";
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
</body>
</html>
