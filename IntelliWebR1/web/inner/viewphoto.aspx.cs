using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class viewphoto : System.Web.UI.Page
    {
        int MaxWidth = 616;
        int MaxHeight = 503;

        int ArrowHeight = 102;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int PhotoID = Convert.ToInt32(Request.QueryString["pid"]);
                Photo PhotoDetails = new Photo().GetPhotoDetails(PhotoID);
                PhotoDetails = SetDimensions(PhotoDetails);
                string _photoPath = new Utils().GetOriginalRootPath(PhotoDetails.PhotoID);

                using (Bitmap _Resized = new Bitmap(_photoPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        _Resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ms.WriteTo(Response.OutputStream);

                    }
                }


            }
            catch (Exception)
            {

            }
        }

        private Photo SetDimensions(Photo PhotoDetails)
        {
            // Landscape
            if (PhotoDetails.Width > PhotoDetails.Height)
            {
                PhotoDetails.Height = CalculateHeight(PhotoDetails.Width, PhotoDetails.Height, MaxWidth);
                PhotoDetails.Width = MaxWidth;
            }
            else //Potrait
            {

                PhotoDetails.Width = CalculateWidth(PhotoDetails.Height, PhotoDetails.Width, MaxHeight);
                PhotoDetails.Height = MaxHeight;
            }

            return PhotoDetails;
        }


        private int CalculateHeight(int Width, int Height, int ConstantWidth)
        {
            try
            {
                int _Height = (Height * ConstantWidth) / Width;
                return _Height;
            }
            catch (Exception)
            {
                return Height;
            }
        }

        private int CalculateWidth(int Height, int Width, int ConstantHeight)
        {
            try
            {
                int _Width = (Width * ConstantHeight) / Height;
                return _Width;
            }
            catch (Exception)
            {
                return Height;
            }
        }
    }
}