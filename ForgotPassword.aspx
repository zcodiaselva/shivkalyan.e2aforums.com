<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>
<!DOCTYPE html>
<html lang="en" class="body-full-height">
    
<meta http-equiv="content-type" content="text/html;charset=utf-8" />
<head>        
        <!-- META SECTION -->
        <title>e2aforums Password</title>            
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        
        <link rel="icon" href="favicon.ico" type="image/x-icon" />
        <!-- END META SECTION -->
        
        <!-- CSS INCLUDE -->        
        <link rel="stylesheet" type="text/css" id="theme" href="E2Forums-New/css/theme-default.css"/>
        <!-- EOF CSS INCLUDE -->    
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var pageLocTitle = '<%=pageTitle%>'
            if (pageLocTitle == "-1") {
                $("#pageHead").html("<strong>Forgot</strong> Password?");

            }
            else {
                $("#pageHead").html("<strong>Password</strong> Reset!");

            }
        });


    </script>
    </head>

<body class="loginbg">


        <div class="registration-container">            
            <div class="registration-box animated fadeInDown">
                 <a href="http://e2aforums.com/">
                <div class="registration-logo"></div>
            </a>
                <div class="registration-body">
                    <div id="pageHead" class="registration-title"></div>
                    <div class="registration-subtitle">Please Enter Your Registered Email</div>


<form id="form2" runat="server" class="form-horizontal" autocomplete="off">

                <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="">
                              
                           
                                    <asp:TextBox ID="txtRegEmail" placeholder="Email" runat="server" class="form-control" MaxLength="150"></asp:TextBox>
                            
                            </div>
                            <div class="col-xs-11 col-xs-offset-1 text-left">
                                <asp:RequiredFieldValidator Style="margin-left: 0px;" ID="RequiredFieldValidator3"
                                    runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="txtRegEmail"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Style="margin-left: -70px;" ID="RegularExpressionValidator1"
                                    runat="server" ErrorMessage="* Email is invalid." ControlToValidate="txtRegEmail"
                                    ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
                                
                                
                                <asp:Label ID="lblMessage" CssClass="Vali-message" runat="server" Font-Size="Small" Text="">

                                </asp:Label>
                            </div>
                        </div>
                        <div>                       
                    <div class="form-group push-up-20">
                        <div class="col-md-6">
                                    <asp:Button ID="btnSubmit" class="btn btn-danger btn-block" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                         <div class="col-md-6">
                                      <asp:Button ID="btnCancel" class="btn btn-large btn-default" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                             </div>
                        </div>
         
                    </ContentTemplate>
                </asp:UpdatePanel>

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
    

</body>

</html>
