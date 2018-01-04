<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footerScriptControl.ascx.cs" Inherits="User_UserControls_UserProfile" %>

<!-- OLD CSS START --> 
<link rel="stylesheet" type="text/css" id="Link2" href="../css/plugins.css"/>
<link rel="stylesheet" type="text/css" id="Link1" href="css/themes/fancy.css"/>
<link rel="stylesheet" type="text/css" id="Link3" href="css/main.css"/>
<link rel="stylesheet" type="text/css" id="Link4" href="css/themes.css"/>
<link rel="stylesheet" type="text/css" id="Link5" href="css/datepicker.css"/>

<!-- OLD CSS END --> 


<!-- START SCRIPTS --> 
<!-- START PLUGINS --> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/jquery/jquery.min.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/jquery/jquery-ui.min.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/bootstrap/bootstrap.min.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/jquery/jquery-migrate.min.js"></script> 
<!-- END PLUGINS --> 
<!-- Forms Element Plugins--> 
<script type='text/javascript' src='../E2Forums-New/js/plugins/icheck/icheck.min.js'></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/bootstrap/bootstrap-file-input.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/form/jquery.form.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/cropper/cropper.min.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/bootstrap/bootstrap-datepicker.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/bootstrap/bootstrap-select.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/tagsinput/jquery.tagsinput.min.js"></script> 
<!-- Forms Element Plugins--> 
<!-- Validation --> 
<script type='text/javascript' src='../E2Forums-New/js/plugins/maskedinput/jquery.maskedinput.min.js'></script> 
<script type="text/javascript" src="../E2Forums-New/js/plugins/bvalidator/jquery.bvalidator.js"></script>
<link href="../E2Forums-New/css/bvalidator/bvalidator.css" rel="stylesheet" type="text/css" />
<!-- Validation --> 

<!-- Weather JS --> 
<script src="../E2Forums-New/js/plugins/weather/jquery.simpleWeather.min.js"></script> 
<!-- Weather JS End--> 

<!-- START TEMPLATE --> 
<script type="text/javascript" src="../E2Forums-New/js/plugins.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/actions.js"></script> 
<script type="text/javascript" src="../E2Forums-New/js/demo_edit_profile.js"></script>
 <script src="../js/jquery.validate.min.js"></script>
<!-- END TEMPLATE --> 
<!-- END SCRIPTS --> 





<script>
    function errorimg() {
        alert("error");
            $(this).attr('src', './images/nopicture.png');
        }           
</script>

<script>
    $(document).ready(function () {

        $(".x-navigation-control").click(function () {
           $('.page-sidebar').toggleClass('open-menu');
        });


        // Bvalidator Hide prompts
        $("#hide-prompts").click(function () {
            $(".bVErrMsgContainer").hide();
            //$('.form-control').removeClass('bvalidator_invalid');
        });
        // Bvalidator
        $('#bvalidator').bValidator();
     /*   $("img").each(function () {
            $(this).attr("src", "../E2Forums-New/img/default_profile_pic.jpg");
        });*/
    });
    // Hide Edit Profile View
    $("#edit-profile").hide();
    // View Profile View   
    $("#backToViewForm").click(function () {
        $("#profileEditForm").hide();
        $("#div_profile").show();
        return false;
    });
</script> 


<script type="text/javascript">
    $(document).ready(function () {
        $("#chat-box-button").click(function () {
            $(".chat-panel").toggleClass("layout-chat-open");
        });

        if (vOccupationID == 0) {

            $('#GrpChtModal').empty();
            $('#GrpChtModal').append("Please update your profile");
        }
        else {
        }

        //$(".chat-group a").click(function () {
        //    $(".chat-panel").toggleClass("conversation-open");
        //});
        $(".chat-back").click(function () {
            $(".chat-panel").removeClass("conversation-open");
        });
        
        $(".clschtpanel").click(function () {
            $(".chat-panel").removeClass("conversation-open");
        });


        $('#chat_users_single_dev').delegate('a', 'click', function () {
            $(".chat-panel").toggleClass("conversation-open");
        });


        $('#searchTargt').delegate('a', 'click', function () {
            $(".chat-panel").toggleClass("conversation-open");
            $("#searchTargt").css("display", "none");
        });

        $('#EditGrpChtModal').delegate('#GroupEditbtn', 'click', function () {
            $("#GroupEdit").fadeIn();
        });

        $('#EditGrpChtModal').delegate('#editAddMembBtn', 'click', function () {
            $("#editsearchTraget").fadeIn();
        });
        
        $('#createdGroup').delegate('#GroupNewEditbtn', 'click', function () {
            $("#createNewGrp").fadeIn();
        });

        $('#EditGrpChtModal').delegate('.closeBtn', 'click', function () {
            $("#editsearchTraget").fadeOut();
        });


        $('#chat_users_Group_dev').delegate('a', 'click', function () {
          
            $(".chat-panel").toggleClass("conversation-open");
        });

        $('.closeBtn').on("click", function () {
            $('#GroupEdit, #uploadTechTip').fadeOut();
        });

        
        $('#addPost').on("click", function () {
            $('#uploadTechTip').fadeIn();
        });

        $('#searchTargt').delegate('#clsSearchPnl', 'click', function () {
            $("#searchTargt").hide();
        });


    });

    $('#fileUpload').change(function () {
        $('#file-caption-name').empty();
        var selectedValue = $(this).val();
        $('#file-caption-name').append(selectedValue);
    });

