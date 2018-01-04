<%@ WebHandler Language="C#" Class="UploadImages" %>

using System;
using System.Web;

public class UploadImages : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string lstrMode = "";

        if (context.Request.QueryString["MODE"] != null)
            lstrMode = context.Request.QueryString["MODE"];

        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        int count = context.Request.Files.Count;

        try
        {
            for (int i = 0; i < context.Request.Files.Count; i++)
            // foreach (System.Web.HttpPostedFile ImageFile in context.Request.Files)
            {
                //HttpPostedFile objHttpPostedFile = (HttpPostedFile)context.Request.Files[i];
                //objHttpPostedFile.SaveAs(string.Concat(pathSave, "/", objHttpPostedFile.FileName));

                //ImageFile = Request.Files[ImageFile];
                System.Web.HttpPostedFile ImageFile = context.Request.Files[i];
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

                        lstrOriginalFilePath = absPath + "Attachments" + "//" + imgfileName + lstrFileExtension;
                        ImageFile.SaveAs(lstrOriginalFilePath);
                        ResizeImage(lstrOriginalFilePath, lstrOriginalFilePath, 500, 466, true);

                        if (builder.ToString() == "")
                            builder.Append("//Attachments" + "//" + imgfileName + lstrFileExtension);
                        else
                            builder.Append(",//Attachments" + "//" + imgfileName + lstrFileExtension);

                    }

                }
                catch (Exception)
                {

                }
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
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}