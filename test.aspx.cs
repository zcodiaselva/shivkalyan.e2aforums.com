using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using System.Web.Security;
using System.Net;
using System.IO;
using System;

public partial class test : System.Web.UI.Page
{
    OpenIdRelyingParty openid = new OpenIdRelyingParty();
    protected void Page_Load(object sender, EventArgs e)
    {
        HandleOpenIDProviderResponse();
    }
    protected void HandleOpenIDProviderResponse()
    {
        var response = openid.GetResponse();

        if (response != null)
        {
            switch (response.Status)
            {
                case AuthenticationStatus.Authenticated:

                    var fetchResponse = response.GetExtension<FetchResponse>();
                    Session["FetchResponse"] = fetchResponse;
                    var response2 = Session["FetchResponse"] as FetchResponse;

                 Response.Write(response2.GetAttributeValue(WellKnownAttributes.Contact.Email));
                 

                    break;
                case AuthenticationStatus.Canceled:
                    Response.Write("c");
                    break;
                case AuthenticationStatus.Failed:
                    Response.Write("falied");
                    break;
            }
        }
        else
        {
            return;

        }

    }

    protected void OpenLogin_Click(object src, CommandEventArgs e)
    {
        string discoveryUri = e.CommandArgument.ToString();
        var b = new UriBuilder(Request.Url) { Query = "" };
        var req = openid.CreateRequest(discoveryUri, b.Uri, b.Uri);

        var fetchRequest = new FetchRequest();
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Person.Gender);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Phone.Mobile);
        fetchRequest.Attributes.AddRequired(WellKnownAttributes.BirthDate.WholeBirthDate);
        req.AddExtension(fetchRequest);
        req.RedirectToProvider();

    }

    private static string GetFullname(string first, string last)
    {
        var _first = first ?? "";
        var _last = last ?? "";

        if (string.IsNullOrEmpty(_first) || string.IsNullOrEmpty(_last))
            return "";

        return _first + " " + _last;
    }

}