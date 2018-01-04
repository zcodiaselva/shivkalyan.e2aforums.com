<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footerControl.ascx.cs" Inherits="User_UserControls_UserProfile" %>



<!-- MESSAGE BOX-->
<div class="message-box animated fadeIn" data-sound="alert" id="mb-signout">
  <div class="mb-container">
    <div class="mb-middle">
      <div class="mb-title"><span class="fa fa-sign-out"></span> Log <strong>Out</strong> ?</div>
      <div class="mb-content">
        <p>Are you sure you want to log out? </p>
      </div>
      <div class="mb-footer">
        <div class="pull-right"> <a href="../logout.aspx" class="btn btn-success btn-lg">Yes</a>
          <button class="btn btn-default btn-lg mb-control-close">No</button>
        </div>
      </div>
    </div>
  </div>
</div>
<!-- END MESSAGE BOX--> 

<!-- Chat Box Start -->


<div class="chat-panel">
<div class="panel panel-default tabs">
<ul class="nav nav-tabs nav-justified">
  <li class="active clschtpanel"><a data-toggle="tab" onclick="return chatGetUsersSingle();" href="#individualChat" aria-expanded="false">Chat</a></li>
  <li class="clschtpanel"><a data-toggle="tab" onclick="return chatGetUsersGroup();" href="#groupChatTab" aria-expanded="false">Group Chat</a> </li>
<%--  <li class="informerWrap"> <a data-toggle="tab" href="#ChatInvi" aria-expanded="true"> Invitation </a>
    <div class="informer informer-danger">4</div>
  </li>--%>
</ul>
<div class="panel-body tab-content">
<div id="individualChat" class="tab-pane active">
  <div class="chat-inner">
<div class="searchWrap">
<input type="search" id="search1"  onkeyup="chatGetUsersSearch()"  class="form-control"  placeholder="Search..." />

  
<div class="searchTargt scroll" id="searchTargt" style="height:150px">
     
<%--    <a href="#">
        <div class="media-left relative"> 
            <img alt="avatar" src="../E2Forums-New/img/avatar.21d1cc35.jpg" class="img-circle avatar avatar-xs">
          <div class="status bg-danger border-white mr10"></div>
        </div>
        <div class="media-body"> <span class="block-tit">Vincent Peterson</span> <span class="text-muted">Offline</span> </div>
       
    </a> --%>
        
   
</div>

    </div>
    
    <div id="chat_users_single_dev"  class="chat-users-wrap">


       <%-- <a href="#">
        <div class="media-left relative"> 
            <img alt="avatar" src="../E2Forums-New/img/avatar.21d1cc35.jpg" class="img-circle avatar avatar-xs">
          <div class="status bg-danger border-white mr10"></div>
        </div>
        <div class="media-body"> <span class="block-tit">Vincent Peterson</span> <span class="text-muted">Offline</span> </div>
        </a> 


        
        <a href="#">
        <div class="media-left relative"> <img alt="avatar" src="../E2Forums-New/img/avatar.21d1cc35.jpg" class="img-circle avatar avatar-xs">
          <div class="status bg-danger border-white mr10"></div>
        </div>
        <div class="media-body"> <span class="block-tit">Pamela Wood</span> <span class="text-muted">Offline</span> </div>
        </a> --%>

    </div>


  </div>



</div>

<div id="groupChatTab" class="tab-pane">
<div class="chat-inner">
<div class="chat-users-wrap">
<div id="Div1" class="tab-pane active">
<div class="chat-group">
<div class="chat-group-header"> Group Chat
  <div data-toggle="modal" data-target="#GrpChtModal" class="crtnew" href="#"><span  class="fa fa-plus"></span> Create New Group</div>
</div>
<div class="favourite-list">
<ul  id="chat_users_Group_dev"  class="grpChat">

</ul>
</div>
</div>
</div>
</div>
</div>



