<?php
/**
 * Prepares Fancier Author Box tabs for display
 *
 * @link  https://wordpress.org/plugins/fancier-author-box/
 * @since 1.0
 *
 * @package    Fancier_Author_Box
 * @subpackage Fancier_Author_Box/includes
 */


/**
 * Constructs bio tab.
 *
 * @since 1.0
 *
 * @param  string  $context  Above or below posts.
 * @param  integer $authorid User ID.
 * @return string  Bio tab HTML.
 */
function ts_fab_show_bio( $context = '', $authorid = '' ) {
	if ( $authorid == '' ) {
		global $authordata;
		$author = $authordata;
	} else {
		$author = get_userdata( $authorid );
	}
	
	// Create Fancier Author Box output
	$ts_fab_bio = '
	<div class="ts-fab-tab" id="ts-fab-bio-' . $context . '">
		<div class="ts-fab-avatar">';
			$ts_fab_bio .= get_avatar( $author->ID, 80 );
			$ts_fab_bio .= '<div class="ts-fab-social-links">';
			
				// Twitter
				if ( get_user_meta( $author->ID, 'ts_fab_twitter', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_twitter', true) ) ) {
						$ts_fab_twitter_url = get_user_meta( $author->ID, 'ts_fab_twitter', true );
					} else {
						$ts_fab_twitter_url = 'http://twitter.com/' . get_user_meta( $author->ID, 'ts_fab_twitter', true );
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_twitter_url ) . '" title="Twitter" rel="nofollow"><img src="' . plugins_url( 'images/twitter.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Twitter profile', 'ts-fab' ) . '" /></a>';
				}
				
				// Facebook
				if ( get_user_meta( $author->ID, 'ts_fab_facebook', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_facebook', true ) ) ) {
						$ts_fab_facebook_url = get_user_meta( $author->ID, 'ts_fab_facebook', true );
					} else {
						$ts_fab_facebook_url = 'http://facebook.com/' . get_user_meta( $author->ID, 'ts_fab_facebook', true );
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_facebook_url ) . '" title="Facebook" rel="nofollow"><img src="' . plugins_url( 'images/facebook.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Facebook profile', 'ts-fab' ) . '" /></a>';
				}
				
				// Google+
				if ( get_user_meta( $author->ID, 'ts_fab_googleplus', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_googleplus', true ) ) ) {
						$ts_fab_googleplus_url = get_user_meta( $author->ID, 'ts_fab_googleplus', true ) . '?rel=author';
					} else {
						$ts_fab_googleplus_url = 'http://plus.google.com/' . get_user_meta( $author->ID, 'ts_fab_googleplus', true ) . '?rel=author';
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_googleplus_url ) . '" title="Google+"><img src="' . plugins_url( 'images/googleplus.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Google+ profile', 'ts-fab' ) . '" /></a>';
				}
				
				// LinkedIn
				if ( get_user_meta( $author->ID, 'ts_fab_linkedin', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_linkedin', true ) ) ) {
						$ts_fab_linkedin_url = get_user_meta( $author->ID, 'ts_fab_linkedin', true );
					} else {
						$ts_fab_linkedin_url = 'http://www.linkedin.com/in/' . get_user_meta( $author->ID, 'ts_fab_linkedin', true );
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_linkedin_url ) . '" title="LinkedIn" rel="nofollow"><img src="' . plugins_url( 'images/linkedin.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My LinkedIn profile', 'ts-fab' ) . '" /></a>';
				}

				// Instagram
				if ( get_user_meta( $author->ID, 'ts_fab_instagram', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_instagram', true ) ) ) {
						$ts_fab_instagram_url = get_user_meta( $author->ID, 'ts_fab_instagram', true );
					} else {
						$ts_fab_instagram_url = 'http://instagram.com/' . get_user_meta( $author->ID, 'ts_fab_instagram', true );
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_instagram_url ) . '" title="Instagram" rel="nofollow"><img src="' . plugins_url( 'images/instagram.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Instagram profile', 'ts-fab' ) . '" /></a>';
				}

				// Flickr
				if ( get_user_meta( $author->ID, 'ts_fab_flickr', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_flickr', true ) ) ) {
						$ts_fab_flickr_url = get_user_meta( $author->ID, 'ts_fab_flickr', true );
					} else {
						$ts_fab_flickr_url = 'http://www.flickr.com/photos/' . get_user_meta( $author->ID, 'ts_fab_flickr', true );
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_flickr_url ) . '" title="Flickr" rel="nofollow"><img src="' . plugins_url( 'images/flickr.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Flickr profile', 'ts-fab' ) . '" /></a>';
				}

				// Pinterest
				if ( get_user_meta( $author->ID, 'ts_fab_pinterest', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_pinterest', true ) ) ) {
						$ts_fab_pinterest_url = get_user_meta( $author->ID, 'ts_fab_pinterest', true );
					} else {
						$ts_fab_pinterest_url = 'http://pinterest.com/' . get_user_meta( $author->ID, 'ts_fab_pinterest', true );
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_pinterest_url ) . '" title="Pinterest" rel="nofollow"><img src="' . plugins_url( 'images/pinterest.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Pinterest profile', 'ts-fab' ) . '" /></a>';
				}

				// Tumblr
				if ( get_user_meta( $author->ID, 'ts_fab_tumblr', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_tumblr', true ) ) ) {
						$ts_fab_tumblr_url = get_user_meta( $author->ID, 'ts_fab_tumblr', true );
					} else {
						$ts_fab_tumblr_url = 'http://' . get_user_meta( $author->ID, 'ts_fab_tumblr', true ) . '.tumblr.com';
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_tumblr_url ) . '" title="Tumblr" rel="nofollow"><img src="' . plugins_url( 'images/tumblr.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Tumblr blog', 'ts-fab' ) . '" /></a>';
				}

				// YouTube
				if ( get_user_meta( $author->ID, 'ts_fab_youtube', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_youtube', true ) ) ) {
						$ts_fab_youtube_url = get_user_meta( $author->ID, 'ts_fab_youtube', true );
					} else {
						$ts_fab_youtube_url = 'http://www.youtube.com/user/' . get_user_meta( $author->ID, 'ts_fab_youtube', true );
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_youtube_url ) . '" title="YouTube" rel="nofollow"><img src="' . plugins_url( 'images/youtube.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My YouTube channel', 'ts-fab' ) . '" /></a>';
				}

				// Vimeo
				if ( get_user_meta( $author->ID, 'ts_fab_vimeo', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_vimeo', true ) ) ) {
						$ts_fab_vimeo_url = get_user_meta( $author->ID, 'ts_fab_vimeo', true );
					} else {
						$ts_fab_vimeo_url = 'http://vimeo.com/' . get_user_meta( $author->ID, 'ts_fab_vimeo', true );
					}
					$ts_fab_bio .= '<a href="' . esc_attr( $ts_fab_vimeo_url ) . '" title="Vimeo" rel="nofollow"><img src="' . plugins_url( 'images/vimeo.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Vimeo channel', 'ts-fab' ) . '" /></a>';
				}
			
			$ts_fab_bio .= '</div>
		</div>
		
		<div class="ts-fab-text">
			<div class="ts-fab-header">';
			
			$ts_fab_follow_author_link = apply_filters( 'ts_fab_follow_author_link', 'rel="nofollow"' );

			if( $author->user_url ) {
				$ts_fab_bio .= '<h4><a href="' . $author->user_url . '" ' . $ts_fab_follow_author_link . '>' . $author->display_name . '</a></h4>';
			} else {
				$ts_fab_bio .= '<h4>' . $author->display_name . '</h4>';
			}
			
			if( get_user_meta( $author->ID, 'ts_fab_position', true) ) {
				$ts_fab_bio .= '<div class="ts-fab-description"><span>' . get_user_meta( $author->ID, 'ts_fab_position', true) . '</span>';
				
				if( get_user_meta( $author->ID, 'ts_fab_company', true) ) {
					if( get_user_meta( $author->ID, 'ts_fab_company_url', true) ) {
						$ts_fab_bio .= ' ' . __( 'at', 'ts-fab' ) . ' <a href="' . esc_url( get_user_meta( $author->ID, 'ts_fab_company_url', true) ) . '" rel="nofollow">';
							$ts_fab_bio .= '<span>' . get_user_meta( $author->ID, 'ts_fab_company', true) . '</span>';
						$ts_fab_bio .= '</a>';
					} else {
						$ts_fab_bio .= ' ' . __( 'at', 'ts-fab' ) . ' <span>' . get_user_meta( $author->ID, 'ts_fab_company', true) . '</span>';
					}
				}
				
				$ts_fab_bio .= '</div>';
			}
			
			$ts_fab_bio .= '</div><!-- /.ts-fab-header -->
			<div class="ts-fab-content">' . $author->user_description . '</div>
		</div>
	</div>';

	return $ts_fab_bio;
}


