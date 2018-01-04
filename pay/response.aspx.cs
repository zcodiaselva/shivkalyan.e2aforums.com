using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;
using System;
using payment_cc;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
public partial class response : System.Web.UI.Page
{
    cls_payment_req_response_prp obj_cls_prp = new cls_payment_req_response_prp();
    cls_payment_req_response obj_cls = new cls_payment_req_response();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}