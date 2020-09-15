using System;
using System.Collections.Generic;
using System.Text;

namespace XamrinEfCoreApi.Models
{
    public static class Settings
    {
        private const string _urlBase = "https://10.0.2.2:5001/api/";

        public static string UrlBase { 
        get
            {
                return _urlBase;
            }
        }
    }
}
