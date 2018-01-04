<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompUsers.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>E2aforums Admin</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link rel="icon" href="favicon.ico" type="image/x-icon" />
<!-- END META SECTION -->
<!-- CSS INCLUDE -->
<link rel="stylesheet" type="text/css" href="../E2Forums-New/css/cropper/cropper.min.css"/>
<!--  EOF CSS INCLUDE -->
<!-- CSS INCLUDE -->
<link rel="stylesheet" type="text/css" id="theme" href="../E2Forums-New/css/theme-default.css"/>
<link rel="stylesheet" type="text/css" id="Link1" href="../E2Forums-New/css/custom.css"/>
<!-- EOF CSS INCLUDE -->
</head>
<body>
      
<!-- START PAGE CONTAINER -->
<div class="page-container page-navigation-top-fixed">


<!-- Top Menu Control Start  --> 
    <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />
   
    <!-- Top Menu Control End  -->

<!-- PAGE CONTENT -->


<div class="page-content">
    <!-- Side Menu Control Start  -->
    <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />
    <!-- side Menu Control End  -->
     <div class="page-content-wrap"> 
      <div class="inner-content-wrap"> 
            <asp:Label style="font-size:16px;font-weight:bold;" Text="" ID="lblMessageSignIn" runat="server" />
        

<!-- Button trigger modal -->
<button class="btn btn-primary btn-sm pull-right mb20" data-toggle="modal" data-target="#CompUsers"> Add Users</button>

<!-- Modal -->
<div class="modal fade" id="CompUsers" tabindex="-1" role="dialog" 
     aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <!-- Modal Header -->
            <div class="modal-header">
                <button type="button" class="close" 
                   data-dismiss="modal">
                       <span aria-hidden="true">&times;</span>
                       <span class="sr-only">Close</span>
                </button>
                <h4 class="modal-title" id="H1">
                    Add Users
                </h4>
            </div>
            
            <!-- Modal Body -->
            <div class="modal-body">
                 
<form id="formregister" runat="server" class="form-horizontal form-bordered form-control-borderless" autocomplete="off">
                       
                            


                        <!-- Email-->
                        <div class="form-group">
                            <div class="col-md-12">
                                <asp:textbox id="txtEmailID" placeholder="Email" runat="server" class="form-control" maxlength="150"></asp:textbox>
                                <div class="error">

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ValidationGroup="ab" ErrorMessage="Email is required!" ForeColor="Red" ControlToValidate="txtEmailID"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator Style="font-size: small; margin-top: 3px;"  ValidationGroup="ab" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email is invalid!" ControlToValidate="txtEmailID" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                </div>

                            </div>
                        </div>
                        <!-- Email-->

                        <!-- Pasword and Re Pasword-->
                        <div class="form-group">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtpwd" TextMode="Password" runat="server" class="form-control input-lg" MaxLength="25" placeholder="Password"></asp:TextBox>



                                <div class="error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="ab" runat="server" ErrorMessage="Password is required!" ForeColor="Red" ControlToValidate="txtpwd"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ValidationGroup="ab" runat="server" ErrorMessage="Password: Use atleast 1 number & letter and min length of 6 characters." ControlToValidate="txtpwd"  ForeColor="Red" Display="Dynamic" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{6,15})$"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                                                        <div class="col-md-6">
                                <asp:TextBox ID="txtConfPwd" TextMode="Password" runat="server" class="form-control input-lg" placeholder="Confirm Password" MaxLength="25"></asp:TextBox>


                                <div class="error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Confirm password is required!"  ValidationGroup="ab" ForeColor="Red" ControlToValidate="txtConfPwd"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="passwordcompare" ControlToCompare="txtpwd"  ValidationGroup="ab" ErrorMessage=" Confirm Password didn't match" ControlToValidate="txtConfPwd" runat="server" ForeColor="Red"></asp:CompareValidator>
                                </div>


                            </div>
                        </div>

                        <!-- Pasword-->

                
                        <!-- Name-->

                        <div class="form-group">
                            <div class="col-md-6">
                                <asp:TextBox ID="TxtFirstName" placeholder="First Name" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                                <div class="error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ValidationGroup="ab" runat="server" ErrorMessage="First Name is required!" ForeColor="Red" ControlToValidate="TxtFirstName"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                             <div class="col-md-6">
                                <asp:TextBox ID="TxtLastName" placeholder="Last Name" runat="server" class="form-control input-lg" MaxLength="150"></asp:TextBox>
                            </div>

                        </div>
                        <!--  Name-->

             

                        <div class="form-group">
                            <div class="col-md-12">
                                <asp:ValidationSummary CssClass="alert alert-danger validation-msg" ID="ValidationSummary1"  ValidationGroup="ab" runat="server" />
                                
                                </div>
                            </div>

                        <div class="form-group">
                            <div class="col-md-12">
                                <label class="checkbox-inline login-subtitle">


                                    


                                    <asp:CheckBox ID="check1" Checked="true" Text="" AutoPostBack="false" runat="server" /> I agree to the <a href="TermsOfUse.aspx" target="_blank" style="color: #f31455;">Terms of Use</a> and <a target="_blank" href="PrivacyPolicy.aspx" style="color: #f31455;">Privacy
                            Policy</a>
                                    <br />
                                    <asp:CustomValidator ID="custValidPP" runat="server" EnableClientScript="true" ErrorMessage="Terms of Use is required!" OnServerValidate="CheckBoxRequired_ServerValidate" ForeColor="Red" ClientValidationFunction=""></asp:CustomValidator>

                                </label>
                              
            

                            </div>
 <div class="col-md-12">
                    <label class="checkbox-inline margin-left-0 login-subtitle">
                                    <asp:CheckBox ID="chknewsletterBox" Text="" AutoPostBack="false" runat="server" /> Receive discounts/newsletter via e-mail
                                </label>
     </div>

                        </div>
                        
                      

                        <div class="form-group push-up-30">
                          
                            <div class="col-md-6">

                                <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-danger btn-block" Text="Add"  ValidationGroup="ab" class="mysubmit" OnClick="btnRegister_Click" />


                            </div>
                        </div>

                

                        
                           
                    </form>
                
                
            </div>
            
            <!-- Modal Footer -->
            <div class="modal-footer">
                <button type="button" class="btn btn-default"
                        data-dismiss="modal">
                            Close
                </button>
            </div>
        </div>
    </div>
