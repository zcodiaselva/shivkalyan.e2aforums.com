<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogInPanel.aspx.cs" Inherits="User_LogInPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/instynt-style.css" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
 <table id="midtableLogin" style="margin: 0px auto; width: 100%; float: left; padding: 0px;">
                    <tr style="margin-bottom: -8px;">
                        <td class="input-field" >
                            <div style="width: 40%; float: left;margin-top:7px;margin-top:7px;">
                                E-Mail:
                            </div>
                            <div style="width: 60%; float: left;">
                                <asp:TextBox ID="txtRegEmail" runat="server" MaxLength="150"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" *"
                                    ForeColor="Red" ControlToValidate="txtRegEmail"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr style="margin-bottom: -8px;">
                        <td class="input-field">
                            <div style="width: 40%; float: left;margin-top:7px;">
                                Password:
                            </div>
                            <div style="width: 60%; float: left;">
                                <asp:TextBox ID="txtRegPwd" TextMode="Password" runat="server" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" *"
                                    ForeColor="Red" ControlToValidate="txtRegPwd"></asp:RequiredFieldValidator>
                            </div>

                        </td>

                    </tr>
                  <tr>
                        <%--<td colspan="2" align="center">  
                            <asp:Button ID="btn_Advisor" class="btn btn-sm btn-primary" CausesValidation="false" runat="server" Text="Go to Advisor's site" style="background-color:#0044a5;width:200px;float:left;margin-left:170px;" OnClick="btn_Advisor_Click"
                                /></td>--%>
                      
                    </tr>
                    <tr style="margin-bottom: -8px;">
                        <td colspan="2" class="smaller">
                             <%--<a href="Advisor/index.html" target="_blank" style="color: #f31455;">Go To advisor's Site</a></br>--%>
                            <asp:CheckBox ID="chkRememberMe" Checked="true" Text="" AutoPostBack="false" runat="server" style="margin-left: 20%;"/>
                            Remember Password
                        </td>
                    </tr>
                    <tr style="margin-bottom: -8px;">
                        <td colspan="2" class="smaller">
                            <asp:LinkButton ID="lnkForgot" Text="Forgot password or e-mail" runat="server" CausesValidation="false"
                                ForeColor="Navy" OnClick="Unnamed1_Click" style="margin-left: 20%;"/>
                            <%--<a href="#" onclick="javascript:call();" style="color: Navy">Forgot password or e-mail</a>--%>
                        </td>
                    </tr>
                    <tr style="margin-top: 8px;">
                        <td class="input-field"></td>
                        <td>
                            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click"
                                class="mysubmit" style="margin-left: -4px;"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="input-field"></td>
                        <td>
                            <asp:Literal ID="lblMessageSignIn" runat="server" Text=" "></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSignIn" />
                <asp:PostBackTrigger ControlID="lnkForgot" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
