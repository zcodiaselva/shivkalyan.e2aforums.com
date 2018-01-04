<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadExcelFile.aspx.cs" Inherits="User_UploadExcelFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">

    <title>Customers</title>

    <meta name="viewport" content="width=device-width,initial-scale=1,maximum-scale=1.0">

    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="img/circularlogo.png">
    <link rel="apple-touch-icon" href="img/icon57.png" sizes="57x57">
    <link rel="apple-touch-icon" href="img/icon72.png" sizes="72x72">
    <link rel="apple-touch-icon" href="img/icon76.png" sizes="76x76">
    <link rel="apple-touch-icon" href="img/icon114.png" sizes="114x114">
    <link rel="apple-touch-icon" href="img/icon120.png" sizes="120x120">
    <link rel="apple-touch-icon" href="img/icon144.png" sizes="144x144">
    <link rel="apple-touch-icon" href="img/icon152.png" sizes="152x152">
    <!-- END Icons -->

    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <%-- <link rel="stylesheet" href="css/bootstrap.min.css">--%>
    <link href="../css/Bootstrap2.css" rel="stylesheet" />
    <link href="css/toastr.css" rel="stylesheet" />
    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="css/plugins.css">

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="css/main.css">

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->

    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link href="css/themes/fancy.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/themes.css">
    <!-- END Stylesheets -->

    <!-- Modernizr (browser feature detection library) & Respond.js (Enable responsive CSS code on browsers that don't support it, eg IE8) -->
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <link href="css/datepicker.css" rel="stylesheet" type="text/css" />

</head>
<body style="background-color: transparent;">



    <form id="form_UploadExcel" runat="server">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" id="btn_close" data-dismiss="modal" aria-hidden="true" onclick="return HideModal();">
                        &times;</button>
                    <h3 id="headerTitle1" class="modal-title">Upload Excel sheet of Customer Details
                    </h3>
                </div>
                 <fieldset>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="ProfilePic">
                        Choose excel sheet:
                    </label>
                    <div class="col-md-6">
                        <%--<input type="file" id="UploadExcel" name="UploadExcel" />--%>
                        <asp:FileUpload ID="FileUpload_TBSxls" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload_TBSxls"
                            ErrorMessage="* required" ValidationGroup="UploadPA"></asp:RequiredFieldValidator>
                        <%-- <label class="col-md-12" id="lblFileName"></label>--%>
                    </div>
                </div>
                 
                <div class="form-group">

                    <div class="col-md-6">
                        <asp:Label ID="lblUpload" runat="server" ForeColor="#FF0033" Visible="False" />
                        <%-- <label class="col-md-12" id="lblUpload"></label>--%>
                    </div>
                </div>

                <div class="form-group">
                    
                    <div class="col-md-12" style="text-align:center;">
                        <%--<input type="file" id="UploadExcel" name="UploadExcel" />--%>
                        <a href="UploadedCvs/SampleCustomerDetails.csv">Click here to download Customer Details Format.</a>
                        <%-- <label class="col-md-12" id="lblFileName"></label>--%>
                    </div>
                </div>
                     </fieldset>
                <div class="modal-footer">
                    <asp:Button ID="Button1" class="btn btn-sm btn-primary" runat="server" Text="Upload"
                        Font-Bold="True" ValidationGroup="UploadPA" OnClick="Button1_Click" OnClientClick="return HideModal();"/>
                    <asp:Label ID="Label1" runat="server" ForeColor="#FF0033" Visible="False" />
                    <%--<button type="button" id="BtnUploadExcel" class="btn btn-sm btn-primary">
                                                Upload</button>--%>
                    <%-- <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                                                Cancel</button>--%>
                </div>
            </div>
        </div>
    </form>

    <script language="javascript" type="text/javascript">
   
        function HideModal() {
             window.parent.HideUploadModal();
       }

    </script>
</body>
</html>

