<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarEvent.ascx.cs"
    Inherits="UserControls_CalendarEvent" %>
<%--<link href="css/GridCss/style.css" rel="stylesheet" type="text/css" />--%>


<div id="divDialog1" name="divDialog1" style="display: none; z-index: 100;" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
    <form id="frmcalendarEventForm" name="frmcalendarEventForm" action="" method="post">

        <div id="content" style="margin-top: 20px;">
            <div class="box" id="div-box" style="width: 600px">
                <div class="bottom">
                    <p id="p_customer" style="display:none;">
                        <label style="width: 150px;">
                            Customer:</label><input maxlength="50" class="validate[required]" type="text" name="Customer" id="Customer" value="" required
                                size="30" />
                    </p>
                    <p>
                        <label style="width: 150px;">
                            Title:</label><input maxlength="50" class="validate[required]" type="text" name="Title" id="Title" value="" required
                                size="30" />
                    </p>
                    <p>
                        <label style="width: 150px;">
                            Description:</label>
                        <textarea id="Description" name="Description" class="validate[required]" style="height: 100px; width: 300px"></textarea>
                    </p>

                    
                    <div class="Rowleft" id="time-div">
                        <label style="width: 150px;">
                            Start Time:</label>
                        <select id="cmbStartHH" name="cmbStartHH" class="validate[required]" style="width: 60px;">
                            <option value="-1">HH</option>
                            <option value="00">00</option>
                            <option value="01">01</option>
                            <option value="02">02</option>
                            <option value="03">03</option>
                            <option value="04">04</option>
                            <option value="05">05</option>
                            <option value="06">06</option>
                            <option value="07">07</option>
                            <option value="08">08</option>
                            <option value="09">09</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                        </select>
                        <select id="cmbStartMM" name="cmbStartMM" style="width: 60px;" class="validate[required]">
                            <option value="-1">MM</option>
                            <option value="00">00</option>
                            <option value="01">01</option>
                            <option value="02">02</option>
                            <option value="03">03</option>
                            <option value="04">04</option>
                            <option value="05">05</option>
                            <option value="06">06</option>
                            <option value="07">07</option>
                            <option value="08">08</option>
                            <option value="09">09</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                            <option value="16">16</option>
                            <option value="17">17</option>
                            <option value="18">18</option>
                            <option value="19">19</option>
                            <option value="20">20</option>
                            <option value="21">21</option>
                            <option value="22">22</option>
                            <option value="23">23</option>
                            <option value="24">24</option>
                            <option value="25">25</option>
                            <option value="26">26</option>
                            <option value="27">27</option>
                            <option value="28">28</option>
                            <option value="29">29</option>
                            <option value="30">30</option>
                            <option value="31">31</option>
                            <option value="32">32</option>
                            <option value="33">33</option>
                            <option value="34">34</option>
                            <option value="35">35</option>
                            <option value="36">36</option>
                            <option value="37">37</option>
                            <option value="38">38</option>
                            <option value="39">39</option>
                            <option value="40">40</option>
                            <option value="41">41</option>
                            <option value="42">42</option>
                            <option value="43">43</option>
                            <option value="44">44</option>
                            <option value="45">45</option>
                            <option value="46">46</option>
                            <option value="47">47</option>
                            <option value="48">48</option>
                            <option value="49">49</option>
                            <option value="50">50</option>
                            <option value="51">51</option>
                            <option value="52">52</option>
                            <option value="53">53</option>
                            <option value="54">54</option>
                            <option value="55">55</option>
                            <option value="56">56</option>
                            <option value="57">57</option>
                            <option value="58">58</option>
                            <option value="59">59</option>
                        </select>
                        <select id="cmbStartAMPM" name="cmbStartAMPM" style="width: 60px;" class="validate[required]">
                            <option value="AM">AM</option>
                            <option value="PM">PM</option>
                        </select>
                    </div>
                    <div id="endTime-div">
                        <label style="width: 150px;">
                            End Time:</label>
                        <select id="cmbEndHH" name="cmbEndHH" style="width: 60px;" class="validate[required]">
                            <option value="-1">HH</option>
                            <option value="00">00</option>
                            <option value="01">01</option>
                            <option value="02">02</option>
                            <option value="03">03</option>
                            <option value="04">04</option>
                            <option value="05">05</option>
                            <option value="06">06</option>
                            <option value="07">07</option>
                            <option value="08">08</option>
                            <option value="09">09</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                        </select>
                        <select id="cmbEndMM" name="cmbEndMM" style="width: 60px;" class="validate[required]">
                            <option value="-1">MM</option>
                            <option value="00">00</option>
                            <option value="01">01</option>
                            <option value="02">02</option>
                            <option value="03">03</option>
                            <option value="04">04</option>
                            <option value="05">05</option>
                            <option value="06">06</option>
                            <option value="07">07</option>
                            <option value="08">08</option>
                            <option value="09">09</option>
                            <option value="10">10</option>
                            <option value="11">11</option>
                            <option value="12">12</option>
                            <option value="13">13</option>
                            <option value="14">14</option>
                            <option value="15">15</option>
                            <option value="16">16</option>
                            <option value="17">17</option>
                            <option value="18">18</option>
                            <option value="19">19</option>
                            <option value="20">20</option>
                            <option value="21">21</option>
                            <option value="22">22</option>
                            <option value="23">23</option>
                            <option value="24">24</option>
                            <option value="25">25</option>
                            <option value="26">26</option>
                            <option value="27">27</option>
                            <option value="28">28</option>
                            <option value="29">29</option>
                            <option value="30">30</option>
                            <option value="31">31</option>
                            <option value="32">32</option>
                            <option value="33">33</option>
                            <option value="34">34</option>
                            <option value="35">35</option>
                            <option value="36">36</option>
                            <option value="37">37</option>
                            <option value="38">38</option>
                            <option value="39">39</option>
                            <option value="40">40</option>
                            <option value="41">41</option>
                            <option value="42">42</option>
                            <option value="43">43</option>
                            <option value="44">44</option>
                            <option value="45">45</option>
                            <option value="46">46</option>
                            <option value="47">47</option>
                            <option value="48">48</option>
                            <option value="49">49</option>
                            <option value="50">50</option>
                            <option value="51">51</option>
                            <option value="52">52</option>
                            <option value="53">53</option>
                            <option value="54">54</option>
                            <option value="55">55</option>
                            <option value="56">56</option>
                            <option value="57">57</option>
                            <option value="58">58</option>
                            <option value="59">59</option>
                        </select>
                        <select id="cmbEndAMPM" name="cmbEndAMPM" style="width: 60px;" class="validate[required]">
                            <option value="AM">AM</option>
                            <option value="PM">PM</option>
                        </select>

                    </div>
                   <%-- <br class="clear" />--%>
                     <p style="margin-top:7px;">
                        <label style="width: 150px;">
                            Venue:</label>
                        <textarea id="Venue" name="Venue" class="validate[required]" style="height: 100px; width: 300px"></textarea>
                    </p>

                     <p style="margin-top:7px;">
                        <label style="width: 150px;">
                            Province:</label>
                        <select id="cmbState" name="cmbState" style="width: 200px;" class="validate[required]" onchange="return GetCities(this);">
                       
                        </select>
                    </p>
              
                     <p style="margin-top:7px;">
                        <label style="width: 150px;display:none;" id="lblCity">
                            City:</label>
                         <select id="cmbCity" name="cmbCity" style="width: 150px;display:none;" class="validate[required]">
                       
                        </select>
                    </p>
                    <div align="center">
                        <img src="../../img/progressing.gif" id="imgProcessing" style="visibility: hidden;" />
                    </div>
                    <div id="div-buttons" align="center">
                        <button id="btnCalendarOK" style="width: 100px;" class="button" type="button" onclick="return AddNewEvent();">OK</button>
                       <button id="btnCalendarDone" style="width: 100px;display:none;" class="button" type="button" onclick="return MarkAsDone();">Done</button>
                       
                         <button id="btnCalendarDelete" style="width: 100px; display: none;" class="button" onclick="return DeleteEvent();">Delete</button>
                        <%--<button id="btnCancel" style="width: 100px;" class="button" type="button" onclick="return Cancel_OnClick();">

                            Cancel</button>--%>
                        <button id="btnApprove" style="width: 100px; display: none;" class="button" type="button" onclick="return Approve_OnClick();">
                            Approve</button>
                    </div>
                </div>
                <div id="div-MessageDialog" style="display: none" title="">
                   
            <p>
                <label style="font-size:12px;font-weight:normal;font-family:Sans-Serif;" id="lblMessage"></label>
            </p>
     
                </div>
                <!-- bottom -->
            </div>
           
            <!-- box -->
        </div>
       <%--  <div id="div_EventDesc" class="box" style="display:none;width:500px;height:200px;"> 
                <h2><label id="EventDesc" ></label></h2>
            </div>--%>

    </form> 
