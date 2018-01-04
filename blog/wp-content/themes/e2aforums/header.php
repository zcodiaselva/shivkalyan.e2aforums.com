<?php
/**
 * The template for displaying the header
 *
 * Displays all of the head element and everything up until the "site-content" div.
 *
 * @package WordPress
 * @subpackage Twenty_Fifteen
 * @since Twenty Fifteen 1.0
 */
?>
<!DOCTYPE html>
<html <?php language_attributes(); ?> class="no-js">
<head>
<meta charset="<?php bloginfo( 'charset' ); ?>">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
<link rel="profile" href="http://gmpg.org/xfn/11">
<link rel="pingback" href="<?php bloginfo( 'pingback_url' ); ?>">
<!--[if lt IE 9]>
	<script src="<?php echo esc_url( get_template_directory_uri() ); ?>/js/html5.js"></script>
<![endif]-->

<link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800italic,800' rel='stylesheet' type='text/css'>
<link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
<link type="text/css" rel="stylesheet" href="<?php bloginfo('template_directory');?>/typography/typography.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
<link type="text/css" rel="stylesheet" href="<?php bloginfo('template_directory');?>/style.css">
<link rel="stylesheet" href="http://e2aforums.com/ashi/css/style.css">
<!--[if lt IE 9]>
<script type="text/javascript" src="<?php bloginfo('template_directory');?>/js/html5shiv.js"></script>
<script type="text/javascript" src="<?php bloginfo('template_directory');?>/js/respond.min.js"></script>
<![endif]-->
<?php wp_head(); ?>
</head>

<body <?php body_class(); ?>>
<div class="main_wrapper">
<header class="main_header">
  <div class="container">
    <div class="header_inner">
      <div class="logo"> <a href="<?php echo get_site_url(); ?>"><img src="<?php echo( get_header_image() ); ?>" title="e2a Forums" alt="e2a Forums"></a> </div>
      <div class="right_part">
        <nav class="navbar navbar-default" role="navigation">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#main-navbar-collapse"> <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>
        </div>
        <?php
wp_nav_menu( array(
'menu' => '',
'container' => 'div',
'container_class' => 'navbar-collapse collapse',
'container_id' => 'main-navbar-collapse',
'menu_class' => 'nav navbar-nav',
'menu_id' => '',
'echo' => true,
'fallback_cb' => 'wp_page_menu',
'before' => '',
'after' => '',
'link_before' => '',
'link_after' => '',
'items_wrap'       => '<ul id="%1$s" class="nav navbar-nav">%3$s</ul>',
'depth' => 0,
'walker' => '',
'theme_location' => 'header_menu'
) );
?>
      </div>
      </nav>
      <div class="clearfix"></div>
    </div>
  </div>
</header>
<div id="content" class="site-content">