</script> 

<script type="text/javascript">
    
    $(document).ready(function () {


        $(".chat-box-button").click(function () {

            $(".chat-panel").toggleClass("layout-chat-open");
            chatGetUsersSingle();
        });

        $('#chat_box_dev').delegate('.chat-back', 'click', function () {
            $(".chat-panel").removeClass("conversation-open");
        });
 
        $("#chat-back").click(function () {
            $(".chat-panel").removeClass("conversation-open");
        });


        $(".alertClick").click(function () {
            $(".chat-panel").removeClass("conversation-open");
        });

        $("#notification_msg, .alertClick").click(function () {
            $(".chat-panel").removeClass("layout-chat-open");
        });

        $("#power-off").click(function () {
            $(".chat-panel").removeClass("layout-chat-open");
        });

        GetTopBarCount();


    });
    function GetTopBarCount() {

        NProgress.start();

        console.log("1");

        $.post("Ajax_dev/A_index.aspx",
        {
            Mode: "GETTOPBARCOUNT"

        },
      function (VarResponseData) {

          //alert(VarResponseData);


          //console.log("hello1234");
          $(VarResponseData).find('Response').each(function () {
              $(VarResponseData).find('AdminData').each(function () {
                  var val_total = "";
                  if ($(this).find('TotalMessage').text() != "") {

                      $('#s_message2').html($(this).find('TotalMessage').text());
                      $('#s_message2').attr('readonly', 'readonly');
                  }
                  else
                      $("#s_message2").html('0');


                  if ($(this).find('TotalNot').text() != "") {
                      $('#NotificationCount').html($(this).find('TotalNot').text());
                      $('#NotificationCount').attr('readonly', 'readonly');
                  }
                  else
                      $("#NotificationCount").html('0');

               
                  if ($(this).find('count_event').text() != "") {
                      $('#lbl_alert_count').html($(this).find('count_event').text());
                      $('#lbl_alert_count').attr('readonly', 'readonly');
                  }
                  else
                      $("#lbl_alert_count").html('0');

              });

          }); //end of Response 
          NProgress.done();

      });
        return false;
    }
</script>

<script>
    $(".xn-openable").hover(
  function () {
      $(this).addClass("active");
  },
  function () {
      $(this).removeClass("active");
  }
);
</script>

<script language="javascript" type="text/javascript">
    $(function () {

        NProgress.start();

        console.log("1");

        $.post("UserProfile.aspx",
        {
            Mode: "GETUSERDET"

        },
      function (VarResponseData) {

          //alert(VarResponseData);


          //console.log("hello1234");
          $(VarResponseData).find('Response').each(function () {
              $(VarResponseData).find('AdminData').each(function () {
                  console.log("hello");
                  console.log($(this).find('Full_Name').text());
                  if ($(this).find('Full_Name').text() != "") {
                      $('#UserNameHead').html($(this).find('Full_Name').text());
                      $('#UserNameHead').attr('readonly', 'readonly');
                  }

                  if ($(this).find('Picture').text() != "")
                      $("#UserImagEditPage").attr("src", $(this).find('Picture').text());
                  else
                      $("#UserImagEditPage").attr("src", "../img/AnonymousGuyPic.jpg");

                  if ($(this).find('EMail').text() != "")
                      $("#UserEmail_desk").html($(this).find('EMail').text());
                  else
                      $("#UserEmail_desk").html('-');
              });

          }); //end of Response 
          NProgress.done();


          return false;
      });

    });                  //End of Ajax

   


        function showimagepreview(input) {

            if (input.files && input.files[0]) {

                var filerdr = new FileReader();

                filerdr.onload = function (e) {

                    $('#imgprvw').attr('src', e.target.result);
                    $("#imgprvw").fadeIn();
                    $("#imgprev-a").fadeIn();

                }

                filerdr.readAsDataURL(input.files[0]);

            }

        }

    </script>



<script>
    $("#search1").focus(function () {
        $("#searchTargt").css("display", "block");
    });

</script>




