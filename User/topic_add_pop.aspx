<%@ Page Language="C#" AutoEventWireup="true" CodeFile="topic_add_pop.aspx.cs" Inherits="User_topic_add_pop" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form  id="form_Topic" runat="server" action="" method="post" enctype="multipart/form-data"
                                class="form-horizontal form-bordered"  >
                                
       <asp:Label ID="lbl_message" runat="server" Text="Label"></asp:Label>
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h3 id="headerTitle1" class="modal-title">Add Topic
                                            </h3>
                                        </div>
                                          
                                        <fieldset>
                                             <div id="outputMessage"></div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Title:
                                                </label>
                                              
                                                   <div class="col-md-3" style="width: 240px;">
                                             
                                                 <asp:TextBox id="txtTitle"  runat="server" placeHolder="Enter title ......." /><br />
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Topic Title is required !" ForeColor="Red"  ControlToValidate="txtTitle" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                                </div>
                                              
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label" for="text-input">
                                                    Description:</label>
                                                <div class="col-md-8">
                                                    <%--<textarea id="txtDesc" cols="20" rows="4" name="txtDesc" class="form-control" placeholder="Description"></textarea>--%>
                                                  <CKEditor:CKEditorControl id="txtDesc" name="txtDesc" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Topic Descripation is required !" ForeColor="Red" ControlToValidate="txtDesc" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                                                                            
 
                                                     </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">
                                                    Category:
                                                </label>
                                                <div class="col-md-3" style="width: 240px;">
                                             
                                                   <asp:DropDownList  runat="server" id="cmb_Categories1">

                                                   </asp:DropDownList>
                                                </div>
                                            </div>

                                        </fieldset>

                                        <div class="modal-footer">
                                       
                                            <asp:Button  runat="server" OnClick="saveClick" name="Save" Text="Save"  ID="saveTopicButton" ValidationGroup="abc"/>
                                            
                                        </div>
                                    </div>
                                </div>
                            </form>
</body>
</html>
