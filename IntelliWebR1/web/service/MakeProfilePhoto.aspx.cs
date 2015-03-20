using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;


namespace IntelliWebR1.web.service
{
    public partial class MakeProfilePhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UploadResponse m_UploadResponse = new UploadResponse { ResponseCode = 0, UploadPath = "", ErrorMessage = "" };
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["pid"] != null)
                {
                    PhotoCrop _PhotoCrop;
                    int _PhotoID = Convert.ToInt32(Request.QueryString["pid"]);
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    if (Request.QueryString["crop"] != null)
                    {
                        _PhotoCrop = new PhotoCrop
                        {
                            XPosition = Convert.ToInt32(Request.QueryString["X1"].ToString()),
                            YPosition = Convert.ToInt32(Request.QueryString["Y1"].ToString()),
                            XWidth = Convert.ToInt32(Request.QueryString["X2"].ToString()),
                            YWidth = Convert.ToInt32(Request.QueryString["Y2"].ToString())
                        };
                        bool _Result = new Photo().MakeExistingAsProfilePhoto(_UserID, _PhotoID, _PhotoCrop);

                        if(_Result)
                        {
                            m_UploadResponse.ResponseCode = 1;
                            m_UploadResponse.ErrorMessage = "done";

                            Photo _PhotoDetails = new Photo().GetPhoto(_PhotoID);

                            string _FilePath = _PhotoDetails.PhotoPath.Split('.')[0];
                            string _RootDirectory = ConfigurationManager.AppSettings["PhotosRootPath"].ToString();
                            string _UserDirectory = _RootDirectory + "\\" + _UserID.ToString();

                            if (!Directory.Exists(_UserDirectory))
                            {
                                Directory.CreateDirectory(_UserDirectory);
                            }

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
                            new ImageResizeQueue().EnqueImage(_RootDirectory + _FilePath + GetExtension(_PhotoDetails.PhotoPath), _Dimensions.ToArray());


                        }
                    }
                    string _ResponseJson = JsonConvert.SerializeObject(m_UploadResponse);
                    Response.Write(_ResponseJson);
                }
            }
        }


        private string GetExtension(string FilePath)
        {
            return Path.GetExtension(FilePath);
        }

        private string GetFileName(string FilePath)
        {
            return Path.GetFileName(FilePath).Replace(" ", "");
        }




    }
}