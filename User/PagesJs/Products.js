var mvarProductID = -1;
$(function () {
    
    $('#Products-a').addClass("active");
    GetProductsListing();

    $('#BtnSaveProduct').click(function () {
       
            AddNewProducts();
     });
    $('#BtnEditProduct').click(function () {
        AddNewProducts();

    });
});



function GetProductsListing() {

    $("#TblProducts").empty();
    $("#TblProducts").SJGrid
    (
    {
        url: 'Ajax/AjaxCustomers.aspx?Mode=GETPRODUCTSLISTING',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Title', name: 'Title', width: 100, sortable: false, align: 'left' },
                { display: 'Description', name: 'Description', width: 120, sortable: false, align: 'left' },
                { display: 'Start Date ', name: 'StartDate', width: 100, sortable: false, align: 'left' },
                { display: 'Last Date', name: 'LastDate', width: 100, sortable: false, align: 'left' },
                { display: 'Action', width: 160, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "DateAndTime",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "DateAndTime",
        query: '',
        onError: function (errorMsg) {
            alert("error");
        },
        onSuccess: function () {

        }
    }

    );
    return false;
}

function DeleteProduct(pvarProductID) {

    var varApproved = "Are  you sure you want to delete this product?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxCustomers.aspx",
                  {

                      Mode: "DELETEPRODUCT",
                      ProductID: pvarProductID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {

                              toastr["success"]("Product deleted successfully");
                              GetProductsListing();
                          }
                      }


                  });
    }
    return false;

}

function showEditProductModel(pvarProductID) {
    mvarProductID = pvarProductID;
    $('#modal-Add-Products').addClass('modal');
    $('#BtnSaveProduct').hide();
    $('#BtnEditProduct').show();
    $('#headerTitle').html("Edit Product");
    $('#btn_addClose').click();
    $.post("Ajax/AjaxCustomers.aspx",
            {
                Mode: "GETPRODUCTDETAILS",
                ProductID: mvarProductID
            },

          function (VarResponseData) {

              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('ProductData').each(function () {

                      if ($(this).find('Title').text() != "") {
                          $('#txtTitle').val($(this).find('Title').text());
                      }
                      if ($(this).find('Description').text() != "") {
                          $('#txtDesc').val($(this).find('Description').text());
                      }
                      if ($(this).find('StartDate').text() != "") {
                          $('#datepickerStart').val($(this).find('StartDate').text());
                      }
                      if ($(this).find('LastDate').text() != "") {
                          $('#datepickerLast').val($(this).find('LastDate').text());
                      }
                  });
              }); //end of Response   
          });                  //End of Ajax

    return false;
}

function AddNewProducts() {
    var varTitle = $('#txtTitle').val();
    var varDescription = $('#txtDesc').val();
    var varStartDate = $('#datepickerStart').val();
    var varLastDate = $('#datepickerLast').val();

    if (varTitle.trim() == "") {
        toastr["error"]("Please enter title");
        return false;
    }

    else if (varStartDate == null || varStartDate == "") {
        toastr["error"]("Please select a start date..");
        return false;
    }
    else if (varLastDate == null || varLastDate == "") {
        toastr["error"]("Please select end date..");
        return false;
    }

    $.post("Ajax/AjaxCustomers.aspx",
                   {
                       Mode: "ADDNEWPRODUCTS",
                       Title: varTitle,
                       Description: varDescription,
                       StartDate: varStartDate,
                       LastDate: varLastDate,
                       ProductID: mvarProductID

                   },
                       function (VarResponseData) {

                           if (VarResponseData == "SUCCESS") {
                               if (mvarProductID == -1) {
                                   toastr.options = { "onHidden": function () { $('.close').click(); GetProductsListing(); } };
                                   $('.close').click();
                                   toastr["success"]("Product added successfully");
                                   document.forms["form_Products"].reset();
                                   mvarProductID = -1;
                               }
                               else {
                                   toastr.options = { "onHidden": function () { $('.close').click(); GetProductsListing(); } };
                                   $('.close').click();
                                   toastr["success"]("Product details updated successfully");
                                   document.forms["form_Products"].reset();
                                   mvarProductID = -1;
                               }
                               NProgress.done();
                           }
                           else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                               toastr["error"]("Product already exists");

                           }
                       });

    return false;
}
function ResetForm() {
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    document.forms["form_Products"].reset();
    $('#headerTitle').html("Add Product");
    $('#BtnSaveProduct').show();
    $('#BtnEditProduct').hide();
    $('#headerTitle').html("Add Product");

}