</div>

                <!-- Forum Block -->
                <div class="block">
                    <!-- Tab Content -->
                    <div class="tab-content">
                        <!-- Forum -->
                        <div class="block-title">
                            <h2>User Listing</h2>
                        </div>
                        <!-- Datatables Content -->
                        <div class="table-responsive">
                                <div class="row"></div>
                                <table id="TblUsers" class="table table-vcenter table-condensed table-bordered">

                                </table>
                        </div>

                    </div>
                   
                    </div>


                    <footer class="clearfix">
                        <!--<div class="pull-right">
                        Crafted with <i class="fa fa-heart text-danger"></i> by <a href="http://goo.gl/vNS3I" target="_blank">pixelcave</a>
                    </div>-->
                        <div class="pull-left">
                            <span id="year-copy"></span>&copy; <a href="#">e2aForums</a>
                        </div>
                    </footer>
                    <!-- END Forum Block -->

               
                <HP:UserProfile ID="UserProfile" runat="server" />

          </div>
         </div>







</div>

    <!-- Footer BOX-->
    <HM:footerControl runat="server" ID="footerControl" />
    <!-- END Footer Box --> 
    <!---Comman Footer Scripts Start -->
    <HM:footerScriptControl runat="server" ID="footerScriptControl" />
    <!-- Comman Footer Scripts End--->


    <!-- Delete--->
  </div><!-- Page Container End -->


            <script src="../js/SJGrid.js"></script>
            <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
            
            <script src="js/toastr.js"></script>
            <script src="js/plugins.js"></script>
           
            <script src="js/FeedEk.js" type="text/javascript"></script>
            <script src="PagesJs/Company.js" type="text/javascript"></script>
            <script src="PagesJs/Common.js" type="text/javascript"></script>
            <script src="js/app.js"></script>
            <script src="js/jquery.tooltipster.js"></script>
        

            <script language="javascript" type="text/javascript">

                $(function () {

                    if ("<%=IsAdmin%>" == 'True') {
                        $('.adminLinks').show();
                        $('.UserLinks').hide();
                    }
                    if (VarUserTypeID != 2) {
                        $('.UserLinks').show();
                    }

                });



            </script>
    
</body>
</html>
