using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Configuration;

namespace IntelliWebR1.web.inner
{
    public partial class photofullview : System.Web.UI.Page
    {
        int MaxWidth = 900;
        int MaxHeight = 500;

        int ArrowHeight = 102;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MaxWidth = Convert.ToInt32(ConfigurationManager.AppSettings["MaFullViewxWidth"]);
                MaxHeight = Convert.ToInt32(ConfigurationManager.AppSettings["MaFullViewxHeight"]);

                int PhotoID = Convert.ToInt32(Request.QueryString["pid"]);
                Photo PhotoDetails = new Photo().GetPhotoDetails(PhotoID);
                PhotoDetails = SetDimensions(PhotoDetails);
                SetContainer(PhotoDetails);
                StyleArrows(PhotoDetails);
                SetImage(PhotoDetails);
            }
            catch (Exception)
            {

            }
        }
        private void SetImage(Photo PhotoDetails)
        {
            imgFullView.Src = new Utils().GetPhotoFullViewPath(PhotoDetails.PhotoID, Page.Request);
            int _height=500;
            if (PhotoDetails.Height > 500)
            {
                _height = 560;
            }
            else
            {
                _height = PhotoDetails.Height;
            }


            imgFullView.Attributes.Add("style", "width:" + PhotoDetails.Width.ToString() + "px;height:" + _height.ToString() + "px;");
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

        private void SetContainer(Photo PhotoDetails)
        {
            try
            {
                string _StyleText = "";
                _StyleText = "width:" + PhotoDetails.Width.ToString() + "px;height:" + PhotoDetails.Height.ToString() + "px;";

                divContainer.Attributes.Add("style", _StyleText);
            }
            catch (Exception)
            {

            }
        }

        private void StyleArrows(Photo PhotoDetails)
        {
            try
            {
                int _top = (PhotoDetails.Height - ArrowHeight) / 2;

                string _ArrowLeftStyle = "position:fixed;left:10px;top:" + _top.ToString() + "px";
                string _ArrowRightStyle = "position:fixed;left:" + (PhotoDetails.Width - 102).ToString() + "px;top:" + _top.ToString() + "px";

               // imgPrevious.Attributes.Add("style", _ArrowLeftStyle);
             //   imgNext.Attributes.Add("style", _ArrowRightStyle);
                
            }
            catch (Exception)
            {

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
}