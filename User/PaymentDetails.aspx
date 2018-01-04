<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentDetails.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>E2aforums Admin</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
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


<!-- Top Menu Control Start  --> <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />
   
    <!-- Top Menu Control End  -->

<!-- PAGE CONTENT -->
<div class="page-content">
    <!-- Side Menu Control Start  -->
    <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />
    <!-- side Menu Control End  -->
     <div class="page-content-wrap"> 
      <div class="inner-content-wrap"> 
                <!-- Page content -->
             <!-- Tab Content -->
          <h1>Payment Details</h1>
                        <div class="tab-content" id="wn">
                              <div class="table-responsive" id="paycontent" >
                                <table id="TblPayment"  class="table table-bordered table-striped table-actions">
                                </table>
                                  </div>
                            </div>
                            
                                <!-- Trigger the modal with a button -->


            <HP:UserProfile ID="UserProfile" runat="server" />


          </div>
         </div>

</div><!-- Page Container End -->

    <!-- Footer BOX-->
    <HM:footerControl runat="server" ID="footerControl" />

<!-- END Footer Box --> 
    <!---Comman Footer Scripts Start -->
    <HM:footerScriptControl runat="server" ID="footerScriptControl" />

    <!-- Comman Footer Scripts End--->


    <!-- Delete--->
  </div>
 <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
    <a href="#" id="to-top"><i class="fa fa-angle-double-up"></i></a>


    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
 
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>  
    <script src="js/FileReader.js"></script>  
    <script src="PagesJs/Payment.js" type="text/javascript"></script>

    <script src="js/ajaxfileupload.js"></script>
     <script src="PagesJs/Common.js" type="text/javascript"></script>
    <script src="js/jquery.tooltipster.js"></script>
    


<!-- Modal -->


    
    
    
    
        <!-----Pop Up---->    
                            <%--data-toggle="modal" data-target="#myModal"--%>
  <div id="PayDetails" class="modal fade myCustomPay" role="dialog">
  <div class="modal-dialog"> 
    
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Payment Details</h4>
      </div>
      <div class="modal-body">
        <div class="panel panel-default" id="Div1">
          <div class="panel-body">
            <h2>Transaction ID  #<strong><span id="ptxn_id" ></span></strong></h2>
            <div class="push-down-10 pull-right">
             <%-- <button class="btn btn-default"><span class="fa fa-print"></span> Print</button>--%>
            </div>
            <!-- INVOICE -->
            <div class="invoice">
              <div class="row">
                <div class="col-md-4">
                  <div class="invoice-address">
                    <h5>From</h5>
                    <h6>Payment For Account</h6>
                    <p ><span id="pFull_Name"></span> </p>
                    <p><strong>Email:</strong> <span id="pEMail"></span> </p>
                  </div>

                  <div class="invoice-address">
                    <h5>To</h5>
                    <h6>e2aforums</h6>
                    <p><strong>Toll Free:</strong> +1-888-280-7780</p>
                    <p><strong>Email:</strong> info@e2aforums.com</p>
                    <p><strong>Support:</strong> support@e2aforums.com</p>
                  </div>

                </div>

                <div class="col-md-8">
                  <div class="invoice-address">
                    <h5>Payment Invoice</h5>
                    <table class="table table-striped">
                      <tbody>
                        <tr>
                          <td width="200">Transaction Type :</td>
                          <td class="text-right"> <span id="ptxn_type"></span></td>
                        </tr>
                        <tr>
                          <td> Payer ID :</td>
                          <td class="text-right"> <span id="ppayer_id"></span></td>
                        </tr>
                        <tr>
                          <td> Payer Full Name :</td>
                          <td class="text-right"> <span id="pbuy_FullName"></span></td>
                        </tr>
                        <tr>
                          <td> Payer Email :</td>
                          <td class="text-right"> <span id="ppayer_email"></span></td>
                        </tr>
                        <tr>
                          <td>Payment Response Date time :</td>
                          <td class="text-right"> <span id="ppay_res_date"></span></td>
                        </tr>
                        <tr>
                          <td>Response:</td>
                          <td class="text-right"> <span id="pstr_out_Response"></span></td>
                        </tr>
                        <tr>
                          <td>Requset ID :</td>
                          <td class="text-right"> <span id="preq_id"></span></td>
                        </tr>
                        <tr>
                          <td>Request Status :</td>
                          <td class="text-right"><span class="label label-refunded"> <span id="pout_flag_val"></span></span></td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
              </div>


