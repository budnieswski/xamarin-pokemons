using StaticShock.Models;
using StaticShock.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StaticShock.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        ObservableCollection<Pokemon> _pokemons = new ObservableCollection<Pokemon>();
        public ObservableCollection<Pokemon> Pokemons {
            get { return _pokemons;  }
            set { _pokemons = value; OnPropertyChanged();  }
        }

        public MainViewModel() : base("Static Shock")
        {
            RefreshCommand = new Command(async () => await LoadData(), () => !IsBusy);
            ItemClickCommand = new Command<Pokemon>(async (item) => await ItemClickCommandExecuteAsync(item));
        }

        public override async Task Initialize(object parameters = null) => await LoadData();

        async Task ItemClickCommandExecuteAsync(Pokemon pokemon)
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;
                var pokePage = new PokePage();
                await pokePage.ViewModel.Initialize(pokemon);

                await Navigation.PushAsync(pokePage);
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

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                //var pokemons = await FakeData();
                var pokemons = await API.getPokemonsAsync();

                Pokemons.Clear();
                foreach (var pokemon in pokemons)
                    Pokemons.Add(pokemon);
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

        async Task<List<Pokemon>> FakeData() => await Task.FromResult(new List<Pokemon>
        {
            new Pokemon { Name= "Pikachu", Url = "globo.com" },
            new Pokemon { Name= "Bubasar", Url = "globo.com" },
            new Pokemon { Name= "Aleatorio", Url = "globo.com" },
            new Pokemon { Name= "Feio", Url = "globo.com" },
            new Pokemon { Name= "Bonito", Url = "globo.com" },
            new Pokemon { Name= "Gordo", Url = "globo.com" },

        }); 
    }
}
