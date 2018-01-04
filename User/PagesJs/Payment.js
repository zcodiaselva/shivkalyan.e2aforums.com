var mvarUserID = -1;

$(function () {
    NProgress.start();
});
function GetPaymentProfile() {

    $('#paycontent').append("Loading....");

    $.post("Ajax/Payment.aspx",
            {
                Mode: "GETPAYMENTPROFILE",

            },
            function (VarResponseData) {

                if (VarResponseData != "") {
                    $('#paycontent').empty();
                    $('#paycontent').append(VarResponseData);

                    NProgress.done();
                }
                else {
                    $('#paycontent').empty();
                    $('#paycontent').append("No Payment Detail Found .");

                    NProgress.done();
                }



            });

    return false;
}

function GetPaymentDetails() {

    $('#paycontent').append("Loading....");

    $.post("Ajax/Payment.aspx",
            {
                Mode: "GETPAYMENTDETAILS",

            },
            function (VarResponseData) {

                if (VarResponseData != "") {
                    $('#paycontent').empty();
                    $('#paycontent').append(VarResponseData);

                    NProgress.done();
                }
                else {
                    $('#paycontent').empty();
                    $('#paycontent').append("No Payment Detail Found .");

                    NProgress.done();
                }



            });

    return false;
}

function GetPaymentDetailsMy() {

    $('#paycontent').append("Loading....");

    $.post("Ajax/Payment.aspx",
            {
                Mode: "GETPAYMENTDETAILSMY",

            },
            function (VarResponseData) {

                if (VarResponseData != "") {
                    $('#paycontent').empty();
                    $('#paycontent').append(VarResponseData);

                    NProgress.done();
                }
                else {
                    $('#paycontent').empty();
                    $('#paycontent').append("No Payment Detail Found .");

                    NProgress.done();
                }



            });

    return false;
}


// PaymentDetails.aspx PAGE

function GetPaymentDetailsReqID(pvarReqID) {
   
    NProgress.start();
    $.post("Ajax/Payment.aspx",
    {
        Mode: "GETPAYMENTDETAILSREQID",
        PReqID: pvarReqID
       
    },
    function (VarResponseData) {
        $(VarResponseData).find('Response').each(function () {
            $(VarResponseData).find('AdminData').each(function () {
                console.log("hello");

                
                if ($(this).find('txn_id').text() != "") {
                    $('#ptxn_id').html($(this).find('txn_id').text());
                    $('#ptxn_id').attr('readonly', 'readonly');
                }

                if ($(this).find('txn_type').text() != "") {
                    $('#ptxn_type').html($(this).find('txn_type').text());
                    $('#ptxn_type').attr('readonly', 'readonly');
                }
                
                if ($(this).find('payer_id').text() != "") {
                    $('#ppayer_id').html($(this).find('payer_id').text());
                    $('#ppayer_id').attr('readonly', 'readonly');
                }

                
                if ($(this).find('first_name').text() != "") {
                    if ($(this).find('last_name').text() != "")
                        $('#pbuy_FullName').html($(this).find('first_name').text() + " " + $(this).find('last_name').text());
                    $('#pbuy_FullName').attr('readonly', 'readonly');
                }
                

                if ($(this).find('payer_email').text() != "") {
                    $('#ppayer_email').html($(this).find('payer_email').text());
                    $('#ppayer_email').attr('readonly', 'readonly');
                }

              
                if ($(this).find('payment_date').text() != "") {
                    $('#ppay_res_date').html($(this).find('payment_date').text());
                    $('#ppay_res_date').attr('readonly', 'readonly');
                }
                
                if ($(this).find('str_out_Response').text() != "") {
                    $('#pstr_out_Response').html($(this).find('str_out_Response').text());
                    $('#pstr_out_Response').attr('readonly', 'readonly');
                }
                

                if ($(this).find('req_id').text() != "") {
                    $('#preq_id').html($(this).find('req_id').text());
                    $('#preq_id').attr('readonly', 'readonly');
                }

                if ($(this).find('payment_status').text() != "") {
                    $('#pout_flag_val').html($(this).find('payment_status').text());
                    $('#pout_flag_val').attr('readonly', 'readonly');
                }

                if ($(this).find('item_number').text() != "") {
                    $('#pitem_number').html($(this).find('item_number').text());
                    $('#pitem_number').attr('readonly', 'readonly');
                }

              
                if ($(this).find('Full_Name').text() != "") {
                    $('#pFull_Name').html($(this).find('Full_Name').text());
                    $('#pFull_Name').attr('readonly', 'readonly');
                }
             
                if ($(this).find('EMail').text() != "") {
                    $('#pEMail').html($(this).find('EMail').text());
                    $('#pEMail').attr('readonly', 'readonly');
                }

                

                if ($(this).find('item_number').text() != "") {
                    if ($(this).find('item_number').text() =="1111")
                    {
                        $('#basicPlanWrap').show();
                        $('#proPlanWrap').hide();
                        if ($(this).find('mc_gross').text() != "") {
                            $('#pout_mc_grossB').html($(this).find('mc_gross').text());
                            $('#pout_mc_grossB').attr('readonly', 'readonly');
                            $('#pout_mc_grossB1').html($(this).find('mc_gross').text());
                            $('#pout_mc_grossB1').attr('readonly', 'readonly');
                        }
                    }
                    else
                    {
                        $('#basicPlanWrap').hide();
                        $('#proPlanWrap').show();
                        if ($(this).find('mc_gross').text() != "") {
                            $('#pout_mc_grossP').html($(this).find('mc_gross').text());
                            $('#pout_mc_grossP').attr('readonly', 'readonly');
                            $('#pout_mc_grossP1').html($(this).find('mc_gross').text());
                            $('#pout_mc_grossP1').attr('readonly', 'readonly');
                        }
                    }
                }

               
            });

        }); //end of Response 
        NProgress.done();


        return false;
    });
}


