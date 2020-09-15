using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamrinEfCoreApi.Data;

namespace XamrinEfCoreApi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(new UserHttpService()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
