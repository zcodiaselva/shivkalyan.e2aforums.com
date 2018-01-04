<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lock_screen.aspx.cs" Inherits="lock_screen" %>
<!DOCTYPE html>
<html lang="en" class="body-full-height">
    
<!-- Mirrored from aqvatarius.com/themes/atlant/html/pages-lock-screen.html by HTTrack Website Copier/3.x [XR&CO'2014], Fri, 07 Aug 2015 07:02:14 GMT -->
<!-- Added by HTTrack --><meta http-equiv="content-type" content="text/html;charset=UTF-8" /><!-- /Added by HTTrack -->
<head>        
        <!-- META SECTION -->
        <title>e2aforums lock screen</title>            
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        
        <link rel="icon" href="favicon.ico" type="image/x-icon" />
        <!-- END META SECTION -->
        
        <!-- CSS INCLUDE -->        
        <link rel="stylesheet" type="text/css" id="theme" href="E2Forums-New/css/theme-default.css"/>
        <!-- EOF CSS INCLUDE -->    

    </head>
    <body>
        
        <div class="lockscreen-container">
            
            <div class="lockscreen-box animated fadeInDown">
                
                <div class="lsb-access">
                    <div class="lsb-box">
                        <div class="fa fa-lock"></div>
                        <div class="user animated fadeIn">
                            <img id="" src="assets/images/users/user2.jpg" alt="Log In"/>
                            <div class="user_signin animated fadeIn">
                                <div class="fa fa-sign-in"></div>
                            </div>
                        </div>
                    </div>
                    
                </div>
                
                <div class="lsb-form animated fadeInDown">
                    <form id="myForm" onsubmit="validateFormOnSubmit(this);"  runat="server" method="post" class="form-horizontal">
                        <div class="form-group sign-in animated fadeInDown">
                            <div class="col-md-12">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <span class="fa fa-user"></span>
                                    </div>
                                  
                                      <%--<input name="email_id" type="text" class="form-control" placeholder="Your login"/>--%>
                               <asp:TextBox ID="txtRegEmail" placeholder="Email" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="a" runat="server" ErrorMessage="* Email required"
                                    ForeColor="Red"   ControlToValidate="txtRegEmail"></asp:RequiredFieldValidator> 
                                   
                                      </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <span class="fa fa-lock"></span>
                                    </div>
                                    <%--<input name="password_h" type="password" class="form-control" placeholder="Password"/>--%>
                                    <asp:TextBox ID="txtRegPwd" TextMode="Password" runat="server" class="form-control input-lg" MaxLength="25" placeholder="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="a"  ErrorMessage=" * Password required" ForeColor="Red" ControlToValidate="txtRegPwd"></asp:RequiredFieldValidator><br>
                                        
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-12">
                                <div class="input-group">
                      <%--  <input type="submit" class="hidden"/>--%>
                                     <asp:Button ID="btnSignIn"  ValidationGroup="a" runat="server" Text="Sign In" CssClass="btn btn-default" OnClick="btnSignIn_Click" />
                                  <asp:Button id="Button1" type="button"  CssClass="btn btn-default" runat="server" text="Cancel" OnClick="Button1_Click"  ></asp:Button>
                                    </div>
                                </div>
                            </div>
                       
                         <asp:CheckBox ID="chkRememberMe" Checked="true" Text="" AutoPostBack="false" Visible="false" runat="server" />
                    </form>
                </div>
                 <asp:Literal Text="" ID="lblMessageSignIn" runat="server" />
                

            </div>
            
        </div>
    <!-- START SCRIPTS -->
        <!-- START PLUGINS -->
        <script type="text/javascript" src="E2Forums-New/js/plugins/jquery/jquery.min.js"></script>
        <script type="text/javascript" src="E2Forums-New/js/plugins/jquery/jquery-ui.min.js"></script>
        <script type="text/javascript" src="E2Forums-New/js/plugins/bootstrap/bootstrap.min.js"></script>        
        <!-- END PLUGINS -->

        <!-- START TEMPLATE -->                
        <script type="text/javascript" src="E2Forums-New/js/plugins.js"></script>
        <script type="text/javascript" src="E2Forums-New/js/actions.js"></script>
        <!-- END TEMPLATE -->
    <!-- END SCRIPTS --> 
    
    </body>
<script>
    $(document).ready(function () {
        $("img").each(function () {
            $(this).attr("src", "E2Forums-New/img/default_profile_pic.jpg");
        });
    });
</script>

    <script type="text/javascript">
        
history.pushState(null, null, 'lock_screen.aspx');
window.addEventListener('popstate', function(event) {
history.pushState(null, null, 'lock_screen.aspx');
}); 
           
           
       
    </script>
  


</html>






