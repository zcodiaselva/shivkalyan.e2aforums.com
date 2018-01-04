<?php
/**
 * The default template for displaying content
 *
 * Used for both single and index/archive/search.
 *
 * @package WordPress
 * @subpackage Twenty_Fifteen
 * @since Twenty Fifteen 1.0
 */
?>
<article id="post-<?php the_ID(); ?>" class="type-post hentry">
<div class="blog-item-wrap">
<a href="<?php the_permalink();?>">
<?php  the_post_thumbnail('my_thumbnail', array( 'class'	=> "img-responsive single-featured wp-post-image")); ?>
</a>
<div class="post-inner-content">
<header class="entry-header page-header">
<h1 class="entry-title">
<a href="<?php the_permalink();?>"><?php the_title(); ?></a>
</h1>
<div class="entry-meta">

<ul>
<li><i class="fa fa-calendar"></i> <time class="entry-date published"><?php echo the_time('j');?> <?php echo the_time('M');?></time></li>
<li><i class="fa fa-eye"></i> Views: <?php if(function_exists('the_views')) { the_views(); } ?></li>
<li><i class="fa fa-user"></i> <a href="<?php echo get_author_posts_url( get_the_author_meta( 'ID' ) ); ?>"> <?php the_author(); ?></a></li>
<li><i class="fa fa-comment-o"></i> Comments: <?php echo comments_number( '0', '1', '%' ); ?></li>
</ul>








</div>
</header>
</div>
<div class="entry-content">
<?php echo wp_trim_words( get_the_content(), 100, ' [...]' ); ?>

<p class="clearfix"><a class="btn btn-primary read-more" href="<?php the_permalink();?>">Read More</a></p>
</div>
</div>
</article><!-- #post-## -->
