<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="User_pro" %>

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
    <link rel="stylesheet" type="text/css" href="../E2Forums-New/css/cropper/cropper.min.css" />
    <!--  EOF CSS INCLUDE -->
    <!-- CSS INCLUDE -->
    <link rel="stylesheet" type="text/css" id="theme" href="../E2Forums-New/css/theme-default.css" />
    <link rel="stylesheet" type="text/css" id="Link1" href="../E2Forums-New/css/custom.css" />
    <style>


    .megaSpacer {
    border-top: 5px solid #3d150a !important;
}
hr {
    -moz-border-bottom-colors: none;
    -moz-border-left-colors: none;
    -moz-border-right-colors: none;
    -moz-border-top-colors: none;
    border-color: #eee -moz-use-text-color #fff;
    border-image: none;
    border-style: solid none;
    border-width: 1px 0;
    margin: 20px 0;
}

    </style>
    <!-- EOF CSS INCLUDE -->
</head>
<body>

    <asp:Panel ID="PanelPageAuthContent" runat="server">
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

                        <div class="content-header">
                            <div class="header-section">
                                <h1>
                                    <i class="gi gi-book_open"></i>Welcome to <strong>Education</strong><br>
                                    <small>Courses Hub!</small>
                                </h1>
                            </div>
                        </div>


                        <!-- Main Row -->
                        <div class="row">
                            <div class="col-md-12">
                                <!-- Courses Content -->
                                <div class="row">
                                    <div id="div_allCourses">
                                        <img src="../img/progressing.gif" style="width: 10%; height: 10%; position: absolute; left: 55%; top: 70%; margin-left: -150px; margin-top: -150px;" />
                                    </div>


                                </div>
                            </div>
                        </div>


                        <div class="row">


                            <div class="col-md-12">
                                <h1 class="cm-link"><strong>Investor Education 101</strong></h1>
                            </div>
    

                            <hr class="megaSpacer" />


                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                <div class="coursesList"><center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Bonds-101/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                <div class="coursesList"><center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Mutual-funds-101/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            
                           
                            

                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                 <div class="coursesList"><center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Mutual-funds-get-the-facts-before-you-invest/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                              <div class="coursesList">      <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/9-types-of-investment-risk/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div></div>

                            </div>

                            
                            
                            

                            <div class="col-md-12">
                                <h1 class="cm-link"><strong>Preventing Frauds and Scams</strong></h1>
                            </div>
                            
                            
                            
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                          <div class="coursesList">          <div class="coursesList"><center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Check-before-you-invest/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div></div>

                            </div>
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                              <div class="coursesList">   <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Cybersecurity-protecting-your-investments-online/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            
                            
                            
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                            <div class="coursesList">     <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/4-signs-of-investment-fraud/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                              <div class="coursesList">   <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Identifying-and-avoiding-phone-and-email-scams/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            
                            
                            
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                               <div class="coursesList">  <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/7-common-investment-scams/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            <div class="col-lg-6">
                            </div>
                            <hr class="megaSpacer">

                            <div class="col-md-12">
                                <h1 class="cm-link"><strong>Seniors’ resources</strong></h1>
                            </div>
                            
                            
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                              <div class="coursesList">     <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Seniors-What-to-do-if-you-suspect-financial-abuse/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                         <div class="coursesList">          <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/If-you-suspect-financial-elder-abuse/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            
                            
                            
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                   <div class="coursesList"><center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Seniors-6-red-flags-of-financial-abuse/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                  <div class="coursesList"> <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/7-signs-of-financial-elder-abuse/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            
                            
                            
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                  <div class="coursesList"> <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/3-key-lessons-on-retirement-from-older-Canadians/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>



                            <div class="col-md-12">
                                <h1 class="cm-link"><strong>Regulatory Policy</strong></h1>
                            </div>
                            
                            
                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                   <div class="coursesList"><center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/CRM2-disclosing-investment-performance-and-the-cost-of-advice/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>

                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                  <div class="coursesList"> <center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Investments-know-what-you-pay-and-how-much-you-make/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            
                            
                            

                            <div class="col-lg-6">
                                <style type="text/css">
                                    @media only screen and (max-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }

                                    @media only screen and (max-device-width: 480px)
                                    {
                                        .OSC-card
                                        {
                                            height: 500px !important;
                                            min-height: 430px !important;
                                        }
                                    }
                                </style>
                                <!--[if lte IE 8]><style>.OSC-card {width: 547px !important;}</style><![endif]-->
                                   <div class="coursesList"><center><iframe class="OSC-card" src="http://www.blog.getsmarteraboutmoney.ca/fact-cards/en/cards/Investor-warnings-and-alerts-from-the-OSC/" scrolling="no" style="border: none; outline: none; box-shadow: 3px 3px 3px #ccc; width: 100%; max-width: 547px; height: 100%; max-height: 430px; clear: both; min-height: 430px; min-width: 280px;"></iframe></center></div>

                            </div>
                            </div>
                        </div>
                        <!-- END Page Content -->

                        <HP:UserProfile ID="UserProfile" runat="server" />

                    </div>
                </div>







            </div>
            <!-- Page Container End -->

            <!-- Footer BOX-->
            <HM:footerControl runat="server" ID="footerControl" />

            <!-- END Footer Box -->
            <!---Comman Footer Scripts Start -->
            <HM:footerScriptControl runat="server" ID="footerScriptControl" />

            <!-- Comman Footer Scripts End--->


            <!-- Delete--->
        </div>



        <script src="../js/SJGrid.js"></script>
        <!-- Bootstrap.js, Jquery plugins and Custom JS code -->

        <script src="js/toastr.js"></script>
        <script src="js/vendor/bootstrap.min.js"></script>
        <script src="js/plugins.js"></script>

        <script src="js/FeedEk.js" type="text/javascript"></script>
        <script src="PagesJs/Courses.js" type="text/javascript"></script>
        <script src="PagesJs/Common.js" type="text/javascript"></script>
        <script src="js/app.js"></script>
        <script src="js/jquery.tooltipster.js"></script>


        <script language="javascript" type="text/javascript">

              

        </script>

    </asp:Panel>
</body>
</html>
