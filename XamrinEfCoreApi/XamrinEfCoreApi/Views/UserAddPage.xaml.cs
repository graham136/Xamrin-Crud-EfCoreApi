using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XamrinEfCoreApi.Data;
using XamrinEfCoreApi.Models;

namespace XamrinEfCoreApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAddPage : ContentPage
    {
        private UserHttpService _userHttpService; 
        public UserAddPage(UserHttpService userHttpService)
        {
            InitializeComponent();
            _userHttpService = userHttpService;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                UserName = UserName.Text,
                UserPassword = UserPassword.Text
            };           

            if (await _userHttpService.AddUserAsync(user))
            {
                await DisplayAlert("Success","User successfully added", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Failure", "Something went wrong", "Ok");
            }
        }
    }
}