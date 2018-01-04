<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserModules.aspx.cs" Inherits="User_UserModules" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>Mutual Funds</title>
    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">
    <link href="../css/toastr.css" rel="stylesheet" type="text/css" />
    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="img/circularlogo.png">
    <link rel="apple-touch-icon" href="img/icon57.png" sizes="57x57">
    <link rel="apple-touch-icon" href="img/icon72.png" sizes="72x72">
    <link rel="apple-touch-icon" href="img/icon76.png" sizes="76x76">
    <link rel="apple-touch-icon" href="img/icon114.png" sizes="114x114">
    <link rel="apple-touch-icon" href="img/icon120.png" sizes="120x120">
    <link rel="apple-touch-icon" href="img/icon144.png" sizes="144x144">
    <link rel="apple-touch-icon" href="img/icon152.png" sizes="152x152">
    <!-- END Icons -->
    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <%-- <link rel="stylesheet" href="css/bootstrap.min.css">--%>
    <link href="../css/Bootstrap2.css" rel="stylesheet" />

    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="css/plugins.css">
    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="css/main.css">

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->
    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link href="css/themes/fancy.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/themes.css">
    <!-- END Stylesheets -->
    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <script src="../js/jquery-1.8.2.js"></script>
    <style type="text/css">
        .image-upload > input {
            display: none;
        }
        .headings {
            color: #fb3399;
        }
        .innerContent{
            color: #353535;
             font-size:14px;
        }
        article p {
             color: #353535;
             font-size:14px;
        }
    </style>
</head>
<body>
    <div id="page-container" class="sidebar-partial sidebar-visible-lg sidebar-no-animations">
        <HM:SideBar ID="SideBar" runat="server" />
        <!-- Main Container -->
        <div id="main-container">
            <!-- Header -->
            <HR:TopBar ID="TopBar" runat="server" />
            <!-- END Header -->
            <!-- Page content -->
            <div class="container">
                <div class="row">
                    <div id="page-content">
                        <div class="block">
                            <div class="row">
                                <section id="div_MutualFunds" style="display:none;">
                                    <div style="margin-left: 20px;">

                                        <!-- Story -->
                                        <article>

                                            <h3 class="headings" ><strong>Mutual Funds</strong></h3>
                                            <br />
                                            <div class="innerContent">
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
                                            </div>
                                        </article>
                                        <!-- END Story -->
                                    </div>
                                </section>

                                <section id="div_segregatedfunds" style="display:none;">
                                    <div style="margin-left: 20px;">

                                        <!-- Story -->
                                        <article>
                                            <h3 class="headings"><strong>Segregated Funds</strong></h3>
                                            <br />
                                            <div class="innerContent">
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
                                            </div>
                                        </article>
                                        <!-- END Story -->
                                    </div>
                                </section>

                                <section id="div_Stocks" style="display:none;">
                                    <div style="margin-left: 20px;">

                                        <!-- Story -->
                                        <article>
                                            <h3 class="headings"><strong>Stocks</strong></h3>
                                            <br />
                                            <div class="innerContent">
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
                                            </div>
                                        </article>
                                        <!-- END Story -->
                                    </div>
                                </section>

                                <section id="divBonds" style="display:none;">
                                    <div style="margin-left: 20px;">

                                        <!-- Story -->
                                        <article>
                                            <h3 class="headings"><strong>Bonds</strong></h3>
                                            <br />
                                            <div class="innerContent">
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
                                            </div>
                                        </article>
                                        <!-- END Story -->
                                    </div>
                                </section>

                                <section id="div_ETF" style="display:none;">
                                    <div style="margin-left: 20px;">

                                        <!-- Story -->
                                        <article>
                                            <h3 class="headings" ><strong>ETF’s (Exchange Traded Funds)</strong></h3>
                                            <br />
                                            <div class="innerContent">
                                                <p>
                                                    A security that tracks an index, a commodity or a basket of assets like an index fund, but trades like a stock on an exchange. ETFs experience price changes throughout the day as they are bought and sold. Because it trades like a stock, an ETF does not have its net asset value (NAV) calculated every day like a mutual fund does.<br />
                                                    By owning an ETF, you get the diversification of an index fund as well as the ability to sell short, buy on margin and purchase as little as one share. Another advantage is that the expense ratios for most ETFs are lower than those of the average mutual fund. When buying and selling ETFs, you have to pay the same commission to your broker that you'd pay on any regular order.

                                                </p>
                                            </div>
                                        </article>
                                        <!-- END Story -->
                                    </div>
                                </section>

                                <section id="div_GIC" style="display:none;">
                                    <div style="margin-left: 20px;">

                                        <!-- Story -->
                                        <article>
                                            <h3 class="headings"><strong>GIC or GIA</strong></h3>
                                            <br />
                                            <div class="innerContent">
                                                <p>
                                                    GIC stands for “Guaranteed Income Certificates” or “Guaranteed Investment Annuity”<br />
                                                    Both are similar in nature. Returns are guaranteed for a term selected. 1 yr to 5 yr terms are typical. The longer the term the higher the rate of return. GIC’s are offered by Banks, Credit Unions or Trust Company’s.
                            <br />
                                                    GIA on the other hand are offered by insurance company’s. It has some additional benefits of beneficiary status, ability to bypass the estate for probate. But it all comes with a slight cost and the rate of return is generally less than a GIC. It’s best advised you consult an investment and insurance advisor. 
                       
                                                </p>
                                            </div>
                                        </article>
                                        <!-- END Story -->
                                    </div>

                                </section>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/vendor/bootstrap.min.js"></script>

    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>
    
    <script src="../js/Querystring.js"></script>
    <script language="javascript" type="text/javascript">
        var _divId = "";
        var varSection = "";
        $(function () {
            varSection = '<%=Section %>';
    
            if (varSection == "MutualFund") {
                $('#div_MutualFunds').show();
                $('#MutualFunds-a').addClass("active");
            }
            if (varSection == "SegregatedFunds") {
                $('#div_segregatedfunds').show();
                $('#SegregatedFunds-a').addClass("active");
            }
            if (varSection == "Stocks") {
                $('#div_Stocks').show();
                $('#Stocks-a').addClass("active");
            }
            if (varSection == "Bonds") {
                $('#divBonds').show();
                $('#Bonds-a').addClass("active");
            }
            if (varSection == "ETF") {
                $('#div_ETF').show();
                $('#ETF-a').addClass("active");
            }
            if (varSection == "GIC") {
                $('#div_GIC').show();
                $('#GIC-a').addClass("active");
            }
        });

    
    </script>
</body>
</html>
