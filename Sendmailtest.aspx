<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sendmailtest.aspx.cs" Inherits="_sendmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        To:<asp:TextBox ID="txtTo" runat="server" Width="361px"></asp:TextBox>
        <br />
        <br />
        Subject:<asp:TextBox ID="txtSubject" runat="server" Width="351px"></asp:TextBox>
        <br />
        <br />
        Message:<asp:TextBox ID="txtMessage" runat="server" Height="61px" 
            TextMode="MultiLine" Width="342px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    
    </div>
    </form>
</body>
</html>