<div id="basicPlanWrap">
                  <div class="table-invoice">
                <table class="table">
                  <tbody>
                    <tr>
                      <th>Membership Description</th>
     
                    </tr>
                    <tr>
                      <td><strong><span class="basicPlan">Basic Plan</span></strong>
                       </td>
                      <td class="text-center"> $ <span id="pout_mc_grossB"></span> /mo</td>
                      
                    </tr>
                  </tbody>
                </table>
              </div>

              <div class="row">
                <div class="col-md-6">
                  <h4>Payment Methods</h4>
                  <div class="paymant-table"> <a class="active" href="#"> <img src="../E2Forums-New/img/paypal.png"> PayPal
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    </a> <a href="#"> <img src="../E2Forums-New/img/visa.png"> Visa
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    </a> <a href="#"> <img src="../E2Forums-New/img/cards/mastercard.png"> Master Card
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    </a> </div>
                </div>
                <div class="col-md-6">
                  <div class="popPlan">
                    <div class="popPlanWrap">
                      <div class="plan-header">
                        <h4 class="basicPlan">Basic Plan</h4>
                        <span>$<span id="pout_mc_grossB1"></span><small>/mo</small></span> </div>
                      <ul class="plan-features">
                        <li>HST/GST (varies with each province) per month guaranteed for 1 year.</li>
                        <li>You get to enjoy complete access to the site including features like calendar management, sales CRM, document storage facility, chat, forum, and much more.</li>
                      </ul>
                    </div>
                  </div>
                </div>
              </div>
    </div>





                <div id="proPlanWrap">
              <div class="row">

                                    <div class="table-invoice">
                <table class="table">
                  <tbody>
                    <tr>
                      <th>Membership Description</th>
     
                    </tr>
                    <tr>
                      <td><strong><span class="proPlan">PRO Plan</span></strong>
                       </td>
                      <td class="text-center"> $<span id="pout_mc_grossP"></span>/mo</td>
                     
                    </tr>
                  </tbody>
                </table>
              </div>

                <div class="col-md-6">
                  <h4>Payment Methods</h4>
                  <div class="paymant-table"> <a class="active" href="#"> <img src="../E2Forums-New/img/paypal.png"> PayPal
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    </a> <a href="#"> <img src="../E2Forums-New/img/visa.png"> Visa
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    </a> <a href="#"> <img src="../E2Forums-New/img/cards/mastercard.png"> Master Card
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                    </a> </div>
                </div>
                <div class="col-md-6">

                  
                  <div class="popPlan" id="proPlan">
                    <div class="popPlanWrap">
                      <div class="plan-header">
                        <h4 class="proPlan">Pro Plan</h4>
                        <span>$<span id="pout_mc_grossP1"></span><small>/mo</small></span> </div>
                      <ul class="plan-features">
                        <li>Per month guaranteed for 1 year. Banner ad design is extra.</li>
                        <li>Includes all Tier 1 features plus a banner ad in the members region. Ad will run 5 times a day at different times.</li>
                        <li>Banner ad design is extra.</li>
                      </ul>
                    </div>
                  </div>
                  
                  
                </div>
              </div>
    </div>


              <div class="row">
                <div class="col-md-12">
                  <div class="pull-right push-down-20">
                      <br>
                    <button class="btn btn-danger" data-dismiss="modal" type="button"> <span class="fa fa-credit-card"></span> OK</button>
                  </div>
                </div>
              </div>
            </div>
            <!-- END INVOICE --> 
            
          </div>
        </div>
        
        
        
        
      </div>
    </div>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
  </div>
</div>
    <script type="text/javascript"  >
        GetPaymentDetails();

    </script>
                            <!---- Popup end-->
</body>

</html>


