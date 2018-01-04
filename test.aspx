<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Button ID="btnLoginToGoogle" runat="server" OnCommand="OpenLogin_Click" 
                            ToolTip="Google_Login" CssClass="btngoogle"
                            CommandArgument="https://www.google.com/accounts/o8/id" Height="34px" 
                            Width="143px" />
    </div>
    </form>
</body>
</html>
