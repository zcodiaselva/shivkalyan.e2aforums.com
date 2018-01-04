<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<!DOCTYPE html>
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head>
    <meta charset="utf-8">

    <title>Home : Details</title>

    <meta name="description" content="E2A Forums">
    <meta name="author" content="E2A Forums">
    <meta name="robots" content="noindex, nofollow">

    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">

    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="logoblue.ico">
    <link rel="apple-touch-icon" href="Themes/img/icon57.png" sizes="57x57">
    <link rel="apple-touch-icon" href="Themes/img/icon72.png" sizes="72x72">
    <link rel="apple-touch-icon" href="Themes/img/icon76.png" sizes="76x76">
    <link rel="apple-touch-icon" href="Themes/img/icon114.png" sizes="114x114">
    <link rel="apple-touch-icon" href="Themes/img/icon120.png" sizes="120x120">
    <link rel="apple-touch-icon" href="Themes/img/icon144.png" sizes="144x144">
    <link rel="apple-touch-icon" href="Themes/img/icon152.png" sizes="152x152">
    <!-- END Icons -->

    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <link href="Themes/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="Themes/css/plugins.css" />

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="Themes/css/main.css" />

    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="Themes/css/themes.css" />
    <!-- END Stylesheets -->

    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="Themes/js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <style type="text/css">
        article p {
            font-size: 14px;
        }

        article ul li {
            font-size: 14px;
        }
    </style>
