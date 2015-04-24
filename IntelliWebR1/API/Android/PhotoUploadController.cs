using IntellidateR1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class PhotoUploadController : ApiController
    {

        public UploadResponse POST([FromBody]AddPicture _PhotoObj)
        {
            UploadResponse m_UploadResponse = new UploadResponse { ResponseCode = 0, UploadPath = "", ErrorMessage = "" };
            try
            {
                byte[] _Array = Convert.FromBase64String(_PhotoObj.PhotoArray);
                MemoryStream ms = new MemoryStream(_Array);
                Image returnImage = Image.FromStream(ms);
                string _fileName = _PhotoObj.FileName;
                int _UserID = _PhotoObj.UserID;
                //   HttpPostedFile m_PostedFile =returnImage;
                string _FilePath = _UserID.ToString() + "\\" + DateTime.Now.ToString("ddMMyyhhmmss") + _fileName.Split('.')[0];
                string _RootDirectory = ConfigurationManager.AppSettings["PhotosRootPath"].ToString();
                string _UserDirectory = _RootDirectory + "\\" + _UserID.ToString();

                if (!Directory.Exists(_UserDirectory))
                {
                    Directory.CreateDirectory(_UserDirectory);
                }

                // Save the original photo
                returnImage.Save(_RootDirectory + _FilePath + GetExtension(_fileName));

                FileInfo f = new FileInfo(_RootDirectory + _FilePath + GetExtension(_fileName));
                long PhotoSize = f.Length;

                int PhotoWidth = 0;
                int PhotoHeight = 0;
                using (Bitmap _Temp = new Bitmap(_RootDirectory + _FilePath + GetExtension(_fileName)))
                {
                    PhotoWidth = _Temp.Width;
                    PhotoHeight = _Temp.Height;
                }


                PhotoCrop _PhotoCrop = new PhotoCrop();
                _PhotoCrop = new PhotoCrop
                {
                    XPosition = _PhotoObj.X1,
                    YPosition = _PhotoObj.Y1,
                    XWidth = _PhotoObj.X2,
                    YWidth = _PhotoObj.Y2
                };


                // Submit details
                Photo m_PhotoDetails = new Photo().SavePhoto(_UserID, _FilePath + GetExtension(_fileName), PhotoSize, PhotoWidth, PhotoHeight, "", (_PhotoCrop.XWidth != 0), _PhotoCrop);

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

                new ImageResizeQueue().EnqueImage(_RootDirectory + _FilePath + GetExtension(_fileName), _Dimensions.ToArray());

                if (m_PhotoDetails == null)
                {
                    m_UploadResponse = new UploadResponse { ResponseCode = 0, UploadPath = "", ErrorMessage = "we can't upload more then 15 photos" };
                }
                else
                {
                    m_UploadResponse = new UploadResponse { ResponseCode = 1, UploadPath = _FilePath + GetExtension(_fileName), ErrorMessage = "" };
                }
                return m_UploadResponse;
            }
            catch (Exception ex)
            {
                string m_jsonText = JsonConvert.SerializeObject(ex);

                string m_ErrorFolder = ConfigurationManager.AppSettings["ErrorLogs"].ToString();
                if (!Directory.Exists(m_ErrorFolder))
                {
                   // return;
                }
                string m_FilePath = m_ErrorFolder + "Photo_Upload" + "_" + DateTime.Now.ToString("ddMMyyyyhhmmssnnn");
                File.WriteAllText(m_FilePath, m_jsonText);
                File.WriteAllText(m_FilePath + DateTime.Now.ToString("ddMMyyyyhhmmssnnn"), _PhotoObj.PhotoArray);
                return m_UploadResponse;
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
            return Path.GetFileName(FilePath).Replace(" ", "");
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }

    public class AddPicture
    {
        public string PhotoArray { get; set; }
        public string FileName { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int UserID { get; set; }
    }
}

    
