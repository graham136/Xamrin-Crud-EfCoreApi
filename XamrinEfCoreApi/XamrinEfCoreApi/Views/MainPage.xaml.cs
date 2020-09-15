using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamrinEfCoreApi.Data;
using XamrinEfCoreApi.Models;
using XamrinEfCoreApi.ViewModels;
using XamrinEfCoreApi.Views;

namespace XamrinEfCoreApi
{
    public partial class MainPage : ContentPage
    {
        //Will add the ViewModel in the second commit to have both code behind and Viewmodel implementations on the record.
        //UserViewModel userViewModel;



        private HttpClient _client = new HttpClient();
        private ObservableCollection<User> _users;

        private UserHttpService _userHttpService;
        public MainPage(UserHttpService userHttpService)
        {
            InitializeComponent();

            Loader.IsRunning = true;
            Loader.IsVisible = true;
            Loader.IsEnabled = true;

            UsersList.IsEnabled = false;
            UsersList.IsVisible = false;

            // Will add the ViewModel in the second commit to have both code behind and Viewmodel implementations on the record.
            //userViewModel = new UserViewModel();           

            _userHttpService = userHttpService;
        }

        protected override async void OnAppearing()
        {
            // Getting the current userlist
            var users = await _userHttpService.GetUsersAsync();
            _users = new ObservableCollection<User>(users);

            UsersList.ItemsSource = _users;

            // Hiding the loader and displaying the UserList
            Loader.IsRunning = false;
            Loader.IsVisible = false;
            Loader.IsEnabled = false;

            UsersList.IsEnabled = true;
            UsersList.IsVisible = true;

        }

        public async void OnEdit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            User tempUser = (User)mi.CommandParameter;
            var userEditPage = new UserEditPage(new UserHttpService());
            
            var user = new User()
            {
                UserId = tempUser.UserId,
                UserName = tempUser.UserName,
                UserPassword = tempUser.UserPassword
            };

            userEditPage.BindingContext = user;
            await Navigation.PushAsync(userEditPage);
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            User tempUser = (User)mi.CommandParameter;
                         
            if (await _userHttpService.DeleteUserAsync(tempUser))
            {
                await DisplayAlert("Success", "User successfully deleted", "OK");
                var users = await _userHttpService.GetUsersAsync();
                _users = new ObservableCollection<User>(users);
                UsersList.ItemsSource = _users;
            }
            else
            {
                await DisplayAlert("Failure", "Something went wrong", "Ok");
            }
        }

        public async void OnAdd(object sender, EventArgs e)
        {
            var userAddPage = new UserAddPage(new UserHttpService());            
            await Navigation.PushAsync(userAddPage);
        }

        public void OnExit(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
