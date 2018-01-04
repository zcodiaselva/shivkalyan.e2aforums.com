<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDocuments.aspx.cs" Inherits="User_pro" %>

<%@ Register Src="~/User/UserControls/SideBarMenuControl.ascx" TagPrefix="HM" TagName="SideBarMenuControl" %>
<%@ Register Src="~/User/UserControls/footerControl.ascx" TagPrefix="HM" TagName="footerControl" %>
<%@ Register Src="~/User/UserControls/footerScriptControl.ascx" TagPrefix="HM" TagName="footerScriptControl" %>
<%@ Register Src="~/User/UserControls/TopMenuBarControl.ascx" TagPrefix="HM" TagName="TopMenuBarControl" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
<!-- META SECTION -->
<title>E2aforums Admin</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
     <div class="page-content-wrap"> 
      <div class="inner-content-wrap"> 


                <!-- Education Block -->
                <div class="block" id="ChapterBlock">
                    <div class="tab-content">
                        <!-- Forum -->

                        <div class="block-title">
                           <h2 id="headerMainTitle" class="modal-title" style="color:#F31455;"></h2>
                            <a data-toggle="modal" href="#modal-Add-Document">
                                <button type="button" id="btnAddDocument" class="btn btn-sm btn-primary" style="float: right; margin-right: 30px; margin-top: 5px;"
                                    onclick="return ResetForm();">
                                    ADD</button></a>
                        </div>
                        <!-- Datatables Content -->
                        <div class="table-responsive">
                           <%-- <div id="TblChapterDetails_wrapper" class="dataTables_wrapper" role="grid">--%>

                                <div class="row">
                                </div>

                                <table id="TblUserDocument" class="table table-vcenter table-condensed table-bordered">
                                </table>
                           <%-- </div>--%>
                        </div>

                        <div id="modal-Add-Document" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
                            <form id="form_Document" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered" onsubmit="return false;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" id="btn_addClose" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h3 id="headerTitle" class="modal-title">Add Document
                                            </h3>
                                        </div>
                                        <fieldset>
                                      
                                            <div class="form-group">
                                                <label class="col-md-3 control-label" for="text-input">
                                                    Description:</label>
                                                <div class="col-md-8">
                                                    <textarea id="txtTitleDesc" cols="20" rows="4" name="txtTitleDesc" class="form-control" placeholder="Description"></textarea>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Document:
                                                </label>
                                                <div class="col-md-6">
                                                    <div class="input-group">
                                                        <input type="file" id="FileUpload" name="FileUpload" />
                                                        <label class="col-md-12" id="lblFileName">
                                               
                                                </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>

                                        <div class="modal-footer">
                                            <button type="button" id="BtnSaveDocument" class="btn btn-sm btn-primary">
                                                Save</button>
                                            <button type="button" id="BtnEditDocument" class="btn btn-sm btn-primary"
                                                style="display: none;">
                                                Update</button>
                                            <button type="button" class="btn btn-sm btn-default" data-dismiss="modal" style="display: none;">
                                                Cancel</button>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>

                    </div>
                </div>

              
                <HP:UserProfile ID="UserProfile" runat="server" />
                <!-- Education Block -->
            


          </div>
         </div>







</div><!-- Page Container End -->

    <!-- Footer BOX-->
    <HM:footerControl runat="server" ID="footerControl" />

<!-- END Footer Box --> 
    <!---Comman Footer Scripts Start -->
    <HM:footerScriptControl runat="server" ID="footerScriptControl" />

    <!-- Comman Footer Scripts End--->


    <!-- Delete--->
  </div>

    
     
    <script src="../js/SJGrid.js"></script>
    <!-- Bootstrap.js, Jquery plugins and Custom JS code -->
    <script src="js/toastr.js"></script>
  
    <script src="js/plugins.js"></script>
    <script src="PagesJs/UserDocument.js" type="text/javascript"></script>
    <script src="PagesJs/Common.js" type="text/javascript"></script>
    <script src="js/app.js"></script>
      <script src="js/ajaxfileupload.js"></script>
    <script language="javascript" type="text/javascript">

    </script>
    
</body>
</html>
