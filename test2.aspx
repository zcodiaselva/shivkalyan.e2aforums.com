<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post">

    <!-- Identify your business so that you can collect the payments. -->
    <input type="hidden" name="business" value="bus_dev@gmail.com">

    <!-- Specify a Subscribe button. -->
    <input type="hidden" name="cmd" value="_xclick-subscriptions">
    <!-- Identify the subscription. -->
    <input type="hidden" name="item_name" value="Basic">
    <input type="hidden" name="item_number" value="1111">

    <!-- Set the terms of the regular subscription. -->
    <input type="hidden" name="currency_code" value="CAD">
    <input type="hidden" name="a3" value="5.00">
    <input type="hidden" name="p3" value="1">
    <input type="hidden" name="t3" value="M">

    <input type="hidden" name="notify_url" value="http://e2aforums.com/ipn.aspx">
    <input type="hidden" name="return" value="http://e2aforums.com/pay/response.aspx">
    <input type="hidden" name="cancel_return" value="http://e2aforums.com/Pricing.aspx">

    <!-- Set recurring payments until canceled. -->
    <input type="hidden" name="src" value="1">

    <!-- Display the payment button. -->
    <input type="image" name="submit"
    src="https://www.paypalobjects.com/en_US/i/btn/btn_subscribe_LG.gif"
    alt="PayPal - The safer, easier way to pay online">
    <img alt="" width="1" height="1"
    src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" >
</form>
</form>
</body>
</html>
