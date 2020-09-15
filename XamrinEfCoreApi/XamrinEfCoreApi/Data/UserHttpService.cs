using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamrinEfCoreApi.Interfaces;
using XamrinEfCoreApi.Models;

namespace XamrinEfCoreApi.Data
{
    public class UserHttpService : IUserHttpService
    {
        string _baseUrl;
        private HttpClient _client;
        public UserHttpService()
        {
            _baseUrl = Settings.UrlBase;

            // Adding this in to debug on local visual studio asp.net core web api.
            // Removes the check for the secure certificate.
            // Not good to leave this in for production

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            _client = new HttpClient(httpClientHandler);

        }
        
        public async Task<bool> AddUserAsync(User user)
        {
            Uri uri = new Uri(string.Format(Settings.UrlBase + "Users"));

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await _client.PostAsync(uri, content);

            return response.IsSuccessStatusCode;
            
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            Uri uri = new Uri(string.Format(Settings.UrlBase + "Users/" + user.UserId));

            HttpResponseMessage response = null;
            response = await _client.DeleteAsync(uri);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var url = _baseUrl + "Users";
            var content = await _client.GetStringAsync(url);
            var users = JsonConvert.DeserializeObject<List<User>>(content);
            return users;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            Uri uri = new Uri(string.Format(Settings.UrlBase + "Users/" + user.UserId));

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await _client.PutAsync(uri, content);
            return response.IsSuccessStatusCode;
        }
    }
}
