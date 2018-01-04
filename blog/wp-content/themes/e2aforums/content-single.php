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

<?php  the_post_thumbnail('my_thumbnail', array( 'class'	=> "img-responsive")); ?>
<div class="post-inner-content">
<header class="entry-header page-header">
<h1 class="entry-title">
<?php the_title(); ?>
</h1>
<div class="entry-meta">
<span class="posted-on">
<i class="fa fa-calendar"></i> 
<time class="entry-date published">
<?php echo the_time('j');?> <?php echo the_time('M');?>
</time>
<i class="fa fa-eye"></i> Views: <?php echo getCrunchifyPostViews(get_the_ID()); ?>
</span>

<span class="byline"> <i class="fa fa-user"></i> <span class="author vcard"><a class="url fn n" href="author/gimmer/index.html"> <?php the_author(); ?></a></span></span>

<span class="comments-link">
<i class="fa fa-comment-o"></i>
<a href="#">
<span class="dsq-postid" rel="741 http://bootstrapbay.com/blog/?p=741">Comments: <?php echo comments_number( '0', '1', '%' ); ?></span></a>
</span>


</div>
</header>
</div>
<div class="entry-content">
<?php the_content(); ?>
</div>
</div>
</article><!-- #post-## -->
