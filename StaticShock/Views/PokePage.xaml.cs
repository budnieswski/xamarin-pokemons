using System;
using System.Collections.Generic;
using StaticShock.ViewModels;
using Xamarin.Forms;

namespace StaticShock.Views
{
    public partial class PokePage : ContentPage
    {
        private PokeViewModel _vm;
        public PokeViewModel ViewModel
        {
            get
            {
                if (_vm == null)
                    _vm = new PokeViewModel();

                BindingContext = _vm;

                return (BindingContext as PokeViewModel);
            }
        }

        public PokePage()
        {
            InitializeComponent();
        }
    }
}
