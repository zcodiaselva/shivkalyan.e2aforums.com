<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserProfileControl.ascx.cs" Inherits="User_UserControls_UserProfile" %>
<script src="js/jquery-1.7.2.js" type="text/javascript"></script>
 <div id="modal-regular-Profile" class="modal" tabindex="-1" role="dialog" aria-hidden="true" style="display: none;">
                <form action="" method="post" enctype="multipart/form-data" class="form-horizontal "   onsubmit="return false;">
                    <div class="modal-dialog customModel">



                        <div class="modal-content">
<div class="profilePopHeader">
       <div class="profilePic">
                              <div class="form-control-static" id="profilepic">

                                    </div>
       </div>
       <div class="profileDes">
           <span class="profileName" id="p_name"></span><br>
           <span class="profileEmail" id="p_email"></span>
           <p id="lbl_aboutME"></p>
       </div> 
       <div class="profileAddress">
       <div data-dismiss="modal" class="closePopup">Press esc to exit <i class="fa fa-sign-in"></i></div>
           <p>
<i>Address:</i><br>
<span id="p_address1"></span><br>
<span id="p_City"></span>
           </p>
       </div>
     </div>







<div class="profilePopBody">
          <div class="row">
              <div class="col-md-4">
              <ul class="profileDetail">
                  <li><label><strong>Organization:</strong> <span id="p_Organization"></span></label></li>
    
                  <li><label><strong>Occupation:  </strong>  <span id="p_Occupation"></span></label></li>
                  <li><label><strong>MGA:  </strong>  <span id="p_MGA"></span></label></li>
                  <li><label><strong>In Business since:</strong>  <span id="p_InBusinessSince"></span></label></li>
              </ul>
                  
              </div>

              <div class="col-md-4">
              <ul class="profileDetail">
                  <li><label><strong>Dealer Name:</strong> <span id="p_DealerName"></span></label></li>
                   <li><label><strong>Designation:</strong>  <span id="p_Designation"></span></label></li>
                  <li><label><strong>Mobile:</strong>  <span id="p_Mobile"></span></label></li>
                  <li><label><strong>Governing Body:  </strong>  <span id="p_GoverningBody"></span></label></li>
                 
              </ul>
                  
              </div>

              <div class="col-md-4">
                                             <div class="form-group" id="div_ProfileVideo" >
                       
                   
                            <div class="input-group" id="divYoutubeVideo">
                             <%--  <iframe id="val_ProfileVideo" title="YouTube video player" style="margin:0; padding:0;"></iframe>--%>
                            </div>
                              
                        </div>
              </div>
          </div>
          </div>



 


   





           
                        </div>



                    </div>

                </form>

</div>



