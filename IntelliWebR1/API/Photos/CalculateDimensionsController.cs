using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using IntellidateR1;

namespace IntelliWebR1.API.Photos
{
    public class CalculateDimensionsController : ApiController
    {
        // POST api/<controller>
        public PhotoDimension Post([FromBody]CalculateDimensions _CalculateDimensions)
        {
            try
            {
                int MaxWidth = Convert.ToInt32(ConfigurationManager.AppSettings["MaFullViewxWidth"]);
                int MaxHeight = Convert.ToInt32(ConfigurationManager.AppSettings["MaFullViewxHeight"]);

                Photo PhotoDetails = new Photo().GetPhotoDetails(_CalculateDimensions.PhotoID);

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

                return new PhotoDimension
                {
                    Height = PhotoDetails.Height,
                    Width = PhotoDetails.Width
                };
            }
            catch (Exception)
            {
                return null;
            }
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

    public class CalculateDimensions
    {
        public int PhotoID { get; set; }

    }

    public class PhotoDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}