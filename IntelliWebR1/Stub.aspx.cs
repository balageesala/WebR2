using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using IntellidateR1;
using IntelliWebR1.API;
using System.Drawing;
using System.Configuration;
namespace IntelliWebR1
{
    public partial class Stub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

         
            // new Conversation().SendMessage(62, 63, "hello hi");

            /*SelectedDate _obj=new SelectedDate();
               _obj.Day="31";
               _obj.Month="02";
               _obj.Year="1988";
               bool x = new IntelliWebR1.API.CheckDateOfBirthController().Post(_obj);*/

            // new User().RegisterUser("ramana", "ramana@gmail.com", "123456789", 1, Convert.ToDateTime("08/08/1988"));
            /* string[] _Files = Directory.GetFiles(@"C:\Users\basee_000\Documents\Visual Studio 2013\Projects\IntellidateR1\IntelliWebR1\web\inner\");
             string _Out = "";
             foreach (var item in _Files)
             {
                 if (item.EndsWith(".aspx"))
                 {
                     string _Name = item.Split('\\')[item.Split('\\').Length - 1];

                     _Out = _Out + "<br />" + _Name.Replace("inner_", "");
                 }
             }

             divOut.InnerHtml = _Out;*/
           // ResizeAllImages();

        }

        private void ResizeAllImages()
        {
            try
            {
                Photo[] _AllPhotos = new Photo().GetAllPhotos();

                List<ImageResizeDimension> _Dimensions = new List<ImageResizeDimension>();
                ImageResizeDimension _EachDimension = new ImageResizeDimension();

                foreach (var EachPhoto in _AllPhotos)
                {
                    _Dimensions = new List<ImageResizeDimension>();

                    _EachDimension = new ImageResizeDimension();
                    _EachDimension.CropAndProceed = true;
                    _EachDimension.CropX = EachPhoto.PhotoCropDetails.XPosition;
                    _EachDimension.CropY = EachPhoto.PhotoCropDetails.YPosition;
                    _EachDimension.CropWidth = EachPhoto.PhotoCropDetails.XWidth;
                    _EachDimension.CropHeight = EachPhoto.PhotoCropDetails.YWidth;

                    _EachDimension.Width = Convert.ToInt32(ConfigurationManager.AppSettings["PCT"]);
                    _EachDimension.Height = Convert.ToInt32(ConfigurationManager.AppSettings["PCT"]);
                    _EachDimension.Title = "PCT";
                    _Dimensions.Add(_EachDimension);


                    _EachDimension = new ImageResizeDimension();
                    _EachDimension.CropAndProceed = false;
                    _EachDimension.Title = "PCGT";
                    _EachDimension.Width = Convert.ToInt32(ConfigurationManager.AppSettings["PCGT"]);
                    _EachDimension.Height = 0;
                    _Dimensions.Add(_EachDimension);

                    string _Path = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + EachPhoto.PhotoPath;
                    new ImageResizeQueue().EnqueImage(_Path, _Dimensions.ToArray());
                }
            }
            catch (Exception)
            {

            }
        }

        private void CreateDummy()
        {
            string _Destination = @"C:\Users\basee_000\Documents\Visual Studio 2013\Projects\IntellidateR1\IntelliWebR1\images\grid\";
            string _Source = @"D:\Shared\Women\";

            string[] _Files = Directory.GetFiles(_Source);

            foreach (var item in _Files)
            {
                File.Copy(item, _Destination + item.Split('\\')[item.Split('\\').Length - 1]);
            }
        }

        protected void cmdConvert_Click(object sender, EventArgs e)
        {
            try
            {
                string _Input = txtInput.Value;
                string[] _AllLines = _Input.Split('\n');


                string _Output = "";
                string _VM = "";

                foreach (var item in _AllLines)
                {
                    if (item.Trim() != "")
                    {
                        _Output = item.Trim();
                        _Output = _Output.Replace("public ", "");
                        _Output = _Output.Replace(" { get; set; }", "");

                        if (_Output.Contains("[]"))
                        {
                            _Output = _Output.Split(' ')[1];
                            _VM = _VM + "<br />";
                            _VM = _VM + "<br />" + "self." + _Output + " = ko.observableArray();";
                            //if (_in.CriteriaOptions != null) {
                            _VM = _VM + "<br />" + "if (_in." + _Output + " != null) {";
                            _VM = _VM + "<br />" + "for (var i = 0; i < _in." + _Output + ".length; i++)";
                            _VM = _VM + "<br />" + "{";
                            _VM = _VM + "<br />" + "self." + _Output + ".push(new VM(_in." + _Output + "[i]));";
                            _VM = _VM + "<br />" + "}";
                            _VM = _VM + "<br />" + "}";
                            _VM = _VM + "<br />";
                        }
                        else
                        {
                            _Output = _Output.Split(' ')[1];
                            _VM = _VM + "<br />" + "self." + _Output + " = ko.observable(_in." + _Output + ");";
                        }


                    }
                }

                divOut.InnerHtml = _VM;
            }
            catch (Exception)
            {

            }
        }

        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

    }
}