</head>
<body style="background-color: #fff;">
    <!-- Page Container -->
    <!-- 'boxed' class for a boxed layout -->
    <div id="page-container">
        <!-- Site Header -->
        <header>
            <div class="container">
                <!-- Site Logo -->
                <a href="index.html" class="site-logo">
                    <img style="margin-top: -13px;" src="User/img/logoblue.png">
                </a>
                <!-- Site Logo -->

                <!-- Site Navigation -->
                <nav>
                    <!-- Menu Toggle -->
                    <!-- Toggles menu on small screens -->
                    <a href="javascript:void(0)" class="btn btn-default site-menu-toggle visible-xs visible-sm">
                        <i class="fa fa-bars"></i>
                    </a>
                    <!-- END Menu Toggle -->

                    <!-- Main Menu -->
                    <ul class="site-nav">
                        <!-- Toggles menu on small screens -->
                        <li class="visible-xs visible-sm">
                            <a href="javascript:void(0)" class="site-menu-toggle text-center">
                                <i class="fa fa-times"></i>
                            </a>
                        </li>
                        <li class="active">

                            <a href="Home.aspx">Home</a>
                        </li>
                        <li>
                            <a href="aboutus.aspx">About us</a>
                        </li>
                        <li>
                            <a class="site-nav-sub"><i class="fa fa-angle-down site-nav-arrow"></i>Sign up</a>
                            <ul>
                                <li>
                                    <a style="cursor: pointer;" onclick="return redirectologin('2');">Expert</a>
                                </li>
                                <li>
                                    <a style="cursor: pointer;" onclick="return redirectologin('3');">User</a>
                                </li>
                                <li>
                                    <a style="cursor: pointer;" onclick="return redirectologin('4');">Advisor</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="SignIn.aspx">Login</a>
                        </li>
                        <!-- END Menu Toggle -->


                    </ul>
                    <!-- END Main Menu -->
                </nav>
                <!-- END Site Navigation -->
            </div>
        </header>
        <!-- END Site Header -->

        <!-- Home Carousel -->
        <div id="home-carousel" class="carousel carousel-home slide" data-ride="carousel" data-interval="2000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="active item">
                    <section class="site-section site-section-light site-section-top" style="background-image: url(img/banner.jpg);">
                        <div class="container">
                            <h2 class="text-center animation-slideUp push hidden-xs">&nbsp;</h2>
                            <h2 class="text-center animation-slideUp push hidden-xs">&nbsp;</h2>
                            <h2 class="text-center animation-slideUp push hidden-xs">&nbsp;</h2>
                        </div>
                    </section>
                </div>
                <div class="item">
                    <section class="site-section site-section-light site-section-top" style="background-image: url(img/banner-financial.jpg);">
                        <div class="container">
                            <h2 class="text-center animation-slideUp push hidden-xs">&nbsp;</h2>
                            <h2 class="text-center animation-slideUp push hidden-xs">&nbsp;</h2>
                            <h2 class="text-center animation-slideUp push hidden-xs">&nbsp;</h2>
                        </div>
                    </section>
                </div>
            </div>
            <!-- END Wrapper for slides -->

            <!-- Controls -->
            <a class="left carousel-control" href="#home-carousel" data-slide="prev">
                <span>
                    <i class="fa fa-chevron-left"></i>
                </span>
            </a>
            <a class="right carousel-control" href="#home-carousel" data-slide="next">
                <span>
                    <i class="fa fa-chevron-right"></i>
                </span>
            </a>
            <!-- END Controls -->
        </div>
        <!-- END Home Carousel -->

        <!-- Article Mutual Fund -->
        <section id="div_MutualFund" class="site-content site-section display-none">
            <div class="container">
                <div class="row">
                    <div class="col-md-10 col-md-offset-1 site-block">
                        <i><a href="Home.aspx">Home </a><a>> </a><a class="pink">Mutual Funds</a></i>
                        <br />
                        <!-- Story -->
                        <article>
                            <h3 class="pink"><strong>Mutual Funds</strong></h3>
                            <br />
                            <p>
                                A mutual fund is a type of investment fund. An
                                investment fund is a collection of investments,
                                such as stocks, bonds or other funds. Unlike
                                most other types of investment funds, mutual
                                funds are “open-ended,” which means as
                                more people invest, the fund issues new units
                                or shares.
                                A mutual fund typically focuses on specific
                                types of investments. For example, a fund may
                                invest mainly in government bonds, stocks
                                from large companies or stocks from certain
                                countries. Some funds may invest in a mix of
                                stocks and bonds, or other mutual funds.
                            </p>

                            <p>
                                When you buy a mutual fund, you’re pooling
                                your money with many other investors. This
                                lets you invest in a variety of investments for a
                                relatively low cost. Another advantage is that
                                a professional manager makes the decisions
                                about specific investments.
                                Also, mutual funds are widely available
                                through banks, financial planning firms,
                                brokerage firms, credit unions, trust
                                companies and other investment firms. You
                                can buy or sell funds at any time.
                            </p>

                            <p>
                                Like all investments, mutual funds have risk—
                                you could lose money on your investment.
                                The value of most mutual funds will change
                                as the value of their investments goes up and
                                down. Depending on the fund, the value could
                                change frequently and by a lot.
                                Also, there are fees that will affect the return
                                you get on your investment. Some of these
                                fees are paid by you, and others are paid by
                                the fund.
                            </p>
                            <p>
                                Your return will also depend on the portfolio
                                manager’s skill at picking investments. Some
                                studies show that most mutual funds are
                                unlikely to consistently perform better than
                                their benchmark over the long term. <a target="_blank" href="http://www.osc.gov.on.ca/documents/en/Investors/res_mutual-funds_en.pdf">More>> </a>
                            </p>

                        </article>
                        <!-- END Story -->
                    </div>
                </div>
                <hr>
            </div>
        </section>
        <!-- END Article -->

        <!-- Article Segregated Funds -->
        <section id="div_SegregatedFunds" class="site-content site-section display-none">
            <div class="container">
                <div class="row">
                    <div class="col-md-10 col-md-offset-1 site-block">
                        <i><a href="Home.aspx">Home </a><a>> </a><a class="pink">Segregated Funds</a></i>
                        <br />
                        <!-- Story -->
                        <article>
                            <h3 class="pink"><strong>Segregated Funds</strong></h3>
                            <br />
                            <p>
                                Segregated funds are unique financial assets available only through life insurance companies. They are called "segregated funds" because life insurers hold them separate from the general assets of the company.<br />
                                Consumers can participate in segregated funds by purchasing a segregated fund contract (an "Individual Variable Insurance Contract") which combines the growth potential of investment funds with unique guarantee features that provide downside risk protection.<br />
                                Life and health insurance companies have total assets of $646.6 billion1.<br />
                                More than 38% of those assets ($246.9 billion) are held in segregated funds. Of that, $101.7 billion represent individual contracts (the remainder are pension products)2.<br />
                                3.2 million Canadians own Individual Variable Insurance Contracts.<br />
                                Assets in those contracts ($101.7 billion) form 9.3% of the total investment fund industry of $1.1 trillion; although down slightly from the 2012 level of 9.8%, segregated funds as a proportion of that industry has remained fairly stable over the past decade in the 9-10% range3.<br />
                                Life and health insurance companies are regulated for solvency: they must meet Minimum Continuing Capital and Surplus Requirements (MCCSR) set by the Office of the Superintendent of Financial Institutions (OSFI) and maintain reserves to meet future guarantees contained in IVIC contracts.
                            </p>
                            <p>
                                Life and health insurance companies are subject to marketplace regulation 
                                <ul>
                                    <li>They can use only licensed agents to offer their products</li>
                                    <li>They must provide disclosure about the product before you purchase your contract</li>
                                    <li>Disclosure is made through an "Information Folder" which includes a brief summary of your contract and your rights in a "Key Facts" document, as well as two-page "Fund Facts" documents describing each of the segregated funds offered in your contract</li>
                                </ul>
                            </p>
                            <p>You can only buy a segregated fund contract through an agent who holds a life insurance license issued by the provincial regulator. There are 96,800 licensed life agents throughout Canada.</p>

                        </article>
                        <!-- END Story -->
                    </div>
                </div>
                <hr>
            </div>
        </section>
        <!-- END Article -->

        <!-- Article Stocks -->
        <section id="div_Stocks" class="site-content site-section display-none">
            <div class="container">
                <div class="row">
                    <div class="col-md-10 col-md-offset-1 site-block">
                        <i><a href="Home.aspx">Home </a><a>> </a><a class="pink">Stocks</a></i>
                        <br />
                        <!-- Story -->
                        <article>
                            <h3 class="pink"><strong>Stocks</strong></h3>
                            <br />
                            <p>
                                At some point, just about every company needs to raise money, whether to open up a West Coast sales office, build a factory, or hire a crop of engineers.<br />
                                In each case, they have two choices: 1) Borrow the money, or 2) raise it from investors by selling them a stake (issuing shares of stock) in the company.<br />
                                When you own a share of stock, you are a part owner in the company with a claim (however small it may be) on every asset and every penny in earnings.<br />
                                Individual stock buyers rarely think like owners, and it's not as if they actually have a say in how things are done.
                                <br />
                                Nevertheless, it's that ownership structure that gives a stock its value. If stockowners didn't have a claim on earnings, then stock certificates would be worth no more than the paper they're printed on. As a company's earnings improve, investors are willing to pay more for the stock.<br />
                                Over time, stocks in general have been solid investments. That is, as the economy has grown, so too have corporate earnings, and so have stock prices.<br />
                                Since 1926, the average large stock has returned close to 10% a year. If you're saving for retirement, that's a pretty good deal -- much better than Canadian/U.S. savings bonds, or stashing cash under your mattress.
                                <br />
                                Of course, "over time" is a relative term. As any stock investor knows, prolonged bear markets can decimate a portfolio.<br />
                                Since World War II, Wall Street has endured several bear markets -- defined as a sustained decline of more than 20% in the value of the Dow Jones Industrial Average.<br />
                                Bull markets eventually follow these downturns, but again, the term "eventually" offers small sustenance in the midst of the downdraft.<br />
                                The point to consider, then, is that investing must be considered a long-term endeavor if it is to be successful. In order to endure the pain of a bear market, you need to have a stake in the game when the tables turn positive.
                            </p>
                        </article>
                        <!-- END Story -->
                    </div>
                </div>
                <hr>
            </div>
        </section>
        <!-- END Article -->

        <!-- Article Bonds -->
        <section id="div_Bonds" class="site-content site-section display-none">
            <div class="container">
                <div class="row">
                    <div class="col-md-10 col-md-offset-1 site-block">
                        <i><a href="Home.aspx">Home ></a><a class="pink"> Bonds</a></i>
                        <br />
                        <!-- Story -->
                        <article>
                            <h3 class="pink"><strong>Bonds</strong></h3>
                            <br />
                            <p>
                                Bonds are a form of debt. Bonds are loans, or IOUs, but you serve as the bank. You loan your money to a company, a city, the government – and they promise to pay you back in full, with regular interest payments. A city may sell bonds to raise money to build a bridge, while the federal government issues bonds to finance its spiraling debts.<br />
                                Nervous investors often flock to the safety of bonds – and the steady stream of income they generate — when the stock market becomes too volatile. Younger investors should carve out a portion of our retirement accounts – 15% or less, depending on one’s age, goals and risk tolerance – to balance out riskier stock-based investments.<br />
                                That doesn’t mean that all bonds are risk-free – far from it. Some bonds happen to be downright dicey. As with all investments, you’re paid more for buying a riskier security. In the bond world, that risk comes in a few different forms.<br />
                                The first is the likelihood the bond issuer will make good on its payments. Less credit-worthy issuers will pay a higher yield, or interest rate. That’s why the riskiest issuers offer what’s called high-yield or “junk” bonds. Those at the opposite end of the spectrum, or those with the best histories, are deemed investment-grade bonds.<br />
                                The safest of the safe are issued by the U.S. government, known as Treasurys; they’re backed by the “full faith and credit” of the U.S. and are deemed virtually risk-free. As such, a Treasury bond will pay a lower yield then a bond issued by a storied company like Johnson & Johnson (investment grade). But J&J will pay less in interest than a bond issued by, say, Shady Joe’s Mail-Order Bride Inc.<br />
                                How long you hold the bond (or how long you lend your money to the bond issuer) also comes into play. Bonds with longer durations – say a 10-year bond versus a one-year bond – pay higher yields. That’s because you’re being paid for keeping your money tied up for a longer period of time.<br />
                                Interest rates, however, probably have the single largest impact on bond prices. As interest rates rise, bond prices fall. That’s because when rates climb, new bonds are issued at the higher rate, making existing bonds with lower rates less valuable.<br />
                                Of course, if you hold onto your bond until maturity, it doesn’t matter how much the price fluctuates. Your interest rate was set when you bought it, and when the term is up, you’ll receive the face value (the money you initially invested) of the bond back — so long as the issuer doesn’t blow up. But if you need to sell your bond on the secondary market – before it matures – you could get less than your original investment back.<br />
                                Up until now, we’ve talked about individual bonds. Mutual funds that invest in bonds, or bond funds, are a bit different: Bond funds do not have a maturity date (like individual bonds), so the amount you invested will fluctuate as will the interest payments it throws off.<br />
                                Then why bother with a bond fund? You need a good hunk of money to build a diversified portfolio of individual bonds. Depending on the type of bond portfolio you’re looking to build, it could require tens of thousands in order to do it right. Bond funds, meanwhile, provide instant diversification. We explain more on the differences between bonds and bond funds below.<br />
                                Before delving into the world of bonds, you’re going to want to familiarize yourself with the types of bonds available and some of the associated vocabulary.<br />
                                Treasurys are issued by the government and are considered the safest bonds on the market. As such, you won’t collect as much in interest as you might elsewhere, but you don’t have to worry about defaults. They’re also used as a benchmark to price all other bonds, such as those issued by companies and municipalities.<br />
                                Treasurys are available in $1,000 increments and are initially sold via auction, where the price of the bond and how much interest it pays out is determined. You can bid directly through your bank or broker. They also trade like any regular security on the open market.<br />

                                Treasury Bills, or T-bills, are a short-term investment sold in terms ranging from a few days to 26 weeks. They’re sold at a discount to their face value ($1,000), but, when T-bills mature, you redeem the full face value. You pocket the difference between the amount you paid and the face value, which is the interest you earned.<br />

                                Treasury Notes are issued in terms of two, five and 10 years and in increments of $1,000. Mortgage rates are priced off of the 10-year note (more commonly called the 10-year bond even though it’s technically a note).<br />
                                Treasury Bonds are issued in terms of 30 years. They pay interest every six months until they mature.<br />
                                Treasury Inflation-Protected Securities (TIPS) are used to protect your portfolio against inflation. TIPS’ usually pay a lower interest rate than other Treasurys, but their principal and interest payments, paid every six months, adjust with inflation as measured by the Consumer Price Index. It’s best to hold these in a tax-deferred account, like an individual retirement account, or IRA, because you’ll have to pay federal taxes on the increase in the underlying principal – even though you don’t get the principal back until maturity. When TIPS do mature, investors receive either the adjusted principal or the original principal, whichever is greater. TIPS are sold with five, 10, and 20-year terms.<br />
                                Savings Bonds are probably some of the most boring gifts out there, but it can’t hurt to understand how they work. You can redeem your savings bonds after a year of holding them, up to 30 years. Talk to your advisor to learn more about it. To find a list of member advisors in your area click here.<br />
                                EE Savings Bonds earn a fixed-rate of interest and can be redeemed after a year (though you lose 3 months interest if you hold them less than five years), but can be held for up to 30 years. When you redeem the bond, you’ll collect the interest accrued plus the amount you paid for the bond. They can be purchased in the form of a paper certificate at a bank for half of their face value (for example, a $100 bond can be purchased for $50) in varying increments from $50 to $10,000. If they’re purchased online, they’re purchased at face value, but can be bought for any amount starting at $25.<br />
                                I Savings Bonds are similar to EE savings bonds, except that they’re indexed for inflation every six months. These are always sold at face value, regardless of whether you buy paper bond certificates or you buy them electronically.<br />
                                Agency bonds are not quite as safe as Treasurys, but yet it’s often safer than the most pristine corporate bonds. They’re issued by government-sponsored enterprises. Because these companies are chartered and regulated in part by the government, the bonds they issue are perceived to be safer than corporate bonds. They are not, however, backed by the “full faith and credit” of the respective. government like Treasurys, which would make them virtually risk-free.<br />
                                Municipal bonds, or Munis, as they’re commonly known, are issued by states, cities and local governments to fund various projects. Municipals aren’t subject to federal taxes, and if you live where the bonds are issued, they may also be exempt from state taxes. Some municipal bonds are more credit-worthy than others, though some munis are insured. If the issuer defaults, the insurance company will have to cover the tab.<br />
                                Corporate bonds are bonds issued by companies. Corporate debt can range from extremely safe to super risky.<br />
                                Coupon is another word for the interest rate paid by a bond. For instance, a $1,000 bond with a 6% coupon will pay $60 a year. The word coupon is used because some bonds really had a paper coupon attached to them, which could be redeemed for the payment.<br />
                                Par is also known as the face value of a bond, this is the amount a bondholder receives when the bond matures. If interest rates rise higher than the bond’s rate, the bond will trade at a discount, or below par; if rates fall below the bond’s rate, it will trade at a premium, or above par.<br />
                                Duration is a measure of a bond price’s sensitivity to a change in interest rates, measured in years. Bonds with longer durations are more sensitive to interest rate changes. If you’re in a bond with a duration of 10 years and rates rise 1%, you’ll see a 10% decline in the bond’s price.
                            </p>

                        </article>
                        <!-- END Story -->
                    </div>
                </div>
                <hr>
            </div>
        </section>
        <!-- END Article -->

        <!-- Article Bonds -->
        <section id="div_ETF" class="site-content site-section display-none">
            <div class="container">
                <div class="row">
                    <div class="col-md-10 col-md-offset-1 site-block">
                        <i><a href="Home.aspx">Home ></a><a class="pink"> ETF</a></i>
                        <br />
                        <!-- Story -->
                        <article>
                            <h3 class="pink"><strong>ETF’s (Exchange Traded Funds)</strong></h3>
                            <br />
                            <p>
                                A security that tracks an index, a commodity or a basket of assets like an index fund, but trades like a stock on an exchange. ETFs experience price changes throughout the day as they are bought and sold. Because it trades like a stock, an ETF does not have its net asset value (NAV) calculated every day like a mutual fund does.<br />
                                By owning an ETF, you get the diversification of an index fund as well as the ability to sell short, buy on margin and purchase as little as one share. Another advantage is that the expense ratios for most ETFs are lower than those of the average mutual fund. When buying and selling ETFs, you have to pay the same commission to your broker that you'd pay on any regular order.

                            </p>

                        </article>
                        <!-- END Story -->
                    </div>
                </div>
                <hr>
            </div>
        </section>
        <!-- END Article -->

        <!-- Article Insurance -->
        <section id="div_Insurance" class="site-content site-section display-none">
            <div class="container">
                <div class="row">
                    <div class="col-md-10 col-md-offset-1 site-block">
                        <i><a href="Home.aspx">Home ></a><a class="pink"> Insurance</a></i>
                        <br />
                        <!-- Story -->
                        <article>
                            <h3 class="pink"><strong>Insurance</strong></h3>
                            <br />
                            <p>
                                Life insurance is a contract between you “the insured” and “the insurer”. The insurer agrees to pay your beneficiary (s) as set out in the contract an agreed sum of money as defined in the contract in the event of death There are various types of life insurance products available today and some are complex. It’s best advised to seek a professional which product suits your needs best.<br />
                                To keep it simple, there are two types of life insurance contracts:<br />
                                <ol>
                                    <li><b>Term Insurance</b>: As the name suggests, this type of insurance is for a fixed term and most contracts renew for the same term at a higher rate. Generally this type of insurance will expire at age 85.</li>
                                   <li><b>Permanent Insurance</b>: As the name suggests, this type of coverage never expires and generally, pays out at age 100, should you live that long or at any age when the death occurs. Generally the premiums are level but talk to an insurance advisor what type of permanent insurance is best suited for your needs.</li>
                                </ol>
                            </p>
                            <p>
                                <b>Other types of Insurance products</b><br />
                                Living Benefit<br />
                                Following types of insurances are covered under this category:<br />
                                <ul>
                                    <li>Critical Illness: Critical illness insurance pays a lump-sum benefit that you can use any way you wish when you are diagnosed with a covered critical illness, as defined in the policy, and satisfy the survival period, as defined in the policy. Number of illnesses covered is based on the type of contract you purchase. A basic policy will cover four illnesses:, Cancer, Stroke, Coronary Artery Bypass, Heart Attack. A more comprehensive policy will cover anywhere from 25 to 26 illnesses. It’s best to consult an expert before you purchase. To consult members in your area please click here.</li>

                                    <li>Long Term Care Insurance: We perform six daily activities that make us independent. They are:<br />
                                        <ol>
                                            <li>Bathing</li>
                                            <li>Dressing</li>
                                            <li>Toileting</li>
                                            <li>Transferring</li>
                                            <li>Continence</li>
                                            <li>Feeding</li>
                                        </ol>
                                        If you’re dependent on carrying out some of these daily activities you’re automatically dependent. In most cases, if you’re unable to perform 2 out of the 6 daily activities, you qualify for long term care benefits. There are other conditions that make you eligible for this benefit.<br />
                                        For more information on Long Term care follow this link: <a href="http://www.clhia.ca/domino/html/clhia/CLHIA_LP4W_LND_Webstation.nsf/resources/Consumer+Brochures/$file/Brochure_Guide_Long_Term_Care_ENG.pdf" target="_blank"><i>More>></i></a>

                                    </li>
                                    <li>Disability</li>
                                    <li>Health and Dental</li>
                                </ul>
                            </p>
                        </article>
                        <!-- END Story -->
                    </div>
                </div>
                <hr>
            </div>
        </section>
        <!-- END Article -->

        <!-- Footer -->
        <footer class="site-footer site-section">
            <div class="container">
                <!-- Footer Links -->
                <div class="row">
                    <div class="col-sm-6">
                        <h4></h4>
                        <ul class="footer-nav list-inline">
                            <li><a href="aboutus.aspx">About Us</a></li>
                            <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                            <li><a href="TermsOfUse.aspx">Terms of Service</a></li>
                        </ul>
                    </div>
                    <div class="col-sm-6 text-right">
                        <h4 class="footer-heading"><span id="year-copy">2014</span> &copy; <a href="#">e2a Forums</a></h4>
                    </div>
                </div>
                <!-- END Footer Links -->
            </div>
        </footer>
        <!-- END Footer -->
    </div>
    <!-- END Page Container -->

    <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
    <a href="#" id="to-top"><i class="fa fa-angle-up"></i></a>
    <form method="post" id="hiddForm">
        <input type="hidden" name="UserTypeID" id="hiddUserTypeID" value="-1" />
    </form>
    <!-- Include Jquery library from Google's CDN but if something goes wrong get Jquery from local file (Remove 'http:' if you have SSL) -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>!window.jQuery && document.write(decodeURI('%3Cscript src="js/vendor/jquery-1.11.1.min.js"%3E%3C/script%3E'));</script>

    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="Themes/js/vendor/bootstrap.min.js"></script>
    <script src="Themes/js/plugins.js"></script>
    <script src="Themes/js/app.js"></script>
    <script src="js/Querystring.js"></script>
    <script>

        var _divId = "";

        $(function () {
            var qs = new Querystring();
            if (qs.contains("Section")) {
                _divId = qs.get("Section");

                showRequiredDiv(_divId)
            }
        });

        var redirectologin = function (pvartype) {
            $('#hiddUserTypeID').val(pvartype);
            document.forms["hiddForm"].action = "register.aspx";
            document.forms["hiddForm"].submit();
        }

        var showRequiredDiv = function (pvarDivId) {
            $(".site-content").hide();
            $("#div_" + pvarDivId).fadeIn();
        }
    </script>
</body>
</html>


