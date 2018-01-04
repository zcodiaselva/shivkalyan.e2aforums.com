<%@ WebHandler Language="C#" Class="UploadAdvertImages" %>

using System;
using System.Web;

public class UploadAdvertImages : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //string lstrMode = "";

        //if (context.Request.QueryString["MODE"] != null)
        //    lstrMode = context.Request.QueryString["MODE"];

        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        try
        {

            System.Web.HttpPostedFile ImageFile = context.Request.Files["fileUpload"];
            string absPath = System.Web.HttpContext.Current.Server.MapPath("~");
            string imgfileName = "";
            string lstrFileExtension = "";
            if (ImageFile != null && ImageFile.FileName != "")
            {
                lstrFileExtension = System.IO.Path.GetExtension(ImageFile.FileName);
                imgfileName = System.IO.Path.GetFileNameWithoutExtension(ImageFile.FileName);
                imgfileName += DateTime.Now.ToString("yyMMddHHmm");
            }


            try
            {
                string lstrOriginalFilePath = "";

                if (!string.IsNullOrEmpty(imgfileName))
                {

                    lstrOriginalFilePath = absPath + "Advertisement" + "//" + imgfileName + lstrFileExtension;
                    ImageFile.SaveAs(lstrOriginalFilePath);
                   // ResizeImage(lstrOriginalFilePath, lstrOriginalFilePath, 500, 466, true);
                    builder.Append("..//Advertisement" + "//" + imgfileName + lstrFileExtension);


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
    public void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
    {
        int NewHeight = 0;
        System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

        // Prevent using images internal thumbnail
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

        if (OnlyResizeIfWider)
        {
            if (FullsizeImage.Width > 500 && FullsizeImage.Height > 466)
            {
                NewWidth = 500;
                NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
            }
            if (FullsizeImage.Width <= 500 && FullsizeImage.Height > 466)
            {
                NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                NewHeight = 466;
            }
            if (FullsizeImage.Width > 500 && FullsizeImage.Height <= 466)
            {
                NewWidth = 500;
                NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
            }
            if (FullsizeImage.Width <= 500 && FullsizeImage.Height <= 466)
            {
                NewWidth = FullsizeImage.Width;
                NewHeight = FullsizeImage.Height;
            }
        }
        System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

        // Clear handle to original file so that we can overwrite it if necessary
        FullsizeImage.Dispose();

        // Save resized picture
        NewImage.Save(NewFile);
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}