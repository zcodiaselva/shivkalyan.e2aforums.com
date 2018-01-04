using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ASPSnippets.TwitterAPI;
public partial class CS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TwitterConnect.API_Key = "<Twitter API Key>";
        TwitterConnect.API_Secret = "<Twitter API Secret>";
        if (!IsPostBack) if (!IsPostBack)
            {
                if (TwitterConnect.IsAuthorized)
                {
                    TwitterConnect twitter = new TwitterConnect();

                    //LoggedIn User Twitter Profile Details
                    DataTable dt = twitter.FetchProfile();
                    imgProfile.ImageUrl = dt.Rows[0]["profile_image_url"].ToString();
                    lblName.Text = dt.Rows[0]["name"].ToString();
                    lblTwitterId.Text = dt.Rows[0]["Id"].ToString();
                    lblScreenName.Text = dt.Rows[0]["screen_name"].ToString();
                    lblDescription.Text = dt.Rows[0]["description"].ToString();
                    lblTweets.Text = dt.Rows[0]["statuses_count"].ToString();
                    lblFollowers.Text = dt.Rows[0]["followers_count"].ToString();
                    lblFriends.Text = dt.Rows[0]["friends_count"].ToString();
                    lblFavorites.Text = dt.Rows[0]["favourites_count"].ToString();
                    lblLocation.Text = dt.Rows[0]["location"].ToString();
                    tblTwitter.Visible = true;

                    //Any other User Twitter Profile Details. Here jQueryFAQs
                    dt = twitter.FetchProfile("jQueryFAQs");
                    imgOtherProfile.ImageUrl = dt.Rows[0]["profile_image_url"].ToString();
                    lblOtherName.Text = dt.Rows[0]["name"].ToString();
                    lblOtherTwitterId.Text = dt.Rows[0]["Id"].ToString();
                    lblOtherScreenName.Text = dt.Rows[0]["screen_name"].ToString();
                    lblOtherDescription.Text = dt.Rows[0]["description"].ToString();
                    lblOtherTweets.Text = dt.Rows[0]["statuses_count"].ToString();
                    lblOtherFollowers.Text = dt.Rows[0]["followers_count"].ToString();
                    lblOtherFriends.Text = dt.Rows[0]["friends_count"].ToString();
                    lblOtherFavorites.Text = dt.Rows[0]["favourites_count"].ToString();
                    lblOtherLocation.Text = dt.Rows[0]["location"].ToString();
                    tblOtherTwitter.Visible = true;

                    btnLogin.Enabled = false;
                }
                if (TwitterConnect.IsDenied)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "alert('User has denied access.')", true);
                }
            }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!TwitterConnect.IsAuthorized)
        {
            TwitterConnect twitter = new TwitterConnect();
            twitter.Authorize(Request.Url.AbsoluteUri.Split('?')[0]);
        }
    }
}