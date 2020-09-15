using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamrinEfCoreApi.Models;

namespace XamrinEfCoreApi.ViewModels
{
    public partial class UserViewModel 
    {

        private string _baseUrl = Settings.UrlBase;
        List<User> _users = new List<User>();        

        public UserViewModel()
        {
                    
        }       
    }
}
