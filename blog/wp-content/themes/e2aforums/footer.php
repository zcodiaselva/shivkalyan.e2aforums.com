<?php
/**
 * The template for displaying the footer
 *
 * Contains the closing of the "site-content" div and all content after.
 *
 * @package WordPress
 * @subpackage Twenty_Fifteen
 * @since Twenty Fifteen 1.0
 */
?>

<div class="footer">
  <div class="container">
    <div class="row">
      <div class="col-md-3 col-sm-6 apps"> <a href="#"><img alt="" class="img-responsive" src="<?php bloginfo('template_directory');?>/images/footer_logo.png"></a>
        <ul class="playstore">
          <li class="appstore"><a href="#"><img alt="" class="img-responsive" src="http://www.e2aforums.com/blog/wp-content/uploads/2016/02/appstore.png"></a></li>
          <li class="googleplay"><a href="#"><img alt="" class="img-responsive" src="http://www.e2aforums.com/blog/wp-content/uploads/2016/02/googleplay.png"></a></li>
        </ul>
      </div>
      <div class="col-md-3 col-sm-6 categories">
        <h3>Quick Links</h3>
        <ul class="form_categories">
          <li><a href="http://e2aforums.com/">HOME</a></li>
          <li><a href="http://e2aforums.com/Register.aspx">SIGN UP</a></li>
          <li><a href="http://e2aforums.com/AboutUs.aspx">ABOUT US</a></li>
          <li><a href="http://e2aforums.com/WhyUs.aspx">WHY E2A FORUMS</a></li>
          <li><a href="http://e2aforums.com/Pricing.aspx">PRICING</a></li>
          <li><a href="http://e2aforums.com/blog">BLOG</a></li>
          <li><a href="http://e2aforums.com/Support.aspx">SUPPORT</a></li>
        </ul>
      </div>
      <div class="col-md-3 col-sm-6 contacts">
        <h3>Contact Us</h3>
        <ul class="information">
          <li><a href="tel:+1-888-280-7780"><b>Toll Free:</b> +1-888-280-7780</a></li>
          <li><a href="mailto:info@e2aforums.com" ><b>Email:</b> info@e2aforums.com</a></li>
          <li><a href="mailto:support@e2aforums.com" ><b>Support:</b> support@e2aforums.com</a></li>
        </ul>
        <ul class="social_icons">
          <li><a href="https://twitter.com/e2aforums"><img src="<?php bloginfo('template_directory');?>/images/twitter.png" alt=""></a></li>
          <li><a href="https://www.facebook.com/join.e2aforums"><img src="<?php bloginfo('template_directory');?>/images/fb.png" alt=""></a></li>
          <li><a href="https://plus.google.com/115450398151198234886/about"><img src="<?php bloginfo('template_directory');?>/images/Google-Plus-icon.png" alt=""></a></li>
          <li><a href="https://www.pinterest.com/e2aforums/"><img src="<?php bloginfo('template_directory');?>/images/pinterest.png" alt=""></a></li>
        </ul>
      </div>
      <div class="col-md-3 col-sm-6 map">
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2892.6035270430884!2d-79.74581138412508!3d43.46898229918239!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x882b67f6b217108b%3A0xdf1b29153e3641ee!2s507+Sixteen+Mile+Dr%2C+Oakville%2C+ON+L6M+0P6%2C+Canada!5e1!3m2!1sen!2sin!4v1462975710585" width="250" height="160" frameborder="0" style="border:0" allowfullscreen></iframe>
      </div>
    </div>
    <div class="copyright">
      <div class="row">
        <div class="col-sm-6"> 
          <!--<ul>
            <li><a href="#">Privacy  Policy</a></li>
            <li><a href="#">Terms of Service</a></li>
          </ul>--> 
        </div>
        <div class="col-sm-6">
          <p>2014-15 &copy; e2aforums | <a href="/PrivacyPolicy.aspx">Privacy Policy</a></p>
        </div>
      </div>
    </div>
  </div>
</div>
</div>
<?php
if ( is_home() ) {
    // This is the blog posts index
    get_sidebar( 'blog' );
echo "<style></style>";
} else {
    // This is not the blog posts index
    get_sidebar();
}
?>
<?php wp_footer(); ?>
</body></html>