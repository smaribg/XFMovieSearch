using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFMovieSearch.ViewModels
{

    class PopularViewModel : MovieListViewModel
    {
        private bool _isRefreshing = false;

        public PopularViewModel(IMovieApi api)
        {
            this._movies = new List<Movie>();
            this._api = api;
        }

        public async Task GetPopular()
        {
            this.Movies = await _api.GetMostPopularMovies();
            LoadMoreInfo();
        }

        public string Title
        {
            get => "Popular";
        }

        public bool IsRefreshing
        {
            get => this._isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await GetPopular();
                    IsRefreshing = false;
                });
            }
        }
    }
}
