<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lnk_log.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>
   <script type="text/javascript">
         function ShowMessage(message, EmailExistanceStatus) {

             if (EmailExistanceStatus == 1)
                 alert(message);

             if (EmailExistanceStatus == 0) {
                 window.opener.location.href = "User/index.aspx";
                 self.close();
             }
             else
                 redirectToProfile();


         }

         function redirectToProfile() {

             window.opener.location.href = "User/index.aspx";
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

<asp:Panel ID="pnlDetails" runat="server" Visible="false">
    <hr />
    <asp:Image ID="imgPicture" runat="server" /><br />
    Name:
    <asp:Label ID="lblName" runat="server" /><br />
    LinkedInId:
    <asp:Label ID="lblLinkedInId" runat="server" /><br />
    Location:
    <asp:Label ID="lblLocation" runat="server" /><br />
    EmailAddress:
    <asp:Label ID="lblEmailAddress" runat="server" /><br />
    Industry:
    <asp:Label ID="lblIndustry" runat="server" /><br />
    Headline:
    <asp:Label ID="lblHeadline" runat="server" /><br />
</asp:Panel>
    </form>
</body>
</html>
