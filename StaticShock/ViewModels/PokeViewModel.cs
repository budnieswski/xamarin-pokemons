using StaticShock.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StaticShock.ViewModels
{
    public class PokeViewModel : BaseViewModel
    {
        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value; OnPropertyChanged();
            }
        }

        private PokemonInformation _information;
        public PokemonInformation Information
        {
            get
            {
                return _information;
            }
            set
            {
                _information = value; OnPropertyChanged();
            }
        }


        public PokeViewModel() : base("")
        {
        }

        public override async Task Initialize(object parameters)
        {
            var pokemon = parameters as Pokemon;

            Title = pokemon.Name;
            Url = pokemon.Url;

            await LoadData();
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                var poke = await API.getPokemonAsync(Url);
                Information = poke;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }
    }
}