</div>

<div id="div_EventDesc" name="divEventDesc" style="display: none;z-index: 100;" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
    <form id="frmEventDesc" name="frmEventDesc" action="" method="post">

        <div id="contentfrmEventDesc" style="margin-top: 20px;">
            <div class="box" id="div-boxEventDesc" >
                <div class="bottom">
                   <h4><label id="EventDesc" ></label></h4>
                </div>
              
     
                </div>
                <!-- bottom -->
           
            <!-- box -->
        </div>


    </form>
   


</div>

<div id="divFollowNotes" name="divFollowNotes" style="display: none;z-index: 100;" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
    <form id="frmFollowNotes" name="frmFollowNotes" action="" method="post">

        <div id="contentfrmFollowNotes" style="margin-top: 20px;">
            <div class="box" id="div-boxfrmFollowNotes" style="width: 600px">
                <div class="bottom">
                    <p id="p_notes" >
                        <label style="width: 150px;text-align:center;margin:auto;">
                            Follow-Up Notes:</label> <textarea id="FollowUpNotes" name="FollowUpNotes" class="validate[required]" style="height: 100px; width: 300px"></textarea>
                    </p>
                    <p>
                        <label style="width: 480px;text-align:center;margin:auto;">
                            <input id="Checkbox1" type="checkbox" />  
                            Do you want to have another meeting with this customer?</label>
                    </p>
                   <p id="p_client" style="display:none;">
                        <label style="width: 480px;text-align:center;margin:auto;">
                            <input id="ChbMarkAsClient" type="checkbox" />  
                            Do you want to mark the status of this customer as client?</label>
                    </p>
                    <div align="center">
                        <img src="../../img/progressing.gif" id="imgProcessing1" style="visibility: hidden;" />
                    </div>
                    <div id="div-buttons1" align="center">
                        <button id="btnCalendarYes" style="width: 100px;" class="button" type="button" onclick="return AddNewFollowUpMeet();">Save</button>
                       <%-- <button id="btnCancel1" style="width: 100px;" class="button" type="button" onclick="return Cancel_OnClick();">
                            Cancel</button>--%>
                      </div>
                </div>
              
     
                </div>
                <!-- bottom -->
           
            <!-- box -->
        </div>


    </form>
   


