using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StaticShock
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            var rootPage = new Views.MainPage();
            MainPage = new NavigationPage(rootPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
