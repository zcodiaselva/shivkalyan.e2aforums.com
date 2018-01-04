$(function () {
    $('#CategoryList-a').addClass("active");
    GetForumCategory();
    
});

function GetForumCategory() {

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
                { display: '<i class=\"gi gi-user\" style=\"text-allign:center\"></i> ', name: 'PicName', width: 20, sortable: false, align: 'left' },
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
        searchSection: false,
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
                               window.location.reload();
                          }
                      }


                  });
    }
    return false;

}