<div class="chat-conversation chat-conversation-group">
  <div class="chat-header"> <a href="javascript:;" class="chat-back"> <i class="fa fa-angle-left"></i> </a>

    <div class="chat-header-title"> Charles Wilson </div>
    <a href="javascript:;" class="chat-right"> <i class="fa fa-circle-thin"></i> </a> </div>
  <div class="chat-conversation-content">
    <p class="text-center text-muted small text-uppercase bold pb15"> Yesterday </p>


    <div class="chat-conversation-user them">
      <div class="media-left relative"> <img class="img-circle avatar avatar-xs" src="../E2Forums-New/img/default_profile_pic.jpg" alt="avatar"> </div>
      <div class="chat-conversation-message">
        <p>Hey.</p>
      </div>
    </div>


    <div class="chat-conversation-user them">
      <div class="chat-conversation-message">
        <p>How are the wife and kids, Taylor?</p>
      </div>
    </div>
    <div class="chat-conversation-user me">
      <div class="chat-conversation-message">
        <p>Pretty good, Samuel.</p>
      </div>
      <div class="media-left relative"> <img class="img-circle avatar avatar-xs" src="../E2Forums-New/img/default_profile_pic.jpg" alt="avatar"> </div>
    </div>
    <p class="text-center text-muted small text-uppercase bold pb15"> Today </p>
    <div class="chat-conversation-user them">
      <div class="chat-conversation-message">
        <p>Curabitur blandit tempus porttitor.</p>
      </div>
    </div>
    <div class="chat-conversation-user me">
      <div class="chat-conversation-message">
        <p>Goodnight!</p>
      </div>
    </div>
    <div class="chat-conversation-user them">
      <div class="chat-conversation-message">
        <p>Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit.</p>
      </div>
    </div>
  </div>

</div>


</div>

<div id="ChatInvi" class="tab-pane">
  <ul class="grpChat">
    <li> <a href="#">
      <div class="media-left relative"> <img class="img-circle avatar avatar-xs" src="../E2Forums-New/img/default_profile_pic.jpg" alt="avatar">
        <div class="status bg-success border-white mr10"></div>
      </div>
      <div class="media-body"> <span class="block-tit">Group Name </span> <span class="text-muted">Online</span> </div>
      </a>
      <div class="editgrp">
      <a href="javascript:void();"><i class="fa fa-trash"></i></a> 
      <a data-toggle="modal" data-target="#GrpChtMbrModal" href="javascript:void();" href="#"><i class="fa fa-users"></i></a>
      </div>
    </li>
  </ul>
</div>
</div>




  <div id="chat_box_dev" class="chat-conversation chat-conversation-group">
 
<%-- <div class="chat-header"> <a href="javascript:;" class="chat-back"> <i class="fa fa-angle-left"></i> </a>

    <div class="chat-header-title"> Charles Wilson </div>
    <a href="javascript:;" class="chat-right"> <i class="fa fa-circle-thin"></i> </a> </div>
  <div class="chat-conversation-content">
    <p class="text-center text-muted small text-uppercase bold pb15"> Yesterday </p>


    <div class="chat-conversation-user them">
      <div class="media-left relative"> <img class="img-circle avatar avatar-xs" src="../E2Forums-New/img/default_profile_pic.jpg" alt="avatar"> </div>
      <div class="chat-conversation-message">
        <p>Hey.</p>
      </div>
    </div>


    <div class="chat-conversation-user them">
      <div class="chat-conversation-message">
        <p>How are the wife and kids, Taylor?</p>
      </div>
    </div>
    <div class="chat-conversation-user me">
      <div class="chat-conversation-message">
        <p>Pretty good, Samuel.</p>
      </div>
      <div class="media-left relative"> <img class="img-circle avatar avatar-xs" src="../E2Forums-New/img/default_profile_pic.jpg" alt="avatar"> </div>
    </div>
    <p class="text-center text-muted small text-uppercase bold pb15"> Today </p>
    <div class="chat-conversation-user them">
      <div class="chat-conversation-message">
        <p>Curabitur blandit tempus porttitor.</p>
      </div>
    </div>
    <div class="chat-conversation-user me">
      <div class="chat-conversation-message">
        <p>Goodnight!</p>
      </div>
    </div>
    <div class="chat-conversation-user them">
      <div class="chat-conversation-message">
        <p>Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit.</p>
      </div>
    </div>
  </div>        
      --%>
      
      
     
</div>










</div>
</div>




<!--

<div class="chat-panel">
  <div class="chat-inner">
    <div class="chat-users-wrap">
      <div id="chat-list" class="tab-pane active">
        <div class="chat-group">
          <div class="chat-group-header"> Chat </div>
          <div class="favourite-list"> 
              
<div id="div_Friends">
</div>



    
              
            </div>
        </div>
      </div>
      
    </div>
  </div>
  <div class="chat-conversation">

  

<div class="chat-header" id="chat-back"> 
    
    
    <a class="chat-back" href="javascript:;"> <i class="fa fa-angle-left"></i> </a>
        <div class="chat-header-title"> Back to Chat </div>


</div>

    <div class="chat-conversation-content">


      <div class="media-body" id="div_message">                                                                                                                               
</div> 
    </div>

  </div>
</div>

    -->
<!-- Chat Box End--> 

