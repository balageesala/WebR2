using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
namespace IntelliWebR1.web.service
{
    public partial class PercentageMeter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            double _Percentage = (Request.QueryString["p"] == null) ? 0 : Convert.ToDouble(Request.QueryString["p"]);
            Response.ContentType = "image/png";

            using (Bitmap _Resized = GeneratePercentageMeterScreen(Convert.ToInt32(_Percentage)))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    _Resized.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.WriteTo(Response.OutputStream);

                }
            }


        }



        private Bitmap GeneratePercentageMeterScreen(double Percentage)
        {
            try
            {
                Bitmap _BlankSheet = new Bitmap(224, 224);

                Graphics _Graphics = Graphics.FromImage(_BlankSheet);

                _Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                _Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                SolidBrush _WhiteBrrush = new SolidBrush(Color.FromArgb(46, 42, 41));
                _Graphics.FillRectangle(_WhiteBrrush, new Rectangle(0, 0, 224, 224));

                SolidBrush _InnerCircleBrush = new SolidBrush(Color.FromArgb(231, 231, 231));
                Pen _InnerCirclePen = new Pen(_InnerCircleBrush, 26);
                _Graphics.DrawEllipse(_InnerCirclePen, new Rectangle(16, 16, 190, 190));


                SolidBrush _OuterCircleBrush = new SolidBrush(Color.FromArgb(193, 40, 45));
                Pen _OuterCirclePen = new Pen(_OuterCircleBrush, 26);
                float _sweepAngle = (Percentage < 0) ? 0 : (float)Percentage;
                _sweepAngle = _sweepAngle * (float)3.6;

                _Graphics.DrawArc(_OuterCirclePen, new Rectangle(16, 16, 190, 190), 90, _sweepAngle);

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

                SolidBrush _ValueBrush = new SolidBrush(Color.White);
                _Graphics.DrawString(_ValueString, _ValueFont, _ValueBrush, _ValueArea, stringFormat);


                _Graphics.Save();
                return _BlankSheet;



            }
            catch (Exception)
            {
                return null;
            }
        }

        private double angle = 100;
        private double speed = 20;
        public Bitmap GenarateMeter(int value)
        {
            try
            {
                Bitmap _BlankSheet = new Bitmap(224, 224);
                Graphics _Graphics = Graphics.FromImage(_BlankSheet);
                _Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			
			
			
			//g.FillRectangle(Brushes.White,this.ClientRectangle);
			Font f = new Font("Times New Roman", 14,System.Drawing.FontStyle.Bold);

            _Graphics.TranslateTransform(224 / 2, 224 / 2);
            _Graphics.FillEllipse(Brushes.Black, 224 / -2, 224 / -2, 224, 224);

            _Graphics.DrawString("", f, Brushes.Green, -26, 224 / -4);
			
			
			//g.TranslateTransform(this.Width /2,this.Height/2);
            _Graphics.RotateTransform(225);
			for(int x = 0; x<45;x++)
			{
                _Graphics.FillRectangle(Brushes.Green, -2, (224 / 2 - 2) * -1, 3, 15);
                _Graphics.RotateTransform(5);
			}
            _Graphics.ResetTransform();

            _Graphics.TranslateTransform(224 / 2, 224 / 2);
            _Graphics.RotateTransform(225);
			int sp = 0;
			for(int x = 0; x<6; x++)
			{
                _Graphics.FillRectangle(Brushes.Red, -3, (224 / 2 - 2) * -1, 6, 25);
                _Graphics.DrawString(sp.ToString(), f, Brushes.Azure, (sp.ToString().Length) * (-6), (224 / -2) + 25);
                _Graphics.RotateTransform(45);
				sp += 20;
			}
            _Graphics.ResetTransform();

            _Graphics.TranslateTransform(224 / 2, 224 / 2);

            _Graphics.RotateTransform((float)angle);
			Pen P = new Pen(System.Drawing.SystemColors.Desktop,14);
			P.EndCap = LineCap.ArrowAnchor;
			P.StartCap = LineCap.RoundAnchor;
            _Graphics.DrawLine(P, 0, 0, 0, (-1) * (224 / 2.75F));
			//P.Width = 16;
			//g.DrawLine(P,0,0,0,(-1)*(this.Height/2.75F));


            _Graphics.ResetTransform();

            _Graphics.TranslateTransform(224 / 2, 224 / 2);

            _Graphics.FillEllipse(Brushes.Black, -6, -9, 14, 14);
            _Graphics.FillEllipse(Brushes.Red, -7, -7, 14, 14);

			P.Width = 4;
			P.Color = Color.Black;
			P.EndCap = LineCap.Round;
			P.StartCap = LineCap.Flat;
            _Graphics.DrawLine(P, 224 / 15.75F, 224 / 3.95F, 224/ 10.75F, 224 / 5.2F);
			
			P.Color = Color.Red;
            _Graphics.DrawLine(P, 224 / 15.75F, 224 / 3.95F, 224 / 15.75F, 224 / 4.6F);

			P.Dispose();
                 _Graphics.Save();
                 return _BlankSheet;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public double Speed
        {
            set
            {
                if (value > 131)
                    value = 131;
                this.angle = value * 2.25 + 225;
               
            }
            get
            {
                return this.speed;
            }
        }


        public Bitmap GetMeter(int value)
        {
            try
            {
                 int userInput;
                 string MeterImg = ConfigurationManager.AppSettings["SpeedMeterImage"].ToString();
                 string PointerImg = ConfigurationManager.AppSettings["PointerImage"].ToString();
                 Bitmap speedometer = new Bitmap(MeterImg);
                 Bitmap pointer = new Bitmap(PointerImg);
                 Bitmap finalImage = new Bitmap(speedometer);

            //Get Speed as user input

                 userInput = (value/10);

            using (Graphics graphics = Graphics.FromImage(finalImage))
            {
                //Rotate pointer image to the correct angle
                Bitmap rotatedPointer = RotateImage(pointer, userInput * 18);
                //Make POinter background transparent
                rotatedPointer.MakeTransparent(Color.White);

                graphics.SmoothingMode = SmoothingMode.HighQuality;
                //Draw Pointer on top of the speedometer image at identified location.
                graphics.DrawImage(rotatedPointer, 73, 185);

                //Save final image
               
            }


            return finalImage;

            }
            catch (Exception)
            {

                return null;
            }
        }


        public Bitmap RotateImage(Bitmap image, float angle)
        {
            Bitmap returnBitmap = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(returnBitmap);

            //set rotation point as the base point of pointer image
            g.TranslateTransform((float)222, (float)207);
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)111, -(float)107);

            g.DrawImage(image, new Point(0, 0));
            return returnBitmap;
        }




    }
}