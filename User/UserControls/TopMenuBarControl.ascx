<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenuBarControl.ascx.cs" Inherits="User_UserControls_TopBarControl" %>
<form class="top-menu-section" >
<!-- START X-NAVIGATION VERTICAL -->
<ul class="x-navigation x-navigation-horizontal x-navigation-panel">
<!-- TOGGLE NAVIGATION -->
<li class="xn-icon-button"> <a href="#" class="x-navigation-minimize"><span class="fa fa-dedent"></span></a> </li>
<!-- END TOGGLE NAVIGATION --> 
<!-- POWER OFF -->
<li class="xn-icon-button pull-right last"> <a href="#" id="power-off"><span class="fa fa-power-off"></span></a>
  <ul class="xn-drop-left animated zoomIn">
      <asp:Panel ID="Panel_lockScreen" runat="server">
    <li><a href="lockScreenRedirect.aspx" ><span class="fa fa-lock"></span> Lock Screen</a></li>
          
      </asp:Panel>
      <li><a target="_blank" href="../ForgotPassword.aspx?pageTitle=Change" ><span class="fa fa-key"></span> Change Password</a></li>
    <li><a href="#" class="mb-control" data-box="#mb-signout"><span class="fa fa-sign-out"></span> Sign Out</a></li>
  </ul>
</li>
<!-- END POWER OFF --> 
<!-- MESSAGES -->
<li class="xn-icon-button pull-right"  title="Chat"> <a class="chat-box-button" href="#"><span class="fa fa-comments"></span></a>
  <div class="informer informer-danger"><span id="s_message2" style="display:none"></span><span id="MessCounterChat" ></span></div>
</li>
<!-- END MESSAGES --> 
<!-- TASKS -->
<li class="xn-icon-button pull-right" title="Notification"> 
<a href="javascript:void(0)" class="dropdown-toggle" id="notification_msg" data-toggle="dropdown" onclick="return GetAllNotifications();">
<label id="NotificationCount" class="informer informer-danger"></label>
    <i class="fa fa-envelope"></i>
</a>


  <div class="panel panel-primary animated zoomIn xn-drop-left xn-panel-dragging">
    <div class="panel-heading">
      <h3 class="panel-title"><span class="fa fa-bell-o"></span> Messages</h3>

    </div>
    <div class="panel-body list-group scroll" style="height: 200px;"> 
<div id="div_notifications" class="mousescroll"> 

</div>
    </div>
    <div class="panel-footer text-center"></div>
  </div>
</li>

    <li class="xn-icon-button pull-right alertClick" > 
<a href="javascript:void(0)" class="dropdown-toggle" id="A1" data-toggle="dropdown" onclick="return GetAllAlert();">
<label id="Label1" class="informer informer-danger"></label>
    <i style="font-size:18px;" class="fa fa-bell" title="Alert"></i>
<i "></i>
</a>

    <label id="lbl_alert_count" class="informer informer-danger"></label>


  
<div class="panel panel-primary animated zoomIn xn-drop-left xn-panel-dragging">
                            <div class="panel-heading">
                                <h3 class="panel-title"><span class="fa fa-lightbulb-o"></span> Alerts</h3>                                
                                <div class="pull-right">
                                    <span class="label label-warning"><label id="lbl_alert_count2" ></label> active</span>
                                </div>
                            </div>
                            <div style="height: 200px;" class="panel-body list-group scroll">                                
                               
                                <div id="div_EventAlert" class="mousescroll"> 
                                    
                                    
                                    
                                     <%--<a href="#" class="list-group-item">
                                    <strong>Phasellus augue arcu, elementum</strong><br />

                                             --%>
                                </div>

                                               
                            </div>     
                            <div class="panel-footer text-center">
                              
                            </div>                            
                        </div>


</li>

<!-- END TASKS --> 
<li class="xn-expert-advisors pull-right">
        <h3>Expert Advice From Experts To Advisors</h3>
      </li>
