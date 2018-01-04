<?php
/**
 * The main template file
 *
 * This is the most generic template file in a WordPress theme
 * and one of the two required files for a theme (the other being style.css).
 * It is used to display a page when nothing more specific matches a query.
 * e.g., it puts together the home page when no home.php file exists.
 *
 * Learn more: {@link https://codex.wordpress.org/Template_Hierarchy}
 *
 * @package WordPress
 * @subpackage Twenty_Fifteen
 * @since Twenty Fifteen 1.0
 */

get_header(); ?>

<div class="mountainBg"><img src="http://www.e2aforums.com/blog/wp-content/uploads/2015/12/blog-bg.jpg" alt="Blog Bg"></div>
<div class="container main-content-area">
  <div class="blog-content">
    <div class="row">
      <section class="main-content-inner col-sm-12 col-md-8 pull-left">
        <?php if ( have_posts() ) : ?>
        <?php
			// Start the loop.
			while ( have_posts() ) : the_post();
				get_template_part( 'content', get_post_format() );
			// End the loop.
			endwhile;

			// Previous/next page navigation.
			the_posts_pagination( array(
				'prev_text'          => __( 'Previous page', 'twentyfifteen' ),
				'next_text'          => __( 'Next page', 'twentyfifteen' ),
				'before_page_number' => '<span class="meta-nav screen-reader-text">' . __( 'Page', 'twentyfifteen' ) . ' </span>',
			) );

		// If no content, include the "No posts found" template.
		else :
			get_template_part( 'content', 'none' );

		endif;
		?>
      </section>
      <aside id="secondary" class="widget-area col-sm-12 col-md-4" role="complementary">
        <div class="well">
          <?php get_sidebar(); ?>
        </div>
      </aside>
    </div>
  </div>
</div>
<!-- .content-area -->

<?php get_footer(); ?>
