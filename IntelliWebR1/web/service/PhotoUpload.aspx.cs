using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using System.Drawing;
using IntellidateR1;

namespace IntelliWebR1.web.service
{
    public partial class PhotoUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UploadResponse m_UploadResponse = new UploadResponse { ResponseCode = 0, UploadPath = "", ErrorMessage = "" };
            string _ResponseJson = JsonConvert.SerializeObject(m_UploadResponse);
            try
            {
              
                Response.Clear();
                Response.ContentType = "text/json";

                // Get the user id
                if (HttpContext.Current.User.Identity.Name == "")
                {
                    Response.Write(_ResponseJson);
                    return;
                }

                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                if (Request.Files.Count > 0)
                {
                    HttpPostedFile m_PostedFile = Request.Files[0];
                    string _FilePath = _UserID.ToString() + "\\" + DateTime.Now.ToString("ddMMyyhhmmss") + GetFileName(m_PostedFile.FileName.Split('.')[0]);
                    string _RootDirectory = ConfigurationManager.AppSettings["PhotosRootPath"].ToString();
                    string _UserDirectory = _RootDirectory + "\\" + _UserID.ToString();

                    if (!Directory.Exists(_UserDirectory))
                    {
                        Directory.CreateDirectory(_UserDirectory);
                    }

                    // Save the original photo
                    m_PostedFile.SaveAs(_RootDirectory + _FilePath + GetExtension(m_PostedFile.FileName));

                    FileInfo f = new FileInfo(_RootDirectory + _FilePath + GetExtension(m_PostedFile.FileName));
                    long PhotoSize = f.Length;

                    int PhotoWidth = 0;
                    int PhotoHeight = 0;
                    using (Bitmap _Temp = new Bitmap(_RootDirectory + _FilePath + GetExtension(m_PostedFile.FileName)))
                    {
                        PhotoWidth = _Temp.Width;
                        PhotoHeight = _Temp.Height;
                    }
                    

                    PhotoCrop _PhotoCrop = new PhotoCrop();
                    // Get the crop dimensions
                    if (Request.QueryString["crop"] != null)
                    {
                        _PhotoCrop = new PhotoCrop
                        {
                            XPosition = Convert.ToInt32(Request.QueryString["X1"].ToString()),
                            YPosition = Convert.ToInt32(Request.QueryString["Y1"].ToString()),
                            XWidth = Convert.ToInt32(Request.QueryString["X2"].ToString()),
                            YWidth = Convert.ToInt32(Request.QueryString["Y2"].ToString())
                        };
                    }

                    // Submit details
                    Photo m_PhotoDetails = new Photo().SavePhoto(_UserID, _FilePath + GetExtension(m_PostedFile.FileName), PhotoSize, PhotoWidth, PhotoHeight, "", (_PhotoCrop.XWidth != 0), _PhotoCrop);

                    List<ImageResizeDimension> _Dimensions = new List<ImageResizeDimension>();
                    
                    ImageResizeDimension _EachDimension = new ImageResizeDimension();
                    _EachDimension.CropAndProceed = true;
                    _EachDimension.CropX = _PhotoCrop.XPosition;
                    _EachDimension.CropY = _PhotoCrop.YPosition;
                    _EachDimension.CropWidth = _PhotoCrop.XWidth;
                    _EachDimension.CropHeight = _PhotoCrop.YWidth;
                    _EachDimension.Title = "PCT";
                    _EachDimension.Width = Convert.ToInt32(ConfigurationManager.AppSettings["PCT"]);
                    _EachDimension.Height = Convert.ToInt32(ConfigurationManager.AppSettings["PCT"]);
                    _Dimensions.Add(_EachDimension);

                    _EachDimension = new ImageResizeDimension();
                    _EachDimension.CropAndProceed = false;
                    _EachDimension.Width = Convert.ToInt32(ConfigurationManager.AppSettings["PCGT"]);
                    _EachDimension.Height = 0;
                    _EachDimension.Title = "PCGT";
                    _Dimensions.Add(_EachDimension);

                    new ImageResizeQueue().EnqueImage(_RootDirectory + _FilePath + GetExtension(m_PostedFile.FileName), _Dimensions.ToArray());

                    if (m_PhotoDetails == null)
                    {
                        m_UploadResponse = new UploadResponse { ResponseCode = 0, UploadPath = "", ErrorMessage = "we can't upload more then 15 photos" };
                    }
                    else
                    {
                        m_UploadResponse = new UploadResponse { ResponseCode = 1, UploadPath = _FilePath + GetExtension(m_PostedFile.FileName), ErrorMessage = "" };
                    }
                   _ResponseJson = JsonConvert.SerializeObject(m_UploadResponse);
                    Response.Write(_ResponseJson);
                }
            }
            catch (Exception ex)
            {
                m_UploadResponse = new UploadResponse { ResponseCode = 0, UploadPath = "", ErrorMessage = ex.Message };
                _ResponseJson = JsonConvert.SerializeObject(m_UploadResponse);
                Response.Write(_ResponseJson);
            }
        }

        private string GetExtension(string FilePath)
        {
            return Path.GetExtension(FilePath);
        }

        private string GetFileName(string FilePath)
        {
            FilePath = FilePath.Replace("+", "_");
            FilePath = FilePath.Replace("-", "_");
            FilePath = FilePath.Replace("!", "_");
            FilePath = FilePath.Replace("@", "_");
            FilePath = FilePath.Replace("#", "_");
            FilePath = FilePath.Replace("$", "_");
            FilePath = FilePath.Replace("%", "_");
            FilePath = FilePath.Replace("~", "_");
            FilePath = FilePath.Replace("*", "_");
            FilePath = FilePath.Replace("(", "_");
            FilePath = FilePath.Replace(")", "_");
            return Path.GetFileName(FilePath).Replace(" ","");
        }
    }
}