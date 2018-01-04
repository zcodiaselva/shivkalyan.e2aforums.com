<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LatestNews.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>





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

               <div class="page-title">
      <h2><i class="fa fa-book"></i> Latest News
      </h2>

     <button id="addPost" onclick="return latestNewsGetMy();" class="btn btn-success btn-condensed addPost pull-right"><i class="fa fa-plus"></i> Add Post</button>
    </div>
    <!-- PAGE CONTENT WRAPPER -->
    



  <div class="col-md-12" id="uploadTechTip" style="display:none;">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                <div class="closeBtn"><i data-original-title="Close Seach Panel" class="fa fa-times" title="" data-placement="top" data-toggle="tooltip" id="closeBtnSearchBar"></i></div>

                                    <h3><span class="fa fa-mail-forward"></span> File Input</h3>
                                    <p>Upload your file here</p>    
                  <form>
                                     <div class="form-horizontal">
                    <div class="form-group">
                      <div class="col-md-2">
                        <div class="form-group">
                          <div class="col-md-12">
                  
                            <input class="fileinput btn-primary" id="fileUpload" name="fileUpload" title="Browse file" type="file">
                            <span class="help-block">News LetterFile</span> </div>
                        </div>
                      </div>
                      <div class="col-md-8">
                        <div class="form-group">
                          <div class="col-md-12">
                            <div class="input-group"> <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                              <input id="latestNewsFileHeading" class="form-control" type="text">
                            </div>
                            <span class="help-block">Enter Group Name</span> </div>
                        </div>
                      </div>
                      <div class="col-md-2">
                        <button onclick="return latestNews_send()" class="btn btn-success btn-block"><span class="fa fa-refresh"></span> Create</button>
                      </div>
                    </div>
                 
                       </div> 
                      </form>                           

<div class="scroll" style="height: 230px; padding-top:30px;"> 

    <div id="MylatestNewsList">


    </div>

                                               
                                </div>


                                </div>
                            </div>
                            
</div>











    <div class="row">
      <div id="latestNewsGetAll" class="col-md-12">
       
    
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
                              <input id="txt_editln_heading" class="form-control" type="text">
                            </div>
                            <span class="help-block">Enter Group Name</span> </div>
                        </div>
                      </div>
                      <div class="col-md-2">
                        <button onclick="return latestNews_info_update()" class="btn btn-success btn-block"><span class="fa fa-refresh"></span>Update</button>
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

        <script src="PagesJs/latestNews.js" type="text/javascript"></script>
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

        latestNewsMemberAssignCheck('<%=UseIDCurent%>');
        latestNewsGetAll();
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