</div>


<script type='text/javascript'>
    //  var varUserID = $.session.get("UserID");
    var d = new Date();
    var y = d.getFullYear();
    var m = d.getMonth();
    var currentdate = "";
    var varMonth = "";
    var varEventID = -1;
    var varEventApprovedbyAdmin = "";
    var varEventCreatorID = -1;
    var CalendarEvent_varCreatedBy;
    var varloggedInUserID=-1
    var varIsAdmin = "";
    var varCityID = -1;
    var mvarCustomerID = "";
    var mvarEventTitle = "";
    var varIsPublic = "";
    var mvarStatus = "";
    var varUserID = -1;
    //   var varUserID = -1;
    $(document).ready(function () {
        
        varCity=-1;
         varUserID='<%=UserID%>';
        varIsAdmin = '<%=IsAdmin%>';
       
        varloggedInUserID=varUserID;
      
        // alert(varloggedInUserID);
        GetCalendarEventsDetails();
        FillStateCombo();

    });//end $(document).ready(function() 
    
    function FillStateCombo() {
        // NProgress.start();
        $.post("Ajax/AjaxUser.aspx",
                { Mode: "FILLSTATECOMBO" },
                   function (varResponseData) {

                       if (varResponseData.Text != "") {
                           $(varResponseData).find('Response').each(function () {

                               $('#cmbState').empty();
                               var opt = document.getElementById("cmbState").options;
                               opt[opt.length] = new Option('Select', -1);

                               $(varResponseData).find('Contents').each(function () {

                                   if ($(this).find('StateID').text() != "" && $(this).find('Title').text() != "") {
                                       // console.log(varCategoryID);
                                       opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('StateID').text());
                                   }
                               }); // end of Contents

                               $('#cmbState').trigger('chosen:updated');
                               //GetCities(pvarStateID);

                           }); //end of Response
                       } //END OF if (VarResponseData
                   });        //END OF function (VarResponse...


        return false;
    }

    function GetCities(pvarStateID) {
      
        pvarStateID= $('#cmbState').val();
       
        $('#lblCity').show();
        $('#cmbCity').show();
        
        // NProgress.start();
        $.post("Ajax/AjaxUser.aspx",
                { Mode: "FILLCITIESOFSELECTEDSTATE",
                    StateID: pvarStateID
                },
                   function (varResponseData) {

                       if (varResponseData.Text != "") {
                           $(varResponseData).find('Response').each(function () {

                               $('#cmbCity').empty();
                               var opt = document.getElementById("cmbCity").options;
                               opt[opt.length] = new Option('Select', -1);

                               $(varResponseData).find('Contents').each(function () {

                                   if ($(this).find('CityID').text() != "" && $(this).find('Title').text() != "") {
                                       // console.log(varCategoryID);
                                       opt[opt.length] = new Option($(this).find('Title').text(), $(this).find('CityID').text());
                                   }
                               }); // end of Contents

                               if (varCityID != -1) {
                                   $('#cmbCity').val(varCityID);
                               }
                              
                               $('#cmbCity').trigger('chosen:updated');


                           }); //end of Response
                       } //END OF if (VarResponseData
                   });        //END OF function (VarResponse...


        return false;
    }

    function GetEventsOfCity() {
        $('#calendar').empty();
        varCity=$("#dd_City").val();
       
        $('#calendar').fullCalendar({
            theme: true,
            editable: false,
            aspectRatio: 1.85,
            weekMode: 'fixed',
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'

            },
            slotMinutes: 15,//$("#dd_City").val()
            events: "Ajax/AjaxCalendar.aspx?Mode=GETCALENDAREVENTS&CityID="+varCity,
            loading: function (bool) {

                if (bool) {
                    ShowCalendarLoading();
                }
                else {
                    HideCalendarLoading();
                }
            },
            dayClick: function (dayDate, allDay, jsEvent, view) {

                document.forms['frmcalendarEventForm'].reset();
                varMonth = dayDate.getMonth() + 1;
                currentdate = varMonth + "/" + dayDate.getDate() + "/" + dayDate.getFullYear();
               
                ShowModalDialog("Add New Event for " + varMonth + "/" + dayDate.getDate() + "/" + dayDate.getFullYear(), 450, 650);

            }
        });
    }
    //#A Jasmeet Kaur:090914 Function used to get calendar events details.
    function GetCalendarEventsDetails() {
    
        $('#calendar').fullCalendar({
            theme: true,
            editable: false,
            aspectRatio: 1.85,
            weekMode: 'fixed',
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            slotMinutes: 15,//$("#dd_City").val()
            events: "Ajax/AjaxCalendar.aspx?Mode=GETCALENDAREVENTS&CityID="+varCity,
            loading: function (bool) {

                if (bool) {
                    ShowCalendarLoading();
                }
                else {
                    HideCalendarLoading();
                }
            },
            dayClick: function (dayDate, allDay, jsEvent, view) {
               
                document.forms['frmcalendarEventForm'].reset();
                varMonth = dayDate.getMonth() + 1;
                currentdate = varMonth + "/" + dayDate.getDate() + "/" + dayDate.getFullYear();
                varEventID = -1;
                $('#btnCalendarDone').hide();
                ShowModalDialog("Add New Event for " + varMonth + "/" + dayDate.getDate() + "/" + dayDate.getFullYear(), 450, 650);

            }
        });
    }//end GetCalendarEventsDetails()

    function ShowMessageDialogWindow() {

        document.getElementById("div-MessageDialog").style.display = "block";

        $('#div-MessageDialog').dialog({
            autoOpen: false,
            width: 250,
            height: 100,
            overlay: {
                backgroundColor: '#000',
                opacity: 0.5
            },
            modal: true,
            resizable: false,
            draggable: true,
            buttons: {
                "OK": function () {

                }
            }
        });


        $('#div-MessageDialog').dialog('option', 'title', objMessageParams.Message);
        $('#div-MessageDialog').dialog('option', 'height', objMessageParams.Height);
        $('#div-MessageDialog').dialog('option', 'width', objMessageParams.Width);

        $("#div-MessageDialog").dialog('option', 'buttons', {
            "OK": function () {
                $(this).dialog("close");

                if (varComposeMsgStatus == "SUCCESS")
                    window.parent.Menu_HideComposeMessageDialog();
            }
        });

        document.getElementById("lblMessage").innerHTML = objMessageParams.MessageDescription;

        $('#div-MessageDialog').dialog('open');

        return false;
    }

    function Cancel_OnClick() {
       
        $('#divFollowNotes').dialog('close');
        $('#divDialog1').dialog('close');
        document.forms['frmcalendarEventForm'].reset();
        $('#CalendarEvents').hide();
    }

    function ShowCalendarLoading() {
        $('#loading').show();
        $('#calendar').addClass("FadeIn");
    }

    function HideCalendarLoading() {
        $('#loading').hide();
        $('#calendar').removeClass("FadeIn");
    }
  
    function SetEditOnlyPropertiesForControls() {
        
        if (varIsPublic == 'True') {
         
            $('#btnCalendarDone').hide();
            $('#p_customer').hide();
        }
        if (varIsPublic == 'False') {
         
            $('#p_customer').show();
            $('#btnCalendarDone').show();
            $('#btnApprove').hide();
        }
        ShowModalDialog("Edit/View/Delete event details", 450, 650);

        return false;
    }

    function AddNewEvent() {

        var IsPageValid = true;
        var varTitle = $('#Title').val();
        var varDescription = $('#Description').val();
        var varStartHH = $('#cmbStartHH').val();
        var varStartMM = $('#cmbStartMM').val();
        var varEndHH = $('#cmbEndHH').val();
        var varEndMM = $('#cmbEndMM').val();
        var varStartAMPM = $('#cmbStartAMPM').val();
        var varEndAMPM = $('#cmbEndAMPM').val();
        var varVenue=$('#Venue').val();
        var varState=$('#cmbState').val();
        var varCity=$('#cmbCity').val();
       
        if (varTitle == "") {
            toastr["error"]("Please enter Title.");
            return false;
        }

        else if (varDescription == "") {
            toastr["error"]("Please enter description.");
            return false;
        }

        else if (varStartHH == "-1") {
            toastr["error"]("Please select start hours.");
            return false;
        }
        else if (varStartMM == "-1") {
            toastr["error"]("Please select start minutes.");
            return false;
        }
        else if (varEndHH == "-1") {
            toastr["error"]("Please select end hours.");
            return false;
        }

        else if (varEndMM == "-1") {
            toastr["error"]("Please select end minutes.");
            return false;
        }
        else if (varStartAMPM == "-1") {
            toastr["error"]("Please select start am/pm.");
            return false;
        }

        else if (varEndAMPM == "-1") {
            toastr["error"]("Please select end am/pm.");
            return false;
        }
        else if (varVenue == "") {
            toastr["error"]("Please enter venue.");
            return false;
        }
        else if (varState == "-1") {
            toastr["error"]("Please select state.");
            return false;
        }
        else if (varCity == "-1") {
            toastr["error"]("Please select city.");
            return false;
        }
        if (varStartAMPM == "PM" && varStartHH != parseInt("12")) {
            varStartHH = parseFloat(varStartHH) + parseInt(12);
        }
        if (varEndAMPM == "PM" && varEndHH != parseInt("12")) {
            varEndHH = parseFloat(varEndHH) + parseInt(12);
        }

        var varFromDateTime = currentdate + " " + varStartHH + ":" + varStartMM + ":00.000";
        var varToDateTime = currentdate + " " + varEndHH + ":" + varEndMM + ":00.000";
       
        if (varFromDateTime >= varToDateTime) {
            alert("Start time should not be greater than or equal to the End time.");
            IsPageValid = false;
        }


        if (!IsPageValid)
            return false;


        document.getElementById("btnCalendarOK").disabled = true;
        //  document.getElementById("btnCalendarOK").style.backgroundColor = "#91bbde"; // "#4780ae"
        document.getElementById("imgProcessing").style.visibility = "visible";


        var param = [
                          { name: 'Title', value: varTitle }
                        , { name: 'Description', value: varDescription }
                        , { name: 'FromDate', value: varFromDateTime }
                        , { name: 'ToDate', value: varToDateTime }
                        , { name: 'Venue', value: varVenue }
                        , { name: 'StateID', value: varState }
                        , { name: 'CityID', value: varCity }
                        , { name: 'EventID', value: varEventID }
                       
                        //#Jasmeet:091614 - This EventID will be used in case of Update only.	

        ];


        $.ajax({
            type: "post",
            url: "Ajax/AjaxCalendar.aspx?Mode=Add",
            data: param,
            dataType: "text",
            success: function (varResponseData) {

                if (varResponseData == "SUCCESS" || varResponseData == "Success") {
                    if (varEventID == -1) {
                        // GetCalendarEventsDetails();
                 
                        toastr["success"]("Event added successfully");
                        $('#divDialog1').dialog('close');
                        $('#calendar').fullCalendar('refetchEvents');
                        Cancel_OnClick();
                        varEventID = -1;
                     
                    }
                    else {

                        toastr["success"]("Event updated successfully");
                        $('#divDialog1').dialog('close');
                              Cancel_OnClick();
                        //window.location.reload();
                        $('#calendar').fullCalendar('refetchEvents');
                        varEventID = -1;
                    }

                }
                else if (varResponseData == "Already Exists" || varResponseData == "ALREADY EXISTS") {
                    toastr["error"]("Event Name already exists");
                    varEventID = -1;

                }
            }
        });

        varIsCompleted = true;

        return false;

    }// end of AddUpdateNewEvent()
    
    function ShowModalDialog(varTitle, varHeight, varWidth) {
      
        if (varEventID == -1) {
           
            document.getElementById("btnCalendarOK").disabled = false;
            $('#btnCalendarDelete').hide();
            $('#p_customer').hide();
            $('#content').show();
            $('#btnCalendarOK').show();
            $('#btnApprove').hide();
            document.getElementById("btnCalendarOK").innerHTML = "Ok";
            document.getElementById("divDialog1").style.display = "block";
            $('#p_customer').hide();
            $('#divDialog1').dialog({
                autoOpen: true,
                title: varTitle,
                width: varWidth,
                height: varHeight,
                position: 'center',
                zIndex: 1000000,
                overlay: {
                    backgroundColor: '#000',
                    opacity: 0.5
                },
                modal: true,
                resizable: false,
                draggable: false,
                close: function (event, ui) {
                    //CloseValidations
                    document.forms['frmcalendarEventForm'].reset();
                    //varEventID = -1;
                }

            });

            $('#divDialog1').dialog('open');

        }
        else if (mvarEventTitle == 'BirthDay' || mvarEventTitle == 'Anniversary') {
          
            $('#div_EventDesc').dialog({
                autoOpen: true,
                title: "Reminder",
                width: 300,
                height: 200,
                position: 'center',
                zIndex: 1000000,
                overlay: {
                    backgroundColor: '#000',
                    opacity: 0.5
                },
                modal: true,
                resizable: false,
                draggable: false,
                close: function (event, ui) {
                   
                }

            });
            $('#div_EventDesc').dialog('open');
        }
        if (mvarStatus == 'Clients' || mvarStatus == 'Prospects') {
            if (mvarStatus == 'Prospects') {
                $('#p_client').show();
            }
            else {
                $('#p_client').hide();
            }
            $('#divFollowNotes').dialog({
                autoOpen: true,
                title: "Add new meeting",
                width: 550,
                height: 400,
                position: 'center',
                zIndex: 1000000,
                overlay: {
                    backgroundColor: '#000',
                    opacity: 0.5
                },
                modal: true,
                resizable: false,
                draggable: false,
                close: function (event, ui) {
                    document.forms['frmFollowNotes'].reset();
                }

            });

            $('#divFollowNotes').dialog('open');
            $('#divDialog1').dialog('close');
            $('#div_EventDesc').dialog('close');
            $('#content').hide();
        }
        else {
    
           
            document.getElementById("divDialog1").style.display = "block";
            $("#btnCalendarDelete").show();
            document.getElementById("btnCalendarOK").disabled = false;
            document.getElementById("btnCalendarDone").disabled = false;
            document.getElementById("btnCalendarOK").innerHTML = "Update";
            document.getElementById("imgProcessing").style.visibility = "hidden";
            $('#div-buttons').show();
            $('#divDialog1').dialog({
                autoOpen: false,
                title: varTitle,
                width: varWidth,
                height: varHeight,
                position: 'center',
                zIndex: 1000000,
                overlay: {
                    backgroundColor: '#000',
                    opacity: 0.5
                },
                modal: true,
                resizable: false,
                draggable: false,
                close: function (event, ui) {
                    //CloseValidations
                    document.forms['frmcalendarEventForm'].reset();
                    //varEventID = -1;
                }

            });

            $('#divDialog1').dialog('open');
        }
        return false;
    }// end of ShowModalDialog()    
    
    function GetSelectedEventDetails(pEventID) {
         varEventID = pEventID;
      
        var param = [
                     { name: 'Mode', value: "GetEventDetails" }
                    , { name: 'EventID', value: pEventID }
                   
        ];

        $.ajax({
            type: "post",
            url: "Ajax/AjaxCalendar.aspx",
            data: param,
            dataType: "text",
            success: function (varResponseData) {
                var varResult = "";
               $(varResponseData).find('Contents').each(function () {
                    mvarEventTitle = $(this).find('Title').text();
                    mvarStatus = $(this).find('Status').text();
                    mvarCustomerID = $(this).find('CustomerID').text();
                    if ($(this).find('Title').text() == 'BirthDay' || $(this).find('Title').text() == 'Anniversary')
                    {
                       
                        // $('#divDialog1').hide();
                        $('#div_EventDesc').dialog({
                            autoOpen: true,
                            title: "Reminder",
                            width: 300,
                            height: 200,
                            position: 'center',
                            zIndex: 1000000,
                            overlay: {
                                backgroundColor: '#000',
                                opacity: 0.5
                            },
                            modal: true,
                            resizable: false,
                            draggable: false,
                            close: function (event, ui) {
                                //window.location.reload();
                                //$('#div_EventDesc').dialog('close');
                                document.forms['frmEventDesc'].reset();
                            }

                        });
                      
                        if ($(this).find('Title').text() == 'BirthDay')
                        {
                          
                            $('#EventDesc').text("Today " + $(this).find('Customer').text() + "'s" + " birthday.");
                        }
                        else {
                            $('#EventDesc').text("Today " + $(this).find('Customer').text() + "'s" + " Anniversary.");
                        }

                        $('#divFollowNotes').style('display', none);
                        $('#divDialog1').style('display', none);
                        $('#div_EventDesc').dialog('open');

                        $('#content').hide();
                        $('#div_EventDesc').show();

                     
                      
                    }
                    if (mvarStatus == 'Clients' || mvarStatus == 'Prospects')
                    {
                        if (mvarStatus == 'Prospects') {
                            $('#p_client').show();
                        }
                        else {
                            $('#p_client').hide();
                        }
     
                    $('#divFollowNotes').dialog({
                        autoOpen: true,
                        title: "Add new meeting",
                        width: 550,
                        height: 400,
                        position: 'center',
                        zIndex: 1000000,
                        overlay: {
                            backgroundColor: '#000',
                            opacity: 0.5
                        },
                        modal: true,
                        resizable: false,
                        draggable: false,
                        close: function (event, ui) {
                            document.forms['frmFollowNotes'].reset();
                        }
           
                    });
                    $('#divFollowNotes').dialog('open');
                    $('#divFollowNotes').style('display', none);
                    $('#divDialog1').style('display', none);
                    $('#div_EventDesc').dialog('open');

                    $('#content').hide();
                    $('#div_EventDesc').hide();

                    //$('#divFollowNotes').dialog('open');
                    //$('#divDialog1').dialog('close');
                    //$('#div_EventDesc').dialog('close');
                    //$('#content').hide();
                }
                    else {
                        $('#content').show();
                        $('#EventDesc').text("");
                        if ($(this).find('Title').text() != "") {
                            document.getElementById("Title").value = $(this).find('Title').text();
                        }

                        document.getElementById("Description").value = $(this).find('Description').text();

                        if ($(this).find('StartDate').text() != "") {
                            currentdate = $(this).find('StartDate').text();
                        }

                        if ($(this).find('StartHours').text() != "") {
                            $('#cmbStartHH').val($(this).find('StartHours').text());
                        }

                        if ($(this).find('StartMinutes').text() != "") {
                            $('#cmbStartMM').val($(this).find('StartMinutes').text());
                        }

                        if ($(this).find('EndHours').text() != "") {
                            $('#cmbEndHH').val($(this).find('EndHours').text());

                        }
                        if ($(this).find('EndMinutes').text() != "") {

                            $('#cmbEndMM').val($(this).find('EndMinutes').text());
                        }

                        if ($(this).find('STARTAMPM').text() != "") {

                            $('#cmbStartAMPM').val($(this).find('STARTAMPM').text());

                        }
                        if ($(this).find('ENDAMPM').text() != "") {

                            $('#cmbEndAMPM').val($(this).find('ENDAMPM').text());

                        }

                        if ($(this).find('CreatedBy').text() != "") {
                            CalendarEvent_varCreatedBy = $(this).find('CreatedBy').text();
                        }

                        if ($(this).find('UserID').text() != "") {
                            varEventCreatorID = $(this).find('UserID').text();
                        }
                        if ($(this).find('IsPublic').text() != "") {
                            varIsPublic = $(this).find('IsPublic').text();
                        }
                        if (varIsPublic == "False") {

                            $('#p_customer').show();
                            $('#Customer').val($(this).find('Customer').text());
                            $('#btnCalendarOK').hide();
                            $('#btnCalendarDelete').hide();
                            mvarCustomerID = $(this).find('CustomerID').text();
                        }
                        if ($(this).find('EventApprovedbyAdmin').text() != "") {
                            varEventApprovedbyAdmin = $(this).find('EventApprovedbyAdmin').text();

                        }
                        if ($(this).find('Venue').text() != "") {
                            document.getElementById("Venue").value = $(this).find('Venue').text();
                        }
                        if ($(this).find('StateID').text() != "") {
                            $('#cmbState').val($(this).find('StateID').text());
                            $('#cmbState').trigger('chosen:updated');
                        }

                        if ($(this).find('CityID').text() != "") {

                            $('#lblCity').show();
                            $('#cmbCity').show();
                            varCityID = $(this).find('CityID').text();
                            GetCities();

                        }
                        if ($(this).find('Status').text() != "") {
                            mvarStatus = $(this).find('Status').text();
                        }
                    
                    }
                
               
                    SetEditOnlyPropertiesForControls();
                
                    
                });
               
                if (varIsPublic == "False") {
                   
                    $('#btnCalendarDone').show();

                }
                else if (varEventApprovedbyAdmin == "False" && varIsAdmin == "True") {
                    $('#btnApprove').show();
                    $('#btnCalendarOK').show();
                    $('#btnCalendarDelete').show();
                }
                else if (varEventApprovedbyAdmin == "True" && varloggedInUserID == varEventCreatorID && varIsAdmin == "False" ){//&& varIsPublic == "False") {
                    $('#btnApprove').hide();
                    $('#btnCalendarOK').hide();
                    $('#btnCalendarDelete').hide();
                    //$('#btnCalendarDone').show();
                }
                else if (varEventApprovedbyAdmin == "True" && varIsAdmin == "True") {
                    $('#btnApprove').hide();
                    $('#btnCalendarOK').show();
                    $('#btnCalendarDelete').show();
                }
               else if (varloggedInUserID != varEventCreatorID) {
                    $('#btnCalendarOK').hide();
                    $('#btnCalendarDelete').hide();
               }
               //else if (varIsPublic == "False") {
               //    alert("hello");
               //    $('#btnCalendarDone').show();
                  
               //}
                else {
                    $('#btnCalendarOK').show();
                    $('#btnCalendarDelete').show();
                }

            },
            error: function (varResponseData) {
                alert("Error: " + varResponseData);
                //#A NT:122909 Redirect to the Logoutpage
                window.location = "../logout.aspx";
            }
        });
      
    }//end GetSelectedEventDetails
    
    function ShowModalDialog(varTitle, varHeight, varWidth) {
   
        if (varEventID == -1) {
            $('#p_customer').hide();
            document.getElementById("btnCalendarOK").disabled = false;
            $('#btnCalendarDelete').hide();
            $('#content').show();
            $('#btnCalendarOK').show();
            $('#btnApprove').hide();
            document.getElementById("btnCalendarOK").innerHTML = "Ok";
            document.getElementById("divDialog1").style.display = "block";

            $('#divDialog1').dialog({
                autoOpen: true,
                title: varTitle,
                width: varWidth,
                height: varHeight,
                position: 'center',
                zIndex: 1000000,
                overlay: {
                    backgroundColor: '#000',
                    opacity: 0.5
                },
                modal: true,
                resizable: false,
                draggable: false,
                close: function (event, ui) {
                    //CloseValidations
                    document.forms['frmcalendarEventForm'].reset();
                    //varEventID = -1;
                }

            });

            $('#divDialog1').dialog('open');

        }
        else if (mvarEventTitle == 'BirthDay' || mvarEventTitle == 'Anniversary') {
              $('#div_EventDesc').dialog({
                autoOpen: true,
                title: "Reminder",
                width: 300,
                height: 200,
                position: 'center',
                zIndex: 1000000,
                overlay: {
                    backgroundColor: '#000',
                    opacity: 0.5
                },
                modal: true,
                resizable: false,
                draggable: false,
                close: function (event, ui) {
                    window.location.reload();
                    document.forms['frmEventDesc'].reset();
                }

            });
              $('#div_EventDesc').dialog('open');
        }
        else {

            document.getElementById("divDialog1").style.display = "block";
            $("#btnCalendarDelete").show();
            document.getElementById("btnCalendarOK").disabled = false;

            document.getElementById("btnCalendarOK").innerHTML = "Update";
            document.getElementById("imgProcessing").style.visibility = "hidden";
            $('#div-buttons').show();
            $('#divDialog1').dialog({
                autoOpen: false,
                title: varTitle,
                width: varWidth,
                height: varHeight,
                position: 'center',
                zIndex: 1000000,
                overlay: {
                    backgroundColor: '#000',
                    opacity: 0.5
                },
                modal: true,
                resizable: false,
                draggable: false,
                close: function (event, ui) {
                    //CloseValidations
                    document.forms['frmcalendarEventForm'].reset();
                    //varEventID = -1;
                }

            });

            $('#divDialog1').dialog('open');
        }
        return false;
    }// end of ShowModalDialog()    
   
    function DeleteEvent() {
        if (confirm("Are you sure you want to delete all the details for this event?"))
            DeleteSelectedEvent();

        return false;
    }
        //#A Jasmeet Kaur:090914 - This function is used to show the details of the selected event.
    function DeleteSelectedEvent(pEventID) {
      //  varEventID=pEventID;
        document.getElementById("imgProcessing").style.visibility = "visible";

        var param = [
                     { name: 'Mode', value: "DeleteEventDetails" }
                    , { name: 'EventID', value: varEventID }
        ];

        $.ajax({
            type: "post",
            url: "Ajax/AjaxCalendar.aspx",
            data: param,
            dataType: "xml",
            success: function (varResponseData) {

                document.getElementById("imgProcessing").style.visibility = "hidden";

                var varResult = "";

                $(varResponseData).find('Contents').each(function () {

                    if ($(this).find('Result').text() != "") {
                        var var_Result = $(this).find('Result').text();

                        if (var_Result == "SUCCESS") {
                            //  GetCalendarEventsDetails();
                            // Cancel_OnClick();
                            $('#divDialog1').dialog('close');
                            toastr["success"]("Event deleted successfully");
                             window.location.reload();
                            //$('#calendar').fullCalendar('refetchEvents');
                            //objMessageParams.Message = "Delete Event";
                            //objMessageParams.MessageDescription = "Selected Event has been deleted successfully.";
                            //objMessageParams.Height = 100;
                            //objMessageParams.Width = 300;
                            //objMessageParams.RedirectOnOk = "";
                            //objMessageParams.Action = "RefreshCalendar";

                            ShowMessageDialogWindow();
                        }
                    }

                });

            },
            error: function (varResponseData) {
                document.getElementById("imgProcessing").style.visibility = "hidden";
                alert("Error: " + varResponseData);
                //#A NT:122909 Redirect to the Logoutpage
                window.location = "../logout.aspx";
            }
        });

    }//end DeleteSelectedEvent

    function Approve_OnClick()
    {
       
        if (confirm("Are  you sure you want to approve this event?"))
         {
           
            $.post("Ajax/AjaxCalendar.aspx",
                      {

                          Mode: "APPROVEEVENT",
                          EventID: varEventID
                      },

                      function (varResponseData) {
                         
                          if (varResponseData != "") {

                              if (varResponseData == "SUCCESS") {

                                  toastr["success"]("Event Approved successfully");
                                  window.location.reload();
                              }
                          }


                      });
        }
        return false;
    }

    function MarkAsDone() {
       
        if (mvarStatus == 'Prospects')
        {
            $('#p_client').show();
        }
        else {
            $('#p_client').hide();
        }
       $('#divDialog1').dialog('close');     
     
       $('#divFollowNotes').dialog({
           autoOpen: true,
           title: "Add new meeting",
           width: 550,
           height: 400,
           position: 'center',
           zIndex: 1000000,
           overlay: {
               backgroundColor: '#000',
               opacity: 0.5
           },
           modal: true,
           resizable: false,
           draggable: false,
           close: function (event, ui) {
               document.forms['frmFollowNotes'].reset();
           }
           
       });
          
       $('#divFollowNotes').dialog('open');
          
      
    }

    function AddNewFollowUpMeet() {
      
        var varIsProspects = "";
        if ($('#FollowUpNotes').val() == "") {
            toastr["error"]("Please Enter Note.");
            return false;
        }
      
      
        if ($('#ChbMarkAsClient').is(":checked")) {
            varIsProspects = "True";
        }
        else {
            varIsProspects = "False";
        }
      
     
        $.post("Ajax/AjaxCalendar.aspx",
          {
              Mode: "ADDNEWFOLLOWUPMEET",
              FollowUpNotes: $('#FollowUpNotes').val(),
              EventID: varEventID,
              CustomerID: mvarCustomerID,
              IsProspects: varIsProspects
              
          },
              function (VarResponseData) {

                  if (VarResponseData == "SUCCESS" || VarResponseData == "success") {
                      toastr["success"]("Follow-up note added successfully.");
                     
                      if ($('#Checkbox1').is(":checked")) {
                          window.location = "Followup2.aspx?CustomerID=" + mvarCustomerID;
                      }
                      $('#divFollowNotes').dialog('close');
                  }
              });


        return false;
    }
    //function PostEventToGoogleCalendar() {
    //    $.post("Ajax/AjaxUser.aspx",
    //     {
    //         Mode: "POSTEVENTTOGOOGLECALENDAR",
    //         EventID: varEventID

    //     },

    //         function (varResponseData) {

    //             if (varResponseData != "") {

    //                 if ((varResponseData == "SUCCESS") || (varResponseData == "success")) {
    //                     toastr["success"]("Topic unliked successfully");

    //                     $('#LikeTopic_' + pvarTopicID).show();
    //                     $('#UnLikeTopic_' + pvarTopicID).hide();

    //                 }

    //             }


    //         });

    //    return false;
    //}
 
</script>

