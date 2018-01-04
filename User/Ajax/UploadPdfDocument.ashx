<%@ WebHandler Language="C#" Class="UploadPdfDocument" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;

public class UploadPdfDocument : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
      
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        try
        {

            System.Web.HttpPostedFile ImageFile = context.Request.Files["fileUpload"];
            string absPath = System.Web.HttpContext.Current.Server.MapPath("~");
            string PdffileName = "";
            string lstrFileExtension = "";
            if (ImageFile != null && ImageFile.FileName != "")
            {
                lstrFileExtension = System.IO.Path.GetExtension(ImageFile.FileName);
                PdffileName = System.IO.Path.GetFileNameWithoutExtension(ImageFile.FileName);
                PdffileName += DateTime.Now.ToString("yyMMddHHmm");
            }


            try
            {
                string lstrOriginalFilePath = "";

                if (!string.IsNullOrEmpty(PdffileName))
                {

                    lstrOriginalFilePath = absPath + "Documents" + "//" + PdffileName + lstrFileExtension;
                    ImageFile.SaveAs(lstrOriginalFilePath);
                    builder.Append("..//Documents" + "//" + PdffileName + lstrFileExtension);


                }

            }
            catch (Exception)
            {

            }


            context.Response.ContentType = "text/plain";
            context.Response.Write("SUCCESS##" + builder.ToString());
        }
        catch (Exception ex)
        {

            context.Response.ContentType = "text/plain";
            context.Response.Write("ERROR:" + ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}      