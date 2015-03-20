using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IntelliWebR1.web.service
{
    public partial class DrawPercentage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _Value = Request.QueryString["v"].ToString();

            Response.ContentType = "image/PNG";
            // Check if value is -1 
            if (_Value == "-1")
            {
                Bitmap _Percentage = DrawUnknown();
                using (_Percentage)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        _Percentage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.WriteTo(Response.OutputStream);

                    }
                }
            }
            else
            {
                Bitmap _Percentage = DrawEclipse(Convert.ToDouble(_Value));
                using (_Percentage)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        _Percentage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.WriteTo(Response.OutputStream);

                    }
                }
            }



        }

        private Bitmap DrawUnknown()
        {
            try
            {
                int _width = 250;
                Bitmap _Image = new Bitmap(_width, _width);
                Graphics _g = Graphics.FromImage(_Image);

                float _penWidth = (float)24;
                Pen _penborder = new Pen(Color.FromArgb(230, 230, 230), _penWidth);

                _g.SmoothingMode = SmoothingMode.AntiAlias;
                _g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                _g.DrawArc(_penborder, new Rectangle(20, 20, 210, 210), 270, (float)(100 * 3.6));

                string _QuestionMarkPath = ConfigurationManager.AppSettings["PhotosFolder"].ToString() + "questionmark.png";
                using (Bitmap _QuestionMark = new Bitmap(_QuestionMarkPath))
                {
                    _g.DrawImage(_QuestionMark, 0, 0);
                }

                _g.Save();
                return _Image;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Bitmap DrawEclipse(double PercentageValue)
        {
            try
            {
                int _width = 250;
                Bitmap _Image = new Bitmap(_width, _width);
                Graphics _g = Graphics.FromImage(_Image);
                float _penWidth = (float)24;
                Pen _pen = new Pen(Color.FromArgb(244, 210, 122), _penWidth);
                Pen _penborder = new Pen(Color.FromArgb(230, 230, 230), _penWidth);

                float _angle = (float)90;
                _g.SmoothingMode = SmoothingMode.AntiAlias;
                _g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                _g.DrawArc(_penborder, new Rectangle(20, 20, 210, 210), 270, (float)(100 * 3.6));
                _g.DrawArc(_pen, new Rectangle(20, 20, 210, 210), 270, (float)(PercentageValue * 3.6));

                Pen _LitePen = new Pen(Color.FromArgb(50, 244, 210, 122), _penWidth);
                //_g.DrawArc(_LitePen, new Rectangle(50, 50, 300, 300), 270, Percentage);
                //_g.DrawArc(_pen, new Rectangle(50, 50, 300, 300), 270, Percentage);


                using (Font font1 = new Font("Arial", 30, FontStyle.Regular, GraphicsUnit.Point))
                {
                    Rectangle rect1 = new Rectangle(20, 20, 210, 210);

                    // Create a StringFormat object with the each line of text, and the block 
                    // of text centered on the page.
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Trimming = StringTrimming.EllipsisWord;


                    // Draw the text and the surrounding rectangle.
                    _g.DrawString(PercentageValue.ToString() + "%", font1, Brushes.Black, rect1, stringFormat);

                    SizeF _size = _g.MeasureString(PercentageValue.ToString(), font1, 36);
                    Font font2 = new Font("Arial", 26, FontStyle.Regular, GraphicsUnit.Point);

                    PointF _position = new PointF();
                    _position.X = rect1.X + _size.Width;
                    _position.Y = rect1.Y;

                    //_g.DrawString("%", font2, Brushes.Black, _position, StringFormat.GenericDefault);

                    //_g.DrawRectangle(Pens.Black, rect1);
                }

                _g.Save();
                return _Image;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}