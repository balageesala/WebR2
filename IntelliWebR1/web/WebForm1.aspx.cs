using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntelliWebR1.API;
using System.IO;
using System.Text;

namespace IntelliWebR1.web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            AddPicture _Obj = new AddPicture();
            _Obj.FileName = "sample.jpeg";
            _Obj.PhotoArray = Convert.ToBase64String(FUpload.FileBytes);
            _Obj.UserID = 197;
            _Obj.X1 = 100;
            _Obj.X2 = 100;
            _Obj.Y1 = 100;
            _Obj.Y2 = 100;
            var _Result = new IntelliWebR1.API.PhotoUploadController().POST(_Obj);

        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }



    
    }
}