<!-- MODALS -->
<div class="modal animated fadeIn" id="modal_change_photo" tabindex="-1" role="dialog" aria-labelledby="smallModalHead" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="smallModalHead">Change photo</h4>
      </div>
      <form id="cp_crop" method="post" action="http://aqvatarius.com/themes/atlant/html/assets/crop_image.php">
        <div class="modal-body">
          <div class="text-center" id="cp_target">Use form below to upload file. Only .jpg files.</div>
          <input type="hidden" name="cp_img_path" id="cp_img_path"/>
          <input type="hidden" name="ic_x" id="ic_x"/>
          <input type="hidden" name="ic_y" id="ic_y"/>
          <input type="hidden" name="ic_w" id="ic_w"/>
          <input type="hidden" name="ic_h" id="ic_h"/>
        </div>
      </form>
      <form id="cp_upload" method="post" enctype="multipart/form-data" action="http://aqvatarius.com/themes/atlant/html/assets/upload_image.php">
        <div class="modal-body form-horizontal form-group-separated">
          <div class="form-group">
            <label class="col-md-4 control-label">New Photo</label>
            <div class="col-md-4">
              <input type="file" class="fileinput btn-info" name="file" id="cp_photo" data-filename-placement="inside" title="Select file"/>
            </div>
          </div>
        </div>
      </form>
      <div class="modal-footer">
        <button type="button" class="btn btn-success disabled" id="cp_accept">Accept</button>
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>


<div class="modal animated fadeIn" id="modal_change_password" tabindex="-1" role="dialog" aria-labelledby="smallModalHead" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        <h4 class="modal-title" id="H1">Change password</h4>
      </div>
      <div class="modal-body">
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer faucibus, est quis molestie tincidunt</p>
      </div>
      <div class="modal-body form-horizontal form-group-separated">
        <div class="form-group">
          <label class="col-md-3 control-label">Old Password</label>
          <div class="col-md-9">
            <input type="password" class="form-control" name="old_password"/>
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label">New Password</label>
          <div class="col-md-9">
            <input type="password" class="form-control" name="new_password"/>
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label">Repeat New</label>
          <div class="col-md-9">
            <input type="password" class="form-control" name="re_password"/>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Proccess</button>
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
<!-- EOF MODALS --> 





<!-- ADD NEW GROUP POPUP START-->
<div id="GrpChtModal" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title"><span class="fa fa-comments"></span> Add New Group</h4>
      </div>

<div class="scroll" style="height:500px;">
      <div class="modal-body">
        <div id="crtGNewGrp" class="tab-pane active">
          <div class="content-frame"> 
            <!-- START CONTENT FRAME TOP --> 
            
            <!-- END CONTENT FRAME TOP --> 
            
            <!-- START CONTENT FRAME RIGHT -->
            
            <div class="row" id="CreateGroup">
<div id="grperrorcontainer">                              
</div>



              <div class="panel panel-default" id="createNewGrp">
                <div class="panel-body">
                  <p>Create New Group.</p>
                  <form class="form-horizontal" action="">
                    <div class="form-group">
                      <div class="col-md-2">
                        <div class="form-group">
                          <div class="col-md-12">
                            <input type="file" class="fileinput btn-primary"  name="fileUpload" id="fileUpload" title="Browse file"/>
                            <span class="help-block">Group Icon</span> </div>
                        </div>
                      </div>
                      <div class="col-md-8">
                        <div class="form-group">
                          <div class="col-md-12">
                            <div class="input-group"> <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                              <input type="text" id="txtGrpName" class="form-control" onkeyup="validateChatForm()">
                            </div>
                            <span class="help-block">Enter Group Name</span> </div>
                        </div>
                      </div>
                      <div class="col-md-2">
                        <button id="GrpBtn" onclick="return chat_create_group()" disabled="disabled" class="btn btn-success btn-block"><span class="fa fa-plus"></span> Create Group</button>
                      </div>
                    </div>
                  </form>
                </div>
              </div>
            </div>
            <div class="row" id="createdGroup">
                <div class="col-md-4">
              <h5><strong>Chat Groups.</strong></h5>
                    </div>
                    <div class="col-md-8">
              <h5><strong>Existing Members in group.</strong></h5>
                        </div>

              <div class="col-md-4">
             <!-- <div class="removeDiv"><i title="Delete Group" class="fa fa-trash"></i></div> -->
              <div class="panel panel-default text-center">
                <div class="panel-body">
                  <form class="form-horizontal">
                  
                      <div class="profile-image grpIcon"> <img id="grp_crt_img_url"  src="" onerror="this.onerror=null;this.src='../E2Forums-New/img/default_profile_pic.jpg';" alt=""> </div>
          
       
                      <div class="form-group">
                        <div class="col-md-12"> 
                        <h6><strong id="grp_crt_name"></strong></h6>
                        <%--<small>0 Members in your group</small>--%>
                        </div>
                      </div>
              
        
                      <button class="btn btn-primary btn-rounded add-grp-mem-btn" type="button">Add Group Members</button>
                     <!-- <button class="btn btn-info btn-rounded" type="button" id="GroupNewEditbtn">Edit</button> -->
                      <%--<button class="btn btn-danger btn-rounded" type="button">Remove</button>--%>
                   
                  </form>
                </div>
              </div>
