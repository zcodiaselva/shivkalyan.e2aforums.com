<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Topic_add_new.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>E2aforums Admin</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link rel="icon" href="favicon.ico" type="image/x-icon" />
<!-- END META SECTION -->
<!-- CSS INCLUDE -->
<link rel="stylesheet" type="text/css" href="../E2Forums-New/css/cropper/cropper.min.css"/>
<!--  EOF CSS INCLUDE -->
<!-- CSS INCLUDE -->
<link rel="stylesheet" type="text/css" id="theme" href="../E2Forums-New/css/theme-default.css"/>
<link rel="stylesheet" type="text/css" id="Link1" href="../E2Forums-New/css/custom.css"/>
<!-- EOF CSS INCLUDE -->
</head>
<body>
      
<!-- START PAGE CONTAINER -->
<div class="page-container page-navigation-top-fixed">


<!-- Top Menu Control Start  --> <HM:SideBarMenuControl runat="server" ID="SideBarMenuControl1" />
   
    <!-- Top Menu Control End  -->

<!-- PAGE CONTENT -->
<div class="page-content">
    <!-- Side Menu Control Start  -->
    <HM:TopMenuBarControl runat="server" ID="TopMenuBarControl" />
    <!-- side Menu Control End  -->
     <div class="page-content-wrap bgn"> 
<div class="inner-content-wrap">
    <div class="block">
<div class="tab-content">
    <div class="block-title">
           <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label><br />
                                <h2>Add Topic</h2>
                            </div>

                     <form  id="form_Topic" runat="server" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered"  >
                                
      
                  
                      
                                        
                                        <fieldset>
                                             <div id="Div1"></div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Title:
                                                </label>
                                              
                                                   <div class="col-md-4">
                                             
                                                 <asp:TextBox id="txtTitle" CssClass="form-control"  runat="server" placeHolder="Enter Title ..." /><br />
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Topic Title is required !" ForeColor="Red"  ControlToValidate="txtTitle" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                                </div>
                                              
                                                  <label class="col-md-2 control-label">
                                                    Category:
                                                </label>
                                                <div class="col-md-4">
                                             
                                                   <asp:DropDownList CssClass="form-control" runat="server" id="cmb_Categories1">

                                                   </asp:DropDownList>
                                                </div>


                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label" for="text-input">
                                                    Description:</label>
                                                <div class="col-md-10">
                                                    <%--<textarea id="txtDesc" cols="20" rows="4" name="txtDesc" class="form-control" placeholder="Description"></textarea>--%>
                                                  <CKEditor:CKEditorControl id="txtDesc" name="txtDesc" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Topic Descripation is required !" ForeColor="Red" ControlToValidate="txtDesc" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                                                                            
 
                                                     </div>
                                            </div>


                                        </fieldset>

                                        <div class="modal-footer">
                                       
                                            <asp:Button  runat="server" CssClass="btn btn-sm btn-primary" OnClick="saveClick" name="Save" Text="Save"  ID="saveTopicButton" ValidationGroup="abc"/>

                                             <asp:Button  runat="server" CssClass="btn btn-sm btn-primary" OnClick="cancelClick" name="Save" Text="Cancel"  ID="Btn_cancel" ValidationGroup="aabc"/>
                                            
                          </div>



                            </form>
    </div>
        </div>
    </div>
         </div> 
   
                

            <HP:UserProfile ID="UserProfile" runat="server" />


         
         </div>

</div><!-- Page Container End -->



<!-- Edit Tip Tech -->


<div id="editTipTech" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Edit Topic</h4>
      </div>
      <div class="modal-body">
        
          
          <form>
                   <div class="form-horizontal">
                        <div id="outputMessage"></div>
                    <div class="form-group">
                      <div class="col-md-2">
                        <div class="form-group">
                          <div class="col-md-12">
                         
                            <input class="fileinput btn-primary" id="Editfilename" name="Editfilename" title="Browse file" type="file">
                            <span class="help-block">Choose File</span> </div>
                        </div>
                      </div>
                      <div class="col-md-8">
                        <div class="form-group">
                          <div class="col-md-12">
                            <div class="input-group"> <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                              <input id="txt_edittt_heading" class="form-control" type="text">
                            </div>
                            <span class="help-block">Enter Group Name</span> </div>
                        </div>
                      </div>
                      <div class="col-md-2">
                        <button onclick="return tech_tip_info_update()" class="btn btn-success btn-block"><span class="fa fa-refresh"></span>Update</button>
                      </div>
                    </div>
                 
                       </div>
              </form>
                
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>




    <!-- Footer BOX-->
    <HM:footerControl runat="server" ID="footerControl" />

<!-- END Footer Box --> 
    <!---Comman Footer Scripts Start -->
    <HM:footerScriptControl runat="server" ID="footerScriptControl" />

    <!-- Comman Footer Scripts End--->


    <!-- Delete--->
  </div>
 <!-- Scroll to top link, initialized in js/app.js - scrollToTop() -->
    <a href="#" id="to-top"><i class="fa fa-angle-double-up"></i></a>

        <script src="PagesJs/techtips.js" type="text/javascript"></script>
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
 
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>  
    <script src="js/FileReader.js"></script>  
    

    <script src="js/ajaxfileupload.js"></script>
     <script src="PagesJs/Common.js" type="text/javascript"></script>
    <script src="js/jquery.tooltipster.js"></script>
   
    <script type="text/javascript" >

        TechTipsMemberAssignCheck('<%=UseIDCurent%>');
        TechTipsGetAll();
    </script>
    
    
    
    <style>
.profileAddress {
  color: #fff;
  float: left;
  position: absolute;
  right: 22px;
  width: 260px;
}
.profileDes {
  float: left;
  overflow-y: hidden;
  text-align: justify;
  width: 83%;
}
.profileAddress > p {
  display: none;
}
.profilePopHeader {
  float: left;
  height: auto;
}
.newsletter-info p {
  font-size: 11px;
}
</style>
</body>
</html>




<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Modal Header</h4>
      </div>
      <div class="modal-body">
        <p>Some text in the modal.</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>