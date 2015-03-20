using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using IntellidateR1;


namespace IntelliWebR1.intelli
{
    public partial class c : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string _Js = "";

                if (Request.QueryString["sp"] != null)
                {
                    if (Request.QueryString["sp"].ToString() == "Y")
                    {
                        _Js = _Js + "var _SitePath = \"" + ConfigurationManager.AppSettings["SitePath"].ToString() + "\"; ";
                    }
                }

                if (Request.QueryString["m"] != null)
                {
                    _Js = _Js + GetJavaScriptString(Request.QueryString["m"].ToString());
                }
                if (Request.QueryString["s"] != null)
                {
                    Response.Clear();
                    if (Request.QueryString["t"] != null)
                    {
                        if (Request.QueryString["t"].ToString() == "j")
                        {
                            Response.ContentType = "text/javascript";
                            _Js = _Js + CompressedJS(Request.QueryString["s"].ToString());
                        }
                        else
                        {
                            Response.ContentType = "text/css";
                            _Js = _Js + CompressedCSS(Request.QueryString["s"].ToString());
                        }
                    }
                }



                Response.Write(_Js);
            }
            catch (Exception ex)
            {
                Response.Write(ex);
               // throw;
            }

        }

        private string GetJavaScriptString(string MessageCodes)
        {
            string _Js = "";
            
            ErrorMessages[] m_ErrorMessages = new ErrorMessages().GetErrorMessages(MessageCodes);

            foreach (ErrorMessages EachErrorMessage in m_ErrorMessages)
            {
                _Js = _Js + "var " + EachErrorMessage.ErrorCode + "=\"" + EachErrorMessage.ErrorMessage + "\"; ";
            }

            return _Js;
        }

        private string CompressedJS(string InString)
        {
            try
            {
                var compressor = new Yahoo.Yui.Compressor.JavaScriptCompressor
                {
                    Encoding = UTF8Encoding.UTF8,
                    DisableOptimizations = false,
                    ObfuscateJavascript = true,
                    PreserveAllSemicolons = true,
                    IgnoreEval = false
                };

                // Read full script file
                string _Decrypted = new IntellidateR1.EncryptDecrypt().Decrypt(InString.Split('-')[0]);
                string[] _ScriptsPath = _Decrypted.Split(',');

                string _JsContent = "";
                string _RootFolder = Server.MapPath("~").ToString();
                
                foreach (var EachScript in _ScriptsPath)
                {
                    if (EachScript.ToUpper().EndsWith("MIN"))
                    {
                        _JsContent = _JsContent + "\n" + File.ReadAllText(_RootFolder + "\\" + EachScript + ".js");
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["StaticDebug"].ToString() == "Y")
                        {
                            _JsContent = _JsContent + "\n" + File.ReadAllText(_RootFolder + "\\" + EachScript + ".js");
                        }
                        else
                        {
                            try
                            {
                                _JsContent = _JsContent + "\n" + compressor.Compress(File.ReadAllText(_RootFolder + "\\" + EachScript + ".js"));
                            }
                            catch (Exception)
                            {
                                
                                _JsContent = _JsContent + "\n" + File.ReadAllText(_RootFolder + "\\" + EachScript + ".js");
                            }
                        }
                        
                    }
                }
    
                return _JsContent;
                
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string CompressedCSS(string InString)
        {
            var compressor = new Yahoo.Yui.Compressor.CssCompressor
            {
                RemoveComments=true
            };

            // Read full script file
            string _Decrypted = new IntellidateR1.EncryptDecrypt().Decrypt(InString.Split('-')[0]);
            string[] _CSSPath = _Decrypted.Split(',');

            string _CssContent = "";
            string _RootFolder = Server.MapPath("~").ToString();
            foreach (var EachCss in _CSSPath)
            {
                _CssContent = _CssContent + "\n" + File.ReadAllText(_RootFolder + "\\" + EachCss + ".css");
            }

            if (ConfigurationManager.AppSettings["StaticDebug"].ToString() == "Y")
            {
                return _CssContent;
            }

            string _CompleteCss = _CssContent;
            return compressor.Compress(_CompleteCss);
        }
    }
}