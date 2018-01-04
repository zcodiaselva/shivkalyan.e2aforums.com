<?php get_header(); ?>

<div class="wrapper section">
	
	<div class="section-inner">

		<div class="content">
													        
			<?php if (have_posts()) : while (have_posts()) : the_post(); ?>
			
				<div id="post-<?php the_ID(); ?>" <?php post_class('single post'); ?>>
						
					<div class="post-image">
		
						<?php echo wp_get_attachment_image( $post->ID, 'post-image' ); ?>
						
					</div>
					
					<div class="post-inner">
					
						<div class="post-header">
						
							<h2 class="post-title"><?php echo basename(get_attached_file( $post->ID )); ?></h2>
							
							<div class="post-meta">
						
								<p><?php _e('By','lovecraft'); ?> <?php the_author_posts_link(); ?></p>
								<p class="post-date"><?php _e('On','lovecraft'); ?> <a href="<?php the_permalink(); ?>"><?php the_date(get_option('date_format')); ?></a></p>
								<?php $imageArray = wp_get_attachment_image_src($post->ID, 'full', false); $url = $imageArray['0']; ?>
								<p><?php _e('Resolution:','lovecraft'); ?> <?php echo $imageArray['1'] . 'x' . $imageArray['2'] . ' px'; ?></p>
							
							</div> <!-- /post-meta -->
						
						</div> <!-- /post-header -->
						
						<?php if ( !empty(get_post(get_post_thumbnail_id())->post_excerpt) ) : ?>
															
							<div class="post-content">
							
								<p><?php echo get_post(get_post_thumbnail_id())->post_excerpt; ?></p>
								
							</div>
							
						<?php endif; ?>
						
					</div> <!-- /post-inner -->
					
					<?php comments_template( '', true ); ?>
																                        
			   	<?php endwhile; else: ?>
			
					<p><?php _e("We couldn't find any posts that matched your query. Please try again.", "lovecraft"); ?></p>
				
				<?php endif; ?>    
					
			</div> <!-- /post -->
		
		</div> <!-- /content -->
		
		<?php get_sidebar(); ?>
		
		<div class="clear"></div>
		
	</div> <!-- /section-inner -->

</div> <!-- /wrapper.section -->
		
<?php get_footer(); ?>