</ul>
<!-- END X-NAVIGATION VERTICAL -->
<div id="validation-msg-container"></div>

</form>


 <form id="frmShowTopicNotification" action="Forum.aspx" method="post">
            <input type="hidden" name="Mode" id="hiddMode" value="ShowTopic" />
            <input type="hidden" name="TopicID" id="hiddTopicID" value="-1" />
            <input type="hidden" name="Topic" id="hiddTopic" value="" />
            <input type="hidden" name="CategoryID" id="hiddCategoryID" value="-1" />
            <input type="hidden" name="ID" id="hiddID" value="" />
    </form>
   <form id="frmViewNotifications" action="Notification.aspx" method="post">
            <input type="hidden" name="ID" id="hiddReferenceID" value="" />
            <input type="hidden" name="Type" id="hiddNotificationType" value="" />
            <input type="hidden" name="NotificationID" id="hiddNotificationID" value="" />
           
    </form>
<script  language="javascript" type="text/javascript">
    
   
</script>

<script>

    // Include the UserVoice JavaScript SDK (only needed once on a page)
    UserVoice = window.UserVoice || []; (function () { var uv = document.createElement('script'); uv.type = 'text/javascript'; uv.async = true; uv.src = '//widget.uservoice.com/22uLZYvqn0yTLcjfgPEZMQ.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(uv, s) })();

    //
    // UserVoice Javascript SDK developer documentation:
    // https://www.uservoice.com/o/javascript-sdk
    //

    // Set colors
    UserVoice.push(['set', {
        accent_color: '#448dd6',
        trigger_color: 'white',
        trigger_background_color: 'rgba(46, 49, 51, 0.6)'
    }]);

    // Identify the user and pass traits
    // To enable, replace sample data with actual user traits and uncomment the line
    UserVoice.push(['identify', {
        email: '<%=Email%>'
        //name:       'John Doe', // User’s real name
        //created_at: 1364406966, // Unix timestamp for the date the user signed up
        //id:         123, // Optional: Unique id of the user (if set, this should not change)
        //type:       'Owner', // Optional: segment your users by type
        //account: {
        //  id:           123, // Optional: associate multiple users with a single account
        //  name:         'Acme, Co.', // Account name
        //  created_at:   1364406966, // Unix timestamp for the date the account was created
        //  monthly_rate: 9.99, // Decimal; monthly rate of the account
        //  ltv:          1495.00, // Decimal; lifetime value of the account
        //  plan:         'Enhanced' // Plan name for the account
        //}
    }]);

    // Add default trigger to the bottom-right corner of the window:
    UserVoice.push(['addTrigger', { mode: 'contact', trigger_position: 'bottom-right' }]);

    // Or, use your own custom trigger:
    //UserVoice.push(['addTrigger', '#id', { mode: 'contact' }]);

    // Autoprompt for Satisfaction and SmartVote (only displayed under certain conditions)
    UserVoice.push(['autoprompt', {}]);
</script>

<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-54240303-1', 'auto');
    ga('send', 'pageview');

</script>
<script language="javascript" type="text/javascript">
    var vOccupationID = 0;
    vOccupationID = '<%=OccupationID %>';
    $(function () {
      
        if ("<%=IsUserLoggedIn%>" == 'False') {

           
            //toastr.options = { "onHidden": function () { toastr["error"]("Yours session has been expired please login again."); window.location('logout.aspx'); } };
            window.location = "logout.aspx";

           
        }

        NProgress.start();
   
        GetAllNotifications();
        
        ShowAdvertisement();
        // $('.tooltip').tooltipster();
        //  $('#abc').tooltip('show');


        NProgress.done();
    });

   
    function GetAllAlert() {
      
        NProgress.start();
        $.post("Ajax/AjaxUser.aspx",
        {
            Mode: "GETALLALERT"

        },

       function (VarResponseData) {
           $('#div_EventAlert').empty();
           $('#lbl_alert_count').empty();
           $("#lbl_alert_count").text(VarResponseData.split('##')[0]);
           $("#lbl_alert_count2").text(VarResponseData.split('##')[0]);
           $('#div_EventAlert').append(VarResponseData.split('##')[1]);
           NProgress.done();
           if (parseInt(VarResponseData.split('##')[0]) > 5) {

               $('#div_EventAlert').slimscroll({
                   color: '#f31455',
                   size: '10px',
               });
           }
           else if (parseInt(VarResponseData.split('##')[0]) == 4) {
               $("#div_EventAlert").removeClass("mousescroll");
               $("#div_EventAlert").animate({ height: "200px" });
           }
           else if (parseInt(VarResponseData.split('##')[0]) == 3) {
               $("#div_EventAlert").removeClass("mousescroll");
               $("#div_EventAlert").animate({ height: "160px" });

           }
           else if (parseInt(VarResponseData.split('##')[0]) == 2) {
               $("#div_EventAlert").removeClass("mousescroll");
               $("#div_EventAlert").animate({ height: "120px" });

           }
           else if (parseInt(VarResponseData.split('##')[0]) == 1) {
               $("#div_EventAlert").removeClass("mousescroll");
               $("#div_EventAlert").animate({ height: "80px" });

           }
           else if (parseInt(VarResponseData.split('##')[0]) == 0 || VarResponseData.split('##')[0] == "") {

               $("#div_EventAlert").removeClass("mousescroll");
               $("#div_EventAlert").animate({ height: "40px" });
               $('#div_EventAlert').text('No alert found.');


           }
       }); //End of Ajax

        return false;


    }
    function GetAllNotifications() {
        if ("<%=IsUserLoggedIn%>" == 'False') {
           
                alert='test';
            }
        else
        {
            
        NProgress.start();
            $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETALLNOTIFICATIONS"

            },

           function (VarResponseData) {
               $('#div_notifications').empty();
               $('#NotificationCount').empty();
               $('#NotificationCount').html(VarResponseData.split('##')[0]);
               $('#div_notifications').append(VarResponseData.split('##')[1]);
               NProgress.done();
               if (parseInt(VarResponseData.split('##')[0]) > 5) {
                   //invalid name call
                   //$('#div_notifications').attr('style','max-height:250px');
                   $('#div_notifications').slimscroll({
                       color: '#f31455',
                       size: '10px',
                   });
               }
               else if (parseInt(VarResponseData.split('##')[0]) == 4) {
                   $("#div_notifications").removeClass("mousescroll");
                   // $('#div_notifications').attr('style', 'height:200px');
                   $("#div_notifications").animate({ height: "200px" });

              
               }
               else if (parseInt(VarResponseData.split('##')[0]) == 3) {
                   $("#div_notifications").removeClass("mousescroll");
                   // $('#div_notifications').attr('style', 'height:160px');
                   $("#div_notifications").animate({ height: "160px" });
             
               }
               else if (parseInt(VarResponseData.split('##')[0]) == 2) {
                   $("#div_notifications").removeClass("mousescroll");
                   //   $('#div_notifications').attr('style', 'height:120px');
                   $("#div_notifications").animate({ height: "120px" });
                   //  $('#div_notifications').dialog(
                   //       "resize", "auto"
                   //);
               }
               else if (parseInt(VarResponseData.split('##')[0]) == 1) {
                   $("#div_notifications").removeClass("mousescroll");
                   $("#div_notifications").animate({ height: "80px" });
                   //  $('#div_notifications').attr('style', 'height:80px');
                   //  $('#div_notifications').dialog(
                   //       "resize", "auto"
                   //);
               }
               else if (parseInt(VarResponseData.split('##')[0]) == 0 || VarResponseData.split('##')[0] == "") {
                   //    $('#div_notifications').attr('style', 'height:50px');
                   // $('#div_notificationFound').show();
                   //  $('#div_notificationFound').text('No notification found');
                   $("#div_notifications").removeClass("mousescroll");
                   $("#div_notifications").animate({ height: "40px" });
                   //       $('#div_notifications').dialog(
                   //       "resize", "auto"
                   //);
                   $('#div_notifications').text('No notification found');


               }

               if (vOccupationID == 0) {
                   $('#div_notifications').empty();
                   $('#div_notifications').text('Please update your profile to gain full access');
               }
           
           }); //End of Ajax
        }
            return false;

       
    }
    function GetNotificationsCount() {
        NProgress.start();
        $.post("Ajax/AjaxUser.aspx",
        {
            Mode: "GETNOTIFICATIONSCOUNT"

        },

        function (VarResponseData) {
            $(VarResponseData).find('Response').each(function () {
                $(VarResponseData).find('NotificationCount').each(function () {


                    if ($(this).find('NotificationCount').text() != "") {
                        $('#NotificationCount').html($(this).find('NotificationCount').text());
                    }

                });

            }); //end of Response   
            NProgress.done();
        });                 //End of Ajax

        return false;
    }

    (function ($) {

        jQuery.fn.extend({
            slimScroll: function (o) {

                var ops = o;
                //do it for every element that matches selector
                this.each(function () {

                    var isOverPanel, isOverBar, isDragg, queueHide, barHeight,
                        divS = '<div></div>',
                        minBarHeight = 30,
                        wheelStep = 30,
                        o = ops || {},
                        cwidth = o.width || 'auto',
                        cheight = o.height || '100',
                        size = o.size || '7px',
                        color = o.color || '#000',
                        position = o.position || 'right',
                        opacity = o.opacity || .4,
                        alwaysVisible = o.alwaysVisible === true;

                    //used in event handlers and for better minification
                    var me = $(this);

                    //wrap content
                    var wrapper = $(divS).css({
                        position: 'relative',
                        overflow: 'hidden',
                        width: cwidth,
                        height: cheight
                    }).attr({ 'class': 'slimScrollDiv' });

                    //update style for the div
                    me.css({
                        overflow: 'hidden',
                        width: cwidth,
                        height: cheight
                    });

                    //create scrollbar rail
                    var rail = $(divS).css({
                        width: '15px',
                        // height: '100%',
                        position: 'absolute',
                        top: 0
                    });

                    //create scrollbar
                    var bar = $(divS).attr({
                        'class': 'slimScrollBar ',
                        style: 'border-radius: ' + size
                    }).css({
                        background: color,
                        width: size,
                        position: 'absolute',
                        top: 0,
                        opacity: opacity,
                        display: alwaysVisible ? 'block' : 'none',
                        BorderRadius: size,
                        MozBorderRadius: size,
                        WebkitBorderRadius: size,
                        zIndex: 99
                    });

                    //set position
                    var posCss = (position == 'right') ? { right: '1px' } : { left: '1px' };
                    rail.css(posCss);
                    bar.css(posCss);

                    //wrap it
                    me.wrap(wrapper);

                    //append to parent div
                    me.parent().append(bar);
                    me.parent().append(rail);

                    //make it draggable
                    bar.draggable({
                        axis: 'y',
                        containment: 'parent',
                        start: function () { isDragg = true; },
                        stop: function () { isDragg = false; hideBar(); },
                        drag: function (e) {
                            //scroll content
                            scrollContent(0, $(this).position().top, false);
                        }
                    });

                    //on rail over
                    rail.hover(function () {
                        showBar();
                    }, function () {
                        hideBar();
                    });

                    //on bar over
                    bar.hover(function () {
                        isOverBar = true;
                    }, function () {
                        isOverBar = false;
                    });

                    //show on parent mouseover
                    me.hover(function () {
                        isOverPanel = true;
                        showBar();
                        hideBar();
                    }, function () {
                        isOverPanel = false;
                        hideBar();
                    });

                    var _onWheel = function (e) {
                        //use mouse wheel only when mouse is over
                        if (!isOverPanel) { return; }

                        var e = e || window.event;

                        var delta = 0;
                        if (e.wheelDelta) { delta = -e.wheelDelta / 120; }
                        if (e.detail) { delta = e.detail / 3; }

                        //scroll content
                        scrollContent(0, delta, true);

                        //stop window scroll
                        if (e.preventDefault) { e.preventDefault(); }
                        e.returnValue = false;
                    }

                    var scrollContent = function (x, y, isWheel) {
                        var delta = y;

                        if (isWheel) {
                            //move bar with mouse wheel
                            delta = bar.position().top + y * wheelStep;

                            //move bar, make sure it doesn't go out
                            delta = Math.max(delta, 0);
                            var maxTop = me.outerHeight() - bar.outerHeight();
                            delta = Math.min(delta, maxTop);

                            //scroll the scrollbar
                            bar.css({ top: delta + 'px' });
                        }

                        //calculate actual scroll amount
                        percentScroll = parseInt(bar.position().top) / (me.outerHeight() - bar.outerHeight());
                        delta = percentScroll * (me[0].scrollHeight - me.outerHeight());

                        //scroll content
                        me.scrollTop(delta);

                        //ensure bar is visible
                        showBar();
                    }

                    var attachWheel = function () {
                        if (window.addEventListener) {
                            this.addEventListener('DOMMouseScroll', _onWheel, false);
                            this.addEventListener('mousewheel', _onWheel, false);
                        }
                        else {
                            document.attachEvent("onmousewheel", _onWheel)
                        }
                    }

                    //attach scroll events
                    attachWheel();

                    var getBarHeight = function () {
                        //calculate scrollbar height and make sure it is not too small
                        barHeight = Math.max((me.outerHeight() / me[0].scrollHeight) * me.outerHeight(), minBarHeight);
                        bar.css({ height: barHeight + 'px' });
                    }

                    //set up initial height
                    getBarHeight();

                    var showBar = function () {
                        //recalculate bar height
                        getBarHeight();
                        clearTimeout(queueHide);

                        //show only when required
                        if (barHeight >= me.outerHeight()) {
                            return;
                        }
                        bar.fadeIn('fast');
                    }

                    var hideBar = function () {
                        //only hide when options allow it
                        if (!alwaysVisible) {
                            queueHide = setTimeout(function () {
                                if (!isOverBar && !isDragg) { bar.fadeOut('slow'); }
                            }, 1000);
                        }
                    }

                });

                //maintain chainability
                return this;
            }
        });

        jQuery.fn.extend({
            slimscroll: jQuery.fn.slimScroll
        });

    })(jQuery);
                  
    function ShowTopicNotification(pvarTopicID, pvarTopic, pvarCategoryID, pvarNotificationID) {
        if (vOccupationID != 0) {
            $('#hiddTopicID').val(pvarTopicID);
            $('#hiddTopic').val(pvarTopic);
            $('#hiddCategoryID').val(pvarCategoryID);
            $('#hiddID').val(pvarNotificationID);
            document.forms["frmShowTopicNotification"].submit();
        }
        else {
            alert('Please update your profile to gain full access');
    
        }
        return false;
    }

    function ViewNotifications(mvarReferenceID, mvarNotificationType, mvarNotificationID) {
        if (vOccupationID != 0) {
            $('#hiddReferenceID').val(mvarReferenceID);
            $('#hiddNotificationType').val(mvarNotificationType);
            $('#hiddNotificationID').val(mvarNotificationID);
            document.forms["frmViewNotifications"].submit();
        }
        else {
            alert('Please update your profile to gain full access');

        }
        return false;

    }

   

 

</script>



 