/**
 * Constructs latest posts tab.
 *
 * @since 1.0
 *
 * @param  string  $context  Above or below posts.
 * @param  integer $authorid User ID.
 * @return string  Bio tab HTML.
 */
function ts_fab_show_latest_posts( $context = '', $authorid = '' ) {
	// Grab settings
	$ts_fab_settings = ts_fab_get_display_settings();

	if ( $authorid == '' ) {
		global $authordata;
		$author = $authordata;
	} else {
		$author = get_userdata( $authorid );
	}
	
	// Hook for custom post types selection
	$post_types = apply_filters( 'ts_fab_show_latest_posts_type_hook', array( 'post' ) );

	$latest_by_author = new WP_Query( array(
		'posts_per_page' => $ts_fab_settings['latest_posts_count'],
		'author'         => $author->ID,
		'post_type'      => $post_types,
	) );

	// Create Fancier Author Box output
	$ts_fab_latest = '
	<div class="ts-fab-tab" id="ts-fab-latest-posts-' . $context . '">
		<div class="ts-fab-avatar">';
			$ts_fab_latest .= get_avatar( $author->ID, 80 );
			$ts_fab_latest .= '<div class="ts-fab-social-links">';
			
				// Twitter
				if ( get_user_meta( $author->ID, 'ts_fab_twitter', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_twitter', true) ) ) {
						$ts_fab_twitter_url = get_user_meta( $author->ID, 'ts_fab_twitter', true );
					} else {
						$ts_fab_twitter_url = 'http://twitter.com/' . get_user_meta( $author->ID, 'ts_fab_twitter', true );
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_twitter_url ) . '" title="Twitter" rel="nofollow"><img src="' . plugins_url( 'images/twitter.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Twitter profile', 'ts-fab' ) . '" /></a>';
				}
				
				// Facebook
				if ( get_user_meta( $author->ID, 'ts_fab_facebook', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_facebook', true ) ) ) {
						$ts_fab_facebook_url = get_user_meta( $author->ID, 'ts_fab_facebook', true );
					} else {
						$ts_fab_facebook_url = 'http://facebook.com/' . get_user_meta( $author->ID, 'ts_fab_facebook', true );
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_facebook_url ) . '" title="Facebook" rel="nofollow"><img src="' . plugins_url( 'images/facebook.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Facebook profile', 'ts-fab' ) . '" /></a>';
				}
				
				// Google+
				if ( get_user_meta( $author->ID, 'ts_fab_googleplus', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_googleplus', true ) ) ) {
						$ts_fab_googleplus_url = get_user_meta( $author->ID, 'ts_fab_googleplus', true ) . '?rel=author';
					} else {
						$ts_fab_googleplus_url = 'http://plus.google.com/' . get_user_meta( $author->ID, 'ts_fab_googleplus', true ) . '?rel=author';
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_googleplus_url ) . '" title="Google+" rel="nofollow"><img src="' . plugins_url( 'images/googleplus.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Google+ profile', 'ts-fab' ) . '" /></a>';
				}
				
				// LinkedIn
				if ( get_user_meta( $author->ID, 'ts_fab_linkedin', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_linkedin', true ) ) ) {
						$ts_fab_linkedin_url = get_user_meta( $author->ID, 'ts_fab_linkedin', true );
					} else {
						$ts_fab_linkedin_url = 'http://www.linkedin.com/in/' . get_user_meta( $author->ID, 'ts_fab_linkedin', true );
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_linkedin_url ) . '" title="LinkedIn" rel="nofollow"><img src="' . plugins_url( 'images/linkedin.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My LinkedIn profile', 'ts-fab' ) . '" /></a>';
				}

				// Instagram
				if ( get_user_meta( $author->ID, 'ts_fab_instagram', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_instagram', true ) ) ) {
						$ts_fab_instagram_url = get_user_meta( $author->ID, 'ts_fab_instagram', true );
					} else {
						$ts_fab_instagram_url = 'http://instagram.com/' . get_user_meta( $author->ID, 'ts_fab_instagram', true );
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_instagram_url ) . '" title="Instagram" rel="nofollow"><img src="' . plugins_url( 'images/instagram.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Instagram profile', 'ts-fab' ) . '" /></a>';
				}

				// Flickr
				if ( get_user_meta( $author->ID, 'ts_fab_flickr', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_flickr', true ) ) ) {
						$ts_fab_flickr_url = get_user_meta( $author->ID, 'ts_fab_flickr', true );
					} else {
						$ts_fab_flickr_url = 'http://www.flickr.com/photos/' . get_user_meta( $author->ID, 'ts_fab_flickr', true );
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_flickr_url ) . '" title="Flickr" rel="nofollow"><img src="' . plugins_url( 'images/flickr.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Flickr profile', 'ts-fab' ) . '" /></a>';
				}

				// Pinterest
				if ( get_user_meta( $author->ID, 'ts_fab_pinterest', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_pinterest', true ) ) ) {
						$ts_fab_pinterest_url = get_user_meta( $author->ID, 'ts_fab_pinterest', true );
					} else {
						$ts_fab_pinterest_url = 'http://pinterest.com/' . get_user_meta( $author->ID, 'ts_fab_pinterest', true );
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_pinterest_url ) . '" title="Pinterest" rel="nofollow"><img src="' . plugins_url( 'images/pinterest.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Pinterest profile', 'ts-fab' ) . '" /></a>';
				}

				// Tumblr
				if ( get_user_meta( $author->ID, 'ts_fab_tumblr', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_tumblr', true ) ) ) {
						$ts_fab_tumblr_url = get_user_meta( $author->ID, 'ts_fab_tumblr', true );
					} else {
						$ts_fab_tumblr_url = 'http://' . get_user_meta( $author->ID, 'ts_fab_tumblr', true ) . '.tumblr.com';
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_tumblr_url ) . '" title="Tumblr" rel="nofollow"><img src="' . plugins_url( 'images/tumblr.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Tumblr blog', 'ts-fab' ) . '" /></a>';
				}

				// YouTube
				if ( get_user_meta( $author->ID, 'ts_fab_youtube', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_youtube', true ) ) ) {
						$ts_fab_youtube_url = get_user_meta( $author->ID, 'ts_fab_youtube', true );
					} else {
						$ts_fab_youtube_url = 'http://www.youtube.com/user/' . get_user_meta( $author->ID, 'ts_fab_youtube', true );
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_youtube_url ) . '" title="YouTube" rel="nofollow"><img src="' . plugins_url( 'images/youtube.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My YouTube channel', 'ts-fab' ) . '" /></a>';
				}

				// Vimeo
				if ( get_user_meta( $author->ID, 'ts_fab_vimeo', true ) ) {
					if ( ts_fab_is_url( get_user_meta( $author->ID, 'ts_fab_vimeo', true ) ) ) {
						$ts_fab_vimeo_url = get_user_meta( $author->ID, 'ts_fab_vimeo', true );
					} else {
						$ts_fab_vimeo_url = 'http://vimeo.com/' . get_user_meta( $author->ID, 'ts_fab_vimeo', true );
					}
					$ts_fab_latest .= '<a href="' . esc_attr( $ts_fab_vimeo_url ) . '" title="Vimeo" rel="nofollow"><img src="' . plugins_url( 'images/vimeo.png', dirname(__FILE__) ) . '" width="24" height="24" alt="' . __( 'My Vimeo channel', 'ts-fab' ) . '" /></a>';
				}
			
			$ts_fab_latest .= '</div>
		</div>
		<div class="ts-fab-text">
			<div class="ts-fab-header">
				<h4>' . __( 'Latest posts by ', 'ts-fab' ) . $author->display_name . ' <span class="latest-see-all">(<a href="' . get_author_posts_url( $author->ID ) . '" rel="nofollow">' . __( 'see all', 'ts-fab' ) . '</a>)</span></h4>
			</div>
			<ul class="ts-fab-latest">';
		
			while ( $latest_by_author->have_posts() ) : $latest_by_author->the_post();
				global $post;
				$ts_fab_latest .= '
				<li>
					<a href="' . get_permalink() . '">' . get_the_title() . '</a><span> - ' .  
					date_i18n( get_option( 'date_format' ), get_the_time( 'U' ) ) . '</span> 
				</li>';
			endwhile;
			wp_reset_postdata();
	
		$ts_fab_latest .= '
		</ul></div>
	</div>';

	return $ts_fab_latest;
}