</div>

  <div class="col-md-8">         
<div id="existingMember" class="existingMember scroll" style="max-height:200px">

<div class="content-frame-right">
<div class="list-group list-group-contacts border-bottom push-down-10">
    <div id="existingMemberdev"></div>
               <%-- <a href="#" class="list-group-item">
                <div class="list-group-status status-online"></div>
                <img src="E2Forums-New/img/default_profile_pic.jpg" class="pull-left" alt="" onerror="this.onerror=null;this.src='../E2Forums-New/img/default_profile_pic.jpg';">
                <div class="contacts-title">John Doe</div>
                <p>This project is awesome</p>
                <span class="adminIndi label-danger">Group admin</span> </a>

              <a class="list-group-item" href="#">
                <div class="list-group-status status-online"></div>
                <img alt="Dmitry Ivaniuk" class="pull-left" src="E2Forums-New/img/default_profile_pic.jpg" onerror="this.onerror=null;this.src='../E2Forums-New/img/default_profile_pic.jpg';"> <span class="contacts-title">Dmitry Ivaniuk</span>
                <p>Social Worker</p>
                                  <div class="slctMmb">
                  <label class="switch">
                    <input type="checkbox" class="switch" value="1" checked/>
                    <span></span> </label>
                </div>
                </a> 


                <a class="list-group-item" href="#">
                <div class="list-group-status status-online"></div>
                <img alt="Dmitry Ivaniuk" class="pull-left" src="E2Forums-New/img/default_profile_pic.jpg" onerror="this.onerror=null;this.src='../E2Forums-New/img/default_profile_pic.jpg';"> <span class="contacts-title">Dmitry Ivaniuk</span>
                <p>Web developer</p>
                                    <div class="slctMmb">
                  <label class="switch">
                    <input type="checkbox" class="switch" value="1" checked/>
                    <span></span> </label>
                </div>
                </a> --%>
                
</div>
</div>

</div>
 </div>            

            </div>




<div id="addSearch" class="addSearch">
<div class="closeBtn"><i id="closeBtn" data-toggle="tooltip" data-placement="top" title="Close Seach Panel" class="fa fa-times"></i></div>
            <div class="content-frame-top" id="SearchMemb">

                <form class="form-horizontal">
                  <div class="form-group">
                  <div class="row">
                    <div class="col-md-8">
                      <div class="input-group">
                        <div class="input-group-addon"> <span class="fa fa-search"></span> </div>
                        <input type="text" id="txt_grp_member_name_search" placeholder="Who are you looking for?" class="form-control">
                        <div class="input-group-btn">
                          <button class="btn btn-primary" onclick="return get_chat_group_Search_member()">Search</button>
                        </div>
                      </div>
                    </div>
                  </div>

                </form>
              </div>
            </div>


            <div class="content-frame-right">
              <div class="list-group list-group-contacts border-bottom push-down-10"> 
              <div id="groupMemberSearchList" class="scroll" style="height:200px"></div>

              </div>
              
            </div>
            </div>
         
          </div>
        </div>
      </div>
        </div>
      
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  
</div>
</div>
<!-- ADD NEW GROUP POPUP END-->

<!-- EDIT GROUP CHAT POPUP START-->
<div id="EditGrpChtModal" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title"><span class="fa fa-comments"></span> Edit Group</h4>
      </div>

<div class="scroll" style="height:500px;">
      <div class="modal-body">
        
          <div class="content-frame">
            <div class="row" id="">

  <div id="editGrpView">
    <div class="col-md-4">
             
              <div class="panel panel-default text-center">
                <div class="panel-body">
                  <form class="form-horizontal">
                  
                      <div class="profile-image grpIcon"> <img id="EditGrpImg_url" alt="Nadia Ali" src="E2Forums-New/img/user3.jpg"> </div>
          
       
                      <div class="form-group">
                        <div class="col-md-12"> 
                        <h6><strong id="editGrpName"> </strong></h6>
                        <%--<small>0 Members in your group</small>--%>
                        </div>
                      </div>
  <button id="editAddMembBtn" class="btn btn-primary btn-rounded" type="button">Add Group Members</button>            
