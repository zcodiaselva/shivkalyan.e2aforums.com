<html>
<head>
<title>PHP jQuery AJAX</title>

<script src="https://code.jquery.com/jquery-2.1.1.min.js" type="text/javascript"></script>
<script>
function sendContact() {

		jQuery.ajax({
		url: "cal_response_new.php",
		data:'costvalue='+$("#costvalue").val()+'&buyer='+$("#buyer").val(),
		type: "POST",
		success:function(data){
		//alert(data);
		$("#res").html(data);
			if(data!=''){
			document.getElementById('msg').style.display="none";
			}
			else{
			document.getElementById('msg').style.display="block";
			}
		},
		error:function (){}
		});
	
}
</script>
</head>
<body>
<span id="msg">Calculate your cost </span>
<div id="res"></div><br><hr color="red">
Pro: cost value : <input type="text" name="costvalue" id="costvalue" class="demoInputBox" placeholder="Enter value" onkeyup="sendContact();"><br>


Number of purchase : <select name="buyer" id="buyer" onchange="sendContact();">
				<option selected="selected" value="0" disabled="disabled">Select Buyer</option>
				<option value="1">First time</option>
				<option value="2">Second time</option>
				</select><br>


<!--<button name="submit" class="btnAction" onClick="sendContact();">Calculate</button><br>-->

</body>
</html>