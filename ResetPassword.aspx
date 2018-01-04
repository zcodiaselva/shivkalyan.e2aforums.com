<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html>
<html lang="en" class="body-full-height">
    
<meta http-equiv="content-type" content="text/html;charset=UTF-8" />
<head>        
        <!-- META SECTION -->
        <title>E2AForums Forgot Password</title>            
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        
        <link rel="icon" href="favicon.ico" type="image/x-icon" />
        <!-- END META SECTION -->
        
        <!-- CSS INCLUDE -->        
        <link rel="stylesheet" type="text/css" id="theme" href="E2Forums-New/css/theme-default.css"/>
        <!-- EOF CSS INCLUDE -->    
    </head>

<body class="loginbg">


        <div class="registration-container">            
            <div class="registration-box animated fadeInDown">
                <div class="registration-logo"></div>
                <div class="registration-body">
                    <div class="registration-title"><strong>Reset</strong> Password?</div>
                    <div class="registration-subtitle">Please Enter your new Password</div>

    <form id="form2" runat="server">
         <div id="main" style="display: block;" class="animation-fadeIn">
       <div id="mid">
       <%-- <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>--%>


           <div id="midtableLogin">
<div class="form-group">
<asp:Label ID="lblNewPassword" runat="server" style="color:#fff">New Password:</asp:Label>                                           
<asp:TextBox ID="NewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>  
<asp:RequiredFieldValidator ID="ReqFieldValNewPswd" runat="server" Font-Size="Small" ErrorMessage="*" ForeColor="Red" ControlToValidate="NewPassword" style="float:left;"></asp:RequiredFieldValidator>                      
</div>
<div class="form-group">
<asp:Label ID="lblConfirmPswd" runat="server" style="color:#fff">Confirm Password:</asp:Label>                    
<asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"  CssClass="form-control"></asp:TextBox> <br />  
<asp:RequiredFieldValidator ID="ReqFieldValConPswd" runat="server" ErrorMessage="*" ForeColor="Red" Font-Size="Small" ControlToValidate="ConfirmPassword" style="float:left;"></asp:RequiredFieldValidator>                       
    </div>




   <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Confirm password doesn't match with new password" Font-Size="Small" ForeColor="Red" ControlToCompare="NewPassword" ControlToValidate="ConfirmPassword" Style="margin-left: 10px;"></asp:CompareValidator> 
<asp:Label ID="Label1" runat="server" Font-Size="Small" Text="" ></asp:Label>             
<asp:HiddenField ID="HiddenField1" runat="server" />
                       
<asp:Label ID="lblMessage" runat="server" Font-Size="Small" Text=""></asp:Label>             
<asp:HiddenField ID="hiddID" runat="server" />

<div class="form-group">

<asp:Button ID="Button1" runat="server" Text="Reset Password" class="btn btn-danger btn-block"  OnClick="ResetPassword_Click"/>
    </div>



           </div>
                
         <%--   </ContentTemplate>
           
        </asp:UpdatePanel>--%>
           </div></div>
    </form>

                </div>
                <div class="registration-footer">
                    <div class="pull-left">
                        &copy; 2015 e2aforums
                    </div>
                    <div class="pull-right">
                        <a href="AboutUs.aspx">About</a> |
                        <a href="Support.aspx">Contact Us</a>
                    </div>
                </div>
            </div>
            
        </div>






        <script src="js/GoogleAnalytics.js"></script>
        <script language="javascript" type="text/javascript">
            var varUserID =<%=UserID%>;
    </script>
</body>
</html>