<button id="GroupEditbtn" type="button" class="btn btn-info btn-rounded">Edit</button>
                   
                  </form>
                </div>
              </div>
</div>


  </div>

                <div class="panel panel-default" id="GroupEdit">

<div class="closeBtn"><i data-original-title="Close Edit Panel" class="fa fa-times" title="" data-placement="top" data-toggle="tooltip" id="I1"></i></div>


                <div class="panel-body">
                  <p>Edit Group Information.</p>

                   <form class="form-horizontal" >
                    <div class="form-group">
                      <div class="col-md-2">
                        <div class="form-group">
                          <div class="col-md-12">
                            <input type="file" class="fileinput btn-primary"  id="Editfilename" name="Editfilename"  title="Browse file"/>
                            <span class="help-block">Group Icon</span> </div>
                        </div>
                      </div>
                      <div class="col-md-8">
                        <div class="form-group">
                          <div class="col-md-12">
                            <div class="input-group"> <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                              <input type="text" id="txt_editgroup_name" class="form-control">
                            </div>
                            <span class="help-block">Enter Group Name</span> </div>
                        </div>
                      </div>
                      <div class="col-md-2">
                        <button onclick="return edit_chatgrp_info_update()" class="btn btn-success btn-block"><span  class="fa fa-refresh"></span>Update</button>
                      </div>
                    </div>
                 
                       </form>
                </div>
              </div>


            </div>
           
                 <div class="list-group list-group-contacts border-bottom push-down-10"> 
                     <h5><strong>Existing Member</strong></h5>
                     <div class="addSearch scroll" style="height:200px;">
            <div class="content-frame-right"  id="editExistingMembers">
           


               

        </div>
             </div>
           </div>
            
          </div>

   
     <div style="display: none;" id="editsearchTraget" class="addSearch">
    <div class="closeBtn"><i id="closeBtnSearchBar" data-toggle="tooltip" data-placement="top" title="" class="fa fa-times" data-original-title="Close Seach Panel"></i></div>
    <div class="content-frame-top" id="Div3">
        <div class="form-group">
            <div class="row">
                <div class="col-md-8">
                    <div class="input-group">
                        <div class="input-group-addon"> <span class="fa fa-search"></span> </div>
                        <input type="text" id="EditgroupMemberTobesearchtxt" placeholder="Who are you looking for?" class="form-control">
                        <div class="input-group-btn">
                            <button class="btn btn-primary" onclick="return edit_chat_group_member_search()">Search</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="content-frame-right">
        <h5><strong>Add New Member</strong></h5>
         <div class="scroll" style="height: 200px;">
        <div id="Edit_chat_grp_Member_search_list" class="list-group list-group-contacts border-bottom push-down-10">
        </div>
         </div>
    </div>
</div>
</div>
     </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
<!-- EDIT GROUP CHAT END-->


<!-- GROUP VIEW MEMBER START-->
<div id="GrpChtMbrModal" class="modal fade" role="dialog">

</div>
<!-- GROUP VIEW MEMBER END-->

 <script src="PagesJs/chat.js" type="text/javascript"></script>
 <script src="PagesJs/Message.js" type="text/javascript"></script>
 <script src="PagesJs/Comon.js" type="text/javascript"></script>
 <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
    <script src="js/app.js"></script> 
<!-- Chat Module Jquery 6 Nov. 2015-->   
<script type="text/javascript">
    $(document).ready(function () {
      

        $(".add-grp-mem-btn").click(function () {
            $("#addSearch").fadeIn(600);
        })

        $("#closeBtn").click(function () {
            $("#addSearch").fadeOut(600);
        })

        $(".removeDiv").click(function () {
            $(this).parent().remove();
        });

        $("#GroupEditbtn").click(function () {
            $("#GroupEdit").fadeIn(600);
        });

    });
</script>

      <script language="javascript"  type="text/javascript">
          $(function () {

              if ("<%=IsAdmin%>" == 'True') {
                  $('.adminLinks').show();
                  $('.UserLinks').hide();
              }
              if (VarUserTypeID != 2) {
                  $('.UserLinks').show();
              }
              maxLength = $("textarea#txtmsg").attr("maxlength");
              $("textarea#txtmsg").after("<div><span id='remainingLengthTempId'>"
                    + maxLength + "</span> remaining</div>");

              $("textarea#txtmsg").bind("keyup change", function () { checkMaxLength(this.id, maxLength); })


          });
      </script>