using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IntelliWebR1
{
    public static class Helper
    {
        public static string LoadScripts(string[] ScriptFilePaths, string[] IncludeMessages, bool IncludeSitePath)
        {
            //_Scripts = _Scripts + "\n" + "<script type=\"text/javascript\" src=\"" + SitePath + "intelli/c.date?t=j&s=" +  + "-" + ConfigurationManager.AppSettings["StaticVersion"].ToString() + "\"></script>";

            string _IncludeSitePathString = (IncludeSitePath) ? "&sp=Y" : "&sp=N";

            string _Encrypted = "";
            string _Joined= "";
            if (ScriptFilePaths.Count() > 0)
            {
                foreach (string EachScript in ScriptFilePaths)
                {
                    _Joined = _Joined + "," + EachScript;
                }
                _Joined = _Joined.Substring(1);

                _Encrypted = new IntellidateR1.EncryptDecrypt().Encrypt(_Joined);
            }
            if (IncludeMessages.Count()==0){
                return "<script type=\"text/javascript\" src=\"" + ConfigurationManager.AppSettings["SitePath"].ToString() + "intelli/c.date?t=j" + _IncludeSitePathString + "&s=" + _Encrypted + "-" + ConfigurationManager.AppSettings["StaticVersion"].ToString() + "\"></script>";
            }

            else
            {
                string _MessageCodes = "";

                foreach (var EachCode in IncludeMessages)
                {
                    _MessageCodes = _MessageCodes + "," + EachCode;
                }
                _MessageCodes = _MessageCodes.Substring(1);

                return "<script type=\"text/javascript\" src=\"" + ConfigurationManager.AppSettings["SitePath"].ToString() + "intelli/c.date?t=j" + _IncludeSitePathString + "&s=" + _Encrypted + "-" + ConfigurationManager.AppSettings["StaticVersion"].ToString() + "&m=" + _MessageCodes + "\"></script>";
            }
                
        }

        public static string LoadCSS(string[] CSSFilePaths)
        {
            //_Scripts = _Scripts + "\n" + "<script type=\"text/javascript\" src=\"" + SitePath + "intelli/c.date?t=j&s=" +  + "-" + ConfigurationManager.AppSettings["StaticVersion"].ToString() + "\"></script>";

            string _Encrypted = "";
            string _Joined = "";
            foreach (string EachScript in CSSFilePaths)
            {
                _Joined = _Joined + "," + EachScript;
            }
            _Joined = _Joined.Substring(1);

            _Encrypted = new IntellidateR1.EncryptDecrypt().Encrypt(_Joined);
           
            return "<link rel=\"stylesheet\" href=\"" + ConfigurationManager.AppSettings["SitePath"].ToString() + "intelli/c.date?t=c&s=" + _Encrypted + "-" + ConfigurationManager.AppSettings["StaticVersion"].ToString() + "\" />";
        }
    }
}