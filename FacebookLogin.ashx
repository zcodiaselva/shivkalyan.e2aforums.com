<%@ WebHandler Language="C#" Class="FacebookLogin" %>

using System;
using System.Web;
using System.Web.SessionState;

public class FacebookLogin : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        
        string lstrMode = "";
        if (context.Request.QueryString["Mode"] != null)
            lstrMode = Convert.ToString(context.Request.QueryString["Mode"]);
        
        var accessToken = context.Request["accessToken"];                
        context.Session.Add("AccessToken",accessToken);
        context.Response.Redirect("FBSuccess.aspx?Mode=" + lstrMode);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}