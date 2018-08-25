using System;
using System.Collections.Generic;
using StaticShock.ViewModels;
using Xamarin.Forms;

namespace StaticShock.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _vm;
        public MainViewModel ViewModel
        {
            get
            {
                if (_vm == null)
                    _vm = new MainViewModel();

                if (BindingContext == null)
                    BindingContext = _vm;

                return (BindingContext as MainViewModel);
            }
        }

        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Initialize(null);
        }
    }
}
