<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="Pricing.aspx.cs" Inherits="_Default" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="innerPage"> <img class="img-responsive" src="ashi/images/1.png" alt=""></div>






        <section class="bannerStrip">

            <div class="container">
                <p class="free-tril">  <span>Start Your 14-days Free Trial Now!</span> <a class="signupbtn" href="Register.aspx">Click Here</a></p>
            </div>
        </section>


        <header data-featurette="marketing-pricing" data-layout-element="hero" class="hero-loaded">
            <div class="container">


                <div class="row plans">
                    <!-- Basic Plan -->
                    <div class="col-md-6 col-xs-12 col-sm-12">
                        <div class="plan-panel basic-plan">
                            <div class="plan-header">
                                <h3>Basic Plan</h3>
                                <span>$4.99<small>/mo</small></span>
                            </div>
                            <ul class="plan-features">
                                <li>HST/GST (varies with each province) per month guaranteed for 1 year.</li>
                                <li>You get to enjoy complete access to the site including features like calendar management, sales CRM, document storage facility, chat, forum, and much more.</li>

                            </ul>
                            <div class="plan-cta">
                                <a id="silver-signup-link" href="pay/BasicPlan.html" data-featurette="analytics-click-event" data-event-label="Source: Plans Page" data-event-category="button" data-event-action="M: Clicked Basic" class="button button-primary full">Click To Pay Now</a>
                            </div>
                        </div>
                    </div>

                    <!-- Pro Plan -->
                    <div class="col-md-6 col-xs-12 col-sm-12">
                        <div class="plan-panel pro-plan">
                            <div class="plan-header">
                                <h3>Pro Plan</h3>
                                <span>$100<small>/mo</small></span>
                            </div>
                            <ul class="plan-features">
                                <li>$100 + HST per month guaranteed for 1 year. Banner ad design is extra.</li>
                                <li>Includes all Tier 1 features plus a banner ad in the members region. Ad will run 5 times a day at different times.</li>
                                <li>Banner ad design is extra</li>

                            </ul>
                            <div class="plan-cta">
                                <a id="gold-signup-link" href="pay/ProPlan.html" data-featurette="analytics-click-event" data-event-label="Source: Plans Page" data-event-category="button" data-event-action="M: Clicked Pro" class="button button-primary full">Click To Pay Now</a>
                            </div>
                        </div>
                    </div>

                </div>
                <!-- /plans -->
            </div>
        </header>

        <!-- Plans -->
        <div class="section plans-content">

            <div class="twelve columns">
                <div class="callout-card organizations">
                    <p>Bulk Corporate membership available at 10% discount. 3 month free trial included. Minimum sign up is 10 members.</p>
                    <p>Company Ads: Please call for pricing at<a href="tel:+1-888-280-7780"> 1-888-280-7780</a> or<a href="mailto:info@e2aforums.com"> email: info@e2aforums.com</a></p>
                    <a href="support.aspx" data-featurette="analytics-click-event" data-event-label="Source: Plans Page" data-event-category="button" data-event-action="M: Clicked Organizations" class="button inverse small redmre" id="featurette-10">Contact Us</a>
                    <div class="illustration left">
                    </div>
                    <div class="illustration right">



                    </div>
                </div>
            </div>




        </div>
    </asp:Content>