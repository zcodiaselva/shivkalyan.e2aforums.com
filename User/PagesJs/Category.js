var mvarCategoryID = -1;

$(function () {
    $('#CategoryList-a').addClass("active");
    GetCategoryListing();
    $('#form_Categories').validate({
     
        highlight: function (e) {
            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            // You can use the following if you would like to highlight with green color the input after successful validation!
            e.closest('.form-group').removeClass('has-success has-error'); // e.closest('.form-group').removeClass('has-success has-error').addClass('has-success');
            e.closest('.help-block').remove();
        },
        rules: {
            txtName: {
                required: true
            },
            txtDesc: {
                required: false
            }
        },
        messages: {
            txtName:
                {
              required: 'Please enter name '
                        },
            txtDesc:
              {
           required: 'Please enter Description '
                   }
        }

    });


    $('#BtnSaveCategory').click(function () {
        if ($('#form_Categories').valid()) {
            AddEditCategory();

        } else {
            //alert('provide email and password to conitnue..');
            return false;
        }
    });
    $('#BtnEditCategory').click(function () {
        if ($('#form_Categories').valid()) {
            AddEditCategory();

        } else {
            //alert('provide email and password to conitnue..');
            return false;
        }
    });
});

function GetCategoryListing() {

    $("#TblCategory").empty();
    $("#TblCategory").SJGrid
    (
    {
        url: 'Ajax/AjaxUser.aspx?Mode=GETCATEGORYLISTING',
        dataType: 'xml',
        rp: 5,
        checkboxes: false,
        attachment: false,
        colModel: [
                { display: '# ', name: 'Row', width: 20, sortable: false, align: 'left' },
                { display: 'Categories', name: 'Category', width: 130, sortable: false, align: 'left' },
                { display: 'Topics', name: 'Topics', width: 100, sortable: false, align: 'left' },
                { display: 'Posts ', name: 'Posts', width: 100, sortable: false, align: 'left' },
                { display: 'Last Post', name: 'PostTime', width: 100, sortable: false, align: 'left' },
                { display: 'Action', width: 160, sortable: false, align: 'left' }
        ],
        generateFooter: false,
        sortname: "Title",
        sortorder: "desc",
        pagination: true,
        searchSection: true,
        qtype: "Title",
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

function DeleteCategory(pvarCategoryID) {

    var varApproved = "Are  you sure you want to delete this Category and its topics and posts?";
    if (confirm(varApproved)) {

        $.post("Ajax/AjaxUser.aspx",
                  {

                      Mode: "DELETECATEGORY",
                      CategoryID: pvarCategoryID
                  },

                  function (varResponseData) {

                      if (varResponseData != "") {

                          if (varResponseData == "SUCCESS") {
                            
                              toastr["success"]("Category deleted successfully");
                              //window.location.reload();
                              GetCategoryListing();
                          }
                      }


                  });
    }
    return false;

}

function showEditCategoryModel(pvarCategoryID) {
    mvarCategoryID=pvarCategoryID
    $('#BtnSaveCategory').hide();
    $('#BtnEditCategory').show();
    $('#headerTitle').html("Edit Category");
    $('#modal-Add-Category').show();
    $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "GETCATEGORYDETAILS",
                CategoryID: mvarCategoryID
            },

          function (VarResponseData) {
              $(VarResponseData).find('Response').each(function () {
                  $(VarResponseData).find('CategoryData').each(function () {
                      if ($(this).find('Title').text() != "") {
                          $('#txtName').val($(this).find('Title').text());
                      }
                      if ($(this).find('Description').text() != "") {
                          $('#txtDesc').val($(this).find('Description').text());
                      }

                  });
              }); //end of Response   
          });                 //End of Ajax

    return false;
}

function AddEditCategory() {
   
          $.post("Ajax/AjaxUser.aspx",
            {
                Mode: "ADDCATEGORY",
                Title: $('#txtName').val(),
                Description: $('#txtDesc').val(),
                CategoryID: mvarCategoryID
            },
                function (VarResponseData) {

                    if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                        if (mvarCategoryID == -1) {
                            toastr.options = { "onHidden": function () { $('.close').click(); GetCategoryListing(); } };
                            $('.close').click();
                            toastr["success"]("Category added successfully");
                          
                            mvarCategoryID = -1;
                            GetCategoryListing();
                        }
                        else {
                            toastr.options = { "onHidden": function () { $('.close').click(); GetCategoryListing(); } };
                            $('.close').click();
                            toastr["success"]("Category updated successfully");
                         
                            mvarCategoryID = -1;
                            GetCategoryListing();
                          
                        }
                    }
                    else if (VarResponseData == "Already Exists" || VarResponseData == "ALREADY EXISTS") {
                        toastr["error"]("Category Name already exists");
                      
                    }
                });


    return false;
}

function ResetForm() {
    $('.form-group').removeClass('has-success has-error');
    $('.help-block').remove();
    $('.error').hide();
    document.forms["form_Categories"].reset();
    $('#headerTitle').html("Add Category");
 
   
}

