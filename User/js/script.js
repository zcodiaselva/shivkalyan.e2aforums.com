	var url;
	var workerPage;
	var oldBrowser = true;
	var oldBrowser = (function(){
		var undef,
			v = 3,
			div = document.createElement('div'),
			all = div.getElementsByTagName('i');
		while (
			div.innerHTML = '<!--[if gt IE ' + (++v) + ']><i></i><![endif]-->',
			all[0]
		);
		if (v>= 5 && v <= 8) {
			return true;
		}
		else {
			return false;
		}
	}());

	$(document).ready(function () {

	    if (oldBrowser) {
	    }
	    else {
	        //Saves url for specific site actions
	        url = window.location.href;
	        var s = "workerindex";
	        //Tests wheher workerindex or index
	        url = url.substr(url.length - 10);


	        //Toggle register and login on clicks
	        /*
	        $("#loginPick").click(function () {
	        $("#midtableLogin").toggle(0);
	        $("#midtableRegister").toggle(0);
	                        

	        });
	        $("#registerPick").click(function () {
	        $("#midtableLogin").toggle(0);
	        $("#midtableRegister").toggle(0);
	        });
	        */

	        //Send iPhone (etc.) users to mobile app. Ideally, this should not be asked every time they enter the site
	        if ((navigator.userAgent.match(/iPhone/i)) || (navigator.userAgent.match(/iPad/i)) || (navigator.userAgent.match(/iPod/i))) {
	            var goToApp = window.confirm("All website functionality is available through the iPhone app. Would you like to download that instead?");
	            if (goToApp) {
	                window.location.href = "https://itunes.apple.com/us/app/apple-store/id375380948?mt=8";
	            }
	        }


	        //If Javascript enabled, perform AJAX updates
	        $(".jsEnabled").show();
	        $(".jsDisabled").hide();
	        $(".quicknav").show();

	        //Hides the advice field initially
	        OnBlurInput();

	        //Hides worker cells in profile tab (this is to avoid issues with JavaScript being disabled)
	        if (url == "ofile.html") {
	            repToHide();
	        }

	        //For profile tab, hide/remove whether worker selected
	        $("#workerSelect").click(function () {
	            $(".workerField").toggle();
	        });

	        //Copies fields in Profile page
	        $("#copyFields").click(function () {
	            if ($("#copyFields").is(':checked')) {
	                $("#ccname").val($("#txtFullName").val());
	                //BillingAddress
	                if ($("#address1").val() != '')
	                    $('#BillingAddress').val($("#address1").val());

	                if ($("#address2").val() != '')
	                    $('#BillingAddress').val($('#BillingAddress').val() + ', ' + $("#address2").val());

	                if ($("#address3").val() != '')
	                    $('#BillingAddress').val($('#BillingAddress').val() + ', ' + $("#address3").val());
                    	                
	                $("#paypalEmail").val($("#txtEmail").val());
	            }
	        });

	        //Potential method to insert social tags, but causing errors
	        //var f1 = '<div id="fb-root"></div><scrip' + 't + type="text/javascript">(function(d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return;  js = d.createElement(s); js.id = id;  js.src = "http://connect.facebook.net/en_US/all.js#xfbml=1&appId=341002669260762";  fjs.parentNode.insertBefore(js, fjs);  }   (document, "script", "facebook-jssdk"));  }  </script>';
	        //var f2 = '<div class="fb-like" data-href="http://www.instynt.com" data-layout="button" data-action="like" data-show-faces="true" data-share="true" data-width="97" style="bottom:4px;"></div>';
	        //var gp = '<div id="googleplus"><div class="g-plusone" data-size="small" data-annotation="none" data-href="http://www.instynt.com/"><g:plusone></g:plusone></div> <script type="text/javascript"> (function() {  var po = document.createElement("script"); po.type = "text/javascript"; po.async = true;  po.src = "../../apis.google.com/js/platform.js";  var s = document.getElementsByTagName("script")[0]; s.parentNode.insertBefore(po, s);  })();  } </script>';
	        //var tw = '<scrip' + 't + type="text/javascript">!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src="http://platform.twitter.com/widgets.js";fjs.parentNode.insertBefore(js,fjs);}}(document,"script","twitter-wjs"); + "</" + "scrip" + "t>"';
	        //var li = '<scrip" + "t" + "src="../../platform.linkedin.com/in.js" type="text/javascript">lang: en_US</script>  <script type="IN/Share" data-url="http://www.instynt.com"></script>';
	        //document.getElementById('facebook1').innerHTML = stripAndExecuteScript(f1);
	        //document.getElementById('facebook2').innerHTML = stripAndExecuteScript(f2);
	        //document.getElementById('googleplus').innerHTML = stripAndExecuteScript(gp);
	        //document.getElementById('twitter').innerHTML = stripAndExecuteScript(tw);
	        //document.getElementById('linkedin').innerHTML = stripAndExecuteScript(li);
	    }
	});

	//Respond to selecting input field
	function OnFocusInput(field_name) {
		$("#guidance1").show();
		$("#guidance2").show();
		var guideText;
		switch(field_name)
		{
		case "reg-email":
			guideText = "We promise to never spam you, but we will send you a confirmation e-mail";
			break;
		case "reg-pw1":
			guideText = "To meet minimum security for your data and info, we require 6-12 characters and at least one number and one character";
			break;
		case "reg-pw2":
			guideText = "Passwords are case sensitive and must match exactly";
			break;
		case "log-email":
			guideText = "Please remember the e-mail that you signed up with, or click the Forgot password or e-Mail link below";
			break;
		case "log-pw":
			guideText = "To help you remember, our requirements were: 6-12 characters and at least one number and one character";
			break;
		case "legalBox":
			guideText = "Key notes: (1) We integrate payments and navigation in our app, which requires some tracking of you. (2) Customer-worker relationships are governed directly and you waive any of Instynt's liability by using the app.";
			break;
		case "newsletterBox":
			guideText = "We hope our newsletter is informative -- this will be the key source to receive promotional discounts. You can easily unsubscribe at any time.";
			break;
		case "rememberPw":
				guideText = "Please be careful about checking to Remember Password if you are using a public/shared computer.";
			break;
		default:
			break;
		}
		document.getElementById("guidance1").innerHTML=guideText;
		document.getElementById("guidance2").innerHTML=guideText;
	}
	//Remove guidance when deselecting
	function OnBlurInput() {
		$("#guidance1").hide();
		$("#guidance2").hide();
	}

	//Save section of url for reference for slider image
	var pathName = window.location.href;
	var url = pathName.slice(-3);


	//This is my hack to keep the user's position on the page when the slider images switch
	function keepLocation(oldOffset) {
	  if (window.pageYOffset!= null){
		st=oldOffset;
	  }
	  if (document.body.scrollWidth!= null){
		st=oldOffset;
	  }
	  setTimeout('window.scrollTo(0,st)',0);
	}

	function repToHide() {
		document.body.innerHTML = document.body.innerHTML.replace(/border-width="00"/g, 'hidden');
	}

	//For generating script on HTML -- not presently used
	function stripAndExecuteScript(text) {
	    var scripts = '';
	    var cleaned = text.replace(/<script[^>]*>([\s\S]*?)<\/script>/gi, function(){
	        scripts += arguments[1] + '\n';
	        return '';
	    });

	    if (window.execScript){
	        window.execScript(scripts);
	    } else {
	        var head = document.getElementsByTagName('head')[0];
	        var scriptElement = document.createElement('script');
	        scriptElement.setAttribute('type', 'text/javascript');
	        scriptElement.innerText = scripts;
	        head.appendChild(scriptElement);
	        head.removeChild(scriptElement);
	    }
	    return cleaned;
	};

	//Slider-relevant coding
    function changeSlide(){
        if ( $( ".slide1" ).is( ".active" ) ) {
            $('.slide2').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
			$('.match-job').addClass('active-job');
			$('.describe-job').removeClass('active-job');
			$('.pay-job').removeClass('active-job');
            $('#text-overlay').html("We'll be there in an Instynt");
            $('.workerpage #text-overlay').html("Take only jobs you want");
            $('.dot').css('background','#000').css('color','#fff');
            $('.dotsecond').css('background','#0087cf').css('color','#fff');
            $('#bigphone').attr('src','images/phone-customer2.png');
            $('.workerpage #bigphone').attr('src','images/phone-worker2.png');
            $('.slide1').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');
        }else
        if ( $( ".slide2" ).is( ".active" ) ) {
            $('.slide3').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
			$('.pay-job').addClass('active-job');
			$('.match-job').removeClass('active-job');
			$('.describe-job').removeClass('active-job');
            $('#text-overlay').html('Great low rates. No need for cash!');
            $('.workerpage #text-overlay').html("You set your own price!");
            $('.dot').css('background','#000').css('color','#fff');
            $('.dotthird').css('background','#0087cf').css('color','#fff');
            $('#bigphone').attr('src','images/phone-customer3.png');
            $('.workerpage #bigphone').attr('src','images/phone-worker3.png');
            $('.slide2').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');
        }else
        if ( $( ".slide3" ).is( ".active" ) ) {
            $('.slide1').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
			$('.describe-job').addClass('active-job');
			$('.match-job').removeClass('active-job');
			$('.pay-job').removeClass('active-job');
            $('#text-overlay').html("Want help now?");
            $('.workerpage #text-overlay').html("Want work in your free time?");
            $('.dot').css('background','#000').css('color','#fff');
            $('.dotfirst').css('background','#0087cf').css('color','#fff');
            $('#bigphone').attr('src','images/phone-customer1.png');
            $('.workerpage  #bigphone').attr('src','images/phone-worker1.png');
            $('.slide3').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');
        }
    }
    function changeSlideprev(){
        if ( $( ".slide1" ).is( ".active" ) ) {
            $('.slide3').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
            $('#text-overlay').html('Great low rates. No need for cash!');
            $('.workerpage #text-overlay').html("You set your own price!");
            $('.dot').css('background','#0087cf').css('color','#fff');
            $('.dotthird').css('background','#fff').css('color','#000');
            $('#bigphone').attr('src','images/phone-customer3.png');
            $('.workerpage #bigphone').attr('src','images/phone-worker3.png');
            $('.slide1').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');

        }else
        if ( $( ".slide2" ).is( ".active" ) ) {
            $('.slide1').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
            $('#text-overlay').html("Want help now?");
            $('.workerpage #text-overlay').html("Want work in your free time?");
            $('.dot').css('background','#0087cf').css('color','#fff');
            $('.dotfirst').css('background','#fff').css('color','#000');
            $('#bigphone').attr('src','images/phone-customer1.png');
            $('.workerpage #bigphone').attr('src','images/phone-worker1.png');
            $('.slide2').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');
        }else
        if ( $( ".slide3" ).is( ".active" ) ) {
            $('.slide2').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
            $('#text-overlay').html("We'll be there in an Instynt");
            $('.workerpage #text-overlay').html("Take only jobs you want");
            $('.dot').css('background','#0087cf').css('color','#fff');
            $('.dotsecond').css('background','#fff').css('color','#000');
            $('#bigphone').attr('src','images/phone-customer2.png');
            $('.workerpage #bigphone').attr('src','images/phone-worker2.png');
            $('.slide3').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');
        }
    }
    $(document).ready(function(){
        var sliderloop;
        var i = 0;
        $('.dotnav').css('left',($(window).width()-$('.dotnav').width())/2);
        $('.slide1').addClass('active');
        $('.dotfirst').css('background','#0087cf').css('color','#fff');
        sliderloop = setInterval(function(){
            changeSlide();
            console.log('odradio')
        },9000);
		
		
		
        $('.dotfirst').click(function(){
            $('.slide1').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
			$('.describe-job').addClass('active-job');
			$('.match-job').removeClass('active-job');
			$('.pay-job').removeClass('active-job');
            $('#text-overlay').html("Want help now?");
            $('.workerpage #text-overlay').html("Want work in your free time?");
            $('.dot').css('background','#000').css('color','#fff');
            $('.dotfirst').css('background','#0087cf').css('color','#fff');
            $('#bigphone').attr('src','images/phone-customer1.png');
            $('.workerpage #bigphone').attr('src','images/phone-worker1.png');
            $('.slide3, .slide2').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');
            clearInterval(sliderloop);
            sliderloop = setInterval(function(){
                changeSlide();
                console.log('odradio')
            },9000);
        });
        $('.dotsecond').click(function(){
            $('.slide2').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
			$('.match-job').addClass('active-job');
			$('.describe-job').removeClass('active-job');
			$('.pay-job').removeClass('active-job');
            $('#text-overlay').html("We'll be there in an Instynt");
            $('.workerpage #text-overlay').html("Take only jobs you want");
            $('.dot').css('background','#000').css('color','#fff');
            $('.dotsecond').css('background','#0087cf').css('color','#fff');
            $('#bigphone').attr('src','images/phone-customer2.png');
            $('.workerpage #bigphone').attr('src','images/phone-worker2.png');
            $('.slide1, .slide3').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');
            clearInterval(sliderloop);
            sliderloop = setInterval(function(){
                changeSlide();
                console.log('odradio')
            },9000);
        });
        $('.dotthird').click(function(){
            $('.slide3').css('z-index','1').animate({opacity: '1'}, 600).addClass('active');
			$('.pay-job').addClass('active-job');
			$('.describe-job').removeClass('active-job');
			$('.match-job').removeClass('active-job');
            $('#text-overlay').html('Great low rates. No need for cash!');
            $('.workerpage #text-overlay').html("You set your own price!");
            $('.dot').css('background','#000').css('color','#fff');
            $('.dotthird').css('background','#0087cf').css('color','#fff');
            $('#bigphone').attr('src','images/phone-customer3.png');
            $('.workerpage #bigphone').attr('src','images/phone-worker3.png');
            $('.slide1, .slide2').css('z-index','0').animate({opacity: '0'}, 600).removeClass('active');
            clearInterval(sliderloop);
            sliderloop = setInterval(function(){
                changeSlide();
                console.log('odradio')
            },9000);
        });
        $('.nextslide').click(function(){
            changeSlide();
            clearInterval(sliderloop);
            sliderloop = setInterval(function(){
                changeSlide();
                console.log('odradio')
            },5000);
        });
        $('.prevslide').click(function(){
            changeSlideprev();
            clearInterval(sliderloop);
            sliderloop = setInterval(function(){
                changeSlide();
                console.log('odradio')
            },9000);
        });
    });
    $(window).resize(function(){
        $('.dotnav').css('left',($(window).width()-$('.dotnav').width())/2);
    });

	$(function() {
        $('button').mouseenter(function() {
            $('p.first').addClass("intro");
        });
        $('button').mouseleave(function() {
            $('p.first').removeClass("intro");
        });
    });

	$(function() {
        $('#download-phone img').mouseenter(function() {
            $('#download-phone img').attr('src','images/get-app-hover.png');
        });

		$('#download-phone img').mouseleave(function() {
            $('#download-phone img').attr('src','images/get-app.png');
        });
    });

