<%@ Page Language="C#" AutoEventWireup="true" CodeFile="webCams.aspx.cs" Inherits="User_webCams" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <script src="https://static.opentok.com/v2/js/opentok.js" charset="utf-8"></script>
    <script charset="utf-8">
        var apiKey = '45623002';
        var sessionId = '1_MX40NTYyMzAwMn5-MTQ2ODgyMTQyMTI3Nn5JejYrYXlqZXFPcXJBdUxwRlFqNnYwdUF-fg';
        var token = 'T1==cGFydG5lcl9pZD00NTYyMzAwMiZzaWc9NGM2ZjllMDE4Zjg3Njg5ZWM4YTRmYzMzMzJkNzA4N2MyZDVkYTk4OTpzZXNzaW9uX2lkPTFfTVg0ME5UWXlNekF3TW41LU1UUTJPRGd5TVRReU1USTNObjVKZWpZcllYbHFaWEZQY1hKQmRVeHdSbEZxTm5Zd2RVRi1mZyZjcmVhdGVfdGltZT0xNDY4ODIxNDQ3Jm5vbmNlPTAuMjUxMDUyMjY2MjE5NjMwODQmcm9sZT1wdWJsaXNoZXImZXhwaXJlX3RpbWU9MTQ3MTQxMzY4MQ==';
        var session = OT.initSession(apiKey, sessionId)
          .on('streamCreated', function (event) {
              session.subscribe(event.stream);
          })
          .connect(token, function (error) {
              var publisher = OT.initPublisher();
              session.publish(publisher);
          });
    </script>
    </form>
</body>
</html>
