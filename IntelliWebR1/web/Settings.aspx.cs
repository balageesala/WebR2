using IntelliWebR1.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddPicture _Obj = new AddPicture();
            _Obj.FileName = FUpload.FileName;
            _Obj.PhotoArray = "";
            _Obj.UserID = 197;
            _Obj.X1 = 100;
            _Obj.X2 = 100;
            _Obj.Y1 = 100;
            _Obj.Y2 = 100;
            var _Result = new IntelliWebR1.API.PhotoUploadController().POST(_Obj);
        }
    }
}