/**
 * Constructs Fancier Author Box tab.
 *
 * Used as helper function, to generate Fancier Author Box before or after posts.
 * 
 * @since 1.0
 *
 * @param  string  $context   Above or below posts.
 * @param  integer $authorid  User ID.
 * @param  array   $show_tabs Array of required tabs.
 * @return string  Bio tab HTML.
 */
function ts_fab_construct_fab( 
	$context = '',
	$authorid = '',
	$show_tabs = array(
		'bio',
		'latest_posts'
	)
	) {

	if( $authorid == '' ) {
		global $authordata;
		$author = $authordata;
	} else {
		$author = get_userdata( $authorid );
	}

	$ts_fab = '<div id="ts-fab-' . $context . '" class="ts-fab-wrapper">';

		// Construct tabs list
		$ts_fab .= '<span class="screen-reader-text">' . __( 'The following two tabs change content below.', 'ts-fab' ) . '</span>';
		$ts_fab .= '<ul class="ts-fab-list">';

			$ts_fab .= '<li class="ts-fab-bio-link"><a href="#ts-fab-bio-' . $context . '">' . __( 'Bio', 'ts-fab' ) . '</a></li>';

			$ts_fab .= '<li class="ts-fab-latest-posts-link"><a href="#ts-fab-latest-posts-' . $context . '">' . __( 'Latest Posts', 'ts-fab' ) . '</a></li>';

		$ts_fab .= '</ul>';

		// Construct individual tabs
		$ts_fab .= '<div class="ts-fab-tabs">';

			$ts_fab .= ts_fab_show_bio( $context, $author->ID );
			$ts_fab .= ts_fab_show_latest_posts( $context, $author->ID );

		$ts_fab .= '
		</div>
	</div>';

	return $ts_fab;
}