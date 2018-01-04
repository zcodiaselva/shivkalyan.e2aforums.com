<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

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
</head>
<body>
    <form id="form1" runat="server">
<asp:Button ID="btnLogin" runat="server" Text="Login with Twitter" OnClick="btnLogin_Click" />
<hr />
<table runat="server" id="tblTwitter" visible="false">
    <tr>
        <td colspan="2">
            <u>Logged in Twitter User's Profile</u>
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            Profile Image
        </td>
        <td>
            <asp:Image ID="imgProfile" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Name
        </td>
        <td>
            <asp:Label ID="lblName" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Twitter Id
        </td>
        <td>
            <asp:Label ID="lblTwitterId" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Screen Name
        </td>
        <td>
            <asp:Label ID="lblScreenName" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Description
        </td>
        <td>
            <asp:Label ID="lblDescription" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Tweets
        </td>
        <td>
            <asp:Label ID="lblTweets" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Followers
        </td>
        <td>
            <asp:Label ID="lblFollowers" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Friends
        </td>
        <td>
            <asp:Label ID="lblFriends" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Favorites
        </td>
        <td>
            <asp:Label ID="lblFavorites" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Location
        </td>
        <td>
            <asp:Label ID="lblLocation" runat="server" />
        </td>
    </tr>
</table>
<br />
<table runat="server" id="tblOtherTwitter" visible="false">
    <tr>
        <td colspan="2">
            <u>Other Twitter User's Profile</u>
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            Profile Image
        </td>
        <td>
            <asp:Image ID="imgOtherProfile" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Name
        </td>
        <td>
            <asp:Label ID="lblOtherName" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Twitter Id
        </td>
        <td>
            <asp:Label ID="lblOtherTwitterId" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Screen Name
        </td>
        <td>
            <asp:Label ID="lblOtherScreenName" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Description
        </td>
        <td>
            <asp:Label ID="lblOtherDescription" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Tweets
        </td>
        <td>
            <asp:Label ID="lblOtherTweets" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Followers
        </td>
        <td>
            <asp:Label ID="lblOtherFollowers" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Friends
        </td>
        <td>
            <asp:Label ID="lblOtherFriends" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Favorites
        </td>
        <td>
            <asp:Label ID="lblOtherFavorites" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Location
        </td>
        <td>
            <asp:Label ID="lblOtherLocation" runat="server" />
        </td>
    </tr>
</table>
    </form>
</body>
</html>
