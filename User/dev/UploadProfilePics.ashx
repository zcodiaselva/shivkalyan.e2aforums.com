<%@ WebHandler Language="C#" Class="UploadProfilePics" %>

using System;
using System.Web;
using System.Web.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;

using System.Collections.Generic;
using System.Linq;

using System.Web.UI;
using System.Web.UI.WebControls;

public class UploadProfilePics : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
      
        string lstrMod = "";

       if (context.Request.Form["Mode"] != null)
        {
            lstrMod = context.Request.Form["Mode"].ToString();
        }
        else if (context.Request.QueryString["Mode"] != null)
        {
            lstrMod = context.Request.QueryString["Mode"].ToString();
        }
      
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
      
        try
        {

            if (lstrMod == "UPLOADGRPFILEPICS")
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

                        //lstrOriginalFilePath = absPath + "ProfilePics" + "//" + imgfileName + lstrFileExtension;
                        //ImageFile.SaveAs(lstrOriginalFilePath);
                        //ResizeImage(lstrOriginalFilePath, lstrOriginalFilePath, 500, 466, true);
                        //builder.Append("..//ProfilePics" + "//" + imgfileName + lstrFileExtension);
                        
                       // lstrOriginalFilePath = absPath + "ProfilePics" + "/" + imgfileName + lstrFileExtension;
                       
                        String filePath = System.Web.HttpContext.Current.Server.MapPath("~/ProfilePics");
                        lstrOriginalFilePath = filePath + "/" + imgfileName + lstrFileExtension;
                        ImageFile.SaveAs(lstrOriginalFilePath);
                       
                        ResizeImage(lstrOriginalFilePath, lstrOriginalFilePath, 500, 466, true);
                        builder.Append("../ProfilePics" + "/" + imgfileName + lstrFileExtension);


                    }

                }
                catch (Exception ex)
                {

                }
            }
            
            
            
            if (lstrMod == "UPLOADPROFILEPICS")
            { 
                
                System.Web.HttpPostedFile ImageFile = context.Request.Files["fileUpload"];
                string absPath = System.Web.HttpContext.Current.Server.MapPath("~");
                string imgfileName = "";
                string lstrFileExtension = "";
                if (ImageFile != null && ImageFile.FileName != "")
                {
                    lstrFileExtension = System.IO.Path.GetExtension(ImageFile.FileName);
                    imgfileName = "File";
                    imgfileName += DateTime.Now.ToString("yyMMddHHmmss");
                }


                try
                {
                    string lstrOriginalFilePath = "";

                    if (!string.IsNullOrEmpty(imgfileName))
                    {
                        String filePath = System.Web.HttpContext.Current.Server.MapPath("~/ProfilePics");
                        lstrOriginalFilePath = filePath + "/" + imgfileName + lstrFileExtension;
                        ImageFile.SaveAs(lstrOriginalFilePath);
                       
                    
                        builder.Append("../ProfilePics" + "/" + imgfileName + lstrFileExtension);


                    }

                }
                catch (Exception ex)
                {

                }
                 
            }

            if (lstrMod == "UPLOADPROFILEPICSUPD")
            {

                System.Web.HttpPostedFile ImageFile = context.Request.Files["fileUploadUpd"];
                string absPath = System.Web.HttpContext.Current.Server.MapPath("~");
                string imgfileName = "";
                string lstrFileExtension = "";
                if (ImageFile != null && ImageFile.FileName != "")
                {
                    lstrFileExtension = System.IO.Path.GetExtension(ImageFile.FileName);
                    imgfileName = "File";
                    imgfileName += DateTime.Now.ToString("yyMMddHHmmss");
                }


                try
                {
                    string lstrOriginalFilePath = "";

                    if (!string.IsNullOrEmpty(imgfileName))
                    {
                        String filePath = System.Web.HttpContext.Current.Server.MapPath("~/ProfilePics");
                        lstrOriginalFilePath = filePath + "/" + imgfileName + lstrFileExtension;
                        ImageFile.SaveAs(lstrOriginalFilePath);


                        builder.Append("../ProfilePics" + "/" + imgfileName + lstrFileExtension);


                    }

                }
                catch (Exception ex)
                {

                }

            }
            if (lstrMod == "UPLOADTECHTIPS")
            {

                System.Web.HttpPostedFile ImageFile = context.Request.Files["Editfilename"];
                string absPath = System.Web.HttpContext.Current.Server.MapPath("~");
                string imgfileName = "";
                string lstrFileExtension = "";
                if (ImageFile != null && ImageFile.FileName != "")
                {
                    lstrFileExtension = System.IO.Path.GetExtension(ImageFile.FileName);
                    imgfileName = "File";
                    imgfileName += DateTime.Now.ToString("yyMMddHHmmss");
                }


                try
                {
                    string lstrOriginalFilePath = "";

                    if (!string.IsNullOrEmpty(imgfileName))
                    {
                        String filePath = System.Web.HttpContext.Current.Server.MapPath("~/techtips");
                        lstrOriginalFilePath = filePath + "/" + imgfileName + lstrFileExtension;
                        ImageFile.SaveAs(lstrOriginalFilePath);

                      
                        builder.Append("../techtips" + "/" + imgfileName + lstrFileExtension);


                    }

                }
                catch (Exception ex)
                {

                }



            }

            if (lstrMod == "UPLOADTECHTIPSNEW")
            {

                System.Web.HttpPostedFile ImageFile = context.Request.Files["fileUpload"];
                string absPath = System.Web.HttpContext.Current.Server.MapPath("~");
                string imgfileName = "";
                string lstrFileExtension = "";
                if (ImageFile != null && ImageFile.FileName != "")
                {
                    lstrFileExtension = System.IO.Path.GetExtension(ImageFile.FileName);
                    imgfileName = "File";
                    imgfileName += DateTime.Now.ToString("yyMMddHHmmss");
                }


                try
                {
                    string lstrOriginalFilePath = "";

                    if (!string.IsNullOrEmpty(imgfileName))
                    {
                        String filePath = System.Web.HttpContext.Current.Server.MapPath("~/techtips");
                        lstrOriginalFilePath = filePath + "/" + imgfileName + lstrFileExtension;
                        ImageFile.SaveAs(lstrOriginalFilePath);

                        
                        builder.Append("../techtips" + "/" + imgfileName + lstrFileExtension);


                    }

                }
                catch (Exception ex)
                {

                }



            }
            if (lstrMod == "UPLOADCUSTOMERPICS")
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

                        lstrOriginalFilePath = absPath + "CustProfilePIcs" + "/" + imgfileName + lstrFileExtension;
                        ImageFile.SaveAs(lstrOriginalFilePath);
                      
                        builder.Append("/CustProfilePIcs" + "/" + imgfileName + lstrFileExtension);


                    }

                }
                catch (Exception)
                {

                }
            }
            if (lstrMod == "UPLOADUSERDOCUMENTS")
            {
                System.Web.HttpPostedFile File = context.Request.Files["fileUpload"];
                string absPath = System.Web.HttpContext.Current.Server.MapPath("~");
                string fileName = "";
                string lstrFileExtension = "";
                if (File != null && File.FileName != "")
                {
                    lstrFileExtension = System.IO.Path.GetExtension(File.FileName);
                    fileName = System.IO.Path.GetFileNameWithoutExtension(File.FileName);
                    fileName += DateTime.Now.ToString("yyMMddHHmm");
                }


                try
                {
                    string lstrOriginalFilePath = "";

                    if (!string.IsNullOrEmpty(fileName))
                    {

                        lstrOriginalFilePath = absPath + "UserDocs" + "/" + fileName + lstrFileExtension;
                        File.SaveAs(lstrOriginalFilePath);
                        builder.Append("/UserDocs" + "/" + fileName + lstrFileExtension);


                    }

                }
                catch (Exception)
                {

                }

            }

            if (lstrMod == "UPLOADGRPFILEPICS")
            {

                System.Web.HttpPostedFile ImageFile = context.Request.Files["Editfilename"];
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

                        String filePath = System.Web.HttpContext.Current.Server.MapPath("~/ProfilePics");
                        lstrOriginalFilePath = filePath + "/" + imgfileName + lstrFileExtension;
                        ImageFile.SaveAs(lstrOriginalFilePath);

                        ResizeImage(lstrOriginalFilePath, lstrOriginalFilePath, 500, 466, true);
                        builder.Append("../ProfilePics" + "/" + imgfileName + lstrFileExtension);


                    }

                }
                catch (Exception ex)
                {

                }
            }
            
            if (lstrMod == "UPLOADCUSTOMERDOCUMENTS")
            {
                System.Web.HttpPostedFile File = context.Request.Files["FileUpload"];
                string absPath = System.Web.HttpContext.Current.Server.MapPath("~");
                string DocFile = "";
                string lstrFileExtension = "";
                if (File != null && File.FileName != "")
                {
                    lstrFileExtension = System.IO.Path.GetExtension(File.FileName);
                    DocFile = System.IO.Path.GetFileNameWithoutExtension(File.FileName);
                    DocFile += DateTime.Now.ToString("yyMMddHHmm");
                }


                try
                {
                    string lstrOriginalFilePath = "";

                    if (!string.IsNullOrEmpty(DocFile))
                    {

                        lstrOriginalFilePath = absPath + "CustomerDocs" + "/" + DocFile + lstrFileExtension;
                        File.SaveAs(lstrOriginalFilePath);
                       // ResizeImage(lstrOriginalFilePath, lstrOriginalFilePath, 500, 466, true);
                        builder.Append("/CustomerDocs" + "/" + DocFile + lstrFileExtension);


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