function planLogGet() {

    $('#planLogDetail').append("Loading....");

    $.post("Ajax/Payment.aspx",
            {
                Mode: "GETPLANLOG",

            },
            function (VarResponseData) {

                if (VarResponseData != "") {
                    $('#planLogDetail').empty();
                    $('#planLogDetail').append(VarResponseData);

                    NProgress.done();
                }
                else {
                    $('#planLogDetail').empty();
                    $('#planLogDetail').append("No Plan Log Detail Found.");

                    NProgress.done();
                }

            });

    return false;
}


function GetPaymentProDetailsReqID(pvarReqID) {

    NProgress.start();
    $.post("Ajax/Payment.aspx",
    {
        Mode: "GETPAYMENTDETAILSREQID",
        PReqID: pvarReqID

    },
    function (VarResponseData) {
        $(VarResponseData).find('Response').each(function () {
            $(VarResponseData).find('AdminData').each(function () {
                console.log("hello");
                if ($(this).find('Full_Name').text() != "") {
                    $('#pFull_Name').html($(this).find('Full_Name').text());
                    $('#pFull_Name').attr('readonly', 'readonly');
                }

                if ($(this).find('EMail').text() != "") {
                    $('#pEMail').html($(this).find('EMail').text());
                    $('#pEMail').attr('readonly', 'readonly');
                }

                if ($(this).find('txn_type').text() != "") {
                    $('#ptxn_type').html($(this).find('txn_type').text());
                    $('#ptxn_type').attr('readonly', 'readonly');
                }
                if ($(this).find('payer_id').text() != "") {
                    $('#ppayer_id').html($(this).find('payer_id').text());
                    $('#ppayer_id').attr('readonly', 'readonly');
                }

                if ($(this).find('first_name').text() != "") {
                    if ($(this).find('last_name').text() != "")
                        $('#pbuy_FullName').html($(this).find('first_name').text() + " " + $(this).find('last_name').text());
                    $('#pbuy_FullName').attr('readonly', 'readonly');
                }

                if ($(this).find('payer_email').text() != "") {
                    $('#ppayer_email').html($(this).find('payer_email').text());
                    $('#ppayer_email').attr('readonly', 'readonly');
                }
                if ($(this).find('subscr_date').text() != "") {
                    $('#ppay_res_date').html($(this).find('subscr_date').text());
                    $('#ppay_res_date').attr('readonly', 'readonly');
                }
                if ($(this).find('str_out_Response').text() != "") {
                    $('#pstr_out_Response').html($(this).find('str_out_Response').text());
                    $('#pstr_out_Response').attr('readonly', 'readonly');
                }
                if ($(this).find('req_id').text() != "") {
                    $('#preq_id').html($(this).find('req_id').text());
                    $('#preq_id').attr('readonly', 'readonly');
                }

                if ($(this).find('payment_status').text() != "") {
                    $('#pout_flag_val').html($(this).find('payment_status').text());
                    $('#pout_flag_val').attr('readonly', 'readonly');
                }

                if ($(this).find('mc_amount3').text() != "") {
                    $('#PAmount').html($(this).find('mc_amount3').text());
                    $('#PAmount').attr('readonly', 'readonly');
                }

                if ($(this).find('period3').text() != "") {
                    $('#Prec_time').html($(this).find('period3').text());
                    $('#Prec_time').attr('readonly', 'readonly');
                }

                //if ($(this).find('txn_id').text() != "") {
                //    $('#ptxn_id').html($(this).find('txn_id').text());
                //    $('#ptxn_id').attr('readonly', 'readonly');
                //}

                //if ($(this).find('item_number').text() != "") {
                //    $('#pitem_number').html($(this).find('item_number').text());
                //    $('#pitem_number').attr('readonly', 'readonly');
                //}

                if ($(this).find('item_number').text() != "") {
                    if ($(this).find('item_number').text() == "1111") {
                        $('#basicPlanWrap').show();
                        $('#proPlanWrap').hide();
                        if ($(this).find('mc_gross').text() != "") {
                            $('#pout_mc_grossB').html($(this).find('mc_amount3').text());
                            $('#pout_mc_grossB').attr('readonly', 'readonly');
                            $('#pout_mc_grossB1').html($(this).find('mc_amount3').text());
                            $('#pout_mc_grossB1').attr('readonly', 'readonly');
                        }
                    }
                    else {
                        $('#basicPlanWrap').hide();
                        $('#proPlanWrap').show();
                        if ($(this).find('mc_gross').text() != "") {
                            $('#pout_mc_grossP').html($(this).find('mc_amount3').text());
                            $('#pout_mc_grossP').attr('readonly', 'readonly');
                            $('#pout_mc_grossP1').html($(this).find('mc_amount3').text());
                            $('#pout_mc_grossP1').attr('readonly', 'readonly');
                        }
                    }
                }


            });

        }); //end of Response 
        NProgress.done();


        return false;
    });
}


