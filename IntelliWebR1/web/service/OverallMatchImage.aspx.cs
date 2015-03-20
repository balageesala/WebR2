using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace IntelliWebR1.web.service
{
    public partial class OverallMatchImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double _Percentage = (Request.QueryString["p"] == null) ? 0 : Convert.ToDouble(Request.QueryString["p"]);
            Response.ContentType = "image/png";
            if (Request.QueryString["o"] != null)
            {
                using (Bitmap _Resized = GenerateOverallCompatibilityPercentageScreen(_Percentage))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        _Resized.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.WriteTo(Response.OutputStream);

                    }
                }
            }
            else
            {
                using (Bitmap _Resized = GenerateNormalPercentageScreen(_Percentage))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        _Resized.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.WriteTo(Response.OutputStream);

                    }
                }
            }
            
        }

        private Bitmap GenerateNormalPercentageScreen(double Percentage)
        {
            try
            {
                Bitmap _BlankSheet = new Bitmap(224, 224);

                Graphics _Graphics = Graphics.FromImage(_BlankSheet);

                _Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                _Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                SolidBrush _WhiteBrrush = new SolidBrush(Color.White);
                _Graphics.FillRectangle(_WhiteBrrush, new Rectangle(0, 0, 224, 224));

                SolidBrush _InnerCircleBrush = new SolidBrush(Color.FromArgb(231, 231, 231));
                Pen _InnerCirclePen = new Pen(_InnerCircleBrush, 26);
                _Graphics.DrawEllipse(_InnerCirclePen, new Rectangle(16, 16, 190, 190));


                SolidBrush _OuterCircleBrush = new SolidBrush(Color.FromArgb(80, 80, 80));
                Pen _OuterCirclePen = new Pen(_OuterCircleBrush, 26);
                float _sweepAngle = (Percentage < 0) ? 0 : (float)Percentage;
                _sweepAngle = _sweepAngle * (float)3.6;

                _Graphics.DrawArc(_OuterCirclePen, new Rectangle(16, 16, 190, 190),270, _sweepAngle);
    
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                
                Font _ValueFont = new Font("Tahoma", 26);
                RectangleF _ValueArea = new RectangleF(40, 90, 150, 50);
                string _ValueString = Percentage.ToString() + "%";
                if (Percentage < 0)
                {
                    _ValueFont = new Font("Tahoma", 40);
                    _ValueString = "?";
                }
                
                SolidBrush _ValueBrush = new SolidBrush(Color.FromArgb(87, 87, 87));
                _Graphics.DrawString(_ValueString, _ValueFont, _ValueBrush, _ValueArea, stringFormat);


                _Graphics.Save();
                return _BlankSheet;



            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private Bitmap GenerateOverallCompatibilityPercentageScreen(double Percentage)
        {
            try
            {
                Bitmap _BlankSheet = new Bitmap(224, 224);

                Graphics _Graphics = Graphics.FromImage(_BlankSheet);

                _Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                _Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                SolidBrush _WhiteBrrush = new SolidBrush(Color.White);
                _Graphics.FillRectangle(_WhiteBrrush, new Rectangle(0, 0, 224, 224));

                SolidBrush _InnerCircleBrush = new SolidBrush(Color.FromArgb(231, 231, 231));
                Pen _InnerCirclePen = new Pen(_InnerCircleBrush, 26);
                _Graphics.DrawEllipse(_InnerCirclePen, new Rectangle(16, 16, 190, 190));


                SolidBrush _OuterCircleBrush = new SolidBrush(Color.FromArgb(80, 80, 80));
                Pen _OuterCirclePen = new Pen(_OuterCircleBrush, 26);
                float _sweepAngle = (Percentage < 0) ? 0 : (float)Percentage;
                _sweepAngle = _sweepAngle * (float)3.6;

                _Graphics.DrawArc(_OuterCirclePen, new Rectangle(16, 16, 190, 190), 270, _sweepAngle);

                RectangleF _TitleArea = new RectangleF(40, 48, 140, 46);
                string _TitleString = "Overall\nCompatibility";
                SolidBrush _TitleBrush = new SolidBrush(Color.FromArgb(87, 87, 87));
                Font _TitleFont = new Font("Tahoma", 14);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                _Graphics.DrawString(_TitleString, _TitleFont, _TitleBrush, _TitleArea, stringFormat);


                Font _ValueFont = new Font("Tahoma", 26);
                RectangleF _ValueArea = new RectangleF(40, 110, 150, 50);
                string _ValueString = (Percentage < 0) ? "?" : Percentage.ToString() + "%";
                if (Percentage < 0)
                {
                    _ValueFont = new Font("Tahoma", 30);
                }
                SolidBrush _ValueBrush = new SolidBrush(Color.FromArgb(87, 87, 87));
                

                _Graphics.DrawString(_ValueString, _ValueFont, _ValueBrush, _ValueArea, stringFormat);

                Pen _RectangePen = new Pen(new SolidBrush(Color.Black));

                _Graphics.Save();
                return _BlankSheet;



            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}